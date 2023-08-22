using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorTipoBaja : IAdministradorTipoBaja
    {

        private IRepositorioTipoBaja repo;
        public AdministradorTipoBaja()
        {
            this.repo = new RepositorioTipoBaja();
        }
        public List<TipoBaja> Obtener()
        {
            return repo.Obtener();
        }
        public List<TipoBaja> ObtenerActivas()
        {
            return repo.ObtenerActivas();
        }

        public Respuesta Crear(TipoBaja item)
        {
            Respuesta resp = new Respuesta();
            TipoBaja tipo = ObtenerTipoPorDescripcion(item.Descripcion);
            if (tipo == null)
            {
                return repo.Crear(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un Tipo con la misma descripción.";
                return resp;
            }

        }

        public Respuesta Modificar(TipoBaja item)
        {
            Respuesta resp = new Respuesta();
            TipoBaja motivo = ObtenerTipoPorDescripcion(item.Descripcion);
            if (motivo == null || motivo.IdTipoBaja == item.IdTipoBaja)
            {
                return repo.Modificar(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un Tipo con la misma descripción.";
                return resp;
            }

        }
        public bool Desactivar(int id)
        {
            return repo.Desactivar(id);
        }

        public TipoBaja RegistrobyId(int id)
        {
            return repo.RegistrobyId(id);
        }

        public TipoBaja ObtenerTipoPorDescripcion(String descTipo)
        {
            return repo.ObtenerTipoPorDescripcion(descTipo);
        }


    }
}
