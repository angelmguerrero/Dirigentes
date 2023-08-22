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

    public class CatalogoEstadoCivilController : ControllerBase
    {

        IAdministradorEstadoCivil admin;
        LogMovimientos logMov;


        public CatalogoEstadoCivilController()
        {
            admin = new AdministradorEstadoCivil();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<EstadoCivilCat> Consultar()
        {
            Logger.Info("Consulta de Estado Civil");
            return admin.Obtener();
        }
        [HttpGet]
        [Route("ConsultarActivo")]
        public List<EstadoCivilCat> ConsultarActivo()
        {
            Logger.Info("Consulta de Estado Civil");
            return admin.ObtenerActivo();
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(EstadoCivilCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                                   User.Identity.Name,
                                                    User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                            SubModuloMov.Estadocivil,
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
        public EstadoCivilCat RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(EstadoCivilCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                                   User.Identity.Name,
                                                    User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                            SubModuloMov.Estadocivil,
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
                            SubModuloMov.Estadocivil,
                            Movimientos.baja,
                            JsonSerializer.Serialize(id));

            admin.Desactivar(id);
            return Ok();
        }
    }
}
