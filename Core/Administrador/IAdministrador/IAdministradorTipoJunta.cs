using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorTipoJunta
    {
        public List<TipoJuntaCat> Obtener();
        public Respuesta Crear(TipoJuntaCat item);
        public Respuesta Modificar(TipoJuntaCat item);
        public bool Desactivar(int id);
        public TipoJuntaCat RegistrobyId(int id);
        public TipoJuntaCat ObtenerTipoJuntaPorDescripcion(string desctipo);
        public List<SelectDom> ObtenerTiposJuntaActivo();
    }
}
