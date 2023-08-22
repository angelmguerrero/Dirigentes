using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorSolicitud : IAdministradorSolicitud
    {
        private IRepositorioSolicitud repositorioSolicitud;

        public AdministradorSolicitud()
        {
            this.repositorioSolicitud = new RepositorioSolicitud();
        }
        public Solicitud CrearSolicitud(Solicitud solicitud)
        {
            return repositorioSolicitud.CrearSolicitud(solicitud);
        }


        public bool DesactivarSolicitud(int idsolicitud)
        {
            return repositorioSolicitud.DesactivarSolicitud(idsolicitud);
        }

        public bool ModificarSolicitud(Solicitud solicitud)
        {
            return repositorioSolicitud.ModificarSolicitud(solicitud);
        }

        public List<Solicitud> ObtenerSolicitud()
        {
            return repositorioSolicitud.ObtenerSolicitud();
        }

        public List<SolicitudPersonaResponsable> ObtenerSolicitudPersonaResponsable()
        {
            return repositorioSolicitud.ObtenerSolicitudPersonaResponsable();
        }
        public List<SolicitudPersonaResponsable> ConsultarSolicitudesbyIdresponsable(int idPersonaresponsable)
        {
            return repositorioSolicitud.ConsultarSolicitudesbyIdresponsable(idPersonaresponsable);
        }

        public Solicitud SolicitudbyId(int idsolicitud)
        {
            return repositorioSolicitud.SolicitudbyId(idsolicitud);
        }

        public SolicitudPersonaResponsable SolicitudpersonaResponsablebyId(int idsolicitud)
        {
            return repositorioSolicitud.SolicitudpersonaResponsablebyId(idsolicitud);
        }

        public bool EnviarNotificacionSolicitudCreacion(int idSolicitud, string correoAcceso)
        {
            return repositorioSolicitud.EnviarNotificacionSolicitudCreacion(idSolicitud, correoAcceso);
        }

        public bool EnviarNotificacionSolicitudAutorizacion(int idSolicitud, string correoAcceso)
        {
            return repositorioSolicitud.EnviarNotificacionSolicitudAutorizacion(idSolicitud, correoAcceso);
        }

        public bool EnviarNotificacionSolicitudObservaciones(int idSolicitud, string correoAcceso)
        {
            return repositorioSolicitud.EnviarNotificacionSolicitudObservaciones(idSolicitud, correoAcceso);
        }
        public PersonaSolicitud SolicitudpersonaResponsablebyCif(int cif)
        {
            return repositorioSolicitud.SolicitudpersonaResponsablebyCif(cif);
        }
    }
}
