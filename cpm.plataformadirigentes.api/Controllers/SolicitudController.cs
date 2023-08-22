using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud;
using CPMPlataformaDirigentes.Models.Models;
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
    public class SolicitudController : ControllerBase
    {
        LogMovimientos logMov;

        public SolicitudController()
        {

            logMov = new LogMovimientos();

        }




        [HttpGet]
        [Route("ConsultarSolicitudes")]
        public List<Solicitud> ConsultarSolicitudes()
        {
            Logger.Info("Consulta de ConsultarSolicitudes");
            IAdministradorSolicitud adminSolicitud = new AdministradorSolicitud();
            return adminSolicitud.ObtenerSolicitud();

        }

        [HttpGet]
        [Route("ConsultarSolicitudesresponsable")]
        public List<SolicitudPersonaResponsable> ConsultarSolicitudesresponsable()
        {
            Logger.Info("Consulta de ConsultarSolicitudesresponsable");
            IAdministradorSolicitud adminSolicitud = new AdministradorSolicitud();
            return adminSolicitud.ObtenerSolicitudPersonaResponsable();

        }

        [HttpPut]
        [Route("ConsultarSolicitudesbyIdresponsable")]
        public List<SolicitudPersonaResponsable> ConsultarSolicitudesbyIdresponsable([FromBody] int idPersonaresponsable)
        {
            Logger.Info("Consulta de ConsultarSolicitudesbyIdresponsable");
            IAdministradorSolicitud adminSolicitud = new AdministradorSolicitud();
            return adminSolicitud.ConsultarSolicitudesbyIdresponsable(idPersonaresponsable);

        }


        [HttpPost]
        [Route("SolicitudpersonaresponsablebyId")]
        public SolicitudPersonaResponsable SolicitudpersonaresponsablebyId([FromBody] int idSolicitud)
        {
            IAdministradorSolicitud adminSolicitud = new AdministradorSolicitud();
            return adminSolicitud.SolicitudpersonaResponsablebyId(idSolicitud);
        }


        [HttpPost]
        [Route("ModificarSolicitud")]
        public IActionResult ModificarSolicitud(Solicitud solicitud)
        {
            logMov.logMovimientos(
            User.Identity.Name,
            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            SubModuloMov.Padronsolicitudes,
            Movimientos.cambio,
            JsonSerializer.Serialize(solicitud));


            IAdministradorSolicitud adminSolicitud = new AdministradorSolicitud();
            adminSolicitud.ModificarSolicitud(solicitud);
            return Ok();
        }

        [HttpPost]
        [Route("Deletesolitud")]
        public IActionResult Deletesolitud([FromBody] int idsolicitud)
        {
            logMov.logMovimientos(
            User.Identity.Name,
            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            SubModuloMov.Padronsolicitudes,
            Movimientos.baja,
            JsonSerializer.Serialize(idsolicitud));

            IAdministradorSolicitud adminSolicitud = new AdministradorSolicitud();
            adminSolicitud.DesactivarSolicitud(idsolicitud);
            return Ok();
        }
        [HttpPost]
        [Route("SolicitudCrear")]
        public Solicitud PersonaCrear(Solicitud solicitud)
        {
            logMov.logMovimientos(
            User.Identity.Name,
            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            SubModuloMov.Padronsolicitudes,
            Movimientos.alta,
            JsonSerializer.Serialize(solicitud));

            IAdministradorSolicitud adminSolicitud = new AdministradorSolicitud();
            // var crear = adminSolicitud.CrearSolicitud(solicitud);
            return adminSolicitud.CrearSolicitud(solicitud);




        }
        [HttpPost]
        [Route("SolicitudpersonaResponsablebyCif")]
        public PersonaSolicitud SolicitudpersonaResponsablebyCif([FromBody] int cif)
        {
            IAdministradorSolicitud adminSolicitud = new AdministradorSolicitud();
            var test = adminSolicitud.SolicitudpersonaResponsablebyCif(cif);
            return adminSolicitud.SolicitudpersonaResponsablebyCif(cif);

        }



    }
}
