using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio
{
    public interface IRepositorioEstatusAcuerdo
    {

        public List<EstatusAcuerdosCat> Obtener();
        public Respuesta Crear(EstatusAcuerdosCat genero);
        public Respuesta Modificar(EstatusAcuerdosCat genero);
        public bool Desactivar(int id);
        public EstatusAcuerdosCat RegistrobyId(int idgenero);

        public EstatusAcuerdosCat ObtenerEstatusAcuerdoPorDescripcion(string estatus);

    }
}
