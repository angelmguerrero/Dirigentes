using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorProfesion
    {
        public List<ProfesionCat> ObtenerProfesiones();
        public List<ProfesionCat> ObtenerProfesionesActivas();
        public Respuesta CrearProfesion(ProfesionCat profesion);
        public Respuesta ModificarProfesion(ProfesionCat profesion);
        public bool DesactivarProfesion(int profesion);

        public ProfesionCat ObtenerProfesion(int idprofesion);

        public List<ProfesionClasifProfesion> ObtenerProfesionesDt();


    }
}
