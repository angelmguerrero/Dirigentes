namespace CPM.PlataformaDirigentes.Models.ModeloDom.ResponsablePlaza
{
    public class ResponsablePlazaPersona
    {

        //Responsable plaza
        public int IdResponsablePlaza { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Estatus { get; set; }
        //public string NombrePersona { get; set; }

        //Persona
        public int IdPersona { get; set; }
        public string NombrePersona { get; set; }

        //Plaza
        public int IdPlaza { get; set; }
        public string Nombre { get; set; }
    }
}
