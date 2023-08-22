namespace CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud
{
    public class PersonResponsable
    {
        public int IdPersonaResponsable { get; set; }
        public string NombrePersonaResponsable { get; set; }
        public string ApellidoPaternoResponsable { get; set; }
        public string ApellidoMaternoResponsable { get; set; }
        public string NombreCompletoResponsable { get; set; }
        //responsable

        public int IdResponsablePlaza { get; set; }
        public int? IdPlaza { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? EstatusResponsable { get; set; }
    }
}
