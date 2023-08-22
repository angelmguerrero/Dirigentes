using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioTipoBaja
    {

        public List<TipoBaja> Obtener();
        public List<TipoBaja> ObtenerActivas();
        public Respuesta Crear(TipoBaja iten);
        public Respuesta Modificar(TipoBaja item);

        public bool Desactivar(int id);
        public TipoBaja RegistrobyId(int id);
        public TipoBaja ObtenerTipoPorDescripcion(string descTipo);


    }

}
