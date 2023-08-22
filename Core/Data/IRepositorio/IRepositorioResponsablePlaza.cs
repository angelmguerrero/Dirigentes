using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.ResponsablePlaza;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioResponsablePlaza
    {

        public List<ResponsablePlazaPersona> ObtenerResponsablePlazaPersona();
        public ResponsablePlazaPersona ResponsablePlazaPersonabyId(int idResponsablePlaza);
        public ResponsablePlazaPersona ResponsablePlazaPersonabyIdPersona(int idPersona);
        public ResponsablePlazaPersona ResponsablePlazabyIdPlaza(int idPlaza);
        //   public ResponsablePlazaPersona ResponsablePlazaPersonabyCif(int cif);       
        public Respuesta CrearResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona);
        public Respuesta ActualizarResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona);
        public int EliminarResponsablePlazaPersonaNew(int idResponsablePlaza);
        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilPermisoSolicitudDirigencial();
        public ResponsablePlaza ObtenerResponsablePorPlaza(ResponsablePlazaPersona responsablePlaza);

        public List<SelectDom> UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo();

    }
}
