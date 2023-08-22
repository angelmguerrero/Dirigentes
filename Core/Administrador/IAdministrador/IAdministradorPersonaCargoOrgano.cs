using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorPersonaCargoOrgano
    {
        public List<PersonaCargoOrganos> ObtenerPersonaCargoOrgano();
        public List<PersonaCargoOrganos> ObtenerPersona();
        public List<PersonaCargoOrganoNivel> ObtenerPersonaCargoNivel();
        public bool CrearPersona(PersonaCat persona);
        public bool ModificarPersona(PersonaCat persona);

        public bool DesactivarPersona(int idPersona);
        public bool ActivarDirigentePersona(int idPersona);
        public PersonaDescripcion PersonabyId(int idPersona);

        public List<PersonaCargoOrganos> ObtenerPersonaCargoOrganobyid(int idPersona);
        public bool DesactivarPersonaxCargo(int idPersona, int idcargoOrgano);

        public bool DeletePersonaInsertarSolicitudBaja(PersonaTipoMotivoBaja personaTipoMotivoBaja);


    }
}
