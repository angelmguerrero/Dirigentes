using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Sucursal;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorSucursal
    {
        public List<SucursalesCat> ObtenerSucursales();
        public List<SucursalesCat> ObtenerSucursalesbyIdPlaza(int IdPlaza);
        public List<SucursalDom> ObtenerSucursalDom();
    }
}
