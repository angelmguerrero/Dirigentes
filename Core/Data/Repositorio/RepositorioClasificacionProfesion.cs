using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioClasificacionProfesion : IRepositorioClasificacionProfesion
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<ClasificacionProfesion> repo;
        public RepositorioClasificacionProfesion()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<ClasificacionProfesion>(context);
        }

        public List<ProfesionesClasificacionProfesion> ObtenerProfesionesClasificacionProfesion()
        {
            try
            {
                var prueba = (from clas in context.ClasificacionProfesions
                              join prof in context.ProfesionCats
                              on clas.IdClasificacionProfesion equals prof.IdClasificacionProfesion into gj
                              from subpet in gj.DefaultIfEmpty()
                              select new ProfesionesClasificacionProfesion
                              {
                                  IdClasificacionProfesion = clas.IdClasificacionProfesion,
                                  DescripcionClasif = clas.Descripcion,
                                  DescripcionProfesion = subpet.Descripcion,
                                  IdProfesion = subpet.IdProfesion,
                                  EstatusClasificacionProfesion = clas.EstatusClasificacionProfesion,
                                  EstatusProfesion = subpet.EstatusProfesion

                              }).ToList();

                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta ClasificacionProfesion", ex);
                return null;
            }


        }
        public List<ClasificacionProfesion> ObtenerClasificacionesProfesion()
        {
            try
            {

                return context.ClasificacionProfesions.ToList();

            }
            catch (Exception ex)
            {
                Logger.Error("Consulta ClasificacionProfesion", ex);
                return null;
            }
        }
        public Respuesta CrearClasificacionProfesion(ClasificacionProfesion clasProfesion)
        {
            ClasificacionProfesion _clasprofesion = new ClasificacionProfesion();
            Respuesta resp = new Respuesta();

            try
            {
                _clasprofesion.EstatusClasificacionProfesion = true;
                context.ClasificacionProfesions.Add(clasProfesion);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion ClasificacionProfesion", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta ModificarClasificacionProfesion(ClasificacionProfesion clasProfesion)
        {
            Respuesta resp = new Respuesta();
            var _clasprofesion = context.ClasificacionProfesions.Where(x => x.IdClasificacionProfesion == clasProfesion.IdClasificacionProfesion).SingleOrDefault();
            if (_clasprofesion == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }

            try
            {

                _clasprofesion.Descripcion = clasProfesion.Descripcion;
                _clasprofesion.EstatusClasificacionProfesion = clasProfesion.EstatusClasificacionProfesion;
                resp.Resultado = repo.Update(_clasprofesion);

                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion ClasificacionProfesion", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool DesactivarClasificacionProfesion(int clasificacionProfesion)
        {
            var _clasprofesion = context.ClasificacionProfesions.Where(x => x.IdClasificacionProfesion == clasificacionProfesion).FirstOrDefault();
            if (_clasprofesion == null)
                return false;
            try
            {
                _clasprofesion.EstatusClasificacionProfesion = false;
                return repo.Update(_clasprofesion);

            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar ClasificacionProfesion", ex);
                return false;
            }
        }

        public ClasificacionProfesion ObtenerClasificacionProfesion(int idclasprofesion)
        {
            var clasprofesion = context.ClasificacionProfesions.Where(x => x.IdClasificacionProfesion == idclasprofesion).FirstOrDefault();

            if (clasprofesion == null)
                return null;
            else
                return clasprofesion;
        }

        public List<SelectDom> ObtenerClasificacionActivo()
        {

            var prueba = (from clas in context.ClasificacionProfesions
                          where clas.EstatusClasificacionProfesion == true
                          select new SelectDom
                          {
                              value = clas.IdClasificacionProfesion,
                              text = clas.Descripcion

                          }).ToList();
            return prueba;
        }
        public ClasificacionProfesion ObtenerClasificacionProfesionPorDescripcion(String descProfesion)
        {
            var clasprofesion = context.ClasificacionProfesions.Where(x => x.Descripcion == descProfesion).FirstOrDefault();

            if (clasprofesion == null)
                return null;
            else
                return clasprofesion;
        }


        public List<ProfesionesClasificacionProfesion> ObtenerClasificacionProfesionPorDescripcionbyid(int idProfesion)
        {
            try
            {
                var prueba = (from profesion in context.ProfesionCats
                              join clasificacion in context.ClasificacionProfesions
                              on profesion.IdClasificacionProfesion equals clasificacion.IdClasificacionProfesion
                              where profesion.IdProfesion == idProfesion
                              && profesion.EstatusProfesion == true
                              && clasificacion.EstatusClasificacionProfesion == true


                              select new ProfesionesClasificacionProfesion
                              {

                                  IdProfesion = profesion.IdProfesion,
                                  DescripcionProfesion = profesion.Descripcion,
                                  IdClasificacionProfesion = clasificacion.IdClasificacionProfesion,
                                  DescripcionClasif = clasificacion.Descripcion

                              }).ToList();
                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta ClasificacionProfesion", ex);
                return null;
            }
        }
    }


}
