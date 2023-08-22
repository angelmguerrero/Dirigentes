namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class ProfesionCat
    {

        public int IdProfesion { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdClasificacionProfesion { get; set; }
        public bool EstatusProfesion { get; set; }

    }
}
