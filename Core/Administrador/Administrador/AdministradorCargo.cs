using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorCargo : IAdministradorCargo
    {
        private IRepositorioCargo repoCargo;
        public AdministradorCargo()
        {
            this.repoCargo = new RepositorioCargo();
        }
        public List<CargoCat> ObtenerCargos()
        {
            return repoCargo.ObtenerCargos();
        }

        public bool CrearCargo(CargoCat cargo)
        {


            return repoCargo.CrearCargo(cargo);
        }

        public bool ModificarCargo(CargoCat cargo)
        {
            return repoCargo.ModificarCargo(cargo);
        }
        public bool DesactivarCargo(int idCargo)
        {
            return repoCargo.DesactivarCargo(idCargo);
        }

        public CargoCat CargobyId(int idcargo)
        {
            return repoCargo.CargobyId(idcargo);
        }
    }
}
