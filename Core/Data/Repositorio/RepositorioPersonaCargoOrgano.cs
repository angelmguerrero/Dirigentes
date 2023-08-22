using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPM.PlataformaDirigentes.Models.Models;
using CPMPlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioPersonaCargoOrgano : IRepositorioPersonaCargoOrgano
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioPersonaCargoOrgano()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }

        public List<PersonaCargoOrganos> ObtenerPersonaCargoOrgano()
        {
            try
            {
                var prueba = (from persona in context.PersonaCats
                              join tipopersona in context.TipoPersonaCats
                              on persona.IdTipoPersona equals tipopersona.IdTipoPersona
                              join genero in context.GeneroCats
                              on persona.IdGenero equals genero.IdGenero
                              join estadocivil in context.EstadoCivilCats
                              on persona.IdEstadoCivil equals estadocivil.IdEstadoCivil
                              join escolaridad in context.EscolaridadCats
                              on persona.IdEscolaridad equals escolaridad.IdEscolaridad
                              join profesion in context.ProfesionCats
                              on persona.IdProfesion equals profesion.IdProfesion
                              join clasificacionprofesion in context.ClasificacionProfesions
                              on profesion.IdClasificacionProfesion equals clasificacionprofesion.IdClasificacionProfesion
                              join cargoxorgano in context.CargoxOrganos
                              on persona.IdPersona equals cargoxorgano.IdPersona
                              join perfilcargo in context.PerfilCargos
                              on cargoxorgano.IdPerfilCargo equals perfilcargo.IdPerfilCargo
                              join organo in context.OrganoCats
                              on cargoxorgano.IdOrgano equals organo.IdOrgano
                              where perfilcargo.EsCargo == true
                              && persona.Dirigente == true

                              select new PersonaCargoOrganos
                              {
                                  IdPersona = persona.IdPersona,
                                  Cif = persona.Cif,
                                  NombrePersona = persona.NombrePersona,
                                  ApellidoPaterno = persona.ApellidoPaterno,
                                  ApellidoMaterno = persona.ApellidoMaterno,
                                  NombrePersonaCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                  FechaNacimiento = persona.FechaNacimiento,
                                  Edad = persona.Edad,
                                  Rfc = persona.Rfc,
                                  Curp = persona.Curp,
                                  Plaza = persona.Plaza,
                                  IdPlaza = persona.IdPlaza,
                                  Sucursal = persona.Sucursal,
                                  FechaIngreso = persona.FechaIngreso,
                                  FechaBaja = persona.FechaBaja,
                                  IdGenero = persona.IdGenero,
                                  DescripcionGenero = genero.Descripcion,
                                  DescripcionEstadoCivil = estadocivil.Descripcion,
                                  CorreoPersonal = persona.CorreoPersonal,
                                  Celular = persona.Celular,
                                  Calle = persona.Calle,
                                  Colonia = persona.Colonia,
                                  NumeroInterior = persona.NumeroInterior,
                                  CodigoPostal = persona.CodigoPostal,
                                  Estado = persona.Estado,
                                  EstatusPersona = persona.EstatusPersona,
                                  Municipio = persona.Municipio,
                                  IdTipoPersona = persona.IdTipoPersona,
                                  IdCargo = persona.IdCargo,
                                  DescripciontipoPersona = tipopersona.Descripcion,
                                  IdEscolaridad = persona.IdEscolaridad,
                                  DescripcionEscolaridad = escolaridad.Descripcion,
                                  IdProfesion = persona.IdProfesion,
                                  DescripcionProfesion = profesion.Descripcion,
                                  DescripcionClasificacion = clasificacionprofesion.Descripcion,
                                  IdPerfilCargo = perfilcargo.IdPerfilCargo,
                                  IdCargoOrgano = cargoxorgano.IdCargoOrgano,
                                  DescripcionCargo = perfilcargo.Descripcion,
                                  DescripcionOrgano = organo.Descripcion,
                                  IdDirigente = persona.IdDirigente,
                                  CuentaMexicana = persona.CuentaMexicana,




                              }).ToList();
                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("ObtenerPersonaCargoOrgano PersonaCargoOrganos", ex);
                return null;
            }
        }
        public List<PersonaCargoOrganos> ObtenerPersona()
        {
            var prueba = (from persona in context.PersonaCats
                          join tipopersona in context.TipoPersonaCats
                          on persona.IdTipoPersona equals tipopersona.IdTipoPersona
                          join genero in context.GeneroCats
                          on persona.IdGenero equals genero.IdGenero
                          join estadocivil in context.EstadoCivilCats
                          on persona.IdEstadoCivil equals estadocivil.IdEstadoCivil
                          join escolaridad in context.EscolaridadCats
                          on persona.IdEscolaridad equals escolaridad.IdEscolaridad
                          join profesion in context.ProfesionCats
                          on persona.IdProfesion equals profesion.IdProfesion
                          join clasificacionprofesion in context.ClasificacionProfesions
                          on profesion.IdClasificacionProfesion equals clasificacionprofesion.IdClasificacionProfesion


                          select new PersonaCargoOrganos
                          {
                              IdPersona = persona.IdPersona,
                              NombrePersona = persona.NombrePersona,
                              ApellidoPaterno = persona.ApellidoPaterno,
                              ApellidoMaterno = persona.ApellidoMaterno,
                              NombrePersonaCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                              FechaNacimiento = persona.FechaNacimiento,
                              Edad = persona.Edad,
                              Rfc = persona.Rfc,
                              Curp = persona.Curp,
                              Plaza = persona.Plaza,
                              IdPlaza = persona.IdPlaza,
                              FechaIngreso = persona.FechaIngreso,
                              Genero = genero.Descripcion,
                              DescripcionEstadoCivil = estadocivil.Descripcion,
                              CorreoPersonal = persona.CorreoPersonal,
                              Celular = persona.Celular,
                              Calle = persona.Calle,
                              NumeroInterior = persona.NumeroInterior,
                              CodigoPostal = persona.CodigoPostal,
                              Estado = persona.Estado,
                              Municipio = persona.Municipio,
                              DescripciontipoPersona = tipopersona.Descripcion,
                              DescripcionEscolaridad = escolaridad.Descripcion,
                              DescripcionProfesion = profesion.Descripcion,
                              DescripcionClasificacion = clasificacionprofesion.Descripcion,


                          }).ToList();
            return prueba;

        }

        public List<PersonaCargoOrganoNivel> ObtenerPersonaCargoNivel()
        {

            try
            {
                var prueba = (from persona in context.PersonaCats
                              join tipopersona in context.TipoPersonaCats
                              on persona.IdTipoPersona equals tipopersona.IdTipoPersona
                              join genero in context.GeneroCats
                              on persona.IdGenero equals genero.IdGenero
                              join estadocivil in context.EstadoCivilCats
                              on persona.IdEstadoCivil equals estadocivil.IdEstadoCivil
                              join escolaridad in context.EscolaridadCats
                              on persona.IdEscolaridad equals escolaridad.IdEscolaridad
                              join profesion in context.ProfesionCats
                              on persona.IdProfesion equals profesion.IdProfesion
                              join clasificacionprofesion in context.ClasificacionProfesions
                              on profesion.IdClasificacionProfesion equals clasificacionprofesion.IdClasificacionProfesion
                              join cargoxorgano in context.CargoxOrganos
                              on persona.IdPersona equals cargoxorgano.IdPersona
                              join perfilcargo in context.PerfilCargos
                              on cargoxorgano.IdPerfilCargo equals perfilcargo.IdPerfilCargo
                              join organo in context.OrganoCats
                              on cargoxorgano.IdOrgano equals organo.IdOrgano
                              join niveldirigencial in context.NivelDirigencials
                              on persona.IdPersona equals niveldirigencial.IdPersona
                              join niveldirigencialcat in context.NivelDirigencialCats
                              on niveldirigencial.IdNivelDirigencialCat equals niveldirigencialcat.IdNivelDirigencialCat
                              join condicionesIngreso in context.CondicionIngresoCats
                              on niveldirigencial.IdCondicionIngreso equals condicionesIngreso.IdCondicion
                              where perfilcargo.EsCargo == true
                              && persona.Dirigente == true

                              select new PersonaCargoOrganoNivel
                              {
                                  IdPersona = persona.IdPersona,
                                  Cif = persona.Cif,
                                  NombrePersona = persona.NombrePersona,
                                  ApellidoPaterno = persona.ApellidoPaterno,
                                  ApellidoMaterno = persona.ApellidoMaterno,
                                  NombrePersonaCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                  FechaNacimiento = persona.FechaNacimiento,
                                  Edad = persona.Edad,
                                  Rfc = persona.Rfc,
                                  Curp = persona.Curp,
                                  Plaza = persona.Plaza,
                                  IdPlaza = persona.IdPlaza,
                                  Sucursal = persona.Sucursal,
                                  FechaIngreso = persona.FechaIngreso,
                                  FechaBaja = persona.FechaBaja,
                                  IdGenero = persona.IdGenero,
                                  DescripcionGenero = genero.Descripcion,
                                  DescripcionEstadoCivil = estadocivil.Descripcion,
                                  CorreoPersonal = persona.CorreoPersonal,
                                  Celular = persona.Celular,
                                  Calle = persona.Calle,
                                  Colonia = persona.Colonia,
                                  NumeroInterior = persona.NumeroInterior,
                                  CodigoPostal = persona.CodigoPostal,
                                  Estado = persona.Estado,
                                  EstatusPersona = persona.EstatusPersona,
                                  Municipio = persona.Municipio,
                                  IdTipoPersona = persona.IdTipoPersona,
                                  IdCargo = persona.IdCargo,
                                  DescripciontipoPersona = tipopersona.Descripcion,
                                  IdEscolaridad = persona.IdEscolaridad,
                                  DescripcionEscolaridad = escolaridad.Descripcion,
                                  IdProfesion = persona.IdProfesion,
                                  DescripcionProfesion = profesion.Descripcion,
                                  DescripcionClasificacion = clasificacionprofesion.Descripcion,
                                  IdPerfilCargo = perfilcargo.IdPerfilCargo,
                                  IdCargoOrgano = cargoxorgano.IdCargoOrgano,
                                  DescripcionCargo = perfilcargo.Descripcion,
                                  DescripcionOrgano = organo.Descripcion,
                                  IdDirigente = persona.IdDirigente,
                                  CuentaMexicana = persona.CuentaMexicana,
                                  IdNivelDirigencialCat = niveldirigencial.IdNivelDirigencialCat,
                                  NivelDirigencialCatDescrip = niveldirigencialcat.Descripcion,
                                  EstatusNivelDirigencial = niveldirigencial.EstatusNivelDirigencial,
                                  FechaIngresoNivel = niveldirigencial.FechaIngreso,
                                  FinPeriodo = niveldirigencial.FinPeriodo,
                                  Periodo = niveldirigencial.Periodo,
                                  Aperiodo = niveldirigencial.Aperiodo,
                                  IdCondicionIngreso = niveldirigencial.IdCondicionIngreso,
                                  CondicionIngresoDescrip = condicionesIngreso.CondicionIngreso,


                              }).ToList();
                foreach (var item in prueba)
                {
                    if (item.FechaIngresoNivel != null)
                    {
                        item.Antiguedad = obtenerAntiguedad((DateTime)item.FechaIngresoNivel);
                    }
                }

                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("ObtenerPersonaCargoNivel PersonaCargoOrganoNivel", ex);
                return null;
            }


        }
        private int obtenerAntiguedad(DateTime fechainicioNivel)
        {
            DateTime fechaUno = DateTime.Now;
            //para obtener fecha en dato numerico
            TimeSpan difFechas = fechaUno - fechainicioNivel;
            return difFechas.Days;
        }
        public bool CrearPersona(PersonaCat persona)
        {
            try
            {

                context.PersonaCats.Add(persona);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Logger.Error("CrearPersona PersonaCat", ex);
                return false;
            }
        }
        public bool ModificarPersona(PersonaCat persona)
        {
            var _persona = context.PersonaCats.Where(x => x.IdPersona == persona.IdPersona).SingleOrDefault();

            if (_persona == null)
                return false;
            try
            {

                _persona.IdPersona = persona.IdPersona;
                _persona.NombrePersona = persona.NombrePersona;
                _persona.ApellidoPaterno = persona.ApellidoPaterno;
                _persona.ApellidoMaterno = persona.ApellidoMaterno;
                _persona.EstatusPersona = persona.EstatusPersona;
                _persona.IdTipoPersona = persona.IdTipoPersona;
                _persona.IdGenero = persona.IdGenero;
                _persona.IdEstadoCivil = persona.IdEstadoCivil;
                _persona.CorreoPersonal = persona.CorreoPersonal;
                _persona.IdOficio = persona.IdOficio;
                _persona.IdEscolaridad = persona.IdEscolaridad;
                _persona.FechaNacimiento = persona.FechaNacimiento;
                _persona.Rfc = persona.Rfc;
                _persona.Curp = persona.Curp;
                _persona.Edad = persona.Edad;
                _persona.CodigoPostal = persona.CodigoPostal;
                _persona.Celular = persona.Celular;
                _persona.FechaIngreso = persona.FechaIngreso;
                _persona.FechaBaja = persona.FechaBaja;
                _persona.Cif = persona.Cif;
                _persona.Dirigente = persona.Dirigente;
                _persona.IdDirigente = persona.IdDirigente;
                _persona.IdProfesion = persona.IdProfesion;
                _persona.Calle = persona.Calle;
                _persona.NumeroInterior = persona.NumeroInterior;
                _persona.Colonia = persona.Colonia;
                _persona.Estado = persona.Estado;
                _persona.Municipio = persona.Municipio;
                _persona.Participacion = persona.Participacion;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion PersonaCat", ex);
                return false;

            }


        }


        public bool DesactivarPersona(int idPersona)
        {
            var _persona = context.PersonaCats.Where(c => c.IdPersona == idPersona).SingleOrDefault();
            if (_persona == null)
                return false;
            try
            {
                _persona.EstatusPersona = false;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar PersonaCat", ex);

            }
            return true;
        }
        public bool ActivarDirigentePersona(int idPersona)
        {
            var _persona = context.PersonaCats.Where(c => c.IdPersona == idPersona).SingleOrDefault();
            if (_persona == null)
                return false;

            _persona.Dirigente = true;
            context.SaveChanges();
            return true;
        }
        public bool DesactivarPersonaxCargo(int idPersona, int idcargoOrgano)
        {
            var _persona = (from persona in context.PersonaCats
                            join cargoxorgano in context.CargoxOrganos
                            on persona.IdPersona equals cargoxorgano.IdPersona
                            where persona.IdPersona == idPersona
                            && cargoxorgano.IdCargoOrgano == idcargoOrgano
                            select new PersonaDescripcion
                            {
                                EstatusPersona = false
                            }
                ).FirstOrDefault();
            //context.PersonaCats.Where(c => c.IdPersona == idPersona).SingleOrDefault();     
            if (_persona == null)
                return false;

            _persona.EstatusPersona = false;
            context.SaveChanges();
            return true;
        }

        public PersonaDescripcion PersonabyId(int idPersona)
        {
            try
            {
                //obtener info tabla dirigente 
                var dirigenteTabla = (from dirigentecont in context.Dirigente
                                      where dirigentecont.IdPersona == idPersona
                                      select new Dirigente
                                      {
                                          ExpedienteDigital = dirigentecont.ExpedienteDigital,
                                          Curriculum = dirigentecont.Curriculum,
                                      }

                             ).FirstOrDefault();
                if (dirigenteTabla == null)
                {

                    var prueba = (from persona in context.PersonaCats
                                  join tipopersona in context.TipoPersonaCats
                                  on persona.IdTipoPersona equals tipopersona.IdTipoPersona
                                  join genero in context.GeneroCats
                                  on persona.IdGenero equals genero.IdGenero
                                  join estadocivil in context.EstadoCivilCats
                                  on persona.IdEstadoCivil equals estadocivil.IdEstadoCivil
                                  join escolaridad in context.EscolaridadCats
                                  on persona.IdEscolaridad equals escolaridad.IdEscolaridad
                                  join profesion in context.ProfesionCats
                                  on persona.IdProfesion equals profesion.IdProfesion
                                  join clasificacionprofesion in context.ClasificacionProfesions
                                  on profesion.IdClasificacionProfesion equals clasificacionprofesion.IdClasificacionProfesion
                                  join oficio in context.OficioCats
                                  on persona.IdOficio equals oficio.IdOficio
                                  where persona.IdPersona == idPersona



                                  select new PersonaDescripcion
                                  {
                                      IdPersona = persona.IdPersona,
                                      NombrePersona = persona.NombrePersona,
                                      ApellidoPaterno = persona.ApellidoPaterno,
                                      ApellidoMaterno = persona.ApellidoMaterno,
                                      //NombrePersonaCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                      EstatusPersona = persona.EstatusPersona,
                                      IdTipoPersona = persona.IdTipoPersona,
                                      DescripciontipoPersona = tipopersona.Descripcion,
                                      IdCargo = persona.IdCargo,
                                      IdGenero = persona.IdGenero,
                                      DescripcionGenero = genero.Descripcion,
                                      IdEstadoCivil = persona.IdEstadoCivil,
                                      DescripcionEstadoCivil = estadocivil.Descripcion,
                                      CorreoPersonal = persona.CorreoPersonal,
                                      IdOficio = persona.IdOficio,
                                      DescripcionIdOficio = oficio.Descripcion,
                                      IdEscolaridad = persona.IdEscolaridad,
                                      DescripcionEscolaridad = escolaridad.Descripcion,
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
                                      DescripcionProfesion = profesion.Descripcion,
                                      IdClasificacion = clasificacionprofesion.IdClasificacionProfesion,
                                      DescripcionClasificacion = clasificacionprofesion.Descripcion,
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
                                      Participacion = persona.Participacion,
                                  }).FirstOrDefault();
                    if (idPersona == null)
                        return null;
                    else
                        return prueba;
                }
                else
                {
                    var pruebadirigenteTabla = (from persona in context.PersonaCats
                                                join tipopersona in context.TipoPersonaCats
                                                on persona.IdTipoPersona equals tipopersona.IdTipoPersona
                                                join genero in context.GeneroCats
                                                on persona.IdGenero equals genero.IdGenero
                                                join estadocivil in context.EstadoCivilCats
                                                on persona.IdEstadoCivil equals estadocivil.IdEstadoCivil
                                                join escolaridad in context.EscolaridadCats
                                                on persona.IdEscolaridad equals escolaridad.IdEscolaridad
                                                join profesion in context.ProfesionCats
                                                on persona.IdProfesion equals profesion.IdProfesion
                                                join clasificacionprofesion in context.ClasificacionProfesions
                                                on profesion.IdClasificacionProfesion equals clasificacionprofesion.IdClasificacionProfesion
                                                join oficio in context.OficioCats
                                                on persona.IdOficio equals oficio.IdOficio
                                                where persona.IdPersona == idPersona



                                                select new PersonaDescripcion
                                                {
                                                    IdPersona = persona.IdPersona,
                                                    NombrePersona = persona.NombrePersona,
                                                    ApellidoPaterno = persona.ApellidoPaterno,
                                                    ApellidoMaterno = persona.ApellidoMaterno,
                                                    //NombrePersonaCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                                    EstatusPersona = persona.EstatusPersona,
                                                    IdTipoPersona = persona.IdTipoPersona,
                                                    DescripciontipoPersona = tipopersona.Descripcion,
                                                    IdCargo = persona.IdCargo,
                                                    IdGenero = persona.IdGenero,
                                                    DescripcionGenero = genero.Descripcion,
                                                    IdEstadoCivil = persona.IdEstadoCivil,
                                                    DescripcionEstadoCivil = estadocivil.Descripcion,
                                                    CorreoPersonal = persona.CorreoPersonal,
                                                    IdOficio = persona.IdOficio,
                                                    DescripcionIdOficio = oficio.Descripcion,
                                                    IdEscolaridad = persona.IdEscolaridad,
                                                    DescripcionEscolaridad = escolaridad.Descripcion,
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
                                                    DescripcionProfesion = profesion.Descripcion,
                                                    IdClasificacion = clasificacionprofesion.IdClasificacionProfesion,
                                                    DescripcionClasificacion = clasificacionprofesion.Descripcion,
                                                    IdPlaza = persona.IdPlaza,
                                                    Plaza = persona.Plaza,
                                                    Sucursal = persona.Sucursal,
                                                    Calle = persona.Calle,
                                                    NumeroInterior = persona.NumeroInterior,
                                                    Colonia = persona.Colonia,
                                                    Estado = persona.Estado,
                                                    Municipio = persona.Municipio,
                                                    CuentaMexicana = persona.CuentaMexicana,
                                                    ExpedienteDigital = dirigenteTabla.ExpedienteDigital,
                                                    Curriculum = dirigenteTabla.Curriculum,
                                                    Participacion = persona.Participacion,

                                                }).FirstOrDefault();
                    if (idPersona == null)
                        return null;
                    else
                        return pruebadirigenteTabla;
                }


            }
            catch (Exception ex)
            {
                Logger.Error("PersonabyId PersonaDescripcion", ex);
                return null;
            }



        }

        public List<PersonaCargoOrganos> ObtenerPersonaCargoOrganobyid(int idPersona)
        {
            try
            {
                var prueba = (from persona in context.PersonaCats
                              join tipopersona in context.TipoPersonaCats on persona.IdTipoPersona equals tipopersona.IdTipoPersona
                              join genero in context.GeneroCats on persona.IdGenero equals genero.IdGenero
                              join estadocivil in context.EstadoCivilCats on persona.IdEstadoCivil equals estadocivil.IdEstadoCivil
                              join escolaridad in context.EscolaridadCats on persona.IdEscolaridad equals escolaridad.IdEscolaridad
                              join profesion in context.ProfesionCats on persona.IdProfesion equals profesion.IdProfesion
                              join clasificacionprofesion in context.ClasificacionProfesions on profesion.IdClasificacionProfesion equals clasificacionprofesion.IdClasificacionProfesion
                              join cargoxorgano in context.CargoxOrganos on persona.IdPersona equals cargoxorgano.IdPersona
                              join perfilcargo in context.PerfilCargos on cargoxorgano.IdPerfilCargo equals perfilcargo.IdPerfilCargo
                              join organo in context.OrganoCats on cargoxorgano.IdOrgano equals organo.IdOrgano
                              where perfilcargo.EsCargo == true
                              && persona.IdPersona == idPersona

                              select new PersonaCargoOrganos
                              {
                                  IdPersona = persona.IdPersona,
                                  Cif = persona.Cif,
                                  NombrePersona = persona.NombrePersona,
                                  NombrePersonaCompleto = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                  FechaNacimiento = persona.FechaNacimiento,
                                  Edad = persona.Edad,
                                  Rfc = persona.Rfc,
                                  Curp = persona.Curp,
                                  Plaza = persona.Plaza,
                                  FechaIngreso = persona.FechaIngreso,
                                  Genero = genero.Descripcion,
                                  DescripcionEstadoCivil = estadocivil.Descripcion,
                                  CorreoPersonal = persona.CorreoPersonal,
                                  Celular = persona.Celular,
                                  Calle = persona.Calle,
                                  NumeroInterior = persona.NumeroInterior,
                                  CodigoPostal = persona.CodigoPostal,
                                  Estado = persona.Estado,
                                  EstatusPersona = persona.EstatusPersona,
                                  Municipio = persona.Municipio,
                                  IdTipoPersona = persona.IdTipoPersona,
                                  IdCargo = persona.IdCargo,
                                  DescripciontipoPersona = tipopersona.Descripcion,
                                  IdEscolaridad = persona.IdEscolaridad,
                                  DescripcionEscolaridad = escolaridad.Descripcion,
                                  IdProfesion = persona.IdProfesion,
                                  DescripcionProfesion = profesion.Descripcion,
                                  DescripcionClasificacion = clasificacionprofesion.Descripcion,
                                  IdPerfilCargo = perfilcargo.IdPerfilCargo,
                                  DescripcionCargo = perfilcargo.Descripcion,
                                  DescripcionOrgano = organo.Descripcion,
                                  FechaInicial = cargoxorgano.FechaInicial,
                                  FechaFinal = cargoxorgano.FechaFinal


                              }).ToList();
                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("RegistroByid DetallePlantillaOrdenDia", ex);
                return null;
            }
        }

        public bool DeletePersonaInsertarSolicitudBaja(PersonaTipoMotivoBaja personaTipoMotivoBaja)
        {
            try
            {

                //var nombre = "Gonzalez";
                //var result = context.Database.ExecuteSqlRaw("pa_i_Insertar_Persona_Cat @p0", nombre);

                var valorSalida = new SqlParameter
                {
                    ParameterName = "@ValorSalida",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = 0
                };

                var result = context.Database.ExecuteSqlRaw("pa_u_Actualizar_Persona_Baja @p0,@p1,@p2,@p3,@p4,@ValorSalida out",
                personaTipoMotivoBaja.IdPersona,
                personaTipoMotivoBaja.IdMotivoBaja,
                personaTipoMotivoBaja.IdTipoBaja,
                personaTipoMotivoBaja.IdPersonaSolicitante,
                personaTipoMotivoBaja.Estatus,
                valorSalida

                );
                return true;


            }
            catch (Exception ex)
            {
                Logger.Error("DeletePersonaInsertarSolicitudBaja PersonaTipoMotivoBaja", ex);
                return false;
            }
        }

    }
}
