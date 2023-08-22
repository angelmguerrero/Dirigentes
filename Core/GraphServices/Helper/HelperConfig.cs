using GraphServices.Models;
using Microsoft.Extensions.Configuration;

namespace GraphServices.Helper
{
    public class HelperConfig
    {
        public static ConfigAzure GetConfig()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            ConfigAzure conf = new ConfigAzure();
            conf.ClientId = config["AzureAd:ClientId"];
            conf.TenantId = config["AzureAd:TenantId"];
            conf.ClientSecret = config["AzureAd:ClientSecret"];
            conf.MeetingOrganizer = config["AzureAd:MeetingOrganizer"];
            return conf;

        }
    }
}
