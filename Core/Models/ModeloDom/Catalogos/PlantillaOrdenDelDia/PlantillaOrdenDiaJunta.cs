namespace CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia
{
    public class PlantillaOrdenDiaJunta
    {

        public int IdPlantillaOrdenDia { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdTipoJunta { get; set; }
        public string? DescripcionJunta { get; set; }
        public bool? EstatusPlantillaOrdenDia { get; set; }
    }
}
