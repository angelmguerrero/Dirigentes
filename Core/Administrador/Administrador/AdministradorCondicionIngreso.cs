using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorCondicionIngreso : IAdministradorCondicionIngreso
    {
        private IRepositorioCondicionIngreso repo;
        public AdministradorCondicionIngreso()
        {
            this.repo = new RepositorioCondicionIngreso();
        }
        public List<CondicionIngresoCat> Obtener()
        {
            return repo.Obtener();
        }
        public List<CondicionIngresoCat> ObtenerActivas()
        {
            return repo.ObtenerActivas();
        }
        public Respuesta Crear(CondicionIngresoCat item)
        {
            Respuesta resp = new Respuesta();
            CondicionIngresoCat con = ObtenerCondicionPorDescripcion(item.CondicionIngreso);
            if (con == null)
            {
                return repo.Crear(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una condición con la misma descripción.";
                return resp;
            }

        }

        public Respuesta Modificar(CondicionIngresoCat item)
        {
            Respuesta resp = new Respuesta();
            CondicionIngresoCat con = ObtenerCondicionPorDescripcion(item.CondicionIngreso);
            if (con == null || con.IdCondicion == item.IdCondicion)
            {
                return repo.Modificar(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe una condición con la misma descripción.";
                return resp;
            }
        }
        public bool Desactivar(int id)
        {
            return repo.Desactivar(id);
        }

        public CondicionIngresoCat RegistrobyId(int id)
        {
            return repo.RegistrobyId(id);
        }

        public CondicionIngresoCat ObtenerCondicionPorDescripcion(String condicion)
        {
            return repo.ObtenerCondicionPorDescripcion(condicion);
        }

    }
}
