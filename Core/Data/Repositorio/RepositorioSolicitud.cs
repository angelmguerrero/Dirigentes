using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPM.PlataformaDirigentes.Models.Models;
using CPMPlataformaDirigentes.Models.Models;
using EmailMailkit.Models;
using EmailMailkit.Services;
using LoggerUtility.LogUtility;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioSolicitud : IRepositorioSolicitud
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioSolicitud()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }

        public Solicitud CrearSolicitud(Solicitud solicitud)
        {
            try
            {

                //obtener la plaza del representante
                var plazaSolicitante = (from plazasolicitante in context.PersonaCats
                                        where plazasolicitante.IdPersona == solicitud.IdPersona
                                        select plazasolicitante).FirstOrDefault();

                //obtener representanteporplaza
                var listaresponsableplaza = (from respnsableplaza in context.ResponsablePlazas
                                             where respnsableplaza.IdPlaza == plazaSolicitante.IdPlaza
                                             && respnsableplaza.Estatus == true
                                             select respnsableplaza).ToList();

                //crea solicitud
                context.Solicitudes.Add(solicitud);
                context.SaveChanges();

                //obntener correo de la personasolicitante
                var listSolicitudSolicitante = (from soliciudes in context.Solicitudes
                                                join persona in context.PersonaCats
                                                on soliciudes.IdPersonaSolicitante equals persona.IdPersona
                                                join usuarios in context.Usuarios
                                                on persona.IdPersona equals usuarios.IdPersona
                                                where soliciudes.IdPersonaSolicitante == solicitud.IdPersonaSolicitante
                                                && soliciudes.IdSolicitud == solicitud.IdSolicitud
                                                select usuarios).FirstOrDefault();

                var _solicitud = context.Solicitudes.Where(x => x.IdSolicitud == solicitud.IdSolicitud).SingleOrDefault();
                if (_solicitud.Estatus == "Aprobado")
                {

                    //actualiza tabla persona- 1-alta
                    if (_solicitud.Estatus == "Aprobado" && solicitud.IdTipoMovimiento == 1)
                    {
                        var personacatx = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == solicitud.IdSolicitud).FirstOrDefault();
                        if (personacatx != null)
                        {
                            var _persona = context.PersonaCats.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                            //var _persona = new PersonaCat();

                            //_persona.IdPersona = persona.IdPersona;
                            _persona.NombrePersona = personacatx.NombrePersona;
                            _persona.ApellidoPaterno = personacatx.ApellidoPaterno;
                            _persona.ApellidoMaterno = personacatx.ApellidoMaterno;
                            _persona.EstatusPersona = personacatx.EstatusPersona;
                            _persona.IdTipoPersona = personacatx.IdTipoPersona;
                            _persona.IdGenero = personacatx.IdGenero;
                            _persona.IdEstadoCivil = personacatx.IdEstadoCivil;
                            _persona.CorreoPersonal = personacatx.CorreoPersonal;
                            _persona.IdOficio = personacatx.IdOficio;
                            _persona.IdEscolaridad = personacatx.IdEscolaridad;
                            _persona.FechaNacimiento = personacatx.FechaNacimiento;
                            _persona.Rfc = personacatx.Rfc;
                            _persona.Curp = personacatx.Curp;
                            _persona.Edad = personacatx.Edad;
                            _persona.CodigoPostal = personacatx.CodigoPostal;
                            _persona.Celular = personacatx.Celular;
                            _persona.FechaIngreso = personacatx.FechaIngreso;
                            _persona.FechaBaja = personacatx.FechaBaja;
                            _persona.Cif = personacatx.Cif;
                            //_persona.Dirigente = personacatx.Dirigente;
                            _persona.IdDirigente = personacatx.IdDirigente;
                            _persona.IdProfesion = personacatx.IdProfesion;
                            _persona.Calle = personacatx.Calle;
                            _persona.NumeroInterior = personacatx.NumeroInterior;
                            _persona.Colonia = personacatx.Colonia;
                            _persona.Estado = personacatx.Estado;
                            _persona.Municipio = personacatx.Municipio;
                            _persona.IdCargo = personacatx.IdCargo;
                            _persona.IdSubUnidadOperativa = personacatx.IdSubUnidadOperativa;
                            _persona.Participacion = personacatx.Participacion;
                            _persona.Dirigente = true;
                            context.SaveChanges();

                            var _niveldirigencial = new NivelDirigencial();
                            _niveldirigencial.IdNivelDirigencialCat = (int)personacatx.IdNivelDirigencialCat;
                            _niveldirigencial.IdPersona = personacatx.IdPersona;
                            _niveldirigencial.EstatusNivelDirigencial = true;
                            _niveldirigencial.FechaIngreso = personacatx.FechaIngresoNivel;
                            _niveldirigencial.FinPeriodo = personacatx.FinPeriodo;
                            _niveldirigencial.Periodo = personacatx.Periodo;
                            _niveldirigencial.Aperiodo = personacatx.Aperiodo;
                            _niveldirigencial.IdCondicionIngreso = personacatx.IdCondicionIngreso;
                            context.NivelDirigencials.Add(_niveldirigencial);
                            context.SaveChanges();

                            _solicitud.EstatusSolicitud = false;
                            context.SaveChanges();



                        }
                        else
                        {
                            var niveldirigencial = context.NivelDirigencials.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();
                            var personacatb = context.PersonaCats.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();

                            var crearpersonahistorico = new PersonaSolicitudHist();

                            crearpersonahistorico.IdPersona = personacatb.IdPersona; ;
                            crearpersonahistorico.NombrePersona = personacatb.NombrePersona;
                            crearpersonahistorico.EstatusPersona = personacatb.EstatusPersona;
                            crearpersonahistorico.IdTipoPersona = personacatb.IdTipoPersona;
                            crearpersonahistorico.IdCargo = personacatb.IdCargo;
                            crearpersonahistorico.IdSubUnidadOperativa = personacatb.IdSubUnidadOperativa;
                            crearpersonahistorico.IdGenero = personacatb.IdGenero;
                            crearpersonahistorico.IdEstadoCivil = personacatb.IdEstadoCivil;
                            crearpersonahistorico.IdOficio = personacatb.IdOficio;
                            crearpersonahistorico.IdEscolaridad = personacatb.IdEscolaridad;
                            crearpersonahistorico.ApellidoPaterno = personacatb.ApellidoPaterno;
                            crearpersonahistorico.ApellidoMaterno = personacatb.ApellidoMaterno;
                            crearpersonahistorico.FechaNacimiento = personacatb.FechaNacimiento;
                            crearpersonahistorico.Rfc = personacatb.Rfc;
                            crearpersonahistorico.Curp = personacatb.Curp;
                            crearpersonahistorico.Edad = personacatb.Edad;
                            crearpersonahistorico.CodigoPostal = personacatb.CodigoPostal;
                            crearpersonahistorico.Celular = personacatb.Celular;
                            crearpersonahistorico.FechaIngreso = personacatb.FechaIngreso;
                            crearpersonahistorico.FechaBaja = personacatb.FechaBaja;
                            crearpersonahistorico.Cif = personacatb.Cif;
                            crearpersonahistorico.Dirigente = true;
                            crearpersonahistorico.IdDirigente = personacatb.IdDirigente;
                            crearpersonahistorico.IdRepresententanteCargoCat = personacatb.IdRepresententanteCargoCat;
                            crearpersonahistorico.IdProfesion = personacatb.IdProfesion;
                            crearpersonahistorico.Calle = personacatb.Calle;
                            crearpersonahistorico.NumeroInterior = personacatb.NumeroInterior;
                            crearpersonahistorico.Colonia = personacatb.Colonia;
                            crearpersonahistorico.Estado = personacatb.Estado;
                            crearpersonahistorico.Municipio = personacatb.Municipio;
                            crearpersonahistorico.IdPlaza = personacatb.IdPlaza;
                            crearpersonahistorico.Plaza = personacatb.Plaza;
                            crearpersonahistorico.IdSucursal = personacatb.IdSucursal;
                            crearpersonahistorico.Sucursal = personacatb.Sucursal;
                            crearpersonahistorico.CorreoPersonal = personacatb.CorreoPersonal;
                            crearpersonahistorico.CuentaMexicana = personacatb.CuentaMexicana;
                            crearpersonahistorico.EstatusPersonSolicitud = true;
                            crearpersonahistorico.IdSubUnidadOperativa = personacatb.IdSubUnidadOperativa;
                            crearpersonahistorico.IdSolicitud = _solicitud.IdSolicitud;
                            crearpersonahistorico.IdNivelDirigencialCat = niveldirigencial.IdNivelDirigencialCat;
                            crearpersonahistorico.FechaIngresoNivel = niveldirigencial.FechaIngreso;
                            crearpersonahistorico.FinPeriodo = niveldirigencial.FinPeriodo;
                            crearpersonahistorico.Periodo = niveldirigencial.Periodo;
                            crearpersonahistorico.Aperiodo = niveldirigencial.Aperiodo;
                            crearpersonahistorico.IdCondicionIngreso = niveldirigencial.IdCondicionIngreso;
                            crearpersonahistorico.Participacion = personacatb.Participacion;

                            context.PersonaSolicitudHists.Add(crearpersonahistorico);
                            context.SaveChanges();

                        }
                        _solicitud.EstatusSolicitud = false;
                        context.SaveChanges();


                    }
                    //2 baja 
                    if (_solicitud.Estatus == "Aprobado" && solicitud.IdTipoMovimiento == 2)
                    {
                        var personacatx = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == solicitud.IdSolicitud).FirstOrDefault();

                        if (personacatx != null)
                        {
                            var _persona = context.PersonaCats.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                            //var _persona = new PersonaCat();

                            //_persona.IdPersona = persona.IdPersona;
                            _persona.NombrePersona = personacatx.NombrePersona;
                            _persona.ApellidoPaterno = personacatx.ApellidoPaterno;
                            _persona.ApellidoMaterno = personacatx.ApellidoMaterno;
                            _persona.EstatusPersona = false;
                            _persona.IdTipoPersona = personacatx.IdTipoPersona;
                            _persona.IdGenero = personacatx.IdGenero;
                            _persona.IdEstadoCivil = personacatx.IdEstadoCivil;
                            _persona.CorreoPersonal = personacatx.CorreoPersonal;
                            _persona.IdOficio = personacatx.IdOficio;
                            _persona.IdEscolaridad = personacatx.IdEscolaridad;
                            _persona.FechaNacimiento = personacatx.FechaNacimiento;
                            _persona.Rfc = personacatx.Rfc;
                            _persona.Curp = personacatx.Curp;
                            _persona.Edad = personacatx.Edad;
                            _persona.CodigoPostal = personacatx.CodigoPostal;
                            _persona.Celular = personacatx.Celular;
                            _persona.FechaIngreso = personacatx.FechaIngreso;
                            _persona.FechaBaja = personacatx.FechaBaja;
                            _persona.Cif = personacatx.Cif;
                            //_persona.Dirigente = personacatx.Dirigente;
                            _persona.IdDirigente = personacatx.IdDirigente;
                            _persona.IdProfesion = personacatx.IdProfesion;
                            _persona.Calle = personacatx.Calle;
                            _persona.NumeroInterior = personacatx.NumeroInterior;
                            _persona.Colonia = personacatx.Colonia;
                            _persona.Estado = personacatx.Estado;
                            _persona.Municipio = personacatx.Municipio;
                            _persona.IdCargo = personacatx.IdCargo;
                            _persona.IdSubUnidadOperativa = personacatx.IdSubUnidadOperativa;
                            _persona.Participacion = personacatx.Participacion;
                            _persona.Dirigente = true;

                            context.SaveChanges();
                            //desactivar usuario

                        }
                        else
                        {
                            var niveldirigencial = context.NivelDirigencials.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();
                            var personacatb = context.PersonaCats.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();

                            var crearpersonahistorico = new PersonaSolicitudHist();

                            crearpersonahistorico.IdPersona = personacatb.IdPersona; ;
                            crearpersonahistorico.NombrePersona = personacatb.NombrePersona;
                            crearpersonahistorico.EstatusPersona = false;
                            crearpersonahistorico.IdTipoPersona = personacatb.IdTipoPersona;
                            crearpersonahistorico.IdCargo = personacatb.IdCargo;
                            crearpersonahistorico.IdSubUnidadOperativa = personacatb.IdSubUnidadOperativa;
                            crearpersonahistorico.IdGenero = personacatb.IdGenero;
                            crearpersonahistorico.IdEstadoCivil = personacatb.IdEstadoCivil;
                            crearpersonahistorico.IdOficio = personacatb.IdOficio;
                            crearpersonahistorico.IdEscolaridad = personacatb.IdEscolaridad;
                            crearpersonahistorico.ApellidoPaterno = personacatb.ApellidoPaterno;
                            crearpersonahistorico.ApellidoMaterno = personacatb.ApellidoMaterno;
                            crearpersonahistorico.FechaNacimiento = personacatb.FechaNacimiento;
                            crearpersonahistorico.Rfc = personacatb.Rfc;
                            crearpersonahistorico.Curp = personacatb.Curp;
                            crearpersonahistorico.Edad = personacatb.Edad;
                            crearpersonahistorico.CodigoPostal = personacatb.CodigoPostal;
                            crearpersonahistorico.Celular = personacatb.Celular;
                            crearpersonahistorico.FechaIngreso = personacatb.FechaIngreso;
                            crearpersonahistorico.FechaBaja = personacatb.FechaBaja;
                            crearpersonahistorico.Cif = personacatb.Cif;
                            crearpersonahistorico.Dirigente = true;
                            crearpersonahistorico.IdDirigente = personacatb.IdDirigente;
                            crearpersonahistorico.IdRepresententanteCargoCat = personacatb.IdRepresententanteCargoCat;
                            crearpersonahistorico.IdProfesion = personacatb.IdProfesion;
                            crearpersonahistorico.Calle = personacatb.Calle;
                            crearpersonahistorico.NumeroInterior = personacatb.NumeroInterior;
                            crearpersonahistorico.Colonia = personacatb.Colonia;
                            crearpersonahistorico.Estado = personacatb.Estado;
                            crearpersonahistorico.Municipio = personacatb.Municipio;
                            crearpersonahistorico.IdPlaza = personacatb.IdPlaza;
                            crearpersonahistorico.Plaza = personacatb.Plaza;
                            crearpersonahistorico.IdSucursal = personacatb.IdSucursal;
                            crearpersonahistorico.Sucursal = personacatb.Sucursal;
                            crearpersonahistorico.CorreoPersonal = personacatb.CorreoPersonal;
                            crearpersonahistorico.CuentaMexicana = personacatb.CuentaMexicana;
                            crearpersonahistorico.EstatusPersonSolicitud = true;
                            crearpersonahistorico.IdSubUnidadOperativa = personacatb.IdSubUnidadOperativa;
                            crearpersonahistorico.IdSolicitud = _solicitud.IdSolicitud;
                            crearpersonahistorico.IdNivelDirigencialCat = niveldirigencial.IdNivelDirigencialCat;
                            crearpersonahistorico.FechaIngresoNivel = niveldirigencial.FechaIngreso;
                            crearpersonahistorico.FinPeriodo = niveldirigencial.FinPeriodo;
                            crearpersonahistorico.Periodo = niveldirigencial.Periodo;
                            crearpersonahistorico.Aperiodo = niveldirigencial.Aperiodo;
                            crearpersonahistorico.IdCondicionIngreso = niveldirigencial.IdCondicionIngreso;
                            crearpersonahistorico.Participacion = personacatb.Participacion;
                            context.PersonaSolicitudHists.Add(crearpersonahistorico);
                            context.SaveChanges();

                        }

                        var _usuariopersona = context.Usuarios.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();
                        if (_usuariopersona != null)
                        {

                            _usuariopersona.EstatusUsuario = false;
                            context.SaveChanges();
                        }
                        _solicitud.EstatusSolicitud = false;
                        context.SaveChanges();
                    }
                    // 3 reingreso
                    if (_solicitud.Estatus == "Aprobado" && solicitud.IdTipoMovimiento == 3)
                    {
                        var niveldirigencial = context.NivelDirigencials.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();
                        var personacatx = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == solicitud.IdSolicitud).FirstOrDefault();

                        if (personacatx != null)
                        {
                            var _persona = context.PersonaCats.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                            //var _persona = new PersonaCat();

                            //_persona.IdPersona = persona.IdPersona;
                            _persona.NombrePersona = personacatx.NombrePersona;
                            _persona.ApellidoPaterno = personacatx.ApellidoPaterno;
                            _persona.ApellidoMaterno = personacatx.ApellidoMaterno;
                            _persona.EstatusPersona = true;
                            _persona.IdTipoPersona = personacatx.IdTipoPersona;
                            _persona.IdGenero = personacatx.IdGenero;
                            _persona.IdEstadoCivil = personacatx.IdEstadoCivil;
                            _persona.CorreoPersonal = personacatx.CorreoPersonal;
                            _persona.IdOficio = personacatx.IdOficio;
                            _persona.IdEscolaridad = personacatx.IdEscolaridad;
                            _persona.FechaNacimiento = personacatx.FechaNacimiento;
                            _persona.Rfc = personacatx.Rfc;
                            _persona.Curp = personacatx.Curp;
                            _persona.Edad = personacatx.Edad;
                            _persona.CodigoPostal = personacatx.CodigoPostal;
                            _persona.Celular = personacatx.Celular;
                            _persona.FechaIngreso = personacatx.FechaIngreso;
                            _persona.FechaBaja = personacatx.FechaBaja;
                            _persona.Cif = personacatx.Cif;
                            //_persona.Dirigente = personacatx.Dirigente;
                            _persona.IdDirigente = personacatx.IdDirigente;
                            _persona.IdProfesion = personacatx.IdProfesion;
                            _persona.Calle = personacatx.Calle;
                            _persona.NumeroInterior = personacatx.NumeroInterior;
                            _persona.Colonia = personacatx.Colonia;
                            _persona.Estado = personacatx.Estado;
                            _persona.Municipio = personacatx.Municipio;
                            _persona.IdCargo = personacatx.IdCargo;
                            _persona.IdSubUnidadOperativa = personacatx.IdSubUnidadOperativa;
                            _persona.Participacion = personacatx.Participacion;
                            _persona.Dirigente = true;
                            context.SaveChanges();

                            var _niveldirigencial = new NivelDirigencial();
                            _niveldirigencial.IdNivelDirigencialCat = (int)personacatx.IdNivelDirigencialCat;
                            _niveldirigencial.IdPersona = personacatx.IdPersona;
                            _niveldirigencial.EstatusNivelDirigencial = true;
                            _niveldirigencial.FechaIngreso = personacatx.FechaIngresoNivel;
                            _niveldirigencial.FinPeriodo = personacatx.FinPeriodo;
                            _niveldirigencial.Aperiodo = personacatx.Aperiodo;
                            _niveldirigencial.IdCondicionIngreso = personacatx.IdCondicionIngreso;
                            context.NivelDirigencials.Add(_niveldirigencial);
                            context.SaveChanges();

                        }
                        else
                        {
                            var personacatb = context.PersonaCats.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();

                            var crearpersonahistorico = new PersonaSolicitudHist();

                            crearpersonahistorico.IdPersona = personacatb.IdPersona; ;
                            crearpersonahistorico.NombrePersona = personacatb.NombrePersona;

                            crearpersonahistorico.EstatusPersona = personacatb.EstatusPersona;
                            crearpersonahistorico.IdTipoPersona = personacatb.IdTipoPersona;
                            crearpersonahistorico.IdCargo = personacatb.IdCargo;
                            crearpersonahistorico.IdSubUnidadOperativa = personacatb.IdSubUnidadOperativa;
                            crearpersonahistorico.IdGenero = personacatb.IdGenero;
                            crearpersonahistorico.IdEstadoCivil = personacatb.IdEstadoCivil;
                            crearpersonahistorico.IdOficio = personacatb.IdOficio;
                            crearpersonahistorico.IdEscolaridad = personacatb.IdEscolaridad;
                            crearpersonahistorico.ApellidoPaterno = personacatb.ApellidoPaterno;
                            crearpersonahistorico.ApellidoMaterno = personacatb.ApellidoMaterno;
                            crearpersonahistorico.FechaNacimiento = personacatb.FechaNacimiento;
                            crearpersonahistorico.Rfc = personacatb.Rfc;
                            crearpersonahistorico.Curp = personacatb.Curp;
                            crearpersonahistorico.Edad = personacatb.Edad;
                            crearpersonahistorico.CodigoPostal = personacatb.CodigoPostal;
                            crearpersonahistorico.Celular = personacatb.Celular;
                            crearpersonahistorico.FechaIngreso = personacatb.FechaIngreso;
                            crearpersonahistorico.FechaBaja = personacatb.FechaBaja;
                            crearpersonahistorico.Cif = personacatb.Cif;
                            crearpersonahistorico.Dirigente = true;
                            crearpersonahistorico.IdDirigente = personacatb.IdDirigente;
                            crearpersonahistorico.IdRepresententanteCargoCat = personacatb.IdRepresententanteCargoCat;
                            crearpersonahistorico.IdProfesion = personacatb.IdProfesion;
                            crearpersonahistorico.Calle = personacatb.Calle;
                            crearpersonahistorico.NumeroInterior = personacatb.NumeroInterior;
                            crearpersonahistorico.Colonia = personacatb.Colonia;
                            crearpersonahistorico.Estado = personacatb.Estado;
                            crearpersonahistorico.Municipio = personacatb.Municipio;
                            crearpersonahistorico.IdPlaza = personacatb.IdPlaza;
                            crearpersonahistorico.Plaza = personacatb.Plaza;
                            crearpersonahistorico.IdSucursal = personacatb.IdSucursal;
                            crearpersonahistorico.Sucursal = personacatb.Sucursal;
                            crearpersonahistorico.CorreoPersonal = personacatb.CorreoPersonal;
                            crearpersonahistorico.FechaCreacion = personacatb.FechaCreacion;
                            crearpersonahistorico.CuentaMexicana = personacatb.CuentaMexicana;
                            crearpersonahistorico.EstatusPersonSolicitud = true;
                            crearpersonahistorico.IdSubUnidadOperativa = personacatb.IdSubUnidadOperativa;
                            crearpersonahistorico.IdSolicitud = _solicitud.IdSolicitud;
                            crearpersonahistorico.IdNivelDirigencialCat = niveldirigencial.IdNivelDirigencialCat;
                            crearpersonahistorico.FechaIngresoNivel = niveldirigencial.FechaIngreso;
                            crearpersonahistorico.FinPeriodo = niveldirigencial.FinPeriodo;
                            crearpersonahistorico.Periodo = niveldirigencial.Periodo;
                            crearpersonahistorico.Aperiodo = niveldirigencial.Aperiodo;
                            crearpersonahistorico.IdCondicionIngreso = niveldirigencial.IdCondicionIngreso;
                            crearpersonahistorico.Participacion = personacatb.Participacion;

                            context.PersonaSolicitudHists.Add(crearpersonahistorico);
                            context.SaveChanges();

                        }
                        //Se dejó la activación del usuario de forma manual
                        //var _usuariopersona = context.Usuarios.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();
                        //if (_usuariopersona != null)
                        //{
                        //    _usuariopersona.EstatusUsuario = true;
                        //    context.SaveChanges();
                        //}
                        _solicitud.EstatusSolicitud = false;
                        context.SaveChanges();
                    }
                    //4 modificacion
                    if (_solicitud.Estatus == "Aprobado" && solicitud.IdTipoMovimiento == 4)
                    {
                        var personacatx = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == solicitud.IdSolicitud).FirstOrDefault();

                        if (personacatx != null)
                        {
                            var _persona = context.PersonaCats.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                            //var _persona = new PersonaCat();

                            //_persona.IdPersona = persona.IdPersona;
                            _persona.NombrePersona = personacatx.NombrePersona;
                            _persona.ApellidoPaterno = personacatx.ApellidoPaterno;
                            _persona.ApellidoMaterno = personacatx.ApellidoMaterno;
                            _persona.EstatusPersona = personacatx.EstatusPersona;
                            _persona.IdTipoPersona = personacatx.IdTipoPersona;
                            _persona.IdGenero = personacatx.IdGenero;
                            _persona.IdEstadoCivil = personacatx.IdEstadoCivil;
                            _persona.CorreoPersonal = personacatx.CorreoPersonal;
                            _persona.IdOficio = personacatx.IdOficio;
                            _persona.IdEscolaridad = personacatx.IdEscolaridad;
                            _persona.FechaNacimiento = personacatx.FechaNacimiento;
                            _persona.Rfc = personacatx.Rfc;
                            _persona.Curp = personacatx.Curp;
                            _persona.Edad = personacatx.Edad;
                            _persona.CodigoPostal = personacatx.CodigoPostal;
                            _persona.Celular = personacatx.Celular;
                            _persona.FechaIngreso = personacatx.FechaIngreso;
                            _persona.FechaBaja = personacatx.FechaBaja;
                            _persona.Cif = personacatx.Cif;
                            //_persona.Dirigente = personacatx.Dirigente;
                            _persona.IdDirigente = personacatx.IdDirigente;
                            _persona.IdProfesion = personacatx.IdProfesion;
                            _persona.Calle = personacatx.Calle;
                            _persona.NumeroInterior = personacatx.NumeroInterior;
                            _persona.Colonia = personacatx.Colonia;
                            _persona.Estado = personacatx.Estado;
                            _persona.Municipio = personacatx.Municipio;
                            _persona.IdCargo = personacatx.IdCargo;
                            _persona.IdSubUnidadOperativa = personacatx.IdSubUnidadOperativa;
                            _persona.Participacion = personacatx.Participacion;
                            _persona.Dirigente = true;
                            context.SaveChanges();

                            var _niveldirigencial = new NivelDirigencial();
                            _niveldirigencial.IdNivelDirigencialCat = (int)personacatx.IdNivelDirigencialCat;
                            _niveldirigencial.IdPersona = personacatx.IdPersona;
                            _niveldirigencial.EstatusNivelDirigencial = true;
                            _niveldirigencial.FechaIngreso = personacatx.FechaIngresoNivel;
                            _niveldirigencial.FinPeriodo = personacatx.FinPeriodo;
                            _niveldirigencial.Aperiodo = personacatx.Aperiodo;
                            _niveldirigencial.IdCondicionIngreso = personacatx.IdCondicionIngreso;
                            context.NivelDirigencials.Add(_niveldirigencial);
                            context.SaveChanges();

                        }
                        else
                        {
                            var niveldirigencial = context.NivelDirigencials.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();
                            var personacatb = context.PersonaCats.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();

                            var crearpersonahistorico = new PersonaSolicitudHist();

                            crearpersonahistorico.IdPersona = personacatb.IdPersona; ;
                            crearpersonahistorico.NombrePersona = personacatb.NombrePersona;

                            crearpersonahistorico.EstatusPersona = personacatb.EstatusPersona;
                            crearpersonahistorico.IdTipoPersona = personacatb.IdTipoPersona;
                            crearpersonahistorico.IdCargo = personacatb.IdCargo;
                            crearpersonahistorico.IdSubUnidadOperativa = personacatb.IdSubUnidadOperativa;
                            crearpersonahistorico.IdGenero = personacatb.IdGenero;
                            crearpersonahistorico.IdEstadoCivil = personacatb.IdEstadoCivil;
                            crearpersonahistorico.IdOficio = personacatb.IdOficio;
                            crearpersonahistorico.IdEscolaridad = personacatb.IdEscolaridad;
                            crearpersonahistorico.ApellidoPaterno = personacatb.ApellidoPaterno;
                            crearpersonahistorico.ApellidoMaterno = personacatb.ApellidoMaterno;
                            crearpersonahistorico.FechaNacimiento = personacatb.FechaNacimiento;
                            crearpersonahistorico.Rfc = personacatb.Rfc;
                            crearpersonahistorico.Curp = personacatb.Curp;
                            crearpersonahistorico.Edad = personacatb.Edad;
                            crearpersonahistorico.CodigoPostal = personacatb.CodigoPostal;
                            crearpersonahistorico.Celular = personacatb.Celular;
                            crearpersonahistorico.FechaIngreso = personacatb.FechaIngreso;
                            crearpersonahistorico.FechaBaja = personacatb.FechaBaja;
                            crearpersonahistorico.Cif = personacatb.Cif;
                            crearpersonahistorico.Dirigente = true;
                            crearpersonahistorico.IdDirigente = personacatb.IdDirigente;
                            crearpersonahistorico.IdRepresententanteCargoCat = personacatb.IdRepresententanteCargoCat;
                            crearpersonahistorico.IdProfesion = personacatb.IdProfesion;
                            crearpersonahistorico.Calle = personacatb.Calle;
                            crearpersonahistorico.NumeroInterior = personacatb.NumeroInterior;
                            crearpersonahistorico.Colonia = personacatb.Colonia;
                            crearpersonahistorico.Estado = personacatb.Estado;
                            crearpersonahistorico.Municipio = personacatb.Municipio;
                            crearpersonahistorico.IdPlaza = personacatb.IdPlaza;
                            crearpersonahistorico.Plaza = personacatb.Plaza;
                            crearpersonahistorico.IdSucursal = personacatb.IdSucursal;
                            crearpersonahistorico.Sucursal = personacatb.Sucursal;
                            crearpersonahistorico.CorreoPersonal = personacatb.CorreoPersonal;
                            crearpersonahistorico.CuentaMexicana = personacatb.CuentaMexicana;
                            crearpersonahistorico.FechaCreacion = personacatb.FechaCreacion;
                            crearpersonahistorico.EstatusPersonSolicitud = true;
                            crearpersonahistorico.IdSubUnidadOperativa = personacatb.IdSubUnidadOperativa;
                            crearpersonahistorico.IdSolicitud = _solicitud.IdSolicitud;
                            crearpersonahistorico.FinPeriodo = niveldirigencial.FinPeriodo;
                            crearpersonahistorico.IdNivelDirigencialCat = niveldirigencial.IdNivelDirigencialCat;
                            crearpersonahistorico.EstatusNivelDirigencial = niveldirigencial.EstatusNivelDirigencial;
                            crearpersonahistorico.FechaIngresoNivel = niveldirigencial.FechaIngreso;
                            crearpersonahistorico.Periodo = niveldirigencial.Periodo;
                            crearpersonahistorico.Aperiodo = niveldirigencial.Aperiodo;
                            crearpersonahistorico.IdCondicionIngreso = niveldirigencial.IdCondicionIngreso;
                            crearpersonahistorico.Participacion = personacatb.Participacion;
                            context.PersonaSolicitudHists.Add(crearpersonahistorico);
                            context.SaveChanges();

                        }
                        _solicitud.EstatusSolicitud = false;
                        context.SaveChanges();
                    }
                }
                if (_solicitud.Estatus == "Pendiente" && solicitud.IdTipoMovimiento == 2)
                {
                    var _usuariopersona = context.Usuarios.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();
                    if (_usuariopersona != null)
                    {

                        _usuariopersona.EstatusUsuario = false;
                        context.SaveChanges();
                    }

                }


                //crear solicitud por responsable
                if (solicitud.IdSolicitud != 0)
                {
                    foreach (var item in listaresponsableplaza)
                    {
                        var solicitudresponsableplaza = new SolicitudResponsablePlaza();

                        solicitudresponsableplaza.IdSolicitud = solicitud.IdSolicitud;
                        solicitudresponsableplaza.IdResponsablePlaza = item.IdResponsablePlaza;
                        context.SolicitudResponsablePlazas.Add(solicitudresponsableplaza);
                        context.SaveChanges();
                    }
                }

                var correo = EnviarNotificacionSolicitudCreacion(solicitud.IdSolicitud, listSolicitudSolicitante.CorreoAcceso);
                return _solicitud;

            }
            catch (Exception e)
            {
                Logger.Error("crear solicitud", e);
                return solicitud;
            }
        }


        public bool DesactivarSolicitud(int idsolicitud)
        {
            var _soliciud = context.Solicitudes.Where(x => x.IdSolicitud == idsolicitud).SingleOrDefault();
            if (_soliciud == null)
                return false;
            try
            {
                _soliciud.EstatusSolicitud = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar Solicitudes", ex);
                return false;
            }
        }

        public bool EnviarNotificacionSolicitudCreacion(int idSolicitud, string correoAcceso)
        {
            //            al crear solicitud(en la creacion de bajas no)
            //            enviar correo a los analistas asignados(responsables plaza asignados)

            //            *checar lo de ODG, se debe enviar solo si es ODG..., de donde sale ??? -->
            //            si el que genera la solicitud es un responsable de plaza, no se envía nada
            //            de notificaciones solo se da de alta en automatico el dirigente


            // Información de Responsable de Plaza:que tengan permiso en el submodulo con id 28  y que los permisos sean Todos o Autorizar
            try
            {
                var informacionResponsablePlaza = (from user1 in context.Usuarios
                                                   join pers1 in context.PersonaCats
                                                   on user1.IdPersona equals pers1.IdPersona
                                                   join perf1 in context.PerfilCargos
                                                   on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                                                   join perm1 in context.Permisos
                                                   on perf1.IdPerfilCargo equals perm1.IdPerfilCargo
                                                   join sub in context.SubModuloCats
                                                   on perm1.IdSubModulo equals sub.IdSubModulo
                                                   where user1.CorreoAcceso == correoAcceso && sub.IdSubModulo == 28 && (perm1.Todos == true || perm1.Autorizar == true)

                                                   select new UsuarioPersonaPerfil

                                                   {
                                                       IdUsuario = user1.IdUsuario,
                                                       CorreoAcceso = user1.CorreoAcceso,
                                                       Perfil = perf1.Descripcion,
                                                       NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                                                       IdPersona = user1.IdPersona

                                                   }).ToList();

                // Informacion de la solicitud
                var informacionSolicitud = (from sol in context.Solicitudes
                                            join solRes in context.SolicitudResponsablePlazas
                                            on sol.IdSolicitud equals solRes.IdSolicitud
                                            join resp in context.ResponsablePlazas
                                            on solRes.IdResponsablePlaza equals resp.IdResponsablePlaza
                                            join pers in context.PersonaCats
                                            on resp.IdPersona equals pers.IdPersona
                                            join usu in context.Usuarios
                                            on resp.IdPersona equals usu.IdPersona
                                            where sol.IdSolicitud == idSolicitud
                                            && resp.Estatus == true

                                            select new SolicitudNotificacion

                                            {
                                                // Solicitud
                                                IdSolicitud = sol.IdSolicitud,
                                                //// Responsable
                                                NombrePersonaResponsable = pers.NombrePersona,
                                                ApellidoPaternoResponsable = pers.ApellidoPaterno,
                                                ApellidoMaternoResponsable = pers.ApellidoMaterno,
                                                CorreoAccesoResponsable = usu.CorreoAcceso
                                            }).ToList();

                //En caso de que el solicitante NO sea responsable de paza si se envía notificación
                if (informacionResponsablePlaza.Count == 0)
                {
                    List<string> addListTo = new List<string>();
                    var subject = "";
                    var isBodyHTML = true;
                    var body = "";
                    var addCc = "";
                    var addCco = "";

                    // Inserta correos de responsables
                    foreach (var infoSol in informacionSolicitud)
                    {
                        addListTo.Add(infoSol.CorreoAccesoResponsable);
                        subject = "Creacion de Solicitud con Id: " + infoSol.IdSolicitud;
                        body = "Se ha creado la solicitud con Id: " + infoSol.IdSolicitud + " favor de darle seguimiento.";
                    }

                    //EnviarEmail email = new EnviarEmail();
                    // email.EnviarCorreoSolicitudNotificacion(addListTo, subject, isBodyHTML, addCc, addCco, body);

                    IMailService _mail = new MailService();
                    MailData mailData = new MailData();
                    // List<string> lstCorreos = new List<string>();
                    //lstCorreos.Add("sysba044@cpm.coop");
                    mailData.To = addListTo;
                    //lstCorreos;
                    mailData.Subject = subject;
                    var testplantilla = _mail.GetEmailTemplate("emailTemplateFormulario");
                    mailData.Body = testplantilla.Replace("[[[varBodyMessage]]]", body);
                    bool result = _mail.Send(mailData);



                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("EnviarNotificacionSolicitudCreacion SolicitudNotificacion", ex);
                return false;
            }
        }

        public bool EnviarNotificacionSolicitudAutorizacion(int idSolicitud, string correoAcceso)
        {
            //            al autorizar solicitud... en edicion de solicitudes al dar estatus de aprobado

            //            a quien enviar???? al solicitante, si el que genera la solicitud es un responsable de plaza, no se envía nada
            //            de notificacione            

            // Información de Responsable de Plaza:que tengan permiso en el submodulo con id 28  y que los permisos sean Todos o Autorizar
            try
            {
                var informacionResponsablePlaza = (from user1 in context.Usuarios
                                                   join pers1 in context.PersonaCats
                                                   on user1.IdPersona equals pers1.IdPersona
                                                   join perf1 in context.PerfilCargos
                                                   on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                                                   join perm1 in context.Permisos
                                                   on perf1.IdPerfilCargo equals perm1.IdPerfilCargo
                                                   join sub in context.SubModuloCats
                                                   on perm1.IdSubModulo equals sub.IdSubModulo
                                                   where user1.CorreoAcceso == correoAcceso && sub.IdSubModulo == 28 && (perm1.Todos == true || perm1.Autorizar == true)

                                                   select new UsuarioPersonaPerfil

                                                   {
                                                       IdUsuario = user1.IdUsuario,
                                                       CorreoAcceso = user1.CorreoAcceso,
                                                       Perfil = perf1.Descripcion,
                                                       NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                                                       IdPersona = user1.IdPersona

                                                   }).ToList();

                // Información de Solicitante
                var informacionSolicitante = (from user1 in context.Usuarios
                                              join pers1 in context.PersonaCats
                                              on user1.IdPersona equals pers1.IdPersona
                                              where user1.CorreoAcceso == correoAcceso

                                              select new UsuarioPersonaPerfil

                                              {
                                                  IdUsuario = user1.IdUsuario,
                                                  CorreoAcceso = user1.CorreoAcceso
                                              }).ToList();

                // Informacion de la solicitud
                var informacionSolicitud = (from sol in context.Solicitudes
                                                //join solRes in context.SolicitudResponsablePlazas
                                                // on sol.IdSolicitud equals solRes.IdSolicitud
                                                // join resp in context.ResponsablePlazas
                                                // on solRes.IdResponsablePlaza equals resp.IdResponsablePlaza
                                            join pers in context.PersonaCats
                                            on sol.IdPersona equals pers.IdPersona
                                            join usu in context.Usuarios
                                            on pers.IdPersona equals usu.IdPersona
                                            where sol.IdSolicitud == idSolicitud

                                            select new SolicitudNotificacion

                                            {
                                                // Solicitud
                                                IdSolicitud = sol.IdSolicitud,

                                                //// Responsable
                                                NombrePersonaResponsable = pers.NombrePersona,
                                                ApellidoPaternoResponsable = pers.ApellidoPaterno,
                                                ApellidoMaternoResponsable = pers.ApellidoMaterno,
                                                CorreoAccesoResponsable = usu.CorreoAcceso
                                            }).ToList();

                //En caso de que el solicitante NO sea responsable de paza si se envía notificación
                if (informacionResponsablePlaza.Count == 0)
                {
                    List<string> addListTo = new List<string>();
                    var subject = "";
                    var isBodyHTML = true;
                    var body = "";
                    var addCc = "";
                    var addCco = "";

                    // Inserta correo de Solicitante              
                    addListTo.Add(correoAcceso);

                    // Inserta correos de responsables
                    foreach (var infoSol in informacionSolicitud)
                    {
                        addListTo.Add(infoSol.CorreoAccesoResponsable);
                        subject = "Aprobación de Solicitud con Id: " + infoSol.IdSolicitud;
                        body = "Se ha aprobado la solicitud con Id: " + infoSol.IdSolicitud + " favor de darle seguimiento.";
                    }

                    // EnviarEmail email = new EnviarEmail();
                    //email.EnviarCorreoSolicitudNotificacion(addListTo, subject, isBodyHTML, addCc, addCco, body);
                    IMailService _mail = new MailService();
                    MailData mailData = new MailData();
                    //List<string> lstCorreos = new List<string>();
                    //lstCorreos.Add("sysba044@cpm.coop");
                    mailData.To = addListTo;
                    mailData.Subject = subject; ;
                    var testplantilla = _mail.GetEmailTemplate("emailTemplateFormulario");
                    mailData.Body = testplantilla.Replace("[[[varBodyMessage]]]", body);
                    bool result = _mail.Send(mailData);


                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("EnviarNotificacionSolicitudAutorizacion SolicitudNotificacion", ex);
                return false;
            }
        }

        public bool EnviarNotificacionSolicitudObservaciones(int idSolicitud, string correoAcceso)
        {
            //            al agregar observaciones de solicitud... en edicion de solicitudes al dar estatus de observaciones

            //            a quien enviar???? al solicitante, si el que genera la solicitud es un responsable de plaza, no se envía nada
            //            de notificacione

            // Información de Responsable de Plaza:que tengan permiso en el submodulo con id 28  y que los permisos sean Todos o Autorizar
            try
            {
                var informacionResponsablePlaza = (from user1 in context.Usuarios
                                                   join pers1 in context.PersonaCats
                                                   on user1.IdPersona equals pers1.IdPersona
                                                   join perf1 in context.PerfilCargos
                                                   on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                                                   join perm1 in context.Permisos
                                                   on perf1.IdPerfilCargo equals perm1.IdPerfilCargo
                                                   join sub in context.SubModuloCats
                                                   on perm1.IdSubModulo equals sub.IdSubModulo
                                                   where user1.CorreoAcceso == correoAcceso && sub.IdSubModulo == 28 && (perm1.Todos == true || perm1.Autorizar == true)

                                                   select new UsuarioPersonaPerfil

                                                   {
                                                       IdUsuario = user1.IdUsuario,
                                                       CorreoAcceso = user1.CorreoAcceso,
                                                       Perfil = perf1.Descripcion,
                                                       NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                                                       IdPersona = user1.IdPersona

                                                   }).ToList();

                // Información de Solicitante
                var informacionSolicitante = (from user1 in context.Usuarios
                                              join pers1 in context.PersonaCats
                                              on user1.IdPersona equals pers1.IdPersona
                                              where user1.CorreoAcceso == correoAcceso

                                              select new UsuarioPersonaPerfil

                                              {
                                                  IdUsuario = user1.IdUsuario,
                                                  CorreoAcceso = user1.CorreoAcceso
                                              }).ToList();

                // Informacion de la solicitud
                var informacionSolicitud = (from sol in context.Solicitudes
                                                //join solRes in context.SolicitudResponsablePlazas
                                                // on sol.IdSolicitud equals solRes.IdSolicitud
                                                // join resp in context.ResponsablePlazas
                                                // on solRes.IdResponsablePlaza equals resp.IdResponsablePlaza
                                            join pers in context.PersonaCats
                                            on sol.IdPersona equals pers.IdPersona
                                            join usu in context.Usuarios
                                            on pers.IdPersona equals usu.IdPersona
                                            where sol.IdSolicitud == idSolicitud

                                            select new SolicitudNotificacion

                                            {
                                                // Solicitud
                                                IdSolicitud = sol.IdSolicitud,

                                                //// Responsable
                                                NombrePersonaResponsable = pers.NombrePersona,
                                                ApellidoPaternoResponsable = pers.ApellidoPaterno,
                                                ApellidoMaternoResponsable = pers.ApellidoMaterno,
                                                CorreoAccesoResponsable = usu.CorreoAcceso
                                            }).ToList();

                //En caso de que el solicitante NO sea responsable de paza si se envía notificación
                if (informacionResponsablePlaza.Count == 0)
                {
                    List<string> addListTo = new List<string>();
                    var subject = "";
                    var isBodyHTML = true;
                    var body = "";
                    var addCc = "";
                    var addCco = "";

                    // Inserta correo de Solicitante              
                    addListTo.Add(correoAcceso);

                    // Inserta correos de responsables
                    foreach (var infoSol in informacionSolicitud)
                    {
                        addListTo.Add(infoSol.CorreoAccesoResponsable);
                        subject = "Observaciones de Solicitud con Id: " + infoSol.IdSolicitud;
                        body = "Se han capturado observaciones en la solicitud con Id: " + infoSol.IdSolicitud + " favor de darle seguimiento.";
                    }

                    // EnviarEmail email = new EnviarEmail();
                    //email.EnviarCorreoSolicitudNotificacion(addListTo, subject, isBodyHTML, addCc, addCco, body);
                    IMailService _mail = new MailService();
                    MailData mailData = new MailData();
                    //List<string> lstCorreos = new List<string>();
                    //lstCorreos.Add("sysba044@cpm.coop");
                    mailData.To = addListTo;
                    mailData.Subject = subject; ;
                    var testplantilla = _mail.GetEmailTemplate("emailTemplateFormulario");
                    mailData.Body = testplantilla.Replace("[[[varBodyMessage]]]", body);
                    bool result = _mail.Send(mailData);

                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("EnviarNotificacionSolicitudObservaciones SolicitudNotificacion", ex);
                return false;
            }
        }

        public bool EnviarNotificacionSolicitudRechazada(int idSolicitud, string correoAcceso)
        {
            //            al agregar observaciones de solicitud... en edicion de solicitudes al dar estatus de observaciones

            //            a quien enviar???? al solicitante, si el que genera la solicitud es un responsable de plaza, no se envía nada
            //            de notificacione

            // Información de Responsable de Plaza:que tengan permiso en el submodulo con id 28  y que los permisos sean Todos o Autorizar
            try
            {
                var informacionResponsablePlaza = (from user1 in context.Usuarios
                                                   join pers1 in context.PersonaCats
                                                   on user1.IdPersona equals pers1.IdPersona
                                                   join perf1 in context.PerfilCargos
                                                   on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                                                   join perm1 in context.Permisos
                                                   on perf1.IdPerfilCargo equals perm1.IdPerfilCargo
                                                   join sub in context.SubModuloCats
                                                   on perm1.IdSubModulo equals sub.IdSubModulo
                                                   where user1.CorreoAcceso == correoAcceso
                                                   && sub.IdSubModulo == 28
                                                   && (perm1.Todos == true || perm1.Autorizar == true)


                                                   select new UsuarioPersonaPerfil

                                                   {
                                                       IdUsuario = user1.IdUsuario,
                                                       CorreoAcceso = user1.CorreoAcceso,
                                                       Perfil = perf1.Descripcion,
                                                       NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                                                       IdPersona = user1.IdPersona

                                                   }).ToList();

                // Información de Solicitante
                var informacionSolicitante = (from user1 in context.Usuarios
                                              join pers1 in context.PersonaCats
                                              on user1.IdPersona equals pers1.IdPersona
                                              where user1.CorreoAcceso == correoAcceso

                                              select new UsuarioPersonaPerfil

                                              {
                                                  IdUsuario = user1.IdUsuario,
                                                  CorreoAcceso = user1.CorreoAcceso
                                              }).ToList();

                // Informacion de la solicitud
                var informacionSolicitud = (from sol in context.Solicitudes
                                                //join solRes in context.SolicitudResponsablePlazas
                                                //on sol.IdSolicitud equals solRes.IdSolicitud
                                                //join resp in context.ResponsablePlazas
                                                //on solRes.IdResponsablePlaza equals resp.IdResponsablePlaza
                                            join pers in context.PersonaCats
                                            on sol.IdPersona equals pers.IdPersona
                                            join usu in context.Usuarios
                                            on pers.IdPersona equals usu.IdPersona
                                            where sol.IdSolicitud == idSolicitud


                                            select new SolicitudNotificacion

                                            {
                                                // Solicitud
                                                IdSolicitud = sol.IdSolicitud,

                                                //// Responsable
                                                NombrePersonaResponsable = pers.NombrePersona,
                                                ApellidoPaternoResponsable = pers.ApellidoPaterno,
                                                ApellidoMaternoResponsable = pers.ApellidoMaterno,
                                                CorreoAccesoResponsable = usu.CorreoAcceso
                                            }).ToList();

                //En caso de que el solicitante NO sea responsable de paza si se envía notificación
                if (informacionResponsablePlaza.Count == 0)
                {
                    List<string> addListTo = new List<string>();
                    var subject = "";
                    var isBodyHTML = true;
                    var body = "";
                    var addCc = "";
                    var addCco = "";

                    // Inserta correo de Solicitante              
                    addListTo.Add(correoAcceso);

                    // Inserta correos de responsables
                    foreach (var infoSol in informacionSolicitud)
                    {
                        addListTo.Add(infoSol.CorreoAccesoResponsable);
                        subject = "Rechazo de Solicitud con Id: " + infoSol.IdSolicitud;
                        body = "Se ha rechazado la solicitud con Id: " + infoSol.IdSolicitud + " favor de darle seguimiento.";
                    }

                    //EnviarEmail email = new EnviarEmail();
                    //email.EnviarCorreoSolicitudNotificacion(addListTo, subject, isBodyHTML, addCc, addCco, body);
                    IMailService _mail = new MailService();
                    MailData mailData = new MailData();
                    //List<string> lstCorreos = new List<string>();
                    //lstCorreos.Add("sysba044@cpm.coop");
                    mailData.To = addListTo;
                    mailData.Subject = subject; ;
                    var testplantilla = _mail.GetEmailTemplate("emailTemplateFormulario");
                    mailData.Body = testplantilla.Replace("[[[varBodyMessage]]]", body);
                    bool result = _mail.Send(mailData);


                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("EnviarNotificacionSolicitudRechazada SolicitudNotificacion", ex);
                return false;
            }
        }

        public bool ModificarSolicitud(Solicitud solicitud)
        {
            try
            {
                var _solicitud = context.Solicitudes.Where(x => x.IdSolicitud == solicitud.IdSolicitud).SingleOrDefault();
                if (_solicitud == null)
                    return false;
                else
                {

                    _solicitud.IdPersona = solicitud.IdPersona;
                    //_solicitud.IdResponsablePlaza = solicitud.IdResponsablePlaza;
                    _solicitud.Estatus = solicitud.Estatus;
                    _solicitud.IdTipoMovimiento = solicitud.IdTipoMovimiento;
                    _solicitud.FechaSolicitud = solicitud.FechaSolicitud;
                    _solicitud.Observaciones = solicitud.Observaciones;
                    _solicitud.IdMotivoBaja = solicitud.IdMotivoBaja;
                    _solicitud.EstatusSolicitud = solicitud.EstatusSolicitud;
                    //_solicitud.IdPersonaSolicitante = solicitud.IdPersonaSolicitante;
                    context.SaveChanges();

                }
                //obntener correo de la personasolicitante
                var listSolicitudSolicitante = (from soliciudes in context.Solicitudes
                                                join persona in context.PersonaCats
                                                on soliciudes.IdPersonaSolicitante equals persona.IdPersona
                                                join usuarios in context.Usuarios
                                                on persona.IdPersona equals usuarios.IdPersona
                                                where soliciudes.IdSolicitud == solicitud.IdSolicitud
                                                select usuarios).FirstOrDefault();


                if (solicitud.Estatus == "Aprobado")
                {
                    var _solicitudaprobada = context.Solicitudes.Where(x => x.IdSolicitud == solicitud.IdSolicitud).SingleOrDefault();
                    //actualiza solicitud
                    _solicitudaprobada.EstatusSolicitud = false;

                    context.SaveChanges();

                    //1 alta
                    if (solicitud.Estatus == "Aprobado" && solicitud.IdTipoMovimiento == 1)
                    {


                        var personacatx = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == solicitud.IdSolicitud).FirstOrDefault();

                        if (personacatx != null)
                        {
                            var _persona = context.PersonaCats.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                            //var _persona = new PersonaCat();

                            //_persona.IdPersona = persona.IdPersona;
                            _persona.NombrePersona = personacatx.NombrePersona;
                            _persona.ApellidoPaterno = personacatx.ApellidoPaterno;
                            _persona.ApellidoMaterno = personacatx.ApellidoMaterno;
                            _persona.EstatusPersona = personacatx.EstatusPersona;
                            _persona.IdTipoPersona = personacatx.IdTipoPersona;
                            _persona.IdGenero = personacatx.IdGenero;
                            _persona.IdEstadoCivil = personacatx.IdEstadoCivil;
                            _persona.CorreoPersonal = personacatx.CorreoPersonal;
                            _persona.IdOficio = personacatx.IdOficio;
                            _persona.IdEscolaridad = personacatx.IdEscolaridad;
                            _persona.FechaNacimiento = personacatx.FechaNacimiento;
                            _persona.Rfc = personacatx.Rfc;
                            _persona.Curp = personacatx.Curp;
                            _persona.Edad = personacatx.Edad;
                            _persona.CodigoPostal = personacatx.CodigoPostal;
                            _persona.Celular = personacatx.Celular;
                            _persona.FechaIngreso = personacatx.FechaIngreso;
                            _persona.FechaBaja = personacatx.FechaBaja;
                            _persona.Cif = personacatx.Cif;
                            //_persona.Dirigente = personacatx.Dirigente;
                            _persona.IdDirigente = personacatx.IdDirigente;
                            _persona.IdProfesion = personacatx.IdProfesion;
                            _persona.Calle = personacatx.Calle;
                            _persona.NumeroInterior = personacatx.NumeroInterior;
                            _persona.Colonia = personacatx.Colonia;
                            _persona.Estado = personacatx.Estado;
                            _persona.Municipio = personacatx.Municipio;
                            _persona.IdCargo = personacatx.IdCargo;
                            _persona.IdSubUnidadOperativa = personacatx.IdSubUnidadOperativa;
                            _persona.Participacion = personacatx.Participacion;
                            _persona.Dirigente = true;


                            context.SaveChanges();

                            var _niveldirigencial = new NivelDirigencial();
                            _niveldirigencial.IdNivelDirigencialCat = (int)personacatx.IdNivelDirigencialCat;
                            _niveldirigencial.IdPersona = personacatx.IdPersona;
                            _niveldirigencial.EstatusNivelDirigencial = true;
                            _niveldirigencial.FechaIngreso = personacatx.FechaIngresoNivel;
                            _niveldirigencial.FinPeriodo = personacatx.FinPeriodo;
                            _niveldirigencial.Aperiodo = personacatx.Aperiodo;
                            _niveldirigencial.IdCondicionIngreso = personacatx.IdCondicionIngreso;
                            context.NivelDirigencials.Add(_niveldirigencial);
                            context.SaveChanges();
                        }

                    }
                    //2 Baja
                    if (solicitud.Estatus == "Aprobado" && solicitud.IdTipoMovimiento == 2)
                    {


                        var personacatx = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == solicitud.IdSolicitud).FirstOrDefault();

                        if (personacatx != null)
                        {
                            var _persona = context.PersonaCats.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                            //var _persona = new PersonaCat();

                            //_persona.IdPersona = persona.IdPersona;
                            _persona.NombrePersona = personacatx.NombrePersona;
                            _persona.ApellidoPaterno = personacatx.ApellidoPaterno;
                            _persona.ApellidoMaterno = personacatx.ApellidoMaterno;
                            _persona.EstatusPersona = false;
                            _persona.IdTipoPersona = personacatx.IdTipoPersona;
                            _persona.IdGenero = personacatx.IdGenero;
                            _persona.IdEstadoCivil = personacatx.IdEstadoCivil;
                            _persona.CorreoPersonal = personacatx.CorreoPersonal;
                            _persona.IdOficio = personacatx.IdOficio;
                            _persona.IdEscolaridad = personacatx.IdEscolaridad;
                            _persona.FechaNacimiento = personacatx.FechaNacimiento;
                            _persona.Rfc = personacatx.Rfc;
                            _persona.Curp = personacatx.Curp;
                            _persona.Edad = personacatx.Edad;
                            _persona.CodigoPostal = personacatx.CodigoPostal;
                            _persona.Celular = personacatx.Celular;
                            _persona.FechaIngreso = personacatx.FechaIngreso;
                            _persona.FechaBaja = personacatx.FechaBaja;
                            _persona.Cif = personacatx.Cif;
                            //_persona.Dirigente = personacatx.Dirigente;
                            _persona.IdDirigente = personacatx.IdDirigente;
                            _persona.IdProfesion = personacatx.IdProfesion;
                            _persona.Calle = personacatx.Calle;
                            _persona.NumeroInterior = personacatx.NumeroInterior;
                            _persona.Colonia = personacatx.Colonia;
                            _persona.Estado = personacatx.Estado;
                            _persona.Municipio = personacatx.Municipio;
                            _persona.IdCargo = personacatx.IdCargo;
                            _persona.IdSubUnidadOperativa = personacatx.IdSubUnidadOperativa;
                            _persona.Participacion = personacatx.Participacion;
                            _persona.Dirigente = true;

                            context.SaveChanges();



                        }

                        var _usuariopersona = context.Usuarios.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                        if (_usuariopersona != null)
                        {

                            _usuariopersona.EstatusUsuario = false;
                            context.SaveChanges();
                        }

                    }
                    //3 Reingreso
                    if (solicitud.Estatus == "Aprobado" && solicitud.IdTipoMovimiento == 3)
                    {

                        var personacatx = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == solicitud.IdSolicitud).FirstOrDefault();

                        if (personacatx != null)
                        {
                            var _persona = context.PersonaCats.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                            //var _persona = new PersonaCat();

                            //_persona.IdPersona = persona.IdPersona;
                            _persona.NombrePersona = personacatx.NombrePersona;
                            _persona.ApellidoPaterno = personacatx.ApellidoPaterno;
                            _persona.ApellidoMaterno = personacatx.ApellidoMaterno;
                            _persona.EstatusPersona = true;
                            _persona.IdTipoPersona = personacatx.IdTipoPersona;
                            _persona.IdGenero = personacatx.IdGenero;
                            _persona.IdEstadoCivil = personacatx.IdEstadoCivil;
                            _persona.CorreoPersonal = personacatx.CorreoPersonal;
                            _persona.IdOficio = personacatx.IdOficio;
                            _persona.IdEscolaridad = personacatx.IdEscolaridad;
                            _persona.FechaNacimiento = personacatx.FechaNacimiento;
                            _persona.Rfc = personacatx.Rfc;
                            _persona.Curp = personacatx.Curp;
                            _persona.Edad = personacatx.Edad;
                            _persona.CodigoPostal = personacatx.CodigoPostal;
                            _persona.Celular = personacatx.Celular;
                            _persona.FechaIngreso = personacatx.FechaIngreso;
                            _persona.FechaBaja = personacatx.FechaBaja;
                            _persona.Cif = personacatx.Cif;
                            //_persona.Dirigente = personacatx.Dirigente;
                            _persona.IdDirigente = personacatx.IdDirigente;
                            _persona.IdProfesion = personacatx.IdProfesion;
                            _persona.Calle = personacatx.Calle;
                            _persona.NumeroInterior = personacatx.NumeroInterior;
                            _persona.Colonia = personacatx.Colonia;
                            _persona.Estado = personacatx.Estado;
                            _persona.Municipio = personacatx.Municipio;
                            _persona.IdCargo = personacatx.IdCargo;
                            _persona.IdSubUnidadOperativa = personacatx.IdSubUnidadOperativa;
                            _persona.Participacion = personacatx.Participacion;
                            _persona.Dirigente = true;

                            context.SaveChanges();

                            var _niveldirigencial = context.NivelDirigencials.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();

                            _niveldirigencial.IdNivelDirigencialCat = (int)personacatx.IdNivelDirigencialCat;
                            _niveldirigencial.IdPersona = personacatx.IdPersona;
                            _niveldirigencial.FechaIngreso = personacatx.FechaIngresoNivel;
                            _niveldirigencial.FinPeriodo = personacatx.FinPeriodo;
                            _niveldirigencial.Aperiodo = personacatx.Aperiodo;
                            _niveldirigencial.IdCondicionIngreso = personacatx.IdCondicionIngreso;
                            //context.NivelDirigencials.Update(_niveldirigencial);
                            context.SaveChanges();

                        }
                        //var _usuariopersona = context.Usuarios.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                        // Se dejó la activación del usuario de foma manual
                        //if (_usuariopersona != null)
                        //{
                        //    _usuariopersona.EstatusUsuario = true;
                        //    context.SaveChanges();
                        //}

                    }
                    //4 Modificación
                    if (solicitud.Estatus == "Aprobado" && solicitud.IdTipoMovimiento == 4)
                    {

                        var personacatx = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == solicitud.IdSolicitud).FirstOrDefault();

                        if (personacatx != null)
                        {
                            var _persona = context.PersonaCats.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();
                            //var _persona = new PersonaCat();

                            //_persona.IdPersona = persona.IdPersona;
                            _persona.NombrePersona = personacatx.NombrePersona;
                            _persona.ApellidoPaterno = personacatx.ApellidoPaterno;
                            _persona.ApellidoMaterno = personacatx.ApellidoMaterno;
                            _persona.EstatusPersona = personacatx.EstatusPersona;
                            _persona.IdTipoPersona = personacatx.IdTipoPersona;
                            _persona.IdGenero = personacatx.IdGenero;
                            _persona.IdEstadoCivil = personacatx.IdEstadoCivil;
                            _persona.CorreoPersonal = personacatx.CorreoPersonal;
                            _persona.IdOficio = personacatx.IdOficio;
                            _persona.IdEscolaridad = personacatx.IdEscolaridad;
                            _persona.FechaNacimiento = personacatx.FechaNacimiento;
                            _persona.Rfc = personacatx.Rfc;
                            _persona.Curp = personacatx.Curp;
                            _persona.Edad = personacatx.Edad;
                            _persona.CodigoPostal = personacatx.CodigoPostal;
                            _persona.Celular = personacatx.Celular;
                            _persona.FechaIngreso = personacatx.FechaIngreso;
                            _persona.FechaBaja = personacatx.FechaBaja;
                            _persona.Cif = personacatx.Cif;
                            //_persona.Dirigente = personacatx.Dirigente;
                            _persona.IdDirigente = personacatx.IdDirigente;
                            _persona.IdProfesion = personacatx.IdProfesion;
                            _persona.Calle = personacatx.Calle;
                            _persona.NumeroInterior = personacatx.NumeroInterior;
                            _persona.Colonia = personacatx.Colonia;
                            _persona.Estado = personacatx.Estado;
                            _persona.Municipio = personacatx.Municipio;
                            _persona.IdCargo = personacatx.IdCargo;
                            _persona.IdSubUnidadOperativa = personacatx.IdSubUnidadOperativa;
                            _persona.Participacion = personacatx.Participacion;
                            _persona.Dirigente = true;
                            context.SaveChanges();

                            var _niveldirigencial = context.NivelDirigencials.Where(x => x.IdPersona == personacatx.IdPersona).FirstOrDefault();

                            _niveldirigencial.IdNivelDirigencialCat = (int)personacatx.IdNivelDirigencialCat;
                            _niveldirigencial.IdPersona = personacatx.IdPersona;
                            _niveldirigencial.EstatusNivelDirigencial = true;
                            _niveldirigencial.FechaIngreso = personacatx.FechaIngresoNivel;
                            _niveldirigencial.FinPeriodo = personacatx.FinPeriodo;
                            _niveldirigencial.Aperiodo = personacatx.Aperiodo;
                            _niveldirigencial.IdCondicionIngreso = personacatx.IdCondicionIngreso;
                            //context.NivelDirigencials.Update(_niveldirigencial);
                            context.SaveChanges();

                        }

                    }
                }
                if (solicitud.Estatus == "Rechazada")
                {

                    _solicitud.EstatusSolicitud = true;
                    _solicitud.IdPersona = solicitud.IdPersona;
                    //_solicitud.IdResponsablePlaza = solicitud.IdResponsablePlaza;
                    _solicitud.Estatus = solicitud.Estatus;
                    _solicitud.IdTipoMovimiento = solicitud.IdTipoMovimiento;
                    _solicitud.FechaSolicitud = solicitud.FechaSolicitud;
                    _solicitud.Observaciones = solicitud.Observaciones;
                    _solicitud.IdMotivoBaja = solicitud.IdMotivoBaja;
                    _solicitud.IdPersonaSolicitante = solicitud.IdPersonaSolicitante;
                    context.SaveChanges();

                    if (solicitud.Estatus == "Rechazada" && solicitud.IdTipoMovimiento == 2)
                    {


                        var _usuariopersona = context.Usuarios.Where(x => x.IdPersona == solicitud.IdPersona).FirstOrDefault();
                        if (_usuariopersona != null)
                        {

                            _usuariopersona.EstatusUsuario = true;
                            context.SaveChanges();
                        }

                    }

                }




                if (_solicitud.Estatus == "Aprobado")
                {
                    var correo = EnviarNotificacionSolicitudAutorizacion(solicitud.IdSolicitud, listSolicitudSolicitante.CorreoAcceso);
                }

                if (_solicitud.Estatus == "En revisión")
                {
                    var correo = EnviarNotificacionSolicitudObservaciones(solicitud.IdSolicitud, listSolicitudSolicitante.CorreoAcceso);
                }
                if (_solicitud.Estatus == "Rechazada")
                {
                    var correo = EnviarNotificacionSolicitudRechazada(solicitud.IdSolicitud, listSolicitudSolicitante.CorreoAcceso);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion Solicitud", ex);
                return false;

            }
        }

        public List<Solicitud> ObtenerSolicitud()
        {
            try
            {
                return context.Solicitudes.ToList();
            }
            catch (Exception ex)
            {
                Logger.Error("ObtenerSolicitud Solicitud", ex);
                return null;

            }


        }

        public List<SolicitudPersonaResponsable> ObtenerSolicitudPersonaResponsable()
        {
            try
            {
                var listSolicitudSolicitante = (
               from soliciudes in context.Solicitudes
               join persona in context.PersonaCats
               on soliciudes.IdPersonaSolicitante equals persona.IdPersona


               select new PersonaSolicitud
               {
                   IdSolicitud = soliciudes.IdSolicitud,
                   IdPersona = (int)soliciudes.IdPersonaSolicitante,
                   NombrePersona = persona.NombrePersona,
                   ApellidoPaterno = persona.ApellidoPaterno,
                   ApellidoMaterno = persona.ApellidoMaterno,
                   Plaza = persona.Plaza,
                   Sucursal = persona.Sucursal,
                   NombreCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,

               }).ToList();

                var listSolicitud = (
                     from soliciudes in context.Solicitudes
                     join persona in context.PersonaCats
                     on soliciudes.IdPersona equals persona.IdPersona
                     join tipomovimiento in context.TipoMovimientos
                     on soliciudes.IdTipoMovimiento equals tipomovimiento.IdTipoMovimiento

                     select new PersonaSolicitud
                     {
                         IdSolicitud = soliciudes.IdSolicitud,
                         NombrePersona = persona.NombrePersona,
                         ApellidoPaterno = persona.ApellidoPaterno,
                         ApellidoMaterno = persona.ApellidoMaterno,
                         Plaza = persona.Plaza,
                         Sucursal = persona.Sucursal,
                         NombreCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                         IdTipoMovimiento = tipomovimiento.IdTipoMovimiento,
                         DescripcionTipoMovimiento = tipomovimiento.Descripcion,
                         IdPersona = persona.IdPersona,
                         //IdResponsablePlaza=soliciudes.IdResponsablePlaza,
                         FechaSolicitud = soliciudes.FechaSolicitud,
                         Observaciones = soliciudes.Observaciones,
                         EstatusSolicitud = soliciudes.EstatusSolicitud,
                         Estatus = soliciudes.Estatus,
                         IdMotivoBaja = soliciudes.IdMotivoBaja,
                         EstatusTipoMovimiento = tipomovimiento.Estatus,
                         IdPlaza = persona.IdPlaza,
                     }).ToList();

                var listResponsable = (from responsable in context.ResponsablePlazas
                                       join persona in context.PersonaCats
                                       on responsable.IdPersona equals persona.IdPersona

                                       select new PersonResponsable
                                       {
                                           IdPersonaResponsable = (Int32)responsable.IdPersona,
                                           NombrePersonaResponsable = persona.NombrePersona,
                                           ApellidoPaternoResponsable = persona.ApellidoPaterno,
                                           ApellidoMaternoResponsable = persona.ApellidoMaterno,
                                           NombreCompletoResponsable = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                           IdResponsablePlaza = responsable.IdResponsablePlaza,
                                           IdPlaza = responsable.IdPlaza
                                       }
                           ).ToList();




                var prueba = (
                    from xsolicitud in listSolicitud
                    join solicitudResponsable in context.SolicitudResponsablePlazas
                    on xsolicitud.IdSolicitud equals solicitudResponsable.IdSolicitud
                    join xresponsable in listResponsable
                    on solicitudResponsable.IdResponsablePlaza equals xresponsable.IdResponsablePlaza
                    join xsolicitudSolicitante in listSolicitudSolicitante
                    on xsolicitud.IdSolicitud equals xsolicitudSolicitante.IdSolicitud

                    select new SolicitudPersonaResponsable
                    {
                        NombrePersona = xsolicitud.NombrePersona,
                        ApellidoPaterno = xsolicitud.ApellidoPaterno,
                        ApellidoMaterno = xsolicitud.ApellidoMaterno,
                        NombreCompleto = xsolicitud.NombreCompleto,
                        IdSolicitud = xsolicitud.IdSolicitud,
                        Plaza = xsolicitud.Plaza,
                        Sucursal = xsolicitud.Sucursal,
                        //IdResponsablePlaza = xsolicitud.IdResponsablePlaza,
                        Estatus = xsolicitud.Estatus,
                        IdTipoMovimiento = xsolicitud.IdTipoMovimiento,
                        FechaSolicitud = xsolicitud.FechaSolicitud,
                        Observaciones = xsolicitud.Observaciones,
                        EstatusSolicitud = xsolicitud.EstatusSolicitud,
                        DescripcionTipoMovimiento = xsolicitud.DescripcionTipoMovimiento,
                        EstatusTipoMovimiento = xsolicitud.EstatusTipoMovimiento,
                        IdPersonaResponsable = xresponsable.IdPersonaResponsable,
                        NombrePersonaResponsable = xresponsable.NombrePersonaResponsable,
                        ApellidoPaternoResponsable = xresponsable.ApellidoMaternoResponsable,
                        ApellidoMaternoResponsable = xresponsable.ApellidoMaternoResponsable,
                        NombreCompletoResponsable = xresponsable.NombreCompletoResponsable,
                        IdPlaza = xresponsable.IdPlaza,
                        //EstatusResponsable = xresponsable.EstatusResponsable,
                        IdResponsablePlaza = xresponsable.IdResponsablePlaza,
                        IdMotivoBaja = xsolicitud.IdMotivoBaja,
                        FechaRegistro = solicitudResponsable.FechaRegistro,
                        NombreCompletoSolicitante = xsolicitudSolicitante.NombreCompleto,

                    }).ToList();

                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("SolicitudPersonaResponsable SolicitudPersonaResponsable", ex);
                return null;
            }
        }
        public List<SolicitudPersonaResponsable> ConsultarSolicitudesbyIdresponsable(int idPersonaresponsable)
        {
            try
            {
                var listSolicitudSolicitante = (
               from soliciudes in context.Solicitudes
               join persona in context.PersonaCats
               on soliciudes.IdPersonaSolicitante equals persona.IdPersona


               select new PersonaSolicitud
               {
                   IdSolicitud = soliciudes.IdSolicitud,
                   IdPersona = (int)soliciudes.IdPersonaSolicitante,
                   NombrePersona = persona.NombrePersona,
                   ApellidoPaterno = persona.ApellidoPaterno,
                   ApellidoMaterno = persona.ApellidoMaterno,
                   Plaza = persona.Plaza,
                   Sucursal = persona.Sucursal,
                   NombreCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,

               }).ToList();

                var listSolicitud = (
                     from soliciudes in context.Solicitudes
                     join persona in context.PersonaCats
                     on soliciudes.IdPersona equals persona.IdPersona
                     join tipomovimiento in context.TipoMovimientos
                     on soliciudes.IdTipoMovimiento equals tipomovimiento.IdTipoMovimiento

                     select new PersonaSolicitud
                     {
                         IdSolicitud = soliciudes.IdSolicitud,
                         NombrePersona = persona.NombrePersona,
                         ApellidoPaterno = persona.ApellidoPaterno,
                         ApellidoMaterno = persona.ApellidoMaterno,
                         Plaza = persona.Plaza,
                         Sucursal = persona.Sucursal,
                         NombreCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                         IdTipoMovimiento = tipomovimiento.IdTipoMovimiento,
                         DescripcionTipoMovimiento = tipomovimiento.Descripcion,
                         IdPersona = persona.IdPersona,
                         //IdResponsablePlaza=soliciudes.IdResponsablePlaza,
                         IdPersonaSolicitante = soliciudes.IdPersonaSolicitante,
                         FechaSolicitud = soliciudes.FechaSolicitud,
                         Observaciones = soliciudes.Observaciones,
                         EstatusSolicitud = soliciudes.EstatusSolicitud,
                         Estatus = soliciudes.Estatus,
                         IdMotivoBaja = soliciudes.IdMotivoBaja,
                         EstatusTipoMovimiento = tipomovimiento.Estatus,
                         IdPlaza = persona.IdPlaza,
                     }).ToList();

                var listResponsable = (from responsable in context.ResponsablePlazas
                                       join persona in context.PersonaCats
                                       on responsable.IdPersona equals persona.IdPersona

                                       select new PersonResponsable
                                       {
                                           IdPersonaResponsable = (Int32)responsable.IdPersona,
                                           NombrePersonaResponsable = persona.NombrePersona,
                                           ApellidoPaternoResponsable = persona.ApellidoPaterno,
                                           ApellidoMaternoResponsable = persona.ApellidoMaterno,
                                           NombreCompletoResponsable = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                           IdResponsablePlaza = responsable.IdResponsablePlaza,
                                           IdPlaza = responsable.IdPlaza
                                       }
                           ).ToList();




                var prueba = (
                    from xsolicitud in listSolicitud
                    join solicitudResponsable in context.SolicitudResponsablePlazas
                    on xsolicitud.IdSolicitud equals solicitudResponsable.IdSolicitud
                    join xresponsable in listResponsable
                    on solicitudResponsable.IdResponsablePlaza equals xresponsable.IdResponsablePlaza
                    join xsolicitudSolicitante in listSolicitudSolicitante
                    on xsolicitud.IdSolicitud equals xsolicitudSolicitante.IdSolicitud
                    where (xresponsable.IdPersonaResponsable == idPersonaresponsable || xsolicitud.IdPersonaSolicitante == idPersonaresponsable)
                    && xsolicitud.EstatusSolicitud == true

                    select new SolicitudPersonaResponsable
                    {
                        NombrePersona = xsolicitud.NombrePersona,
                        ApellidoPaterno = xsolicitud.ApellidoPaterno,
                        ApellidoMaterno = xsolicitud.ApellidoMaterno,
                        NombreCompleto = xsolicitud.NombreCompleto,
                        IdSolicitud = xsolicitud.IdSolicitud,
                        Plaza = xsolicitud.Plaza,
                        Sucursal = xsolicitud.Sucursal,
                        //IdResponsablePlaza = xsolicitud.IdResponsablePlaza,
                        Estatus = xsolicitud.Estatus,
                        IdTipoMovimiento = xsolicitud.IdTipoMovimiento,
                        FechaSolicitud = xsolicitud.FechaSolicitud,
                        Observaciones = xsolicitud.Observaciones,
                        EstatusSolicitud = xsolicitud.EstatusSolicitud,
                        DescripcionTipoMovimiento = xsolicitud.DescripcionTipoMovimiento,
                        EstatusTipoMovimiento = xsolicitud.EstatusTipoMovimiento,
                        //IdPersonaResponsable = xresponsable.IdPersonaResponsable,
                        //NombrePersonaResponsable = xresponsable.NombrePersonaResponsable,
                        //ApellidoPaternoResponsable = xresponsable.ApellidoMaternoResponsable,
                        //ApellidoMaternoResponsable = xresponsable.ApellidoMaternoResponsable,
                        NombreCompletoResponsable = xresponsable.NombreCompletoResponsable,
                        //IdPlaza = xresponsable.IdPlaza,
                        //EstatusResponsable = xresponsable.EstatusResponsable,
                        //IdResponsablePlaza = xresponsable.IdResponsablePlaza,
                        IdMotivoBaja = xsolicitud.IdMotivoBaja,
                        FechaRegistro = solicitudResponsable.FechaRegistro,
                        IdPersonaSolicitante = xsolicitud.IdPersonaSolicitante,
                        NombreCompletoSolicitante = xsolicitudSolicitante.NombreCompleto,
                    }).ToList();


                var solicitudesfinal = (from item in prueba
                                        group item by new
                                        {
                                            item.IdSolicitud,
                                            item.NombreCompleto,
                                            item.Plaza,
                                            item.Sucursal,
                                            item.DescripcionTipoMovimiento,
                                            item.FechaSolicitud,
                                            item.Observaciones,
                                            item.Estatus,
                                            item.EstatusSolicitud,
                                            item.IdPersonaSolicitante,
                                            item.NombreCompletoSolicitante,
                                        } into g
                                        select new SolicitudPersonaResponsable
                                        {
                                            IdSolicitud = g.Key.IdSolicitud,
                                            NombreCompleto = g.Key.NombreCompleto,
                                            Plaza = g.Key.Plaza,
                                            Sucursal = g.Key.Sucursal,
                                            DescripcionTipoMovimiento = g.Key.DescripcionTipoMovimiento,
                                            FechaSolicitud = g.Key.FechaSolicitud,
                                            Observaciones = g.Key.Observaciones,
                                            Estatus = g.Key.Estatus,
                                            EstatusSolicitud = g.Key.EstatusSolicitud,
                                            IdPersonaSolicitante = g.Key.IdPersonaSolicitante,
                                            NombreCompletoSolicitante = g.Key.NombreCompletoSolicitante,
                                        }).ToList();

                if (solicitudesfinal == null)
                    return null;
                else
                    return solicitudesfinal;
            }
            catch (Exception ex)
            {
                Logger.Error("ConsultarSolicitudesbyIdresponsable SolicitudPersonaResponsable", ex);
                return null;
            }
        }
        public Solicitud SolicitudbyId(int idsolicitud)
        {
            try
            {
                var solicitud = context.Solicitudes.Where(x => x.IdSolicitud == idsolicitud).FirstOrDefault();

                if (solicitud == null)
                    return null;
                else
                    return solicitud;
            }
            catch (Exception ex)
            {
                Logger.Error("SolicitudbyId Solicitud", ex);
                return null;
            }
        }

        public SolicitudPersonaResponsable SolicitudpersonaResponsablebyId(int idsolicitud)
        {
            try
            {
                var listSolicitudSolicitante = (
              from soliciudes in context.Solicitudes
              join persona in context.PersonaCats
              on soliciudes.IdPersonaSolicitante equals persona.IdPersona


              select new PersonaSolicitud
              {
                  IdSolicitud = soliciudes.IdSolicitud,
                  IdPersona = (int)soliciudes.IdPersonaSolicitante,
                  NombrePersona = persona.NombrePersona,
                  ApellidoPaterno = persona.ApellidoPaterno,
                  ApellidoMaterno = persona.ApellidoMaterno,
                  Plaza = persona.Plaza,
                  Sucursal = persona.Sucursal,
                  NombreCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,

              }).ToList();
                var listSolicitud = (
                       from soliciudes in context.Solicitudes
                       join persona in context.PersonaCats
                       on soliciudes.IdPersona equals persona.IdPersona
                       join tipomovimiento in context.TipoMovimientos
                       on soliciudes.IdTipoMovimiento equals tipomovimiento.IdTipoMovimiento

                       select new PersonaSolicitud
                       {
                           IdSolicitud = soliciudes.IdSolicitud,
                           NombrePersona = persona.NombrePersona,
                           ApellidoPaterno = persona.ApellidoPaterno,
                           ApellidoMaterno = persona.ApellidoMaterno,
                           Plaza = persona.Plaza,
                           Sucursal = persona.Sucursal,
                           NombreCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                           IdTipoMovimiento = tipomovimiento.IdTipoMovimiento,
                           DescripcionTipoMovimiento = tipomovimiento.Descripcion,
                           IdPersona = persona.IdPersona,
                           //IdResponsablePlaza = soliciudes.IdResponsablePlaza,
                           FechaSolicitud = soliciudes.FechaSolicitud,
                           Observaciones = soliciudes.Observaciones,
                           Estatus = soliciudes.Estatus,
                           EstatusSolicitud = soliciudes.EstatusSolicitud,
                           IdMotivoBaja = soliciudes.IdMotivoBaja,



                       }).ToList();
                var listResponsable = (from responsable in context.ResponsablePlazas
                                       join persona in context.PersonaCats
                                       on responsable.IdPersona equals persona.IdPersona

                                       select new PersonResponsable
                                       {
                                           IdPersonaResponsable = (Int32)responsable.IdPersona,
                                           NombrePersonaResponsable = persona.NombrePersona,
                                           ApellidoPaternoResponsable = persona.ApellidoPaterno,
                                           ApellidoMaternoResponsable = persona.ApellidoMaterno,
                                           NombreCompletoResponsable = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                           IdResponsablePlaza = responsable.IdResponsablePlaza,
                                       }
                           ).ToList();




                var prueba = (


                     from xsolicitud in listSolicitud
                     join solicitudResponsable in context.SolicitudResponsablePlazas
                     on xsolicitud.IdSolicitud equals solicitudResponsable.IdSolicitud
                     join xresponsable in listResponsable
                     on solicitudResponsable.IdResponsablePlaza equals xresponsable.IdResponsablePlaza
                     join xsolicitudSolicitante in listSolicitudSolicitante
                     on xsolicitud.IdSolicitud equals xsolicitudSolicitante.IdSolicitud
                     where xsolicitud.IdSolicitud == idsolicitud


                     select new SolicitudPersonaResponsable
                     {
                         NombrePersona = xsolicitud.NombrePersona,
                         ApellidoPaterno = xsolicitud.ApellidoPaterno,
                         ApellidoMaterno = xsolicitud.ApellidoMaterno,
                         NombreCompleto = xsolicitud.NombreCompleto,
                         IdSolicitud = xsolicitud.IdSolicitud,
                         Plaza = xsolicitud.Plaza,
                         Sucursal = xsolicitud.Sucursal,
                         //IdResponsablePlaza = xsolicitud.IdResponsablePlaza,
                         Estatus = xsolicitud.Estatus,
                         IdTipoMovimiento = xsolicitud.IdTipoMovimiento,
                         FechaSolicitud = xsolicitud.FechaSolicitud,
                         Observaciones = xsolicitud.Observaciones,
                         EstatusSolicitud = xsolicitud.EstatusSolicitud,
                         DescripcionTipoMovimiento = xsolicitud.DescripcionTipoMovimiento,
                         EstatusTipoMovimiento = xsolicitud.EstatusTipoMovimiento,
                         IdMotivoBaja = xsolicitud.IdMotivoBaja,
                         IdPersona = xsolicitud.IdPersona,
                         IdPersonaResponsable = xresponsable.IdPersonaResponsable,
                         NombrePersonaResponsable = xresponsable.NombrePersonaResponsable,
                         ApellidoPaternoResponsable = xresponsable.ApellidoMaternoResponsable,
                         ApellidoMaternoResponsable = xresponsable.ApellidoMaternoResponsable,
                         NombreCompletoResponsable = xresponsable.NombreCompletoResponsable,
                         IdPlaza = xresponsable.IdPlaza,
                         FechaRegistro = xresponsable.FechaRegistro,
                         IdPersonaSolicitante = xsolicitud.IdPersonaSolicitante,
                         NombreCompletoSolicitante = xsolicitudSolicitante.NombreCompleto,
                         // EstatusResponsable = xresponsable.EstatusResponsable

                     }).FirstOrDefault();



                if (prueba == null)
                    return null;
                else
                    return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("SolicitudpersonaResponsablebyId SolicitudPersonaResponsable", ex);
                return null;
            }


        }

        public PersonaSolicitud SolicitudpersonaResponsablebyCif(int cif)
        {
            try
            {
                var prueba = (
                   from soliciudes in context.Solicitudes
                   join persona in context.PersonaCats
                   on soliciudes.IdPersona equals persona.IdPersona
                   join tipomovimiento in context.TipoMovimientos
                   on soliciudes.IdTipoMovimiento equals tipomovimiento.IdTipoMovimiento
                   where persona.Cif == cif
                   && tipomovimiento.IdTipoMovimiento == 1
                   && soliciudes.Estatus == "Aprobado"

                   select new PersonaSolicitud
                   {
                       IdSolicitud = soliciudes.IdSolicitud,
                       NombrePersona = persona.NombrePersona,
                       ApellidoPaterno = persona.ApellidoPaterno,
                       ApellidoMaterno = persona.ApellidoMaterno,
                       Plaza = persona.Plaza,
                       Sucursal = persona.Sucursal,
                       NombreCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                       IdTipoMovimiento = tipomovimiento.IdTipoMovimiento,
                       DescripcionTipoMovimiento = tipomovimiento.Descripcion,
                       IdPersona = persona.IdPersona,
                       FechaSolicitud = soliciudes.FechaSolicitud,
                       Observaciones = soliciudes.Observaciones,
                       Estatus = soliciudes.Estatus,
                       EstatusSolicitud = soliciudes.EstatusSolicitud,
                       IdMotivoBaja = soliciudes.IdMotivoBaja,
                       Cif = persona.Cif




                   }).FirstOrDefault();

                if (prueba == null)
                {
                    var pruebaVacia = new PersonaSolicitud();
                    pruebaVacia.Cif = 0;

                    return pruebaVacia;
                }
                else { return prueba; }
                //return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("SolicitudpersonaResponsablebyCif PersonaSolicitud", ex);
                return null;
            }

        }
    }
}
