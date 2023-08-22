namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class Convocatorium
    {
        public int IdConvocatoria { get; set; }
        public string Convocatoria { get; set; } = null!;
        public int IdOrgano { get; set; }
        public int IdModalidad { get; set; }
        public int IdOrdenDia { get; set; }
        public string Ubicacion { get; set; } = null!;
        public string? Organizador { get; set; }
        public int EstatusConvocatoria { get; set; }
    }
}
