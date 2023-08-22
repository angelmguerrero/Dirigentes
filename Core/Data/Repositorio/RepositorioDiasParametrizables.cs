using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioDiasParametrizables : IRepositorioDiasParametrizables
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<DiasParametrizablesCat> repo;
        public RepositorioDiasParametrizables()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<DiasParametrizablesCat>(context);
        }
        public List<DiasParametrizablesCat> Obtener()
        {
            return context.DiasParametrizablesCats.ToList();
        }
        public Respuesta Crear(DiasParametrizablesCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusDiaParametrizable = true;
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
                Logger.Error("Creacion DiasParametrizables", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta Modificar(DiasParametrizablesCat item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.DiasParametrizablesCats.Where(x => x.IdDiaParametrizable == item.IdDiaParametrizable).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _item.Descripcion = item.Descripcion;
                _item.Dias = item.Dias;
                _item.DiasNaturales = item.DiasNaturales;
                _item.EstatusDiaParametrizable = item.EstatusDiaParametrizable;
                if (repo.Update(_item))
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
                Logger.Error("Modificacion DiasParametrizables", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool Desactivar(int id)
        {
            var _item = context.DiasParametrizablesCats.Where(x => x.IdDiaParametrizable == id).SingleOrDefault();
            if (_item == null)
                return false;
            try
            {
                _item.EstatusDiaParametrizable = false;
                repo.Update(_item);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar DiasParametrizables", ex);
                return false;
            }
        }

        public DiasParametrizablesCat RegistrobyId(int id)
        {
            var item = context.DiasParametrizablesCats.Where(x => x.IdDiaParametrizable == id).FirstOrDefault();

            if (item == null)
                return null;
            else
                return item;
        }

        public DiasParametrizablesCat ObtenerDiasParamPorDescripcion(String descDias)
        {
            var item = context.DiasParametrizablesCats.Where(x => x.Descripcion == descDias).FirstOrDefault();

            if (item == null)
                return null;
            else
                return item;
        }


    }
}
