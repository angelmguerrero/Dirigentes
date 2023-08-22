using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioDiasParametrizables
    {
        public List<DiasParametrizablesCat> Obtener();
        public Respuesta Crear(DiasParametrizablesCat item);
        public Respuesta Modificar(DiasParametrizablesCat item);

        public bool Desactivar(int id);

        public DiasParametrizablesCat RegistrobyId(int id);
        public DiasParametrizablesCat ObtenerDiasParamPorDescripcion(string descDias);

    }
}
