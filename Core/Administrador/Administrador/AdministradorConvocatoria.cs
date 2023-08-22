using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Comun.Constantes;
using CPM.PlataformaDirigentes.Comun.Enumerados;
using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.PlantillaOrdenDelDia;
using CPM.PlataformaDirigentes.Models.ModeloDom.Convocatoria;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using EmailMailkit.Models;
using EmailMailkit.Services;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorConvocatoria : IAdministradorConvocatoria
    {
        private CPMDirigentesPlataformaContext context;
        private IRepositorioConvocatorias repo;
        private IRepositorioSelect repoSelect;
        private IGenericRepository<OrganoCat> repoOrgano;
        private IGenericRepository<Convocatorium> repoConvocatoria;
        private IGenericRepository<RelMeetingAutorizacion> repoAutorizacion;


        public AdministradorConvocatoria()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            this.repo = new RepositorioConvocatorias();
            this.repoSelect = new RepositorioSelect();
            this.repoOrgano = new GenericRepository<OrganoCat>(context);
            this.repoConvocatoria = new GenericRepository<Convocatorium>(context);
            this.repoAutorizacion = new GenericRepository<RelMeetingAutorizacion>(context);

        }
        public List<SelectDom> GetComitesPermisoConvocar(string correo)
        {
            return repoSelect.GetComitesPermisoConvocar(correo);
        }
        public List<CalendarioDom> GetConvocatorias(string correo)
        {
            return repo.GetConvocatorias(correo);
        }
        public List<SelectDom> GetModalidad()
        {
            return repoSelect.GetModalidad();

        }
        public List<SelectCorreo> GetAsistentesNecesarios(int IdOrgano)
        {
            return repoSelect.GetAsistentesNecesarios(IdOrgano);
        }
        public List<SelectCorreo> GetAllCorreos()
        {
            return repoSelect.GetAllCorreos();
        }
        public List<SelectCorreo> GetAsistentesConocimiento(int IdOrgano)
        {
            return repoSelect.GetAsistentesConocimiento(IdOrgano);
        }
        public List<SelectCorreo> GetAsistentesOcultos()
        {
            return repoSelect.GetAsistentesOcultos();
        }
        public List<DetallePlantillaOrdenDiaDom> iterarDetallesOrdenDia(List<DetallePlantillaOrdenDiaDom> item, List<DetallePlantillaOrdenDiaDom> lista)
        {
            foreach (DetallePlantillaOrdenDiaDom child in item)
            {
                lista.Add(child);
                if (child.niveles.Count() > 0)
                {
                    iterarDetallesOrdenDia(child.niveles, lista);
                }

            }

            return lista;
        }
        public async Task<Respuesta> CrearConvocatoria(ConvocatoriaDom convocatoria)
        {
            Respuesta resp = new Respuesta();

            List<DetallePlantillaOrdenDiaDom> listaOrden = new List<DetallePlantillaOrdenDiaDom>();
            listaOrden = iterarDetallesOrdenDia(convocatoria.lstOrdenDia, listaOrden);

            convocatoria.lstOrdenDia = listaOrden;

            if (convocatoria.idConvocatoria == (int)Numeracion.Cero)
            {
                resp = await repo.CrearConvocatoria(convocatoria);
            }
            else
            {
                resp = await repo.ModificarConvocatoria(convocatoria);
            }
            return resp;
        }
        public List<FechasConvocatorias> GetHorariosConvocatoria()
        {
            return repoSelect.GetHorariosConvocatoria();
        }
        public List<RelMeetingOrdenDiumDom> ObtenerOrdenDiaPorIdConvocatoria(int id)
        {
            List<RelMeetingOrdenDiumDom> lista = repo.ObtenerOrdenDiaPorIdConvocatoria(id);
            List<RelMeetingOrdenDiumDom> listaDetalle = new List<RelMeetingOrdenDiumDom>();

            foreach (RelMeetingOrdenDiumDom child in lista)
            {
                if (buscarItem(child, listaDetalle) == false)
                {
                    listaDetalle.Add(ChildrenOf(id, child));
                }

            }

            return listaDetalle;

        }
        public RelMeetingOrdenDiumDom ChildrenOf(int idConvocatoria, RelMeetingOrdenDiumDom detalle)
        {

            List<RelMeetingOrdenDiumDom> lista = repo.RegistrobyIdPadre(idConvocatoria, detalle.IdConsecutivoPadre);

            foreach (RelMeetingOrdenDiumDom child in lista.Where(x => x.IdPadre == detalle.IdConsecutivoPadre))
            {
                if (detalle.niveles == null)
                    detalle.niveles = new List<RelMeetingOrdenDiumDom>();
                detalle.niveles.Add(ChildrenOf(idConvocatoria, child));
            }

            return detalle;
        }
        public bool buscarItem(RelMeetingOrdenDiumDom detalle, List<RelMeetingOrdenDiumDom> lista)
        {

            foreach (RelMeetingOrdenDiumDom child in lista)
            {
                if (child.IdRelMeetingOrdenDia == detalle.IdRelMeetingOrdenDia)
                {
                    return true;
                }
                else
                {
                    if (child.niveles.Count() > 0)
                    {
                        bool finder = buscarItem(detalle, child.niveles);
                        if (finder)
                        {
                            return true;
                        }

                    }
                }

            }

            return false;
        }
        public ConvocatoriaDom GetConvocatoriaEdit(int idConvocatoria)
        {
            var convoca = repo.GetConvocatoria(idConvocatoria);

            List<DetallePlantillaOrdenDiaDom> lista = convoca.lstOrdenDia.ToList();

            List<DetallePlantillaOrdenDiaDom> listaDetalle = new List<DetallePlantillaOrdenDiaDom>();

            foreach (DetallePlantillaOrdenDiaDom child in lista)
            {
                if (buscarItemOrden(child, listaDetalle) == false)
                {
                    listaDetalle.Add(ChildrenOfOrden(child, lista));
                }

            }

            convoca.lstOrdenDia = listaDetalle;

            return convoca;


        }
        public DetallePlantillaOrdenDiaDom ChildrenOfOrden(DetallePlantillaOrdenDiaDom detalle, List<DetallePlantillaOrdenDiaDom> orden)
        {

            List<DetallePlantillaOrdenDiaDom> lista = orden.Where(x => x.IdPadre == detalle.IdConsecutivoPadre).ToList();

            foreach (DetallePlantillaOrdenDiaDom child in lista.Where(x => x.IdPadre == detalle.IdConsecutivoPadre))
            {
                if (detalle.niveles == null)
                    detalle.niveles = new List<DetallePlantillaOrdenDiaDom>();
                detalle.niveles.Add(ChildrenOfOrden(child, orden));
            }

            return detalle;
        }
        public bool buscarItemOrden(DetallePlantillaOrdenDiaDom detalle, List<DetallePlantillaOrdenDiaDom> lista)
        {

            foreach (DetallePlantillaOrdenDiaDom child in lista)
            {
                if (child.IdDetallePlantillaOrdenDia == detalle.IdDetallePlantillaOrdenDia)
                {
                    return true;
                }
                else
                {
                    if (child.niveles.Count() > 0)
                    {
                        bool finder = buscarItemOrden(detalle, child.niveles);
                        if (finder)
                        {
                            return true;
                        }

                    }
                }

            }

            return false;
        }
        public Respuesta AutorizarConvocatoria(int idConvocatoria, string correo)
        {
            Respuesta resp = new Respuesta();
            resp.Resultado = false;
            bool creada = false;

            var convocatoria = GetConvocatoriaEdit(idConvocatoria);

            #region Obtener quien genera la convocatoria
            var lstCargos = repoSelect.GetCargosxOrgano(correo, convocatoria.idOrgano);
            #endregion

            #region Presidente/Coordinador
            /*Presidente o Coordinador:
                      Presidente o Coordinador:
                    - Si el presidente genera la convocatoria, se remitirá al secretario para su revisión y aprobación 
                    antes de ser publicada en base a la plantilla de una o dos firmas.
                   
                    - Si recibe la convocatoria el secretario o miembro exoficio, puede editar la convocatoria y enviar
                    - Tener la opción de poder cancelar la convocatoria, en caso de que el presidente rechace la 
                    convocatoria y notificar al miembro exoficio y secretario.
                    • Una vez publicada la convocatoria, si requieren agregar o eliminar puntos a la orden del día el 
                    proceso será el mismo que el anterior, siempre y cuando la convocatoria sea vigente.
                    • Si pasa del día y/u horario de la celebración de la junta no se puede modificar y/o cancelar, 
                    únicamente el Administrador podría hacerlo.
            */

            var presi = lstCargos.Where(x => x.Contains(Cargos.presidente) || x.Contains(Cargos.coordinador));
            if (presi.Count() > (int)Numeracion.Cero)
            {
                var numFirnas = repoOrgano.GetFirstOrDefault(x => x.IdOrgano == convocatoria.idOrgano).NoFirmas;
                if (numFirnas == (int)Numeracion.Uno)
                {
                    //Actualizar estatus de la convocatoria
                    var convocaSimple = repoConvocatoria.GetFirstOrDefault(x => x.IdConvocatoria == idConvocatoria);
                    convocaSimple.EstatusConvocatoria = (int)EstatusConvocatoria.Publicada;
                    repoConvocatoria.Update(convocaSimple);
                    EnvioCorreosAsistentes(convocatoria);
                    resp.Mensaje = "La convocatoria fue publicada";
                    resp.Resultado = true;
                    return resp;

                }
                else
                {

                    var lstSecretario = repoSelect.GetCorreoxCargo(convocatoria.idOrgano, Cargos.secretario);

                    if (lstSecretario.Count > 0)
                    {
                        AgregarAutorizacion(lstSecretario, convocatoria.idConvocatoria, (int)TipoAutorizador.Secretario);
                        EnvioCorreosAutorizacion(lstSecretario, convocatoria.convocatoria);
                        resp.Resultado = true;
                        resp.Mensaje = "Se solicitaron las autorizaciones correspondientes";
                    }
                    else
                    {
                        resp.Resultado = false;
                        resp.Mensaje = "No hay secretario registrado para este organo";
                    }
                    return resp;

                }

            }
            #endregion

            #region ExOfixio
            /*
                Exoficio:
                - Si el miembro exoficio genera la convocatoria, se remitirá al secretario y presidente para su 
                revisión y aprobación antes de ser publicada.

             */
            var exoficio = lstCargos.Where(x => x.Contains(Cargos.exoficio));
            if (exoficio.Count() > (int)Numeracion.Cero)
            {
                var lstSecretario = repoSelect.GetCorreoxCargo(convocatoria.idOrgano, Cargos.secretario);
                var lstPresidente = repoSelect.GetCorreoxCargo(convocatoria.idOrgano, Cargos.presidente);

                if (lstSecretario.Count > 0)
                {
                    AgregarAutorizacion(lstSecretario, convocatoria.idConvocatoria, (int)TipoAutorizador.Secretario);
                    EnvioCorreosAutorizacion(lstSecretario, convocatoria.convocatoria);
                    resp.Resultado = true;
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>No hay secretario registrado para este organo</li>";
                }


                if (lstPresidente.Count > 0)
                {
                    AgregarAutorizacion(lstPresidente, convocatoria.idConvocatoria, (int)TipoAutorizador.Presidete);
                    EnvioCorreosAutorizacion(lstPresidente, convocatoria.convocatoria);
                    resp.Resultado = true;
                    resp.Mensaje = "Se solicitaron las autorizaciones correspondientes";
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>No hay presidente registrado para este organo</li>";
                }
                return resp;

            }
            #endregion

            #region Secretario 
            /*
             Secretario:
            - Si el secretario genera la convocatoria, se remitirá al presidente o coordinador para su revisión y 
            aprobación antes de ser publicada.
            - Si recibe la convocatoria del miembro exoficio o del presidente / coordinador, puede editar la 
            convocatoria y enviar al presidente y/o coordinador para su aprobación antes de ser publicada.
             */

            var secretario = lstCargos.Where(x => x.Contains(Cargos.secretario));
            if (secretario.Count() > (int)Numeracion.Cero)
            {
                var lstPresidente = repoSelect.GetCorreoxCargo(convocatoria.idOrgano, Cargos.presidente);

                if (lstPresidente.Count > 0)
                {
                    AgregarAutorizacion(lstPresidente, convocatoria.idConvocatoria, (int)TipoAutorizador.Presidete);
                    EnvioCorreosAutorizacion(lstPresidente, convocatoria.convocatoria);
                    resp.Resultado = true;
                    resp.Mensaje = "Se solicitaron las autorizaciones correspondientes";
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>No hay presidente registrado para este organo</li>";
                }
                return resp;
            }


            #endregion

            #region Otros
            var numFirnasOtros = repoOrgano.GetFirstOrDefault(x => x.IdOrgano == convocatoria.idOrgano).NoFirmas;
            if (numFirnasOtros == (int)Numeracion.Uno)
            {
                var lstPresidente = repoSelect.GetCorreoxCargo(convocatoria.idOrgano, Cargos.presidente);

                if (lstPresidente.Count > 0)
                {
                    AgregarAutorizacion(lstPresidente, convocatoria.idConvocatoria, (int)TipoAutorizador.Presidete);
                    EnvioCorreosAutorizacion(lstPresidente, convocatoria.convocatoria);
                    resp.Resultado = true;
                    resp.Mensaje = "Se solicitaron las autorizaciones correspondientes";
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>No hay presidente registrado para este organo</li>";
                }
                return resp;

            }
            else
            {

                var lstSecretario = repoSelect.GetCorreoxCargo(convocatoria.idOrgano, Cargos.secretario);
                var lstPresidente = repoSelect.GetCorreoxCargo(convocatoria.idOrgano, Cargos.presidente);

                if (lstSecretario.Count > 0)
                {
                    AgregarAutorizacion(lstSecretario, convocatoria.idConvocatoria, (int)TipoAutorizador.Secretario);
                    EnvioCorreosAutorizacion(lstSecretario, convocatoria.convocatoria);
                    resp.Resultado = true;
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>No hay secretario registrado para este organo</li>";
                }


                if (lstPresidente.Count > 0)
                {
                    AgregarAutorizacion(lstPresidente, convocatoria.idConvocatoria, (int)TipoAutorizador.Presidete);
                    EnvioCorreosAutorizacion(lstPresidente, convocatoria.convocatoria);
                    resp.Resultado = true;
                    resp.Mensaje = "Se solicitaron las autorizaciones correspondientes";
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>No hay presidente registrado para este organo</li>";
                }
                return resp;

            }



            #endregion

        }
        public Respuesta CancelarConvocatoria(int idConvocatoria, string correo)
        {
            Respuesta resp = new Respuesta();

            var convocaCancelar = repoConvocatoria.GetFirstOrDefault(x => x.IdConvocatoria == idConvocatoria);
            var lstPresidente = repoSelect.GetCorreoxCargo(convocaCancelar.IdOrgano, Cargos.presidente);
            var usuarioaprueba = lstPresidente.Contains(correo);

            if (usuarioaprueba)
            {
                var lstExoficio = repoSelect.GetCorreoxCargo(convocaCancelar.IdOrgano, Cargos.exoficio);
                var lstSecretario = repoSelect.GetCorreoxCargo(convocaCancelar.IdOrgano, Cargos.secretario);
                EnvioCorreosCancelacion(lstExoficio, convocaCancelar.Convocatoria);
                EnvioCorreosCancelacion(lstSecretario, convocaCancelar.Convocatoria);

            }

            convocaCancelar.EstatusConvocatoria = (int)EstatusConvocatoria.Cancelada;

            if (repoConvocatoria.Update(convocaCancelar))
            {
                resp.Resultado = true;
                resp.Mensaje = "La convocatoria ha sido cancelada";
            }
            else
            {
                resp.Resultado = false;
                resp.Mensaje = "La convocatoria no pudo ser cancelada";
            }

            return resp;
        }
        public Respuesta AprobarConvocatoria(int idConvocatoria, string correo)
        {
            Respuesta resp = new Respuesta();
            try
            {
                var lstAprobacion = repoAutorizacion.Get(x => x.IdConvocatoria == idConvocatoria);
                var usuarioaprueba = lstAprobacion.Where(x => x.CorreoAutoriza == correo).SingleOrDefault();

                if (usuarioaprueba != null)
                {
                    foreach (var item in lstAprobacion)
                    {
                        if (item.TipoAutorizador == usuarioaprueba.TipoAutorizador)
                        {
                            item.Autorizo = true;
                            repoAutorizacion.Update(item);
                        }
                    }

                    var lstAprobacionValidar = repoAutorizacion.Get(x => x.IdConvocatoria == idConvocatoria && x.Autorizo == false);

                    if (lstAprobacionValidar.Count() == (int)Numeracion.Cero)
                    {
                        var convocaAprobar = repoConvocatoria.GetFirstOrDefault(x => x.IdConvocatoria == idConvocatoria);
                        convocaAprobar.EstatusConvocatoria = (int)EstatusConvocatoria.Publicada;
                        repoConvocatoria.Update(convocaAprobar);

                        var convocatoria = GetConvocatoriaEdit(idConvocatoria);
                        EnvioCorreosAsistentes(convocatoria);
                        resp.Resultado = true;
                        resp.Mensaje = "La convocatoria fue publicada";
                    }
                    else
                    {
                        resp.Resultado = true;
                        resp.Mensaje = "Estan pendientes aprobaciones para poder publicar la convocatoria";
                    }
                }
                else
                {
                    resp.Resultado = false;
                    resp.Mensaje = "El usuario no  puede aprobar esta convocatoria";
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Error aprobar Convocatoria" + ex);
                resp.Resultado = false;
                resp.Mensaje = "No se pudo aprobar la convocatoria";

            }
            return resp;
        }
        public int GetEstatusConvocatoria(int idConvocatoria)
        {
            return repoConvocatoria.GetFirstOrDefault(x => x.IdConvocatoria == idConvocatoria).EstatusConvocatoria;
        }
        #region Private
        private List<string> ObtenerListadoCorreos(List<SelectCorreo> lstCorreos)
        {
            List<string> lstResult = new List<string>();

            foreach (var item in lstCorreos)
            {
                lstResult.Add(item.text);
            }
            return lstResult;

        }
        private bool EnvioCorreosAsistentes(ConvocatoriaDom convocatoria)
        {
            //Comienza el envio de correos
            string plantillaCorreo = string.Empty;
            IMailService _mail = new MailService();
            MailData mailData = new MailData();

            mailData.To = ObtenerListadoCorreos(convocatoria.listNecesarios);
            mailData.Cc = ObtenerListadoCorreos(convocatoria.listConocimiento);
            mailData.Bcc = ObtenerListadoCorreos(convocatoria.listOcultos);
            mailData.Subject = convocatoria.convocatoria;

            foreach (var item in convocatoria.listMeeting)
            {
                if (convocatoria.idModalidad == (int)TipoModalidad.Presencial)
                {
                    plantillaCorreo = _mail.GetEmailTemplate("emailTemplateEventoSinLiga")
                 .Replace("[[[tituloEvento]]]", convocatoria.convocatoria)
                 .Replace("[[[inicioEvento]]]", item.fechaInicio + ' ' + item.horaInicio)
                 .Replace("[[[finEvento]]]", item.fechaInicio + ' ' + item.horaFin);
                }
                else
                {
                    plantillaCorreo = _mail.GetEmailTemplate("emailTemplateEvento")
                   .Replace("[[[JoinWebUrl]]]", item.urlMeeting)
                   .Replace("[[[IdMeetingTeams]]]", "")
                   .Replace("[[[AccessCode]]]", "");

                }
                mailData.Body = plantillaCorreo;
                var incio = DateTime.Parse(item.fechaInicio + ' ' + item.horaInicio);
                var fin = DateTime.Parse(item.fechaInicio + ' ' + item.horaFin);
                _mail.SendCalendar(mailData, incio, fin, convocatoria.idConvocatoria, true);
            }
            return true;


        }
        private bool EnvioCorreosAutorizacion(List<string> lstCorreos, string nombreConvocatoria)
        {
            //Comienza el envio de correos
            string plantillaCorreo = string.Empty;
            IMailService _mail = new MailService();
            MailData mailData = new MailData();
            mailData.To = lstCorreos;
            mailData.Subject = String.Format("Autorización convocatoria {0}", nombreConvocatoria);
            plantillaCorreo = _mail.GetEmailTemplate("emailTemplateEventoAutorizar").Replace("[[[tituloEvento]]]", nombreConvocatoria);
            mailData.Body = plantillaCorreo;
            _mail.Send(mailData);
            return true;

        }
        private bool AgregarAutorizacion(List<string> lstCorreos, int idConvocatoria, int tipoAutorizador)
        {
            foreach (var item in lstCorreos)
            {
                RelMeetingAutorizacion autoriza = new RelMeetingAutorizacion();
                autoriza.CorreoAutoriza = item;
                autoriza.IdConvocatoria = idConvocatoria;
                autoriza.TipoAutorizador = tipoAutorizador;
                repoAutorizacion.Insert(autoriza);
            }

            return true;

        }
        private bool EnvioCorreosCancelacion(List<string> lstCorreos, string nombreConvocatoria)
        {
            //Comienza el envio de correos
            string plantillaCorreo = string.Empty;
            IMailService _mail = new MailService();
            MailData mailData = new MailData();
            mailData.To = lstCorreos;
            mailData.Subject = String.Format("Autorización convocatoria {0}", nombreConvocatoria);
            plantillaCorreo = _mail.GetEmailTemplate("emailTemplateEventoCancelar").Replace("[[[tituloEvento]]]", nombreConvocatoria);
            mailData.Body = plantillaCorreo;
            _mail.Send(mailData);
            return true;

        }
        #endregion

    }
}
