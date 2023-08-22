using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioDetallePlantillaOrdenDia
    {
        public List<DetallePlantillaOrdenDiaDom> RegistrobyId(int id);

        public int Crear(DetallePlantillaOrdenDiaDom item);
        public Respuesta Modificar(DetallePlantillaOrdenDiaDom item);

        public bool Desactivar(DetallePlantillaOrdenDiaDom item);
        public DetallePlantillaOrdenDia ObtenerPlantillaPorDescripcion(string descMotivo);

        public List<DetallePlantillaOrdenDiaDom> RegistrobyIdPadre(int idPlantilla, int idPadre);

        public DetallePlantillaOrdenDiaDom ObtenerUltimoIdPadre(int idPlantilla);

        public bool EliminarNivelPorId(int id);
    }
}
