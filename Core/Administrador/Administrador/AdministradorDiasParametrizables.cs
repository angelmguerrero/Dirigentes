using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorDiasParametrizables : IAdministradorDiasParametrizables
    {
        private IRepositorioDiasParametrizables repo;

        public AdministradorDiasParametrizables()
        {
            this.repo = new RepositorioDiasParametrizables();
        }
        public List<DiasParametrizablesCat> Obtener()
        {
            return repo.Obtener();
        }

        public Respuesta Crear(DiasParametrizablesCat item)
        {
            Respuesta resp = new Respuesta();
            DiasParametrizablesCat dia = ObtenerDiasParamPorDescripcion(item.Descripcion);
            if (dia == null)
            {
                return repo.Crear(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un dia parametrizable con la misma descripción.";
                return resp;
            }

        }
        public Respuesta Modificar(DiasParametrizablesCat item)
        {
            Respuesta resp = new Respuesta();
            DiasParametrizablesCat dia = ObtenerDiasParamPorDescripcion(item.Descripcion);
            if (dia == null || dia.IdDiaParametrizable == item.IdDiaParametrizable)
            {
                return repo.Modificar(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un dia parametrizable con la misma descripción.";
                return resp;
            }

        }

        public bool Desactivar(int id)
        {
            return repo.Desactivar(id);
        }

        public DiasParametrizablesCat RegistrobyId(int id)
        {
            return repo.RegistrobyId(id);
        }

        public DiasParametrizablesCat ObtenerDiasParamPorDescripcion(String descDias)
        {
            return repo.ObtenerDiasParamPorDescripcion(descDias);
        }
    }
}
