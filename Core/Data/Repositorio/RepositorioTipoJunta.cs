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
    public class RepositorioTipoJunta : IRepositorioTipoJunta
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<TipoJuntaCat> repo;
        public RepositorioTipoJunta()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<TipoJuntaCat>(context);
        }
        public List<TipoJuntaCat> Obtener()
        {
            return context.TipoJuntaCats.ToList();
        }
        public Respuesta Crear(TipoJuntaCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusTipoJunta = true;
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
                Logger.Error("Creacion TipoJunta", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public Respuesta Modificar(TipoJuntaCat item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.TipoJuntaCats.Where(x => x.IdTipoJunta == item.IdTipoJunta).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _item.Descripcion = item.Descripcion;
                _item.EstatusTipoJunta = item.EstatusTipoJunta;
                resp.Resultado = repo.Update(_item);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion TipoJunta", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public bool Desactivar(int id)
        {
            var _cargo = context.TipoJuntaCats.Where(x => x.IdTipoJunta == id).SingleOrDefault();
            if (_cargo == null)
                return false;
            try
            {
                _cargo.EstatusTipoJunta = false;
                return repo.Update(_cargo);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar TipoJunta", ex);
                return false;
            }
        }

        public TipoJuntaCat RegistrobyId(int id)
        {
            var cargo = context.TipoJuntaCats.Where(x => x.IdTipoJunta == id).FirstOrDefault();

            if (cargo == null)
                return null;
            else
                return cargo;

        }
        public TipoJuntaCat ObtenerTipoJuntaPorDescripcion(String descTipo)
        {
            var cargo = context.TipoJuntaCats.Where(x => x.Descripcion == descTipo).FirstOrDefault();

            if (cargo == null)
                return null;
            else
                return cargo;

        }

        public List<SelectDom> ObtenerTipoJuntaActivo()
        {
            try
            {
                var prueba = (from clas in context.TipoJuntaCats
                              where clas.EstatusTipoJunta == true
                              select new SelectDom
                              {
                                  value = clas.IdTipoJunta,
                                  text = clas.Descripcion

                              }).ToList();
                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta TipoJunta", ex);
                return null;
            }
        }


    }
}
