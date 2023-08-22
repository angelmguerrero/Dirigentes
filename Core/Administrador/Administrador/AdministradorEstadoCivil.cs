using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorEstadoCivil : IAdministradorEstadoCivil
    {
        private IRepositorioEstadoCivil repoEstadoCivil;

        public AdministradorEstadoCivil()
        {
            this.repoEstadoCivil = new RepositorioEstadoCivil();
        }
        public List<EstadoCivilCat> Obtener()
        {
            return repoEstadoCivil.Obtener();
        }
        public List<EstadoCivilCat> ObtenerActivo()
        {
            return repoEstadoCivil.ObtenerActivo();
        }
        public Respuesta Crear(EstadoCivilCat estadocivil)
        {
            Respuesta resp = new Respuesta();
            EstadoCivilCat estado = ObtenerEstadoCivilPorDescripcion(estadocivil.Descripcion);
            if (estado == null)
            {
                return repoEstadoCivil.Crear(estadocivil);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un estado civil con la misma descripción.";
                return resp;
            }

        }
        public Respuesta Modificar(EstadoCivilCat estadocivil)
        {
            Respuesta resp = new Respuesta();
            EstadoCivilCat estado = ObtenerEstadoCivilPorDescripcion(estadocivil.Descripcion);
            if (estado == null || estado.IdEstadoCivil == estadocivil.IdEstadoCivil)
            {
                return repoEstadoCivil.Modificar(estadocivil);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un estado civil con la misma descripción.";
                return resp;
            }

        }

        public bool Desactivar(int estadocivil)
        {
            return repoEstadoCivil.Desactivar(estadocivil);
        }

        public EstadoCivilCat RegistrobyId(int idestadocivil)
        {
            return repoEstadoCivil.RegistrobyId(idestadocivil);
        }

        public EstadoCivilCat ObtenerEstadoCivilPorDescripcion(String descEstado)
        {
            return repoEstadoCivil.ObtenerEstadoCivilPorDescripcion(descEstado);
        }

    }
}
