using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorLogGeneral : IAdministradorLogGeneral
    {
        private IRepositorioLogGeneral repoLogGeneral;
        public AdministradorLogGeneral()
        {
            this.repoLogGeneral = new RepositorioLogGeneral();
        }

        public bool CrearLogGeneral(LogGeneral logGeneral)
        {
            return repoLogGeneral.CrearLogGeneral(logGeneral);
        }


    }
}
