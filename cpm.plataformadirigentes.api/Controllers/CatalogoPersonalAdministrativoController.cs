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
    public class CatalogoPersonalAdministrativoController : ControllerBase
    {
        IAdministradorPersonalAdministrativo admin;
        LogMovimientos logMov;



        public CatalogoPersonalAdministrativoController()
        {
            admin = new AdministradorPersonalAdministrativo();
            logMov = new LogMovimientos();


        }
        [HttpGet]
        [Route("Consultar")]
        public List<PersonalAdministrativoCat> Consultar()
        {
            Logger.Info("Consulta de Personal Administrativo");
            return admin.Obtener();
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(PersonalAdministrativoCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                                 User.Identity.Name,
                                                 User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                                 SubModuloMov.Personaladministrativo,
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
        public PersonalAdministrativoCat RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(PersonalAdministrativoCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                       User.Identity.Name,
                                       User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                       SubModuloMov.Personaladministrativo,
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
                                   SubModuloMov.Personaladministrativo,
                                   Movimientos.baja,
                                   JsonSerializer.Serialize(id));

            admin.Desactivar(id);
            return Ok();
        }
    }
}
