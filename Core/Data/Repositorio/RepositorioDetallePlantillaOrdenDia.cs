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
    public class RepositorioDetallePlantillaOrdenDia : IRepositorioDetallePlantillaOrdenDia
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<DetallePlantillaOrdenDia> repo;

        public RepositorioDetallePlantillaOrdenDia()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<DetallePlantillaOrdenDia>(context);
        }

        public int Crear(DetallePlantillaOrdenDiaDom item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                DetallePlantillaOrdenDia detalle = new DetallePlantillaOrdenDia();
                detalle.IdConsecutivoPadre = item.IdConsecutivoPadre;
                detalle.Descripcion = item.Descripcion;
                detalle.Indice = item.Indice;
                detalle.IdPadre = item.IdPadre;
                detalle.IdPlantillaOrdenDia = item.IdPlantillaOrdenDia;
                if (repo.Insert(detalle))
                {
                    return detalle.IdDetallePlantillaOrdenDia;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Creacion DetallePlantillaOrdenDia", ex);
                return 0;
            }

        }

        public bool Desactivar(DetallePlantillaOrdenDiaDom item)
        {
            try
            {
                DetallePlantillaOrdenDia detalle = new DetallePlantillaOrdenDia();
                detalle.IdDetallePlantillaOrdenDia = item.IdDetallePlantillaOrdenDia;
                detalle.IdConsecutivoPadre = item.IdConsecutivoPadre;
                detalle.Descripcion = item.Descripcion;
                detalle.Indice = item.Indice;
                detalle.IdPadre = item.IdPadre;
                detalle.IdPlantillaOrdenDia = item.IdPlantillaOrdenDia;

                if (detalle.IdDetallePlantillaOrdenDia > 0)
                {
                    return repo.Delete(detalle);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Eliminar DetallePlantillaOrdenDia", ex);
                return false;
            }
        }

        public Respuesta Modificar(DetallePlantillaOrdenDiaDom item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                DetallePlantillaOrdenDia detalle = new DetallePlantillaOrdenDia();
                detalle.IdDetallePlantillaOrdenDia = item.IdDetallePlantillaOrdenDia;
                detalle.IdConsecutivoPadre = item.IdConsecutivoPadre;
                detalle.Descripcion = item.Descripcion;
                detalle.Indice = item.Indice;
                detalle.IdPadre = item.IdPadre;
                detalle.IdPlantillaOrdenDia = item.IdPlantillaOrdenDia;
                if (repo.Update(detalle))
                {
                    resp.Resultado = true;
                    return resp;
                }
                else
                {
                    resp.Resultado = false;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion DetallePlantillaOrdenDia", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public DetallePlantillaOrdenDia ObtenerPlantillaPorDescripcion(string descMotivo)
        {
            throw new NotImplementedException();
        }

        public List<DetallePlantillaOrdenDiaDom> RegistrobyId(int id)
        {
            try
            {
                var consulta = (from detalle in context.DetallePlantillaOrdenDia
                                where detalle.IdPlantillaOrdenDia == id
                                select new DetallePlantillaOrdenDiaDom
                                {
                                    IdDetallePlantillaOrdenDia = detalle.IdDetallePlantillaOrdenDia,
                                    IdConsecutivoPadre = detalle.IdConsecutivoPadre,
                                    Descripcion = detalle.Descripcion,
                                    Indice = detalle.Indice,
                                    IdPadre = detalle.IdPadre,
                                    IdPlantillaOrdenDia = detalle.IdPlantillaOrdenDia,
                                }
                ).ToList();

                return consulta;
            }
            catch (Exception ex)
            {
                Logger.Error("RegistroByid DetallePlantillaOrdenDia", ex);
                return null;
            }
        }

        public List<DetallePlantillaOrdenDiaDom> RegistrobyIdPadre(int idPlantilla, int idPadre)
        {
            try
            {
                var consulta = (from detalle in context.DetallePlantillaOrdenDia
                                where detalle.IdPlantillaOrdenDia == idPlantilla
                                && detalle.IdPadre == idPadre
                                select new DetallePlantillaOrdenDiaDom
                                {
                                    IdDetallePlantillaOrdenDia = detalle.IdDetallePlantillaOrdenDia,
                                    IdConsecutivoPadre = detalle.IdConsecutivoPadre,
                                    Descripcion = detalle.Descripcion,
                                    Indice = detalle.Indice,
                                    IdPadre = detalle.IdPadre,
                                    IdPlantillaOrdenDia = detalle.IdPlantillaOrdenDia,
                                }
                ).ToList();

                return consulta;
            }
            catch (Exception ex)
            {
                Logger.Error("RegistroByidPadre DetallePlantillaOrdenDia", ex);
                return null;
            }
        }

        public DetallePlantillaOrdenDiaDom ObtenerUltimoIdPadre(int idPlantilla)
        {
            try
            {
                var consulta = (from detalle in context.DetallePlantillaOrdenDia
                                where detalle.IdPlantillaOrdenDia == idPlantilla
                                select new DetallePlantillaOrdenDiaDom
                                {
                                    IdDetallePlantillaOrdenDia = detalle.IdDetallePlantillaOrdenDia,
                                    IdConsecutivoPadre = detalle.IdConsecutivoPadre,
                                    Descripcion = detalle.Descripcion,
                                    Indice = detalle.Indice,
                                    IdPadre = detalle.IdPadre,
                                    IdPlantillaOrdenDia = detalle.IdPlantillaOrdenDia,
                                }
                ).OrderByDescending(x => x.IdConsecutivoPadre).FirstOrDefault();

                return consulta;
            }
            catch (Exception ex)
            {
                Logger.Error("UltimoIdPadre DetallePlantillaOrdenDia", ex);
                return null;
            }
        }

        public bool EliminarNivelPorId(int id)
        {
            try
            {
                var detalle = repo.GetFirstOrDefault(x => x.IdDetallePlantillaOrdenDia == id);
                repo.Delete(detalle);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("EliminacionporId DetallePlantillaOrdenDia", ex);
                return false;
            }
        }
    }
}
