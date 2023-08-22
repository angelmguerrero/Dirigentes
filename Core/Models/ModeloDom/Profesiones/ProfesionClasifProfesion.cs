namespace CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones
{
    public class ProfesionClasifProfesion
    {

        public int IdProfesion { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdClasificacionProfesion { get; set; }

        public string DescripcionClasificacion { get; set; } = null!;

        public bool EstatusProfesion { get; set; }


    }
}
