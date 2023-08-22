using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPMPlataformaDirigentes.Models.ModelsConsulta;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorVwInfoSocios : IAdministradorVwInfoSocios
    {
        private IRepositorioVwInfoSocios repoVwInfoSocios;
        public AdministradorVwInfoSocios()
        {
            this.repoVwInfoSocios = new RepositorioVwInfoSocios();
        }
        public List<VwInfoSocio> ObtnerVwInfoSocios()
        {
            return repoVwInfoSocios.ObtnerVwInfoSocios();
        }

        public VwInfoSocio VwInfoSociobyID(string cif)
        {
            return repoVwInfoSocios.VwInfoSociobyID(cif);
        }
    }
}
