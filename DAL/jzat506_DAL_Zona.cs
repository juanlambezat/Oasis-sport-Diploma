using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_Zona
    {
        public List<jzat506_ZonaCobertura> jzat506_ListarZonas()
        {
            List<jzat506_ZonaCobertura> lista = new List<jzat506_ZonaCobertura>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT IdZona, Localidad, CodigoPostal, CostoEnvio FROM ZonaCobertura ORDER BY Localidad";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new jzat506_ZonaCobertura
                        {
                            jzat506_Id = Convert.ToInt32(reader["IdZona"]),
                            jzat506_Localidad = reader["Localidad"].ToString() ?? "",
                            jzat506_CodigoPostal = reader["CodigoPostal"].ToString() ?? "",
                            jzat506_CostoEnvio = Convert.ToDecimal(reader["CostoEnvio"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
