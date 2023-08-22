using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorMotivoBaja
    {
        public List<MotivosBajaCat> Obtener();
        public Respuesta Crear(MotivosBajaCat item);
        public Respuesta Modificar(MotivosBajaCat item);
        public bool Desactivar(int id);
        public MotivosBajaCat RegistrobyId(int id);
        public MotivosBajaCat ObtenerMotivoPorDescripcion(string descMotivo);

        public List<MotivosBajaCat> ObtenerMotivosDt();
        public List<MotivosBajaCat> ObtenerSinMotivo();
    }
}
