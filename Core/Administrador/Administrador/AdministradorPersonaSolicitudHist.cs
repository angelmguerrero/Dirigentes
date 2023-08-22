using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorPersonaSolicitudHist : IAdministradorPersonaSolicitudHist
    {
        private IRepositorioPersonaSolicitudHist repoPersonaSolicitud;
        public AdministradorPersonaSolicitudHist()
        {
            this.repoPersonaSolicitud = new RepositorioPersonaSolicitudHist();
        }

        public PersonaCatvsPersonaSoli CompararPersonaSolicitudHistbyIdsolicitud(int idSolicitudHist)
        {
            return repoPersonaSolicitud.CompararPersonaSolicitudHistbyIdsolicitud(idSolicitudHist);
        }

        public bool Crear(PersonaSolicitudHist persona)
        {
            return repoPersonaSolicitud.Crear(persona);
        }

        public bool DesactivarPersonaSolicitudHist(int idPersonaSolicitudHist)
        {
            return repoPersonaSolicitud.DesactivarPersonaSolicitudHist(idPersonaSolicitudHist);
        }

        public bool ModificarPersonaSolicitudHist(PersonaSolicitudHist persona)
        {
            return repoPersonaSolicitud.ModificarPersonaSolicitudHist(persona);
        }

        public List<PersonaSolicitudHist> ObtenerPersonaSolicitudHist()
        {
            return repoPersonaSolicitud.ObtenerPersonaSolicitudHist();
        }

        public PersonaSolicitudHist PersonaSolicitudHistbyId(int idPersonaSolicitudHist)
        {
            return repoPersonaSolicitud.PersonaSolicitudHistbyId(idPersonaSolicitudHist);
        }
        public PersonaSolicitudHistorico PersonaSolicitudHistbyIdsolicitud(int idSolicitudHist)
        {
            return repoPersonaSolicitud.PersonaSolicitudHistbyIdsolicitud(idSolicitudHist);
        }
    }
}
