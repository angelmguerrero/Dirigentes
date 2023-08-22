using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
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
    public class CatalogoEscolaridadController : ControllerBase
    {
        IAdministradorEscolaridad adminEscolaridad;
        LogMovimientos logMov;

        public CatalogoEscolaridadController()
        {
            adminEscolaridad = new AdministradorEscolaridad();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<EscolaridadCat> Consultar()
        {
            Logger.Info("Consulta de Escolaridades");
            return adminEscolaridad.ObtenerEscolaridades();
        }

        [HttpGet]
        [Route("ObtenerEscolaridadActivo")]
        public List<SelectDom> ObtenerEscolaridadActivo()
        {
            Logger.Info("Consulta de Escolaridades");
            return adminEscolaridad.ObtenerEscolaridadActivo();
        }


        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(EscolaridadCat escolaridad)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                      User.Identity.Name,
                                       User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                               SubModuloMov.Escolaridad,
                               Movimientos.alta,
                               JsonSerializer.Serialize(escolaridad));

                return adminEscolaridad.CrearEscolaridad(escolaridad);

            }
            else
            {
                resp.Resultado = false;
                return resp;

            }

        }

        [HttpPost]
        [Route("RegistrobyId")]
        public EscolaridadCat RegistrobyId([FromBody] int idEscolaridad)
        {
            return adminEscolaridad.ObtenerEscolaridad(idEscolaridad);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(EscolaridadCat escolaridad)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                     User.Identity.Name,
                                      User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                              SubModuloMov.Escolaridad,
                              Movimientos.cambio,
                              JsonSerializer.Serialize(escolaridad));

                return adminEscolaridad.ModificarEscolaridad(escolaridad);

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
                            SubModuloMov.Escolaridad,
                            Movimientos.cambio,
                            JsonSerializer.Serialize(id));


            adminEscolaridad.DesactivarEscolaridad(id);
            return Ok();
        }

    }

}