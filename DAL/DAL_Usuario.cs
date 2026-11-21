using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Servicios;
using System.Collections;

namespace DAL
{
    public class DAL_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "select Id_Usuario, NomUsuario, Contraseña, Bloqueado, Eliminado from Usuarios";

            SqlCommand cmd = new SqlCommand(query, cn);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id = Convert.ToInt32(reader["Id_Usuario"]),
                            Username = reader["NomUsuario"].ToString(),
                            Password = reader["Contraseña"].ToString(),
                            Bloqueado = Convert.ToBoolean(reader["Bloqueado"]),
                            Eliminado = Convert.ToBoolean(reader["Eliminado"]),


                        });

                    }
                }
            }
            catch (Exception ex) 
            {
                System.Console.WriteLine("Error en la búsqueda: " + ex.Message);
                
            }



            return lista;
        }

        Encriptacion encriptador = new Encriptacion();

        private const string jzat506_SesionTrigger = "EXEC sp_set_session_context @key = N'usuario', @value = @UsuarioSesion; ";

        private string jzat506_UsuarioSesion()
        {
            if (SessionManager.GetInstance().IsLogged())
                return SessionManager.GetInstance().Usuario.Username;

            return "sistema";
        }


        public void AñadirUsuario(Usuario usuario)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = jzat506_SesionTrigger + "INSERT INTO usuarios (nomUsuario, contraseña) VALUES (@NomUsuario, @Contraseña)";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@UsuarioSesion", jzat506_UsuarioSesion());
                cmd.Parameters.AddWithValue("@NomUsuario", usuario.Username);
                cmd.Parameters.AddWithValue("@Contraseña", encriptador.Encriptar(usuario.Password)); 

                
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = jzat506_SesionTrigger + "UPDATE Usuarios SET Eliminado = 1 WHERE Id_Usuario = @Id_Usuario";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@UsuarioSesion", jzat506_UsuarioSesion());
                cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarUsuario(int idUsuario, Usuario usuario)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = jzat506_SesionTrigger + @"UPDATE Usuarios
                     SET NomUsuario = @NomUsuario,
                         Contraseña = @Contraseña
                     WHERE Id_Usuario = @IdUsuario";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@UsuarioSesion", jzat506_UsuarioSesion());
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@NomUsuario", usuario.Username);
                cmd.Parameters.AddWithValue("@Contraseña", encriptador.Encriptar(usuario.Password));

                cmd.ExecuteNonQuery();
            }
        }

        public void jzat506_CambiarContrasenia(int idUsuario, string contraseniaNueva)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = jzat506_SesionTrigger + "UPDATE Usuarios SET Contraseña = @Contraseña WHERE Id_Usuario = @Id";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@UsuarioSesion", jzat506_UsuarioSesion());
                cmd.Parameters.AddWithValue("@Contraseña", encriptador.Encriptar(contraseniaNueva));
                cmd.Parameters.AddWithValue("@Id", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public Usuario ObtenerPorUsuario(string username)
        {
            Usuario usuario = null;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"SELECT Id_Usuario, NomUsuario, Contraseña, Bloqueado, Eliminado FROM Usuarios WHERE NomUsuario = @Username ORDER BY Eliminado";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id_Usuario"]),
                                Username = reader["NomUsuario"].ToString(),
                                Password = reader["Contraseña"].ToString(),
                                Bloqueado = Convert.ToBoolean(reader["Bloqueado"]),
                                Eliminado = Convert.ToBoolean(reader["Eliminado"])
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public void BloquearUsuario(int idUsuario)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = jzat506_SesionTrigger + @"UPDATE Usuarios
                         SET Bloqueado = 1
                         WHERE Id_Usuario = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioSesion", jzat506_UsuarioSesion());
                    cmd.Parameters.AddWithValue("@Id", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
