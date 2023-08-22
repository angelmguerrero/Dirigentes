namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class DetallePlantillaOrdenDia
    {
        public int IdDetallePlantillaOrdenDia { get; set; }
        public int IdConsecutivoPadre { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Indice { get; set; } = null!;
        public int? IdPadre { get; set; }
        public int IdPlantillaOrdenDia { get; set; }
    }
}
