using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.ResponsablePlaza;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPMPlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorResponsablePlaza : IAdministradorResponsablePlaza
    {
        private IRepositorioResponsablePlaza repoResponsablePlaza;
        public AdministradorResponsablePlaza()
        {
            this.repoResponsablePlaza = new RepositorioResponsablePlaza();
        }

        public List<ResponsablePlazaPersona> ObtenerResponsablePlazaPersona()
        {
            return repoResponsablePlaza.ObtenerResponsablePlazaPersona();
        }

        public Respuesta CrearResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona)
        {
            Respuesta resp = new Respuesta();
            ResponsablePlaza crear = ObtenerResponsablePorPlaza(ResponsablePlazaPersona);
            if (crear == null)
            {
                return repoResponsablePlaza.CrearResponsablePlazaPersonaNew(ResponsablePlazaPersona);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un responsable con la misma persona y la misma plaza.";
                return resp;
            }

        }

        public Respuesta ActualizarResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona)
        {
            Respuesta resp = new Respuesta();
            ResponsablePlaza mod = ObtenerResponsablePorPlaza(ResponsablePlazaPersona);
            if (mod == null || mod.IdResponsablePlaza == ResponsablePlazaPersona.IdResponsablePlaza)
            {
                return repoResponsablePlaza.ActualizarResponsablePlazaPersonaNew(ResponsablePlazaPersona);
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "Ya existe un responsable con la misma persona y la misma plaza.";
                return resp;
            }

        }

        public int EliminarResponsablePlazaPersonaNew(int idResponsablePlaza)
        {
            return repoResponsablePlaza.EliminarResponsablePlazaPersonaNew(idResponsablePlaza);
        }

        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilPermisoSolicitudDirigencial()
        {
            return repoResponsablePlaza.UsuarioPersonaPerfilPermisoSolicitudDirigencial();
        }

        public ResponsablePlazaPersona ResponsablePlazaPersonabyId(int idResponsablePlaza)
        {
            return repoResponsablePlaza.ResponsablePlazaPersonabyId(idResponsablePlaza);
        }

        public ResponsablePlazaPersona ResponsablePlazabyIdPlaza(int idPlaza)
        {
            return repoResponsablePlaza.ResponsablePlazabyIdPlaza(idPlaza);
        }

        public ResponsablePlazaPersona ResponsablePlazaPersonabyIdPersona(int idPersona)
        {
            return repoResponsablePlaza.ResponsablePlazaPersonabyIdPersona(idPersona);
        }

        //public ResponsablePlazaPersona ResponsablePlazaPersonabyCif(int cif)
        //{
        //    return repoResponsablePlaza.ResponsablePlazaPersonabyCif(cif);
        //}

        public ResponsablePlaza ObtenerResponsablePorPlaza(ResponsablePlazaPersona ResponsablePlazaPersona)
        {

            return repoResponsablePlaza.ObtenerResponsablePorPlaza(ResponsablePlazaPersona);
        }

        public List<SelectDom> UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo()
        {
            return repoResponsablePlaza.UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo();
        }

    }
}
