using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Servicios;

namespace BLL
{
    public class BLL_Permisos
    {
        private  DAL_Permisos permisoDAL = new DAL_Permisos();

        public const string CodigoAdministrador = "AA099";


        public bool UsuarioTienePermiso(int usuarioId, string codigoPermiso)
        {
            ComponentePermiso? perfil = permisoDAL.ObtenerPerfilDeUsuario(usuarioId);

            if (perfil == null)
                return false;

            return perfil.TienePermiso(codigoPermiso);
        }

        public ComponentePermiso? ObtenerPerfilUsuario(int usuarioId)
        {
            return permisoDAL.ObtenerPerfilDeUsuario(usuarioId);
        }

        public bool TienePermiso(string codigoPermiso, int usuarioId)
        {
            if (SessionManager.GetInstance().Usuario == null)
                return false;

            return UsuarioTienePermiso(usuarioId, codigoPermiso);
        }

        public void AsignarPerfil(int usuarioId, ComponentePermiso perfil)
        {
            if (!(perfil is GrupoPermisos))
                throw new Exception("El perfil de un usuario debe ser un permiso compuesto.");

            permisoDAL.AsignarPerfil(usuarioId, perfil.Id);
        }

        public void QuitarPerfil(int usuarioId)
        {
            permisoDAL.QuitarPerfil(usuarioId);
        }

        public List<ComponentePermiso> ObtenerTodos()
        {
            return permisoDAL.ObtenerTodos();
        }

        public List<ComponentePermiso> ObtenerPerfiles()
        {
            List<ComponentePermiso> perfiles = new List<ComponentePermiso>();

            foreach (ComponentePermiso permiso in permisoDAL.ObtenerTodos())
            {
                if (permiso is GrupoPermisos)
                    perfiles.Add(permiso);
            }

            return perfiles;
        }

        public ComponentePermiso ObtenerArbolPermiso(int permisoId)
        {
            return permisoDAL.ObtenerArbolPermiso(permisoId);
        }

        public int CrearGrupoPermiso(string nombre, string codigo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Debe ingresar un nombre para el grupo.");

            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("Debe ingresar un codigo para el grupo.");

            if (permisoDAL.ExisteCodigo(codigo))
                throw new Exception($"Ya existe un permiso con el codigo '{codigo}'.");

            return permisoDAL.CrearGrupoPermiso(nombre, codigo);
        }

        public bool ExisteCodigo(string codigo)
        {
            return permisoDAL.ExisteCodigo(codigo);
        }

        public void AgregarPermisoAGrupo(int grupoId, int permisoHijoId)
        {
            ValidarPermisoEnGrupo(grupoId, permisoHijoId);

            permisoDAL.AgregarPermisoAGrupo(grupoId, permisoHijoId);
        }

        public void ValidarPermisoEnGrupo(int grupoId, int permisoHijoId)
        {
            if (grupoId == permisoHijoId)
                throw new Exception("Un grupo no puede contenerse a sí mismo.");

            ComponentePermiso hijo = permisoDAL.ObtenerArbolPermiso(permisoHijoId);

            if (ContienePermiso(hijo, grupoId))
                throw new Exception($"No se puede agregar '{hijo.Nombre}' porque ese grupo ya contiene al grupo que se está modificando.");
        }

        private bool ContienePermiso(ComponentePermiso permiso, int permisoId)
        {
            if (permiso.Id == permisoId)
                return true;

            foreach (ComponentePermiso hijo in permiso.ObtenerHijos())
            {
                if (ContienePermiso(hijo, permisoId))
                    return true;
            }

            return false;
        }

        public List<ComponentePermiso> ObtenerPermisosGrupo(int grupoId)
        {
            return permisoDAL.ObtenerPermisosGrupo(grupoId);
        }

        public void ModificarGrupoPermiso(int grupoId, string nombre, List<ComponentePermiso> permisosNuevos)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Debe ingresar un nombre para el grupo.");

            if (permisosNuevos.Count == 0)
                throw new Exception("Debe agregar al menos un permiso al grupo.");

            foreach (ComponentePermiso permiso in permisosNuevos)
                ValidarPermisoEnGrupo(grupoId, permiso.Id);

            permisoDAL.ActualizarNombreGrupo(grupoId, nombre);
            permisoDAL.EliminarPermisosDeGrupo(grupoId);

            foreach (ComponentePermiso permiso in permisosNuevos)
                permisoDAL.AgregarPermisoAGrupo(grupoId, permiso.Id);
        }

        public void EliminarGrupoPermiso(int grupoId)
        {
            permisoDAL.EliminarPermisosDeGrupo(grupoId);
            permisoDAL.EliminarGrupo(grupoId);
        }

        public bool GrupoPoseeUsuarios(int grupoId)
        {
            return permisoDAL.GrupoPoseeUsuarios(grupoId);
        }

        public bool GrupoEstaEnOtroGrupo(int grupoId)
        {
            return permisoDAL.GrupoEstaEnOtroGrupo(grupoId);
        }

        public bool EsAdministrador(int usuarioId)
        {
            ComponentePermiso? perfil = permisoDAL.ObtenerPerfilDeUsuario(usuarioId);

            if (perfil == null)
                return false;

            return perfil.Codigo == CodigoAdministrador;
        }

        public bool ExisteGrupoConNombre(string nombre, int grupoIdExcluido, List<ComponentePermiso> permisosExistentes)
        {
            return permisosExistentes
                .OfType<GrupoPermisos>()
                .Any(g => g.Id != grupoIdExcluido && g.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }


    }
}
