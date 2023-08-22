namespace CPMPlataformaDirigentes.Models.Models
{
    public partial class PerfilCargo
    {
        public int IdPerfilCargo { get; set; }
        public string Descripcion { get; set; }
        public bool? EstatusPerfil { get; set; }
        public int? OrdenCargo { get; set; }
        public bool? EsCargo { get; set; }
    }
}
