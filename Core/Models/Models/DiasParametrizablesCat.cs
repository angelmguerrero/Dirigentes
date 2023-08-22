namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class DiasParametrizablesCat
    {
        public int IdDiaParametrizable { get; set; }
        public string Descripcion { get; set; }
        public int Dias { get; set; }
        public string DiasNaturales { get; set; }
        public bool EstatusDiaParametrizable { get; set; }
    }
}
