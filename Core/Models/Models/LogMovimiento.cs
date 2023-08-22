namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class LogMovimiento
    {
        public int IdLogMovimiento { get; set; }
        public int? IdOperacion { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdUsuario { get; set; }


    }
}
