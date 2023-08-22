namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class RelMeetingAutorizacion
    {
        public int Id { get; set; }
        public int IdConvocatoria { get; set; }
        public string CorreoAutoriza { get; set; } = null!;
        public bool Autorizo { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public int TipoAutorizador { get; set; }
    }
}
