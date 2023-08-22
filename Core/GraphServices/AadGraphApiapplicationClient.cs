using GraphServices.Helper;
using Microsoft.Graph;

namespace GraphServices;

public class AadGraphApiApplicationClient
{
    private readonly GraphApplicationClientService _graphApplicationClientService;

    public AadGraphApiApplicationClient()
    {

        _graphApplicationClientService = new GraphApplicationClientService();
    }

    private string GetUserIdAsync()
    {
        var conf = HelperConfig.GetConfig();
        return conf.MeetingOrganizer;

    }

    public async Task SendEmailAsync(Message message)
    {
        var graphServiceClient = _graphApplicationClientService.GetGraphClientWithManagedIdentityOrDevClient();

        var saveToSentItems = true;

        var userId = GetUserIdAsync();

        await graphServiceClient.Users[userId]
            .SendMail(message, saveToSentItems)
            .Request()
            .PostAsync();
    }

    public async Task<OnlineMeeting> CreateOnlineMeeting(OnlineMeeting onlineMeeting)
    {
        var graphServiceClient = _graphApplicationClientService.GetGraphClientWithManagedIdentityOrDevClient();

        return await graphServiceClient.Users[GetUserIdAsync()]
            .OnlineMeetings
            .Request()
            .AddAsync(onlineMeeting);
    }

    public async Task<OnlineMeeting> UpdateOnlineMeeting(OnlineMeeting onlineMeeting)
    {
        var graphServiceClient = _graphApplicationClientService.GetGraphClientWithManagedIdentityOrDevClient();


        return await graphServiceClient.Users[GetUserIdAsync()]
            .OnlineMeetings[onlineMeeting.Id]
            .Request()
            .UpdateAsync(onlineMeeting);
    }

    public async Task<OnlineMeeting> GetOnlineMeeting(string onlineMeetingId)
    {
        var graphServiceClient = _graphApplicationClientService.GetGraphClientWithManagedIdentityOrDevClient();


        return await graphServiceClient.Users[GetUserIdAsync()]
            .OnlineMeetings[onlineMeetingId]
            .Request()
            .GetAsync();
    }
}
