namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class DiasInhabilesCat
    {
        public int IdDiaInhabil { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Descripcion { get; set; }
        public bool EstatusDiaInhabil { get; set; }
    }
}
