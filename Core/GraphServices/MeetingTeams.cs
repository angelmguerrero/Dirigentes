using CPM.PlataformaDirigentes.Models.ModeloDom;
using GraphServices.Models;

namespace GraphServices
{
    public class MeetingTeams
    {

        public async Task<MeetingsTeams> CrearReunion(string convocatoria, DateTime fechaInicio, DateTime fechaFin, List<SelectCorreo> lstCorreos)
        {
            MeetingsTeams respuesta = new MeetingsTeams();

            TeamsService _teamsService = new TeamsService();
            AadGraphApiApplicationClient _aadGraphApiDelegatedClient = new AadGraphApiApplicationClient();

            var meeting = _teamsService.CreateTeamsMeeting(convocatoria, fechaInicio, fechaFin);
            List<string> items = new();
            foreach (var item in lstCorreos)
            {
                items.Add(item.text);

            }
            var updatedMeeting = _teamsService.AddMeetingParticipants(meeting, items);

            var createdMeeting = await _aadGraphApiDelegatedClient.CreateOnlineMeeting(updatedMeeting);
            respuesta.JoinUrl = createdMeeting.JoinUrl;
            respuesta.idMeeting = createdMeeting.Id;

            return respuesta;
        }
    }
}
