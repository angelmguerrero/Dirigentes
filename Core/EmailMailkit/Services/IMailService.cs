using EmailMailkit.Models;

namespace EmailMailkit.Services
{
    public interface IMailService
    {
        bool Send(MailData mailData);
        bool SendWithAttachments(MailDataWithAttachments mailData);
        bool SendCalendar(MailData mailData, DateTime inicio, DateTime fin, int idConvocatoria, bool cancelacion = false);
        string GetEmailTemplate(string emailTemplate);
        string GetEmailTemplate<T>(string emailTemplate, T emailTemplateModel);

    }
}
