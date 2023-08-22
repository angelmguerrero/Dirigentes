using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorTipoBaja
    {
        public List<TipoBaja> Obtener();
        public List<TipoBaja> ObtenerActivas();
        public Respuesta Crear(TipoBaja item);
        public Respuesta Modificar(TipoBaja item);
        public bool Desactivar(int id);
        public TipoBaja RegistrobyId(int id);
        public TipoBaja ObtenerTipoPorDescripcion(string descTipo);
    }
}
