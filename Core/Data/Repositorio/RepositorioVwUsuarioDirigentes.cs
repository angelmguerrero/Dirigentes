using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPMPlataformaDirigentes.Models.ModelsConsulta;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioVwUsuarioDirigentes : IRepositorioVwUsuarioDirigentes
    {
        private ConsultaCPMContext context;
        public RepositorioVwUsuarioDirigentes()
        {
            this.context = new ConsultaCPMContext(
            Configuracion.GetConnectionConsultaCpmString());
        }
        public List<VwUsuarioDirigente> ObtnerVwUsuarioDirigentes()
        {
            return context.VwUsuarioDirigentes.ToList();
        }

        public VwUsuarioDirigente VwUsuarioDirigentebyID(string cif)
        {
            cif = cif.PadLeft(10, '0').ToString();
            var VwUsuarioDirigente = context.VwUsuarioDirigentes.Where(x => x.Cif == cif).FirstOrDefault();
            if (VwUsuarioDirigente == null)
                return null;
            else
                return VwUsuarioDirigente;
        }

        public VwUsuarioDirigente VwUsuarioDirigentebyCif(string cif)
        {
            cif = cif.PadLeft(10, '0');
            var VwUsuarioDirigente = context.VwUsuarioDirigentes.Where(x => x.Cif == cif.ToString()).FirstOrDefault();
            if (VwUsuarioDirigente == null)
                return null;
            else
                return VwUsuarioDirigente;
        }

        public VwUsuarioDirigente VwUsuarioDirigentebyNombre(string nombre)
        {
            // Checar por ApPAterno + ApMaterno + Nombre
            var VwUsuarioDirigente = context.VwUsuarioDirigentes.Where(x => x.NombreCompleto.Contains(nombre)).FirstOrDefault();
            if (VwUsuarioDirigente == null)
                return null;
            else
                return VwUsuarioDirigente;
        }

        public VwUsuarioDirigente VwUsuarioDirigentebyCuentaMexicana(string cuentaMexicana)
        {
            var VwUsuarioDirigente = context.VwUsuarioDirigentes.Where(x => x.CuentaMexicana == cuentaMexicana).FirstOrDefault();
            if (VwUsuarioDirigente == null)
                return null;
            else
                return VwUsuarioDirigente;
        }

        public List<VwUsuarioDirigente> VwUsuarioDirigentebyNombreApellidos(VwUsuarioDirigente usuarioDirigente)
        {
            // Checar por ApPAterno + ApMaterno + Nombre
            var VwUsuarioDirigente = context.VwUsuarioDirigentes.Where(x => x.Nombre == usuarioDirigente.Nombre && x.ApellidoPaterno == usuarioDirigente.ApellidoPaterno && x.ApellidoMaterno == usuarioDirigente.ApellidoMaterno).ToList();
            if (VwUsuarioDirigente == null)
                return null;
            else
                return VwUsuarioDirigente;
        }
    }
}
