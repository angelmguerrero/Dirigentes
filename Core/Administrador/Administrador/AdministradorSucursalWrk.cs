using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorSucursalWrk : IAdministradorSucursalWrk
    {
        private IRepositorioSucursalWrk repoSucursalWrk;
        public AdministradorSucursalWrk()
        {
            this.repoSucursalWrk = new RepositorioSucursalWrk();
        }

        public List<SucursalWrk> ObtenerSucursalWrks()
        {
            return repoSucursalWrk.ObtenerSucursalWrks();
        }

        public List<SucursalWrk> ObtenerSucursalWrksbyIdPlaza(int IdPlaza)
        {

            return repoSucursalWrk.ObtenerSucursalWrksbyIdPlaza(IdPlaza);
        }

        public bool CrearSucursalWrk(SucursalWrk SucursalWrk)
        {
            return repoSucursalWrk.CrearSucursalWrk(SucursalWrk);
        }

        public bool ModificarSucursalWrk(SucursalWrk SucursalWrk)
        {
            return repoSucursalWrk.ModificarSucursalWrk(SucursalWrk);
        }

        public bool DesactivarSucursalWrk(int idSucursalWrk)
        {
            return repoSucursalWrk.DesactivarSucursalWrk(idSucursalWrk);
        }

        public SucursalWrk SucursalWrkbyId(int idSucursalWrk)
        {
            return repoSucursalWrk.SucursalWrkbyId(idSucursalWrk);
        }


    }
}
