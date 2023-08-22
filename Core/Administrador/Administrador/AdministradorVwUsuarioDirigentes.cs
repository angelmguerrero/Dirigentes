using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPMPlataformaDirigentes.Models.ModelsConsulta;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorVwUsuarioDirigentes : IAdministradorVwUsuarioDirigentes
    {
        private IRepositorioVwUsuarioDirigentes repoVwUsuarioDirigentes;
        public AdministradorVwUsuarioDirigentes()
        {
            this.repoVwUsuarioDirigentes = new RepositorioVwUsuarioDirigentes();
        }
        public List<VwUsuarioDirigente> ObtnerVwUsuarioDirigentes()
        {
            return repoVwUsuarioDirigentes.ObtnerVwUsuarioDirigentes();
        }

        public VwUsuarioDirigente VwUsuarioDirigentebyID(string cif)
        {
            return repoVwUsuarioDirigentes.VwUsuarioDirigentebyID(cif);
        }

        public VwUsuarioDirigente VwUsuarioDirigentebyCif(string cif)
        {
            return repoVwUsuarioDirigentes.VwUsuarioDirigentebyCif(cif);
        }

        public VwUsuarioDirigente VwUsuarioDirigentebyNombre(string nombre)
        {
            return repoVwUsuarioDirigentes.VwUsuarioDirigentebyNombre(nombre);
        }

        public VwUsuarioDirigente VwUsuarioDirigentebyCuentaMexicana(string cuentaMexicana)
        {
            return repoVwUsuarioDirigentes.VwUsuarioDirigentebyCuentaMexicana(cuentaMexicana);
        }

        public List<VwUsuarioDirigente> VwUsuarioDirigentebyNombreApellidos(VwUsuarioDirigente usuarioDirigente)
        {
            return repoVwUsuarioDirigentes.VwUsuarioDirigentebyNombreApellidos(usuarioDirigente);
        }
    }
}
