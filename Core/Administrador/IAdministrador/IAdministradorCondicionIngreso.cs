using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador
{
    public interface IAdministradorCondicionIngreso
    {
        public List<CondicionIngresoCat> Obtener();
        public List<CondicionIngresoCat> ObtenerActivas();
        public Respuesta Crear(CondicionIngresoCat item);
        public Respuesta Modificar(CondicionIngresoCat item);
        public bool Desactivar(int id);
        public CondicionIngresoCat RegistrobyId(int id);
        public CondicionIngresoCat ObtenerCondicionPorDescripcion(string condicion);


    }
}
