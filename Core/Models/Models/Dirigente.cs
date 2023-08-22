namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class Dirigente
    {
        public int IdDirigente { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? ExpedienteDigital { get; set; }
        public string? Curriculum { get; set; }
        public bool? Estatus { get; set; }
        public int? IdPersona { get; set; }
    }
}
