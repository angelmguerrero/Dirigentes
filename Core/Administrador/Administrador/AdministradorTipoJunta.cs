using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorTipoJunta : IAdministradorTipoJunta
    {
        private IRepositorioTipoJunta repo;
        public AdministradorTipoJunta()
        {
            this.repo = new RepositorioTipoJunta();
        }
        public List<TipoJuntaCat> Obtener()
        {
            return repo.Obtener();
        }

        public Respuesta Crear(TipoJuntaCat item)
        {
            Respuesta resp = new Respuesta();
            TipoJuntaCat junta = ObtenerTipoJuntaPorDescripcion(item.Descripcion);
            if (junta == null)
            {
                return repo.Crear(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un tipo de junta con la misma descripción";
                return resp;
            }

        }

        public Respuesta Modificar(TipoJuntaCat item)
        {
            Respuesta resp = new Respuesta();
            TipoJuntaCat junta = ObtenerTipoJuntaPorDescripcion(item.Descripcion);
            if (junta == null || junta.IdTipoJunta == item.IdTipoJunta)
            {
                return repo.Modificar(item);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un tipo de junta con la misma descripción";
                return resp;
            }

        }
        public bool Desactivar(int id)
        {
            return repo.Desactivar(id);
        }

        public TipoJuntaCat RegistrobyId(int id)
        {
            return repo.RegistrobyId(id);
        }

        public List<SelectDom> ObtenerTiposJuntaActivo()
        {
            return repo.ObtenerTipoJuntaActivo();
        }

        public TipoJuntaCat ObtenerTipoJuntaPorDescripcion(String desctipo)
        {
            return repo.ObtenerTipoJuntaPorDescripcion(desctipo);
        }
    }
}
