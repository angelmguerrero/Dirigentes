using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioEscolaridad : IRepositorioEscolaridad
    {

        private CPMDirigentesPlataformaContext context;
        IGenericRepository<EscolaridadCat> repo;
        public RepositorioEscolaridad()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<EscolaridadCat>(context);
        }

        public List<EscolaridadCat> ObtenerEscolaridades()
        {
            return context.EscolaridadCats.ToList();
        }
        public Respuesta CrearEscolaridad(EscolaridadCat escolaridad)
        {
            Respuesta resp = new Respuesta();
            try
            {
                escolaridad.EstatusEscolaridad = true;
                context.EscolaridadCats.Add(escolaridad);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion Escolaridad", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta ModificarEscolaridad(EscolaridadCat escolaridad)
        {
            Respuesta resp = new Respuesta();
            var _escolaridad = context.EscolaridadCats.Where(x => x.IdEscolaridad == escolaridad.IdEscolaridad).SingleOrDefault();
            if (_escolaridad == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _escolaridad.Descripcion = escolaridad.Descripcion;
                _escolaridad.EstatusEscolaridad = escolaridad.EstatusEscolaridad;
                resp.Resultado = repo.Update(_escolaridad);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion Escolaridad", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool DesactivarEscolaridad(int escolaridad)
        {
            var _escolaridad = context.EscolaridadCats.Where(x => x.IdEscolaridad == escolaridad).FirstOrDefault();
            if (_escolaridad == null)
                return false;
            try
            {
                _escolaridad.EstatusEscolaridad = false;
                return repo.Update(_escolaridad);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar Escolaridad", ex);
                return false;
            }
        }

        public EscolaridadCat ObtenerEscolaridad(int idescolaridad)
        {
            var escolaridad = context.EscolaridadCats.Where(x => x.IdEscolaridad == idescolaridad).FirstOrDefault();

            if (escolaridad == null)
                return null;
            else
                return escolaridad;

        }

        public EscolaridadCat ObtenerEscolaridadPorDescripcion(String descEscolaridad)
        {
            var escolaridad = context.EscolaridadCats.Where(x => x.Descripcion == descEscolaridad).FirstOrDefault();

            if (escolaridad == null)
                return null;
            else
                return escolaridad;
        }

        public List<SelectDom> ObtenerEscolaridadActivo()
        {
            try
            {
                var prueba = (from esc in context.EscolaridadCats
                              where esc.EstatusEscolaridad == true
                              select new SelectDom
                              {
                                  value = esc.IdEscolaridad,
                                  text = esc.Descripcion

                              }).ToList();
                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta Escolaridad", ex);
                return null;
            }
        }

    }
}
