using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.OrganoDirigencial;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioOrganoDirigencial
    {
        public List<OrganoCat> Obtener();
        public Respuesta Crear(OrganoCat iten);
        public Respuesta Modificar(OrganoCat item);

        public bool Desactivar(int id);
        public OrganoCat RegistrobyId(int id);
        public List<OrganoDirigencialDom> ObtenerDom();
        public List<SelectDom> ObtenerMateriales();
        public List<SelectDom> ObtenerNivelGestion();
        public OrganoCat ObtenerOrganoPorDescripcion(OrganoCat organo);
    }
}
