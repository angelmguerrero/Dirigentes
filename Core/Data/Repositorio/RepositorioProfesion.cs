using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioProfesion : IRepositorioProfesion
    {

        private CPMDirigentesPlataformaContext context;
        IGenericRepository<ProfesionCat> repo;
        public RepositorioProfesion()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<ProfesionCat>(context);
        }

        public List<ProfesionCat> ObtenerProfesiones()
        {
            return context.ProfesionCats.ToList();
        }
        public List<ProfesionCat> ObtenerProfesionesActivas()
        {
            return context.ProfesionCats.Where(x => x.EstatusProfesion == true).ToList();
        }

        public Respuesta CrearProfesion(ProfesionCat profesion)
        {
            ProfesionCat _profesion = new ProfesionCat();
            Respuesta resp = new Respuesta();
            try
            {
                _profesion.Descripcion = profesion.Descripcion;
                _profesion.EstatusProfesion = profesion.EstatusProfesion;
                _profesion.IdClasificacionProfesion = profesion.IdClasificacionProfesion;
                context.ProfesionCats.Add(profesion);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion Profesion", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta ModificarProfesion(ProfesionCat profesion)
        {
            Respuesta resp = new Respuesta();
            var _profesion = context.ProfesionCats.Where(x => x.IdProfesion == profesion.IdProfesion).SingleOrDefault();
            if (_profesion == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _profesion.Descripcion = profesion.Descripcion;
                _profesion.EstatusProfesion = profesion.EstatusProfesion;
                _profesion.IdClasificacionProfesion = profesion.IdClasificacionProfesion;
                resp.Resultado = repo.Update(_profesion);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion Profesion", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool DesactivarProfesion(int profesion)
        {
            var _profesion = context.ProfesionCats.Where(x => x.IdProfesion == profesion).SingleOrDefault();
            if (_profesion == null)
                return false;
            try
            {
                _profesion.EstatusProfesion = false;
                return repo.Update(_profesion);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar Profesion", ex);
                return false;
            }
        }

        public ProfesionCat ObtenerProfesion(int idprofesion)
        {
            var profesion = context.ProfesionCats.Where(x => x.IdProfesion == idprofesion).FirstOrDefault();

            if (profesion == null)
                return null;
            else
                return profesion;
        }

        public ProfesionCat ObtenerProfesionPorDescripcion(String descProfesion)
        {
            var profesion = context.ProfesionCats.Where(x => x.Descripcion == descProfesion).FirstOrDefault();

            if (profesion == null)
                return null;
            else
                return profesion;
        }

        public bool DesactivarProfesionPorClasificacion(int clas)
        {
            var prueba = (from prof in context.ProfesionCats
                          where prof.EstatusProfesion == true && prof.IdClasificacionProfesion == clas
                          select new ProfesionCat
                          {
                              IdProfesion = prof.IdProfesion,
                              Descripcion = prof.Descripcion,
                              IdClasificacionProfesion = prof.IdClasificacionProfesion,
                              EstatusProfesion = prof.EstatusProfesion
                          }).ToList();

            try
            {
                foreach (var item in prueba)
                {
                    item.EstatusProfesion = false;
                    repo.Update(item);
                }

                return true;

            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar ProfesionPorClasificacion", ex);
                return false;
            }


        }
        public List<ProfesionClasifProfesion> ObtenerProfesionesDt()
        {
            try
            {
                var prueba = (from prof in context.ProfesionCats
                              join clas in context.ClasificacionProfesions
                              on prof.IdClasificacionProfesion equals clas.IdClasificacionProfesion
                              select new ProfesionClasifProfesion
                              {
                                  IdProfesion = prof.IdProfesion,
                                  Descripcion = prof.Descripcion,
                                  DescripcionClasificacion = clas.Descripcion,
                                  IdClasificacionProfesion = clas.IdClasificacionProfesion,
                                  EstatusProfesion = prof.EstatusProfesion

                              }).ToList();

                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta Profesiones", ex);
                return null;
            }
        }



    }
}
