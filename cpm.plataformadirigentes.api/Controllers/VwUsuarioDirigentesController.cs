using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPMPlataformaDirigentes.Models.ModelsConsulta;
using Microsoft.AspNetCore.Mvc;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class VwUsuarioDirigentesController : ControllerBase
    {
        //log
        private readonly ILogger _logger;
        public VwUsuarioDirigentesController(ILogger<VwUsuarioDirigentesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("ConsultarVw_InfoSocios")]
        public List<VwUsuarioDirigente> ConsultarCargos()
        {
            _logger.LogInformation("Consulta de VwUsuarioDirigente");
            IAdministradorVwUsuarioDirigentes adminVwUsuarioDirigentes = new AdministradorVwUsuarioDirigentes();
            return adminVwUsuarioDirigentes.ObtnerVwUsuarioDirigentes();
        }

        [HttpPost]
        [Route("VwUsuarioDirigentesbyId")]
        public VwUsuarioDirigente VwUsuarioDirigentebyId([FromBody] string cif)
        {

            IAdministradorVwUsuarioDirigentes adminVwUsuarioDirigentes = new AdministradorVwUsuarioDirigentes();
            var test = adminVwUsuarioDirigentes.VwUsuarioDirigentebyID(cif);
            return adminVwUsuarioDirigentes.VwUsuarioDirigentebyID(cif);

        }

        [HttpPost]
        [Route("VwUsuarioDirigentebyCif")]
        public VwUsuarioDirigente VwUsuarioDirigentebyCif([FromBody] string cif)
        {

            IAdministradorVwUsuarioDirigentes adminVwUsuarioDirigentes = new AdministradorVwUsuarioDirigentes();
            var test = adminVwUsuarioDirigentes.VwUsuarioDirigentebyCif(cif);
            return adminVwUsuarioDirigentes.VwUsuarioDirigentebyCif(cif);

        }

        [HttpPost]
        [Route("VwUsuarioDirigentebyNombre")]
        public VwUsuarioDirigente VwUsuarioDirigentebyNombre([FromBody] string nombre)
        {

            IAdministradorVwUsuarioDirigentes adminVwUsuarioDirigentes = new AdministradorVwUsuarioDirigentes();
            var test = adminVwUsuarioDirigentes.VwUsuarioDirigentebyNombre(nombre);
            return adminVwUsuarioDirigentes.VwUsuarioDirigentebyNombre(nombre);

        }

        [HttpPost]
        [Route("VwUsuarioDirigentebyCuentaMexicana")]
        public VwUsuarioDirigente VwUsuarioDirigentebyCuentaMexicana([FromBody] string cuentaMexicana)
        {

            IAdministradorVwUsuarioDirigentes adminVwUsuarioDirigentes = new AdministradorVwUsuarioDirigentes();
            var test = adminVwUsuarioDirigentes.VwUsuarioDirigentebyCuentaMexicana(cuentaMexicana);
            return adminVwUsuarioDirigentes.VwUsuarioDirigentebyCuentaMexicana(cuentaMexicana);

        }


        [HttpPost]
        [Route("VwUsuarioDirigentebyNombreApellidos")]
        public List<VwUsuarioDirigente> VwUsuarioDirigentebyNombreApellidos([FromBody] VwUsuarioDirigente usuarioDirigente)
        {

            IAdministradorVwUsuarioDirigentes adminVwUsuarioDirigentes = new AdministradorVwUsuarioDirigentes();
            var test = adminVwUsuarioDirigentes.VwUsuarioDirigentebyNombreApellidos(usuarioDirigente);
            return adminVwUsuarioDirigentes.VwUsuarioDirigentebyNombreApellidos(usuarioDirigente);

        }

    }
}
