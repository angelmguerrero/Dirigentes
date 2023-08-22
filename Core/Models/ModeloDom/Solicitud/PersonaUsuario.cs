namespace CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud
{
    public class PersonaUsuario
    {
        //Persona

        public int IdPersona { get; set; }
        public string NombrePersona { get; set; }
        public bool? EstatusPersona { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int? Cif { get; set; }
        public int? IdPlaza { get; set; }
        public string Plaza { get; set; }

        // Usuario

        public int IdUsuario { get; set; }
        public string CorreoAcceso { get; set; }
        public bool? EstatusUsuario { get; set; }
        public int? IdPerfilCargo { get; set; }

    }
}
