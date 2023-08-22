namespace CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.OrganoDirigencial
{
    public class OrganoDirigencialDom
    {
        public int IdOrgano { get; set; }
        public string Descripcion { get; set; }
        public string NivelOrgano { get; set; }
        public string AbreviaturaOrgano { get; set; }
        public int? NoFirmas { get; set; }
        public string Material { get; set; }
        public bool EstatusOrgano { get; set; }
    }
}
