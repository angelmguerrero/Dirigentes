using CPMPlataformaDirigentes.Models.ModelsConsulta;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioVwUsuarioDirigentes
    {

        public List<VwUsuarioDirigente> ObtnerVwUsuarioDirigentes();

        public VwUsuarioDirigente VwUsuarioDirigentebyID(string cif);

        public VwUsuarioDirigente VwUsuarioDirigentebyCif(string cif);

        public VwUsuarioDirigente VwUsuarioDirigentebyNombre(string nombre);

        public VwUsuarioDirigente VwUsuarioDirigentebyCuentaMexicana(string cuentaMexicana);

        public List<VwUsuarioDirigente> VwUsuarioDirigentebyNombreApellidos(VwUsuarioDirigente usuarioDirigente);
    }
}
