using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioEstadoCivil
    {
        public List<EstadoCivilCat> Obtener();
        public Respuesta Crear(EstadoCivilCat estadocivil);
        public Respuesta Modificar(EstadoCivilCat estadocivil);

        public bool Desactivar(int estadocivil);

        public EstadoCivilCat RegistrobyId(int idestadocivil);

        public EstadoCivilCat ObtenerEstadoCivilPorDescripcion(string descEstado);
        public List<EstadoCivilCat> ObtenerActivo();
    }
}
