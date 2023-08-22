using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioNivelDirigencial
    {
        public List<NivelDirigencial> Obtener();
        public List<NivelDirigencial> ObtenerActivas();
        public Respuesta Crear(NivelDirigencial item);
        public Respuesta Modificar(NivelDirigencial item);
        public Respuesta CrearOModificar(NivelDirigencial item);

        public bool Desactivar(int id);
        public NivelDirigencial RegistrobyId(int id);

        public NivelDirigencial RegistrobyIdPersona(int idPersona);
    }
}
