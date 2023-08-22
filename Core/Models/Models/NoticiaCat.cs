namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class NoticiaCat
    {
        public int IdNoticia { get; set; }
        public string TituloNoticia { get; set; }
        public string ResumenNoticia { get; set; }
        public string HipervinculoNoticia { get; set; }
        public string NombreImagen { get; set; }
        public string NombreImagenLimpio { get; set; }
        public bool? EstatusNoticia { get; set; }
    }
}
