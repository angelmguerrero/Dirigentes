using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioCargo
    {
        public List<CargoCat> ObtenerCargos();
        public bool CrearCargo(CargoCat cargo);
        public bool ModificarCargo(CargoCat cargo);

        public bool DesactivarCargo(int idCargo);
        public CargoCat CargobyId(int idcargo);
    }
}
