namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class PlantillaOrdenDia
    {

        public int IdPlantillaOrdenDia { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdTipoJunta { get; set; }
        public bool? EstatusPlantillaOrdenDia { get; set; }

    }
}
