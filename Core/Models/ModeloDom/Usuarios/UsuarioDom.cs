namespace CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios
{
    public class UsuarioDom
    {

        public int IdUsuario { get; set; }
        public string? UsuarioDa { get; set; }
        public string? Password { get; set; }
        public string? CorreoAcceso { get; set; }
        public int? EstatusUsuario { get; set; }
        public int? IdPersona { get; set; }
        public int? IdPerfil { get; set; }
        public string? NombrePersona { get; set; }
    }
}
