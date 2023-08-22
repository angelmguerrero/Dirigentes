using CPMPlataformaDirigentes.Models.ModelsConsulta;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorVwUsuarioDirigentes
    {
        public List<VwUsuarioDirigente> ObtnerVwUsuarioDirigentes();

        public VwUsuarioDirigente VwUsuarioDirigentebyID(string cif);

        public VwUsuarioDirigente VwUsuarioDirigentebyCif(string cif);

        public VwUsuarioDirigente VwUsuarioDirigentebyNombre(string nombre);

        public VwUsuarioDirigente VwUsuarioDirigentebyCuentaMexicana(string cuentaMexicana);

        public List<VwUsuarioDirigente> VwUsuarioDirigentebyNombreApellidos(VwUsuarioDirigente usuarioDirigente);

    }
}
