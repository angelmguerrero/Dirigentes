using CPMPlataformaDirigentes.Models.ModelsConsulta;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorVwInfoSocios
    {
        public List<VwInfoSocio> ObtnerVwInfoSocios();

        public VwInfoSocio VwInfoSociobyID(string cif);


    }
}
