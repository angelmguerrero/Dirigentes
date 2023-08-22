using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioPersonalAdministrativo : IRepositorioPersonalAdministrativo
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<PersonalAdministrativoCat> repo;
        public RepositorioPersonalAdministrativo()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<PersonalAdministrativoCat>(context);
        }
        public List<PersonalAdministrativoCat> Obtener()
        {
            return context.PersonalAdministrativoCats.ToList();
        }
        public Respuesta Crear(PersonalAdministrativoCat genero)
        {

            Respuesta resp = new Respuesta();
            try
            {
                genero.EstatusPersonalAdministrativo = true;
                if (repo.Insert(genero))
                {
                    resp.Resultado = true;
                    return resp;
                }
                else
                {
                    resp.Resultado = false;
                    return resp;
                }

            }
            catch (Exception ex)
            {
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta Modificar(PersonalAdministrativoCat item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.PersonalAdministrativoCats.Where(x => x.IdPersonalAdministrativo == item.IdPersonalAdministrativo).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _item.NombreParticipanteOculto = item.NombreParticipanteOculto;
                _item.CorreoParticipante = item.CorreoParticipante;
                _item.EstatusPersonalAdministrativo = item.EstatusPersonalAdministrativo;
                if (repo.Update(_item))
                {
                    resp.Resultado = true;
                    return resp;
                }
                else
                {
                    resp.Resultado = false;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.Resultado = false;
                return resp;
            }
        }

        public bool Desactivar(int id)
        {
            var _item = context.PersonalAdministrativoCats.Where(x => x.IdPersonalAdministrativo == id).SingleOrDefault();
            if (_item == null)
                return false;
            try
            {
                _item.EstatusPersonalAdministrativo = false;
                repo.Update(_item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PersonalAdministrativoCat RegistrobyId(int id)
        {
            var item = context.PersonalAdministrativoCats.Where(x => x.IdPersonalAdministrativo == id).FirstOrDefault();

            if (item == null)
                return null;
            else
                return item;
        }

        public PersonalAdministrativoCat ObtenerPersonalPorNombre(String nombre)
        {
            var item = context.PersonalAdministrativoCats.Where(x => x.NombreParticipanteOculto == nombre).FirstOrDefault();

            if (item == null)
                return null;
            else
                return item;
        }

        public PersonalAdministrativoCat ObtenerPersonalPorCorreo(String correo)
        {
            var item = context.PersonalAdministrativoCats.Where(x => x.CorreoParticipante == correo).FirstOrDefault();

            if (item == null)
                return null;
            else
                return item;
        }
    }
}
