using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_AnalisisVentas
    {
        public decimal jzat506_ObtenerTotalVendido(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT ISNULL(SUM(Total), 0) FROM Factura
                                 WHERE Fecha >= @Desde AND Fecha < @Hasta";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    jzat506_AgregarFechas(cmd, desde, hasta);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        public int jzat506_ContarVentas(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT COUNT(*) FROM Factura
                                 WHERE Fecha >= @Desde AND Fecha < @Hasta";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    jzat506_AgregarFechas(cmd, desde, hasta);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int jzat506_ContarEnvios(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT COUNT(*) FROM Pedido p
                                 INNER JOIN Envio e ON e.IdPedido = p.IdPedido
                                 WHERE p.Fecha >= @Desde AND p.Fecha < @Hasta";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    jzat506_AgregarFechas(cmd, desde, hasta);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<jzat506_ItemAnalisis> jzat506_ObtenerVentasPorCategoria(DateTime desde, DateTime hasta)
        {
            List<jzat506_ItemAnalisis> lista = new List<jzat506_ItemAnalisis>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT pr.Categoria, SUM(d.Cantidad * d.PrecioUnitario) AS Total
                                 FROM DetalleFactura d
                                 INNER JOIN Factura f ON f.IdFactura = d.IdFactura
                                 INNER JOIN Producto pr ON pr.IdProducto = d.IdProducto
                                 WHERE f.Fecha >= @Desde AND f.Fecha < @Hasta
                                 GROUP BY pr.Categoria
                                 ORDER BY Total DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    jzat506_AgregarFechas(cmd, desde, hasta);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jzat506_ItemAnalisis item = new jzat506_ItemAnalisis();
                            item.jzat506_Nombre = reader["Categoria"].ToString() ?? "";
                            item.jzat506_Valor = Convert.ToDecimal(reader["Total"]);
                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }

        public List<string> jzat506_ObtenerProductosSinVentas(DateTime desde, DateTime hasta)
        {
            List<string> lista = new List<string>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT pr.Nombre FROM Producto pr
                                 WHERE NOT EXISTS (SELECT 1 FROM DetalleFactura d
                                                   INNER JOIN Factura f ON f.IdFactura = d.IdFactura
                                                   WHERE d.IdProducto = pr.IdProducto
                                                   AND f.Fecha >= @Desde AND f.Fecha < @Hasta)
                                 ORDER BY pr.Nombre";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    jzat506_AgregarFechas(cmd, desde, hasta);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(reader["Nombre"].ToString() ?? "");
                    }
                }
            }

            return lista;
        }

        public List<jzat506_ItemAnalisis> jzat506_ObtenerProductosJuntos(DateTime desde, DateTime hasta)
        {
            List<jzat506_ItemAnalisis> lista = new List<jzat506_ItemAnalisis>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT TOP 2 p1.Nombre AS Producto1, p2.Nombre AS Producto2, COUNT(DISTINCT d1.IdFactura) AS Veces
                                 FROM DetalleFactura d1
                                 INNER JOIN DetalleFactura d2 ON d2.IdFactura = d1.IdFactura AND d2.IdProducto > d1.IdProducto
                                 INNER JOIN Factura f ON f.IdFactura = d1.IdFactura
                                 INNER JOIN Producto p1 ON p1.IdProducto = d1.IdProducto
                                 INNER JOIN Producto p2 ON p2.IdProducto = d2.IdProducto
                                 WHERE f.Fecha >= @Desde AND f.Fecha < @Hasta
                                 GROUP BY p1.Nombre, p2.Nombre
                                 HAVING COUNT(DISTINCT d1.IdFactura) >= 2
                                 ORDER BY Veces DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    jzat506_AgregarFechas(cmd, desde, hasta);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jzat506_ItemAnalisis item = new jzat506_ItemAnalisis();
                            item.jzat506_Nombre = reader["Producto1"].ToString() ?? "";
                            item.jzat506_Nombre2 = reader["Producto2"].ToString() ?? "";
                            item.jzat506_Cantidad = Convert.ToInt32(reader["Veces"]);
                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }

        public List<jzat506_ItemAnalisis> jzat506_ObtenerEnviosPorZona(DateTime desde, DateTime hasta)
        {
            List<jzat506_ItemAnalisis> lista = new List<jzat506_ItemAnalisis>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT z.Localidad, COUNT(*) AS Cantidad
                                 FROM Pedido p
                                 INNER JOIN Envio e ON e.IdPedido = p.IdPedido
                                 INNER JOIN ZonaCobertura z ON z.IdZona = e.IdZona
                                 WHERE p.Fecha >= @Desde AND p.Fecha < @Hasta
                                 GROUP BY z.Localidad
                                 ORDER BY Cantidad DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    jzat506_AgregarFechas(cmd, desde, hasta);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jzat506_ItemAnalisis item = new jzat506_ItemAnalisis();
                            item.jzat506_Nombre = reader["Localidad"].ToString() ?? "";
                            item.jzat506_Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }

        public List<jzat506_ItemAnalisis> jzat506_ObtenerTiempoEntregaPorZona(DateTime desde, DateTime hasta)
        {
            List<jzat506_ItemAnalisis> lista = new List<jzat506_ItemAnalisis>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT z.Localidad,
                                        AVG(CAST(DATEDIFF(SECOND, p.Fecha, h.Fecha) AS DECIMAL(18,2))) / 3600 AS Horas,
                                        COUNT(*) AS Cantidad
                                 FROM Pedido p
                                 INNER JOIN Envio e ON e.IdPedido = p.IdPedido
                                 INNER JOIN ZonaCobertura z ON z.IdZona = e.IdZona
                                 INNER JOIN HistorialCambios h ON h.EntidadId = p.IdPedido
                                        AND h.NombreEntidad = 'Pedido' AND h.NombreCampo = 'Estado' AND h.ValorNuevo = 'Entregado'
                                 WHERE p.Fecha >= @Desde AND p.Fecha < @Hasta
                                 GROUP BY z.Localidad
                                 ORDER BY Horas DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    jzat506_AgregarFechas(cmd, desde, hasta);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jzat506_ItemAnalisis item = new jzat506_ItemAnalisis();
                            item.jzat506_Nombre = reader["Localidad"].ToString() ?? "";
                            item.jzat506_Valor = Convert.ToDecimal(reader["Horas"]);
                            item.jzat506_Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }

        private void jzat506_AgregarFechas(SqlCommand cmd, DateTime desde, DateTime hasta)
        {
            cmd.Parameters.AddWithValue("@Desde", desde.Date);
            cmd.Parameters.AddWithValue("@Hasta", hasta.Date.AddDays(1));
        }
    }
}
