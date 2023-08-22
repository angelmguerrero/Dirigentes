namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class RelMeetingConvocatorium
    {
        public int Id { get; set; }
        public string IdMeetingTeams { get; set; } = null!;
        public int IdConvocatoria { get; set; }
        public DateTime FechaInicio { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string JoinWebUrl { get; set; } = null!;
    }
}
