using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_Transportista
    {
        public List<jzat506_Transportista> jzat506_ListarTransportistas()
        {
            List<jzat506_Transportista> lista = new List<jzat506_Transportista>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT t.IdTransportista, t.Nombre, t.Apellido,
                                        (SELECT TOP 1 p.IdPedido
                                         FROM Envio e
                                         INNER JOIN Pedido p ON p.IdPedido = e.IdPedido
                                         WHERE e.IdTransportista = t.IdTransportista
                                         AND p.Estado <> 'Entregado') AS PedidoActual
                                 FROM Transportista t
                                 ORDER BY t.IdTransportista";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jzat506_Transportista transportista = new jzat506_Transportista();
                        transportista.jzat506_Id = Convert.ToInt32(reader["IdTransportista"]);
                        transportista.jzat506_Nombre = reader["Nombre"].ToString() ?? "";
                        transportista.jzat506_Apellido = reader["Apellido"].ToString() ?? "";

                        if (reader["PedidoActual"] != DBNull.Value)
                            transportista.jzat506_PedidoActual = Convert.ToInt32(reader["PedidoActual"]);

                        lista.Add(transportista);
                    }
                }
            }

            return lista;
        }

        public void jzat506_AsignarTransportista(int idEnvio, int idTransportista)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE Envio SET IdTransportista = @IdTransportista WHERE IdEnvio = @IdEnvio";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdTransportista", idTransportista);
                    cmd.Parameters.AddWithValue("@IdEnvio", idEnvio);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
