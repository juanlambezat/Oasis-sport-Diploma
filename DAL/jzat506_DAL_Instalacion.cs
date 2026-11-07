using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class jzat506_DAL_Instalacion
    {
        public bool jzat506_BaseDisponible()
        {
            try
            {
                using (SqlConnection cn = new Conexion().ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT OBJECT_ID('dbo.usuarios')", cn))
                    {
                        return cmd.ExecuteScalar() != DBNull.Value;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public void jzat506_CrearBase(string servidor, string script)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.ObtenerCadena("master", servidor)))
            {
                cn.Open();

                foreach (string lote in jzat506_SepararLotes(script))
                {
                    using (SqlCommand cmd = new SqlCommand(lote, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private List<string> jzat506_SepararLotes(string script)
        {
            List<string> lotes = new List<string>();
            StringBuilder actual = new StringBuilder();

            foreach (string linea in script.Replace("\r\n", "\n").Split('\n'))
            {
                if (linea.Trim().ToUpper() == "GO")
                {
                    if (actual.ToString().Trim() != "")
                        lotes.Add(actual.ToString());

                    actual.Clear();
                }
                else
                {
                    actual.AppendLine(linea);
                }
            }

            if (actual.ToString().Trim() != "")
                lotes.Add(actual.ToString());

            return lotes;
        }
    }
}
