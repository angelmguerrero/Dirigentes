namespace CPMPlataformaDirigentes.Models.Models
{
    public partial class LogGeneral
    {
        public int LogGeneralId { get; set; }
        public int? IdModulo { get; set; }
        public int? IdSubmodulo { get; set; }
        public string? TipoMovimiento { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? UsuarioCorreo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Tabla { get; set; }
    }
}
