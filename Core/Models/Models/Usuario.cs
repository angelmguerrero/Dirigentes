namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class Usuario
    {

        public int IdUsuario { get; set; }
        public string UsuarioDa { get; set; }
        public string Password { get; set; }
        public string CorreoAcceso { get; set; }
        public bool? EstatusUsuario { get; set; }
        public int? IdPersona { get; set; }
        public int? IdPerfilCargo { get; set; }
        public DateTime? FechaCreacion { get; set; }


    }
}
