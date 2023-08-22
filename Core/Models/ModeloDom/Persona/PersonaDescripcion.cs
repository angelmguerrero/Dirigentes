namespace CPM.PlataformaDirigentes.Models.ModeloDom.Persona
{
    public class PersonaDescripcion
    {
        //persona
        public int IdPersona { get; set; }
        public string? NombrePersona { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public bool? EstatusPersona { get; set; }
        public int IdTipoPersona { get; set; }
        public int? IdCargo { get; set; }
        public string? DescripciontipoPersona { get; set; }
        public int? IdPlaza { get; set; }

        //public int? IdSubUnidadOperativa { get; set; }
        //public string? DescripcionUnidadOperativa { get; set; }
        public int? IdGenero { get; set; }
        public string? DescripcionGenero { get; set; }
        public int? IdEstadoCivil { get; set; }
        public string DescripcionEstadoCivil { get; set; }
        public string CorreoPersonal { get; set; }
        public int? IdOficio { get; set; }
        public string? DescripcionIdOficio { get; set; }
        public int? IdEscolaridad { get; set; }
        public string? DescripcionEscolaridad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Rfc { get; set; }
        public string? Curp { get; set; }
        public int? Edad { get; set; }
        public int? CodigoPostal { get; set; }
        public string Celular { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? Cif { get; set; }
        public bool Dirigente { get; set; }
        public int? IdDirigente { get; set; }

        public string CuentaMexicana { get; set; }
        public int IdProfesion { get; set; }
        public string? DescripcionProfesion { get; set; }
        public int IdClasificacion { get; set; }
        public string? DescripcionClasificacion { get; set; }

        //public string? NombrePersonaCompleto { get; set; }
        public string? Plaza { get; set; }
        public string? Sucursal { get; set; }
        public int? IdSucursal { get; set; }
        public string? Calle { get; set; }
        public string? NumeroInterior { get; set; }
        public string? Colonia { get; set; }
        public string? Estado { get; set; }
        public string? Municipio { get; set; }
        //Dirigente

        public DateTime? FechaCreacion { get; set; }
        public string? ExpedienteDigital { get; set; }
        public string? Curriculum { get; set; }
        public bool? Estatus { get; set; }
        public int? IdPersonaDirigente { get; set; }
        public string? Participacion { get; set; }






    }
}
