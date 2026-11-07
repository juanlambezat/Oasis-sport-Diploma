using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_ReporteFactura
    {
        public List<jzat506_Factura> jzat506_ObtenerFacturasPorCliente(int idCliente)
        {
            List<jzat506_Factura> lista = new List<jzat506_Factura>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT IdFactura, Fecha, Total, MedioPago, DVH
                                 FROM Factura
                                 WHERE IdCliente = @IdCliente
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

        public Dictionary<int, List<jzat506_DetalleFactura>> jzat506_ObtenerDetallesPorCliente(int idCliente)
        {
            Dictionary<int, List<jzat506_DetalleFactura>> detalles = new Dictionary<int, List<jzat506_DetalleFactura>>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT d.IdFactura, d.IdDetalle, d.IdProducto, p.Codigo, p.Nombre,
                                        d.Cantidad, d.PrecioUnitario, d.DVH
                                 FROM DetalleFactura d
                                 INNER JOIN Factura f ON f.IdFactura = d.IdFactura
                                 INNER JOIN Producto p ON p.IdProducto = d.IdProducto
                                 WHERE f.IdCliente = @IdCliente
                                 ORDER BY d.IdFactura, d.IdDetalle";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idFactura = Convert.ToInt32(reader["IdFactura"]);

                            if (!detalles.ContainsKey(idFactura))
                                detalles[idFactura] = new List<jzat506_DetalleFactura>();

                            detalles[idFactura].Add(new jzat506_DetalleFactura
                            {
                                jzat506_Id = Convert.ToInt32(reader["IdDetalle"]),
                                jzat506_Producto = new jzat506_Producto
                                {
                                    jzat506_Id = Convert.ToInt32(reader["IdProducto"]),
                                    jzat506_Codigo = reader["Codigo"].ToString() ?? "",
                                    jzat506_Nombre = reader["Nombre"].ToString() ?? ""
                                },
                                jzat506_Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                jzat506_PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                                jzat506_DVH = Convert.ToInt32(reader["DVH"])
                            });
                        }
                    }
                }
            }

            return detalles;
        }
    }
}
