using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorPlazaWrk : IAdministradorPlazaWrk
    {
        private IRepositorioPlazaWrk repoPlazaWrk;
        public AdministradorPlazaWrk()
        {
            this.repoPlazaWrk = new RepositorioPlazaWrk();
        }

        public List<PlazaWrk> ObtenerPlazaWrks()
        {
            return repoPlazaWrk.ObtenerPlazaWrks();
        }

        public List<SelectDom> ObtenerPlazaActivo()
        {
            return repoPlazaWrk.ObtenerPlazaActivo();
        }

        //public bool CrearPlazaWrk(PlazaWrk PlazaWrk)
        //{
        //    return repoPlazaWrk.CrearPlazaWrk(PlazaWrk);
        //}

        //public bool ModificarPlazaWrk(PlazaWrk PlazaWrk)
        //{
        //    return repoPlazaWrk.ModificarPlazaWrk(PlazaWrk);
        //}

        //public bool DesactivarPlazaWrk(int idPlazaWrk)
        //{
        //    return repoPlazaWrk.DesactivarPlazaWrk(idPlazaWrk);
        //}

        //public PlazaWrk PlazaWrkbyId(int idPlazaWrk)
        //{
        //    return repoPlazaWrk.PlazaWrkbyId(idPlazaWrk);
        //}


    }
}
