using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorEstadoCivil
    {
        public List<EstadoCivilCat> Obtener();
        public List<EstadoCivilCat> ObtenerActivo();
        public Respuesta Crear(EstadoCivilCat estadocivil);
        public Respuesta Modificar(EstadoCivilCat estadocivil);
        public bool Desactivar(int estadocivil);

        public EstadoCivilCat RegistrobyId(int idestadocivil);

        public EstadoCivilCat ObtenerEstadoCivilPorDescripcion(string descEstado);

    }
}
