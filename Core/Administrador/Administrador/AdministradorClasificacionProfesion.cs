using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Profesiones;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorClasificacionProfesion : IAdministradorClasificacionProfesion
    {
        private IRepositorioClasificacionProfesion repoClasProfesion;
        private IRepositorioProfesion repoProfesion;

        public AdministradorClasificacionProfesion()
        {
            this.repoClasProfesion = new RepositorioClasificacionProfesion();
            this.repoProfesion = new RepositorioProfesion();
        }

        public List<ClasificacionProfesion> ObtenerClasificacionesProfesion()
        {
            return repoClasProfesion.ObtenerClasificacionesProfesion();
        }
        public Respuesta CrearClasificacionProfesion(ClasificacionProfesion clasprofesion)
        {
            Respuesta resp = new Respuesta();
            ClasificacionProfesion clas = ObtenerClasificacionProfesionPorDescripcion(clasprofesion.Descripcion);
            if (clas == null)
            {
                return repoClasProfesion.CrearClasificacionProfesion(clasprofesion);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una clasificación con la misma descripción.";
                return resp;
            }

        }
        public Respuesta ModificarClasificacionProfesion(ClasificacionProfesion clasprofesion)
        {
            Respuesta resp = new Respuesta();
            ClasificacionProfesion clas = ObtenerClasificacionProfesionPorDescripcion(clasprofesion.Descripcion);
            if (clas == null || clas.IdClasificacionProfesion == clasprofesion.IdClasificacionProfesion)
            {
                return repoClasProfesion.ModificarClasificacionProfesion(clasprofesion);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una clasificación con la misma descripción.";
                return resp;
            }
        }


        public bool DesactivarClasificacionProfesion(int clasprofesion)
        {
            if (repoClasProfesion.DesactivarClasificacionProfesion(clasprofesion))
            {
                DesactivarProfesionPorClasificacion(clasprofesion);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ClasificacionProfesion ObtenerClasificacionProfesion(int idclasprofesion)
        {
            return repoClasProfesion.ObtenerClasificacionProfesion(idclasprofesion);
        }

        public List<ProfesionesClasificacionProfesion> ObtenerProfesionesClasificacionProfesion()
        {
            List<ProfesionesClasificacionProfesion> lista = new List<ProfesionesClasificacionProfesion>();
            List<ProfesionesClasificacionProfesion> listaFinal = new List<ProfesionesClasificacionProfesion>();
            lista = repoClasProfesion.ObtenerProfesionesClasificacionProfesion();
            listaFinal.InsertRange(0, lista);
            foreach (ProfesionesClasificacionProfesion clas in lista)
            {
                if (clas.EstatusProfesion == false)
                {
                    clas.DescripcionProfesion = "";
                }
                if (listaFinal.Where(x => x.IdClasificacionProfesion == clas.IdClasificacionProfesion && x.EstatusProfesion == false).ToList().Count > 1)
                {
                    listaFinal.Remove(clas);
                }
            }
            return listaFinal;
        }

        public List<SelectDom> ObtenerClasificacionActivo()
        {
            return repoClasProfesion.ObtenerClasificacionActivo();
        }

        public ClasificacionProfesion ObtenerClasificacionProfesionPorDescripcion(String descProfesion)
        {
            return repoClasProfesion.ObtenerClasificacionProfesionPorDescripcion(descProfesion);
        }
        public List<ProfesionesClasificacionProfesion> ObtenerClasificacionProfesionPorDescripcionbyid(int idProfesion)
        {
            return repoClasProfesion.ObtenerClasificacionProfesionPorDescripcionbyid(idProfesion);
        }

        public bool DesactivarProfesionPorClasificacion(int clasprofesion)
        {
            return repoProfesion.DesactivarProfesionPorClasificacion(clasprofesion);
        }
    }
}
