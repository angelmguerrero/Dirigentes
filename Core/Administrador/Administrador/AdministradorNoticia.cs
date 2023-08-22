using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorNoticia : IAdministradorNoticia
    {
        private IRepositorioNoticia repoNoticia;
        public AdministradorNoticia()
        {
            this.repoNoticia = new RepositorioNoticia();
        }
        public List<NoticiaCat> Obtener()
        {
            return repoNoticia.ObtenerNoticias();
        }
        public bool Crear(NoticiaCat noticia)
        {
            return repoNoticia.CrearNoticia(noticia);
        }
        public bool Modificar(NoticiaCat noticia)
        {
            return repoNoticia.ModificarNoticia(noticia);
        }

        public bool Desactivar(int idnoticia)
        {
            return repoNoticia.DesactivarNoticia(idnoticia);
        }

        public NoticiaCat RegistrobyId(int idnoticia)
        {
            return repoNoticia.ObtenerNoticia(idnoticia);
        }
    }
}
