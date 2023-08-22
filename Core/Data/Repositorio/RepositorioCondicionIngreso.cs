using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioCondicionIngreso : IRepositorioCondicionIngreso
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<CondicionIngresoCat> repo;
        public RepositorioCondicionIngreso()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<CondicionIngresoCat>(context);
        }
        public List<CondicionIngresoCat> Obtener()
        {
            try
            {
                return context.CondicionIngresoCats.ToList();
            }
            catch (Exception ex)
            {
                Logger.Error("Obtener CondicionIngresoCat", ex);
                return null;
            }
        }
        public List<CondicionIngresoCat> ObtenerActivas()
        {
            try
            {

                return context.CondicionIngresoCats.Where(x => x.EstatusCondicion == true).ToList();
            }
            catch (Exception ex)
            {
                Logger.Error("ObtenerActivas CondicionIngresoCat", ex);
                return null;
            }
        }
        public Respuesta Crear(CondicionIngresoCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusCondicion = true;
                context.CondicionIngresoCats.Add(item);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion CondicionIngreso", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public Respuesta Modificar(CondicionIngresoCat item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.CondicionIngresoCats.Where(x => x.IdCondicion == item.IdCondicion).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }

            try
            {
                _item.CondicionIngreso = item.CondicionIngreso;
                _item.EstatusCondicion = item.EstatusCondicion;
                resp.Resultado = repo.Update(_item);
                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion CondicionIngreso", ex);
                resp.Resultado = false;
                resp.Mensaje = "Ocurrio un error";
                return resp;
            }


        }
        public bool Desactivar(int id)
        {
            var _item = context.CondicionIngresoCats.Where(x => x.IdCondicion == id).SingleOrDefault();
            if (_item == null)
                return false;

            try
            {
                _item.EstatusCondicion = false;
                return repo.Update(_item);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar CondicionIngreso", ex);
                return false;
            }
        }
        public CondicionIngresoCat RegistrobyId(int id)
        {
            try
            {
                var item = context.CondicionIngresoCats.Where(x => x.IdCondicion == id).FirstOrDefault();

                if (item == null)
                    return null;
                else
                    return item;
            }
            catch (Exception ex)
            {
                Logger.Error("RegistrobyId CondicionIngreso", ex);
                return null;
            }

        }

        public CondicionIngresoCat ObtenerCondicionPorDescripcion(String descCondicion)
        {
            try
            {
                var condicion = context.CondicionIngresoCats.Where(x => x.CondicionIngreso == descCondicion).FirstOrDefault();

                if (condicion == null)
                    return null;
                else
                    return condicion;
            }
            catch (Exception ex)
            {
                Logger.Error("ObtenerCondicionPorDescripcion CondicionIngresoCat", ex);
                return null;
            }
        }

    }
}