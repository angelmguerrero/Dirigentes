using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.CargoXOrgano;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorCargoXOrgano
    {
        public List<CargoOrganoDescDom> Obtener();
        public Respuesta Crear(List<CargoOrganoDom> cargoxorgano);
        public Respuesta Modificar(CargoOrganoDom cargoxorgano);
        public bool Desactivar(int cargoxorgano);
        public CargoOrganoDom RegistrobyId(int idcargoxorgano);
        public List<SelectDom> GetOrgano(int idNivel);
        public List<SelectDom> GetCargo();
        public List<SelectDom> GetPlaza();
        public List<SelectDom> GetNivel();
        public List<PersonaBuscar> GetUsuario(BuscarPersona bPersona);

    }
}
