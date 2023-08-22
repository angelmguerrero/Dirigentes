using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorTipoPersona : IAdministradorTipoPersona
    {

        private IRepositorioTipoPersona repoTipoPersona;

        public AdministradorTipoPersona()
        {
            this.repoTipoPersona = new RepositorioTipoPersona();
        }

        public bool CrearTipoPersona(TipoPersonaCat Tipopersona)
        {
            return repoTipoPersona.CrearTipoPersona(Tipopersona);
        }

        public bool DesactivarTipoPersona(int idTipopersona)
        {
            return repoTipoPersona.DesactivarTipoPersona(idTipopersona);
        }

        public bool ModificarTipoPersona(TipoPersonaCat Tipopersona)
        {
            return repoTipoPersona.ModificarTipoPersona(Tipopersona);
        }

        public List<TipoPersonaCat> ObtenerTipoPersona()
        {
            return repoTipoPersona.ObtenerTipoPersona().ToList();

        }

        public TipoPersonaCat TipoPersonabyId(int idTipopersona)
        {
            return repoTipoPersona.ObtenerTipoPersonabyId(idTipopersona);
        }
    }
}
