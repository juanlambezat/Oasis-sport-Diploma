using System;
using System.Collections.Generic;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_Usuario_C
    {
        private readonly jzat506_DAL_Usuario_C jzat506_dalUsuarioC = new jzat506_DAL_Usuario_C();
        private readonly BLL_DV jzat506_bllDV = new BLL_DV();
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        public List<jzat506_Usuario_C> jzat506_ListarVersiones()
        {
            return jzat506_dalUsuarioC.jzat506_ListarVersiones();
        }

        public void jzat506_ActivarVersion(jzat506_Usuario_C version, int idUsuarioLogueado)
        {
            if (version.jzat506_Activo)
                throw new Exception("La versión elegida ya es la versión vigente del usuario.");

            if (version.jzat506_IdUsuario == idUsuarioLogueado)
                throw new Exception("No se pueden aplicar versiones del usuario con el que inició sesión.");

            jzat506_dalUsuarioC.jzat506_ActivarVersion(version.jzat506_IdVersion, version.jzat506_IdUsuario);

            jzat506_bllDV.InicializarDVs();

            string usuarioSesion = "sistema";
            if (SessionManager.GetInstance().IsLogged())
                usuarioSesion = SessionManager.GetInstance().Usuario.Username;

            jzat506_bllEvento.RegistrarEvento(new Evento()
            {
                Usuario = usuarioSesion,
                Modulo = "Usuarios",
                Descripcion = "Se activó la versión " + version.jzat506_IdVersion + " del usuario " + version.jzat506_NombreUsuario,
                Fecha = DateTime.Now,
                Criticidad = 2
            });
        }
    }
}
