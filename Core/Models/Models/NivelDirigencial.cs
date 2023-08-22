namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class NivelDirigencial
    {
        public int IdNivelDirigencial { get; set; }
        public int IdNivelDirigencialCat { get; set; }
        public int IdPersona { get; set; }
        public bool? EstatusNivelDirigencial { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? FinPeriodo { get; set; }
        public string? Periodo { get; set; }
        public int? Aperiodo { get; set; }
        public int? IdCondicionIngreso { get; set; }
    }
}
