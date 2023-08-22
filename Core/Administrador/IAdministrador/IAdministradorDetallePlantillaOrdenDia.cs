using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorDetallePlantillaOrdenDia
    {

        public List<DetallePlantillaOrdenDiaDom> RegistrobyId(int id);

        public Respuesta Crear(List<DetallePlantillaOrdenDiaDom> item, int idPLantilla);
        public Respuesta Modificar(List<DetallePlantillaOrdenDiaDom> item);

        public bool Desactivar(List<DetallePlantillaOrdenDiaDom> detalle);
        public DetallePlantillaOrdenDia ObtenerPlantillaPorDescripcion(string descMotivo);

        public int ObtenerUltimoIdPadre(int idPlantilla);

        public Respuesta ValidarVacios(List<DetallePlantillaOrdenDiaDom> item);

        public List<DetallePlantillaOrdenDiaDom> PlantillaPorIdTipoJunta(int id);

        public int ObtenerIdPadrePorTipoJunta(int id);
    }
}
