using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Plaza;
using Microsoft.AspNetCore.Mvc;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PlazaController : ControllerBase
    {
        private readonly ILogger _logger;
        public PlazaController(ILogger<PlazaController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("ConsultarPlazas")]
        public List<PlazaCat> ConsultarPlazas()
        {
            _logger.LogInformation("Consulta de Plazas");
            IAdministradorPlaza adminPlaza = new AdministradorPlaza();
            return adminPlaza.ObtenerPlazas();
        }

        [HttpPost]
        [Route("RegistrobyId")]
        public PlazaCat RegistrobyId([FromBody] int idPlaza)
        {
            IAdministradorPlaza adminPlaza = new AdministradorPlaza();
            var test = adminPlaza.PlazabyId(idPlaza);
            return adminPlaza.PlazabyId(idPlaza);
        }

        [HttpGet]
        [Route("ConsultarPlazasDom")]
        public List<PlazaDom> ConsultarPlazasDom()
        {
            _logger.LogInformation("Consulta de Plazas Dominio");
            IAdministradorPlaza adminPlaza = new AdministradorPlaza();
            return adminPlaza.ObtenerPlazaDom();
        }

        [HttpGet]
        [Route("ConsultarRegiones")]
        public List<SelectDom> ConsultarRegiones()
        {
            IAdministradorPlaza adminPlaza = new AdministradorPlaza();
            return adminPlaza.ObtenerRegiones();
        }



    }
}
