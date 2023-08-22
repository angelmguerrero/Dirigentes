using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.Perfil;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorPerfilCargo : IAdministradorPerfilCargo
    {
        private IRepositorioPerfilCargo repoPerfilCargo;
        public AdministradorPerfilCargo()
        {
            this.repoPerfilCargo = new RepositorioPerfilCargo();
        }
        public List<PerfilCargo> ObtenerPerfilCargos()
        {
            return repoPerfilCargo.ObtenerPerfilCargos();
        }

        public List<PerfilCargo> ObtenerPerfilCargosActivos()
        {
            return repoPerfilCargo.ObtenerPerfilCargosActivos();
        }

        public List<PerfilPermiso> ObtenerPerfilPermiso()
        {
            return repoPerfilCargo.ObtenerPerfilPermiso();
        }

        public List<PerfilPermisoIndex> ObtenerPerfilPermisoIndex()
        {
            return repoPerfilCargo.ObtenerPerfilPermisoIndex();
        }

        public List<PerfilPermisoResumen> ObtenerPerfilPermisobyCorreoAcceso(string correoAcceso)
        {
            return repoPerfilCargo.ObtenerPerfilPermisobyCorreoAcceso(correoAcceso);
        }

        public List<PerfilPermiso> ObtenerPerfilPermisobyIdUsuario(int idUsuario)
        {
            return repoPerfilCargo.ObtenerPerfilPermisobyIdUsuario(idUsuario);
        }

        public List<PerfilPermiso> ObtenerPerfilPermisobyIdPerfil(int idPerfil)
        {
            return repoPerfilCargo.ObtenerPerfilPermisobyIdPerfil(idPerfil);
        }

        public List<PerfilPermiso> ObtenerPerfilPermisoSinPerfil()
        {
            return repoPerfilCargo.ObtenerPerfilPermisoSinPerfil();
        }

        public bool CrearPerfilCargo(PerfilCargo PerfilCargo)
        {
            return repoPerfilCargo.CrearPerfilCargo(PerfilCargo);
        }

        //public bool CrearPerfilPermiso(PerfilPermiso PerfilPermiso)
        //{
        //    return repoPerfilCargo.CrearPerfilPermiso(PerfilPermiso);
        //}

        public int CrearPerfilPermisoNew(List<PerfilPermiso> PerfilPermiso)
        {
            return repoPerfilCargo.CrearPerfilPermisoNew(PerfilPermiso);
        }

        public bool ModificarPerfilPermiso(List<PerfilPermiso> perfilPermiso)
        {
            return repoPerfilCargo.ModificarPerfilPermiso(perfilPermiso);
        }
        //public bool DesactivarPerfilCargo(int idPerfilCargo)
        //{
        //    return repoPerfilCargo.DesactivarPerfilCargo(idPerfilCargo);
        //}

        //public PerfilCargo PerfilCargobyId(int idPerfilCargo)
        //{
        //    return repoPerfilCargo.PerfilCargobyId(idPerfilCargo);
        //}

        public PerfilCargo PerfilCargobyNombre(string nombre)
        {
            return repoPerfilCargo.PerfilCargobyNombre(nombre);
        }

        public List<PerfilPermiso> PerfilPermisobyId(int idPerfilCargo)
        {
            return repoPerfilCargo.PerfilPermisobyId(idPerfilCargo);
        }

        //public PerfilPermiso PerfilPermisobyNombre(string nombre)
        //{
        //    return repoPerfilCargo.PerfilPermisobyNombre(nombre);
        //}
    }
}
