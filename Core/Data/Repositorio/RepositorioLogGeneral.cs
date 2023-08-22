using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioLogGeneral : IRepositorioLogGeneral
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioLogGeneral()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }


        public bool CrearLogGeneral(LogGeneral logGeneral)
        {

            try
            {
                context.LogGenerals.Add(logGeneral);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
