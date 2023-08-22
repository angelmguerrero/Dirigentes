using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioPersonaSolicitudHist
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
