namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class Acuerdo
    {
        public int IdAcuerdo { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdConvocatoria { get; set; }
        public int IdEstatusAcuerdo { get; set; }


    }
}
