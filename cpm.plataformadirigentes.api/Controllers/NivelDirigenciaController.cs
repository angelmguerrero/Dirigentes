using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace cpm.plataformadirigentes.api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class NivelDirigenciaController : ControllerBase
    {
        IAdministradorNivelDirigencial admin;
        LogMovimientos logMov;
        public NivelDirigenciaController()
        {

            admin = new AdministradorNivelDirigencial();
            logMov = new LogMovimientos();

        }

        [HttpGet]
        [Route("Consultar")]
        public List<NivelDirigencial> Consultar()
        {
            Logger.Info("Consulta Nivel Dirigencial");
            return admin.Obtener();
        }
        [HttpGet]
        [Route("ConsultarActivas")]
        public List<NivelDirigencial> ConsultarActivas()
        {
            Logger.Info("Consulta de Nivel dirigencial IngresoCatActivas");
            return admin.ObtenerActivas();
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(NivelDirigencial item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {

                logMov.logMovimientos(
                            User.Identity.Name,
                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                            SubModuloMov.PadronInicial,
                            Movimientos.alta,
                            JsonSerializer.Serialize(item),
                            "NivelDirigencial");

                return admin.Crear(item);

            }
            else
            {
                resp.Resultado = false;
                return resp;
            }
        }

        [HttpPost]
        [Route("RegistrobyId")]
        public NivelDirigencial RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("RegistrobyIdPersona")]
        public NivelDirigencial RegistrobyIdPersona([FromBody] int idPersona)
        {
            return admin.RegistrobyIdPersona(idPersona);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(NivelDirigencial item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                            User.Identity.Name,
                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                            SubModuloMov.PadronInicial,
                            Movimientos.cambio,
                            JsonSerializer.Serialize(item),
                            "NivelDirigencial");

                return admin.Modificar(item);
            }
            else
            {
                resp.Resultado = false;
                return resp;
            }
        }

        [HttpPost]
        [Route("CrearOModificar")]
        public Respuesta CrearOModificar(NivelDirigencial item)
        {

            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                           User.Identity.Name,
                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                           SubModuloMov.PadronInicial,
                           Movimientos.cambio,
                           JsonSerializer.Serialize(item),
                           "NivelDirigencial");

                return admin.CrearOModificar(item);
            }
            else
            {
                resp.Resultado = false;
                return resp;
            }
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] int id)
        {
            logMov.logMovimientos(
                           User.Identity.Name,
                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                           SubModuloMov.PadronInicial,
                           Movimientos.baja,
                           JsonSerializer.Serialize(id),
                           "NivelDirigencial");

            admin.Desactivar(id);
            return Ok();
        }
    }
}
