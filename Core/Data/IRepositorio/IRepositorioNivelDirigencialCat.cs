using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioNivelDirigencialCat
    {


        public List<NivelDirigencialCat> Obtener();
        public List<NivelDirigencialCat> ObtenerActivas();
        public Respuesta Crear(NivelDirigencialCat item);
        public Respuesta Modificar(NivelDirigencialCat item);

        public bool Desactivar(int id);
        public NivelDirigencialCat RegistrobyId(int id);



    }
}
