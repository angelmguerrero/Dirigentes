using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.OrganoDirigencial;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace CPMPlataformaDirigentes.Controller;

[Route("api/[controller]/")]
[ApiController]
public class CatalogoOrganoDirigencialController : ControllerBase
{
    IAdministradorOrganoDirigencial admin;
    LogMovimientos logMov;


    public CatalogoOrganoDirigencialController()
    {

        admin = new AdministradorOrganoDirigencial();
        logMov = new LogMovimientos();

    }
    [HttpGet]
    [Route("Consultar")]
    public List<OrganoDirigencialDom> Consultar()
    {
        Logger.Info("Consulta de OrganoDirigencialCat");
        return admin.Obtener();
    }

    [HttpPost]
    [Route("Crear")]
    public Respuesta Crear(OrganoCat item)
    {
        Respuesta resp = new Respuesta();
        if (ModelState.IsValid)
        {
            logMov.logMovimientos(
                                            User.Identity.Name,
                                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                            SubModuloMov.OrganosDirigenciales,
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
    public OrganoCat RegistrobyId([FromBody] int id)
    {
        return admin.RegistrobyId(id);
    }

    [HttpPost]
    [Route("Update")]
    public Respuesta Update(OrganoCat item)
    {
        Respuesta resp = new Respuesta();
        if (ModelState.IsValid)
        {
            logMov.logMovimientos(
                                     User.Identity.Name,
                                     User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                     SubModuloMov.OrganosDirigenciales,
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
                                    SubModuloMov.OrganosDirigenciales,
                                    Movimientos.baja,
                                    JsonSerializer.Serialize(id));

        admin.Desactivar(id);
        return Ok();
    }

    [HttpGet]
    [Route("ConsultarMateriales")]
    public List<SelectDom> ConsultarMateriales()
    {

        return admin.ObtenerMateriales();
    }


    [HttpGet]
    [Route("ConsultarNivelGestion")]
    public List<SelectDom> ConsultarNivelGestion()
    {

        return admin.ObtenerNivelGestion();
    }


}

