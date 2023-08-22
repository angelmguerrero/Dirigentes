namespace CPMPlataformaDirigentes.Models.Models
{
    public partial class Solicitud
    {
        public int IdSolicitud { get; set; }
        public int? IdPersona { get; set; }
        public string Estatus { get; set; }
        public int? IdTipoMovimiento { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string Observaciones { get; set; }
        public int? IdMotivoBaja { get; set; }
        public bool? EstatusSolicitud { get; set; }
        public int? IdTipoBaja { get; set; }
        public DateTime? FechaEfectivaBaja { get; set; }
        public int? IdPersonaSolicitante { get; set; }
        public DateTime? FechaReingreso { get; set; }
    }
}
