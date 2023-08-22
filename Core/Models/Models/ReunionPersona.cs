namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class ReunionPersona
    {
        public int IdReunionPersona { get; set; }
        public int IdConvocatoria { get; set; }
        public int IdPersona { get; set; }
        public int? Oculto { get; set; }
        public bool? EstatusReunionPersona { get; set; }


    }
}
