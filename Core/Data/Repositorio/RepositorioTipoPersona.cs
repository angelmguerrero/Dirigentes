using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioTipoPersona : IRepositorioTipoPersona
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioTipoPersona()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }

        public List<TipoPersonaCat> ObtenerTipoPersona()
        {
            return context.TipoPersonaCats.ToList();

        }
        public bool CrearTipoPersona(TipoPersonaCat tipopersona)
        {
            try
            {

                tipopersona.EstatusTipoPersona = true;
                context.TipoPersonaCats.Add(tipopersona);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ModificarTipoPersona(TipoPersonaCat tipopersona)
        {
            var _tipopersona = context.TipoPersonaCats.Where(c => c.IdTipoPersona == tipopersona.IdTipoPersona).SingleOrDefault();
            if (_tipopersona == null)
                return false;




            _tipopersona.Descripcion = tipopersona.Descripcion;
            _tipopersona.EstatusTipoPersona = tipopersona.EstatusTipoPersona;
            context.SaveChanges();

            return true;
        }

        public bool DesactivarTipoPersona(int tipopersona)
        {
            var _tipopersona = context.TipoPersonaCats.Where(x => x.IdTipoPersona == tipopersona).SingleOrDefault();
            if (_tipopersona == null)
                return false;

            _tipopersona.EstatusTipoPersona = false;
            context.SaveChanges();
            return true;
        }

        public TipoPersonaCat ObtenerTipoPersonabyId(int idtipopersona)
        {
            var tipopersona = context.TipoPersonaCats.Where(x => x.IdTipoPersona == idtipopersona).FirstOrDefault();
            if (tipopersona == null)
                return null;
            else
                return tipopersona;
        }

    }
}
