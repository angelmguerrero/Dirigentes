namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class ConvocatoriaHorario
    {
        public int IdConvocatoriaHorario { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool? EstatusConvocatoriaHorario { get; set; }


    }
}
