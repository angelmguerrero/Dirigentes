using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorPersonalAdministrativo
    {
        public List<PersonalAdministrativoCat> Obtener();
        public Respuesta Crear(PersonalAdministrativoCat item);
        public Respuesta Modificar(PersonalAdministrativoCat item);
        public bool Desactivar(int id);
        public PersonalAdministrativoCat RegistrobyId(int id);

        public PersonalAdministrativoCat ObtenerPersonaPorNombre(string nombre);
        public PersonalAdministrativoCat ObtenerPersonaPorCorreo(string correo);
    }
}
