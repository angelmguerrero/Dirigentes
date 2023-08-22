using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioMotivosBaja
    {
        public List<MotivosBajaCat> Obtener();
        public Respuesta Crear(MotivosBajaCat iten);
        public Respuesta Modificar(MotivosBajaCat item);

        public bool Desactivar(int id);
        public MotivosBajaCat RegistrobyId(int id);
        public MotivosBajaCat ObtenerMotivoPorDescripcion(string descMotivo);
        public List<MotivosBajaCat> ObtenerMotivosDt();
        public List<MotivosBajaCat> ObtenerSinMotivo();

    }
}
