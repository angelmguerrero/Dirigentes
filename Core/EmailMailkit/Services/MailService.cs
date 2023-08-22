using EmailMailkit.Configuration;
using EmailMailkit.Models;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using LoggerUtility.LogUtility;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Utils;
using RazorEngineCore;
using System.Text;

namespace EmailMailkit.Services
{
    public class MailService : IMailService
    {
        // private CPMDirigentesPlataformaContext context;

        public MailService()
        {
            // this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());

        }

        public bool SendWithAttachments(MailDataWithAttachments mailData)
        {
            //string destinatario = "";
            //string copia = "";
            //string oculto = "";
            //string mensaje = "";

            try
            {
                // Initialize a new instance of the MimeKit.MimeMessage class
                var mail = new MimeMessage();
                var _settings = HelperConfig.GetConfig();

                #region Sender / Receiver
                // Sender
                mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
                mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

                // Receiver
                foreach (string mailAddress in mailData.To)
                {
                    mail.To.Add(MailboxAddress.Parse(mailAddress));
                    //destinatario += mailAddress + ';';
                }

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                        //copia += mailAddress + ';';

                    }
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                        //oculto += mailAddress + ";";
                    }
                }
                #endregion

                #region Content

                // Add Content to Mime Message
                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string templateDir = Path.Combine(baseDir, "wwwroot/");
                string templatePathLogo = Path.Combine(templateDir, $"CpmImage.png");
                string templatePathPie = Path.Combine(templateDir, $"PieCorreo.jpg");
                var imageLogo = body.LinkedResources.Add(templatePathLogo);
                var imagePie = body.LinkedResources.Add(templatePathPie);
                imageLogo.ContentId = MimeUtils.GenerateMessageId();
                imagePie.ContentId = MimeUtils.GenerateMessageId();
                mailData.Body = mailData.Body.Replace("IMAGENLOGO", imageLogo.ContentId);
                mailData.Body = mailData.Body.ToString().Replace("IMAGENPIE", imagePie.ContentId);


