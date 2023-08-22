using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace cpm.plataformadirigentes.api.Controllers;

[Route("api/[controller]/")]

[ApiController]
public class ConvocatoriasController : ControllerBase
{
    LogMovimientos logMov;
    IAdministradorConvocatoria adminConvoca;
    IAdministradorDetallePlantillaOrdenDia adminDetalle;

    public ConvocatoriasController()
    {
        logMov = new LogMovimientos();
        adminConvoca = new AdministradorConvocatoria();
        adminDetalle = new AdministradorDetallePlantillaOrdenDia();

    }

    [HttpGet]
    [Route("GetTipoJunta")]
    public List<SelectDom> GetTipoJunta()
    {
        IAdministradorTipoJunta adminJunta = new AdministradorTipoJunta();
        return adminJunta.ObtenerTiposJuntaActivo();
    }

    [HttpGet]
    [Route("GetModalidad")]
    public List<SelectDom> GetModalidad()
    {

        return adminConvoca.GetModalidad();
    }


    [HttpGet]
    [Route("GetComite")]
    public List<SelectDom> GetComite()
    {

        return adminConvoca.GetComitesPermisoConvocar(User.Identity.Name);

    }


    [HttpPost]
    [Route("ConsultarDetallePlantilla")]
    public List<DetallePlantillaOrdenDiaDom> ConsultarDetallePlantilla([FromBody] int idDetalle)
    {
        return adminDetalle.PlantillaPorIdTipoJunta(idDetalle);
    }

    [HttpPost]
    [Route("ObtenerIdPadrePlantilla")]
    public int ObtenerIdPadrePlantilla([FromBody] int idDetalle)
    {
        return adminDetalle.ObtenerIdPadrePorTipoJunta(idDetalle);
    }


    [HttpPost]
    [Route("GetCorreos")]
    public List<List<SelectCorreo>> GetCorreos([FromBody] int idOrgano)
    {

        List<List<SelectCorreo>> lsttadinal = new List<List<SelectCorreo>>
        {
            adminConvoca.GetAllCorreos(),
            adminConvoca.GetAsistentesNecesarios(idOrgano),
            adminConvoca.GetAsistentesConocimiento(idOrgano),
            adminConvoca.GetAsistentesOcultos(),
        };

        return lsttadinal;
    }

    [HttpPost]
    [Route("CrearConvocatoria")]
    public async Task<Respuesta> CrearConvocatoria(ConvocatoriaDom convoca)
    {
        logMov.logMovimientos(
       User.Identity.Name,
       User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
       SubModuloMov.Convocatoria,
       convoca.idConvocatoria == 0 ? Movimientos.alta : Movimientos.cambio,
       JsonSerializer.Serialize(convoca));

        convoca.Organizador = User.Identity.Name;
        return await adminConvoca.CrearConvocatoria(convoca);

    }

    [HttpGet]
    [Route("GetConvocatorias")]
    public List<CalendarioDom> GetConvocatorias()
    {

        return adminConvoca.GetConvocatorias(User.Identity.Name);

    }

    [HttpGet]
    [Route("HorariosConvocatoria")]
    public List<FechasConvocatorias> HorariosConvocatoria()
    {
        return adminConvoca.GetHorariosConvocatoria();

    }

    [HttpPost]
    [Route("LeerOrdenDia")]
    public List<RelMeetingOrdenDiumDom> LeerOrdenDia([FromBody] int id)
    {

        return adminConvoca.ObtenerOrdenDiaPorIdConvocatoria(id);
    }

    [HttpPost]
    [Route("GetConvocatoriaEdit")]
    public ConvocatoriaDom GetConvocatoriaEdit([FromBody] int idConvocatoria)
    {

        return adminConvoca.GetConvocatoriaEdit(idConvocatoria);
    }

    [HttpPost]
    [Route("AutorizarConvocatoria")]
    public Respuesta AutorizarConvocatoria([FromBody] int idConvocatoria)
    {
        logMov.logMovimientos(
        User.Identity.Name,
        User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
        SubModuloMov.Convocatoria,
        Movimientos.cambio,
        JsonSerializer.Serialize(idConvocatoria), "Autorizar");


        return adminConvoca.AutorizarConvocatoria(idConvocatoria, User.Identity.Name);

    }
    [HttpPost]
    [Route("CancelarConvocatoria")]
    public Respuesta CancelarConvocatoria([FromBody] int idConvocatoria)
    {
        logMov.logMovimientos(
       User.Identity.Name,
       User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
       SubModuloMov.Convocatoria,
       Movimientos.cambio,
       JsonSerializer.Serialize(idConvocatoria), "Cancelar");

        return adminConvoca.CancelarConvocatoria(idConvocatoria, User.Identity.Name);
    }
    [HttpPost]
    [Route("AprobarConvocatoria")]
    public Respuesta AprobarConvocatoria([FromBody] int idConvocatoria)
    {
        logMov.logMovimientos(
       User.Identity.Name,
       User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
       SubModuloMov.Convocatoria,
       Movimientos.cambio,
       JsonSerializer.Serialize(idConvocatoria), "Aprobar");

        return adminConvoca.AprobarConvocatoria(idConvocatoria, User.Identity.Name);
    }
    [HttpPost]
    [Route("GetEstatusConvocatoria")]
    public int GetEstatusConvocatoria([FromBody] int idConvocatoria)
    {
        return adminConvoca.GetEstatusConvocatoria(idConvocatoria);
    }
}


