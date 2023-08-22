namespace CPMPlataformaDirigentes.Models.Models
{
    public partial class SolicitudResponsablePlaza
    {
        public int IdSolicitudResponsablePlaza { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdResponsablePlaza { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
