using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorPlantillaOrdenDia
    {

        public List<PlantillaOrdenDia> Obtener();
        public Respuesta Crear(PlantillaOrdenDiaDetalles plantilla);
        public Respuesta Modificar(PlantillaOrdenDiaDetalles plantilla);
        public bool Desactivar(int plantilla);

        public PlantillaOrdenDia RegistrobyId(int idplantilla);

        public PlantillaOrdenDia ObtenerPlantillaPorDescripcion(string descPlantilla);
        public List<PlantillaOrdenDiaJunta> ObtenerPlantillaOrdenDiaDt();
    }
}
