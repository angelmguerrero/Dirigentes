namespace CPMPlataformaDirigentes.Models.ModelsConsulta
{
    public partial class VwUsuarioDirigente
    {
        public string Cif { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public int? PlazaId { get; set; }
        public string Plaza { get; set; }
        public int SucursalId { get; set; }
        public string Sucursal { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string CuentaMexicana { get; set; }
    }
}
