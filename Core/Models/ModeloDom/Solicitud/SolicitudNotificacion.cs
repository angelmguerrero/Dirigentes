namespace CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud
{
    public class SolicitudNotificacion
    {
        // Solicitud

        public int IdSolicitud { get; set; }

        //Persona

        public string NombrePersonaSolicitud { get; set; }
        public string ApellidoPaternoSolicitud { get; set; }
        public string ApellidoMaternoSolicitud { get; set; }

        // Responsable

        public string NombrePersonaResponsable { get; set; }
        public string ApellidoPaternoResponsable { get; set; }
        public string ApellidoMaternoResponsable { get; set; }
        public string CorreoAccesoResponsable { get; set; }

    }
}
