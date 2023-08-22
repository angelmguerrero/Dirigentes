using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.Plaza;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorPlaza : IAdministradorPlaza
    {
        private IRepositorioPlaza repoPlaza;
        public AdministradorPlaza()
        {
            this.repoPlaza = new RepositorioPlaza();
        }

        public List<PlazaCat> ObtenerPlazas()
        {
            return repoPlaza.ObtenerPlazas();
        }

        public PlazaCat PlazabyId(int idPlaza)
        {
            return repoPlaza.PlazabyId(idPlaza);
        }

        public List<PlazaDom> ObtenerPlazaDom()
        {
            return repoPlaza.ObtenerPlazaDom();
        }

        public List<SelectDom> ObtenerRegiones()
        {
            return repoPlaza.ObtenerRegiones();
        }

    }
}
