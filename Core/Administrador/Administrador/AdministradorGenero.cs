using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorGenero : IAdministradorGenero
    {
        private IRepositorioGenero repoGenero;

        public AdministradorGenero()
        {
            this.repoGenero = new RepositorioGenero();
        }
        public List<GeneroCat> Obtener()
        {
            return repoGenero.Obtener();
        }
        public List<GeneroCat> Obteneractivo()
        {
            return repoGenero.Obteneractivo();
        }

        public Respuesta Crear(GeneroCat genero)
        {
            Respuesta resp = new Respuesta();
            GeneroCat crear = ObtenerGeneroPorDescripcion(genero.Descripcion);
            if (crear == null)
            {
                return repoGenero.Crear(genero);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un genero con la misma descripción.";
                return resp;
            }

        }
        public Respuesta Modificar(GeneroCat genero)
        {
            Respuesta resp = new Respuesta();
            GeneroCat mod = ObtenerGeneroPorDescripcion(genero.Descripcion);
            if (mod == null || mod.IdGenero == genero.IdGenero)
            {
                return repoGenero.Modificar(genero);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un genero con la misma descripción.";
                return resp;
            }
        }

        public bool Desactivar(int genero)
        {
            return repoGenero.Desactivar(genero);
        }


        public GeneroCat RegistrobyId(int idgenero)
        {
            return repoGenero.RegistrobyId(idgenero);
        }

        public GeneroCat ObtenerGeneroPorDescripcion(String descGenero)
        {
            return repoGenero.ObtenerGeneroPorDescripcion(descGenero);
        }


    }
}
