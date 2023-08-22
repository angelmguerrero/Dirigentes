using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Plaza;
using CPMPlataformaDirigentes.Data.Contexto;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioPlaza : IRepositorioPlaza
    {
        private CPMDirectorioSucursalesContext context;
        public RepositorioPlaza()
        {
            this.context = new CPMDirectorioSucursalesContext(Configuracion.GetConnectionConsultaCpmDirectorioString());
        }

        public List<PlazaCat> ObtenerPlazas()
        {
            return (from plaza in context.PlazaWrks
                    select new PlazaCat
                    {
                        IdPlaza = plaza.IdPlaza,
                        Descripcion = plaza.Nombre,
                        EstatusPlaza = plaza.Activo,
                        IdRegion = plaza.IdRegion,
                        CentroCosto = plaza.CentroCostos
                    }).ToList();
        }
        public PlazaCat PlazabyId(int idPlaza)
        {
            var Plaza = (from plaza in context.PlazaWrks
                         where plaza.IdPlaza == idPlaza
                         select new PlazaCat
                         {
                             IdPlaza = plaza.IdPlaza,
                             Descripcion = plaza.Nombre,
                             EstatusPlaza = plaza.Activo,
                             IdRegion = plaza.IdRegion,
                             CentroCosto = plaza.CentroCostos
                         }).FirstOrDefault();

            if (Plaza == null)
                return null;
            else
                return Plaza;

        }
        public List<PlazaDom> ObtenerPlazaDom()
        {
            return (from plaza in context.PlazaWrks
                    join region in context.RegionWrks
                    on plaza.IdRegion equals region.IdRegion
                    select new PlazaDom

                    {
                        IdPlaza = plaza.IdPlaza,
                        Descripcion = plaza.Nombre,
                        EstatusPlaza = plaza.Activo,
                        Region = region.Nombre,
                        CentroCosto = plaza.CentroCostos
                    }).ToList();

        }
        public List<SelectDom> ObtenerRegiones()
        {

            var prueba = (from clas in context.RegionWrks
                          select new SelectDom
                          {
                              value = clas.IdRegion,
                              text = clas.Nombre

                          }).ToList();
            return prueba;
        }

    }
}
