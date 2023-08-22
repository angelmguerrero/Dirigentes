using CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioSolicitud
    {
        public List<Solicitud> ObtenerSolicitud();
        public List<SolicitudPersonaResponsable> ObtenerSolicitudPersonaResponsable();

        public List<SolicitudPersonaResponsable> ConsultarSolicitudesbyIdresponsable(int idPersonaresponsable);
        public Solicitud CrearSolicitud(Solicitud solicitud);

        public bool ModificarSolicitud(Solicitud solicitud);
        public bool DesactivarSolicitud(int idsolicitud);
        public bool EnviarNotificacionSolicitudCreacion(int idSolicitud, string correoAcceso);
        public bool EnviarNotificacionSolicitudAutorizacion(int idSolicitud, string correoAcceso);
        public bool EnviarNotificacionSolicitudObservaciones(int idSolicitud, string correoAcceso);
        public Solicitud SolicitudbyId(int idsolicitud);
        public SolicitudPersonaResponsable SolicitudpersonaResponsablebyId(int idsolicitud);
        public PersonaSolicitud SolicitudpersonaResponsablebyCif(int cif);
    }
}
