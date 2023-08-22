using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorNivelDirigencialCat : IAdministradorNivelDirigencialCat
    {
        private IRepositorioNivelDirigencialCat repoNivelDirigencialCat;

        public AdministradorNivelDirigencialCat()
        {
            this.repoNivelDirigencialCat = new RepositorioNivelDirigencialCat();
        }
        public List<NivelDirigencialCat> Obtener()
        {
            return repoNivelDirigencialCat.Obtener();
        }

        public List<NivelDirigencialCat> ObtenerActivas()
        {
            return repoNivelDirigencialCat.ObtenerActivas();
        }
        public Respuesta Crear(NivelDirigencialCat item)
        {
            return repoNivelDirigencialCat.Crear(item);
        }

        public bool Desactivar(int id)
        {
            return repoNivelDirigencialCat.Desactivar(id);
        }

        public Respuesta Modificar(NivelDirigencialCat item)
        {
            return repoNivelDirigencialCat.Modificar(item);
        }



        public NivelDirigencialCat RegistrobyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
