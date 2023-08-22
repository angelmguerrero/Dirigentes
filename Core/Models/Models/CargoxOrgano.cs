namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class CargoxOrgano
    {
        public int IdCargoOrgano { get; set; }
        public int IdPersona { get; set; }
        public int IdOrgano { get; set; }
        public int IdPerfilCargo { get; set; }
        public int? IdPlaza { get; set; }
        public int IdNivelGestion { get; set; }
        public string Suplente { get; set; }
        public string Firmante { get; set; }
        public string Necesario { get; set; }
        public DateTime? FechaNombramiento { get; set; }
        public DateTime? FechaActaDesignacion { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public DateTime? FechaIngresoSocio { get; set; }
        public bool EstatusCargoOrgano { get; set; }
    }
}
