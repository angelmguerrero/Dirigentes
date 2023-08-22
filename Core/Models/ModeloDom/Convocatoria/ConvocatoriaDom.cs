using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;

namespace CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria
{
    public class ConvocatoriaDom
    {
        public int idConvocatoria { get; set; }
        public string convocatoria { get; set; }
        public int idOrgano { get; set; }
        public int idTipoJunta { get; set; }
        public int idModalidad { get; set; }
        public int IdOrdenDia { get; set; }
        public string? correoMaterial { get; set; }
        public string? fechaInicioMaterial { get; set; }
        public string? fechaFinMaterial { get; set; }
        public string? ubicacion { get; set; }
        public string? Organizador { get; set; }
        public int? estatusConvocatoria { get; set; }
        public List<MeetingDom> listMeeting { get; set; } = new List<MeetingDom>();
        public List<DetallePlantillaOrdenDiaDom> lstOrdenDia { get; set; } = new List<DetallePlantillaOrdenDiaDom>();
        public List<SelectCorreo> listNecesarios { get; set; } = new List<SelectCorreo>();
        public List<SelectCorreo> listConocimiento { get; set; } = new List<SelectCorreo>();
        public List<SelectCorreo> listOcultos { get; set; } = new List<SelectCorreo>();

    }
}
