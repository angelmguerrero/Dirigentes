using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPM.PlataformaDirigentes.Models.Models;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        LogMovimientos logMov;
        private readonly ILogger _logger;
        public UsuariosController(ILogger<UsuariosController> logger)
        {
            _logger = logger;
            logMov = new LogMovimientos();
        }
        [HttpGet]
        [Route("ConsultarUsuarios")]
        public List<Usuario> ConsultarUsuarios()
        {

            _logger.LogInformation("Consulta de Usuarios");
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.ObtenerUsuarios();
        }

        [HttpGet]
        [Route("ConsultarUsuariosPersonaPerfil")]
        public List<UsuarioPersonaPerfil> ConsultarUsuariosPersonaPerfil()
        {
            _logger.LogInformation("Consulta de Usuarios Persona Perfil");
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.ObtenerUsuariosPersonaPerfil();
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                IAdministradorUsuario adminUsuario = new AdministradorUsuario();
                var crear = adminUsuario.CrearUsuario(usuario);
                return Ok();
            }
            else return BadRequest();


        }

        [HttpPost]
        [Route("CrearUsuarioPersonaPerfil")]
        public IActionResult CrearUsuarioPersonaPerfil(UsuarioPersonaPerfil usuarioPersonaPerfil)
        {
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                           User.Identity.Name,
                                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                           SubModuloMov.Usuarios,
               Movimientos.alta,
                                           JsonSerializer.Serialize(usuarioPersonaPerfil));
                IAdministradorUsuario adminUsuario = new AdministradorUsuario();
                var crear = adminUsuario.CrearUsuarioPersonaPerfil(usuarioPersonaPerfil);
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("CrearUsuarioPersonaPerfilNew")]
        public IActionResult CrearUsuarioPersonaPerfilNew(UsuarioPersonaPerfil usuarioPersonaPerfil)
        {
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                           User.Identity.Name,
                                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                           SubModuloMov.Usuarios,
               Movimientos.alta,
                                           JsonSerializer.Serialize(usuarioPersonaPerfil));
                IAdministradorUsuario adminUsuario = new AdministradorUsuario();
                var crear = adminUsuario.CrearUsuarioPersonaPerfilNew(usuarioPersonaPerfil);
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("ActualizarUsuarioPersonaPerfilNew")]
        
        public IActionResult ActualizarUsuarioPersonaPerfilNew(UsuarioPersonaPerfil usuarioPersonaPerfil)
        {
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                           User.Identity.Name,
                                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                           SubModuloMov.Usuarios,
               Movimientos.cambio,
                                           JsonSerializer.Serialize(usuarioPersonaPerfil));
                IAdministradorUsuario adminUsuario = new AdministradorUsuario();
                var crear = adminUsuario.ActualizarUsuarioPersonaPerfilNew(usuarioPersonaPerfil);
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("EliminarUsuarioPersonaPerfilNew")]
        public IActionResult UsuarioDelete([FromBody] int idUsuario)
        {
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                           User.Identity.Name,
                                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                           SubModuloMov.Usuarios,
               Movimientos.baja,
                                           JsonSerializer.Serialize(idUsuario));
                IAdministradorUsuario adminUsuario = new AdministradorUsuario();
                var crear = adminUsuario.EliminarUsuarioPersonaPerfilNew(idUsuario);
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("UsuarioPersonaPerfilbyId")]
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyId([FromBody] int idUsuario)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilbyId(idUsuario);
        }

        [HttpPost]
        [Route("UsuarioPersonaPerfilbyCif")]
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCif([FromBody] int cif)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilbyCif(cif);
        }

        [HttpPost]
        [Route("UsuarioPersonaPerfilbyCorreoAcceso")]
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCorreoAcceso([FromBody] string correoAcceso)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilbyCorreoAcceso(correoAcceso);
        }

        [HttpPost]
        [Route("UsuariobyId")]
        public Usuario UsuariobyId([FromBody] int idUsuario)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuariobyId(idUsuario);
        }

        [HttpPost]
        [Route("UsuarioUpdate")]
        public IActionResult UsuarioUpdate(Usuario Usuario)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            adminUsuario.ModificarUsuario(Usuario);
            return Ok();
        }

        [HttpPost]
        [Route("UsuarioPersonaPerfilbyCifPadron")]
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCifPadron([FromBody] int cifUsuario)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilbyCifPadron(cifUsuario);
        }
        //[HttpPost]
        //[Route("UsuarioDelete")]
        //public IActionResult UsuarioDelete([FromBody] int idUsuario)
        //{
        //    IAdministradorUsuario adminUsuario = new AdministradorUsuario();
        //    adminUsuario.DesactivarUsuario(idUsuario);
        //    return Ok();
        //}
        [HttpPost]
        [Route("UsuarioPersonaPerfilbyCuentaMexicanaPadron")]
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyCuentaMexicanaPadron([FromBody] string cuentamexicana)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilbyCuentaMex(cuentamexicana);
        }

        [HttpPost]
        [Route("UsuarioPersonaPerfilbyNombrePadron")]
        public UsuarioPersonaPerfil UsuarioPersonaPerfilbyNombrePadron([FromBody] string NombreUsuario)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilbyNombre(NombreUsuario);
        }

        [HttpPost]
        [Route("UsuarioPersonaPerfilbyNombreApellidoPadron")]
        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilbyNombreApellidoPadron([FromBody] PersonaNombre usuarioDirigente)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilbyNombreApellidoPadron(usuarioDirigente);


        }



        [HttpPost]
        [Route("UsuarioPerfiles")]
        public List<string> UsuarioPerfiles([FromBody] string correoAcceso)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPerfiles(correoAcceso);
        }
        [HttpPost]
        [Route("UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo")]
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo([FromBody] string correo)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilPermisoSolicitudDirigencialbyCorreo(correo);
        }
        [HttpPost]
        [Route("UsuarioPersonaPerfilPermisoPlaza")]
        public UsuarioPersonaPerfil UsuarioPersonaPerfilPermisoPlaza([FromBody] string correo)
        {
            IAdministradorUsuario adminUsuario = new AdministradorUsuario();
            return adminUsuario.UsuarioPersonaPerfilPermisoPlaza(correo);
        }
    }
}
