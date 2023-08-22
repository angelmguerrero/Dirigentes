using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorTipoPersona
    {
        public List<TipoPersonaCat> ObtenerTipoPersona();
        public bool CrearTipoPersona(TipoPersonaCat Tipopersona);
        public bool ModificarTipoPersona(TipoPersonaCat Tipopersona);
        public bool DesactivarTipoPersona(int idTipopersona);
        public TipoPersonaCat TipoPersonabyId(int idTipopersona);
    }
}
