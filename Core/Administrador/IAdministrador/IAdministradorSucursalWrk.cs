using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorSucursalWrk
    {
        public List<SucursalWrk> ObtenerSucursalWrks();
        public bool CrearSucursalWrk(SucursalWrk SucursalWrk);
        public bool ModificarSucursalWrk(SucursalWrk SucursalWrk);
        public bool DesactivarSucursalWrk(int idSucursalWrk);
        public SucursalWrk SucursalWrkbyId(int idSucursalWrk);
        public List<SucursalWrk> ObtenerSucursalWrksbyIdPlaza(int IdPlaza);

    }
}
