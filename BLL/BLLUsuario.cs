using Entidades;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Servicios;
using System.Windows.Forms;

namespace BLL
{
    public class BLLUsuario
    {
        public DAL_Usuario DAL_Usuario = new DAL_Usuario();

        public List<Usuario> Listar()
        {
            return DAL_Usuario.Listar();
        }

        public void AñadirUsuario(Usuario usuario)
        {
            DAL_Usuario.AñadirUsuario(usuario);
        }

        public void ModificarUsuario(int idUsuario, Usuario usuarioNuevo)
        {
            
            Usuario usuarioAntes = DAL_Usuario.ObtenerPorUsuario(
                DAL_Usuario.Listar().FirstOrDefault(u => u.Id == idUsuario)?.Username ?? ""
            );          
            DAL_Usuario.ModificarUsuario(idUsuario, usuarioNuevo);         
            if (usuarioAntes != null)
            {
                usuarioNuevo.Id = idUsuario;
                BLL_HistorialCambios bllHistorial = new BLL_HistorialCambios();
                string quienModifica = Servicios.SessionManager.GetInstance().Usuario?.Username ?? "sistema";
                bllHistorial.RegistrarCambiosUsuario(usuarioAntes, usuarioNuevo, quienModifica);
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            DAL_Usuario.EliminarUsuario(idUsuario);
        }

        public void jzat506_CambiarContrasenia(int idUsuario, string username, string contraseniaActual, string contraseniaNueva)
        {
            jzat506_ValidarContraseniaNueva(contraseniaActual, contraseniaNueva);

            Usuario usuario = DAL_Usuario.ObtenerPorUsuario(username);

            if (usuario == null)
                throw new System.Exception("No se encontró el usuario.");

            Encriptacion encriptadorLocal = new Encriptacion();

            if (usuario.Password != encriptadorLocal.Encriptar(contraseniaActual))
                throw new System.Exception("La contraseña actual es incorrecta.");

            DAL_Usuario.jzat506_CambiarContrasenia(idUsuario, contraseniaNueva);
        }

        private void jzat506_ValidarContraseniaNueva(string contraseniaActual, string contraseniaNueva)
        {
            if (string.IsNullOrWhiteSpace(contraseniaNueva))
                throw new System.Exception("Debe ingresar una contraseña nueva.");

            if (contraseniaNueva.Length < 6)
                throw new System.Exception("La contraseña nueva debe tener al menos 6 caracteres.");

            if (contraseniaNueva.Any(char.IsWhiteSpace))
                throw new System.Exception("La contraseña nueva no puede contener espacios.");

            if (!contraseniaNueva.Any(char.IsLetter) || !contraseniaNueva.Any(char.IsDigit))
                throw new System.Exception("La contraseña nueva debe incluir al menos una letra y un número.");

            if (contraseniaNueva == contraseniaActual)
                throw new System.Exception("La contraseña nueva no puede ser igual a la actual.");
        }

        private Encriptacion encriptador = new Encriptacion();

        private int intentosFallidos = 0;

        public Usuario ValidarUsuario(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Debe ingresar un usuario.");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Debe ingresar una contraseña.");


            

            Usuario usuario = DAL_Usuario.ObtenerPorUsuario(username);

            if (usuario == null || usuario.Eliminado)
                throw new Exception("Usuario o contraseña incorrectos.");

            if (usuario.Bloqueado)
                throw new Exception("El usuario se encuentra bloqueado.");

            string hash = encriptador.Encriptar(password);

            if (usuario.Password != hash)
            {
                intentosFallidos++;

                if (intentosFallidos >= 3)
                {
                    DAL_Usuario.BloquearUsuario(usuario.Id);
                    throw new Exception("Usuario bloqueado por exceso de intentos.");
                }

                throw new Exception(
                    $"Usuario o contraseña incorrectos. Intento {intentosFallidos}/3");
            }

            intentosFallidos = 0;

            return usuario;
        }

       
    }
}
