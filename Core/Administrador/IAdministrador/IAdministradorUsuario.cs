using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorUsuario
    {
        public List<Usuario> ObtenerUsuarios();
        public bool CrearUsuario(Usuario Usuario);
        public bool ModificarUsuario(Usuario Usuario);
        public bool DesactivarUsuario(int idUsuario);
        public Usuario UsuariobyId(int idUsuario);

        public List<UsuarioDom> ObtenerUsuariosPersona();
        public List<UsuarioPersonaPerfil> ObtenerUsuariosPersonaPerfil();
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyId(int idUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCif(int cif);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCorreoAcceso(string correoAcceso);
        public bool CrearUsuarioPersonaPerfil(UsuarioPersonaPerfil UsuarioPersonaPerfil);
        public int CrearUsuarioPersonaPerfilNew(UsuarioPersonaPerfil UsuarioPersonaPerfil);
        public int ActualizarUsuarioPersonaPerfilNew(UsuarioPersonaPerfil UsuarioPersonaPerfil);
        public int EliminarUsuarioPersonaPerfilNew(int idUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCifPadron(int cifUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCuentaMex(string CuentaMexUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyNombre(string NombreUsuario);
        public List<string> UsuarioPerfiles(string correoUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo(string correo);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoPlaza(string correo);
        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilbyNombreApellidoPadron(PersonaNombre usuarioDirigente);

    }
}
