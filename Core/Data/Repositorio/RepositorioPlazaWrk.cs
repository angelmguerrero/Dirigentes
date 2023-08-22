using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPMPlataformaDirigentes.Data.Contexto;
using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioPlazaWrk : IRepositorioPlazaWrk
    {
        private CPMDirectorioSucursalesContext context;
        public RepositorioPlazaWrk()
        {
            this.context = new CPMDirectorioSucursalesContext(Configuracion.GetConnectionConsultaCpmDirectorioString());
        }

        public List<PlazaWrk> ObtenerPlazaWrks()
        {
            return context.PlazaWrks.ToList();
        }

        public List<SelectDom> ObtenerPlazaActivo()
        {

            var prueba = (from plaza in context.PlazaWrks
                          where plaza.Activo == true
                          select new SelectDom
                          {
                              value = plaza.IdPlaza,
                              text = plaza.Nombre

                          }).ToList();
            return prueba;
        }

        //public bool CrearPlazaWrk(PlazaWrk PlazaWrk)
        //{
        //    try
        //    {
        //        PlazaWrk.Activo = true;
        //        context.PlazaWrks.Add(PlazaWrk);
        //        context.SaveChanges();
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool ModificarPlazaWrk(PlazaWrk PlazaWrk)
        //{
        //    var _PlazaWrk = context.PlazaWrks.Where(x => x.IdPlaza == PlazaWrk.IdPlaza).SingleOrDefault();
        //    if (_PlazaWrk == null)
        //        return false;

        //    _PlazaWrk.IdPlaza = PlazaWrk.IdPlaza;
        //    _PlazaWrk.Nombre = PlazaWrk.Nombre;
        //    _PlazaWrk.IdRegion = PlazaWrk.IdRegion;
        //    _PlazaWrk.Activo = PlazaWrk.Activo;
        //    _PlazaWrk.CentroCostos = PlazaWrk.CentroCostos;            
        //    context.SaveChanges();

        //    return true;
        //}

        //public bool DesactivarPlazaWrk(int idPlazaWrk)
        //{
        //    var _PlazaWrk = context.PlazaWrks.Where(x => x.IdPlaza == idPlazaWrk).SingleOrDefault();
        //    if (_PlazaWrk == null)
        //        return false;

        //    _PlazaWrk.Activo = false;
        //    context.SaveChanges();
        //    return true;
        //}

        //public PlazaWrk PlazaWrkbyId(int idPlazaWrk)
        //{
        //    var PlazaWrk = context.PlazaWrks.Where(x => x.IdPlaza == idPlazaWrk).FirstOrDefault();

        //    if (PlazaWrk == null)
        //        return null;
        //    else
        //        return PlazaWrk;

        //}



    }
}
