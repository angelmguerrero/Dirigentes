using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioGenero : IRepositorioGenero
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<GeneroCat> repo;
        public RepositorioGenero()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<GeneroCat>(context);
        }
        public List<GeneroCat> Obtener()
        {
            return context.GeneroCats.ToList();
        }
        public List<GeneroCat> Obteneractivo()
        {
            var genero = context.GeneroCats.Where(x => x.EstatusGenero == true).ToList();

            return genero;
        }
        public Respuesta Crear(GeneroCat genero)
        {
            Respuesta resp = new Respuesta();
            try
            {
                genero.EstatusGenero = true;
                context.GeneroCats.Add(genero);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion Genero", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta Modificar(GeneroCat genero)
        {
            Respuesta resp = new Respuesta();
            var _genero = context.GeneroCats.Where(x => x.IdGenero == genero.IdGenero).SingleOrDefault();
            if (_genero == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _genero.Descripcion = genero.Descripcion;
                _genero.EstatusGenero = genero.EstatusGenero;
                resp.Resultado = repo.Update(_genero);

                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion Genero", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool Desactivar(int id)
        {
            var _genero = context.GeneroCats.Where(x => x.IdGenero == id).SingleOrDefault();
            if (_genero == null)
                return false;
            try
            {
                _genero.EstatusGenero = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar Genero", ex);
                return false;
            }
        }

        public GeneroCat RegistrobyId(int idgenero)
        {
            var genero = context.GeneroCats.Where(x => x.IdGenero == idgenero).FirstOrDefault();

            if (genero == null)
                return null;
            else
                return genero;
        }

        public GeneroCat ObtenerGeneroPorDescripcion(String descGenero)
        {
            var genero = context.GeneroCats.Where(x => x.Descripcion == descGenero).FirstOrDefault();

            if (genero == null)
                return null;
            else
                return genero;
        }


    }
}
