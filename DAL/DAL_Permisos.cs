using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Servicios;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DAL_Permisos
    {
        public ComponentePermiso ObtenerArbolPermiso(int permisoId)
        {
            ComponentePermiso permiso = ObtenerPermisoPorId(permisoId);

            if (permiso is GrupoPermisos grupo)
            {
                List<int> hijosIds = ObtenerHijosIds(permisoId);

                foreach (int hijoId in hijosIds)
                {
                    ComponentePermiso hijo = ObtenerArbolPermiso(hijoId);
                    grupo.Agregar(hijo);
                }
            }

            return permiso;
        }

        public ComponentePermiso? ObtenerPerfilDeUsuario(int usuarioId)
        {
            int perfilId;

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT PermisoId FROM UsuarioPermiso WHERE UsuarioId = @UsuarioId";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", usuarioId);

                    object? resultado = comando.ExecuteScalar();

                    if (resultado == null)
                        return null;

                    perfilId = Convert.ToInt32(resultado);
                }
            }

            return ObtenerArbolPermiso(perfilId);
        }

        private ComponentePermiso ObtenerPermisoPorId(int permisoId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT Id, Nombre, Codigo, EsGrupo FROM Permiso WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@Id", permisoId);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Permiso no encontrado.");

                        bool esGrupo = Convert.ToBoolean(reader["EsGrupo"]);

                        if (esGrupo)
                        {
                            return new GrupoPermisos
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Codigo = reader["Codigo"]?.ToString()
                            };
                        }

                        return new PermisoSimple
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Codigo = reader["Codigo"].ToString()
                        };
                    }
                }
            }
        }

        private List<int> ObtenerHijosIds(int padreId)
        {
            List<int> hijos = new List<int>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT HijoId FROM PermisoRelacion WHERE PadreId = @PadreId";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@PadreId", padreId);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hijos.Add(Convert.ToInt32(reader["HijoId"]));
                        }
                    }
                }
            }

            return hijos;
        }

        public void AsignarPerfil(int usuarioId, int perfilId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @"DELETE FROM UsuarioPermiso WHERE UsuarioId = @UsuarioId;
                INSERT INTO UsuarioPermiso (UsuarioId, PermisoId) VALUES (@UsuarioId, @PermisoId)";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    comando.Parameters.AddWithValue("@PermisoId", perfilId);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void QuitarPerfil(int usuarioId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "DELETE FROM UsuarioPermiso WHERE UsuarioId = @UsuarioId";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@UsuarioId", usuarioId);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<ComponentePermiso> ObtenerTodos()
        {
            List<ComponentePermiso> permisos = new List<ComponentePermiso>();

            using (SqlConnection conexion = new Conexion().ObtenerConexion())
            {
                conexion.Open();

                string query = "SELECT Id, Nombre, Codigo, EsGrupo FROM Permiso ORDER BY EsGrupo DESC, Codigo";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bool esGrupo = Convert.ToBoolean(reader["EsGrupo"]);

                        ComponentePermiso permiso;

                        if (esGrupo)
                        {
                            permiso = new GrupoPermisos
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Codigo = reader["Codigo"].ToString()
                            };
                        }
                        else
                        {
                            permiso = new PermisoSimple
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Codigo = reader["Codigo"].ToString()
                            };
                        }

                        permisos.Add(permiso);
                    }
                }
            }

            return permisos;
        }

        public int CrearGrupoPermiso(string nombre, string codigo)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @" INSERT INTO Permiso (Nombre, Codigo, EsGrupo) OUTPUT INSERTED.Id VALUES (@Nombre, @Codigo, 1)";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Codigo", codigo);

                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public bool ExisteCodigo(string codigo)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT COUNT(*) FROM Permiso WHERE Codigo = @Codigo";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@Codigo", codigo);

                    return (int)comando.ExecuteScalar() > 0;
                }
            }
        }

        public void AgregarPermisoAGrupo(int grupoId, int permisoHijoId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = @" IF NOT EXISTS (SELECT 1 FROM PermisoRelacion
                WHERE PadreId = @PadreId AND HijoId = @HijoId
            )
            BEGIN
                INSERT INTO PermisoRelacion (PadreId, HijoId)
                VALUES (@PadreId, @HijoId)
            END";

                using (SqlCommand comando = new SqlCommand(query, cn))
                {
                    comando.Parameters.AddWithValue("@PadreId", grupoId);
                    comando.Parameters.AddWithValue("@HijoId", permisoHijoId);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<ComponentePermiso> ObtenerPermisosGrupo(int idPermiso)
        {
            List<ComponentePermiso> permisos = new List<ComponentePermiso>();

            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = @"SELECT p.Id, p.Nombre, p.Codigo, p.EsGrupo
                     FROM Permiso p
                     INNER JOIN PermisoRelacion pr ON p.Id = pr.HijoId
                     WHERE pr.PadreId = @idPermiso";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@idPermiso", idPermiso);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bool esGrupo = Convert.ToBoolean(reader["EsGrupo"]);

                        ComponentePermiso permiso;
                        if (esGrupo)
                            permiso = new GrupoPermisos { Id = Convert.ToInt32(reader["Id"]), Nombre = reader["Nombre"].ToString(), Codigo = reader["Codigo"].ToString() };
                        else
                            permiso = new PermisoSimple { Id = Convert.ToInt32(reader["Id"]), Nombre = reader["Nombre"].ToString(), Codigo = reader["Codigo"].ToString() };

                        permisos.Add(permiso);
                    }
                }
            }
            cn.Close();
            return permisos;
        }

        public void ActualizarNombreGrupo(int grupoId, string nombre)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "UPDATE Permiso SET Nombre = @Nombre WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Id", grupoId);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public void EliminarPermisosDeGrupo(int grupoId)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "DELETE FROM PermisoRelacion WHERE PadreId = @PadreId";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@PadreId", grupoId);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public void EliminarGrupo(int grupoId)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "DELETE FROM Permiso WHERE Id = @Id AND EsGrupo = 1";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Id", grupoId);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        public bool GrupoPoseeUsuarios(int grupoId)
        {
            Conexion conexion = new Conexion();
            SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string query = "SELECT COUNT(*) FROM UsuarioPermiso WHERE PermisoId = @PermisoId";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@PermisoId", grupoId);
                int cantidad = (int)cmd.ExecuteScalar();
                return cantidad > 0;
            }
        }

        public bool GrupoEstaEnOtroGrupo(int grupoId)
        {
            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT COUNT(*) FROM PermisoRelacion WHERE HijoId = @HijoId";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@HijoId", grupoId);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
