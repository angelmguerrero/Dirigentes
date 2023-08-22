namespace CPMPlataformaDirigentes.Models.Models
{
    public partial class PersonaCat
    {
        public int IdPersona { get; set; }
        public string NombrePersona { get; set; }
        public bool? EstatusPersona { get; set; }
        public int IdTipoPersona { get; set; }
        public int? IdCargo { get; set; }
        public int? IdSubUnidadOperativa { get; set; }
        public int? IdGenero { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? IdOficio { get; set; }
        public int? IdEscolaridad { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public int? Edad { get; set; }
        public int? CodigoPostal { get; set; }
        public string Celular { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? Cif { get; set; }
        public bool Dirigente { get; set; }
        public int? IdDirigente { get; set; }
        public int IdRepresententanteCargoCat { get; set; }
        public int IdProfesion { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string Colonia { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public int? IdPlaza { get; set; }
        public string Plaza { get; set; }
        public int? IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public string CorreoPersonal { get; set; }
        public string CuentaMexicana { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? EstatusSolicitud { get; set; }
        public string? Participacion { get; set; }
    }
}
