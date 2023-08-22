using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoProfesionesController : ControllerBase
    {
        private readonly ILogger _logger;

        public CatalogoProfesionesController(ILogger<CatalogoProfesionesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("ConsultarProfesiones")]
        public List<ProfesionCat> ConsultarProfesiones()
        {
            _logger.LogInformation("Consulta de Profesiones");
            IAdministradorProfesion adminProfesion = new AdministradorProfesion();
            return adminProfesion.ObtenerProfesiones();
        }

    }
}
