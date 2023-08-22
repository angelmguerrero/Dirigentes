using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using LogMovimientoSistema;
using Microsoft.AspNetCore.Mvc;

namespace cpm.plataformadirigentes.api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class NivelDirigencialCatController : ControllerBase
    {
        IAdministradorNivelDirigencialCat admin;
        LogMovimientos logMov;


        public NivelDirigencialCatController()
        {
            admin = new AdministradorNivelDirigencialCat();
            logMov = new LogMovimientos();

        }

        [HttpGet]
        [Route("Consultar")]
        public List<NivelDirigencialCat> Consultar()
        {
            Logger.Info("Consulta Nivel Dirigencial Cat");
            return admin.Obtener();
        }
        [HttpGet]
        [Route("ConsultarActivas")]
        public List<NivelDirigencialCat> ConsultarActivas()
        {
            Logger.Info("Consulta de Nivel dirigencialCat IngresoCatActivas");
            return admin.ObtenerActivas();
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(NivelDirigencialCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {

                //logMov.logMovimientos(
                //            User.Identity.Name,
                //            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                //            SubModuloMov.Condicionesdeingreso,
                //            Movimientos.alta,
                //            JsonSerializer.Serialize(item));
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
        public NivelDirigencialCat RegistrobyId([FromBody] int id)
        {
            return admin.RegistrobyId(id);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(NivelDirigencialCat item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                //logMov.logMovimientos(
                //                         User.Identity.Name,
                //                         User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                //                         SubModuloMov.Condicionesdeingreso,
                //                         Movimientos.cambio,
                //                         JsonSerializer.Serialize(item));

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
            //logMov.logMovimientos(
            //                             User.Identity.Name,
            //                             User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            //                             SubModuloMov.Condicionesdeingreso,
            //                             Movimientos.cambio,
            //                             JsonSerializer.Serialize(id));

            admin.Desactivar(id);
            return Ok();
        }
    }
}
