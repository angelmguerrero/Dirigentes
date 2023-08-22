namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class OrdenDelDium
    {

        public int IdOrdenDia { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdDetalleOrdenDia { get; set; }
        public int IdTipoJunta { get; set; }
        public bool? EstatusOrdenDia { get; set; }

    }
}
