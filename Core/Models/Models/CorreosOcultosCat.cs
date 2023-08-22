namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class CorreosOcultosCat
    {
        public int IdCorreoOculto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public bool EstatusCorreoOculto { get; set; }
    }
}
