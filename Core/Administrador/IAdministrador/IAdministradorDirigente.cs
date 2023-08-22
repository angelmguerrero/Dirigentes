using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorDirigente
    {
        public List<Dirigente> ObtenerDirigente();
        public bool CrearDirigente(Dirigente dirigente);
        public bool ModificarDirigente(Dirigente dirigente);
        public bool DesactivarDirigente(int idDirigente);
        public Dirigente DirigentebyId(int idDirigente);

    }
}
