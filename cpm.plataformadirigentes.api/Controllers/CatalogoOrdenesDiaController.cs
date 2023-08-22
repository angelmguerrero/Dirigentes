using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using Microsoft.AspNetCore.Mvc;


namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CatalogoOrdenesDiaController : ControllerBase
    {


        [HttpGet]
        [Route("ConsultarTiposJunta")]
        public List<SelectDom> ConsultarTiposJunta()
        {
            IAdministradorTipoJunta adminTipoJunta = new AdministradorTipoJunta();
            return adminTipoJunta.ObtenerTiposJuntaActivo();
        }
    }
}
