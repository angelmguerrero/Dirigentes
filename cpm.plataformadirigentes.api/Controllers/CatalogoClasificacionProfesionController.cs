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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CatalogoClasificacionProfesionController : ControllerBase
    {
        IAdministradorClasificacionProfesion admin;
        LogMovimientos logMov;


        public CatalogoClasificacionProfesionController(ILogger<CatalogoClasificacionProfesionController> logger)
        {
            logMov = new LogMovimientos();
            admin = new AdministradorClasificacionProfesion();
        }

        [HttpGet]
        [Route("ConsultarProfesionesPorClasificacion")]
        public List<ProfesionesClasificacionProfesion> ConsultarProfesionesPorClasificacion()
        {
            Logger.Info("Consulta de Clasificacion por Profesion");
            return admin.ObtenerProfesionesClasificacionProfesion();
        }

        [HttpGet]
        [Route("Consultar")]
        public List<ClasificacionProfesion> Consultar()
        {
            Logger.Info("Consulta de Clasificacion por Profesion");
            return admin.ObtenerClasificacionesProfesion();
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(ClasificacionProfesion clasifProfesion)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
             User.Identity.Name,
             User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
             SubModuloMov.Clasificacionporprofesion,
             Movimientos.alta,
             JsonSerializer.Serialize(clasifProfesion));


                return admin.CrearClasificacionProfesion(clasifProfesion);

            }
            else
            {
                resp.Resultado = false;
                return resp;
            }

        }

        [HttpPost]
        [Route("RegistrobyId")]
        public ClasificacionProfesion RegistrobyId([FromBody] int idClasifProfesion)
        {
            IAdministradorClasificacionProfesion adminClasifProfesion = new AdministradorClasificacionProfesion();
            return adminClasifProfesion.ObtenerClasificacionProfesion(idClasifProfesion);
        }

        [HttpPost]
        [Route("Update")]
        public Respuesta Update(ClasificacionProfesion clasifProfesion)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
          User.Identity.Name,
          User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
          SubModuloMov.Clasificacionporprofesion,
          Movimientos.cambio,
          JsonSerializer.Serialize(clasifProfesion));

                return admin.ModificarClasificacionProfesion(clasifProfesion);
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
            IAdministradorClasificacionProfesion admin = new AdministradorClasificacionProfesion();

            logMov.logMovimientos(
            User.Identity.Name,
            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            SubModuloMov.Clasificacionporprofesion,
            Movimientos.baja,
            JsonSerializer.Serialize(id));

            admin.DesactivarClasificacionProfesion(id);
            return Ok();
        }

        [HttpPut]
        [Route("ObtenerClasificacionProfesionPorDescripcionbyid")]
        public List<ProfesionesClasificacionProfesion> ObtenerClasificacionProfesionPorDescripcionbyid([FromBody] int idprofesion)
        {
            IAdministradorClasificacionProfesion admin = new AdministradorClasificacionProfesion();
            return admin.ObtenerClasificacionProfesionPorDescripcionbyid(idprofesion);
        }
        [HttpGet]
        [Route("ObtenerClasificacionActivo")]
        public List<SelectDom> ObtenerClasificacionActivo()
        {
            Logger.Info("Consulta de Clasificacion por Profesion");
            return admin.ObtenerClasificacionActivo();
        }
    }
}
