using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.CargoXOrgano;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using LoggerUtility.LogUtility;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace CPMPlataformaDirigentes.Controller;


[Route("api/[controller]/")]
[ApiController]
public class CatalogoCargoXOrganoController : ControllerBase
{
    IAdministradorCargoXOrgano admin;
    LogMovimientos logMov;


    public CatalogoCargoXOrganoController()
    {

        admin = new AdministradorCargoXOrgano();
        logMov = new LogMovimientos();

    }
    [HttpGet]
    [Route("Consultar")]
    public List<CargoOrganoDescDom> Consultar()
    {
        Logger.Info("Consulta de CargoxOrgano");
        return admin.Obtener();
    }

    [HttpPost]
    [Route("Crear")]
    public Respuesta Crear(List<CargoOrganoDom> item)
    {
        logMov.logMovimientos(
         User.Identity.Name,
          User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
          SubModuloMov.Cargopororganodirigencial,
        Movimientos.alta,
        JsonSerializer.Serialize(item));

        return admin.Crear(item);
    }

    [HttpPost]
    [Route("RegistrobyId")]
    public CargoOrganoDom RegistrobyId([FromBody] int id)
    {
        return admin.RegistrobyId(id);
    }

    [HttpPost]
    [Route("Update")]
    public Respuesta Update(CargoOrganoDom item)
    {
        logMov.logMovimientos(
          User.Identity.Name,
          User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
     SubModuloMov.Cargopororganodirigencial,
     Movimientos.cambio,
     JsonSerializer.Serialize(item));


        return admin.Modificar(item);
    }

    [HttpPost]
    [Route("Delete")]
    public IActionResult Delete([FromBody] int id)
    {
        logMov.logMovimientos(
            User.Identity.Name,
            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
            SubModuloMov.Cargopororganodirigencial,
            Movimientos.baja,
            JsonSerializer.Serialize(id));


        admin.Desactivar(id);
        return Ok();
    }

    [HttpPost]
    [Route("GetOrgano")]
    public List<SelectDom> GetOrgano([FromBody] int id)
    {
        return admin.GetOrgano(id);
    }
    [HttpGet]
    [Route("GetCargo")]
    public List<SelectDom> GetCargo()
    {
        return admin.GetCargo();
    }
    [HttpGet]
    [Route("GetPlaza")]
    public List<SelectDom> GetPlaza()
    {
        return admin.GetPlaza();
    }
    [HttpGet]
    [Route("GetNivel")]
    public List<SelectDom> GetNivel()
    {
        return admin.GetNivel();
    }
    [HttpPost]
    [Route("GetUsuario")]
    public List<PersonaBuscar> GetUsuario(BuscarPersona bPersona)
    {

        return admin.GetUsuario(bPersona);
    }
}


