using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorUsuario : IAdministradorUsuario
    {
        private IRepositorioUsuario repoUsuario;
        public AdministradorUsuario()
        {
            this.repoUsuario = new RepositorioUsuario();
        }
        public List<Usuario> ObtenerUsuarios()
        {
            return repoUsuario.ObtenerUsuarios();
        }

        public List<UsuarioDom> ObtenerUsuariosPersona()
        {
            return repoUsuario.ObtenerUsuariosPersona();
        }

        public List<UsuarioPersonaPerfil> ObtenerUsuariosPersonaPerfil()
        {
            return repoUsuario.ObtenerUsuariosPersonaPerfil();
        }

        public bool CrearUsuario(Usuario Usuario)
        {
            return repoUsuario.CrearUsuario(Usuario);
        }

        public bool CrearUsuarioPersonaPerfil(UsuarioPersonaPerfil UsuarioPersonaPerfil)
        {
            return repoUsuario.CrearUsuarioPersonaPerfil(UsuarioPersonaPerfil);
        }

        public int CrearUsuarioPersonaPerfilNew(UsuarioPersonaPerfil UsuarioPersonaPerfil)
        {
            return repoUsuario.CrearUsuarioPersonaPerfilNew(UsuarioPersonaPerfil);
        }

        public int ActualizarUsuarioPersonaPerfilNew(UsuarioPersonaPerfil UsuarioPersonaPerfil)
        {
            return repoUsuario.ActualizarUsuarioPersonaPerfilNew(UsuarioPersonaPerfil);
        }

        public int EliminarUsuarioPersonaPerfilNew(int idUsuario)
        {
            return repoUsuario.EliminarUsuarioPersonaPerfilNew(idUsuario);
        }

        public bool ModificarUsuario(Usuario Usuario)
        {
            return repoUsuario.ModificarUsuario(Usuario);
        }
        public bool DesactivarUsuario(int idUsuario)
        {
            return repoUsuario.DesactivarUsuario(idUsuario);
        }

        public Usuario UsuariobyId(int idUsuario)
        {
            return repoUsuario.UsuariobyId(idUsuario);
        }

        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyId(int idUsuario)
        {
            return repoUsuario.UsuarioPersonaPerfilbyId(idUsuario);
        }

        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCif(int cif)
        {
            return repoUsuario.UsuarioPersonaPerfilbyCif(cif);
        }

        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCorreoAcceso(string correoAcceso)
        {
            return repoUsuario.UsuarioPersonaPerfilbyCorreoAcceso(correoAcceso);
        }


        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCifPadron(int cifUsuario)
        {
            return repoUsuario.UsuarioPersonaPerfilbyCifPadron(cifUsuario);
        }
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCuentaMex(string CuentaMexUsuario)
        {
            return repoUsuario.UsuarioPersonaPerfilbyCuentaMex(CuentaMexUsuario);
        }

        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyNombre(string NombreUsuario)
        {
            return repoUsuario.UsuarioPersonaPerfilbyNombrePadron(NombreUsuario);
        }
        public List<string> UsuarioPerfiles(string correoUsuario)
        {
            return repoUsuario.UsuarioPerfiles(correoUsuario);
        }
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo(string correo)
        {
            return repoUsuario.UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo(correo);
        }
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoPlaza(string correo)
        {
            return repoUsuario.UsuarioPersonaPerfilPermisoPlaza(correo);
        }

        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilbyNombreApellidoPadron(PersonaNombre usuarioDirigente)
        {
            return repoUsuario.UsuarioPersonaPerfilbyNombreApellidoPadron(usuarioDirigente);
        }
    }
}
