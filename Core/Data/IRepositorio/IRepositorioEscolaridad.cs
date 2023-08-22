using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioEscolaridad
    {

        public List<EscolaridadCat> ObtenerEscolaridades();
        public Respuesta CrearEscolaridad(EscolaridadCat escolaridad);
        public Respuesta ModificarEscolaridad(EscolaridadCat escolaridad);

        public bool DesactivarEscolaridad(int escolaridad);

        public EscolaridadCat ObtenerEscolaridad(int idescolaridad);

        public EscolaridadCat ObtenerEscolaridadPorDescripcion(string descEscolaridad);

        public List<SelectDom> ObtenerEscolaridadActivo();
    }
}
