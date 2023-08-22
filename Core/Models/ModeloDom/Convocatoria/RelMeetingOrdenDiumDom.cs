using Newtonsoft.Json;

namespace CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria
{
    public class RelMeetingOrdenDiumDom
    {

        public int IdRelMeetingOrdenDia { get; set; }
        public int IdConvocatoria { get; set; }

        public int IdPlantillaOrdenDia { get; set; }
        public int IdConsecutivoPadre { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Indice { get; set; } = null!;
        public int? IdPadre { get; set; }

        [JsonProperty("children")]
        public List<RelMeetingOrdenDiumDom> niveles { get; set; } = new List<RelMeetingOrdenDiumDom>();
    }
}
