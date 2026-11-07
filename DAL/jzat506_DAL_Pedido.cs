using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_Pedido
    {
        public List<jzat506_Factura> jzat506_ObtenerFacturasSinPedido(int idCliente)
        {
            List<jzat506_Factura> lista = new List<jzat506_Factura>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT IdFactura, Fecha, Total, MedioPago, DVH
                                 FROM Factura
                                 WHERE IdCliente = @IdCliente
                                 AND IdFactura NOT IN (SELECT IdFactura FROM Pedido)
                                 ORDER BY Fecha DESC, IdFactura DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new jzat506_Factura
                            {
                                jzat506_Id = Convert.ToInt32(reader["IdFactura"]),
                                jzat506_Cliente = new jzat506_Cliente { jzat506_Id = idCliente },
                                jzat506_Fecha = Convert.ToDateTime(reader["Fecha"]),
                                jzat506_Total = Convert.ToDecimal(reader["Total"]),
                                jzat506_MedioPago = reader["MedioPago"].ToString() ?? "",
                                jzat506_DVH = Convert.ToInt32(reader["DVH"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public int jzat506_InsertarPedido(jzat506_Pedido pedido, jzat506_Envio envio)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string queryPedido = @"INSERT INTO Pedido (IdFactura, Fecha, Estado, DVH)
                                           OUTPUT INSERTED.IdPedido
                                           VALUES (@IdFactura, @Fecha, @Estado, 0)";

                    int idPedido;
                    using (SqlCommand cmd = new SqlCommand(queryPedido, cn, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@IdFactura", pedido.jzat506_Factura.jzat506_Id);
                        cmd.Parameters.AddWithValue("@Fecha", pedido.jzat506_Fecha);
                        cmd.Parameters.AddWithValue("@Estado", pedido.jzat506_Estado);
                        idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string queryEnvio = @"INSERT INTO Envio (IdPedido, IdZona, Direccion, Telefono, CostoEnvio, MedioPago, DVH)
                                          OUTPUT INSERTED.IdEnvio
                                          VALUES (@IdPedido, @IdZona, @Direccion, @Telefono, @CostoEnvio, @MedioPago, 0)";

                    using (SqlCommand cmd = new SqlCommand(queryEnvio, cn, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmd.Parameters.AddWithValue("@IdZona", envio.jzat506_Zona.jzat506_Id);
                        cmd.Parameters.AddWithValue("@Direccion", envio.jzat506_Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", envio.jzat506_Telefono);
                        cmd.Parameters.AddWithValue("@CostoEnvio", envio.jzat506_CostoEnvio);
                        cmd.Parameters.AddWithValue("@MedioPago", envio.jzat506_MedioPago);
                        envio.jzat506_Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    transaccion.Commit();
                    pedido.jzat506_Id = idPedido;
                    return idPedido;
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        public List<jzat506_Pedido> jzat506_ObtenerNoEntregados()
        {
            List<jzat506_Pedido> lista = new List<jzat506_Pedido>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT p.IdPedido, p.IdFactura, p.Fecha, p.Estado, p.DVH,
                                        e.IdEnvio, e.IdZona, e.Direccion, e.Telefono, e.CostoEnvio, e.MedioPago, e.DVH AS DVHEnvio,
                                        e.IdTransportista, t.Nombre AS NombreTransportista, t.Apellido AS ApellidoTransportista,
                                        z.Localidad, z.CodigoPostal,
                                        f.Total, c.Nombre, c.Apellido
                                 FROM Pedido p
                                 INNER JOIN Envio e ON e.IdPedido = p.IdPedido
                                 INNER JOIN ZonaCobertura z ON z.IdZona = e.IdZona
                                 INNER JOIN Factura f ON f.IdFactura = p.IdFactura
                                 INNER JOIN Cliente c ON c.IdCliente = f.IdCliente
                                 LEFT JOIN Transportista t ON t.IdTransportista = e.IdTransportista
                                 WHERE p.Estado <> 'Entregado'
                                 ORDER BY p.Fecha, p.IdPedido";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jzat506_Pedido pedido = new jzat506_Pedido();
                        pedido.jzat506_Id = Convert.ToInt32(reader["IdPedido"]);
                        pedido.jzat506_Fecha = Convert.ToDateTime(reader["Fecha"]);
                        pedido.jzat506_Estado = reader["Estado"].ToString() ?? "";
                        pedido.jzat506_DVH = Convert.ToInt32(reader["DVH"]);

                        pedido.jzat506_Factura = new jzat506_Factura();
                        pedido.jzat506_Factura.jzat506_Id = Convert.ToInt32(reader["IdFactura"]);
                        pedido.jzat506_Factura.jzat506_Total = Convert.ToDecimal(reader["Total"]);
                        pedido.jzat506_Factura.jzat506_Cliente = new jzat506_Cliente();
                        pedido.jzat506_Factura.jzat506_Cliente.jzat506_Nombre = reader["Nombre"].ToString() ?? "";
                        pedido.jzat506_Factura.jzat506_Cliente.jzat506_Apellido = reader["Apellido"].ToString() ?? "";

                        pedido.jzat506_Envio = new jzat506_Envio();
                        pedido.jzat506_Envio.jzat506_Id = Convert.ToInt32(reader["IdEnvio"]);
                        pedido.jzat506_Envio.jzat506_Direccion = reader["Direccion"].ToString() ?? "";
                        pedido.jzat506_Envio.jzat506_Telefono = reader["Telefono"].ToString() ?? "";
                        pedido.jzat506_Envio.jzat506_CostoEnvio = Convert.ToDecimal(reader["CostoEnvio"]);
                        pedido.jzat506_Envio.jzat506_MedioPago = reader["MedioPago"].ToString() ?? "";
                        pedido.jzat506_Envio.jzat506_DVH = Convert.ToInt32(reader["DVHEnvio"]);

                        pedido.jzat506_Envio.jzat506_Zona = new jzat506_ZonaCobertura();
                        pedido.jzat506_Envio.jzat506_Zona.jzat506_Id = Convert.ToInt32(reader["IdZona"]);
                        pedido.jzat506_Envio.jzat506_Zona.jzat506_Localidad = reader["Localidad"].ToString() ?? "";
                        pedido.jzat506_Envio.jzat506_Zona.jzat506_CodigoPostal = reader["CodigoPostal"].ToString() ?? "";

                        if (reader["IdTransportista"] != DBNull.Value)
                        {
                            pedido.jzat506_Envio.jzat506_Transportista = new jzat506_Transportista();
                            pedido.jzat506_Envio.jzat506_Transportista.jzat506_Id = Convert.ToInt32(reader["IdTransportista"]);
                            pedido.jzat506_Envio.jzat506_Transportista.jzat506_Nombre = reader["NombreTransportista"].ToString() ?? "";
                            pedido.jzat506_Envio.jzat506_Transportista.jzat506_Apellido = reader["ApellidoTransportista"].ToString() ?? "";
                            pedido.jzat506_Envio.jzat506_Transportista.jzat506_PedidoActual = pedido.jzat506_Id;
                        }

                        lista.Add(pedido);
                    }
                }

                foreach (jzat506_Pedido pedido in lista)
                {
                    string queryDetalle = @"SELECT d.Cantidad, d.PrecioUnitario, pr.Nombre
                                            FROM DetalleFactura d
                                            INNER JOIN Producto pr ON pr.IdProducto = d.IdProducto
                                            WHERE d.IdFactura = @IdFactura";

                    using (SqlCommand cmd = new SqlCommand(queryDetalle, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdFactura", pedido.jzat506_Factura.jzat506_Id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                jzat506_DetalleFactura detalle = new jzat506_DetalleFactura();
                                detalle.jzat506_Cantidad = Convert.ToInt32(reader["Cantidad"]);
                                detalle.jzat506_PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]);
                                detalle.jzat506_Producto = new jzat506_Producto();
                                detalle.jzat506_Producto.jzat506_Nombre = reader["Nombre"].ToString() ?? "";
                                pedido.jzat506_Factura.jzat506_Detalles.Add(detalle);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        public void jzat506_ActualizarEstado(int idPedido, string estado)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE Pedido SET Estado = @Estado WHERE IdPedido = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@Id", idPedido);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void jzat506_ActualizarDVH(int idPedido, int dvh)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE Pedido SET DVH = @DVH WHERE IdPedido = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVH", dvh);
                    cmd.Parameters.AddWithValue("@Id", idPedido);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void jzat506_ActualizarDVHEnvio(int idEnvio, int dvh)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE Envio SET DVH = @DVH WHERE IdEnvio = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVH", dvh);
                    cmd.Parameters.AddWithValue("@Id", idEnvio);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<jzat506_Pedido> jzat506_ObtenerTodos()
        {
            List<jzat506_Pedido> lista = new List<jzat506_Pedido>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT IdPedido, IdFactura, Fecha, Estado, DVH FROM Pedido";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new jzat506_Pedido
                        {
                            jzat506_Id = Convert.ToInt32(reader["IdPedido"]),
                            jzat506_Factura = new jzat506_Factura { jzat506_Id = Convert.ToInt32(reader["IdFactura"]) },
                            jzat506_Fecha = Convert.ToDateTime(reader["Fecha"]),
                            jzat506_Estado = reader["Estado"].ToString() ?? "",
                            jzat506_DVH = Convert.ToInt32(reader["DVH"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<jzat506_Envio> jzat506_ObtenerTodosEnvios()
        {
            List<jzat506_Envio> lista = new List<jzat506_Envio>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT IdEnvio, IdZona, Direccion, Telefono, CostoEnvio, MedioPago, IdTransportista, DVH FROM Envio";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jzat506_Envio envio = new jzat506_Envio
                        {
                            jzat506_Id = Convert.ToInt32(reader["IdEnvio"]),
                            jzat506_Zona = new jzat506_ZonaCobertura { jzat506_Id = Convert.ToInt32(reader["IdZona"]) },
                            jzat506_Direccion = reader["Direccion"].ToString() ?? "",
                            jzat506_Telefono = reader["Telefono"].ToString() ?? "",
                            jzat506_CostoEnvio = Convert.ToDecimal(reader["CostoEnvio"]),
                            jzat506_MedioPago = reader["MedioPago"].ToString() ?? "",
                            jzat506_DVH = Convert.ToInt32(reader["DVH"])
                        };

                        if (reader["IdTransportista"] != DBNull.Value)
                            envio.jzat506_Transportista = new jzat506_Transportista { jzat506_Id = Convert.ToInt32(reader["IdTransportista"]) };

                        lista.Add(envio);
                    }
                }
            }

            return lista;
        }

        public void jzat506_ActualizarDVV(int dvv)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE DVVertical SET ValorDVV = @DVV WHERE Tabla = 'Pedido'";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVV", dvv);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void jzat506_ActualizarDVVEnvio(int dvv)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE DVVertical SET ValorDVV = @DVV WHERE Tabla = 'Envio'";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVV", dvv);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
