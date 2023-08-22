using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioCargo : IRepositorioCargo
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioCargo()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }
        public List<CargoCat> ObtenerCargos()
        {
            return context.CargoCats.ToList();
        }
        public bool CrearCargo(CargoCat cargo)
        {
            try
            {
                cargo.EstatusCargo = true;
                context.CargoCats.Add(cargo);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ModificarCargo(CargoCat cargo)
        {
            var _cargo = context.CargoCats.Where(x => x.IdCargo == cargo.IdCargo).SingleOrDefault();
            if (_cargo == null)
                return false;

            _cargo.Descripcion = cargo.Descripcion;
            _cargo.EstatusCargo = cargo.EstatusCargo;
            _cargo.OrdenCargo = cargo.OrdenCargo;
            context.SaveChanges();

            return true;
        }
        public bool DesactivarCargo(int idCargo)
        {
            var _cargo = context.CargoCats.Where(x => x.IdCargo == idCargo).SingleOrDefault();
            if (_cargo == null)
                return false;

            _cargo.EstatusCargo = false;
            context.SaveChanges();
            return true;
        }

        public CargoCat CargobyId(int idcargo)
        {
            var cargo = context.CargoCats.Where(x => x.IdCargo == idcargo).FirstOrDefault();

            if (cargo == null)
                return null;
            else
                return cargo;

        }


    }
}
