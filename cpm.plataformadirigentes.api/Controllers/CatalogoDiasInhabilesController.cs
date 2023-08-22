using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.DiaInhabil;
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

public class CatalogoDiasInhabilesController : ControllerBase
{

    IAdministradorDiasInhabiles admin;
    LogMovimientos logMov;


    public CatalogoDiasInhabilesController()
    {
        admin = new AdministradorDiasInhabiles();
        logMov = new LogMovimientos();

    }
    [HttpGet]
    [Route("Consultar")]
    public List<DiasInhabilesCat> Consultar()
    {
        Logger.Info("Consulta de Dias Inhabiles");
        return admin.Obtener();
    }

    [HttpPost]
    [Route("Crear")]
    public Respuesta Crear(DiasInhabilesCat item)
    {
        Respuesta resp = new Respuesta();
        if (ModelState.IsValid)
        {
            logMov.logMovimientos(
                                User.Identity.Name,
                                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                SubModuloMov.Diasinhabiles,
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
    public DiasInhabilesCat RegistrobyId([FromBody] int id)
    {
        return admin.RegistrobyId(id);
    }

    [HttpPost]
    [Route("Update")]
    public Respuesta Update(DiasInhabilesCat item)
    {
        Respuesta resp = new Respuesta();
        if (ModelState.IsValid)
        {
            logMov.logMovimientos(
                                        User.Identity.Name,
                                        User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                        SubModuloMov.Diasinhabiles,
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
                                      SubModuloMov.Diasinhabiles,
                                      Movimientos.baja,
                                      JsonSerializer.Serialize(id));

        admin.Desactivar(id);
        return Ok();
    }

    [HttpGet]
    [Route("GetSabado")]
    public int GetSabado()
    {
        return admin.GetSabado();
    }

    [HttpGet]
    [Route("GetDomingo")]
    public int GetDomingo()
    {
        return admin.GetDomingo();
    }

    [HttpPost]
    [Route("UpdateSabado")]
    public IActionResult UpdateSabado([FromBody] bool status)
    {
        logMov.logMovimientos(
                              User.Identity.Name,
                              User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                              SubModuloMov.Diasinhabiles,
                              Movimientos.cambio,
                              JsonSerializer.Serialize(status));


        admin.UpdateSabado(status);
        return Ok();
    }

    [HttpPost]
    [Route("UpdateDomingo")]
    public IActionResult UpdateDomingo([FromBody] bool status)
    {
        logMov.logMovimientos(
                          User.Identity.Name,
                          User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                          SubModuloMov.Diasinhabiles,
                          Movimientos.cambio,
                          JsonSerializer.Serialize(status));

        admin.UpdateDomingo(status);
        return Ok();
    }

    [HttpPost]
    [Route("BuscarFechas")]
    public List<DiasInhabilesCat> BuscarFechas(FiltroFechas filtro)
    {
        return admin.BuscarFechas(filtro);
    }

}

