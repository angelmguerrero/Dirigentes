using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorPersonalAdministrativo : IAdministradorPersonalAdministrativo
    {
        private IRepositorioPersonalAdministrativo repo;

        public AdministradorPersonalAdministrativo()
        {
            this.repo = new RepositorioPersonalAdministrativo();
        }
        public List<PersonalAdministrativoCat> Obtener()
        {
            return repo.Obtener();
        }

        public Respuesta Crear(PersonalAdministrativoCat item)
        {
            Respuesta resp = new Respuesta();
            PersonalAdministrativoCat personal = ObtenerPersonaPorNombre(item.NombreParticipanteOculto);
            PersonalAdministrativoCat personalCorreo = ObtenerPersonaPorCorreo(item.CorreoParticipante);
            if (personal == null)
            {
                if (personalCorreo == null)
                {
                    return repo.Crear(item);
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje = "Ya existe un personal con el mismo correo";
                    return resp;
                }

            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un personal con el mismo nombre";
                return resp;
            }

        }
        public Respuesta Modificar(PersonalAdministrativoCat item)
        {
            Respuesta resp = new Respuesta();
            PersonalAdministrativoCat personal = ObtenerPersonaPorNombre(item.NombreParticipanteOculto);
            PersonalAdministrativoCat personalCorreo = ObtenerPersonaPorCorreo(item.CorreoParticipante);
            if (personal == null || personal.IdPersonalAdministrativo == item.IdPersonalAdministrativo)
            {
                if (personalCorreo == null || personalCorreo.IdPersonalAdministrativo == item.IdPersonalAdministrativo)
                {

                    return repo.Modificar(item);

                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje = "Ya existe un personal con el mismo correo";
                    return resp;
                }

            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un personal con el mismo nombre";
                return resp;
            }

        }

        public bool Desactivar(int genero)
        {
            return repo.Desactivar(genero);
        }


        public PersonalAdministrativoCat RegistrobyId(int idgenero)
        {
            return repo.RegistrobyId(idgenero);
        }

        public PersonalAdministrativoCat ObtenerPersonaPorNombre(String nombre)
        {
            return repo.ObtenerPersonalPorNombre(nombre);
        }

        public PersonalAdministrativoCat ObtenerPersonaPorCorreo(String correo)
        {
            return repo.ObtenerPersonalPorCorreo(correo);
        }

    }
}
