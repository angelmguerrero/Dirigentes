using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorMotivoBaja : IAdministradorMotivoBaja
    {
        private IRepositorioMotivosBaja repo;
        public AdministradorMotivoBaja()
        {
            this.repo = new RepositorioMotivosBaja();
        }
        public List<MotivosBajaCat> Obtener()
        {
            return repo.Obtener();
        }

        public Respuesta Crear(MotivosBajaCat item)
        {
            Respuesta resp = new Respuesta();
            MotivosBajaCat motivo = ObtenerMotivoPorDescripcion(item.Descripcion);
            if (motivo == null)
            {
                return repo.Crear(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un Motivo con la misma descripción.";
                return resp;
            }

        }

        public Respuesta Modificar(MotivosBajaCat item)
        {
            Respuesta resp = new Respuesta();
            MotivosBajaCat motivo = ObtenerMotivoPorDescripcion(item.Descripcion);
            if (motivo == null || motivo.IdMotivoBaja == item.IdMotivoBaja)
            {
                return repo.Modificar(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un Motivo con la misma descripción.";
                return resp;
            }

        }
        public bool Desactivar(int id)
        {
            return repo.Desactivar(id);
        }

        public MotivosBajaCat RegistrobyId(int id)
        {
            return repo.RegistrobyId(id);
        }

        public MotivosBajaCat ObtenerMotivoPorDescripcion(String descMotivo)
        {
            return repo.ObtenerMotivoPorDescripcion(descMotivo);
        }

        public List<MotivosBajaCat> ObtenerMotivosDt()
        {
            return repo.ObtenerMotivosDt();
        }

        public List<MotivosBajaCat> ObtenerSinMotivo()
        {
            return repo.ObtenerSinMotivo();
        }
    }
}
