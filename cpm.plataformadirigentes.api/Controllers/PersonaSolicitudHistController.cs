using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPM.PlataformaDirigentes.Models.Models;
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
    public class PersonaSolicitudHistController : ControllerBase
    {
        LogMovimientos logMov;
        IAdministradorPersonaSolicitudHist admin;

        public PersonaSolicitudHistController()
        {

            admin = new AdministradorPersonaSolicitudHist();
            logMov = new LogMovimientos();
        }

        [HttpGet]
        [Route("ConsultarPersonaSolicitud")]
        public List<PersonaSolicitudHist> ConsultarPersonaSolicitud()
        {
            Logger.Info("Consulta de OrganoDirigencialCat");
            return admin.ObtenerPersonaSolicitudHist();
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(PersonaSolicitudHist persona)
        {


            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                            User.Identity.Name,
                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                            SubModuloMov.Padronsolicitudes,
                            Movimientos.alta,
                            JsonSerializer.Serialize(persona),
                            "PersonaSolicitudHist");

                var crear = admin.Crear(persona);
                return Ok();
            }
            else
                return BadRequest();

        }

        [HttpPost]
        [Route("RegistrobyId")]
        public PersonaSolicitudHist RegistrobyId([FromBody] int idPersonaSolicitudHist)
        {
            return admin.PersonaSolicitudHistbyId(idPersonaSolicitudHist);
        }
        [HttpPost]
        [Route("RegistrobyIdsolicitud")]
        public PersonaSolicitudHistorico RegistrobyIdsolicitud([FromBody] int idSolicitudHist)
        {
            return admin.PersonaSolicitudHistbyIdsolicitud(idSolicitudHist);
        }

        [HttpPost]
        [Route("CompararPersonaSolHistbyIdsolicitud")]
        public PersonaCatvsPersonaSoli CompararPersonaSolHistbyIdsolicitud([FromBody] int idSolicitudHist)
        {
            return admin.CompararPersonaSolicitudHistbyIdsolicitud(idSolicitudHist);
        }

        [HttpPost]
        [Route("ModificarPersonaSolicitudHist")]
        public IActionResult ModificarPersonaSolicitudHist(PersonaSolicitudHist persona)
        {

            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                          User.Identity.Name,
                          User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                          SubModuloMov.Padronsolicitudes,
                          Movimientos.cambio,
                          JsonSerializer.Serialize(persona),
                          "PersonaSolicitudHist");
                admin.ModificarPersonaSolicitudHist(persona);
                return Ok();
            }
            else
                return BadRequest();

        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] int idPersonaSolicitudHist)
        {

            if (ModelState.IsValid)
                logMov.logMovimientos(
                         User.Identity.Name,
                         User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                         SubModuloMov.Padronsolicitudes,
                         Movimientos.baja,
                         JsonSerializer.Serialize(idPersonaSolicitudHist),
                         "PersonaSolicitudHist");
            admin.DesactivarPersonaSolicitudHist(idPersonaSolicitudHist);
            return Ok();
        }



    }
}
