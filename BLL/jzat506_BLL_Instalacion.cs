using System;
using System.IO;
using DAL;

namespace BLL
{
    public class jzat506_BLL_Instalacion
    {
        private readonly jzat506_DAL_Instalacion jzat506_dalInstalacion = new jzat506_DAL_Instalacion();

        public bool jzat506_BaseDisponible()
        {
            return jzat506_dalInstalacion.jzat506_BaseDisponible();
        }

        public string jzat506_ServidorActual()
        {
            return Conexion.ObtenerServidor();
        }

        public bool jzat506_CrearBase(string servidor)
        {
            if (string.IsNullOrWhiteSpace(servidor))
                throw new Exception("Ingrese el nombre del servidor SQL Server.");

            servidor = servidor.Trim();

            if (jzat506_dalInstalacion.jzat506_ExisteBase(servidor))
            {
                Conexion.GuardarServidor(servidor);
                return true;
            }

            string ruta = Path.Combine(AppContext.BaseDirectory, "OasisSports.sql");

            if (!File.Exists(ruta))
                throw new Exception("No se encontró el script de la base de datos (OasisSports.sql).");

            jzat506_dalInstalacion.jzat506_CrearBase(servidor, File.ReadAllText(ruta));
            Conexion.GuardarServidor(servidor);
            return false;
        }

        public bool jzat506_BaseActualizada()
        {
            return jzat506_dalInstalacion.jzat506_BaseActualizada();
        }

        public void jzat506_ActualizarBase()
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "OasisSports_Actualizacion.sql");

            if (!File.Exists(ruta))
                throw new Exception("No se encontró el script de actualización (OasisSports_Actualizacion.sql).");

            jzat506_dalInstalacion.jzat506_ActualizarBase(File.ReadAllText(ruta));
        }
    }
}
