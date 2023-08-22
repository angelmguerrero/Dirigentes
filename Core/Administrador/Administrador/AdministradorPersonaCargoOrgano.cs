using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorPersonaCargoOrgano : IAdministradorPersonaCargoOrgano
    {
        private IRepositorioPersonaCargoOrgano repoPersonaCargoOrgano;

        public AdministradorPersonaCargoOrgano()
        {
            this.repoPersonaCargoOrgano = new RepositorioPersonaCargoOrgano();
        }

        public List<PersonaCargoOrganos> ObtenerPersonaCargoOrgano()
        {
            return repoPersonaCargoOrgano.ObtenerPersonaCargoOrgano();
        }
        public List<PersonaCargoOrganoNivel> ObtenerPersonaCargoNivel()
        {
            return repoPersonaCargoOrgano.ObtenerPersonaCargoNivel();
        }
        public List<PersonaCargoOrganos> ObtenerPersona()
        {
            return repoPersonaCargoOrgano.ObtenerPersona();
        }
        public PersonaDescripcion PersonabyId(int idPersona)
        {
            return repoPersonaCargoOrgano.PersonabyId(idPersona);
        }
        public bool CrearPersona(PersonaCat persona)
        {
            return repoPersonaCargoOrgano.CrearPersona(persona);

        }

        public bool DesactivarPersona(int idPersona)
        {
            return repoPersonaCargoOrgano.DesactivarPersona(idPersona);
        }
        public bool ActivarDirigentePersona(int idPersona)
        {
            return repoPersonaCargoOrgano.ActivarDirigentePersona(idPersona);
        }
        public bool DesactivarPersonaxCargo(int idPersona, int idcargoOrgano)
        {
            return repoPersonaCargoOrgano.DesactivarPersonaxCargo(idPersona, idcargoOrgano);
        }
        public bool ModificarPersona(PersonaCat persona)
        {
            return repoPersonaCargoOrgano.ModificarPersona(persona);
        }

        public List<PersonaCargoOrganos> ObtenerPersonaCargoOrganobyid(int idPersona)
        {
            return repoPersonaCargoOrgano.ObtenerPersonaCargoOrganobyid(idPersona);
        }


        public bool DeletePersonaInsertarSolicitudBaja(PersonaTipoMotivoBaja personaTipoMotivoBaja)
        {
            return repoPersonaCargoOrgano.DeletePersonaInsertarSolicitudBaja(personaTipoMotivoBaja);
        }

    }
}
