using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Sucursal;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioSucursal
    {
        public List<SucursalesCat> ObtenerSucursales();
        public List<SucursalesCat> ObtenerSucursalesbyIdPlaza(int IdPlaza);
        public List<SucursalDom> ObtenerSucursalDom();


    }
}
