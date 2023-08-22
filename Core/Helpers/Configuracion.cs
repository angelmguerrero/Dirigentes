using Microsoft.Extensions.Configuration;

namespace CPM.PlataformaDirigentes.Helpers
{
    public class Configuracion
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return Security.deCryp(config.GetConnectionString("SQLConnection"));
        }

        public static string GetConnectionConsultaCpmString()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return Security.deCryp(config.GetConnectionString("SQLConnectionConsultaCpm"));
        }

        public static string GetConnectionConsultaCpmDirectorioString()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return Security.deCryp(config.GetConnectionString("SQLConnectionConsultaCpmDirectorio"));
        }

        public static string GetSMTPServer()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return config["SMTPServer:EmailServer"];
        }

        public static string GetSMTPSender()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return config["SMTPServer:EmailSender"];
        }

        public static string GetCalendarAttachmentLugar()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return config["CalendarAttachment:Lugar"];
        }

        public static string GetCalendarAttachmentOrganizador()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return config["CalendarAttachment:Organizador"];
        }

        public static string GetCalendarAttachmentEmail()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return config["CalendarAttachment:Email"];
        }

        public static string GetRutaVNX()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return config["VNXAtributtes:RutaVNX"];
        }
        public static string GetCarpetaVNX()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            return config["VNXAtributtes:CarpetaRoot"];
        }
    }
}
