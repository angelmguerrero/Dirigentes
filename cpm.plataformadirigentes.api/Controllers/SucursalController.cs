using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Sucursal;
using Microsoft.AspNetCore.Mvc;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ILogger _logger;
        public SucursalController(ILogger<SucursalController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("ConsultarSucursales")]
        public List<SucursalesCat> ConsultarSucursales()
        {
            _logger.LogInformation("Consulta de Sucursales");
            IAdministradorSucursal adminSucursal = new AdministradorSucursal();
            return adminSucursal.ObtenerSucursales();
        }

        [HttpGet]
        [Route("ConsultarSucursalesbyIdPlaza")]
        public List<SucursalesCat> ConsultarSucursalesbyIdPlaza(int idPlaza)
        {
            _logger.LogInformation("Consulta de Sucursales");
            IAdministradorSucursal adminSucursal = new AdministradorSucursal();
            return adminSucursal.ObtenerSucursalesbyIdPlaza(idPlaza);
        }


        [HttpGet]
        [Route("ConsultarSucursalesDom")]
        public List<SucursalDom> ConsultarSucursalesDom()
        {
            _logger.LogInformation("Consulta de Sucursales Dom");
            IAdministradorSucursal adminSucursal = new AdministradorSucursal();
            return adminSucursal.ObtenerSucursalDom();
        }

    }
}
