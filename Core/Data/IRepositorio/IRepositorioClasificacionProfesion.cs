using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioClasificacionProfesion
    {
        public List<ClasificacionProfesion> ObtenerClasificacionesProfesion();
        public Respuesta CrearClasificacionProfesion(ClasificacionProfesion clasProfesion);
        public Respuesta ModificarClasificacionProfesion(ClasificacionProfesion clasProfesion);

        public bool DesactivarClasificacionProfesion(int clasificacionProfesion);

        public ClasificacionProfesion ObtenerClasificacionProfesion(int idclasProfesion);

        public List<ProfesionesClasificacionProfesion> ObtenerProfesionesClasificacionProfesion();

        public List<SelectDom> ObtenerClasificacionActivo();

        public ClasificacionProfesion ObtenerClasificacionProfesionPorDescripcion(string descProfesion);
        public List<ProfesionesClasificacionProfesion> ObtenerClasificacionProfesionPorDescripcionbyid(int idProfesion);
    }
}
