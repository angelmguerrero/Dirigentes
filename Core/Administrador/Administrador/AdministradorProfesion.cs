using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorProfesion : IAdministradorProfesion
    {
        private IRepositorioProfesion repoProfesion;

        public AdministradorProfesion()
        {
            this.repoProfesion = new RepositorioProfesion();
        }
        public List<ProfesionCat> ObtenerProfesiones()
        {
            return repoProfesion.ObtenerProfesiones();
        }
        public Respuesta CrearProfesion(ProfesionCat profesion)
        {
            Respuesta resp = new Respuesta();
            ProfesionCat prof = ObtenerProfesionPorDescripcion(profesion.Descripcion);
            if (prof == null)
            {
                return repoProfesion.CrearProfesion(profesion);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una profesión con la misma descripción.";
                return resp;
            }
        }
        public Respuesta ModificarProfesion(ProfesionCat profesion)
        {
            Respuesta resp = new Respuesta();
            ProfesionCat prof = ObtenerProfesionPorDescripcion(profesion.Descripcion);
            if (prof == null || prof.IdProfesion == profesion.IdProfesion)
            {
                return repoProfesion.ModificarProfesion(profesion);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una profesión con la misma descripción.";
                return resp;
            }
        }

        public bool DesactivarProfesion(int profesion)
        {
            return repoProfesion.DesactivarProfesion(profesion);
        }

        public ProfesionCat ObtenerProfesion(int idprofesion)
        {
            return repoProfesion.ObtenerProfesion(idprofesion);
        }

        public ProfesionCat ObtenerProfesionPorDescripcion(String descProfesion)
        {
            return repoProfesion.ObtenerProfesionPorDescripcion(descProfesion);
        }

        public List<ProfesionCat> ObtenerProfesionesActivas()
        {

            return repoProfesion.ObtenerProfesionesActivas();
        }

        public List<ProfesionClasifProfesion> ObtenerProfesionesDt()
        {
            return repoProfesion.ObtenerProfesionesDt();
        }
    }
}
