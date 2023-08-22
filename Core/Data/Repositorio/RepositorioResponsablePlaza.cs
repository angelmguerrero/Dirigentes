using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.ResponsablePlaza;
using CPM.PlataformaDirigentes.Models.ModeloDom.Usuarios;
using CPMPlataformaDirigentes.Data.Contexto;
using CPMPlataformaDirigentes.Models.Models;
using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioResponsablePlaza : IRepositorioResponsablePlaza
    {
        private CPMDirigentesPlataformaContext context;
        private CPMDirectorioSucursalesContext context2;
        IGenericRepository<ResponsablePlaza> repo;
        public RepositorioResponsablePlaza()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            this.context2 = new CPMDirectorioSucursalesContext(Configuracion.GetConnectionConsultaCpmDirectorioString());
            repo = new GenericRepository<ResponsablePlaza>(context);
        }


        public List<ResponsablePlazaPersona> ObtenerResponsablePlazaPersona()
        {
            // La consulta se hace de esta forma debido a que no se pueden joinear tablas de contextos diferentes
            try
            {
                var plazaWrk = (from pla in context2.PlazaWrks

                                select new PlazaWrk

                                {
                                    IdPlaza = pla.IdPlaza,
                                    Nombre = pla.Nombre,
                                }).ToList();

                var responsablePlaza = (from resp in context.ResponsablePlazas

                                        select new ResponsablePlaza

                                        {
                                            IdResponsablePlaza = resp.IdResponsablePlaza,
                                            FechaRegistro = resp.FechaRegistro,
                                            Estatus = resp.Estatus,
                                            IdPersona = resp.IdPersona,
                                            IdPlaza = resp.IdPlaza,
                                        }).ToList();

                var persona = (from pers1 in context.PersonaCats

                               select new PersonaCat

                               {
                                   IdPersona = pers1.IdPersona,
                                   NombrePersona = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                               }).ToList();

                var prueba = (from resp in responsablePlaza
                              join pers1 in persona
                              on resp.IdPersona equals pers1.IdPersona
                              join plaz in plazaWrk
                              on resp.IdPlaza equals plaz.IdPlaza

                              select new ResponsablePlazaPersona

                              {
                                  IdResponsablePlaza = resp.IdResponsablePlaza,
                                  FechaRegistro = resp.FechaRegistro,
                                  Estatus = resp.Estatus,
                                  IdPersona = (int)resp.IdPersona,
                                  NombrePersona = pers1.NombrePersona,
                                  IdPlaza = (int)resp.IdPlaza,
                                  Nombre = plaz.Nombre,
                              }).ToList();

                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta ResponsablePlazaPersona", ex);
                return null;
            }
        }

        public Respuesta CrearResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona)
        {
            Respuesta resp = new Respuesta();
            try
            {
                var responsablePlaza = new ResponsablePlaza();
                responsablePlaza.IdPersona = ResponsablePlazaPersona.IdPersona;
                responsablePlaza.IdPlaza = ResponsablePlazaPersona.IdPlaza;
                responsablePlaza.Estatus = true;
                context.ResponsablePlazas.Add(responsablePlaza);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion ResponsablePlaza", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public Respuesta ActualizarResponsablePlazaPersonaNew(ResponsablePlazaPersona ResponsablePlazaPersona)
        {
            Respuesta resp = new Respuesta();
            var _responsablePlaza = context.ResponsablePlazas.Where(x => x.IdResponsablePlaza == ResponsablePlazaPersona.IdResponsablePlaza).SingleOrDefault();
            if (_responsablePlaza == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _responsablePlaza.IdResponsablePlaza = ResponsablePlazaPersona.IdResponsablePlaza;
                _responsablePlaza.IdPlaza = ResponsablePlazaPersona.IdPlaza;
                _responsablePlaza.IdPersona = ResponsablePlazaPersona.IdPersona;
                _responsablePlaza.Estatus = ResponsablePlazaPersona.Estatus;
                resp.Resultado = repo.Update(_responsablePlaza);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion ResponsablePlaza", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public int EliminarResponsablePlazaPersonaNew(int idResponsablePlaza)
        {
            var _responsablePlaza = context.ResponsablePlazas.Where(x => x.IdResponsablePlaza == idResponsablePlaza).SingleOrDefault();
            if (_responsablePlaza == null)
                return 0;
            try
            {
                _responsablePlaza.Estatus = false;
                context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar ResponsablePlaza", ex);
                return 0;
            }
        }

        public List<UsuarioPersonaPerfil> UsuarioPersonaPerfilPermisoSolicitudDirigencial()
        {

            // Se mostrarán en el combo de responsables plaza SOLO los que tengan permiso en el submodulo con id 28
            // Padrón de dirigentes(solicitudes) y que los permisos sean Todos o Autorizar
            try
            {
                var prueba = (from user1 in context.Usuarios
                              join pers1 in context.PersonaCats
                              on user1.IdPersona equals pers1.IdPersona
                              join perf1 in context.PerfilCargos
                              on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                              join perm1 in context.Permisos
                              on perf1.IdPerfilCargo equals perm1.IdPerfilCargo
                              join sub in context.SubModuloCats
                              on perm1.IdSubModulo equals sub.IdSubModulo

                              where sub.IdSubModulo == 28 && (perm1.Todos == true || perm1.Autorizar == true)
                              // where perf1.per

                              select new UsuarioPersonaPerfil

                              {
                                  IdUsuario = user1.IdUsuario,
                                  CorreoAcceso = user1.CorreoAcceso,
                                  Perfil = perf1.Descripcion,
                                  NombrePersonaCompleto = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno,
                                  EstatusUsuario = user1.EstatusUsuario,
                                  UsuarioDa = user1.UsuarioDa,
                                  Password = user1.Password,
                                  IdPersona = user1.IdPersona,
                                  IdPerfil = user1.IdPerfilCargo,
                                  NombrePersona = pers1.NombrePersona,
                                  ApellidoPaterno = pers1.ApellidoPaterno,
                                  ApellidoMaterno = pers1.ApellidoMaterno,
                                  EstatusPersona = pers1.EstatusPersona,
                                  IdCargo = (perf1.EsCargo == true ? perf1.IdPerfilCargo : 0),
                                  IdSubUnidadOperativa = pers1.IdSubUnidadOperativa,
                                  IdGenero = pers1.IdGenero,
                                  //     Genero = gen1.Descripcion,
                                  IdEstadoCivil = pers1.IdEstadoCivil,
                                  //  EstadoCivil = edo1.Descripcion,
                                  IdOficio = pers1.IdOficio,
                                  IdEscolaridad = pers1.IdEscolaridad,
                                  FechaNacimiento = pers1.FechaNacimiento,
                                  Rfc = pers1.Rfc,
                                  Curp = pers1.Curp,
                                  Edad = pers1.Edad,
                                  CodigoPostal = pers1.CodigoPostal,
                                  Celular = pers1.Celular,
                                  FechaIngreso = pers1.FechaIngreso,
                                  FechaBaja = pers1.FechaBaja,
                                  Cif = pers1.Cif,
                                  Dirigente = pers1.Dirigente,
                                  IdRepresententanteCargoCat = pers1.IdRepresententanteCargoCat,
                                  // IdOrgano = pers1.IdOrgano,
                                  IdProfesion = pers1.IdProfesion,
                                  Plaza = pers1.Plaza,
                                  Sucursal = pers1.Sucursal,
                                  EstatusPerfil = perf1.EstatusPerfil,
                                  Calle = pers1.Calle,
                                  NumeroInterior = pers1.NumeroInterior,
                                  Colonia = pers1.Colonia,
                                  Estado = pers1.Estado,
                                  Municipio = pers1.Municipio,
                                  IdDirigente = pers1.IdDirigente,
                                  Email = pers1.CorreoPersonal,
                                  CuentaMexicana = pers1.CuentaMexicana
                                  //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                              }).ToList();

                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta UsuarioPersonaPerfil", ex);
                return null;
            }

        }

        public ResponsablePlazaPersona ResponsablePlazaPersonabyId(int idResponsablePlaza)
        {
            // La consulta se hace de esta forma debido a que no se pueden joinear tablas de contextos diferentes
            try
            {
                var plazaWrk = (from pla in context2.PlazaWrks

                                select new PlazaWrk

                                {
                                    IdPlaza = pla.IdPlaza,
                                    Nombre = pla.Nombre,
                                }).ToList();

                var responsablePlaza = (from resp in context.ResponsablePlazas

                                        select new ResponsablePlazaPersona

                                        {
                                            IdResponsablePlaza = resp.IdResponsablePlaza,
                                            FechaRegistro = resp.FechaRegistro,
                                            Estatus = resp.Estatus,
                                            IdPersona = (int)resp.IdPersona,
                                            IdPlaza = (int)resp.IdPlaza,
                                        }).ToList();

                var persona = (from pers1 in context.PersonaCats

                               select new PersonaCat

                               {
                                   IdPersona = pers1.IdPersona,
                                   NombrePersona = pers1.NombrePersona,
                               }).ToList();

                var prueba = (from resp in responsablePlaza
                              join pers1 in persona
                              on resp.IdPersona equals pers1.IdPersona
                              join plaz in plazaWrk
                              on resp.IdPlaza equals plaz.IdPlaza
                              where resp.IdResponsablePlaza == idResponsablePlaza

                              select new ResponsablePlazaPersona

                              {
                                  IdResponsablePlaza = resp.IdResponsablePlaza,
                                  FechaRegistro = resp.FechaRegistro,
                                  Estatus = resp.Estatus,
                                  IdPersona = (int)resp.IdPersona,
                                  NombrePersona = pers1.NombrePersona,
                                  IdPlaza = (int)resp.IdPlaza,
                                  Nombre = plaz.Nombre,
                              }).FirstOrDefault();



                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta ResponsablePlaza", ex);
                return null;
            }
        }
        public ResponsablePlazaPersona ResponsablePlazabyIdPlaza(int idPlaza)
        {
            // La consulta se hace de esta forma debido a que no se pueden joinear tablas de contextos diferentes
            try
            {
                var plazaWrk = (from pla in context2.PlazaWrks

                                select new PlazaWrk

                                {
                                    IdPlaza = pla.IdPlaza,
                                    Nombre = pla.Nombre,
                                }).ToList();

                var responsablePlaza = (from resp in context.ResponsablePlazas
                                        where resp.Estatus == true

                                        select new ResponsablePlazaPersona

                                        {
                                            IdResponsablePlaza = resp.IdResponsablePlaza,
                                            FechaRegistro = resp.FechaRegistro,
                                            Estatus = resp.Estatus,
                                            IdPersona = (int)resp.IdPersona,
                                            IdPlaza = (int)resp.IdPlaza,
                                        }).ToList();

                var persona = (from pers1 in context.PersonaCats

                               select new PersonaCat

                               {
                                   IdPersona = pers1.IdPersona,
                                   NombrePersona = pers1.NombrePersona,
                               }).ToList();

                var prueba = (from resp in responsablePlaza
                              join pers1 in persona
                              on resp.IdPersona equals pers1.IdPersona
                              join plaz in plazaWrk
                              on resp.IdPlaza equals plaz.IdPlaza
                              where resp.IdPlaza == idPlaza

                              select new ResponsablePlazaPersona

                              {
                                  IdResponsablePlaza = resp.IdResponsablePlaza,
                                  FechaRegistro = resp.FechaRegistro,
                                  Estatus = resp.Estatus,
                                  IdPersona = (int)resp.IdPersona,
                                  NombrePersona = pers1.NombrePersona,
                                  IdPlaza = (int)resp.IdPlaza,
                                  Nombre = plaz.Nombre,
                              }).FirstOrDefault();

                if (prueba == null)
                    return null;

                else return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta ResponsablePlaza", ex);
                return null;
            }
        }

        public ResponsablePlazaPersona ResponsablePlazaPersonabyIdPersona(int idPersona)
        {

            // Valida que existan Responsables de Plaza para la Plaza de la Persona
            try
            {
                var responsablePlaza = (from resp in context.ResponsablePlazas

                                        select new ResponsablePlazaPersona

                                        {
                                            IdResponsablePlaza = resp.IdResponsablePlaza,
                                            FechaRegistro = resp.FechaRegistro,
                                            Estatus = resp.Estatus,
                                            IdPersona = (int)resp.IdPersona,
                                            IdPlaza = (int)resp.IdPlaza,
                                        }).ToList();

                var persona = (from pers1 in context.PersonaCats
                               where pers1.IdPersona == idPersona

                               select new PersonaCat

                               {
                                   IdPersona = pers1.IdPersona,
                                   NombrePersona = pers1.NombrePersona,
                                   IdPlaza = pers1.IdPlaza,
                               }).ToList();

                var prueba = (from resp in responsablePlaza
                              join pers1 in persona
                              on resp.IdPlaza equals pers1.IdPlaza

                              select new ResponsablePlazaPersona

                              {
                                  IdResponsablePlaza = resp.IdResponsablePlaza,
                                  FechaRegistro = resp.FechaRegistro,
                                  Estatus = resp.Estatus,
                                  IdPersona = (int)resp.IdPersona,
                                  NombrePersona = pers1.NombrePersona,
                                  IdPlaza = (int)resp.IdPlaza,
                                  Nombre = "",
                              }).FirstOrDefault();


                if (prueba == null)
                {
                    var pruebaVacia = new ResponsablePlazaPersona();
                    pruebaVacia.IdResponsablePlaza = 0;

                    return pruebaVacia;
                }
                else { return prueba; }
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta ResponsablePlaza", ex);
                return null;
            }
        }

        public ResponsablePlaza ObtenerResponsablePorPlaza(ResponsablePlazaPersona responsablePlaza)
        {
            var plaza = context.ResponsablePlazas.Where(x => x.IdPlaza == responsablePlaza.IdPlaza && x.IdPersona == responsablePlaza.IdPersona).FirstOrDefault();

            if (plaza == null)
                return null;
            else
                return plaza;
        }

        public List<SelectDom> UsuarioPersonaPerfilPermisoSolicitudDirigencialActivo()
        {

            // Se mostrarán en el combo de responsables plaza SOLO los que tengan permiso en el submodulo con id 28
            // Padrón de dirigentes(solicitudes) y que los permisos sean Todos o Autorizar
            try
            {
                var prueba = (from user1 in context.Usuarios
                              join pers1 in context.PersonaCats
                              on user1.IdPersona equals pers1.IdPersona
                              join perf1 in context.PerfilCargos
                              on user1.IdPerfilCargo equals perf1.IdPerfilCargo
                              join perm1 in context.Permisos
                              on perf1.IdPerfilCargo equals perm1.IdPerfilCargo
                              join sub in context.SubModuloCats
                              on perm1.IdSubModulo equals sub.IdSubModulo

                              where sub.IdSubModulo == 28 && (perm1.Todos == true || perm1.Autorizar == true)
                              // where perf1.per

                              select new SelectDom

                              {
                                  value = (int)user1.IdPersona,
                                  text = pers1.NombrePersona + " " + pers1.ApellidoPaterno + " " + pers1.ApellidoMaterno
                                  //calle, numero interior,colonia, estado, municipio.. faltan estos en persona
                              }).ToList();

                return prueba;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta Usuarios", ex);
                return null;
            }
        }

    }
}
