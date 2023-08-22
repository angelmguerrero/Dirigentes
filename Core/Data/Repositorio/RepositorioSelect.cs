using CPM.PlataformaDirigentes.Comun.Constantes;
using CPM.PlataformaDirigentes.Comun.Enumerados;
using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria;
using CPMPlataformaDirigentes.Data.Contexto;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioSelect : IRepositorioSelect
    {
        private readonly CPMDirigentesPlataformaContext context;
        private CPMDirectorioSucursalesContext contextdirectorio;

        public RepositorioSelect()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            this.contextdirectorio = new CPMDirectorioSucursalesContext(Configuracion.GetConnectionConsultaCpmDirectorioString());

        }

        public List<SelectDom> GetComitesPermisoConvocar(string correo)
        {


            var lstComites = (from cxo in context.CargoxOrganos
                              join org in context.OrganoCats on cxo.IdOrgano equals org.IdOrgano
                              join perf in context.PerfilCargos on cxo.IdPerfilCargo equals perf.IdPerfilCargo
                              join perm in context.Permisos on perf.IdPerfilCargo equals perm.IdPerfilCargo
                              join sm in context.SubModuloCats on perm.IdSubModulo equals sm.IdSubModulo
                              where sm.Descripcion == Modulos.convocatoria
                              && (perm.Crear == true || perm.Editar == true || perm.Todos == true)
                              && cxo.IdPersona == (from persona in context.Usuarios where persona.CorreoAcceso.ToUpper() == correo.ToUpper() select persona.IdPersona).SingleOrDefault()
                              select new SelectDom()
                              {
                                  value = org.IdOrgano,
                                  text = org.Descripcion
                              }).ToList();


            return lstComites;
        }
        public List<SelectDom> GetModalidad()
        {
            return (from mod in context.ModalidadCats
                    where mod.EstatusModalidad == true
                    select new SelectDom()
                    {
                        value = mod.IdModalidad,
                        text = mod.Descripcion
                    }).ToList();
        }
        public List<SelectCorreo> GetAsistentesNecesarios(int IdOrgano)
        {
            var listPersonas = (from organo in context.CargoxOrganos
                                where organo.Necesario.ToUpper() == "SI"
                                && organo.EstatusCargoOrgano == true
                                && organo.IdOrgano == IdOrgano
                                select organo.IdPersona).Distinct().ToList();


            var listCorreos = (from persona in context.Usuarios
                               where listPersonas.Contains((int)persona.IdPersona) && persona.CorreoAcceso != ""
                               select new SelectCorreo()
                               {
                                   text = persona.CorreoAcceso
                               }).ToList();

            return listCorreos;
        }
        public List<SelectCorreo> GetAllCorreos()
        {

            var list = (from persona in context.Usuarios
                        where persona.EstatusUsuario == true && persona.CorreoAcceso != ""
                        select new SelectCorreo()
                        {
                            text = persona.CorreoAcceso
                        }).ToList();


            return list;
        }
        public List<SelectCorreo> GetAsistentesConocimiento(int IdOrgano)
        {
            var listPersonas = (from organo in context.CargoxOrganos
                                where organo.Necesario.ToUpper() == "NO"
                                && organo.EstatusCargoOrgano == true
                                && organo.IdOrgano == IdOrgano
                                select organo.IdPersona).Distinct().ToList();


            var listCorreos = (from persona in context.Usuarios
                               where listPersonas.Contains((int)persona.IdPersona) && persona.CorreoAcceso != ""
                               select new SelectCorreo()
                               {
                                   text = persona.CorreoAcceso
                               }).ToList();


            return listCorreos;

        }
        public List<SelectCorreo> GetAsistentesOcultos()
        {
            var list = (from asistente in context.PersonalAdministrativoCats
                        where asistente.EstatusPersonalAdministrativo == true && asistente.CorreoParticipante != ""
                        select new SelectCorreo()
                        {
                            text = asistente.CorreoParticipante
                        }).Distinct().ToList();
            return list;
        }
        public List<SelectDom> GetOrgano(int idNivel)
        {
            return (from org in context.OrganoCats
                    where org.EstatusOrgano == true && org.IdNivelGestion == idNivel
                    select new SelectDom
                    {
                        value = org.IdOrgano,
                        text = org.Descripcion
                    }).ToList();
        }
        public List<SelectDom> GetCargo()
        {
            return (from per in context.PerfilCargos
                    where per.EsCargo == true && per.EstatusPerfil == true
                    select new SelectDom
                    {
                        value = per.IdPerfilCargo,
                        text = per.Descripcion
                    }).ToList();
        }
        public List<SelectDom> GetPlaza()
        {
            return (from plz in contextdirectorio.PlazaWrks
                    where plz.Activo == true
                    select new SelectDom
                    {
                        value = plz.IdPlaza,
                        text = plz.Nombre
                    }).ToList();
        }
        public List<SelectDom> GetNivel()
        {
            return (from niv in context.NivelGestionCats
                    select new SelectDom
                    {
                        value = niv.IdNivelGestion,
                        text = niv.Descripcion
                    }).ToList();
        }
        public List<FechasConvocatorias> GetHorariosConvocatoria()
        {

            var lstDisponibilidad = (from convoca in context.Convocatoria
                                     join meet in context.RelMeetingConvocatoria on convoca.IdConvocatoria equals meet.IdConvocatoria
                                     join asiste in context.RelMeetingAsistentes on meet.Id equals asiste.IdMeeting
                                     where (convoca.EstatusConvocatoria != (int)EstatusConvocatoria.Finalizada
                                     || convoca.EstatusConvocatoria != (int)EstatusConvocatoria.Cancelada)
                                     && meet.FechaInicio.Date >= DateTime.Now.Date

                                     select new FechasConvocatorias
                                     {
                                         fechaInicio = meet.FechaInicio,
                                         horaInicio = meet.HoraInicio,
                                         horaFin = meet.HoraFin,
                                         correoAsistente = asiste.CorreoAsistente
                                     }
                                    ).ToList();
            return lstDisponibilidad;

        }

        public List<string> GetCargosxOrgano(string correo, int idOrgano)
        {

            var lstComites = (from cxo in context.CargoxOrganos
                              join org in context.OrganoCats on cxo.IdOrgano equals org.IdOrgano
                              join perf in context.PerfilCargos on cxo.IdPerfilCargo equals perf.IdPerfilCargo
                              join perm in context.Permisos on perf.IdPerfilCargo equals perm.IdPerfilCargo
                              join sm in context.SubModuloCats on perm.IdSubModulo equals sm.IdSubModulo
                              where sm.Descripcion == Modulos.convocatoria
                              && cxo.IdOrgano == idOrgano
                              && (perm.Crear == true || perm.Editar == true || perm.Todos == true)
                              && cxo.IdPersona == (from persona in context.Usuarios where persona.CorreoAcceso.ToUpper() == correo.ToUpper() select persona.IdPersona).SingleOrDefault()
                              select perf.Descripcion.ToUpper()).ToList();

            return lstComites;
        }

        public List<string> GetCorreoxCargo(int idOrgano, string cargo)
        {
            var lstCargos = (from cargos in context.CargoxOrganos
                             join perfil in context.PerfilCargos on cargos.IdPerfilCargo equals perfil.IdPerfilCargo
                             where cargos.IdOrgano == idOrgano
                             && perfil.Descripcion.ToUpper() == cargo.ToUpper()
                             select cargos.IdPersona).ToList();


            var lstCorreos = (from usuarios in context.Usuarios
                              where lstCargos.Contains((int)usuarios.IdPersona)
                              select usuarios.CorreoAcceso).ToList();

            return lstCorreos;

        }



    }
}
