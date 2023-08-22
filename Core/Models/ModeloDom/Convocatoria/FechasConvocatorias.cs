namespace CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria
{
    public class FechasConvocatorias
    {
        public DateTime fechaInicio { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public string correoAsistente { get; set; }
    }
}
