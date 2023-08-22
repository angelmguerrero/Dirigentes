using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioNoticia
    {

        public List<NoticiaCat> ObtenerNoticias();
        public bool CrearNoticia(NoticiaCat noticia);
        public bool ModificarNoticia(NoticiaCat noticia);

        public bool DesactivarNoticia(int idnoticia);

        public NoticiaCat ObtenerNoticia(int idnoticia);


    }
}
