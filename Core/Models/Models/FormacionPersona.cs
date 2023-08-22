namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class FormacionPersona
    {
        public int IdFormacionPersona { get; set; }
        public int? IdSubUnidadOperativa { get; set; }
        public int? IdPersona { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaFinCargo { get; set; }
        public bool? EstatusFormacionPersona { get; set; }


    }
}
