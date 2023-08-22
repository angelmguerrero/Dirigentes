namespace CPM.PlataformaDirigentes.Models.ModeloDom.Persona
{
    public partial class PersonaTipoMotivoBaja
    {
        //Persona
        public int IdPersona { get; set; }

        //MotivoBaja
        public int IdMotivoBaja { get; set; }
        public string? DescripcionMotivoBaja { get; set; }

        //Tipo Baja
        public int IdTipoBaja { get; set; }
        public string DescripcionTipoBaja { get; set; }

        //persona solicitante
        public int IdPersonaSolicitante { get; set; }
        //solicitud
        public string Estatus { get; set; }

    }
}
