using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CatalogoPlantillaOrdenDiaController : ControllerBase
    {
        IAdministradorPlantillaOrdenDia admin;
        IAdministradorDetallePlantillaOrdenDia adminDetalle;
        LogMovimientos logMov;

        public CatalogoPlantillaOrdenDiaController()
        {
            logMov = new LogMovimientos();
            admin = new AdministradorPlantillaOrdenDia();
            adminDetalle = new AdministradorDetallePlantillaOrdenDia();
        }

        [HttpGet]
        [Route("ConsultarTiposJunta")]
        public List<SelectDom> ConsultarTiposJunta()
        {
            IAdministradorTipoJunta adminTipoJunta = new AdministradorTipoJunta();
            return adminTipoJunta.ObtenerTiposJuntaActivo();
        }


        [HttpGet]
        [Route("Consultar")]
        public List<PlantillaOrdenDiaJunta> Consultar()
        {
            //Logger.Info("Consulta de Estatus Acuerdo");
            return admin.ObtenerPlantillaOrdenDiaDt();
        }

        [HttpPost]
        [Route("ConsultarEncabezado")]
        public PlantillaOrdenDia ConsultarEncabezado([FromBody] int idPlantilla)
        {
            return admin.RegistrobyId(idPlantilla);
        }

        [HttpPost]
        [Route("ConsultarDetalle")]
        public List<DetallePlantillaOrdenDiaDom> ConsultarDetalle([FromBody] int idDetalle)
        {
            return adminDetalle.RegistrobyId(idDetalle);
        }

        [HttpPost]
        [Route("Crear")]
        public Respuesta Crear(PlantillaOrdenDiaDetalles orden)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                User.Identity.Name,
                                User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                SubModuloMov.Ordendeldia,
                                Movimientos.alta,
                                JsonSerializer.Serialize(orden));

                return admin.Crear(orden);
            }
            else
            {
                resp.Resultado = false;
                return resp;
            }
        }



        [HttpPost]
        [Route("Update")]
        public Respuesta Update(PlantillaOrdenDiaDetalles item)
        {
            Respuesta resp = new Respuesta();
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                            User.Identity.Name,
                                            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                            SubModuloMov.Ordendeldia,
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
            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                                           User.Identity.Name,
                                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                                           SubModuloMov.Ordendeldia,
                                           Movimientos.baja,
                                           JsonSerializer.Serialize(id));

                admin.Desactivar(id);
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("DeleteDetalles")]
        public IActionResult DeleteDetalles(List<DetallePlantillaOrdenDiaDom> detalles)
        {
            adminDetalle.Desactivar(detalles);
            return Ok();
        }

        [HttpPost]
        [Route("ObtenerUltimoIdPadre")]
        public int ObtenerUltimoIdPadre([FromBody] int idDetalle)
        {
            return adminDetalle.ObtenerUltimoIdPadre(idDetalle);
        }

        [HttpPost]
        [Route("ValidarVacios")]
        public Respuesta ValidarVacios(List<DetallePlantillaOrdenDiaDom> detalles)
        {
            return adminDetalle.ValidarVacios(detalles);
        }

    }
}
