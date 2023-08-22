using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace CPM.PlataformaDirigentes.Helpers
{
    public class EnviarEmail
    {

        public EnviarEmail()
        {

        }

        public System.Net.Mail.Attachment CrearAttachmentEvento(DateTime inicio, DateTime fin, string titulo)
        {
            string lugar = Configuracion.GetCalendarAttachmentLugar();
            string nombre = Configuracion.GetCalendarAttachmentOrganizador();
            string email = Configuracion.GetCalendarAttachmentEmail();

            var e = new CalendarEvent
            {
                Start = new CalDateTime(inicio),
                End = new CalDateTime(fin),
            };

            var calendar = new Ical.Net.Calendar();
            e.Summary = titulo;
            e.Description = titulo;
            e.Location = lugar;
            Organizer Organizador = new Organizer();
            Organizador.CommonName = nombre;
            Organizador.Value = new Uri(email);
            e.Organizer = Organizador;

            calendar.Events.Add(e);

            var serializer = new CalendarSerializer();
            var serializedCalendar = serializer.SerializeToString(calendar);
            var bytescalendar = Encoding.UTF8.GetBytes(serializedCalendar);
            MemoryStream ms = new MemoryStream(bytescalendar);
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, "event.ics", "text/calendar");
            return attachment;
        }
        private readonly IHostingEnvironment _hostingEnvironment;

        public EnviarEmail(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public string EnviarCorreo(Email email)
        {
            string server = Configuracion.GetSMTPServer();
            string sender = Configuracion.GetSMTPSender();

            MailMessage message = new MailMessage();
            MailAddress From = new MailAddress(sender);
            message.From = From;
            //foreach (string address in email.addListTo)
            //{
            MailAddress to = new MailAddress(email.addListTo);
            message.To.Add(to);
            //}
            if (email.addCc != null)
            {
                //foreach (string address in email.addCc)
                //{
                MailAddress Cc = new MailAddress(email.addCc);
                message.CC.Add(Cc);
                //}
            }

            if (email.addCco != null)
            {
                //foreach (string address in email.addCco)
                //{
                MailAddress Cco = new MailAddress(email.addCco);
                message.To.Add(Cco);
                //}
            }
            message.Subject = email.Subject;
            message.IsBodyHtml = email.isBodyHTML;
            message.Body = email.Body;

            SmtpClient client = new SmtpClient();
            client.Host = server;

            client.Host = server;   // COMENTADO PARA PRUEBAS FJCG

            // COMENTAR ESTOS 2 DESPUES DE LAS PRUEBAS FJCG
            client.Host = "10.99.9.50";
            client.Port = 25;
            // COMENTAR ESTOS 2 DESPUES DE LAS PRUEBAS FJCG

            try
            {
                client.Send(message);
                return "";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public string EnviarCorreoIp(Email email)
        {
            string server = Configuracion.GetSMTPServer();
            string sender = Configuracion.GetSMTPSender();

            MailMessage message = new MailMessage();
            MailAddress From = new MailAddress(sender);
            message.From = From;
            //foreach (string address in email.addListTo)
            //{
            MailAddress to = new MailAddress(email.addListTo);
            message.To.Add(to);
            //}
            if (email.addCc != null)
            {
                //foreach (string address in email.addCc)
                //{
                MailAddress Cc = new MailAddress(email.addCc);
                message.CC.Add(Cc);
                //}
            }

            if (email.addCco != null)
            {
                //foreach (string address in email.addCco)
                //{
                MailAddress Cco = new MailAddress(email.addCco);
                message.To.Add(Cco);
                //}
            }
            message.Subject = email.Subject;
            message.IsBodyHtml = email.isBodyHTML;
            message.Body = email.Body;

            SmtpClient client = new SmtpClient();
            //client.Host = server;

            //client.Host = server;   // COMENTADO PARA PRUEBAS FJCG

            // COMENTAR ESTOS 2 DESPUES DE LAS PRUEBAS FJCG
            client.Host = "10.99.9.50";
            client.Port = 25;
            // COMENTAR ESTOS 2 DESPUES DE LAS PRUEBAS FJCG

            try
            {
                client.Send(message);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EnviarCorreoSolicitudNotificacion(List<string> addListTo, string Subject, bool isBodyHTML, string addCc, string addCco, string body)
        {

            string server = Configuracion.GetSMTPServer();
            string sender = Configuracion.GetSMTPSender();

            MailMessage message = new MailMessage();
            MailAddress From = new MailAddress(sender);
            message.From = From;
            foreach (string address in addListTo)
            {
                message.To.Add(address);
            }
            if (addCc != "")
            {
                message.CC.Add(addCc);
            }

            if (addCco != "")
            {
                message.To.Add(addCco);
            }
            message.Subject = Subject;
            message.IsBodyHtml = isBodyHTML;
            message.Body = body;

            SmtpClient client = new SmtpClient();
            client.Host = server;

            // COMENTAR ESTOS 2 DESPUES DE LAS PRUEBAS FJCG
            //client.Host = "10.99.9.50";
            // client.Port = 25;
            // COMENTAR ESTOS 2 DESPUES DE LAS PRUEBAS FJCG

            try
            {
                client.Send(message);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string EnviarCorreoSolicitudNotificacionImagenAdjunta(List<string> addListTo, string Subject, bool isBodyHTML, string body, string archivoAdjunto, List<List<string>> Att = null, List<string> addCc = null, List<string> addCco = null)
        {

            string server = Configuracion.GetSMTPServer();
            string sender = Configuracion.GetSMTPSender();

            MailMessage message = new MailMessage();
            MailAddress From = new MailAddress(sender);
            message.From = From;
            foreach (string address in addListTo)
            {
                message.To.Add(address);
            }
            if (addCc != null)
            {
                foreach (string address in addCc)
                {
                    MailAddress Cc = new MailAddress(address);
                    message.CC.Add(Cc);
                }
            }

            // Investigar cco
            if (addCco != null)
            {
                foreach (string address in addCco)
                {
                    MailAddress Cco = new MailAddress(address);
                    message.CC.Add(Cco);
                }
            }

            // Adjuntamiento de imagenes
            if (Att != null)
            {
                for (int i = 0; i < Att.Count(); i++)
                {
                    if (Att[i][0] != "")
                    {
                        System.Net.Mail.Attachment inlineLogo = new System.Net.Mail.Attachment(Att[i][1]);
                        message.Attachments.Add(inlineLogo);
                        string contentID = Att[i][0];
                        inlineLogo.ContentId = contentID;

                        //To make the image display as inline and not as attachment

                        inlineLogo.ContentDisposition.Inline = true;
                        inlineLogo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    }
                    else
                        message.Attachments.Add(new System.Net.Mail.Attachment(Att[i][1]));
                }
            }
            // Adjuntamiento de imagenes

            message.Subject = Subject;
            message.IsBodyHtml = isBodyHTML;
            message.Body = body;

            if (archivoAdjunto != string.Empty)
            {
                //FileInfo attachment = new FileInfo(archivoAdjunto);
                //Attachment data = new Attachment(attachment, MediaTypeNames.Application.Octet);
                // message.Attachments.Add(data);
                System.Net.Mail.Attachment data = new System.Net.Mail.Attachment(archivoAdjunto, MediaTypeNames.Application.Octet);
                message.Attachments.Add(data);
            }

            SmtpClient client = new SmtpClient();
            //client.Host = server;

            // COMENTAR ESTOS 2 DESPUES DE LAS PRUEBAS FJCG
            client.Host = "10.99.9.50";
            client.Port = 25;
            // COMENTAR ESTOS 2 DESPUES DE LAS PRUEBAS FJCG

            try
            {
                client.Send(message);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //public static string ObtenerEmailTemplateFormulariosImagenAdjunta(string body = "")
        //{
        //    // application's base path
        //  //  string contentRootPath = _hostingEnvironment.ContentRootPath;

        //    // application's publishing path
        //  //  string webRootPath = _hostingEnvironment.WebRootPath;

        //    string template = Constantes.CONST_EMAIL_TEMPLATE_FORMULARIO;
        //    var path2 = Path.Combine(_hostingEnvironment.ContentRootPath, "", "");
        //    string path = HttpContext.Current.Server.MapPath(template);
        //    string content = string.Empty;

        //    using (System.IO.StreamReader sr = new System.IO.StreamReader(path, Encoding.UTF8))
        //    {
        //        content = sr.ReadToEnd();
        //    }

        //    //   @Request.Url.Scheme://@Request.Url.Authority@Url.Content("~/Scripts/lib/bootstrap/dist/css/bootstrap.css")
        //    string logoImage = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/Content/images/CpmImage.png";
        //    content = content.Replace("[[[myVarLogoImage]]]", "cid:logo");

        //    string logoImagePie = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/Content/images/PieCorreo.jpg";
        //    content = content.Replace("[[[myVarLogoImagePie]]]", "cid:bookmark");

        //    content = (body != "") ? content.Replace("[[[varBodyMessage]]]", body) : content;
        //    return content;
        //}


    }
}
