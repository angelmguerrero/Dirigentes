using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPMPlataformaDirigentes.Models.ModelsConsulta;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioVwInfoSocios : IRepositorioVwInfoSocios
    {
        private ConsultaCPMContext context;
        public RepositorioVwInfoSocios()
        {
            this.context = new ConsultaCPMContext(
            Configuracion.GetConnectionConsultaCpmString());
        }
        public List<VwInfoSocio> ObtnerVwInfoSocios()
        {
            return context.VwInfoSocios.ToList();
        }

        public VwInfoSocio VwInfoSociobyID(string cif)
        {
            var VwInfoSocio = context.VwInfoSocios.Where(x => x.Cif == cif.PadLeft(10, '0')).FirstOrDefault();
            if (VwInfoSocio == null)
                return null;
            else
                return VwInfoSocio;
        }
    }
}
