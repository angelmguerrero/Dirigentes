using Newtonsoft.Json;

namespace CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia
{
    public class DetallePlantillaOrdenDiaDom
    {
        public int IdDetallePlantillaOrdenDia { get; set; }
        public int IdConsecutivoPadre { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Indice { get; set; } = null!;
        public int? IdPadre { get; set; }
        public int IdPlantillaOrdenDia { get; set; }

        [JsonProperty("children")]
        public List<DetallePlantillaOrdenDiaDom> niveles { get; set; } = new List<DetallePlantillaOrdenDiaDom>();
    }
}
