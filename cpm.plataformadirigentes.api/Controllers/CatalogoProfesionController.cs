
using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
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
    
    public class CatalogoProfesionController : ControllerBase
    {
        IAdministradorProfesion adminProfesion;
        LogMovimientos logMov;


        public CatalogoProfesionController()
        {
            adminProfesion = new AdministradorProfesion();
            logMov = new LogMovimientos();

        }
        [HttpGet]
        [Route("Consultar")]
        public List<ProfesionClasifProfesion> Consultar()
        {
            Logger.Info("Consulta de Profesion");
            return adminProfesion.ObtenerProfesionesDt();
        }

        [HttpGet]
        [Route("ConsultarActivas")]
        public List<ProfesionCat> ConsultarActivas()
        {
            Logger.Info("Consulta de Profesion");
            return adminProfesion.ObtenerProfesionesActivas();
        }


        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(ProfesionCat profesion)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                User.Identity.Name,
                                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                SubModuloMov.Profesion,
                                Movimientos.alta,
                                JsonSerializer.Serialize(profesion));

                return adminProfesion.CrearProfesion(profesion);

            }
            else
            {
                resp.Resultado = false;
                return resp;
            }


        }

        [HttpPost]
        [Route("RegistrobyId")]
        public ProfesionCat RegistrobyId([FromBody] int idProfesion)
        {
            return adminProfesion.ObtenerProfesion(idProfesion);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(ProfesionCat profesion)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {

                logMov.logMovimientos(
                                            User.Identity.Name,
                                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                            SubModuloMov.Profesion,
                                            Movimientos.cambio,
                                            JsonSerializer.Serialize(profesion));

                return adminProfesion.ModificarProfesion(profesion);

            }
            else
            {
                resp.Resultado = false;
                return resp;
            }

        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] int idProfesion)
        {

            logMov.logMovimientos(
                                           User.Identity.Name,
                                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                           SubModuloMov.Profesion,
                                           Movimientos.baja,
                                           JsonSerializer.Serialize(idProfesion));


            adminProfesion.DesactivarProfesion(idProfesion);
            return Ok();
        }

        [HttpGet]
        [Route("ConsultarClasificaciones")]
        public List<SelectDom> ConsultarClasificaciones()
        {
            IAdministradorClasificacionProfesion adminClasifProfesion = new AdministradorClasificacionProfesion();
            return adminClasifProfesion.ObtenerClasificacionActivo();
        }

    }
}
