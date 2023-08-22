namespace CPMPlataformaDirigentes.Models.ModelsConsulta
{
    public partial class VwInfoSocio
    {
        public string Cif { get; set; }


        public string Nombre { get; set; }
        public string ApePatSocio { get; set; }

        public string ApeMatSocio { get; set; }
        public string Calle { get; set; }
        public string EntreCalles { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }
        public decimal? CveCol { get; set; }
        public string Colonia { get; set; }
        public string Cp { get; set; }
        public string Ciudad { get; set; }
        public string Sucursal { get; set; }
        public int? IdSucursal { get; set; }
        public string CveEstado { get; set; }
        public string EstadoDomicilio { get; set; }
        public int IdEstadoSucursal { get; set; }
        public string EstadoSucursal { get; set; }
        public string TelCasa { get; set; }
        public DateTime? FecNacD { get; set; }
        public string Sexo { get; set; }
        public string TipSocio { get; set; }
        public string TipoSocio { get; set; }
        public string TipoPersona { get; set; }
    }
}
