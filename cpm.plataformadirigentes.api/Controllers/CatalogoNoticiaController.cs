using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CatalogoNoticiaController : ControllerBase
    {
        IAdministradorNoticia admin;
        LogMovimientos logMov;


        public CatalogoNoticiaController()
        {

            admin = new AdministradorNoticia();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<NoticiaCat> Consultar()
        {
            Logger.Info("Consulta de Noticia");
            return admin.Obtener();
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(NoticiaCat item)
        {
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                             User.Identity.Name,
                             User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                             SubModuloMov.Noticias,
                             Movimientos.alta,
                             JsonSerializer.Serialize(item));

                var crear = admin.Crear(item);
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPost]
        [Route("RegistrobyId")]
        public NoticiaCat RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(NoticiaCat item)
        {
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                            User.Identity.Name,
                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                            SubModuloMov.Noticias,
                            Movimientos.cambio,
                            JsonSerializer.Serialize(item));

                admin.Modificar(item);
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] int id)
        {
            logMov.logMovimientos(
                       User.Identity.Name,
                       User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                       SubModuloMov.Noticias,
                       Movimientos.baja,
                       JsonSerializer.Serialize(id));

            admin.Desactivar(id);
            return Ok();
        }
    }
}
