using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioTipoBaja : IRepositorioTipoBaja
    {

        private CPMDirigentesPlataformaContext context;
        IGenericRepository<TipoBaja> repo;
        public RepositorioTipoBaja()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<TipoBaja>(context);
        }

        public List<TipoBaja> Obtener()
        {
            return context.TipoBajas.ToList();
        }

        public List<TipoBaja> ObtenerActivas()
        {

            return context.TipoBajas.Where(x => x.EstatusTipoBaja == true).ToList();
        }
        public Respuesta Crear(TipoBaja item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusTipoBaja = true;
                context.TipoBajas.Add(item);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion TipoBaja", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public Respuesta Modificar(TipoBaja item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.TipoBajas.Where(x => x.IdTipoBaja == item.IdTipoBaja).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _item.Descripcion = item.Descripcion;
                _item.EstatusTipoBaja = item.EstatusTipoBaja;
                resp.Resultado = repo.Update(_item);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion TipoBaja", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public bool Desactivar(int id)
        {
            var _item = context.TipoBajas.Where(x => x.IdTipoBaja == id).SingleOrDefault();
            if (_item == null)
                return false;
            try
            {
                _item.EstatusTipoBaja = false;
                return repo.Update(_item);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar TipoBaja", ex);
                return false;
            }
        }

        public TipoBaja RegistrobyId(int id)
        {
            var item = context.TipoBajas.Where(x => x.IdTipoBaja == id).FirstOrDefault();

            if (item == null)
                return null;
            else
                return item;

        }

        public TipoBaja ObtenerTipoPorDescripcion(String descTipo)
        {
            var tipo = context.TipoBajas.Where(x => x.Descripcion == descTipo).FirstOrDefault();

            if (tipo == null)
                return null;
            else
                return tipo;
        }


    }
}
