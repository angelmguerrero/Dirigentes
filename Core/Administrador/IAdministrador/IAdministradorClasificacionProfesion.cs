using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorClasificacionProfesion
    {
        public List<ClasificacionProfesion> ObtenerClasificacionesProfesion();
        public Respuesta CrearClasificacionProfesion(ClasificacionProfesion clasprofesion);
        public Respuesta ModificarClasificacionProfesion(ClasificacionProfesion clasprofesion);
        public bool DesactivarClasificacionProfesion(int clasprofesion);

        public ClasificacionProfesion ObtenerClasificacionProfesion(int idclasprofesion);

        public List<ProfesionesClasificacionProfesion> ObtenerProfesionesClasificacionProfesion();

        public List<SelectDom> ObtenerClasificacionActivo();

        public ClasificacionProfesion ObtenerClasificacionProfesionPorDescripcion(string descProfesion);
        public List<ProfesionesClasificacionProfesion> ObtenerClasificacionProfesionPorDescripcionbyid(int idProfesion);

        public bool DesactivarProfesionPorClasificacion(int clasprofesion);
    }
}
