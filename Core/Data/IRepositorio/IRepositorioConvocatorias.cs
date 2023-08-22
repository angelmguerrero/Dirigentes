using CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioConvocatorias
    {
        public List<CalendarioDom> GetConvocatorias(string correo);
        public Task<Respuesta> CrearConvocatoria(ConvocatoriaDom convocatoria);
        public List<RelMeetingOrdenDiumDom> ObtenerOrdenDiaPorIdConvocatoria(int id);
        public List<RelMeetingOrdenDiumDom> RegistrobyIdPadre(int idConvocatoria, int idPadre);
        public ConvocatoriaDom GetConvocatoria(int idConvocatoria);
        public Task<Respuesta> ModificarConvocatoria(ConvocatoriaDom convocatoria);
    }
}
