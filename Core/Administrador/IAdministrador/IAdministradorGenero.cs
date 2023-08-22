using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorGenero
    {
        public List<GeneroCat> Obtener();
        public Respuesta Crear(GeneroCat genero);
        public Respuesta Modificar(GeneroCat genero);
        public bool Desactivar(int genero);

        public GeneroCat RegistrobyId(int idgenero);

        public GeneroCat ObtenerGeneroPorDescripcion(string descGenero);
        public List<GeneroCat> Obteneractivo();
    }
}
