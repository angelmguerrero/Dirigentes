using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioNivelDirigencialCat : IRepositorioNivelDirigencialCat
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<NivelDirigencialCat> repo;

        public RepositorioNivelDirigencialCat()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<NivelDirigencialCat>(context);

        }
        public List<NivelDirigencialCat> Obtener()
        {
            return context.NivelDirigencialCats.ToList();
        }

        public List<NivelDirigencialCat> ObtenerActivas()
        {
            try
            {
                return context.NivelDirigencialCats.Where(x => x.Estatus == true).ToList();
            }
            catch (Exception ex)
            {
                Logger.Error("ObtenerActivas NivelDirigencialCat", ex);
                return null;
            }
        }

        public Respuesta Crear(NivelDirigencialCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.Estatus = true;
                context.NivelDirigencialCats.Add(item);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Crear NivelDirigencialCat", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool Desactivar(int id)
        {
            try
            {
                var _item = context.NivelDirigencialCats.Where(x => x.IdNivelDirigencialCat == id).SingleOrDefault();
                if (_item == null)
                    return false;

                _item.Estatus = false;
                return repo.Update(_item);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar NivelDirigencialCat", ex);
                return false;
            }
        }

        public Respuesta Modificar(NivelDirigencialCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                var _item = context.NivelDirigencialCats.Where(x => x.IdNivelDirigencialCat == item.IdNivelDirigencialCat).SingleOrDefault();
                if (_item == null)
                {
                    resp.Resultado = false;
                    resp.Mensaje = "No se encontro el registro";
                    return resp;
                }


                _item.Descripcion = item.Descripcion;
                _item.Estatus = item.Estatus;
                resp.Resultado = repo.Update(_item);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion NivelDirigencialCat", ex);
                resp.Resultado = false;
                return resp;
            }
        }



        public NivelDirigencialCat RegistrobyId(int id)
        {
            try
            {
                var item = context.NivelDirigencialCats.Where(x => x.IdNivelDirigencialCat == id).FirstOrDefault();

                if (item == null)
                    return null;
                else
                    return item;
            }
            catch (Exception ex)
            {
                Logger.Error("RegistrobyId NivelDirigencialCat", ex);
                return null;
            }
        }
    }
}
