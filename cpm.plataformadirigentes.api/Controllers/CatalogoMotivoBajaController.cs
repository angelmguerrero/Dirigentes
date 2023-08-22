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

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CatalogoMotivoBajaController : ControllerBase
    {
        IAdministradorMotivoBaja admin;
        LogMovimientos logMov;


        public CatalogoMotivoBajaController()
        {
            admin = new AdministradorMotivoBaja();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<MotivosBajaCat> Consultar()
        {
            Logger.Info("Consulta de MotivosBajaCat");
            return admin.Obtener();
        }
        [HttpGet]
        [Route("ConsultarSinMotivo")]
        public List<MotivosBajaCat> ConsultarSinMotivo()
        {
            Logger.Info("Consulta de MotivosBajaCat");
            return admin.ObtenerSinMotivo();
        }


        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(MotivosBajaCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                 User.Identity.Name,
                                 User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                 SubModuloMov.MotivoBaja,
                                 Movimientos.alta,
                                 JsonSerializer.Serialize(item));

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
        public MotivosBajaCat RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(MotivosBajaCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                                User.Identity.Name,
                                                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                                SubModuloMov.MotivoBaja,
                                                Movimientos.cambio,
                                                JsonSerializer.Serialize(item));
                return admin.Modificar(item);
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
                                             SubModuloMov.MotivoBaja,
                                             Movimientos.baja,
                                             JsonSerializer.Serialize(id));


            admin.Desactivar(id);
            return Ok();
        }

        [HttpGet]
        [Route("ConsultarMotivosDt")]
        public List<MotivosBajaCat> ConsultarMotivosDt()
        {
            Logger.Info("Consulta de MotivosBajaCat");
            return admin.ObtenerMotivosDt();
        }
    }
}