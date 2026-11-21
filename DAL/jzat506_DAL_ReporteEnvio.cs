using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_ReporteEnvio
    {
        public List<jzat506_Pedido> jzat506_ObtenerEnvios(DateTime desde, DateTime hasta, string estado, int idZona)
        {
            List<jzat506_Pedido> lista = new List<jzat506_Pedido>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT p.IdPedido, p.IdFactura, p.Fecha, p.Estado, p.DVH,
                                        e.IdEnvio, e.IdZona, e.Direccion, e.Telefono, e.CostoEnvio, e.MedioPago, e.DVH AS DVHEnvio,
                                        e.IdTransportista, t.Nombre AS NombreTransportista, t.Apellido AS ApellidoTransportista,
                                        z.Localidad, z.CodigoPostal,
                                        f.Total, c.DNI, c.Nombre, c.Apellido
                                 FROM Pedido p
                                 INNER JOIN Envio e ON e.IdPedido = p.IdPedido
                                 INNER JOIN ZonaCobertura z ON z.IdZona = e.IdZona
                                 INNER JOIN Factura f ON f.IdFactura = p.IdFactura
                                 INNER JOIN Cliente c ON c.IdCliente = f.IdCliente
                                 LEFT JOIN Transportista t ON t.IdTransportista = e.IdTransportista
                                 WHERE p.Fecha >= @Desde AND p.Fecha < @Hasta
                                 AND (@Estado = '' OR p.Estado = @Estado)
                                 AND (@IdZona = 0 OR e.IdZona = @IdZona)
                                 ORDER BY p.Fecha DESC, p.IdPedido DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date.AddDays(1));
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@IdZona", idZona);

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
                            pedido.jzat506_Factura.jzat506_Cliente.jzat506_DNI = Convert.ToInt32(reader["DNI"]);
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
                            }

                            lista.Add(pedido);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
