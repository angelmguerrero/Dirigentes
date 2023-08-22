using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioMotivosBaja : IRepositorioMotivosBaja

    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<MotivosBajaCat> repo;
        public RepositorioMotivosBaja()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<MotivosBajaCat>(context);
        }

        public List<MotivosBajaCat> Obtener()
        {
            return context.MotivosBajaCats.ToList();
        }
        public List<MotivosBajaCat> ObtenerSinMotivo()
        {
            var ObtenerSinmotivoactivo = (from motivobaja in context.MotivosBajaCats
                                          where motivobaja.IdMotivoBaja != 5
                                          && motivobaja.EstatusMotivoBaja == true
                                          select motivobaja).ToList();

            if (ObtenerSinmotivoactivo == null)
                return null;
            else
                return ObtenerSinmotivoactivo;
        }
        public Respuesta Crear(MotivosBajaCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusMotivoBaja = true;
                context.MotivosBajaCats.Add(item);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion MotivoBaja", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public Respuesta Modificar(MotivosBajaCat item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.MotivosBajaCats.Where(x => x.IdMotivoBaja == item.IdMotivoBaja).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _item.Descripcion = item.Descripcion;
                _item.EstatusMotivoBaja = item.EstatusMotivoBaja;
                resp.Resultado = repo.Update(_item);

                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion MotivoBaja", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public bool Desactivar(int id)
        {
            var _cargo = context.MotivosBajaCats.Where(x => x.IdMotivoBaja == id).SingleOrDefault();
            if (_cargo == null)
                return false;
            try
            {
                _cargo.EstatusMotivoBaja = false;
                return repo.Update(_cargo);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar MotivoBaja", ex);
                return false;
            }
        }

        public MotivosBajaCat RegistrobyId(int id)
        {
            var cargo = context.MotivosBajaCats.Where(x => x.IdMotivoBaja == id).FirstOrDefault();

            if (cargo == null)
                return null;
            else
                return cargo;

        }

        public MotivosBajaCat ObtenerMotivoPorDescripcion(String descMotivo)
        {
            var motivo = context.MotivosBajaCats.Where(x => x.Descripcion == descMotivo).FirstOrDefault();

            if (motivo == null)
                return null;
            else
                return motivo;
        }

        public List<MotivosBajaCat> ObtenerMotivosDt()
        {
            try
            {
                var motivos = (from motivo in context.MotivosBajaCats
                               where motivo.IdMotivoBaja != 5
                               select new MotivosBajaCat
                               {
                                   IdMotivoBaja = motivo.IdMotivoBaja,
                                   Descripcion = motivo.Descripcion,
                                   EstatusMotivoBaja = motivo.EstatusMotivoBaja,
                               }).ToList();

                return motivos;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta MotivoBaja", ex);
                return null;
            }
        }

    }
}
