using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia
{
    public class PlantillaOrdenDiaDetalles
    {

        public PlantillaOrdenDia encabezado { get; set; }

        public List<DetallePlantillaOrdenDiaDom> detalles { get; set; } = new List<DetallePlantillaOrdenDiaDom> { };

        public List<DetallePlantillaOrdenDiaDom> detallesEliminados { get; set; } = new List<DetallePlantillaOrdenDiaDom> { };
    }
}
