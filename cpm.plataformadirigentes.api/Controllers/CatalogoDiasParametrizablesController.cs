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
    public class CatalogoDiasParametrizablesController : ControllerBase
    {
        LogMovimientos logMov;
        IAdministradorDiasParametrizables admin;

        public CatalogoDiasParametrizablesController()
        {
            admin = new AdministradorDiasParametrizables();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<DiasParametrizablesCat> Consultar()
        {
            Logger.Info("Consulta de Genero");
            return admin.Obtener();
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(DiasParametrizablesCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                    User.Identity.Name,
                     User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
             SubModuloMov.Diasparametrizables,
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
        public DiasParametrizablesCat RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(DiasParametrizablesCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                       User.Identity.Name,
                        User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                SubModuloMov.Diasparametrizables,
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
               SubModuloMov.Diasparametrizables,
               Movimientos.baja,
               JsonSerializer.Serialize(id));

            admin.Desactivar(id);
            return Ok();
        }
    }
}
