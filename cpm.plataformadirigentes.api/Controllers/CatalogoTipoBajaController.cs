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
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoTipoBajaController : ControllerBase
    {
        IAdministradorTipoBaja admin;
        LogMovimientos logMov;


        public CatalogoTipoBajaController()
        {
            admin = new AdministradorTipoBaja();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<TipoBaja> Consultar()
        {
            Logger.Info("Consulta de TiposBaja");
            return admin.Obtener();
        }
        [HttpGet]
        [Route("ConsultarActivas")]
        public List<TipoBaja> ConsultarActivas()
        {
            Logger.Info("Consulta de TiposBaja Activas");
            return admin.ObtenerActivas();
        }


        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(TipoBaja item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                               User.Identity.Name,
                                               User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                               SubModuloMov.TipoBaja,
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
        public TipoBaja RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(TipoBaja item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                                  User.Identity.Name,
                                                  User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                                  SubModuloMov.TipoBaja,
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
                                      SubModuloMov.TipoBaja,
                                      Movimientos.baja,
                                      JsonSerializer.Serialize(id));

            admin.Desactivar(id);
            return Ok();
        }
    }
}
