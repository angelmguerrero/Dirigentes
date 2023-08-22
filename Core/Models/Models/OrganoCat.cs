namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class OrganoCat
    {
        public int IdOrgano { get; set; }
        public string Descripcion { get; set; }
        public int? IdNivelGestion { get; set; }
        public string AbreviaturaOrgano { get; set; }
        public int? NoFirmas { get; set; }
        public int? IdMaterial { get; set; }
        public bool EstatusOrgano { get; set; }
    }
}
