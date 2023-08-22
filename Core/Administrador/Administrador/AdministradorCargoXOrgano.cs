using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Comun.Constantes;
using CPM.PlataformaDirigentes.Comun.Enumerados;
using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.CargoXOrgano;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.ModeloDom.Persona;
using CPM.PlataformaDirigentes.Models.Models;
using CPMPlataformaDirigentes.Data.Contexto;
using CPMPlataformaDirigentes.Models.Models;
using CPMPlataformaDirigentes.Models.ModelsDirectorioSucursales;
using LoggerUtility.LogUtility;
using MGenericRepository;
using System.Data;

namespace CPM.PlataformaDirigentes.Administrador.Administrador
{
    public class AdministradorCargoXOrgano : IAdministradorCargoXOrgano
    {
        private IRepositorioCargoXOrgano repoCargoXOrgano;
        private IRepositorioSelect repoSelect;
        private CPMDirigentesPlataformaContext context;
        private CPMDirectorioSucursalesContext contextSuc;

        public AdministradorCargoXOrgano()
        {
            this.repoCargoXOrgano = new RepositorioCargoxOrgano();
            this.repoSelect = new RepositorioSelect();
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            this.contextSuc = new CPMDirectorioSucursalesContext(Configuracion.GetConnectionConsultaCpmDirectorioString());
        }
        public List<CargoOrganoDescDom> Obtener()
        {
            return repoCargoXOrgano.Obtener();
        }
        public Respuesta Crear(List<CargoOrganoDom> cargoxorgano)
        {
            var respVal = ValidacionCargos(cargoxorgano);
            if (respVal.Resultado)
            {
                var respNegocio = ReglasNegocioCargos(cargoxorgano);
                if (respNegocio.Resultado)
                    return repoCargoXOrgano.Crear(cargoxorgano);
                else
                    return respNegocio;
            }
            else
                return respVal;
        }
        public Respuesta Modificar(CargoOrganoDom cargoxorgano)
        {
            List<CargoOrganoDom> lstcargos = new List<CargoOrganoDom>();
            lstcargos.Add(cargoxorgano);

            var respVal = ValidacionCargos(lstcargos);
            if (respVal.Resultado)
            {
                var respNegocio = ReglasNegocioCargos(lstcargos);
                if (respNegocio.Resultado)
                    return repoCargoXOrgano.Modificar(cargoxorgano);
                else
                    return respNegocio;
            }
            else
                return respVal;
        }
        public bool Desactivar(int cargoxorgano)
        {
            return repoCargoXOrgano.Desactivar(cargoxorgano);
        }
        public CargoOrganoDom RegistrobyId(int idcargoxorgano)
        {
            return repoCargoXOrgano.RegistrobyId(idcargoxorgano);
        }
        public List<SelectDom> GetOrgano(int idNivel)
        {
            return repoSelect.GetOrgano(idNivel);
        }
        public List<SelectDom> GetCargo()
        {
            return repoSelect.GetCargo();
        }
        public List<SelectDom> GetPlaza()
        {
            return repoSelect.GetPlaza();
        }
        public List<SelectDom> GetNivel()
        {
            return repoSelect.GetNivel();
        }
        public List<PersonaBuscar> GetUsuario(BuscarPersona bPersona)
        {
            List<PersonaBuscar> lstPersonas = new();
            IGenericRepository<PersonaCat> repoPersona = new GenericRepository<PersonaCat>(context);
            IGenericRepository<PlazaWrk> repoPlaza = new GenericRepository<PlazaWrk>(contextSuc);

            PersonaBuscar oPersona = new();

            //CIF
            if (bPersona.TipoBusqueda == (int)TipoBusqueda.CIF)
            {
                try
                {
                    var persona = repoPersona.GetFirstOrDefault(x => x.Cif == Convert.ToInt64(bPersona.PersonaBusqueda));
                    if (persona != null)
                    {
                        oPersona.IdPersona = persona.IdPersona;
                        oPersona.NombrePersona = persona.NombrePersona;
                        oPersona.ApellidoPaterno = persona.ApellidoPaterno;
                        oPersona.ApellidoMaterno = persona.ApellidoMaterno;
                        oPersona.FechaIngreso = persona.FechaIngreso;
                        lstPersonas.Add(oPersona);
                        return lstPersonas;
                    }
                    else
                        return lstPersonas;

                }
                catch (Exception ex)
                {
                    Logger.Error("Error Get Usuario 1", ex);
                    return lstPersonas;
                }
            }
            //Nombre
            else if (bPersona.TipoBusqueda == (int)TipoBusqueda.Nombre)
            {

                var lstPlazas = repoPlaza.Get();

                try
                {
                    string apellidoMaterno = bPersona.ApellidoMaterno;
                    string apellidoPaterno = bPersona.ApellidoPaterno;
                    string nombreUsuario = bPersona.PersonaBusqueda;

                    var lstpersonabusca = repoPersona.Get(x => x.NombrePersona.Trim().ToUpper() == nombreUsuario.Trim().ToUpper()
                                                                && x.ApellidoPaterno.Trim().ToUpper() == apellidoPaterno.Trim().ToUpper()
                                                                && x.ApellidoMaterno.Trim().ToUpper() == apellidoMaterno.Trim().ToUpper()
                                                                );

                    if (lstpersonabusca.Count > 0)
                    {
                        foreach (var person in lstpersonabusca)
                        {
                            PersonaBuscar oPersonalst = new();

                            oPersonalst.IdPersona = person.IdPersona;
                            oPersonalst.NombrePersona = person.NombrePersona;
                            oPersonalst.ApellidoPaterno = person.ApellidoPaterno;
                            oPersonalst.ApellidoMaterno = person.ApellidoMaterno;
                            oPersonalst.FechaIngreso = person.FechaIngreso;

                            if (person.IdPlaza != null)
                                oPersonalst.Plaza = lstPlazas.Where(x => x.IdPlaza == person.IdPlaza).SingleOrDefault().Nombre.ToString();

                            lstPersonas.Add(oPersonalst);
                        }

                        return lstPersonas;
                    }
                    else
                        return lstPersonas;
                }
                catch (Exception ex)
                {
                    Logger.Error("Error Get Usuario 2", ex);
                    return lstPersonas;
                }
            }
            else
            //Numero de socio
            {
                try
                {
                    var persona = repoPersona.GetFirstOrDefault(x => x.CuentaMexicana == bPersona.PersonaBusqueda);

                    if (persona != null)
                    {
                        oPersona.IdPersona = persona.IdPersona;
                        oPersona.NombrePersona = persona.NombrePersona;
                        oPersona.ApellidoPaterno = persona.ApellidoPaterno;
                        oPersona.ApellidoMaterno = persona.ApellidoMaterno;
                        oPersona.FechaIngreso = persona.FechaIngreso;
                        lstPersonas.Add(oPersona);
                        return lstPersonas;
                    }
                    else
                        return lstPersonas;
                }
                catch (Exception ex)
                {
                    Logger.Error("Error Get Usuario 2", ex);
                    return lstPersonas;
                }
            }
        }
        private static Respuesta ValidacionCargos(List<CargoOrganoDom> cargoxorgano)
        {
            int numCargo = 0;
            Respuesta resp = new Respuesta();
            resp.Resultado = true;

            foreach (var item in cargoxorgano)
            {
                resp.Mensaje += String.Format("El cargo {0} tiene los siguintes errores : ", ++numCargo);
                if (item.IdPersona == (int)Numeracion.Cero)
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>Debe seleccionar una persona</li>";
                }

                if (item.IdNivelGestion == (int)Numeracion.Cero)
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>Debe seleccionar un nivel</li>";
                }

