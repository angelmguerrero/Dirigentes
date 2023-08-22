using CPM.PlataformaDirigentes.Administrador.Administrador;
using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using LogMovimientoSistema;
using LogMovimientoSistema.Constantes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class DirigentesController : ControllerBase
    {
        LogMovimientos logMov;


        public DirigentesController()
        {
            logMov = new LogMovimientos();
        }

        [HttpGet]
        [Route("ObtenerDirigente")]
        public List<Dirigente> ObtenerDirigente()
        {
            Logger.Info("Consulta de ObtenerDirigente");
            IAdministradorDirigente administradorDirigente = new AdministradorDirigente();
            return administradorDirigente.ObtenerDirigente();
        }
        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(Dirigente dirigente)
        {


            if (ModelState.IsValid)
            {
                logMov.logMovimientos(
                          User.Identity.Name,
                          User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                          SubModuloMov.PadronInicial,
                          Movimientos.alta,
                          JsonSerializer.Serialize(dirigente),
                          "Dirigente");
                IAdministradorDirigente administradorDirigente = new AdministradorDirigente();
                var crear = administradorDirigente.CrearDirigente(dirigente);
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("AgregarDocumentos")]
        public IActionResult AgregarDocumentos([FromForm] IFormFileCollection file)
        {

            MemoryStream target = new MemoryStream();
            MemoryStream target1 = new MemoryStream();
            //HttpContext.Request.Form.Files[0].CopyTo(target);
            file[0].CopyTo(target);
            file[1].CopyTo(target1);
            var extension = Path.GetExtension(file[0].FileName);
            var nombre = Path.GetFileNameWithoutExtension(file[0].FileName);
            var extension2 = Path.GetExtension(file[1].FileName);
            var nombre2 = Path.GetFileNameWithoutExtension(file[1].FileName);
            //var nombreSinExtension = nombre.Substring(0, nombre.IndexOf("."));
            Thread ThreadErr = new Thread(() => AdminArchivos.CargarArchivo(target.ToArray(), nombre, "D", extension));
            Thread ThreadErr2 = new Thread(() => AdminArchivos.CargarArchivo(target1.ToArray(), nombre2, "D", extension2));
            ThreadErr.Start();
            ThreadErr2.Start();
            return Ok();
        }

        [HttpPost]
        [Route("AgregarDocumentoUpdate")]
        public IActionResult AgregarDocumentoUpdate([FromForm] IFormFileCollection file)
        {
            MemoryStream target = new MemoryStream();
            //HttpContext.Request.Form.Files[0].CopyTo(target);
            file[0].CopyTo(target);
            var extension = Path.GetExtension(file[0].FileName);
            var nombre = Path.GetFileNameWithoutExtension(file[0].FileName);
            //var nombreSinExtension = nombre.Substring(0, nombre.IndexOf("."));
            Thread ThreadErr = new Thread(() => AdminArchivos.CargarArchivo(target.ToArray(), nombre, "D", extension));
            ThreadErr.Start();

            return Ok();
        }




        [HttpPost]
        [Route("DescargarDocumento")]
        public FileContentResult DescargarDocumento([FromBody] CPM.PlataformaDirigentes.Models.ModeloDom.General.Archivo archivo)
        {
            byte[] fileBytes;
            fileBytes = AdminArchivos.Download("", archivo.Nombre, "D", archivo.Extension);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, archivo.Nombre);
        }



        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Dirigente dirigente)
        {

            logMov.logMovimientos(
                           User.Identity.Name,
                           User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                           SubModuloMov.PadronInicial,
                           Movimientos.cambio,
                           JsonSerializer.Serialize(dirigente),
                           "Dirigente");
            IAdministradorDirigente administradorDirigente = new AdministradorDirigente();
            administradorDirigente.ModificarDirigente(dirigente);
            return Ok();
        }

        [HttpPost]
        [Route("DesactivarDirigente")]
        public IActionResult DesactivarDirigente([FromBody] int idDirigente)
        {
            logMov.logMovimientos(
                          User.Identity.Name,
                          User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + ' ' + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                          SubModuloMov.PadronInicial,
                          Movimientos.baja,
                          JsonSerializer.Serialize(idDirigente),
                          "Dirigente");
            IAdministradorDirigente administradorDirigente = new AdministradorDirigente();
            administradorDirigente.DesactivarDirigente(idDirigente);
            return Ok();
        }

        [HttpPost]
        [Route("ObtenerDirigentebyId")]
        public Dirigente ObtenerDirigentebyId([FromBody] int idDirigente)
        {
            IAdministradorDirigente administradorDirigente = new AdministradorDirigente();
            return administradorDirigente.DirigentebyId(idDirigente);
        }
    }


}
