namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class RelMeetingAsistente
    {
        public int Id { get; set; }
        public int IdMeeting { get; set; }
        public string CorreoAsistente { get; set; }
        public int TipoAsistente { get; set; }
    }
}
