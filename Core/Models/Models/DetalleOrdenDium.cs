namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class DetalleOrdenDium
    {

        public int IdDetalleOrdenDia { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? IdSubDetalleOrdenDia { get; set; }
        public bool? EstatusDetalleOrdenDia { get; set; }


    }
}
