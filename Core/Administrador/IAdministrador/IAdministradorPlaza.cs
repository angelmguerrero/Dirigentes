using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Plaza;


namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorPlaza
    {
        public List<PlazaCat> ObtenerPlazas();
        public PlazaCat PlazabyId(int idPlaza);
        public List<PlazaDom> ObtenerPlazaDom();
        public List<SelectDom> ObtenerRegiones();
    }
}
