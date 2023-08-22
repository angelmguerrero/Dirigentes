using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Plaza;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioPlaza
    {
        public List<PlazaCat> ObtenerPlazas();

        public PlazaCat PlazabyId(int idPlaza);
        public List<PlazaDom> ObtenerPlazaDom();
        public List<SelectDom> ObtenerRegiones();



    }
}
