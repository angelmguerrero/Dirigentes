using Microsoft.Extensions.Configuration;


namespace EmailMailkit.Configuration
{
    public class HelperConfig
    {
        public static MailSettings GetConfig()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            MailSettings conf = new MailSettings();
            conf.DisplayName = config["MailSettings:DisplayName"];
            conf.From = config["MailSettings:From"];
            conf.Host = config["MailSettings:Host"];
            conf.Port = Convert.ToInt16(config["MailSettings:Port"]);
            conf.UseSSL = Convert.ToBoolean(config["MailSettings:UseSSL"]);
            conf.UseStartTls = Convert.ToBoolean(config["MailSettings:UseStartTls"]);
            return conf;

        }

    }




}
