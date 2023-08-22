using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorEstatusAcuerdo : IAdministradorEstatusAcuerdo
    {
        private IRepositorioEstatusAcuerdo repo;

        public AdministradorEstatusAcuerdo()
        {
            this.repo = new RepositorioEstatusAcuerdo();
        }
        public List<EstatusAcuerdosCat> Obtener()
        {
            return repo.Obtener();
        }

        public Respuesta Crear(EstatusAcuerdosCat item)
        {
            Respuesta resp = new Respuesta();
            EstatusAcuerdosCat estatus = ObtenerEstatusAcuerdoPorDescripcion(item.Descripcion);
            if (estatus == null)
            {
                return repo.Crear(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un estatus con la misma descripción.";
                return resp;
            }

        }
        public Respuesta Modificar(EstatusAcuerdosCat item)
        {
            Respuesta resp = new Respuesta();
            EstatusAcuerdosCat estatus = ObtenerEstatusAcuerdoPorDescripcion(item.Descripcion);
            if (estatus == null || estatus.IdEstatusAcuerdo == item.IdEstatusAcuerdo)
            {
                return repo.Modificar(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un estatus con la misma descripción.";
                return resp;
            }
        }

        public bool Desactivar(int item)
        {
            return repo.Desactivar(item);
        }


        public EstatusAcuerdosCat RegistrobyId(int item)
        {
            return repo.RegistrobyId(item);
        }

        public EstatusAcuerdosCat ObtenerEstatusAcuerdoPorDescripcion(String descAcuerdo)
        {
            return repo.ObtenerEstatusAcuerdoPorDescripcion(descAcuerdo);
        }
    }
}
