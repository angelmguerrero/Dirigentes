using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using LoggerUtility.LogUtility;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PersonaPerfilCargoOrganoController : ControllerBase
    {

        LogMovimientos logMov;
        public PersonaPerfilCargoOrganoController()
        {
            logMov = new LogMovimientos();
        }





        [HttpGet]
        [Route("ConsultarPersonaCargoOrgano")]
        public List<PersonaCargoOrganos> ObtenerPersonaCargoOrgano()
        {
            Logger.Info("Consulta de PersonaCargoOrgano");
            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            return adminPersonaCargoOrgano.ObtenerPersonaCargoOrgano();

        }
        [HttpGet]
        [Route("ObtenerPersonaCargoNivel")]
        public List<PersonaCargoOrganoNivel> ObtenerPersonaCargoNivel()
        {
            Logger.Info("Consulta de Persona Cargo Organo Nivel");
            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            return adminPersonaCargoOrgano.ObtenerPersonaCargoNivel();

        }

        [HttpGet]
        [Route("ConsultarPersona")]
        public List<PersonaCargoOrganos> ObtenerPersona()
        {
            Logger.Info("Consulta de PersonaCargoOrgano");
            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            return adminPersonaCargoOrgano.ObtenerPersona();

        }

        [HttpPost]
        [Route("PersonabyId")]
        public PersonaDescripcion RegistrobyId([FromBody] int idPersona)
        {
            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            return adminPersonaCargoOrgano.PersonabyId(idPersona);

        }
        [HttpPost]
        [Route("PersonaCrear")]
        public IActionResult PersonaCrear(Models.Models.PersonaCat persona)
        {


            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                User.Identity.Name,
                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                SubModuloMov.PadronInicial,
                Movimientos.alta,
                JsonSerializer.Serialize(persona));

                IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
                var crear = adminPersonaCargoOrgano.CrearPersona(persona);
                return Ok();
            }
            else return BadRequest();


        }

        [HttpPost]
        [Route("PersonaUpdate")]
        public IActionResult PersonaUpdate(Models.Models.PersonaCat persona)
        {
            logMov.logMovimientos(
            User.Identity.Name,
            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            SubModuloMov.PadronInicial,
            Movimientos.cambio,
            JsonSerializer.Serialize(persona));

            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            adminPersonaCargoOrgano.ModificarPersona(persona);
            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] int idpersona)
        {
            logMov.logMovimientos(
            User.Identity.Name,
            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            SubModuloMov.PadronInicial,
            Movimientos.baja,
            JsonSerializer.Serialize(idpersona));

            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            adminPersonaCargoOrgano.DesactivarPersona(idpersona);
            return Ok();
        }

        [HttpPost]
        [Route("ActivaDirigente")]
        public IActionResult ActivaDirigente([FromBody] int idpersona)
        {
            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            adminPersonaCargoOrgano.ActivarDirigentePersona(idpersona);
            return Ok();
        }

        [HttpPost]
        [Route("DeletePersonaInsertarSolicitudBaja")]
        public IActionResult DeletePersonaInsertarSolicitudBaja([FromBody] PersonaTipoMotivoBaja personaTipoMotivoBaja)
        {
            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            adminPersonaCargoOrgano.DeletePersonaInsertarSolicitudBaja(personaTipoMotivoBaja);
            return Ok();
        }

        [HttpPost]
        [Route("DeletePersonaxCargo")]
        public IActionResult DeletePersonaxCargo([FromBody] int idpersona, int idcargoOrgano)
        {
            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            adminPersonaCargoOrgano.DesactivarPersonaxCargo(idpersona, idcargoOrgano);
            return Ok();
        }

        //[HttpPut]
        //[Route("ConsultarPersonaCargoOrganobyid")]
        //public List<PersonaCargoOrganos> ConsultarPersonaCargoOrganobyid(int idpersona)
        //{
        //    _logger.LogInformation("Consulta de PersonaCargoOrganobyId");
        //    IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
        //    return adminPersonaCargoOrgano.ObtenerPersonaCargoOrganobyid(idpersona);

        //}

        [HttpPut]
        [Route("ConsultarPersonaCargoOrganobyid")]

        public List<PersonaCargoOrganos> ConsultarPersonaCargoOrganobyid([FromBody] int idpersona)
        {
            Logger.Info("Consulta de PersonaCargoOrganobyId");
            IAdministradorPersonaCargoOrgano adminPersonaCargoOrgano = new AdministradorPersonaCargoOrgano();
            return adminPersonaCargoOrgano.ObtenerPersonaCargoOrganobyid(idpersona);

        }

    }
}
