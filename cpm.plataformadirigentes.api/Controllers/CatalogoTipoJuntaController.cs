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
    public class CatalogoTipoJuntaController : ControllerBase
    {
        IAdministradorTipoJunta admin;
        LogMovimientos logMov;


        public CatalogoTipoJuntaController()
        {

            admin = new AdministradorTipoJunta();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<TipoJuntaCat> Consultar()
        {
            Logger.Info("Consulta de TipoJuntaCat");
            return admin.Obtener();
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(TipoJuntaCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                 User.Identity.Name,
                                 User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                 SubModuloMov.TipoJunta,
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
        public TipoJuntaCat RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(TipoJuntaCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                User.Identity.Name,
                                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                SubModuloMov.TipoJunta,
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
                                SubModuloMov.TipoJunta,
                                Movimientos.cambio,
                                JsonSerializer.Serialize(id));

            admin.Desactivar(id);
            return Ok();
        }
    }
}
