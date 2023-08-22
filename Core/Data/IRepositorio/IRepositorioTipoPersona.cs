using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioTipoPersona
    {
        public List<TipoPersonaCat> ObtenerTipoPersona();
        public bool CrearTipoPersona(TipoPersonaCat tipoPersona);
        public bool ModificarTipoPersona(TipoPersonaCat tipoPersona);

        public bool DesactivarTipoPersona(int idtipoPersona);

        public TipoPersonaCat ObtenerTipoPersonabyId(int idtipoPersona);
    }
}
