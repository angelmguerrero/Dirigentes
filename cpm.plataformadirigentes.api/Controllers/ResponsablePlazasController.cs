using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.ResponsablePlaza;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ResponsablePlazasController : ControllerBase
    {
        LogMovimientos logMov;
        public ResponsablePlazasController()
        {
            logMov = new LogMovimientos();
        }
        //[HttpGet]
        //[Route("ConsultarResponsablePlazas")]
        //public List<Usuario> ConsultarResponsablePlazas()
        //{
        //    _logger.LogInformation("Consulta de ResponsablePlazas");
        //    IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
        //    return adminResponsablePlaza.ObtenerResponsablePlazas();
        //}

        [HttpGet]
        [Route("ConsultarResponsablePlazasPersona")]
        public List<ResponsablePlazaPersona> ConsultarResponsablePlazasPersona()
        {
            IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
            var test = adminResponsablePlaza.ObtenerResponsablePlazaPersona();
            return adminResponsablePlaza.ObtenerResponsablePlazaPersona();
        }


        [HttpPost]
        [Route("CrearResponsablePlazaPersonaNew")]
        public Respuesta CrearResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                User.Identity.Name,
                                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                SubModuloMov.ResponsablePlaza,
                                Movimientos.alta,
                                JsonSerializer.Serialize(ResponsablePlazaPersona));

                IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
                var crear = adminResponsablePlaza.CrearResponsablePlazaPersonaNew(ResponsablePlazaPersona);
                return crear;
            }
            else
            {
                resp.Resultado = false;
                return resp;
            }

        }

        [HttpPost]
        [Route("ActualizarResponsablePlazaPersonaNew")]
        public Respuesta ActualizarResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {

                logMov.logMovimientos(
                                            User.Identity.Name,
                                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                            SubModuloMov.ResponsablePlaza,
                                            Movimientos.cambio,
                                            JsonSerializer.Serialize(ResponsablePlazaPersona));

                IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
                var crear = adminResponsablePlaza.ActualizarResponsablePlazaPersonaNew(ResponsablePlazaPersona);
                return crear;
            }
            else
            {
                resp.Resultado = false;
                return resp;
            }

        }

        [HttpPost]
        [Route("EliminarResponsablePlazaPersonaNew")]
        public IActionResult UsuarioDelete([FromBody] int idResponsablePlaza)
        {
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                           User.Identity.Name,
                                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                           SubModuloMov.Profesion,
                                           Movimientos.baja,
                                           JsonSerializer.Serialize(idResponsablePlaza));

                IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
                var crear = adminResponsablePlaza.EliminarResponsablePlazaPersonaNew(idResponsablePlaza);
                return Ok();
            }
            else return BadRequest();

        }


        [HttpGet]
        [Route("UsuarioPersonaPerfilPermisoSolicitudDirigencial")]
        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilPermisoSolicitudDirigencial()
        {
            IAdministradorResponsablePlaza adminUsuario = new AdministradorResponsablePlaza();
            var test = adminUsuario.UsuarioPersonaPerfilPermisoSolicitudDirigencial();
            return adminUsuario.UsuarioPersonaPerfilPermisoSolicitudDirigencial();
        }

        [HttpPost]
        [Route("ResponsablePlazaPersonabyId")]
        public ResponsablePlazaPersona ResponsablePlazaPersonabyId([FromBody] int idUsuario)
        {
            IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
            var test = adminResponsablePlaza.ResponsablePlazaPersonabyId(idUsuario);
            return adminResponsablePlaza.ResponsablePlazaPersonabyId(idUsuario);
        }

        [HttpPost]
        [Route("ResponsablePlazaPersonabyIdPersona")]
        public ResponsablePlazaPersona ResponsablePlazaPersonabyIdPersona([FromBody] int idPersona)
        {
            IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
            var test = adminResponsablePlaza.ResponsablePlazaPersonabyIdPersona(idPersona);
            return adminResponsablePlaza.ResponsablePlazaPersonabyIdPersona(idPersona);
        }
        [HttpPost]
        [Route("ResponsablePlazaPersonabyIdplaza")]
        public ResponsablePlazaPersona ResponsablePlazaPersonabyIdplaza([FromBody] int idplaza)
        {
            IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
            var test = adminResponsablePlaza.ResponsablePlazabyIdPlaza(idplaza);
            return adminResponsablePlaza.ResponsablePlazabyIdPlaza(idplaza);
        }

        [HttpGet]
        [Route("UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo")]
        public List<SelectDom> UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo()
        {
            IAdministradorResponsablePlaza adminUsuario = new AdministradorResponsablePlaza();
            //var test = adminUsuario.UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo();
            return adminUsuario.UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo();
        }



        //[HttpPost]
        //[Route("ResponsablePlazaPersonabyCif")]
        //public ResponsablePlazaPersona ResponsablePlazaPersonabyCif([FromBody] int cif)
        //{
        //    IAdministradorResponsablePlaza adminResponsablePlaza = new AdministradorResponsablePlaza();
        //    var test = adminResponsablePlaza.ResponsablePlazaPersonabyCif(cif);
        //    return adminResponsablePlaza.ResponsablePlazaPersonabyCif(cif);
        //}



    }
}
