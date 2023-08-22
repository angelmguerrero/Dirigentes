using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorCargo
    {
        public List<CargoCat> ObtenerCargos();
        public bool CrearCargo(CargoCat cargo);
        public bool ModificarCargo(CargoCat cargo);
        public bool DesactivarCargo(int idCargo);
        public CargoCat CargobyId(int idcargo);

    }
}
