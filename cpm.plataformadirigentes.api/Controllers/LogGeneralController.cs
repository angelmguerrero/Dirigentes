using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPMPlataformaDirigentes.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LogGeneralController : ControllerBase
    {
        private readonly ILogger _logger;
        public LogGeneralController(ILogger<LogGeneralController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("CrearLogGeneral")]
        public IActionResult CrearLogGeneral(LogGeneral logGeneral)
        {
            var correo = User.Identity.Name;
            string apellidos = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;
            string nombre = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;

            logGeneral.UsuarioCorreo = correo;
            logGeneral.UsuarioNombre = nombre + ' ' + apellidos;

            if (ModelState.IsValid)
            {
                IAdministradorLogGeneral adminLogGeneral = new AdministradorLogGeneral();
                var crear = adminLogGeneral.CrearLogGeneral(logGeneral);
                return Ok();
            }
            else return BadRequest();


        }

    }
}
