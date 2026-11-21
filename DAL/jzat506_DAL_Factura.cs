using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_Factura
    {
        public int jzat506_InsertarFactura(jzat506_Factura factura)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string queryFactura = @"INSERT INTO Factura (IdCliente, Fecha, Total, MedioPago, DVH)
                                         OUTPUT INSERTED.IdFactura
                                         VALUES (@IdCliente, @Fecha, @Total, @MedioPago, 0)";

                int idFactura;
                using (SqlCommand cmd = new SqlCommand(queryFactura, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", factura.jzat506_Cliente.jzat506_Id);
                    cmd.Parameters.AddWithValue("@Fecha", factura.jzat506_Fecha);
                    cmd.Parameters.AddWithValue("@Total", factura.jzat506_Total);
                    cmd.Parameters.AddWithValue("@MedioPago", factura.jzat506_MedioPago);
                    idFactura = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string queryDetalle = @"INSERT INTO DetalleFactura (IdFactura, IdProducto, Cantidad, PrecioUnitario, DVH)
                                         OUTPUT INSERTED.IdDetalle
                                         VALUES (@IdFactura, @IdProducto, @Cantidad, @PrecioUnitario, 0)";

                foreach (jzat506_DetalleFactura detalle in factura.jzat506_Detalles)
                {
                    using (SqlCommand cmd = new SqlCommand(queryDetalle, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdFactura", idFactura);
                        cmd.Parameters.AddWithValue("@IdProducto", detalle.jzat506_Producto.jzat506_Id);
                        cmd.Parameters.AddWithValue("@Cantidad", detalle.jzat506_Cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", detalle.jzat506_PrecioUnitario);
                        detalle.jzat506_Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return idFactura;
            }
        }

        public void jzat506_ActualizarDVH(int idFactura, int dvh)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE Factura SET DVH = @DVH WHERE IdFactura = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVH", dvh);
                    cmd.Parameters.AddWithValue("@Id", idFactura);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void jzat506_ActualizarDVHDetalle(int idDetalle, int dvh)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE DetalleFactura SET DVH = @DVH WHERE IdDetalle = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVH", dvh);
                    cmd.Parameters.AddWithValue("@Id", idDetalle);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<jzat506_Factura> jzat506_ObtenerTodas()
        {
            List<jzat506_Factura> lista = new List<jzat506_Factura>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT IdFactura, IdCliente, Fecha, Total, MedioPago, DVH FROM Factura";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new jzat506_Factura
                        {
                            jzat506_Id = Convert.ToInt32(reader["IdFactura"]),
                            jzat506_Cliente = new jzat506_Cliente { jzat506_Id = Convert.ToInt32(reader["IdCliente"]) },
                            jzat506_Fecha = Convert.ToDateTime(reader["Fecha"]),
                            jzat506_Total = Convert.ToDecimal(reader["Total"]),
                            jzat506_MedioPago = reader["MedioPago"].ToString() ?? "",
                            jzat506_DVH = Convert.ToInt32(reader["DVH"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<jzat506_DetalleFactura> jzat506_ObtenerTodosDetalles()
        {
            List<jzat506_DetalleFactura> lista = new List<jzat506_DetalleFactura>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT IdDetalle, IdProducto, Cantidad, PrecioUnitario, DVH FROM DetalleFactura";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new jzat506_DetalleFactura
                        {
                            jzat506_Id = Convert.ToInt32(reader["IdDetalle"]),
                            jzat506_Producto = new jzat506_Producto { jzat506_Id = Convert.ToInt32(reader["IdProducto"]) },
                            jzat506_Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            jzat506_PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                            jzat506_DVH = Convert.ToInt32(reader["DVH"])
                        });
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

                string query = "UPDATE DVVertical SET ValorDVV = @DVV WHERE Tabla = 'Factura'";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVV", dvv);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void jzat506_ActualizarDVVDetalle(int dvv)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE DVVertical SET ValorDVV = @DVV WHERE Tabla = 'DetalleFactura'";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVV", dvv);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
