using Microsoft.Data.SqlClient;
using System;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DAL
{
    public class Conexion
    {
        public static string cadena1 =
         "Data Source=localhost\\SQLEXPRESS;" +
         "Initial Catalog=OasisSports;" +
         "Integrated Security=True;" +
         "Encrypt=True;" +
         "TrustServerCertificate=True;";

        public static string cadena2 = "Data Source=.;Initial Catalog=OasisSports;" +
            "Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;" +
            "Trust Server Certificate=True;Command Timeout=0";

        public static string cadena3 =
        "Data Source=.;" +
        "Initial Catalog=OasisSports;" +
        "Integrated Security=True;" +
        "Encrypt=True;" +
        "TrustServerCertificate=True;";

        public static string ArchivoServidor = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Oasis Sports", "servidor.txt");

        private SqlConnection conexion;


        public Conexion()
        {
            conexion = new SqlConnection(ObtenerCadena("OasisSports", ObtenerServidor()));
        }

        public static string ObtenerServidor()
        {
            if (File.Exists(ArchivoServidor))
            {
                string servidor = File.ReadAllText(ArchivoServidor).Trim();
                if (servidor != "")
                    return servidor;
            }

            return ".";
        }

        public static void GuardarServidor(string servidor)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ArchivoServidor)!);
            File.WriteAllText(ArchivoServidor, servidor);
        }

        public static string ObtenerCadena(string baseDatos, string servidor)
        {
            return "Data Source=" + servidor + ";Initial Catalog=" + baseDatos + ";" +
                "Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;" +
                "Trust Server Certificate=True;Command Timeout=0;Connect Timeout=30";
        }


        public void AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
                Console.WriteLine("Conexión abierta");
            }
        }


        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
                Console.WriteLine("Conexión cerrada");
            }
        }


        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }

    }
}
