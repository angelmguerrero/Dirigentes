using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorNoticia
    {
        public List<NoticiaCat> Obtener();
        public bool Crear(NoticiaCat noticia);
        public bool Modificar(NoticiaCat noticia);
        public bool Desactivar(int idnoticia);

        public NoticiaCat RegistrobyId(int idnoticia);
    }
}
