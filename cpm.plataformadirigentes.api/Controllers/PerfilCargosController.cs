using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.Perfil;
using CPMPlataformaDirigentes.Models.Models;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace CPMPlataformaDirigentes.Controller
{

    [Route("api/[controller]/")]
    [ApiController]

    public class PerfilCargosController : ControllerBase
    {
        LogMovimientos logMov;
        private readonly ILogger _logger;
        public PerfilCargosController(ILogger<PerfilCargosController> logger)
        {
            _logger = logger;
            logMov = new LogMovimientos();
        }

        [HttpGet]
        [Route("ConsultarPerfilCargos")]
        public List<PerfilCargo> ConsultarPerfilCargos()
        {
            _logger.LogInformation("Consulta de PerfilCargos");
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            return adminPerfilCargo.ObtenerPerfilCargos();
        }

        [HttpGet]
        [Route("ConsultarPerfilCargosActivos")]
        public List<PerfilCargo> ConsultarPerfilCargosActivos()
        {
            _logger.LogInformation("Consulta de PerfilCargosActivos");
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            return adminPerfilCargo.ObtenerPerfilCargosActivos();
        }

        [HttpGet]
        [Route("ConsultarPerfilPermiso")]
        public List<PerfilPermiso> ConsultarPerfilPermiso()
        {
            _logger.LogInformation("Consulta de PerfilPermiso");
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            var test = adminPerfilCargo.ObtenerPerfilPermiso();
            return adminPerfilCargo.ObtenerPerfilPermiso();
        }

        [HttpGet]
        [Route("ConsultarPerfilPermisoIndex")]
        public List<PerfilPermisoIndex> ConsultarPerfilPermisoIndex()
        {
            _logger.LogInformation("Consulta de PerfilPermisoIndex");
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            var test = adminPerfilCargo.ObtenerPerfilPermisoIndex();
            return adminPerfilCargo.ObtenerPerfilPermisoIndex();
        }

        [HttpPost]
        [Route("ConsultarPermisobyCorreoAcceso")]
        public List<PerfilPermisoResumen> ConsultarPermisobyCorreoAcceso([FromBody] string correoAcceso)
        {
            _logger.LogInformation("Consulta de PermisobyCorreoAcceso");
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            return adminPerfilCargo.ObtenerPerfilPermisobyCorreoAcceso(correoAcceso);
        }

        [HttpPost]
        [Route("ConsultarPermisobyIdUsuario")]
        public List<PerfilPermiso> ConsultarPermisobyIdUsuario([FromBody] int idUsuario)
        {
            _logger.LogInformation("Consulta de PermisobyIdUsuario");
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            var test = adminPerfilCargo.ObtenerPerfilPermisobyIdUsuario(idUsuario);
            return adminPerfilCargo.ObtenerPerfilPermisobyIdUsuario(idUsuario);
        }

        [HttpPost]
        [Route("ConsultarPermisobyIdPerfil")]
        public List<PerfilPermiso> ConsultarPermisobyIdPerfil([FromBody] int idPerfil)
        {
            _logger.LogInformation("Consulta de PermisobyIdPerfil");
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            var test = adminPerfilCargo.ObtenerPerfilPermisobyIdPerfil(idPerfil);
            return adminPerfilCargo.ObtenerPerfilPermisobyIdPerfil(idPerfil);
        }

        [HttpGet]
        [Route("ConsultarPerfilPermisoSinPerfil")]
        public List<PerfilPermiso> ConsultarPerfilPermisoSinPerfil()
        {
            _logger.LogInformation("Consulta de PerfilPermiso SinPerfil");
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            var test = adminPerfilCargo.ObtenerPerfilPermisoSinPerfil();
            return adminPerfilCargo.ObtenerPerfilPermisoSinPerfil();
        }

        [HttpPost]
        [Route("CrearPerfilPermisoNew")]
        public IActionResult CrearPerfilPermisoNew(List<PerfilPermiso> PerfilPermiso)
        {
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                            User.Identity.Name,
                                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                            SubModuloMov.PerfilesyPermisos,
                Movimientos.alta,
                                            JsonSerializer.Serialize(PerfilPermiso));

                IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
                var crear = adminPerfilCargo.CrearPerfilPermisoNew(PerfilPermiso);
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("PerfilPermisobyId")]
        public List<PerfilPermiso> PerfilPermisobyId([FromBody] int idPerfilCargo)
        {
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            var test = adminPerfilCargo.PerfilPermisobyId(idPerfilCargo);
            return adminPerfilCargo.PerfilPermisobyId(idPerfilCargo);
        }

        //[HttpPost]
        //[Route("PerfilPermisobyNombre")]
        //public PerfilPermiso PerfilPermisobyNombre([FromBody] string nombre)
        //{
        //    IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
        //    var test = adminPerfilCargo.PerfilPermisobyNombre(nombre);
        //    return adminPerfilCargo.PerfilPermisobyNombre(nombre);
        //}

        [HttpPost]
        [Route("PerfilCargobyNombre")]
        public PerfilCargo PerfilCargobyNombre([FromBody] string nombre)
        {
            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            var test = adminPerfilCargo.PerfilCargobyNombre(nombre);
            return adminPerfilCargo.PerfilCargobyNombre(nombre);
        }

        [HttpPost]
        [Route("PerfilPermisoUpdate")]
        public IActionResult PerfilPermisoUpdate(List<PerfilPermiso> perfilpermiso)
        {
            logMov.logMovimientos(
                                            User.Identity.Name,
                                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                            SubModuloMov.PerfilesyPermisos,
                Movimientos.cambio,
                                            JsonSerializer.Serialize(perfilpermiso));

            IAdministradorPerfilCargo adminPerfilCargo = new AdministradorPerfilCargo();
            adminPerfilCargo.ModificarPerfilPermiso(perfilpermiso);
            return Ok();
        }



    }
}
