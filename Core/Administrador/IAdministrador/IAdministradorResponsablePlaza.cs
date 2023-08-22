using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.ResponsablePlaza;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorResponsablePlaza
    {

        public List<ResponsablePlazaPersona> ObtenerResponsablePlazaPersona();
        public ResponsablePlazaPersona ResponsablePlazaPersonabyId(int idResponsablePlaza);
        public ResponsablePlazaPersona ResponsablePlazaPersonabyIdPersona(int idPersona);
        //   public ResponsablePlazaPersona ResponsablePlazaPersonabyCif(int cif);      
        //   public ResponsablePlazaPersona ResponsablePlazaPersonabyCif(int cif);      
        public ResponsablePlazaPersona ResponsablePlazabyIdPlaza(int idPlaza);
        public Respuesta CrearResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona);
        public Respuesta ActualizarResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona);
        public int EliminarResponsablePlazaPersonaNew(int idResponsablePlaza);
        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilPermisoSolicitudDirigencial();
        public ResponsablePlaza ObtenerResponsablePorPlaza(ResponsablePlazaPersona ResponsablePlazaPersona);
        public List<SelectDom> UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo();
    }
}
