using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioTipoJunta
    {
        public List<TipoJuntaCat> Obtener();
        public Respuesta Crear(TipoJuntaCat iten);
        public Respuesta Modificar(TipoJuntaCat item);

        public bool Desactivar(int id);
        public TipoJuntaCat RegistrobyId(int id);
        public TipoJuntaCat ObtenerTipoJuntaPorDescripcion(string descTipo);
        public List<SelectDom> ObtenerTipoJuntaActivo();
    }
}
