using CPM.PlataformaDirigentes.Helpers;
using CPMPlataformaDirigentes.Models.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
//using Microsoft.Extensions.PlatformAbstractions;

namespace CPMPlataformaDirigentes.Controller
{
    [Route("api/[controller]/")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        //private readonly ILogger _logger;

        //public EmailController(ILogger<EmailController> logger)
        //{
        //    _logger = logger;

        //}


        private readonly IHostingEnvironment _hostingEnvironment;

        public EmailController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("EnviarEmailPlantilla")]
        public IActionResult EnviarEmailPlantilla(LogGeneral logGeneral)
        {
            // application's base path
            ///string contentRootPath = "";
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            if (ModelState.IsValid)
            {
                // var lstNotificados = Data.NotificadoData.CargarNotificadosConsulta();
                List<string> lTo = new List<string>();
                //foreach (var item in lstNotificados)
                //{
                lTo.Add("francisco_Camarena_externo@cpm.coop");
                //}

                string bodyText = Constantes.CONST_EMAIL_BODY_TEXT_DEPOSITO_ARCHIVO_CONCILIACION_CFE_OK;
                //string bodyText = Constantes.CONST_EMAIL_BODY_TEXT_DEPOSITO_ARCHIVO_CONCILIACION_CFE_OK.Replace("[[[nombrearchivo]]]", nombreArchivo).Replace("[[[fechaencabezado]]]", fechaEncabezado).Replace("[[[registros]]]", totalRegistros).Replace("[[[monto]]]", montoTotalRegistros).Replace("[[[fecha]]]", DateTime.Now.ToString()).Replace("[[[telefonoCpm]]]", telefonoCpm).Replace("[[[correoCpm]]]", correoCpm);

                string bodyMailImagenAdjunta = ObtenerEmailTemplateFormulariosImagenAdjunta(bodyText);

                string path = Path.Combine(contentRootPath);

                List<List<string>> Att = new List<List<string>>();
                //Att.Add(new List<string> { "logo", Server.MapPath("~/Content/images/CpmImage.png") });
                //Att.Add(new List<string> { "bookmark", Server.MapPath("~/Content/images/PieCorreo.jpg") });
                Att.Add(new List<string> { "logo", Path.Combine(contentRootPath, "wwwroot", "CpmImage.png") });
                Att.Add(new List<string> { "bookmark", Path.Combine(contentRootPath, "wwwroot", "PieCorreo.jpg") });

                EnviarEmail email = new EnviarEmail();
                email.EnviarCorreoSolicitudNotificacionImagenAdjunta(lTo, "Archivo de conciliación CFE. Depósito de archivo ", true, bodyMailImagenAdjunta, "", Att);
                //email.EnviarCorreoSolicitudNotificacionImagenAdjunta(lTo, "Archivo de conciliación CFE. Depósito de archivo " + nombreArchivo, true, bodyMailImagenAdjunta, (archivoAnexo == string.Empty ? "" : archivoAnexo), Att);

                // Mail.EnviarEmailImagenAdjunta(lTo, "Archivo de conciliación CFE. Depósito de archivo " + nombreArchivo, true, bodyMailImagenAdjunta, (archivoAnexo == string.Empty ? "" : archivoAnexo), Att);

                //   IAdministradorUsuario adminUsuario = new AdministradorUsuario();
                //  var crear = adminUsuario.CrearUsuarioPersonaPerfil(usuarioPersonaPerfil);
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("ObtenerEmailTemplateFormulariosImagenAdjunta")]
        public string ObtenerEmailTemplateFormulariosImagenAdjunta(string body = "")
        {
            // application's base path

            string contentRootPath = _hostingEnvironment.ContentRootPath;

            string template = Constantes.CONST_EMAIL_TEMPLATE_FORMULARIO;
            string path = Path.Combine(contentRootPath, "wwwroot", "emailTemplateFormulario.html");

            //string path = Path.Combine(contentRootPath, template);
            string content = string.Empty;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.UTF8))
            {
                content = sr.ReadToEnd();
            }

            string scheme = Url.ActionContext.HttpContext.Request.Scheme;
            //   @Request.Url.Scheme://@Request.Url.Authority@Url.Content("~/Scripts/lib/bootstrap/dist/css/bootstrap.css")
            string logoImage = Url.ActionContext.HttpContext.Request.Scheme + "://" + Url.ActionContext.HttpContext.Request.Host + "/wwwroot/CpmImage.png";
            content = content.Replace("[[[myVarLogoImage]]]", "cid:logo");

            string logoImagePie = Url.ActionContext.HttpContext.Request.Scheme + "://" + Url.ActionContext.HttpContext.Request.Host + "/wwwroot/PieCorreo.jpg";
            content = content.Replace("[[[myVarLogoImagePie]]]", "cid:bookmark");

            content = (body != "") ? content.Replace("[[[varBodyMessage]]]", body) : content;
            return content;

        }



    }
}
