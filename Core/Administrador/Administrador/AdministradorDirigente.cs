using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorDirigente : IAdministradorDirigente
    {
        private IRepositorioDirigente repoDirigente;
        public AdministradorDirigente()
        {
            this.repoDirigente = new RepositorioDirigente();
        }

        public bool CrearDirigente(Dirigente dirigente)
        {
            return repoDirigente.CrearDirigente(dirigente);
        }

        public bool DesactivarDirigente(int idDirigente)
        {
            return repoDirigente.DesactivarDirigente(idDirigente);
        }

        public Dirigente DirigentebyId(int idDirigente)
        {
            return repoDirigente.DirigentebyId(idDirigente);
        }

        public bool ModificarDirigente(Dirigente dirigente)
        {
            return repoDirigente.ModificarDirigente(dirigente);
        }

        public List<Dirigente> ObtenerDirigente()
        {
            return repoDirigente.ObtenerDirigente();
        }
    }
}
