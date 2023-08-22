namespace CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales
{
    public partial class RegionWrk
    {
        public int IdRegion { get; set; }
        public long IdColonia { get; set; }
        public int IdTipoLocal { get; set; }
        public int IdVialidad { get; set; }
        public int IdHorario { get; set; }
        public int NumIcbs { get; set; }
        public int CentroCostos { get; set; }
        public string Nombre { get; set; }
        public decimal LatitudUtm { get; set; }
        public decimal LongitudUtm { get; set; }
        public string Direccion { get; set; }
        public string EntreCalles { get; set; }
        public string ContraCalles { get; set; }
        public int CodigoPostal { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }
        public string Referencia { get; set; }
        public bool? Activo { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
