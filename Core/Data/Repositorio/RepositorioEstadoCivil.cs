using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioEstadoCivil : IRepositorioEstadoCivil
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<EstadoCivilCat> repo;
        public RepositorioEstadoCivil()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<EstadoCivilCat>(context);
        }
        public List<EstadoCivilCat> Obtener()
        {
            return context.EstadoCivilCats.ToList();
        }

        public List<EstadoCivilCat> ObtenerActivo()
        {
            var estadocivil = context.EstadoCivilCats.Where(x => x.EstatusEstadoCivil == true).ToList();

            return estadocivil;
        }
        public Respuesta Crear(EstadoCivilCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusEstadoCivil = true;
                context.EstadoCivilCats.Add(item);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion EstadoCivil", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta Modificar(EstadoCivilCat item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.EstadoCivilCats.Where(x => x.IdEstadoCivil == item.IdEstadoCivil).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _item.Descripcion = item.Descripcion;
                _item.EstatusEstadoCivil = item.EstatusEstadoCivil;
                resp.Resultado = repo.Update(_item);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion EstadoCivil", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool Desactivar(int id)
        {
            var _Item = context.EstadoCivilCats.Where(x => x.IdEstadoCivil == id).FirstOrDefault();
            if (_Item == null)
                return false;
            try
            {
                _Item.EstatusEstadoCivil = false;
                return repo.Update(_Item);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar EstadoCivil", ex);
                return false;
            }
        }

        public EstadoCivilCat RegistrobyId(int id)
        {
            var _item = context.EstadoCivilCats.Where(x => x.IdEstadoCivil == id).FirstOrDefault();

            if (_item == null)
                return null;
            else
                return _item;
        }

        public EstadoCivilCat ObtenerEstadoCivilPorDescripcion(String descEstado)
        {
            var estadocivil = context.EstadoCivilCats.Where(x => x.Descripcion == descEstado).FirstOrDefault();

            if (estadocivil == null)
                return null;
            else
                return estadocivil;
        }


    }
}
