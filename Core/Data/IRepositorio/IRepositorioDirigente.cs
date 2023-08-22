using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioDirigente
    {
        public List<Dirigente> ObtenerDirigente();
        public bool CrearDirigente(Dirigente dirigente);
        public bool ModificarDirigente(Dirigente dirigente);
        public bool DesactivarDirigente(int idDirigente);
        public Dirigente DirigentebyId(int idDirigente);

    }
}
