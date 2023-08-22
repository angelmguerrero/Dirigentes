using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.OrganoDirigencial;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorOrganoDirigencial : IAdministradorOrganoDirigencial
    {
        private IRepositorioOrganoDirigencial repo;
        public AdministradorOrganoDirigencial()
        {
            this.repo = new RepositorioOrganoDirigencial();
        }
        public List<OrganoDirigencialDom> Obtener()
        {
            return repo.ObtenerDom();
        }

        public Respuesta Crear(OrganoCat item)
        {
            Respuesta resp = new Respuesta();
            OrganoCat organo = ObtenerOrganoPorDescripcion(item);
            if (organo == null)
            {
                return repo.Crear(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un organo con la misma descripción y nivel.";
                return resp;
            }

        }

        public Respuesta Modificar(OrganoCat item)
        {
            Respuesta resp = new Respuesta();
            OrganoCat organo = ObtenerOrganoPorDescripcion(item);
            if (organo == null || organo.IdOrgano == item.IdOrgano)
            {
                return repo.Modificar(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un organo con la misma descripción y nivel.";
                return resp;
            }

        }
        public bool Desactivar(int id)
        {
            return repo.Desactivar(id);
        }

        public OrganoCat RegistrobyId(int id)
        {
            return repo.RegistrobyId(id);
        }

        public List<SelectDom> ObtenerMateriales()
        {
            return repo.ObtenerMateriales();
        }

        public List<SelectDom> ObtenerNivelGestion()
        {
            return repo.ObtenerNivelGestion();
        }

        public OrganoCat ObtenerOrganoPorDescripcion(OrganoCat organo)
        {
            return repo.ObtenerOrganoPorDescripcion(organo);
        }

    }
}
