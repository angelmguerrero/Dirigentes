using CPMPlataformaDirigentes.Models.ModelsConsulta;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioVwInfoSocios
    {

        public List<VwInfoSocio> ObtnerVwInfoSocios();

        public VwInfoSocio VwInfoSociobyID(string cif);

    }
}
