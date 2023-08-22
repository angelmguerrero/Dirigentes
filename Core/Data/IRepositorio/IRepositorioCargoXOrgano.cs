using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.CargoXOrgano;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioCargoXOrgano
    {
        public List<CargoOrganoDescDom> Obtener();
        public Respuesta Crear(List<CargoOrganoDom> cargoxorgano);
        public Respuesta Modificar(CargoOrganoDom cargoxorgano);
        public bool Desactivar(int cargoxorgano);
        public CargoOrganoDom RegistrobyId(int id);
        public List<PersonaOrganoCargo> GetPersonaOrganoCargo();
    }
}
