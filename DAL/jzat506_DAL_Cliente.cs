using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_Cliente
    {
        public jzat506_Cliente? jzat506_ObtenerPorDNI(int dni)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT IdCliente, DNI, Nombre, Apellido, Email, Telefono, Direccion, Activo, DVH " +
                               "FROM Cliente WHERE DNI = @DNI";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DNI", dni);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return jzat506_LeerCliente(reader);
                    }
                }
            }

            return null;
        }

        public int jzat506_InsertarCliente(jzat506_Cliente cliente)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"INSERT INTO Cliente (DNI, Nombre, Apellido, Email, Telefono, Direccion, DVH)
                                  OUTPUT INSERTED.IdCliente
                                  VALUES (@DNI, @Nombre, @Apellido, @Email, @Telefono, @Direccion, 0)";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DNI", cliente.jzat506_DNI);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.jzat506_Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.jzat506_Apellido);
                    cmd.Parameters.AddWithValue("@Email", (object)cliente.jzat506_Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", (object)cliente.jzat506_Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", (object)cliente.jzat506_Direccion ?? DBNull.Value);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void jzat506_ModificarCliente(jzat506_Cliente cliente)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email,
                                  Telefono = @Telefono, Direccion = @Direccion WHERE IdCliente = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cliente.jzat506_Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.jzat506_Apellido);
                    cmd.Parameters.AddWithValue("@Email", (object)cliente.jzat506_Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", (object)cliente.jzat506_Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Direccion", (object)cliente.jzat506_Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", cliente.jzat506_Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void jzat506_EliminarCliente(int idCliente)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE Cliente SET Activo = 0 WHERE IdCliente = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void jzat506_ActualizarDVH(int idCliente, int dvh)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE Cliente SET DVH = @DVH WHERE IdCliente = @Id";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVH", dvh);
                    cmd.Parameters.AddWithValue("@Id", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<jzat506_Cliente> jzat506_ObtenerTodos()
        {
            List<jzat506_Cliente> lista = new List<jzat506_Cliente>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT IdCliente, DNI, Nombre, Apellido, Email, Telefono, Direccion, Activo, DVH FROM Cliente";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add(jzat506_LeerCliente(reader));
                }
            }

            return lista;
        }

        public void jzat506_ActualizarDVV(int dvv)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "UPDATE DVVertical SET ValorDVV = @DVV WHERE Tabla = 'Cliente'";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@DVV", dvv);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private jzat506_Cliente jzat506_LeerCliente(SqlDataReader reader)
        {
            return new jzat506_Cliente
            {
                jzat506_Id = Convert.ToInt32(reader["IdCliente"]),
                jzat506_DNI = Convert.ToInt32(reader["DNI"]),
                jzat506_Nombre = reader["Nombre"].ToString() ?? "",
                jzat506_Apellido = reader["Apellido"].ToString() ?? "",
                jzat506_Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString() ?? "",
                jzat506_Telefono = reader["Telefono"] == DBNull.Value ? "" : reader["Telefono"].ToString() ?? "",
                jzat506_Direccion = reader["Direccion"] == DBNull.Value ? "" : reader["Direccion"].ToString() ?? "",
                jzat506_Activo = Convert.ToBoolean(reader["Activo"]),
                jzat506_DVH = Convert.ToInt32(reader["DVH"])
            };
        }
    }
}
