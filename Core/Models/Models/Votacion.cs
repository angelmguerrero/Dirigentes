namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class Votacion
    {
        public int IdVotacion { get; set; }
        public string? Descripcion { get; set; }
        public string? EstatusVotacion { get; set; }
        public int? IdConvocatoria { get; set; }
        public string? UrlVotacion { get; set; }


    }
}
