using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioSelect
    {
        public List<SelectDom> GetComitesPermisoConvocar(string correo);
        public List<SelectDom> GetModalidad();
        public List<SelectCorreo> GetAsistentesNecesarios(int IdOrgano);
        public List<SelectCorreo> GetAllCorreos();
        public List<SelectCorreo> GetAsistentesConocimiento(int IdOrgano);
        public List<SelectCorreo> GetAsistentesOcultos();
        public List<SelectDom> GetOrgano(int idNivel);
        public List<SelectDom> GetCargo();
        public List<SelectDom> GetPlaza();
        public List<SelectDom> GetNivel();
        public List<FechasConvocatorias> GetHorariosConvocatoria();
        public List<string> GetCargosxOrgano(string correo, int idOrgano);
        public List<string> GetCorreoxCargo(int idOrgano, string cargo);
    }
}
