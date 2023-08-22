using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioPlantillaOrdenDia
    {
        public List<PlantillaOrdenDia> Obtener();
        public int Crear(PlantillaOrdenDia item);
        public Respuesta Modificar(PlantillaOrdenDia item);

        public bool Desactivar(int id);
        public PlantillaOrdenDia RegistrobyId(int id);
        public PlantillaOrdenDia ObtenerPlantillaPorDescripcion(string descMotivo);
        public List<PlantillaOrdenDiaJunta> ObtenerPlantillaOrdenDiaDt();

        public bool EliminarPlantilla(int id);
        public int ObtenerIdPlantillaPorTipodeJunta(int id);


    }
}
