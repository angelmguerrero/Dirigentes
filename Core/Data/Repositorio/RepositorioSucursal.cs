using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Sucursal;
using CPMPlataformaDirigentes.Data.Contexto;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioSucursal : IRepositorioSucursal
    {
        private CPMDirectorioSucursalesContext context;
        public RepositorioSucursal()
        {
            this.context = new CPMDirectorioSucursalesContext(Configuracion.GetConnectionConsultaCpmDirectorioString());
        }
        public List<SucursalesCat> ObtenerSucursales()
        {

            return (from sucursal in context.SucursalWrks
                    select new SucursalesCat
                    {
                        IdSucursal = sucursal.IdSucursal,
                        Descripcion = sucursal.Nombre,
                        EstatusSucursal = sucursal.Activo,
                        IdPlaza = sucursal.IdPlaza,
                        CentroCosto = sucursal.CentroCostos
                    }).ToList();


        }
        public List<SucursalesCat> ObtenerSucursalesbyIdPlaza(int IdPlaza)
        {
            var sucursalCat = (from pla1 in context.PlazaWrks
                               join suc2 in context.SucursalWrks
                               on pla1.IdPlaza equals suc2.IdPlaza
                               where pla1.IdPlaza == IdPlaza

                               select new SucursalesCat

                               {
                                   IdSucursal = suc2.IdSucursal,
                                   Descripcion = suc2.Nombre,
                                   EstatusSucursal = suc2.Activo

                               }).ToList();

            return sucursalCat;
        }
        public List<SucursalDom> ObtenerSucursalDom()
        {
            return (from suc in context.SucursalWrks
                    join plaza in context.PlazaWrks
                    on suc.IdPlaza equals plaza.IdPlaza
                    select new SucursalDom

                    {
                        IdSucursal = suc.IdSucursal,
                        Descripcion = suc.Nombre,
                        EstatusSucursal = suc.Activo,
                        Plaza = plaza.Nombre,
                        CentroCosto = suc.CentroCostos
                    }).ToList();

        }



    }
}
