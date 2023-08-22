namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class Perfil
    {

        public int IdPerfil { get; set; }
        public string? Descripcion { get; set; }
        public bool? EstatusPerfil { get; set; }
        public int? OrdenCargo { get; set; }
        public bool? EsCargo { get; set; }

    }
}
