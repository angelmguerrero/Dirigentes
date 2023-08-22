using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPMPlataformaDirigentes.Models.ModelsConsulta;
using Microsoft.AspNetCore.Mvc;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class VwInfoSociosController : ControllerBase
    {
        //log
        private readonly ILogger _logger;
        public VwInfoSociosController(ILogger<VwInfoSociosController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("ConsultarVw_InfoSocios")]
        public List<VwInfoSocio> ConsultarCargos()
        {
            _logger.LogInformation("Consulta de VwInfoSocio");
            IAdministradorVwInfoSocios adminVwInfoSocios = new AdministradorVwInfoSocios();
            return adminVwInfoSocios.ObtnerVwInfoSocios();
        }

        [HttpPost]
        [Route("VwInfoSociosbyId")]
        public VwInfoSocio VwInfoSociobyId([FromBody] string cif)
        {

            IAdministradorVwInfoSocios adminVwInfoSocios = new AdministradorVwInfoSocios();
            var test = adminVwInfoSocios.VwInfoSociobyID(cif);
            return adminVwInfoSocios.VwInfoSociobyID(cif);

        }


    }
}
