using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioNoticia : IRepositorioNoticia
    {

        private CPMDirigentesPlataformaContext context;
        public RepositorioNoticia()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }

        public List<NoticiaCat> ObtenerNoticias()
        {
            return context.NoticiaCats.ToList();
        }

        public bool CrearNoticia(NoticiaCat noticia)
        {
            try
            {
                context.NoticiaCats.Add(noticia);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarNoticia(NoticiaCat noticia)
        {
            var _noticia = context.NoticiaCats.Where(x => x.IdNoticia == noticia.IdNoticia).SingleOrDefault();
            if (_noticia == null)
                return false;

            _noticia.TituloNoticia = noticia.TituloNoticia;
            _noticia.ResumenNoticia = noticia.ResumenNoticia;
            _noticia.HipervinculoNoticia = noticia.HipervinculoNoticia;
            _noticia.NombreImagen = noticia.NombreImagen;
            _noticia.NombreImagenLimpio = noticia.NombreImagenLimpio;
            _noticia.EstatusNoticia = noticia.EstatusNoticia;
            context.SaveChanges();
            return true;
        }

        public bool DesactivarNoticia(int id)
        {
            var _Noticia = context.NoticiaCats.Where(x => x.IdNoticia == id).SingleOrDefault();
            if (_Noticia == null)
                return false;

            _Noticia.EstatusNoticia = false;
            context.SaveChanges();
            return true;
        }


        public NoticiaCat ObtenerNoticia(int idnoticia)
        {
            var noticia = context.NoticiaCats.Where(x => x.IdNoticia == idnoticia).FirstOrDefault();

            if (noticia == null)
                return null;
            else
                return noticia;
        }
    }


}
