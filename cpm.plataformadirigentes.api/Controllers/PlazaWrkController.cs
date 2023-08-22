using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;
using Microsoft.AspNetCore.Mvc;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PlazaWrkController : ControllerBase
    {
        private readonly ILogger _logger;
        public PlazaWrkController(ILogger<PlazaWrkController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("ConsultarPlazas")]
        public List<PlazaWrk> ObtenerPlazaWrks()
        {
            _logger.LogInformation("Consulta de Plazas");
            IAdministradorPlazaWrk adminPlaza = new AdministradorPlazaWrk();
            return adminPlaza.ObtenerPlazaWrks();
        }

        [HttpGet]
        [Route("ConsultarPlazasActivo")]
        public List<SelectDom> ObtenerPlazaActivo()
        {
            _logger.LogInformation("Consulta de Plazas");
            IAdministradorPlazaWrk adminPlaza = new AdministradorPlazaWrk();
            return adminPlaza.ObtenerPlazaActivo();
        }

        //[HttpPost]
        //[Route("Crear")]
        //public IActionResult CrearPlazaWrk(PlazaWrk PlazaWrk)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IAdministradorPlazaWrk adminPlaza = new AdministradorPlazaWrk();
        //        var crear = adminPlaza.CrearPlazaWrk(PlazaWrk);
        //        return Ok();
        //    }
        //    else return BadRequest(ModelState);


        //} 

        //[HttpPost]
        //[Route("RegistrobyId")]
        //public PlazaWrk PlazaWrkbyId([FromBody] int idPlaza)
        //{
        //    IAdministradorPlazaWrk adminPlaza = new AdministradorPlazaWrk();
        //    var test = adminPlaza.PlazaWrkbyId(idPlaza);
        //    return adminPlaza.PlazaWrkbyId(idPlaza);
        //}

        //[HttpPost]
        //[Route("Update")]
        //public IActionResult ModificarPlazaWrk(PlazaWrk PlazaWrk)
        //{
        //    IAdministradorPlazaWrk adminPlaza = new AdministradorPlazaWrk();
        //    adminPlaza.ModificarPlaza(PlazaWrk);
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("PlazaDelete")]
        //public IActionResult DesactivarPlazaWrk([FromBody] int idPlaza)
        //{
        //    IAdministradorPlazaWrk adminPlaza = new AdministradorPlazaWrk();
        //    adminPlaza.DesactivarPlaza(idPlaza);
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("ConsultarPlazasDom")]
        //public List<PlazaDom> ConsultarPlazasDom()
        //{
        //    _logger.LogInformation("Consulta de Plazas Dominio");
        //    IAdministradorPlaza adminPlaza = new AdministradorPlaza();
        //    return adminPlaza.ObtenerPlazaDom();
        //}

        //[HttpGet]
        //[Route("ConsultarRegiones")]
        //public List<SelectDom> ConsultarRegiones()
        //{
        //    IAdministradorPlaza adminPlaza = new AdministradorPlaza();
        //    return adminPlaza.ObtenerRegiones();
        //}



    }
}
