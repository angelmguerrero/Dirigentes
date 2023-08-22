namespace CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.CargoXOrgano
{
    public class CargoOrganoDom
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
        public string FechaNombramiento { get; set; }
        public string FechaActaDesignacion { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public string FechaIngresoSocio { get; set; }
        public bool EstatusCargoOrgano { get; set; }


    }
}
