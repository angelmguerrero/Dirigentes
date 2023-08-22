using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Sucursal;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorSucursal : IAdministradorSucursal
    {
        private IRepositorioSucursal repoSucursal;
        public AdministradorSucursal()
        {
            this.repoSucursal = new RepositorioSucursal();
        }

        public List<SucursalesCat> ObtenerSucursales()
        {
            return repoSucursal.ObtenerSucursales();
        }

        public List<SucursalesCat> ObtenerSucursalesbyIdPlaza(int IdPlaza)
        {

            return repoSucursal.ObtenerSucursalesbyIdPlaza(IdPlaza);
        }

        public List<SucursalDom> ObtenerSucursalDom()
        {
            return repoSucursal.ObtenerSucursalDom();
        }
    }
}
