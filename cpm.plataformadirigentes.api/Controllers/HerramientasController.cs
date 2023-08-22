using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerramientasController : ControllerBase
    {
        [HttpPost]
        [Route("MandarCorreo")]
        public IActionResult MandarCorreo(Email correo)
        {
            EnviarEmail email = new EnviarEmail();
            email.EnviarCorreo(correo);
            return Ok();
        }

        [HttpPost]
        [Route("MandarCorreoIp")]
        public IActionResult MandarCorreoIp(Email correo)
        {
            EnviarEmail email = new EnviarEmail();
            email.EnviarCorreoIp(correo);
            return Ok();
        }

        [HttpPost]
        [Route("AgregarDocumento")]
        public IActionResult AgregarDocumento([FromForm] IFormFileCollection file)
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
        public FileContentResult DescargarDocumento([FromBody] Archivo archivo)
        {
            byte[] fileBytes;
            fileBytes = AdminArchivos.Download("", archivo.Nombre, "D", archivo.Extension);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, archivo.Nombre);
        }

    }
}
