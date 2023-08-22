using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Perfil;
using CPM.PlataformaDirigentes.Models.ModeloDom.Solicitud;
using CPM.PlataformaDirigentes.Models.Models;
using CPMPlataformaDirigentes.Models.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioPerfilCargo : IRepositorioPerfilCargo
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioPerfilCargo()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }


        public List<PerfilPermiso> ObtenerPerfilPermiso()
        {

            var prueba = (from mod1 in context.ModuloCats
                          join sub1 in context.SubModuloCats
                          on mod1.IdModulo equals sub1.IdModulo
                          join perm1 in context.Permisos
                          on sub1.IdSubModulo equals perm1.IdSubModulo
                          join perf1 in context.PerfilCargos
                          on perm1.IdPerfilCargo equals perf1.IdPerfilCargo
                          where perf1.IdPerfilCargo != 16

                          select new PerfilPermiso

                          {
                              // Modulo
                              IdModulo = mod1.IdModulo,
                              DescripcionModulo = mod1.Descripcion,
                              EstatusModulo = mod1.EstatusModulo,
                              //Submodulo //
                              IdSubModulo = sub1.IdSubModulo,
                              DescripcionSubmodulo = sub1.Descripcion,
                              EstatusSubModulo = sub1.EstatusSubModulo,
                              //Perfil
                              IdPerfilCargo = perf1.IdPerfilCargo,
                              DescripcionPerfil = perf1.Descripcion,
                              EstatusPerfil = perf1.EstatusPerfil,
                              OrdenCargo = perf1.OrdenCargo,
                              EsCargo = perf1.EsCargo,
                              //Permiso
                              IdPermiso = perm1.IdPermiso,
                              Todos = perm1.Todos,
                              Crear = perm1.Crear,
                              Editar = perm1.Editar,
                              Consultar = perm1.Consultar,
                              Eliminar = perm1.Eliminar,
                              Descargar = perm1.Descargar,
                              Cargar = perm1.Cargar,
                              Autorizar = perm1.Autorizar,
                              Historico = perm1.Historico,
                              EstatusPermiso = perm1.EstatusPermiso,

                          }).ToList();

            return prueba;
            //return (List<PerfilCargoPersonaPerfil>)_PerfilCargoPersonaPerfil;
        }

        public List<PerfilPermisoIndex> ObtenerPerfilPermisoIndex()
        {

            //Consulta inicial
            var prueba = (from mod1 in context.ModuloCats
                          join sub1 in context.SubModuloCats
                          on mod1.IdModulo equals sub1.IdModulo
                          join perm1 in context.Permisos
                          on sub1.IdSubModulo equals perm1.IdSubModulo
                          join perf1 in context.PerfilCargos
                          on perm1.IdPerfilCargo equals perf1.IdPerfilCargo
                          where perf1.IdPerfilCargo != 16 && mod1.EstatusModulo == true && sub1.EstatusSubModulo == true

                          select new PerfilPermisoIndex

                          {
                              // Modulo
                              IdModulo = mod1.IdModulo,
                              //Perfil
                              IdPerfilCargo = perf1.IdPerfilCargo,
                              DescripcionPerfil = perf1.Descripcion,
                              EstatusPerfil = perf1.EstatusPerfil,
                              OrdenCargo = perf1.OrdenCargo,
                              EsCargo = perf1.EsCargo,
                              //Permiso                            
                              Todos = perm1.Todos,
                              Crear = perm1.Crear,
                              Editar = perm1.Editar,
                              Consultar = perm1.Consultar,
                              Eliminar = perm1.Eliminar,
                              Descargar = perm1.Descargar,
                              Cargar = perm1.Cargar,
                              Autorizar = perm1.Autorizar,
                              Historico = perm1.Historico,
                              Tipo = (perf1.EsCargo == true ? "Cargo" : "Perfil"),
                          }).ToList();


            //Agrupado de Perfil

            var agrupadoPerfil = from s in prueba
                                 group s by new
                                 {
                                     s.IdPerfilCargo,
                                     s.DescripcionPerfil,
                                     s.EstatusPerfil,
                                     PerfilesPermisos = "",
                                     Usuarios = "",
                                     Catalogo = "",
                                     PadronDirigentes = "",
                                     Convocatorias = "",
                                     LogisticaJocaps = "",
                                     RequerimientosAdicionales = "",
                                     IndicadoresReporteria = "",
                                     Blog = "",
                                     Tipo = ""
                                 };


            var pruebaagrupadoPerfil = (from agr in agrupadoPerfil

                                        select new PerfilPermisoIndex

                                        {
                                            //Perfil
                                            IdPerfilCargo = agr.Key.IdPerfilCargo,
                                            DescripcionPerfil = agr.Key.DescripcionPerfil,
                                            EstatusPerfil = agr.Key.EstatusPerfil,
                                            //Permiso                            
                                            PerfilesPermisos = agr.Key.PerfilesPermisos,
                                            Usuarios = agr.Key.Usuarios,
                                            Catalogo = agr.Key.Catalogo,
                                            PadronDirigentes = agr.Key.PadronDirigentes,
                                            Convocatorias = agr.Key.Convocatorias,
                                            LogisticaJocaps = agr.Key.LogisticaJocaps,
                                            RequerimientosAdicionales = agr.Key.RequerimientosAdicionales,
                                            IndicadoresReporteria = agr.Key.IndicadoresReporteria,
                                            Blog = agr.Key.Blog,
                                            Tipo = agr.Key.Tipo,
                                        }).ToList();


            ////Agrupado de Perfil, Modulo, PErmisos

            var agrupadoPerfilModuloPermiso = from s in prueba
                                                  //group s by new { s.IdPerfilCargo, s.IdModulo, s.Todos, s.Crear, s.Editar, s.Consultar, s.Eliminar, s.Descargar, s.Cargar, s.Autorizar, s.Historico };
                                              group s by new
                                              {
                                                  IdPerfilCargo = s.IdPerfilCargo,
                                                  DescripcionPerfil = s.DescripcionPerfil,
                                                  EstatusPerfil = s.EstatusPerfil,
                                                  PerfilesPermisos = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 1) ? "*" : ""),
                                                  Usuarios = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 2) ? "*" : ""),
                                                  Catalogo = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 3) ? "*" : ""),
                                                  PadronDirigentes = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 4) ? "*" : ""),
                                                  Convocatorias = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 5) ? "*" : ""),
                                                  LogisticaJocaps = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 6) ? "*" : ""),
                                                  RequerimientosAdicionales = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 7) ? "*" : ""),
                                                  IndicadoresReporteria = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 8) ? "*" : ""),
                                                  Blog = (((s.Todos == true || s.Crear == true || s.Editar == true || s.Consultar == true || s.Eliminar == true || s.Descargar == true || s.Cargar == true || s.Autorizar == true || s.Historico == true) && s.IdModulo == 9) ? "*" : ""),
                                                  Tipo = s.Tipo
                                              };



            var pruebaagrupadoPerfilModuloPermiso = (from agr in agrupadoPerfilModuloPermiso

                                                     select new PerfilPermisoIndex

                                                     {
                                                         //Perfil
                                                         IdPerfilCargo = agr.Key.IdPerfilCargo,
                                                         DescripcionPerfil = agr.Key.DescripcionPerfil,
                                                         EstatusPerfil = agr.Key.EstatusPerfil,
                                                         //Permiso                            
                                                         PerfilesPermisos = agr.Key.PerfilesPermisos,
                                                         Usuarios = agr.Key.Usuarios,
                                                         Catalogo = agr.Key.Catalogo,
                                                         PadronDirigentes = agr.Key.PadronDirigentes,
                                                         Convocatorias = agr.Key.Convocatorias,
                                                         LogisticaJocaps = agr.Key.LogisticaJocaps,
                                                         RequerimientosAdicionales = agr.Key.RequerimientosAdicionales,
                                                         IndicadoresReporteria = agr.Key.IndicadoresReporteria,
                                                         Blog = agr.Key.Blog,
                                                         Tipo = agr.Key.Tipo
                                                     }).ToList();


            // Planchado de información de permisos en tabla de agrupado de perfil

            foreach (var perm in pruebaagrupadoPerfilModuloPermiso)
            {

                foreach (var agrPrincipal in pruebaagrupadoPerfil)
                {
                    if (perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        agrPrincipal.Tipo = perm.Tipo;
                    }
                    else { }
                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.PerfilesPermisos == "")
                        {
                            if (perm.PerfilesPermisos == "*")
                            { agrPrincipal.PerfilesPermisos = "*"; }
                        }
                    }
                    else { }

                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.Usuarios == "")
                        {
                            if (perm.Usuarios == "*")
                            { agrPrincipal.Usuarios = "*"; }
                        }
                    }
                    else { }

                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.Catalogo == "")
                        {
                            if (perm.Catalogo == "*")
                            { agrPrincipal.Catalogo = "*"; }
                        }
                    }
                    else { }

                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.PadronDirigentes == "")
                        {
                            if (perm.PadronDirigentes == "*")
                            { agrPrincipal.PadronDirigentes = "*"; }
                        }
                    }
                    else { }

                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.Convocatorias == "")
                        {
                            if (perm.Convocatorias == "*")
                            { agrPrincipal.Convocatorias = "*"; }
                        }
                    }
                    else { }

                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.LogisticaJocaps == "")
                        {
                            if (perm.LogisticaJocaps == "*")
                            { agrPrincipal.LogisticaJocaps = "*"; }
                        }
                    }
                    else { }

                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.RequerimientosAdicionales == "")
                        {
                            if (perm.RequerimientosAdicionales == "*")
                            { agrPrincipal.RequerimientosAdicionales = "*"; }
                        }
                    }
                    else { }

                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.IndicadoresReporteria == "")
                        {
                            if (perm.IndicadoresReporteria == "*")
                            { agrPrincipal.IndicadoresReporteria = "*"; }
                        }
                    }
                    else { }

                    if (perm.IdModulo == agrPrincipal.IdModulo && perm.IdPerfilCargo == agrPrincipal.IdPerfilCargo)
                    {
                        if (agrPrincipal.Blog == "")
                        {
                            if (perm.Blog == "*")
                            { agrPrincipal.Blog = "*"; }
                        }
                    }
                    else { }


                }
            }

            return pruebaagrupadoPerfil;

        }

        public List<PerfilPermisoResumen> ObtenerPerfilPermisobyCorreoAcceso(string correoAcceso)
        {

            //Consulta inicial de perfil - todo usuario debe tener un perfil -

            // correoAcceso = "augl23028@cpm.coop";

            var informacionPerfil = (from mod1 in context.ModuloCats
                                     join sub1 in context.SubModuloCats
                                     on mod1.IdModulo equals sub1.IdModulo
                                     join perm1 in context.Permisos
                                     on sub1.IdSubModulo equals perm1.IdSubModulo
                                     join perf1 in context.PerfilCargos
                                     on perm1.IdPerfilCargo equals perf1.IdPerfilCargo
                                     join usu in context.Usuarios
                                     on perf1.IdPerfilCargo equals usu.IdPerfilCargo
                                     where usu.CorreoAcceso.ToUpper() == correoAcceso.ToUpper() && usu.EstatusUsuario == true && perf1.EstatusPerfil == true

                                     select new PerfilPermiso

                                     {
                                         // SubModulo
                                         IdSubModulo = sub1.IdSubModulo,
                                         DescripcionSubmodulo = sub1.Descripcion,
                                         //Permiso                            
                                         Todos = perm1.Todos,
                                         Crear = perm1.Crear,
                                         Editar = perm1.Editar,
                                         Consultar = perm1.Consultar,
                                         Eliminar = perm1.Eliminar,
                                         Descargar = perm1.Descargar,
                                         Cargar = perm1.Cargar,
                                         Autorizar = perm1.Autorizar,
                                         Historico = perm1.Historico,
                                     }).ToList();


            //Agrupado de información de Perfil

            var agrupadoInformacionPerfil = from s in informacionPerfil
                                            group s by new
                                            {
                                                s.IdSubModulo,
                                                s.DescripcionSubmodulo,
                                                s.Todos,
                                                s.Crear,
                                                s.Editar,
                                                s.Consultar,
                                                s.Eliminar,
                                                s.Descargar,
                                                s.Cargar,
                                                s.Autorizar,
                                                s.Historico,
                                            };

            // Convierte agrupado en lista
            var agrupadoInformacionPerfilLista = (from agr in agrupadoInformacionPerfil

                                                  select new PerfilPermiso

                                                  {
                                                      //Submodulo
                                                      IdSubModulo = agr.Key.IdSubModulo,
                                                      DescripcionSubmodulo = agr.Key.DescripcionSubmodulo,
                                                      //Permiso                            
                                                      Todos = agr.Key.Todos,
                                                      Crear = agr.Key.Crear,
                                                      Editar = agr.Key.Editar,
                                                      Consultar = agr.Key.Consultar,
                                                      Eliminar = agr.Key.Eliminar,
                                                      Descargar = agr.Key.Descargar,
                                                      Cargar = agr.Key.Cargar,
                                                      Autorizar = agr.Key.Autorizar,
                                                      Historico = agr.Key.Historico,

                                                  }).ToList();



            //Consulta de Cargos del usuario

            var informacionCargo = (from mod1 in context.ModuloCats
                                    join sub1 in context.SubModuloCats
                                    on mod1.IdModulo equals sub1.IdModulo
                                    join perm1 in context.Permisos
                                    on sub1.IdSubModulo equals perm1.IdSubModulo
                                    join carg in context.CargoxOrganos
                                    on perm1.IdPerfilCargo equals carg.IdPerfilCargo
                                    join usu in context.Usuarios
                                    on carg.IdPersona equals usu.IdPersona
                                    where usu.CorreoAcceso == correoAcceso && usu.EstatusUsuario == true && carg.EstatusCargoOrgano == true

                                    select new PerfilPermiso

                                    {
                                        // SubModulo
                                        IdSubModulo = sub1.IdSubModulo,
                                        DescripcionSubmodulo = sub1.Descripcion,
                                        //Permiso                            
                                        Todos = perm1.Todos,
                                        Crear = perm1.Crear,
                                        Editar = perm1.Editar,
                                        Consultar = perm1.Consultar,
                                        Eliminar = perm1.Eliminar,
                                        Descargar = perm1.Descargar,
                                        Cargar = perm1.Cargar,
                                        Autorizar = perm1.Autorizar,
                                        Historico = perm1.Historico,
                                    }).ToList();


            //Agrupado de información de Cargos

            var agrupadoInformacionCargo = from s in informacionCargo
                                           group s by new
                                           {
                                               s.IdSubModulo,
                                               s.DescripcionSubmodulo,
                                               s.Todos,
                                               s.Crear,
                                               s.Editar,
                                               s.Consultar,
                                               s.Eliminar,
                                               s.Descargar,
                                               s.Cargar,
                                               s.Autorizar,
                                               s.Historico,
                                           };

            // Convierte agrupado en lista
            var agrupadoInformacionCargoLista = (from agr in agrupadoInformacionCargo

                                                 select new PerfilPermiso

                                                 {
                                                     //Submodulo
                                                     IdSubModulo = agr.Key.IdSubModulo,
                                                     DescripcionSubmodulo = agr.Key.DescripcionSubmodulo,
                                                     //Permiso                            
                                                     Todos = agr.Key.Todos,
                                                     Crear = agr.Key.Crear,
                                                     Editar = agr.Key.Editar,
                                                     Consultar = agr.Key.Consultar,
                                                     Eliminar = agr.Key.Eliminar,
                                                     Descargar = agr.Key.Descargar,
                                                     Cargar = agr.Key.Cargar,
                                                     Autorizar = agr.Key.Autorizar,
                                                     Historico = agr.Key.Historico,

                                                 }).ToList();


            // Planchado de información de permisos en tabla de agrupado de perfil

            foreach (var permisoCargo in agrupadoInformacionCargoLista)
            {

                foreach (var permisoPerfil in agrupadoInformacionPerfilLista)
                {
                    if (permisoCargo.IdSubModulo == permisoPerfil.IdSubModulo)
                    {
                        if (permisoPerfil.Todos == false)
                        {
                            if (permisoCargo.Todos == true)
                            { permisoPerfil.Todos = true; }
                        }
                        else { }

                        if (permisoPerfil.Crear == false)
                        {
                            if (permisoCargo.Crear == true)
                            { permisoPerfil.Crear = true; }
                        }
                        else { }

                        if (permisoPerfil.Editar == false)
                        {
                            if (permisoCargo.Editar == true)
                            { permisoPerfil.Editar = true; }
                        }
                        else { }

                        if (permisoPerfil.Consultar == false)
                        {
                            if (permisoCargo.Consultar == true)
                            { permisoPerfil.Consultar = true; }
                        }
                        else { }

                        if (permisoPerfil.Eliminar == false)
                        {
                            if (permisoCargo.Eliminar == true)
                            { permisoPerfil.Eliminar = true; }
                        }
                        else { }

                        if (permisoPerfil.Descargar == false)
                        {
                            if (permisoCargo.Descargar == true)
                            { permisoPerfil.Descargar = true; }
                        }
                        else { }

                        if (permisoPerfil.Cargar == false)
                        {
                            if (permisoCargo.Cargar == true)
                            { permisoPerfil.Cargar = true; }
                        }
                        else { }

                        if (permisoPerfil.Autorizar == false)
                        {
                            if (permisoCargo.Autorizar == true)
                            { permisoPerfil.Autorizar = true; }
                        }
                        else { }

                        if (permisoPerfil.Historico == false)
                        {
                            if (permisoCargo.Historico == true)
                            { permisoPerfil.Historico = true; }
                        }
                        else { }
                    }
                    else { }




                }
            }


            // Listas finales
            var permisosResumenTodos = (from permiso in agrupadoInformacionPerfilLista
                                        select new PerfilPermisoResumen
                                        {
                                            DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                            Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                            Permiso = "Todos",
                                            Valor = permiso.Todos
                                        }
                          ).ToList();

            var permisosResumenCrear = (from permiso in agrupadoInformacionPerfilLista
                                        select new PerfilPermisoResumen
                                        {
                                            DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                            Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                            Permiso = "Crear",
                                            Valor = permiso.Crear
                                        }
                          ).ToList();
            var permisosResumenEditar = (from permiso in agrupadoInformacionPerfilLista
                                         select new PerfilPermisoResumen
                                         {
                                             DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                             Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                             Permiso = "Editar",
                                             Valor = permiso.Editar
                                         }
                          ).ToList();

            var permisosResumenConsultar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                                Permiso = "Consultar",
                                                Valor = permiso.Consultar
                                            }
                          ).ToList();
            var permisosResumenEliminar = (from permiso in agrupadoInformacionPerfilLista
                                           select new PerfilPermisoResumen
                                           {
                                               DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                               Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                               Permiso = "Eliminar",
                                               Valor = permiso.Eliminar
                                           }
                          ).ToList();

            var permisosResumenDescargar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                                Permiso = "Descargar",
                                                Valor = permiso.Descargar
                                            }
                          ).ToList();
            var permisosResumenCargar = (from permiso in agrupadoInformacionPerfilLista
                                         select new PerfilPermisoResumen
                                         {
                                             DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                             Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                             Permiso = "Cargar",
                                             Valor = permiso.Cargar
                                         }
                          ).ToList();

            var permisosResumenAutorizar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                                Permiso = "Autorizar",
                                                Valor = permiso.Autorizar
                                            }
                          ).ToList();
            var permisosResumenHistorico = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Submodulo = Cadenas.RemueveAcentos(Cadenas.RemueveEspacios(permiso.DescripcionSubmodulo)),
                                                Permiso = "Historico",
                                                Valor = permiso.Historico
                                            }
                          ).ToList();


            var listaUnionFinal = permisosResumenTodos.Union(permisosResumenCrear).Union(permisosResumenEditar).Union(permisosResumenConsultar).Union(permisosResumenEliminar).Union(permisosResumenDescargar).Union(permisosResumenCargar).Union(permisosResumenAutorizar).Union(permisosResumenHistorico);

            return listaUnionFinal.ToList();
            //return agrupadoInformacionPerfilLista;

        }

        public List<PerfilPermiso> ObtenerPerfilPermisobyIdUsuario(int idUsuario)
        {

            // var coreein = EnviarNotificacionSolicitudCreacion(7);

            //Consulta inicial de perfil - todo usuario debe tener un perfil -

            var informacionPerfil = (from mod1 in context.ModuloCats
                                     join sub1 in context.SubModuloCats
                                     on mod1.IdModulo equals sub1.IdModulo
                                     join perm1 in context.Permisos
                                     on sub1.IdSubModulo equals perm1.IdSubModulo
                                     join perf1 in context.PerfilCargos
                                     on perm1.IdPerfilCargo equals perf1.IdPerfilCargo
                                     join usu in context.Usuarios
                                     on perf1.IdPerfilCargo equals usu.IdPerfilCargo
                                     //where usu.IdPersona==idPersona
                                     where usu.IdUsuario == idUsuario && usu.EstatusUsuario == true

                                     select new PerfilPermiso

                                     {
                                         // SubModulo
                                         IdSubModulo = sub1.IdSubModulo,
                                         DescripcionSubmodulo = sub1.Descripcion,
                                         //Permiso                            
                                         Todos = perm1.Todos,
                                         Crear = perm1.Crear,
                                         Editar = perm1.Editar,
                                         Consultar = perm1.Consultar,
                                         Eliminar = perm1.Eliminar,
                                         Descargar = perm1.Descargar,
                                         Cargar = perm1.Cargar,
                                         Autorizar = perm1.Autorizar,
                                         Historico = perm1.Historico,
                                     }).ToList();


            //Agrupado de información de Perfil

            var agrupadoInformacionPerfil = from s in informacionPerfil
                                            group s by new
                                            {
                                                s.IdSubModulo,
                                                s.DescripcionSubmodulo,
                                                s.Todos,
                                                s.Crear,
                                                s.Editar,
                                                s.Consultar,
                                                s.Eliminar,
                                                s.Descargar,
                                                s.Cargar,
                                                s.Autorizar,
                                                s.Historico,
                                            };

            // Convierte agrupado en lista
            var agrupadoInformacionPerfilLista = (from agr in agrupadoInformacionPerfil

                                                  select new PerfilPermiso

                                                  {
                                                      //Submodulo
                                                      IdSubModulo = agr.Key.IdSubModulo,
                                                      DescripcionSubmodulo = agr.Key.DescripcionSubmodulo,
                                                      //Permiso                            
                                                      Todos = agr.Key.Todos,
                                                      Crear = agr.Key.Crear,
                                                      Editar = agr.Key.Editar,
                                                      Consultar = agr.Key.Consultar,
                                                      Eliminar = agr.Key.Eliminar,
                                                      Descargar = agr.Key.Descargar,
                                                      Cargar = agr.Key.Cargar,
                                                      Autorizar = agr.Key.Autorizar,
                                                      Historico = agr.Key.Historico,

                                                  }).ToList();



            //Consulta de Cargos del usuario

            var informacionCargo = (from mod1 in context.ModuloCats
                                    join sub1 in context.SubModuloCats
                                    on mod1.IdModulo equals sub1.IdModulo
                                    join perm1 in context.Permisos
                                    on sub1.IdSubModulo equals perm1.IdSubModulo
                                    join carg in context.CargoxOrganos
                                    on perm1.IdPerfilCargo equals carg.IdPerfilCargo
                                    join usu in context.Usuarios
                                    on carg.IdPersona equals usu.IdPersona
                                    //  where usu.IdPersona == idPersona
                                    where usu.IdUsuario == idUsuario

                                    select new PerfilPermiso

                                    {
                                        // SubModulo
                                        IdSubModulo = sub1.IdSubModulo,
                                        DescripcionSubmodulo = sub1.Descripcion,
                                        //Permiso                            
                                        Todos = perm1.Todos,
                                        Crear = perm1.Crear,
                                        Editar = perm1.Editar,
                                        Consultar = perm1.Consultar,
                                        Eliminar = perm1.Eliminar,
                                        Descargar = perm1.Descargar,
                                        Cargar = perm1.Cargar,
                                        Autorizar = perm1.Autorizar,
                                        Historico = perm1.Historico,
                                    }).ToList();


            //Agrupado de información de Cargos

            var agrupadoInformacionCargo = from s in informacionCargo
                                           group s by new
                                           {
                                               s.IdSubModulo,
                                               s.DescripcionSubmodulo,
                                               s.Todos,
                                               s.Crear,
                                               s.Editar,
                                               s.Consultar,
                                               s.Eliminar,
                                               s.Descargar,
                                               s.Cargar,
                                               s.Autorizar,
                                               s.Historico,
                                           };

            // Convierte agrupado en lista
            var agrupadoInformacionCargoLista = (from agr in agrupadoInformacionCargo

                                                 select new PerfilPermiso

                                                 {
                                                     //Submodulo
                                                     IdSubModulo = agr.Key.IdSubModulo,
                                                     DescripcionSubmodulo = agr.Key.DescripcionSubmodulo,
                                                     //Permiso                            
                                                     Todos = agr.Key.Todos,
                                                     Crear = agr.Key.Crear,
                                                     Editar = agr.Key.Editar,
                                                     Consultar = agr.Key.Consultar,
                                                     Eliminar = agr.Key.Eliminar,
                                                     Descargar = agr.Key.Descargar,
                                                     Cargar = agr.Key.Cargar,
                                                     Autorizar = agr.Key.Autorizar,
                                                     Historico = agr.Key.Historico,

                                                 }).ToList();


            // Planchado de información de permisos en tabla de agrupado de perfil

            foreach (var permisoCargo in agrupadoInformacionCargoLista)
            {

                foreach (var permisoPerfil in agrupadoInformacionPerfilLista)
                {
                    if (permisoCargo.IdSubModulo == permisoPerfil.IdSubModulo)
                    {
                        if (permisoPerfil.Todos == false)
                        {
                            if (permisoCargo.Todos == true)
                            { permisoPerfil.Todos = true; }
                        }
                        else { }

                        if (permisoPerfil.Crear == false)
                        {
                            if (permisoCargo.Crear == true)
                            { permisoPerfil.Crear = true; }
                        }
                        else { }

                        if (permisoPerfil.Editar == false)
                        {
                            if (permisoCargo.Editar == true)
                            { permisoPerfil.Editar = true; }
                        }
                        else { }

                        if (permisoPerfil.Consultar == false)
                        {
                            if (permisoCargo.Consultar == true)
                            { permisoPerfil.Consultar = true; }
                        }
                        else { }

                        if (permisoPerfil.Eliminar == false)
                        {
                            if (permisoCargo.Eliminar == true)
                            { permisoPerfil.Eliminar = true; }
                        }
                        else { }

                        if (permisoPerfil.Descargar == false)
                        {
                            if (permisoCargo.Descargar == true)
                            { permisoPerfil.Descargar = true; }
                        }
                        else { }

                        if (permisoPerfil.Cargar == false)
                        {
                            if (permisoCargo.Cargar == true)
                            { permisoPerfil.Cargar = true; }
                        }
                        else { }

                        if (permisoPerfil.Autorizar == false)
                        {
                            if (permisoCargo.Autorizar == true)
                            { permisoPerfil.Autorizar = true; }
                        }
                        else { }

                        if (permisoPerfil.Historico == false)
                        {
                            if (permisoCargo.Historico == true)
                            { permisoPerfil.Historico = true; }
                        }
                        else { }
                    }
                    else { }




                }
            }

            // Listas finales
            var permisosResumenTodos = (from permiso in agrupadoInformacionPerfilLista
                                        select new PerfilPermisoResumen
                                        {
                                            DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                            Permiso = "Todos",
                                            Valor = permiso.Todos
                                        }
                          ).ToList();

            var permisosResumenCrear = (from permiso in agrupadoInformacionPerfilLista
                                        select new PerfilPermisoResumen
                                        {
                                            DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                            Permiso = "Crear",
                                            Valor = permiso.Crear
                                        }
                          ).ToList();
            var permisosResumenEditar = (from permiso in agrupadoInformacionPerfilLista
                                         select new PerfilPermisoResumen
                                         {
                                             DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                             Permiso = "Editar",
                                             Valor = permiso.Editar
                                         }
                          ).ToList();

            var permisosResumenConsultar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Permiso = "Consultar",
                                                Valor = permiso.Consultar
                                            }
                          ).ToList();
            var permisosResumenEliminar = (from permiso in agrupadoInformacionPerfilLista
                                           select new PerfilPermisoResumen
                                           {
                                               DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                               Permiso = "Eliminar",
                                               Valor = permiso.Eliminar
                                           }
                          ).ToList();

            var permisosResumenDescargar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Permiso = "Descargar",
                                                Valor = permiso.Descargar
                                            }
                          ).ToList();
            var permisosResumenCargar = (from permiso in agrupadoInformacionPerfilLista
                                         select new PerfilPermisoResumen
                                         {
                                             DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                             Permiso = "Cargar",
                                             Valor = permiso.Cargar
                                         }
                          ).ToList();

            var permisosResumenAutorizar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Permiso = "Autorizar",
                                                Valor = permiso.Autorizar
                                            }
                          ).ToList();
            var permisosResumenHistorico = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Permiso = "Historico",
                                                Valor = permiso.Historico
                                            }
                          ).ToList();




            var listaUnionFinal = permisosResumenTodos.Union(permisosResumenCrear).Union(permisosResumenEditar).Union(permisosResumenConsultar).Union(permisosResumenEliminar).Union(permisosResumenDescargar).Union(permisosResumenCargar).Union(permisosResumenAutorizar).Union(permisosResumenHistorico);

            //return prueba;

            return agrupadoInformacionPerfilLista;

        }

        public List<PerfilPermiso> ObtenerPerfilPermisobyIdPerfil(int idPerfil)
        {
            //Consulta inicial de perfil - todo usuario debe tener un perfil -

            var informacionPerfil = (from mod1 in context.ModuloCats
                                     join sub1 in context.SubModuloCats
                                     on mod1.IdModulo equals sub1.IdModulo
                                     join perm1 in context.Permisos
                                     on sub1.IdSubModulo equals perm1.IdSubModulo
                                     join perf1 in context.PerfilCargos
                                     on perm1.IdPerfilCargo equals perf1.IdPerfilCargo

                                     where perf1.IdPerfilCargo == idPerfil

                                     select new PerfilPermiso

                                     {
                                         //Perfil
                                         DescripcionPerfil = perf1.Descripcion,
                                         // SubModulo
                                         IdSubModulo = sub1.IdSubModulo,
                                         DescripcionSubmodulo = sub1.Descripcion,
                                         //Permiso                            
                                         Todos = perm1.Todos,
                                         Crear = perm1.Crear,
                                         Editar = perm1.Editar,
                                         Consultar = perm1.Consultar,
                                         Eliminar = perm1.Eliminar,
                                         Descargar = perm1.Descargar,
                                         Cargar = perm1.Cargar,
                                         Autorizar = perm1.Autorizar,
                                         Historico = perm1.Historico,
                                     }).ToList();


            //Agrupado de información de Perfil

            var agrupadoInformacionPerfil = from s in informacionPerfil
                                            group s by new
                                            {
                                                s.DescripcionPerfil,
                                                s.IdSubModulo,
                                                s.DescripcionSubmodulo,
                                                s.Todos,
                                                s.Crear,
                                                s.Editar,
                                                s.Consultar,
                                                s.Eliminar,
                                                s.Descargar,
                                                s.Cargar,
                                                s.Autorizar,
                                                s.Historico,
                                            };

            // Convierte agrupado en lista
            var agrupadoInformacionPerfilLista = (from agr in agrupadoInformacionPerfil

                                                  select new PerfilPermiso

                                                  {
                                                      //Perfil
                                                      DescripcionPerfil = agr.Key.DescripcionPerfil,
                                                      //Submodulo
                                                      IdSubModulo = agr.Key.IdSubModulo,
                                                      DescripcionSubmodulo = agr.Key.DescripcionSubmodulo,
                                                      //Permiso                            
                                                      Todos = agr.Key.Todos,
                                                      Crear = agr.Key.Crear,
                                                      Editar = agr.Key.Editar,
                                                      Consultar = agr.Key.Consultar,
                                                      Eliminar = agr.Key.Eliminar,
                                                      Descargar = agr.Key.Descargar,
                                                      Cargar = agr.Key.Cargar,
                                                      Autorizar = agr.Key.Autorizar,
                                                      Historico = agr.Key.Historico,

                                                  }).ToList();

            // Listas finales
            var permisosResumenTodos = (from permiso in agrupadoInformacionPerfilLista
                                        select new PerfilPermisoResumen
                                        {
                                            DescripcionPerfil = permiso.DescripcionPerfil,
                                            DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                            Permiso = "Todos",
                                            Valor = permiso.Todos
                                        }
                          ).ToList();

            var permisosResumenCrear = (from permiso in agrupadoInformacionPerfilLista
                                        select new PerfilPermisoResumen
                                        {
                                            DescripcionPerfil = permiso.DescripcionPerfil,
                                            DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                            Permiso = "Crear",
                                            Valor = permiso.Crear
                                        }
                          ).ToList();
            var permisosResumenEditar = (from permiso in agrupadoInformacionPerfilLista
                                         select new PerfilPermisoResumen
                                         {
                                             DescripcionPerfil = permiso.DescripcionPerfil,
                                             DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                             Permiso = "Editar",
                                             Valor = permiso.Editar
                                         }
                          ).ToList();

            var permisosResumenConsultar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionPerfil = permiso.DescripcionPerfil,
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Permiso = "Consultar",
                                                Valor = permiso.Consultar
                                            }
                          ).ToList();
            var permisosResumenEliminar = (from permiso in agrupadoInformacionPerfilLista
                                           select new PerfilPermisoResumen
                                           {
                                               DescripcionPerfil = permiso.DescripcionPerfil,
                                               DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                               Permiso = "Eliminar",
                                               Valor = permiso.Eliminar
                                           }
                          ).ToList();

            var permisosResumenDescargar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionPerfil = permiso.DescripcionPerfil,
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Permiso = "Descargar",
                                                Valor = permiso.Descargar
                                            }
                          ).ToList();
            var permisosResumenCargar = (from permiso in agrupadoInformacionPerfilLista
                                         select new PerfilPermisoResumen
                                         {
                                             DescripcionPerfil = permiso.DescripcionPerfil,
                                             DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                             Permiso = "Cargar",
                                             Valor = permiso.Cargar
                                         }
                          ).ToList();

            var permisosResumenAutorizar = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionPerfil = permiso.DescripcionPerfil,
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Permiso = "Autorizar",
                                                Valor = permiso.Autorizar
                                            }
                          ).ToList();
            var permisosResumenHistorico = (from permiso in agrupadoInformacionPerfilLista
                                            select new PerfilPermisoResumen
                                            {
                                                DescripcionPerfil = permiso.DescripcionPerfil,
                                                DescripcionSubmodulo = permiso.DescripcionSubmodulo,
                                                Permiso = "Historico",
                                                Valor = permiso.Historico
                                            }
                          ).ToList();




            var listaUnionFinal = permisosResumenTodos.Union(permisosResumenCrear).Union(permisosResumenEditar).Union(permisosResumenConsultar).Union(permisosResumenEliminar).Union(permisosResumenDescargar).Union(permisosResumenCargar).Union(permisosResumenAutorizar).Union(permisosResumenHistorico);

            //return prueba;

            return agrupadoInformacionPerfilLista;

        }
        public List<PerfilPermiso> ObtenerPerfilPermisoSinPerfil()
        {

            var prueba = (from mod1 in context.ModuloCats
                          join sub1 in context.SubModuloCats
                          on mod1.IdModulo equals sub1.IdModulo
                          join perm1 in context.Permisos
                          on sub1.IdSubModulo equals perm1.IdSubModulo
                          join perf1 in context.PerfilCargos
                          on perm1.IdPerfilCargo equals perf1.IdPerfilCargo
                          where perf1.IdPerfilCargo == 16 && mod1.EstatusModulo == true && sub1.EstatusSubModulo == true && perf1.EstatusPerfil == true
                          select new PerfilPermiso

                          {
                              // Modulo
                              IdModulo = mod1.IdModulo,
                              DescripcionModulo = mod1.Descripcion,
                              EstatusModulo = mod1.EstatusModulo,
                              //Submodulo //
                              IdSubModulo = sub1.IdSubModulo,
                              DescripcionSubmodulo = sub1.Descripcion,
                              EstatusSubModulo = sub1.EstatusSubModulo,
                              //Perfil
                              IdPerfilCargo = perf1.IdPerfilCargo,
                              DescripcionPerfil = perf1.Descripcion,
                              EstatusPerfil = perf1.EstatusPerfil,
                              OrdenCargo = perf1.OrdenCargo,
                              EsCargo = perf1.EsCargo,
                              //Permiso
                              IdPermiso = perm1.IdPermiso,
                              Todos = perm1.Todos,
                              Crear = perm1.Crear,
                              Editar = perm1.Editar,
                              Consultar = perm1.Consultar,
                              Eliminar = perm1.Eliminar,
                              Descargar = perm1.Descargar,
                              Cargar = perm1.Cargar,
                              Autorizar = perm1.Autorizar,
                              Historico = perm1.Historico,
                              EstatusPermiso = perm1.EstatusPermiso,

                          }).ToList();

            return prueba;
            //return (List<PerfilCargoPersonaPerfil>)_PerfilCargoPersonaPerfil;
        }

        public List<PerfilCargo> ObtenerPerfilCargos()
        {
            return context.PerfilCargos.ToList();
        }

        public List<PerfilCargo> ObtenerPerfilCargosActivos()
        {
            // carga solo los activos qy que no sean cargos
            return context.PerfilCargos.Where(x => x.EstatusPerfil == true && x.EsCargo == false && x.IdPerfilCargo != 16).ToList();
        }

        public bool CrearPerfilCargo(PerfilCargo PerfilCargo)
        {
            try
            {
                context.PerfilCargos.Add(PerfilCargo);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CrearPerfilPermiso(PerfilPermiso PerfilPermiso)
        {
            try
            {
                // checar insert en PerfilCargo, persona, perfil

                var result = context.EscolaridadCats.FromSqlRaw<EscolaridadCat>("pa_Obtener_Escolaridad").ToList();

                // var result2 = context.Database.ExecuteSqlRaw("insert into persona(1,2,3) values ()");
                // context.PerfilCargos.Add(PerfilCargo);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int CrearPerfilPermisoNew(List<PerfilPermiso> PerfilPermiso)
        {
            try
            {
                var parameter = new List<SqlParameter>();

                var valorSalida = new SqlParameter
                {
                    ParameterName = "@ValorSalida",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = 0
                };

                string descripcionPerfil = "Nuevo";
                int ordenCargo = 1;
                bool esCargo = true;

                foreach (var perfilPermiso in PerfilPermiso)
                {
                    descripcionPerfil = perfilPermiso.DescripcionPerfil;
                    esCargo = (bool)perfilPermiso.EsCargo;
                    ordenCargo = (int)(perfilPermiso.OrdenCargo == null ? 0 : perfilPermiso.OrdenCargo);
                }

                // Insert de PerfilCargo

                var resultPerfilCargoInsert = context.Database.ExecuteSqlRaw("pa_i_Insertar_Perfil_Cargo @p0,@p1,@p2,@ValorSalida out", descripcionPerfil, ordenCargo, esCargo, valorSalida);
                int resultPerfilCargo = (int)valorSalida.Value;
                var resultFinal = 0;

                // Insert de Permiso

                foreach (var perfilPermiso in PerfilPermiso)
                {
                    var result = context.Database.ExecuteSqlRaw("pa_i_Insertar_Perfil_Permiso @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14", perfilPermiso.DescripcionPerfil,
                            perfilPermiso.OrdenCargo,
                            perfilPermiso.EsCargo,
                            perfilPermiso.IdModulo,
                            perfilPermiso.IdSubModulo,
                            perfilPermiso.Todos,
                            perfilPermiso.Crear,
                            perfilPermiso.Editar,
                            perfilPermiso.Consultar,
                            perfilPermiso.Eliminar,
                            perfilPermiso.Descargar,
                            perfilPermiso.Cargar,
                            perfilPermiso.Autorizar,
                            perfilPermiso.Historico,
                            resultPerfilCargo

                );

                    resultFinal = result;
                }


                return resultFinal;


            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool ModificarPerfilPermiso(List<PerfilPermiso> perfilpermiso)
        {

            foreach (var perfilPermiso in perfilpermiso)
            {
                var result = context.Database.ExecuteSqlRaw("pa_u_Actualizar_Perfil_Permiso @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15", perfilPermiso.DescripcionPerfil,
                        perfilPermiso.OrdenCargo,
                        perfilPermiso.EsCargo,
                        perfilPermiso.IdModulo,
                        perfilPermiso.IdSubModulo,
                        perfilPermiso.Todos,
                        perfilPermiso.Crear,
                        perfilPermiso.Editar,
                        perfilPermiso.Consultar,
                        perfilPermiso.Eliminar,
                        perfilPermiso.Descargar,
                        perfilPermiso.Cargar,
                        perfilPermiso.Autorizar,
                        perfilPermiso.Historico,
                        perfilPermiso.IdPermiso,
                        perfilPermiso.IdPerfilCargo

            );

            }

            return true;
        }

        public PerfilCargo PerfilCargobyId(int idPerfilCargo)
        {
            var PerfilCargo = context.PerfilCargos.Where(x => x.IdPerfilCargo == idPerfilCargo).FirstOrDefault();

            if (PerfilCargo == null)
                return null;
            else
                return PerfilCargo;

        }

        public PerfilCargo PerfilCargobyNombre(string nombre)
        {
            var PerfilCargo = context.PerfilCargos.Where(x => x.Descripcion == nombre).FirstOrDefault();

            if (PerfilCargo == null)
            {
                var pruebaVacia = new PerfilCargo();
                pruebaVacia.Descripcion = "";

                return pruebaVacia;
            }
            else
                return PerfilCargo;

        }

        public List<PerfilPermiso> PerfilPermisobyId(int idPerfilCargo)
        {
            var prueba = (from mod1 in context.ModuloCats
                          join sub1 in context.SubModuloCats
                          on mod1.IdModulo equals sub1.IdModulo
                          join perm1 in context.Permisos
                          on sub1.IdSubModulo equals perm1.IdSubModulo
                          join perf1 in context.PerfilCargos
                          on perm1.IdPerfilCargo equals perf1.IdPerfilCargo
                          where perf1.IdPerfilCargo == idPerfilCargo && mod1.EstatusModulo == true && sub1.EstatusSubModulo == true

                          select new PerfilPermiso

                          {
                              // Modulo
                              IdModulo = mod1.IdModulo,
                              DescripcionModulo = mod1.Descripcion,
                              EstatusModulo = mod1.EstatusModulo,
                              //Submodulo //
                              IdSubModulo = sub1.IdSubModulo,
                              DescripcionSubmodulo = sub1.Descripcion,
                              EstatusSubModulo = sub1.EstatusSubModulo,
                              //Perfil
                              IdPerfilCargo = perf1.IdPerfilCargo,
                              DescripcionPerfil = perf1.Descripcion,
                              EstatusPerfil = perf1.EstatusPerfil,
                              OrdenCargo = perf1.OrdenCargo,
                              EsCargo = perf1.EsCargo,
                              //Permiso
                              IdPermiso = perm1.IdPermiso,
                              Todos = perm1.Todos,
                              Crear = perm1.Crear,
                              Editar = perm1.Editar,
                              Consultar = perm1.Consultar,
                              Eliminar = perm1.Eliminar,
                              Descargar = perm1.Descargar,
                              Cargar = perm1.Cargar,
                              Autorizar = perm1.Autorizar,
                              Historico = perm1.Historico,
                              EstatusPermiso = perm1.EstatusPermiso,

                          }).ToList();

            return prueba;

        }



        public bool EnviarNotificacionSolicitudCreacion(int idSolicitud)
        {

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

            EnviarEmail email = new EnviarEmail();
            email.EnviarCorreoSolicitudNotificacion(addListTo, subject, isBodyHTML, addCc, addCco, body);

            return true;
        }

    }
}
