using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using LogMovimientoSistema;
using Microsoft.AspNetCore.Mvc;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CatalogoTipoPersonaController : ControllerBase
    {
        IAdministradorTipoPersona adminTipoPersona;
        LogMovimientos logMov;

        public CatalogoTipoPersonaController()
        {
            adminTipoPersona = new AdministradorTipoPersona();
            logMov = new LogMovimientos();

        }

        [HttpGet]
        [Route("Consultar")]
        public List<TipoPersonaCat> Consultar()
        {
            Logger.Info("Consulta de Tipo Persona");
            return adminTipoPersona.ObtenerTipoPersona();
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(TipoPersonaCat tipopersona)
        {
            if (ModelState.IsValid)
            {
                //logMov.logMovimientos(
                //                User.Identity.Name,
                //                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                //                SubModuloMov.,
                //                Movimientos.alta,
                //                JsonSerializer.Serialize(tipopersona));

                adminTipoPersona.CrearTipoPersona(tipopersona);
                return Ok();
            }
            else return BadRequest();


        }

        [HttpPost]
        [Route("RegistrobyId")]
        public TipoPersonaCat RegistrobyId([FromBody] int idtipopersona)
        {
            return adminTipoPersona.TipoPersonabyId(idtipopersona);

        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(TipoPersonaCat tipopersona)
        {
            //logMov.logMovimientos(
            //                    User.Identity.Name,
            //                    User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            //                    SubModuloMov.,
            //                    Movimientos.alta,
            //                    JsonSerializer.Serialize(tipopersona));

            adminTipoPersona.ModificarTipoPersona(tipopersona);
            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] int idTipopersona)
        {
            //logMov.logMovimientos(
            //                    User.Identity.Name,
            //                    User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            //                    SubModuloMov.,
            //                    Movimientos.alta,
            //                    JsonSerializer.Serialize(tipopersona));


            adminTipoPersona.DesactivarTipoPersona(idTipopersona);

            return Ok();
        }




    }
}
