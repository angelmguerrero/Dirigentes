using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorNivelDirigencial : IAdministradorNivelDirigencial
    {
        private IRepositorioNivelDirigencial repo;
        public AdministradorNivelDirigencial()
        {
            this.repo = new RepositorioNivelDirigencial();
        }
        public List<NivelDirigencial> Obtener()
        {
            return repo.Obtener();
        }

        public List<NivelDirigencial> ObtenerActivas()
        {
            return repo.ObtenerActivas();
        }
        public Respuesta Crear(NivelDirigencial item)
        {
            return repo.Crear(item);
        }

        public bool Desactivar(int id)
        {
            return repo.Desactivar(id);
        }
        public Respuesta CrearOModificar(NivelDirigencial item)
        {
            return repo.CrearOModificar(item);
        }
        public Respuesta Modificar(NivelDirigencial item)
        {
            return repo.Modificar(item);
        }

        public NivelDirigencial RegistrobyId(int id)
        {
            return repo.RegistrobyId(id);
        }
        public NivelDirigencial RegistrobyIdPersona(int idPersona)
        {
            return repo.RegistrobyIdPersona(idPersona);
        }
    }
}
