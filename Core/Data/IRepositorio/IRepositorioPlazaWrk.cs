using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioPlazaWrk
    {
        public List<PlazaWrk> ObtenerPlazaWrks();
        public List<SelectDom> ObtenerPlazaActivo();
        //public bool CrearPlazaWrk(PlazaWrk PlazaWrk);
        //public bool ModificarPlazaWrk(PlazaWrk PlazaWrk);
        //public bool DesactivarPlazaWrk(int idPlazaWrk);
        //public PlazaWrk PlazaWrkbyId(int idPlazaWrk);

    }
}
