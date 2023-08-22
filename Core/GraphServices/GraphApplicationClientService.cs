using Azure.Identity;
using GraphServices.Helper;
using Microsoft.Graph;

namespace GraphServices;

public class GraphApplicationClientService
{
    private GraphServiceClient? _graphServiceClient;

    /// <summary>
    /// gets a singleton instance of the GraphServiceClient
    /// </summary>
    /// <returns></returns>
    public GraphServiceClient GetGraphClientWithManagedIdentityOrDevClient()
    {
        if (_graphServiceClient != null)
            return _graphServiceClient;

        string[] scopes = new[] { "https://graph.microsoft.com/.default" };

        var chainedTokenCredential = GetChainedTokenCredentials();
        _graphServiceClient = new GraphServiceClient(chainedTokenCredential, scopes);

        return _graphServiceClient;
    }

    private ChainedTokenCredential GetChainedTokenCredentials()
    {
        var config = HelperConfig.GetConfig();
        var tenantId = config.TenantId;
        var clientId = config.ClientId;
        var clientSecret = config.ClientSecret;

        var options = new TokenCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
        };

        // https://docs.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
        var devClientSecretCredential = new ClientSecretCredential(
            tenantId, clientId, clientSecret, options);

        var chainedTokenCredential = new ChainedTokenCredential(devClientSecretCredential);

        return chainedTokenCredential;

    }
}