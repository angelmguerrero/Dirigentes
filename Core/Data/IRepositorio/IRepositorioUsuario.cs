using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioUsuario
    {
        public List<Usuario> ObtenerUsuarios();
        public bool CrearUsuario(Usuario usuario);
        public bool ModificarUsuario(Usuario usuario);

        public bool DesactivarUsuario(int idUsuario);
        public Usuario UsuariobyId(int idUsuario);

        public List<UsuarioDom> ObtenerUsuariosPersona();
        public List<UsuarioPersonaPerfil> ObtenerUsuariosPersonaPerfil();
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCifPadron(int cifUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyNombrePadron(string NombreUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCuentaMex(string CuentaMexUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyId(int idUsuario);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCif(int cif);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCorreoAcceso(string correoAcceso);
        public bool CrearUsuarioPersonaPerfil(UsuarioPersonaPerfil usuarioPersonaPerfil);
        public int CrearUsuarioPersonaPerfilNew(UsuarioPersonaPerfil usuarioPersonaPerfil);
        public int ActualizarUsuarioPersonaPerfilNew(UsuarioPersonaPerfil usuarioPersonaPerfil);
        public int EliminarUsuarioPersonaPerfilNew(int idUsuario);
        public List<string> UsuarioPerfiles(string correoUsuario);

        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo(string correo);
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoPlaza(string correo);
        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilbyNombreApellidoPadron(PersonaNombre usuarioDirigente);

        //  public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCifPadron(int cifUsuario);
    }
}