                // Check if we got any attachments and add the to the builder for our message
                if (mailData.Attachments != null)
                {
                    byte[] attachmentFileByteArray;
                    foreach (IFormFile attachment in mailData.Attachments)
                    {
                        if (attachment.Length > 0)
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                attachment.CopyTo(memoryStream);
                                attachmentFileByteArray = memoryStream.ToArray();
                            }
                            body.Attachments.Add(attachment.FileName, attachmentFileByteArray, ContentType.Parse(attachment.ContentType));
                        }
                    }
                }
                //mensaje = mailData.Body;
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion

                #region Send Mail
                SendMail(mail);
                return true;
                #endregion

            }
            catch (Exception ex)
            {
                Logger.Error("SendWithAttachments", ex);
                // LogEnvioCorreos(destinatario, mailData.Subject, copia, oculto, mensaje, false);
                return false;
            }
        }
        public bool Send(MailData mailData)
        {
            //string destinatario = "";
            //string copia = "";
            //string oculto = "";
            //string mensaje = "";

            try
            {
                var _settings = HelperConfig.GetConfig();

                // Initialize a new instance of the MimeKit.MimeMessage class
                var mail = new MimeMessage();

                #region Sender / Receiver
                // Sender
                mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
                mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

                // Receiver
                foreach (string mailAddress in mailData.To)
                {
                    mail.To.Add(MailboxAddress.Parse(mailAddress));
                    //destinatario += mailAddress + ';';

                }

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                        //copia += mailAddress + ';';

                    }
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                        //oculto += mailAddress + ';';

                    }
                }
                #endregion

                #region Content

                // Add Content to Mime Message
                mail.Subject = mailData.Subject;
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string templateDir = Path.Combine(baseDir, "wwwroot/");
                string templatePathLogo = Path.Combine(templateDir, $"CpmImage.png");
                string templatePathPie = Path.Combine(templateDir, $"PieCorreo.jpg");

                var imageLogo = GetFileImage(templatePathLogo);
                var imagePie = GetFileImage(templatePathPie);

                imageLogo.ContentId = MimeUtils.GenerateMessageId();
                imagePie.ContentId = MimeUtils.GenerateMessageId();
                mailData.Body = mailData.Body.Replace("IMAGENLOGO", imageLogo.ContentId);
                mailData.Body = mailData.Body.ToString().Replace("IMAGENPIE", imagePie.ContentId);

                //mensaje = mailData.Body;

                var mixed = new Multipart("mixed");
                mixed.Add(new TextPart("html")
                {
                    ContentTransferEncoding = ContentEncoding.QuotedPrintable,
                    Text = mailData.Body
                });

                mixed.Add(imageLogo);
                mixed.Add(imagePie);
                mail.Body = mixed;

                #endregion

                #region Send Mail
                SendMail(mail);
                //LogEnvioCorreos(destinatario, mailData.Subject, copia, oculto, mensaje, true);
                return true;
                #endregion

            }
            catch (Exception ex)
            {
                Logger.Error("Send", ex);

                //LogEnvioCorreos(destinatario, mailData.Subject,copia, oculto, mensaje, false);
                return false;
            }
        }
        public string CreateIcal(DateTime inicio, DateTime fin, string titulo, int id, bool cancelacion)
        {

            CalDateTime incioTZ = new CalDateTime(inicio, "America/Mexico_City");
            CalDateTime finTZ = new CalDateTime(fin, "America/Mexico_City");

            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            string lugar = config["CalendarAttachment:Lugar"];
            string nombre = config["CalendarAttachment:Organizador"];
            string email = config["CalendarAttachment:Email"];
            string productId = config["CalendarAttachment:ProductId"]; ;
            string defaultProductId = "-//github.com/rianjs/ical.net//NONSGML ical.net 4.0//EN";
            string status = "CONFIRMED";
            string method = "REQUEST";
            int sequence = 2;

            if (cancelacion)
            {
                status = "CANCELLED";
                method = "CANCEL";
                sequence = 2;
            }

            var e = new CalendarEvent
            {
                Start = incioTZ,
                End = finTZ,
                Uid = id + "@cpm.coop",
                Status = status,
                Sequence = sequence
            };

            var calendar = new Ical.Net.Calendar();
            //calendar.AddTimeZone(new VTimeZone("America/Mexico_City"));
            calendar.Method = method;
            e.Summary = titulo;
            e.Description = titulo;
            e.Location = lugar;
            Organizer Organizador = new Organizer();
            Organizador.CommonName = nombre;
            Organizador.Value = new Uri("mailto:" + email);
            e.Organizer = Organizador;

            calendar.Events.Add(e);

            var serializer = new CalendarSerializer();
            var serializedCalendar = serializer.SerializeToString(calendar).Replace(defaultProductId, productId); ;
            return serializedCalendar;
        }
        public bool SendCalendar(MailData mailData, DateTime inicio, DateTime fin, int idConvocatoria, bool cancelacion = true)
        {
            try
            {
                //string destinatario = "";
                //string copia = "";
                //string oculto = "";
                //string mensaje = "";

                var _settings = HelperConfig.GetConfig();
                var mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
                mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

                foreach (string mailAddress in mailData.To)
                {
                    mail.To.Add(MailboxAddress.Parse(mailAddress));
                    //destinatario += mailAddress + ';';
                }

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                        //copia += mailAddress + ';';

                    }
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                        //oculto += mailAddress + ';';

                    }
                }

                mail.Subject = mailData.Subject;

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string templateDir = Path.Combine(baseDir, "wwwroot/");
                string templatePathLogo = Path.Combine(templateDir, $"CpmImage.png");
                string templatePathPie = Path.Combine(templateDir, $"PieCorreo.jpg");

                var imageLogo = GetFileImage(templatePathLogo);
                var imagePie = GetFileImage(templatePathPie);

                imageLogo.ContentId = MimeUtils.GenerateMessageId();
                imagePie.ContentId = MimeUtils.GenerateMessageId();
                mailData.Body = mailData.Body.Replace("IMAGENLOGO", imageLogo.ContentId);
                mailData.Body = mailData.Body.ToString().Replace("IMAGENPIE", imagePie.ContentId);

                //mensaje = mailData.Body;

                var mixed = new Multipart("mixed");
                mixed.Add(new TextPart("html")
                {
                    ContentTransferEncoding = ContentEncoding.QuotedPrintable,
                    Text = mailData.Body
                });


                var ical = new TextPart("calendar")
                {
                    ContentTransferEncoding = ContentEncoding.Base64,
                    Text = CreateIcal(inicio, fin, mailData.Subject, idConvocatoria, cancelacion)
                };
                if (cancelacion)
                {
                    ical.ContentType.Parameters.Add("method", "CANCEL");
                }
                else
                {
                    ical.ContentType.Parameters.Add("method", "REQUEST");
                }

                mixed.Add(ical);
                mixed.Add(imageLogo);
                mixed.Add(imagePie);

                mail.Body = mixed;

                SendMail(mail);
                //LogEnvioCorreos(destinatario, mailData.Subject, copia, oculto, mensaje, true);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GetEmailTemplate<T>(string emailTemplate, T emailTemplateModel)
        {
            string mailTemplate = LoadTemplate(emailTemplate);

            try
            {
                IRazorEngine razorEngine = new RazorEngine();
                IRazorEngineCompiledTemplate modifiedMailTemplate = razorEngine.Compile(mailTemplate);

                return modifiedMailTemplate.Run(emailTemplateModel);
            }
            catch (Exception ex)
            {

                Logger.Error("GetEmailTemplate", ex);
                return "";
            }

        }
        public string GetEmailTemplate(string emailTemplate)
        {
            try
            {
                return LoadTemplate(emailTemplate);

            }
            catch (Exception ex)
            {
                Logger.Error("GetEmailTemplate", ex);
                return "";
            }
        }
        public string LoadTemplate(string emailTemplate)
        {

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string templateDir = Path.Combine(baseDir, "wwwroot/MailTemplates");
            string templatePath = Path.Combine(templateDir, $"{emailTemplate}.cshtml");

            using FileStream fileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);

            string mailTemplate = streamReader.ReadToEnd();
            streamReader.Close();

            return mailTemplate;
        }

        private bool SendMail(MimeMessage mail)
        {
            var _settings = HelperConfig.GetConfig();

            using var smtp = new SmtpClient();
            smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.None);
            smtp.AuthenticationMechanisms.Remove("XOAUTH2");

            smtp.Send(mail);
            smtp.Disconnect(true);
            return true;

        }
        private MimePart GetFileImage(string path)
        {

            var imageLogo = new MimePart("image", "png")
            {
                Content = new MimeContent(File.OpenRead(path), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Inline),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(path)
                
            };

            return imageLogo;

        }
        //private bool LogEnvioCorreos(string to, string asunto, string copia, string oculto, string mensaje, bool enviado)
        //{
        //    IGenericRepository<EnvioCorreo> repoEnvio = new GenericRepository<EnvioCorreo>(context);

        //    EnvioCorreo envio = new EnvioCorreo();

        //    envio.Destinatario = to;
        //    envio.Asunto = asunto;
        //    envio.Copia = copia;
        //    envio.Oculto = oculto;
        //    envio.Mensaje = mensaje;
        //    envio.Enviado = enviado;

        //    repoEnvio.Insert(envio);
        //    return true;


        //}
    }
}
