namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class Materiale
    {
        public int IdMaterial { get; set; }
        public string Descripción { get; set; } = null!;
        public string Junta { get; set; } = null!;
        public bool? EstatusMaterial { get; set; }
    }
}
