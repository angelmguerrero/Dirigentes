using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorEstatusAcuerdo
    {
        public List<EstatusAcuerdosCat> Obtener();
        public Respuesta Crear(EstatusAcuerdosCat item);
        public Respuesta Modificar(EstatusAcuerdosCat item);
        public bool Desactivar(int item);
        public EstatusAcuerdosCat RegistrobyId(int item);

        public EstatusAcuerdosCat ObtenerEstatusAcuerdoPorDescripcion(string descAcuerdo);
    }
}
