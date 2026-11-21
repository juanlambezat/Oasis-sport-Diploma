using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_Usuario_C
    {
        public List<jzat506_Usuario_C> jzat506_ListarVersiones()
        {
            List<jzat506_Usuario_C> lista = new List<jzat506_Usuario_C>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT IdVersion, id_usuario, nomUsuario, contraseña, bloqueado, eliminado, Fecha, Hora, Usuario, Activo
                                 FROM usuarios_C
                                 ORDER BY Fecha DESC, Hora DESC, IdVersion DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jzat506_Usuario_C version = new jzat506_Usuario_C();
                        version.jzat506_IdVersion = Convert.ToInt32(reader["IdVersion"]);
                        version.jzat506_IdUsuario = Convert.ToInt32(reader["id_usuario"]);
                        version.jzat506_NombreUsuario = reader["nomUsuario"].ToString() ?? "";
                        version.jzat506_Contrasenia = reader["contraseña"].ToString() ?? "";
                        version.jzat506_Bloqueado = Convert.ToBoolean(reader["bloqueado"]);
                        version.jzat506_Eliminado = Convert.ToBoolean(reader["eliminado"]);
                        version.jzat506_Fecha = Convert.ToDateTime(reader["Fecha"]);
                        version.jzat506_Hora = (TimeSpan)reader["Hora"];
                        version.jzat506_Usuario = reader["Usuario"].ToString() ?? "";
                        version.jzat506_Activo = Convert.ToBoolean(reader["Activo"]);
                        lista.Add(version);
                    }
                }
            }

            return lista;
        }

        public void jzat506_ActivarVersion(int idVersion, int idUsuario)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"UPDATE usuarios_C
                                 SET Activo = CASE WHEN IdVersion = @IdVersion THEN 1 ELSE 0 END
                                 WHERE id_usuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdVersion", idVersion);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
