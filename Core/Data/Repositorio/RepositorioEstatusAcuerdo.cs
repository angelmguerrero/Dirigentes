using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioEstatusAcuerdo : IRepositorioEstatusAcuerdo
    {

        private CPMDirigentesPlataformaContext context;
        IGenericRepository<EstatusAcuerdosCat> repo;
        public RepositorioEstatusAcuerdo()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<EstatusAcuerdosCat>(context);
        }
        public List<EstatusAcuerdosCat> Obtener()
        {
            return context.EstatusAcuerdosCats.ToList();
        }
        public Respuesta Crear(EstatusAcuerdosCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusAcuerdo = true;
                if (repo.Insert(item))
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
                Logger.Error("Creacion EstatusAcuerdo", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta Modificar(EstatusAcuerdosCat item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.EstatusAcuerdosCats.Where(x => x.IdEstatusAcuerdo == item.IdEstatusAcuerdo).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _item.Descripcion = item.Descripcion;
                _item.EstatusAcuerdo = item.EstatusAcuerdo;
                resp.Resultado = repo.Update(_item);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion EstatusAcuerdo", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool Desactivar(int id)
        {
            var _genero = context.EstatusAcuerdosCats.Where(x => x.IdEstatusAcuerdo == id).SingleOrDefault();
            if (_genero == null)
                return false;
            try
            {
                _genero.EstatusAcuerdo = false;
                return repo.Update(_genero);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar EstatusAcuerdo", ex);
                return false;
            }
        }

        public EstatusAcuerdosCat RegistrobyId(int id)
        {
            var genero = context.EstatusAcuerdosCats.Where(x => x.IdEstatusAcuerdo == id).FirstOrDefault();

            if (genero == null)
                return null;
            else
                return genero;
        }

        public EstatusAcuerdosCat ObtenerEstatusAcuerdoPorDescripcion(String estatus)
        {
            var acuerdo = context.EstatusAcuerdosCats.Where(x => x.Descripcion == estatus).FirstOrDefault();

            if (acuerdo == null)
                return null;
            else
                return acuerdo;
        }


    }
}
