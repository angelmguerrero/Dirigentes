namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class TipoPersonaCat
    {


        public int IdTipoPersona { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? EstatusTipoPersona { get; set; }


    }
}
