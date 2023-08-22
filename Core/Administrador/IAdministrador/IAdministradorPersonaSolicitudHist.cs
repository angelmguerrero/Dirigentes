using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorPersonaSolicitudHist
    {
        public List<PersonaSolicitudHist> ObtenerPersonaSolicitudHist();
        public bool Crear(PersonaSolicitudHist persona);
        public bool ModificarPersonaSolicitudHist(PersonaSolicitudHist persona);

        public bool DesactivarPersonaSolicitudHist(int idPersonaSolicitudHist);
        public PersonaSolicitudHist PersonaSolicitudHistbyId(int idPersonaSolicitudHist);

        public PersonaSolicitudHistorico PersonaSolicitudHistbyIdsolicitud(int idSolicitudHist);
        public PersonaCatvsPersonaSoli CompararPersonaSolicitudHistbyIdsolicitud(int idSolicitudHist);

    }
}
