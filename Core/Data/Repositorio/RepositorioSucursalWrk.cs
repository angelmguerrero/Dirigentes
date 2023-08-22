using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPMPlataformaDirigentes.Data.Contexto;
using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioSucursalWrk : IRepositorioSucursalWrk
    {
        private CPMDirectorioSucursalesContext context;
        public RepositorioSucursalWrk()
        {
            this.context = new CPMDirectorioSucursalesContext(Configuracion.GetConnectionString());
        }

        public List<SucursalWrk> ObtenerSucursalWrks()
        {
            return context.SucursalWrks.ToList();
        }

        public List<SucursalWrk> ObtenerSucursalWrksbyIdPlaza(int IdPlaza)
        {
            var SucursalWrk = (from pla1 in context.PlazaWrks
                               join suc2 in context.SucursalWrks
                               on pla1.IdPlaza equals suc2.IdPlaza
                               where pla1.IdPlaza == IdPlaza

                               select new SucursalWrk

                               {
                                   IdSucursal = suc2.IdSucursal,
                                   Nombre = suc2.Nombre,
                                   Activo = suc2.Activo

                               }).ToList();

            return SucursalWrk;
        }

        public bool CrearSucursalWrk(SucursalWrk SucursalWrk)
        {
            try
            {
                context.SucursalWrks.Add(SucursalWrk);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarSucursalWrk(SucursalWrk SucursalWrk)
        {
            var _SucursalWrk = context.SucursalWrks.Where(x => x.IdSucursal == SucursalWrk.IdSucursal).SingleOrDefault();
            if (_SucursalWrk == null)
                return false;

            _SucursalWrk.IdSucursal = SucursalWrk.IdSucursal;
            _SucursalWrk.Nombre = SucursalWrk.Nombre;
            _SucursalWrk.IdPlaza = SucursalWrk.IdPlaza;
            _SucursalWrk.Activo = SucursalWrk.Activo;
            _SucursalWrk.CentroCostos = SucursalWrk.CentroCostos;
            context.SaveChanges();

            return true;
        }

        public bool DesactivarSucursalWrk(int idSucursalWrk)
        {
            var _SucursalWrk = context.SucursalWrks.Where(x => x.IdSucursal == idSucursalWrk).SingleOrDefault();
            if (_SucursalWrk == null)
                return false;

            _SucursalWrk.Activo = false;
            context.SaveChanges();
            return true;
        }

        public SucursalWrk SucursalWrkbyId(int idSucursalWrk)
        {
            var SucursalWrk = context.SucursalWrks.Where(x => x.IdSucursal == idSucursalWrk).FirstOrDefault();

            if (SucursalWrk == null)
                return null;
            else
                return SucursalWrk;

        }





    }
}
