namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class CargosPlaza
    {
        public int IdCargoPlaza { get; set; }
        public int IdPlaza { get; set; }
        public int IdCargo { get; set; }
        public int IdPersona { get; set; }
        public bool EstatusCargoPlaza { get; set; }
    }
}
