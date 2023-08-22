namespace CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.CargoXOrgano
{
    public class CargoOrganoDescDom
    {
        public int IdCargoOrgano { get; set; }
        public string Persona { get; set; }
        public string Organo { get; set; }
        public string Cargo { get; set; }
        public string Suplente { get; set; }
        public string Firmante { get; set; }
        public DateTime? FechaNombramiento { get; set; }
        public DateTime? FechaActaDesignacion { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public DateTime? FechaIngresoSocio { get; set; }
        public string Necesario { get; set; }
        public string? Plaza { get; set; }
        public string NivelGestion { get; set; }
        public bool? EstatusCargoOrgano { get; set; }
        public int? OrdenCargo { get; set; }
        public string? RFC { get; set; }
    }
}
