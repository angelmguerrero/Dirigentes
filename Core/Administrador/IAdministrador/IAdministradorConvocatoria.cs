using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorConvocatoria
    {
        public List<SelectDom> GetComitesPermisoConvocar(string correo);
        public List<CalendarioDom> GetConvocatorias(string correo);
        public List<SelectDom> GetModalidad();
        public List<SelectCorreo> GetAsistentesNecesarios(int IdOrgano);
        public List<SelectCorreo> GetAllCorreos();
        public List<SelectCorreo> GetAsistentesConocimiento(int IdOrgano);
        public List<SelectCorreo> GetAsistentesOcultos();
        public Task<Respuesta> CrearConvocatoria(ConvocatoriaDom convocatoria);
        public List<FechasConvocatorias> GetHorariosConvocatoria();
        public List<RelMeetingOrdenDiumDom> ObtenerOrdenDiaPorIdConvocatoria(int id);
        public ConvocatoriaDom GetConvocatoriaEdit(int idConvocatoria);
        public Respuesta AutorizarConvocatoria(int idConvocatoria, string correo);
        public Respuesta CancelarConvocatoria(int idConvocatoria, string correo);
        public Respuesta AprobarConvocatoria(int idConvocatoria, string correo);
        public int GetEstatusConvocatoria(int idConvocatoria);


    }
}
