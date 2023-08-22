namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class RelMeetingOrdenDium
    {
        public int IdRelMeetingOrdenDia { get; set; }
        public int IdConvocatoria { get; set; }

        public int IdPlantillaOrdenDia { get; set; }
        public int IdConsecutivoPadre { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Indice { get; set; } = null!;
        public int? IdPadre { get; set; }
    }
}
