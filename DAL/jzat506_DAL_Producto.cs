using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_Producto
    {
        public List<jzat506_Producto> jzat506_ListarProductos()
        {
            List<jzat506_Producto> lista = new List<jzat506_Producto>();

            using (SqlConnection cn = new Conexion().ObtenerConexion())
            {
                cn.Open();

                string query = "SELECT IdProducto, Codigo, Nombre, Categoria, Precio, DVH FROM Producto";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new jzat506_Producto
                        {
                            jzat506_Id = Convert.ToInt32(reader["IdProducto"]),
                            jzat506_Codigo = reader["Codigo"].ToString() ?? "",
                            jzat506_Nombre = reader["Nombre"].ToString() ?? "",
                            jzat506_Categoria = reader["Categoria"].ToString() ?? "",
                            jzat506_Precio = Convert.ToDecimal(reader["Precio"]),
                            jzat506_DVH = Convert.ToInt32(reader["DVH"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
