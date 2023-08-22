namespace CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud
{
    public class SolicitudPersonaResponsable
    {
        public int IdPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }

        public string Plaza { get; set; }
        public string Sucursal { get; set; }
        //solicitud
        public int IdSolicitud { get; set; }

        public int? IdResponsablePlaza { get; set; }
        public string Estatus { get; set; }
        public int? IdTipoMovimiento { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string Observaciones { get; set; }
        public int? IdMotivoBaja { get; set; }
        public bool? EstatusSolicitud { get; set; }
        public int? IdPersonaSolicitante { get; set; }
        public string NombreCompletoSolicitante { get; set; }

        //tipo movimiento

        public string DescripcionTipoMovimiento { get; set; }
        public bool? EstatusTipoMovimiento { get; set; }
        public int IdPersonaResponsable { get; set; }
        public string NombrePersonaResponsable { get; set; }
        public string ApellidoPaternoResponsable { get; set; }
        public string ApellidoMaternoResponsable { get; set; }
        public string NombreCompletoResponsable { get; set; }
        //responsable
        public int? IdPlaza { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? EstatusResponsable { get; set; }


    }
}
