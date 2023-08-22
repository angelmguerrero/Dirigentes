using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioPlantillaOrdenDia : IRepositorioPlantillaOrdenDia
    {

        private CPMDirigentesPlataformaContext context;
        IGenericRepository<PlantillaOrdenDia> repo;

        public RepositorioPlantillaOrdenDia()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<PlantillaOrdenDia>(context);
        }
        public List<PlantillaOrdenDia> Obtener()
        {
            return context.PlantillaOrdenDia.ToList();
        }
        public int Crear(PlantillaOrdenDia item)
        {
            //Respuesta resp = new Respuesta();

            try
            {
                item.EstatusPlantillaOrdenDia = true;
                context.PlantillaOrdenDia.Add(item);
                context.SaveChanges();
                return item.IdPlantillaOrdenDia;
            }
            catch (Exception ex)
            {
                Logger.Error("Creacion PlantillaOrdenDia", ex);
                return 0;
            }
        }

        public bool Desactivar(int id)
        {
            var _plantilla = context.PlantillaOrdenDia.Where(x => x.IdPlantillaOrdenDia == id).FirstOrDefault();
            if (_plantilla == null)
                return false;
            try
            {
                _plantilla.EstatusPlantillaOrdenDia = false;
                return repo.Update(_plantilla);
            }
            catch (Exception ex)
            {
                Logger.Error("Creacion PlantillaOrdenDia", ex);
                return false;
            }
        }

        public Respuesta Modificar(PlantillaOrdenDia item)
        {
            Respuesta resp = new Respuesta();
            var _plantilla = context.PlantillaOrdenDia.Where(x => x.IdPlantillaOrdenDia == item.IdPlantillaOrdenDia).SingleOrDefault();
            if (_plantilla == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _plantilla.Descripcion = item.Descripcion;
                _plantilla.IdTipoJunta = item.IdTipoJunta;
                _plantilla.EstatusPlantillaOrdenDia = item.EstatusPlantillaOrdenDia;
                resp.Resultado = repo.Update(_plantilla);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion PlantillaOrdenDia", ex);
                resp.Resultado = false;
                resp.Mensaje = "Ocurrio un error.";
                return resp;
            }
        }


        public PlantillaOrdenDia ObtenerPlantillaPorDescripcion(string descMotivo)
        {
            var plantilla = context.PlantillaOrdenDia.Where(x => x.Descripcion == descMotivo).FirstOrDefault();

            if (plantilla == null)
                return null;
            else
                return plantilla;
        }

        public PlantillaOrdenDia RegistrobyId(int id)
        {
            var plantilla = context.PlantillaOrdenDia.Where(x => x.IdPlantillaOrdenDia == id).FirstOrDefault();

            if (plantilla == null)
                return null;
            else
                return plantilla;
        }

        public List<PlantillaOrdenDiaJunta> ObtenerPlantillaOrdenDiaDt()
        {
            try
            {
                var consulta = (from plantilla in context.PlantillaOrdenDia
                                join junta in context.TipoJuntaCats
                                on plantilla.IdTipoJunta equals junta.IdTipoJunta
                                select new PlantillaOrdenDiaJunta
                                {
                                    IdPlantillaOrdenDia = plantilla.IdPlantillaOrdenDia,
                                    Descripcion = plantilla.Descripcion,
                                    IdTipoJunta = plantilla.IdTipoJunta,
                                    DescripcionJunta = junta.Descripcion,
                                    EstatusPlantillaOrdenDia = plantilla.EstatusPlantillaOrdenDia
                                }

                ).ToList();

                return consulta;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta PlantillaOrdenDia", ex);
                return null;
            }
        }

        public bool EliminarPlantilla(int id)
        {
            try
            {
                var plantilla = repo.GetFirstOrDefault(x => x.IdPlantillaOrdenDia == id);
                repo.Delete(plantilla);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Eliminar PlantillaOrdenDia", ex);
                return false;
            }
        }

        public int ObtenerIdPlantillaPorTipodeJunta(int id)
        {
            var plantilla = repo.GetFirstOrDefault(x => x.IdTipoJunta == id);
            if (plantilla == null)
            {
                return 0;
            }
            return plantilla.IdPlantillaOrdenDia;
        }
    }
}
