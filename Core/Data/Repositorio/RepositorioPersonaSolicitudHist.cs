using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioPersonaSolicitudHist : IRepositorioPersonaSolicitudHist
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioPersonaSolicitudHist()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }

        public PersonaCatvsPersonaSoli CompararPersonaSolicitudHistbyIdsolicitud(int idSolicitudHist)
        {
            try
            {
                var personaSolicitudHis = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == idSolicitudHist).FirstOrDefault();
                if (personaSolicitudHis == null) return null;
                var personacat = context.PersonaCats.Where(x => x.IdPersona == personaSolicitudHis.IdPersona).FirstOrDefault();
                var dirigente = context.Dirigente.Where(x => x.IdPersona == personaSolicitudHis.IdPersona).FirstOrDefault();
                var niveldirigencial = context.NivelDirigencials.Where(x => x.IdPersona == personaSolicitudHis.IdPersona).FirstOrDefault();
                if (dirigente == null)
                {

                    var comparapersona = new PersonaCatvsPersonaSoli();
                    comparapersona.NombrePersona = (personaSolicitudHis.NombrePersona == personacat.NombrePersona ? false : true);
                    comparapersona.ApellidoPaterno = (personaSolicitudHis.ApellidoPaterno == personacat.ApellidoPaterno ? false : true);
                    comparapersona.ApellidoMaterno = (personaSolicitudHis.ApellidoMaterno == personacat.ApellidoMaterno ? false : true);
                    // comparapersona.IdTipoPersona = (personaSolicitudHis.NombrePersona == personacat.NombrePersona ? true : false);
                    comparapersona.IdGenero = (personaSolicitudHis.IdGenero == personacat.IdGenero ? false : true);
                    comparapersona.IdEstadoCivil = (personaSolicitudHis.IdEstadoCivil == personacat.IdEstadoCivil ? false : true);
                    comparapersona.CorreoPersonal = (personaSolicitudHis.CorreoPersonal == personacat.CorreoPersonal ? false : true);
                    comparapersona.IdOficio = (personaSolicitudHis.IdOficio == personacat.IdOficio ? false : true);
                    comparapersona.IdEscolaridad = (personaSolicitudHis.IdEscolaridad == personacat.IdEscolaridad ? false : true);
                    comparapersona.FechaNacimiento = (personaSolicitudHis.FechaNacimiento == personacat.FechaNacimiento ? false : true);
                    comparapersona.Rfc = (personaSolicitudHis.Rfc == personacat.Rfc ? false : true);
                    comparapersona.Curp = (personaSolicitudHis.Curp == personacat.Curp ? false : true);
                    comparapersona.Edad = (personaSolicitudHis.Edad == personacat.Edad ? false : true);
                    comparapersona.CodigoPostal = (personaSolicitudHis.CodigoPostal == personacat.CodigoPostal ? false : true);
                    comparapersona.Celular = (personaSolicitudHis.Celular == personacat.Celular ? false : true);
                    comparapersona.FechaIngreso = (personaSolicitudHis.FechaIngreso == personacat.FechaIngreso ? false : true);
                    comparapersona.FechaBaja = (personaSolicitudHis.FechaBaja == personacat.FechaBaja ? false : true);
                    comparapersona.Cif = (personaSolicitudHis.Cif == personacat.Cif ? false : true);
                    comparapersona.Dirigente = (personaSolicitudHis.Dirigente == personacat.Dirigente ? false : true);
                    comparapersona.IdDirigente = (personaSolicitudHis.IdDirigente == personacat.IdDirigente ? false : true);
                    comparapersona.IdProfesion = (personaSolicitudHis.IdProfesion == personacat.IdProfesion ? false : true);
                    comparapersona.Calle = (personaSolicitudHis.Calle == personacat.Calle ? false : true);
                    comparapersona.NumeroInterior = (personaSolicitudHis.NumeroInterior == personacat.NumeroInterior ? false : true);
                    comparapersona.Colonia = (personaSolicitudHis.NombrePersona == personacat.NombrePersona ? false : true);
                    comparapersona.Estado = (personaSolicitudHis.Colonia == personacat.Colonia ? false : true);
                    comparapersona.Municipio = (personaSolicitudHis.Municipio == personacat.Municipio ? false : true);
                    comparapersona.Plaza = (personaSolicitudHis.Plaza == personacat.Plaza ? false : true);
                    comparapersona.Sucursal = (personaSolicitudHis.Sucursal == personacat.Sucursal ? false : true);
                    comparapersona.IdNivelDirigencialCat = (personaSolicitudHis.IdNivelDirigencialCat == niveldirigencial.IdNivelDirigencialCat ? false : true);
                    comparapersona.FechaIngresoNivel = (personaSolicitudHis.FechaIngresoNivel == niveldirigencial.FechaIngreso ? false : true);
                    comparapersona.FinPeriodo = (personaSolicitudHis.FinPeriodo == niveldirigencial.FinPeriodo ? false : true);
                    comparapersona.Periodo = (personaSolicitudHis.Periodo == niveldirigencial.Periodo ? false : true);
                    comparapersona.Aperiodo = (personaSolicitudHis.Aperiodo == niveldirigencial.Aperiodo ? false : true);
                    comparapersona.IdCondicionIngreso = (personaSolicitudHis.IdCondicionIngreso == niveldirigencial.IdCondicionIngreso ? false : true);
                    comparapersona.Participacion = (personaSolicitudHis.Participacion == personacat.Participacion ? false : true);

                    if (comparapersona == null)
                        return null;
                    else
                        return comparapersona;
                }
                else
                {

                    var comparapersonaall = new PersonaCatvsPersonaSoli();
                    comparapersonaall.NombrePersona = (personaSolicitudHis.NombrePersona == personacat.NombrePersona ? false : true);
                    comparapersonaall.ApellidoPaterno = (personaSolicitudHis.ApellidoPaterno == personacat.ApellidoPaterno ? false : true);
                    comparapersonaall.ApellidoMaterno = (personaSolicitudHis.ApellidoMaterno == personacat.ApellidoMaterno ? false : true);
                    //comparapersonaall.IdTipoPersona = (personaSolicitudHis.NombrePersona == personacat.NombrePersona ? true : false);
                    comparapersonaall.IdGenero = (personaSolicitudHis.IdGenero == personacat.IdGenero ? false : true);
                    comparapersonaall.IdEstadoCivil = (personaSolicitudHis.IdEstadoCivil == personacat.IdEstadoCivil ? false : true);
                    comparapersonaall.CorreoPersonal = (personaSolicitudHis.CorreoPersonal == personacat.CorreoPersonal ? false : true);
                    comparapersonaall.IdOficio = (personaSolicitudHis.IdOficio == personacat.IdOficio ? false : true);
                    comparapersonaall.IdEscolaridad = (personaSolicitudHis.IdEscolaridad == personacat.IdEscolaridad ? false : true);
                    comparapersonaall.FechaNacimiento = (personaSolicitudHis.FechaNacimiento == personacat.FechaNacimiento ? false : true);
                    comparapersonaall.Rfc = (personaSolicitudHis.Rfc == personacat.Rfc ? false : true);
                    comparapersonaall.Curp = (personaSolicitudHis.Curp == personacat.Curp ? false : true);
                    comparapersonaall.Edad = (personaSolicitudHis.Edad == personacat.Edad ? false : true);
                    comparapersonaall.CodigoPostal = (personaSolicitudHis.CodigoPostal == personacat.CodigoPostal ? false : true);
                    comparapersonaall.Celular = (personaSolicitudHis.Celular == personacat.Celular ? false : true);
                    comparapersonaall.FechaIngreso = (personaSolicitudHis.FechaIngreso == personacat.FechaIngreso ? false : true);
                    comparapersonaall.FechaBaja = (personaSolicitudHis.FechaBaja == personacat.FechaBaja ? false : true);
                    comparapersonaall.Cif = (personaSolicitudHis.Cif == personacat.Cif ? false : true);
                    comparapersonaall.Dirigente = (personaSolicitudHis.Dirigente == personacat.Dirigente ? false : true);
                    comparapersonaall.IdDirigente = (personaSolicitudHis.IdDirigente == personacat.IdDirigente ? false : true);
                    comparapersonaall.IdProfesion = (personaSolicitudHis.IdProfesion == personacat.IdProfesion ? false : true);
                    comparapersonaall.Calle = (personaSolicitudHis.Calle == personacat.Calle ? false : true);
                    comparapersonaall.NumeroInterior = (personaSolicitudHis.NumeroInterior == personacat.NumeroInterior ? false : true);
                    comparapersonaall.Colonia = (personaSolicitudHis.NombrePersona == personacat.NombrePersona ? false : true);
                    comparapersonaall.Estado = (personaSolicitudHis.Colonia == personacat.Colonia ? false : true);
                    comparapersonaall.Municipio = (personaSolicitudHis.Municipio == personacat.Municipio ? false : true);
                    comparapersonaall.Plaza = (personaSolicitudHis.Plaza == personacat.Plaza ? false : true);
                    comparapersonaall.Sucursal = (personaSolicitudHis.Sucursal == personacat.Sucursal ? false : true);
                    comparapersonaall.ExpedienteDigital = (personaSolicitudHis.Expediente == dirigente.ExpedienteDigital ? false : true);
                    comparapersonaall.Curriculum = (personaSolicitudHis.Curriculum == dirigente.Curriculum ? false : true);
                    comparapersonaall.Participacion = (personaSolicitudHis.Participacion == personacat.Participacion ? false : true);

                    if (niveldirigencial == null)
                    {
                        comparapersonaall.IdNivelDirigencialCat = true;
                        comparapersonaall.FechaIngresoNivel = true;
                        comparapersonaall.FinPeriodo = true;
                        comparapersonaall.Periodo = true;
                        comparapersonaall.Aperiodo = true;
                        comparapersonaall.IdCondicionIngreso = true;


                    }
                    else
                    {
                        comparapersonaall.IdNivelDirigencialCat = (personaSolicitudHis.IdNivelDirigencialCat == niveldirigencial.IdNivelDirigencialCat ? false : true);
                        comparapersonaall.FechaIngresoNivel = (personaSolicitudHis.FechaIngresoNivel == niveldirigencial.FechaIngreso ? false : true);
                        comparapersonaall.FinPeriodo = (personaSolicitudHis.FinPeriodo == niveldirigencial.FinPeriodo ? false : true);
                        comparapersonaall.Periodo = (personaSolicitudHis.Periodo == niveldirigencial.Periodo ? false : true);
                        comparapersonaall.Aperiodo = (personaSolicitudHis.Aperiodo == niveldirigencial.Aperiodo ? false : true);
                        comparapersonaall.IdCondicionIngreso = (personaSolicitudHis.IdCondicionIngreso == niveldirigencial.IdCondicionIngreso ? false : true);

                    }


                    if (comparapersonaall == null)
                        return null;
                    else
                        return comparapersonaall;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("CompararPersonaSolicitudHistbyIdsolicitud PersonaSolicitudHist", ex);
                return null;
            }


        }

        public bool Crear(PersonaSolicitudHist persona)
        {
            try
            {


                context.PersonaSolicitudHists.Add(persona);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Logger.Error("Crear PersonaSolicitudHist", ex);
                return false;
            }
        }

        public bool DesactivarPersonaSolicitudHist(int idPersonaSolicitudHist)
        {
            try
            {
                var _personaSolicitud = context.PersonaSolicitudHists.Where(x => x.IdPersonaSolicitud == idPersonaSolicitudHist).SingleOrDefault();
                if (_personaSolicitud == null)
                    return false;

                _personaSolicitud.EstatusPersonSolicitud = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("DesactivarPersonaSolicitudHist PersonaSolicitudHists", ex);
                return false;
            }
        }

        public bool ModificarPersonaSolicitudHist(PersonaSolicitudHist persona)
        {
            try
            {
                var _personaSolicitud = context.PersonaSolicitudHists.Where(x => x.IdSolicitud == persona.IdSolicitud).SingleOrDefault();
                if (_personaSolicitud == null)
                    return false;


                _personaSolicitud.IdPersona = persona.IdPersona;
                _personaSolicitud.NombrePersona = persona.NombrePersona;
                _personaSolicitud.ApellidoPaterno = persona.ApellidoPaterno;
                _personaSolicitud.ApellidoMaterno = persona.ApellidoMaterno;
                _personaSolicitud.EstatusPersona = persona.EstatusPersona;
                _personaSolicitud.IdTipoPersona = persona.IdTipoPersona;
                _personaSolicitud.IdGenero = persona.IdGenero;
                _personaSolicitud.IdEstadoCivil = persona.IdEstadoCivil;
                _personaSolicitud.CorreoPersonal = persona.CorreoPersonal;
                _personaSolicitud.IdOficio = persona.IdOficio;
                _personaSolicitud.IdEscolaridad = persona.IdEscolaridad;
                _personaSolicitud.FechaNacimiento = persona.FechaNacimiento;
                _personaSolicitud.Rfc = persona.Rfc;
                _personaSolicitud.Curp = persona.Curp;
                _personaSolicitud.Edad = persona.Edad;
                _personaSolicitud.CodigoPostal = persona.CodigoPostal;
                _personaSolicitud.Celular = persona.Celular;
                _personaSolicitud.FechaIngreso = persona.FechaIngreso;
                _personaSolicitud.FechaBaja = persona.FechaBaja;
                _personaSolicitud.Cif = persona.Cif;
                _personaSolicitud.Dirigente = persona.Dirigente;
                _personaSolicitud.IdDirigente = persona.IdDirigente;
                _personaSolicitud.IdProfesion = persona.IdProfesion;
                _personaSolicitud.Calle = persona.Calle;
                _personaSolicitud.NumeroInterior = persona.NumeroInterior;
                _personaSolicitud.Colonia = persona.Colonia;
                _personaSolicitud.Estado = persona.Estado;
                _personaSolicitud.Municipio = persona.Municipio;
                _personaSolicitud.EstatusPersonSolicitud = persona.EstatusPersonSolicitud;
                _personaSolicitud.IdSolicitud = persona.IdSolicitud;
                _personaSolicitud.IdNivelDirigencialCat = persona.IdNivelDirigencialCat;
                _personaSolicitud.FechaIngresoNivel = persona.FechaIngresoNivel;
                _personaSolicitud.FinPeriodo = persona.FinPeriodo;
                _personaSolicitud.Periodo = persona.Periodo;
                _personaSolicitud.Aperiodo = persona.Aperiodo;
                _personaSolicitud.IdCondicionIngreso = persona.IdCondicionIngreso;
                _personaSolicitud.Participacion = persona.Participacion;
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion PersonaSolicitudHist", ex);
                return false;
            }
        }

        public List<PersonaSolicitudHist> ObtenerPersonaSolicitudHist()
        {
            return context.PersonaSolicitudHists.ToList();
        }

        public PersonaSolicitudHist PersonaSolicitudHistbyId(int idPersonaSolicitudHist)
        {
            try
            {
                var personaSolicitud = context.PersonaSolicitudHists.Where(x => x.IdPersonaSolicitud == idPersonaSolicitudHist).FirstOrDefault();

                if (personaSolicitud == null)
                    return null;
                else
                    return personaSolicitud;
            }
            catch (Exception ex)
            {
                Logger.Error("PersonaSolicitudHistbyId PersonaSolicitudHist", ex);
                return null;
            }
        }

        public PersonaSolicitudHistorico PersonaSolicitudHistbyIdsolicitud(int idSolicitudHist)
        {
            try
            {
                var personaSolicitud = (from persona in context.PersonaSolicitudHists
                                        where persona.IdSolicitud == idSolicitudHist
                                        select new PersonaSolicitudHistorico
                                        {
                                            IdPersonaSolicitud = persona.IdPersonaSolicitud,
                                            IdPersona = persona.IdPersona,
                                            NombrePersona = persona.NombrePersona,
                                            ApellidoPaterno = persona.ApellidoPaterno,
                                            ApellidoMaterno = persona.ApellidoMaterno,
                                            EstatusPersona = persona.EstatusPersona,
                                            IdTipoPersona = persona.IdTipoPersona,
                                            IdCargo = persona.IdCargo,
                                            IdGenero = persona.IdGenero,
                                            IdEstadoCivil = persona.IdEstadoCivil,
                                            CorreoPersonal = persona.CorreoPersonal,
                                            IdOficio = persona.IdOficio,
                                            IdEscolaridad = persona.IdEscolaridad,
                                            FechaNacimiento = persona.FechaNacimiento,
                                            Rfc = persona.Rfc,
                                            Curp = persona.Curp,
                                            Edad = persona.Edad,
                                            CodigoPostal = persona.CodigoPostal,
                                            Celular = persona.Celular,
                                            FechaIngreso = persona.FechaIngreso,
                                            FechaBaja = persona.FechaBaja,
                                            Cif = persona.Cif,
                                            Dirigente = persona.Dirigente,
                                            IdDirigente = persona.IdDirigente,
                                            IdProfesion = persona.IdProfesion,
                                            IdPlaza = persona.IdPlaza,
                                            Plaza = persona.Plaza,
                                            Sucursal = persona.Sucursal,
                                            Calle = persona.Calle,
                                            NumeroInterior = persona.NumeroInterior,
                                            Colonia = persona.Colonia,
                                            Estado = persona.Estado,
                                            Municipio = persona.Municipio,
                                            CuentaMexicana = persona.CuentaMexicana,
                                            EstatusPersonSolicitud = persona.EstatusPersonSolicitud,
                                            IdSolicitud = persona.IdSolicitud,
                                            IdNivelDirigencialCat = persona.IdNivelDirigencialCat,
                                            FechaIngresoNivel = persona.FechaIngresoNivel,
                                            FinPeriodo = persona.FinPeriodo,
                                            Aperiodo = persona.Aperiodo,
                                            IdCondicionIngreso = persona.IdCondicionIngreso,
                                            Participacion = persona.Participacion,

                                        }).FirstOrDefault();

                if (personaSolicitud == null)
                    return null;
                else
                {
                    //obtener info tabla dirigente 
                    var dirigenteTabla = (from dirigentecont in context.Dirigente
                                          where dirigentecont.IdPersona == personaSolicitud.IdPersona
                                          select new Dirigente
                                          {
                                              ExpedienteDigital = dirigentecont.ExpedienteDigital,
                                              Curriculum = dirigentecont.Curriculum,
                                          }

                                     ).FirstOrDefault();
                    if (dirigenteTabla == null)
                    {
                        return personaSolicitud;
                    }
                    else
                    {

                        var personaSolicitudArchivo = (from persona in context.PersonaSolicitudHists
                                                       join diri in context.Dirigente
                                                       on persona.IdPersona equals diri.IdPersona
                                                       where persona.IdSolicitud == idSolicitudHist
                                                       select new PersonaSolicitudHistorico
                                                       {
                                                           IdPersonaSolicitud = persona.IdPersonaSolicitud,
                                                           IdPersona = persona.IdPersona,
                                                           NombrePersona = persona.NombrePersona,
                                                           ApellidoPaterno = persona.ApellidoPaterno,
                                                           ApellidoMaterno = persona.ApellidoMaterno,
                                                           EstatusPersona = persona.EstatusPersona,
                                                           IdTipoPersona = persona.IdTipoPersona,
                                                           IdCargo = persona.IdCargo,
                                                           IdGenero = persona.IdGenero,
                                                           IdEstadoCivil = persona.IdEstadoCivil,
                                                           CorreoPersonal = persona.CorreoPersonal,
                                                           IdOficio = persona.IdOficio,
                                                           IdEscolaridad = persona.IdEscolaridad,
                                                           FechaNacimiento = persona.FechaNacimiento,
                                                           Rfc = persona.Rfc,
                                                           Curp = persona.Curp,
                                                           Edad = persona.Edad,
                                                           CodigoPostal = persona.CodigoPostal,
                                                           Celular = persona.Celular,
                                                           FechaIngreso = persona.FechaIngreso,
                                                           FechaBaja = persona.FechaBaja,
                                                           Cif = persona.Cif,
                                                           Dirigente = persona.Dirigente,
                                                           IdDirigente = persona.IdDirigente,
                                                           IdProfesion = persona.IdProfesion,
                                                           IdPlaza = persona.IdPlaza,
                                                           Plaza = persona.Plaza,
                                                           Sucursal = persona.Sucursal,
                                                           IdSucursal = persona.IdSucursal,
                                                           Calle = persona.Calle,
                                                           NumeroInterior = persona.NumeroInterior,
                                                           Colonia = persona.Colonia,
                                                           Estado = persona.Estado,
                                                           Municipio = persona.Municipio,
                                                           CuentaMexicana = persona.CuentaMexicana,
                                                           EstatusPersonSolicitud = persona.EstatusPersonSolicitud,
                                                           IdSolicitud = persona.IdSolicitud,
                                                           ExpedienteDigital = diri.ExpedienteDigital,
                                                           Curriculum = diri.Curriculum,
                                                           IdNivelDirigencialCat = persona.IdNivelDirigencialCat,
                                                           FechaIngresoNivel = persona.FechaIngresoNivel,
                                                           FinPeriodo = persona.FinPeriodo,
                                                           Aperiodo = persona.Aperiodo,
                                                           IdCondicionIngreso = persona.IdCondicionIngreso,
                                                           Participacion = persona.Participacion,


                                                       }).FirstOrDefault();
                        return personaSolicitudArchivo;
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error("PersonaSolicitudHistbyIdsolicitud PersonaSolicitudHist", ex);
                return null;
            }




        }
    }
}
