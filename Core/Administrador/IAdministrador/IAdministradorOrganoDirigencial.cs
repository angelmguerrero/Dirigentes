using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.OrganoDirigencial;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorOrganoDirigencial
    {
        public List<OrganoDirigencialDom> Obtener();
        public Respuesta Crear(OrganoCat item);
        public Respuesta Modificar(OrganoCat item);
        public bool Desactivar(int id);
        public OrganoCat RegistrobyId(int id);
        public List<SelectDom> ObtenerMateriales();
        public List<SelectDom> ObtenerNivelGestion();

        public OrganoCat ObtenerOrganoPorDescripcion(OrganoCat organo);

    }
}
