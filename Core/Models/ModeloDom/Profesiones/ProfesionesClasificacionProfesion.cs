namespace CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones
{
    public class ProfesionesClasificacionProfesion
    {

        public int IdClasificacionProfesion { get; set; }
        public string? DescripcionClasif { get; set; }
        public string? DescripcionProfesion { get; set; }
        public int? IdProfesion { get; set; }
        public bool? EstatusClasificacionProfesion { get; set; }

        public bool? EstatusProfesion { get; set; }

    }
}
