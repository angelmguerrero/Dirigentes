using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioProfesion
    {
        public List<ProfesionCat> ObtenerProfesiones();

        public Respuesta CrearProfesion(ProfesionCat profesion);
        public Respuesta ModificarProfesion(ProfesionCat profesion);

        public bool DesactivarProfesion(int profesion);

        public ProfesionCat ObtenerProfesion(int idprofesion);

        public ProfesionCat ObtenerProfesionPorDescripcion(string descProfesion);

        public bool DesactivarProfesionPorClasificacion(int clas);
        public List<ProfesionCat> ObtenerProfesionesActivas();

        public List<ProfesionClasifProfesion> ObtenerProfesionesDt();


    }
}
