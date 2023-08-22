using CPM.PlataformaDirigentes.Comun.Constantes;
using CPM.PlataformaDirigentes.Comun.Enumerados;
using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using GraphServices;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioConvocatorias : IRepositorioConvocatorias
    {
        private readonly CPMDirigentesPlataformaContext context;
        IGenericRepository<Convocatorium> repo;
        IGenericRepository<RelMeetingAsistente> repoAsistente;
        IGenericRepository<RelMeetingOrdenDium> repoOrden;
        IGenericRepository<RelMeetingConvocatorium> repoConvoca;

        public RepositorioConvocatorias()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<Convocatorium>(context);
            repoAsistente = new GenericRepository<RelMeetingAsistente>(context);
            repoOrden = new GenericRepository<RelMeetingOrdenDium>(context);
            repoConvoca = new GenericRepository<RelMeetingConvocatorium>(context);


        }

        public List<CalendarioDom> GetConvocatorias(string correo)
        {
            var lstConvocatorias = (from c in context.Convocatoria
                                    join m in context.RelMeetingConvocatoria on c.IdConvocatoria equals m.IdConvocatoria
                                    join cxo in context.CargoxOrganos on c.IdOrgano equals cxo.IdOrgano
                                    join perf in context.PerfilCargos on cxo.IdPerfilCargo equals perf.IdPerfilCargo
                                    join perm in context.Permisos on perf.IdPerfilCargo equals perm.IdPerfilCargo
                                    join sm in context.SubModuloCats on perm.IdSubModulo equals sm.IdSubModulo
                                    where sm.Descripcion == Modulos.convocatoria
                                    && (perm.Crear == true || perm.Editar == true || perm.Todos == true)
                                    && cxo.IdPersona == (from persona in context.PersonaCats where persona.CorreoPersonal.ToUpper() == correo select persona.IdPersona).SingleOrDefault()
                                    select new CalendarioDom()
                                    {
                                        id = c.IdConvocatoria.ToString(),
                                        title = c.Convocatoria,
                                        startDate = m.FechaInicio.ToString("yyyy-MM-dd"),
                                        IdOrgano = c.IdOrgano,
                                        status = c.EstatusConvocatoria
                                    }).ToList();


            return lstConvocatorias;
        }

        public async Task<Respuesta> CrearConvocatoria(ConvocatoriaDom convocatoria)
        {
            Respuesta resp = new Respuesta();
            resp.Resultado = false;
            string idMeeting = string.Empty;
            string urlMeeting = string.Empty;
            Convocatorium nConvoca = new Convocatorium();
            var lstContactos = convocatoria.listConocimiento.Union(convocatoria.listNecesarios).Union(convocatoria.listOcultos).ToList();

            try
            {
                nConvoca.Convocatoria = convocatoria.convocatoria;
                nConvoca.IdOrgano = convocatoria.idOrgano;
                nConvoca.IdModalidad = convocatoria.idModalidad;
                nConvoca.IdOrdenDia = convocatoria.IdOrdenDia;
                nConvoca.Ubicacion = convocatoria.ubicacion;
                nConvoca.Organizador = convocatoria.Organizador;
                nConvoca.EstatusConvocatoria = (int)EstatusConvocatoria.EnValidacion;

                if (repo.Insert(nConvoca))
                {
                    foreach (var meeting in convocatoria.listMeeting)
                    {
                        #region Crear Meeting
                        if (nConvoca.IdModalidad == (int)TipoModalidad.Adistancia || nConvoca.IdModalidad == (int)TipoModalidad.Mixta)
                        {
                            DateTime dateTimeStart = DateTime.Parse(meeting.fechaInicio + ' ' + meeting.horaInicio);
                            DateTime dateTimeEnd = DateTime.Parse(meeting.fechaInicio + ' ' + meeting.horaFin);

                            MeetingTeams teams = new MeetingTeams();
                            var newmeet = await teams.CrearReunion(convocatoria.convocatoria, dateTimeStart, dateTimeEnd, lstContactos);
                            idMeeting = newmeet.idMeeting;
                            urlMeeting = newmeet.JoinUrl;

                        }
                        else
                        {
                            idMeeting = System.Guid.NewGuid().ToString();

                        }
                        #endregion

                        #region Crear Convocatoria
                        //CREAR CONVOCATORIA
                        RelMeetingConvocatorium nmeeting = new RelMeetingConvocatorium();
                        nmeeting.IdMeetingTeams = idMeeting;
                        nmeeting.IdConvocatoria = nConvoca.IdConvocatoria;
                        nmeeting.FechaInicio = DateTime.Parse(meeting.fechaInicio);
                        nmeeting.HoraInicio = TimeSpan.Parse(meeting.horaInicio);
                        nmeeting.HoraFin = TimeSpan.Parse(meeting.horaFin);
                        nmeeting.JoinWebUrl = urlMeeting;
                        repoConvoca.Insert(nmeeting);
                        #endregion

                        #region Generar Asistentes
                        //INGRESAR ASISTENTES
                        foreach (var asiste in convocatoria.listNecesarios)
                        {
                            RelMeetingAsistente nasistentes = new RelMeetingAsistente();

                            nasistentes.IdMeeting = nmeeting.Id;
                            nasistentes.CorreoAsistente = asiste.text;
                            nasistentes.TipoAsistente = (int)TipoAsistente.Necesario;
                            repoAsistente.Insert(nasistentes);

                        }
                        //INGRESAR CONOCIMIENTO
                        foreach (var asiste in convocatoria.listConocimiento)
                        {
                            RelMeetingAsistente nasistentes = new RelMeetingAsistente();

                            nasistentes.IdMeeting = nmeeting.Id;
                            nasistentes.CorreoAsistente = asiste.text;
                            nasistentes.TipoAsistente = (int)TipoAsistente.Conocimiento;
                            repoAsistente.Insert(nasistentes);

                        }
                        //INGRESAR OCULTOS
                        foreach (var asiste in convocatoria.listOcultos)
                        {
                            RelMeetingAsistente nasistentes = new RelMeetingAsistente();

                            nasistentes.IdMeeting = nmeeting.Id;
                            nasistentes.CorreoAsistente = asiste.text;
                            nasistentes.TipoAsistente = (int)TipoAsistente.Oculto;
                            repoAsistente.Insert(nasistentes);


                        }
                        #endregion

                        #region Generar Orden del Dia
                        //INGRESAR ORDEN DEL DIA
                        foreach (var orden in convocatoria.lstOrdenDia)
                        {
                            RelMeetingOrdenDium norden = new RelMeetingOrdenDium();
                            norden.IdConvocatoria = nConvoca.IdConvocatoria;
                            norden.IdPlantillaOrdenDia = convocatoria.IdOrdenDia;
                            norden.IdConsecutivoPadre = orden.IdConsecutivoPadre;
                            norden.Descripcion = orden.Descripcion;
                            norden.Indice = orden.Indice;
                            norden.IdPadre = orden.IdPadre;
                            repoOrden.Insert(norden);


                        }
                        #endregion

                    }
                    resp.Resultado = true;
                }
                else
                {
                    resp.Mensaje = "No se pudo crear la convocatoria";
                }
            }
            catch (Exception ex)
            {
                if (nConvoca.IdConvocatoria != (int)Numeracion.Cero)
                {
                    var delConvoca = repoConvoca.Get(x => x.IdConvocatoria == nConvoca.IdConvocatoria);

                    var delOrden = repoOrden.Get(x => x.IdConvocatoria == nConvoca.IdConvocatoria);
                    context.RelMeetingOrdenDia.RemoveRange(delOrden);


                    foreach (var item in delConvoca)
                    {
                        var delAsistentes = repoAsistente.Get(x => x.IdMeeting == item.Id);
                        context.RelMeetingAsistentes.RemoveRange(delAsistentes);


                    }

                    context.RelMeetingConvocatoria.RemoveRange(delConvoca);
                    context.Convocatoria.Remove(nConvoca);
                    context.SaveChanges();


                }
                Logger.Error("Crear Convocatoria", ex);
            }

            return resp;
        }

        public async Task<Respuesta> ModificarConvocatoria(ConvocatoriaDom convocatoria)
        {
            Respuesta resp = new Respuesta();
            resp.Resultado = false;
            string idMeeting = string.Empty;
            string urlMeeting = string.Empty;
            Convocatorium nConvoca = new Convocatorium();
            var lstContactos = convocatoria.listConocimiento.Union(convocatoria.listNecesarios).Union(convocatoria.listOcultos).ToList();

            try
            {

                nConvoca = repo.GetFirstOrDefault(x => x.IdConvocatoria == convocatoria.idConvocatoria);


                nConvoca.Convocatoria = convocatoria.convocatoria;
                nConvoca.IdOrgano = convocatoria.idOrgano;
                nConvoca.IdModalidad = convocatoria.idModalidad;
                nConvoca.IdOrdenDia = convocatoria.IdOrdenDia;
                nConvoca.Ubicacion = convocatoria.ubicacion;
                nConvoca.Organizador = convocatoria.Organizador;
                nConvoca.EstatusConvocatoria = (int)EstatusConvocatoria.EnValidacion;

                if (repo.Update(nConvoca))
                {


                    #region Borrar Informacion anterior
                    var dellistmeeting = repoConvoca.Get(x => x.IdConvocatoria == nConvoca.IdConvocatoria);

                    var delOrden = repoOrden.Get(x => x.IdConvocatoria == nConvoca.IdConvocatoria);
                    context.RelMeetingOrdenDia.RemoveRange(delOrden);


                    foreach (var item in dellistmeeting)
                    {
                        var delAsistentes = repoAsistente.Get(x => x.IdMeeting == item.Id);
                        context.RelMeetingAsistentes.RemoveRange(delAsistentes);


                    }
                    context.RelMeetingConvocatoria.RemoveRange(dellistmeeting);
                    context.SaveChanges();
                    #endregion


                    foreach (var meeting in convocatoria.listMeeting)
                    {

                        #region Crear Meeting
                        if (nConvoca.IdModalidad == (int)TipoModalidad.Adistancia || nConvoca.IdModalidad == (int)TipoModalidad.Mixta)
                        {
                            DateTime dateTimeStart = DateTime.Parse(meeting.fechaInicio + ' ' + meeting.horaInicio);
                            DateTime dateTimeEnd = DateTime.Parse(meeting.fechaInicio + ' ' + meeting.horaFin);

                            MeetingTeams teams = new MeetingTeams();
                            var newmeet = await teams.CrearReunion(convocatoria.convocatoria, dateTimeStart, dateTimeEnd, lstContactos);
                            idMeeting = newmeet.idMeeting;
                            urlMeeting = newmeet.JoinUrl;

                        }
                        else
                        {
                            idMeeting = System.Guid.NewGuid().ToString();

                        }
                        #endregion

                        #region Crear Convocatoria
                        //CREAR CONVOCATORIA
                        RelMeetingConvocatorium nmeeting = new RelMeetingConvocatorium();
                        nmeeting.IdMeetingTeams = idMeeting;
                        nmeeting.IdConvocatoria = nConvoca.IdConvocatoria;
                        nmeeting.FechaInicio = DateTime.Parse(meeting.fechaInicio);
                        nmeeting.HoraInicio = TimeSpan.Parse(meeting.horaInicio);
                        nmeeting.HoraFin = TimeSpan.Parse(meeting.horaFin);
                        nmeeting.JoinWebUrl = urlMeeting;
                        repoConvoca.Insert(nmeeting);
                        #endregion

                        #region Generar Asistentes
                        //INGRESAR ASISTENTES
                        foreach (var asiste in convocatoria.listNecesarios)
                        {
                            RelMeetingAsistente nasistentes = new RelMeetingAsistente();

                            nasistentes.IdMeeting = nmeeting.Id;
                            nasistentes.CorreoAsistente = asiste.text;
                            nasistentes.TipoAsistente = (int)TipoAsistente.Necesario;
                            repoAsistente.Insert(nasistentes);

                        }
                        //INGRESAR CONOCIMIENTO
                        foreach (var asiste in convocatoria.listConocimiento)
                        {
                            RelMeetingAsistente nasistentes = new RelMeetingAsistente();

                            nasistentes.IdMeeting = nmeeting.Id;
                            nasistentes.CorreoAsistente = asiste.text;
                            nasistentes.TipoAsistente = (int)TipoAsistente.Conocimiento;
                            repoAsistente.Insert(nasistentes);

                        }
                        //INGRESAR OCULTOS
                        foreach (var asiste in convocatoria.listOcultos)
                        {
                            RelMeetingAsistente nasistentes = new RelMeetingAsistente();

                            nasistentes.IdMeeting = nmeeting.Id;
                            nasistentes.CorreoAsistente = asiste.text;
                            nasistentes.TipoAsistente = (int)TipoAsistente.Oculto;
                            repoAsistente.Insert(nasistentes);


                        }
                        #endregion

                        #region Generar Orden del Dia
                        //INGRESAR ORDEN DEL DIA
                        foreach (var orden in convocatoria.lstOrdenDia)
                        {
                            RelMeetingOrdenDium norden = new RelMeetingOrdenDium();
                            norden.IdConvocatoria = nConvoca.IdConvocatoria;
                            norden.IdPlantillaOrdenDia = convocatoria.IdOrdenDia;
                            norden.IdConsecutivoPadre = orden.IdConsecutivoPadre;
                            norden.Descripcion = orden.Descripcion;
                            norden.Indice = orden.Indice;
                            norden.IdPadre = orden.IdPadre;
                            repoOrden.Insert(norden);


                        }
                        #endregion

                    }
                    resp.Resultado = true;
                }
                else
                {
                    resp.Mensaje = "No se pudo editar la convocatoria";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Modificar Convocatoria", ex);
            }

            return resp;

        }

        public List<RelMeetingOrdenDiumDom> ObtenerOrdenDiaPorIdConvocatoria(int id)
        {
            var prueba = (from orden in context.RelMeetingOrdenDia
                          where orden.IdConvocatoria == id
                          select new RelMeetingOrdenDiumDom
                          {
                              IdRelMeetingOrdenDia = orden.IdRelMeetingOrdenDia,
                              IdConvocatoria = orden.IdConvocatoria,
                              IdPlantillaOrdenDia = orden.IdPlantillaOrdenDia,
                              IdConsecutivoPadre = orden.IdConsecutivoPadre,
                              Descripcion = orden.Descripcion,
                              Indice = orden.Indice,
                              IdPadre = orden.IdPadre
                          }
                ).ToList();

            return prueba;
        }

        public List<RelMeetingOrdenDiumDom> RegistrobyIdPadre(int idConvocatoria, int idPadre)
        {
            var consulta = (from orden in context.RelMeetingOrdenDia
                            where orden.IdConvocatoria == idConvocatoria
                            && orden.IdPadre == idPadre
                            select new RelMeetingOrdenDiumDom
                            {
                                IdRelMeetingOrdenDia = orden.IdRelMeetingOrdenDia,
                                IdConvocatoria = orden.IdConvocatoria,
                                IdPlantillaOrdenDia = orden.IdPlantillaOrdenDia,
                                IdConsecutivoPadre = orden.IdConsecutivoPadre,
                                Descripcion = orden.Descripcion,
                                Indice = orden.Indice,
                                IdPadre = orden.IdPadre
                            }
                ).ToList();

            return consulta;
        }

        public ConvocatoriaDom GetConvocatoria(int idConvocatoria)
        {

            ConvocatoriaDom convoca = new ConvocatoriaDom();

            convoca = (from convocatorias in context.Convocatoria
                       where convocatorias.IdConvocatoria == idConvocatoria
                       select new ConvocatoriaDom
                       {
                           idConvocatoria = convocatorias.IdConvocatoria,
                           convocatoria = convocatorias.Convocatoria,
                           idOrgano = convocatorias.IdOrgano,
                           idModalidad = convocatorias.IdModalidad,
                           IdOrdenDia = convocatorias.IdOrdenDia,
                           ubicacion = convocatorias.Ubicacion,
                           estatusConvocatoria = convocatorias.EstatusConvocatoria
                       }
                       ).SingleOrDefault();

            var lstMeetings = (from meetings in context.RelMeetingConvocatoria
                               where meetings.IdConvocatoria == idConvocatoria
                               select new MeetingDom
                               {
                                   IdMeeting = meetings.Id,
                                   fechaInicio = meetings.FechaInicio.ToString("yyyy-MM-dd"),
                                   horaInicio = meetings.HoraInicio.ToString(@"hh\:mm"),
                                   horaFin = meetings.HoraFin.ToString(@"hh\:mm"),
                                   urlMeeting = meetings.JoinWebUrl

                               }).ToList();

            convoca.listMeeting = lstMeetings;

            var listNecesarios = (from necesarios in context.RelMeetingAsistentes
                                  where necesarios.TipoAsistente == (int)TipoAsistente.Necesario
                                  && necesarios.IdMeeting == lstMeetings[0].IdMeeting
                                  select new SelectCorreo
                                  {
                                      text = necesarios.CorreoAsistente
                                  }
                                  ).ToList();

            var listConocimiento = (from necesarios in context.RelMeetingAsistentes
                                    where necesarios.TipoAsistente == (int)TipoAsistente.Conocimiento
                                    && necesarios.IdMeeting == lstMeetings[0].IdMeeting
                                    select new SelectCorreo
                                    {
                                        text = necesarios.CorreoAsistente
                                    }
                                 ).ToList();

            var listOcultos = (from necesarios in context.RelMeetingAsistentes
                               where necesarios.TipoAsistente == (int)TipoAsistente.Oculto
                               && necesarios.IdMeeting == lstMeetings[0].IdMeeting

                               select new SelectCorreo
                               {
                                   text = necesarios.CorreoAsistente
                               }
                                 ).ToList();

            var tipojunta = (from junta in context.PlantillaOrdenDia
                             where junta.IdPlantillaOrdenDia == convoca.IdOrdenDia
                             select junta.IdTipoJunta).SingleOrDefault();

            convoca.idTipoJunta = tipojunta;
            var listOrdenDia = (from orden in context.RelMeetingOrdenDia
                                where orden.IdConvocatoria == idConvocatoria
                                select new DetallePlantillaOrdenDiaDom
                                {
                                    IdDetallePlantillaOrdenDia = orden.IdRelMeetingOrdenDia,
                                    IdPlantillaOrdenDia = orden.IdPlantillaOrdenDia,
                                    IdConsecutivoPadre = orden.IdConsecutivoPadre,
                                    Descripcion = orden.Descripcion,
                                    Indice = orden.Indice,
                                    IdPadre = orden.IdPadre
                                }
                ).ToList();

            convoca.listNecesarios = listNecesarios;
            convoca.listConocimiento = listConocimiento;
            convoca.listOcultos = listOcultos;
            convoca.lstOrdenDia = listOrdenDia;

            return convoca;


        }



    }
}
