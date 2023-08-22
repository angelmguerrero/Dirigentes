using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorEscolaridad : IAdministradorEscolaridad
    {
        private IRepositorioEscolaridad repoEscolaridad;

        public AdministradorEscolaridad()
        {
            this.repoEscolaridad = new RepositorioEscolaridad();
        }
        public List<EscolaridadCat> ObtenerEscolaridades()
        {
            return repoEscolaridad.ObtenerEscolaridades();
        }

        public Respuesta CrearEscolaridad(EscolaridadCat escolaridad)
        {
            Respuesta resp = new Respuesta();
            EscolaridadCat esco = ObtenerEscolaridadPorDescripcion(escolaridad.Descripcion);
            if (esco == null)
            {
                return repoEscolaridad.CrearEscolaridad(escolaridad);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una escolaridad con la misma descripción.";
                return resp;
            }

        }
        public Respuesta ModificarEscolaridad(EscolaridadCat escolaridad)
        {
            Respuesta resp = new Respuesta();
            EscolaridadCat esco = ObtenerEscolaridadPorDescripcion(escolaridad.Descripcion);
            if (esco == null || esco.IdEscolaridad == escolaridad.IdEscolaridad)
            {
                return repoEscolaridad.ModificarEscolaridad(escolaridad);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una escolaridad con la misma descripción.";
                return resp;
            }

        }

        public bool DesactivarEscolaridad(int escolaridad)
        {
            return repoEscolaridad.DesactivarEscolaridad(escolaridad);
        }


        public EscolaridadCat ObtenerEscolaridad(int idescolaridad)
        {
            return repoEscolaridad.ObtenerEscolaridad(idescolaridad);
        }
        public EscolaridadCat ObtenerEscolaridadPorDescripcion(String descEscolaridad)
        {
            return repoEscolaridad.ObtenerEscolaridadPorDescripcion(descEscolaridad);
        }

        public List<SelectDom> ObtenerEscolaridadActivo()
        {
            return repoEscolaridad.ObtenerEscolaridadActivo();
        }


    }
}
