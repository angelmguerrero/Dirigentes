namespace CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud
{
    public class PersonaSolicitud
    {
        public int IdPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string Plaza { get; set; }
        public int? IdPlaza { get; set; }
        public string Sucursal { get; set; }

        public int? Cif { get; set; }
        //solicitud
        public int IdSolicitud { get; set; }


        public string Estatus { get; set; }
        public int? IdTipoMovimiento { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string Observaciones { get; set; }
        public int? IdMotivoBaja { get; set; }
        public bool? EstatusSolicitud { get; set; }
        public int? IdPersonaSolicitante { get; set; }
        //tipo movimiento

        public string DescripcionTipoMovimiento { get; set; }
        public bool? EstatusTipoMovimiento { get; set; }


    }
}
