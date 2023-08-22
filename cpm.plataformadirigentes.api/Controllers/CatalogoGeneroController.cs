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
    public class CatalogoGeneroController : ControllerBase
    {
        IAdministradorGenero admin;
        LogMovimientos logMov;



        public CatalogoGeneroController()
        {
            admin = new AdministradorGenero();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<GeneroCat> Consultar()
        {
            Logger.Info("Consulra de Genero");
            return admin.Obtener();
        }
        [HttpGet]
        [Route("ConsultarActivo")]
        public List<GeneroCat> ConsultarActivo()
        {
            Logger.Info("Consulra de Genero");
            return admin.Obteneractivo();
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(GeneroCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                 User.Identity.Name,
                                 User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                 SubModuloMov.Genero,
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
        public GeneroCat RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(GeneroCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                            User.Identity.Name,
                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                            SubModuloMov.Genero,
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
                  SubModuloMov.Genero,
                  Movimientos.baja,
                  JsonSerializer.Serialize(id));

            admin.Desactivar(id);
            return Ok();
        }
    }
}
