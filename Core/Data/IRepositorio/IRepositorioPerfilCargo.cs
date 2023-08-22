using CPM.PlataformaDirigentes.Models.ModeloDom.Perfil;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioPerfilCargo
    {
        public List<PerfilCargo> ObtenerPerfilCargos();
        public List<PerfilCargo> ObtenerPerfilCargosActivos();
        public bool CrearPerfilCargo(PerfilCargo PerfilCargo);
        //   public bool ModificarPerfilCargo(PerfilCargo PerfilCargo);

        //  public bool DesactivarPerfilCargo(int idPerfilCargo);
        public PerfilCargo PerfilCargobyNombre(string nombre);


        public List<PerfilPermiso> ObtenerPerfilPermiso();
        public List<PerfilPermisoIndex> ObtenerPerfilPermisoIndex();
        public List<PerfilPermisoResumen> ObtenerPerfilPermisobyCorreoAcceso(string correoAcceso);
        public List<PerfilPermiso> ObtenerPerfilPermisobyIdUsuario(int idUsuario);
        public List<PerfilPermiso> ObtenerPerfilPermisobyIdPerfil(int idPerfil);
        public List<PerfilPermiso> ObtenerPerfilPermisoSinPerfil();
        public List<PerfilPermiso> PerfilPermisobyId(int idPerfilCargo);
        // public PerfilPermiso PerfilPermisobyNombre(string nombre);
        public bool ModificarPerfilPermiso(List<PerfilPermiso> perfilPermiso);
        // public bool CrearPerfilPermiso(PerfilPermiso PerfilPermiso);
        public int CrearPerfilPermisoNew(List<PerfilPermiso> PerfilPermiso);
    }
}
