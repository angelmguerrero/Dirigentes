namespace CPMPlataformaDirigentes.Models.Models
{
    public partial class ResponsablePlaza
    {
        public int IdResponsablePlaza { get; set; }
        public int? IdPersona { get; set; }
        public int? IdPlaza { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Estatus { get; set; }
    }
}
