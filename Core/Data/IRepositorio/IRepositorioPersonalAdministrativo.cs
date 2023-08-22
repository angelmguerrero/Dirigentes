using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioPersonalAdministrativo
    {
        public List<PersonalAdministrativoCat> Obtener();
        public Respuesta Crear(PersonalAdministrativoCat item);
        public Respuesta Modificar(PersonalAdministrativoCat item);

        public bool Desactivar(int item);

        public PersonalAdministrativoCat RegistrobyId(int item);
        public PersonalAdministrativoCat ObtenerPersonalPorNombre(string nombre);
        public PersonalAdministrativoCat ObtenerPersonalPorCorreo(string correo);
    }
}