                if (item.IdPerfilCargo == (int)Numeracion.Cero)
                {
                    resp.Resultado = false;
                    resp.Mensaje = "<li>Debe seleccionar un Cargo</li>";
                }


                if (item.IdOrgano == (int)Numeracion.Cero)
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>Debe seleccionar un órgano</li>";
                }

                if (String.IsNullOrEmpty(item.Firmante))
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>Indique si es firmante</li>";
                }

                if (String.IsNullOrEmpty(item.Suplente))
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>Indique si es suplengte</li>";

                }
                if (String.IsNullOrEmpty(item.Necesario))
                {
                    resp.Resultado = false;
                    resp.Mensaje += "<li>Indique si es necesario</li>";

                }
                resp.Mensaje += "<br>";
            }
            return resp;
        }
        private Respuesta ReglasNegocioCargos(List<CargoOrganoDom> cargoxorgano)
        {

            /*No se puede presentar la situación de tener un Presidente y Coordinador dentro del órgano dirigencial.*/
            IGenericRepository<PerfilCargo> repoPerfil = new GenericRepository<PerfilCargo>(context);
            IGenericRepository<OrganoCat> repoOrgano = new GenericRepository<OrganoCat>(context);

            Respuesta resp = new Respuesta();
            resp.Resultado = true;
            var lstCargos = repoCargoXOrgano.GetPersonaOrganoCargo();

            foreach (var item in cargoxorgano)
            {
                var oPerfil = repoPerfil.GetFirstOrDefault(x => x.IdPerfilCargo == item.IdPerfilCargo).Descripcion.ToUpper();
                var oOrgano = repoOrgano.GetFirstOrDefault(x => x.IdOrgano == item.IdOrgano).Descripcion.ToUpper();

                if (oPerfil == Cargos.presidente)
                {
                    var existeCoordinador = lstCargos.Where(x => x.IdOrgano == item.IdOrgano && x.DescripcionPerfil.ToUpper() == Cargos.coordinador);
                    if (existeCoordinador.Count() > (int)Numeracion.Cero)
                    {
                        resp.Resultado = false;
                        resp.Mensaje += String.Format("<li>Ya existe el cargo de coordinador en el organo {0}, no puede agregar el cargo de presidente</li>", oOrgano);
                    }
                }

                if (oPerfil == Cargos.coordinador)
                {
                    var existPresidente = lstCargos.Where(x => x.IdOrgano == item.IdOrgano && x.DescripcionPerfil.ToUpper() == Cargos.presidente);
                    if (existPresidente.Count() > (int)Numeracion.Cero)
                    {
                        resp.Resultado = false;
                        resp.Mensaje += String.Format("<li>Ya existe el cargo de presidente en el organo {0}, no puede agregar el cargo de coordinador</li>", oOrgano);
                    }
                }
            }

            return resp;
        }
    }
}
