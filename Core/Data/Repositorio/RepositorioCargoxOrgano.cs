using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.CargoXOrgano;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using CPMPlataformaDirigentes.Data.Contexto;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioCargoxOrgano : IRepositorioCargoXOrgano
    {
        private CPMDirigentesPlataformaContext context;
        private CPMDirectorioSucursalesContext contextdirectorio;

        IGenericRepository<CargoxOrgano> repo;

        public RepositorioCargoxOrgano()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            this.contextdirectorio = new CPMDirectorioSucursalesContext(Configuracion.GetConnectionConsultaCpmDirectorioString());

            repo = new GenericRepository<CargoxOrgano>(context);

        }

        public List<CargoOrganoDescDom> Obtener()
        {
            try
            {
                var lstPlazas = (from plaza in contextdirectorio.PlazaWrks select plaza).ToList();

                var lstcargos = (from cargo in context.CargoxOrganos
                                 join persona in context.PersonaCats on cargo.IdPersona equals persona.IdPersona

                                 join organo in context.OrganoCats on cargo.IdOrgano equals organo.IdOrgano into org
                                 from sorgano in org.DefaultIfEmpty()


                                 join nivel in context.NivelGestionCats on cargo.IdNivelGestion equals nivel.IdNivelGestion into lev
                                 from snivel in lev.DefaultIfEmpty()

                                 join perfil in context.PerfilCargos on cargo.IdPerfilCargo equals perfil.IdPerfilCargo into per
                                 from sperfil in per.DefaultIfEmpty()

                                     //join plaza in lstPlazas on cargo.IdPlaza equals plaza.IdPlaza into plz
                                     //from splaza in plz.DefaultIfEmpty()


                                 select new CargoOrganoDescDom
                                 {
                                     IdCargoOrgano = cargo.IdCargoOrgano,
                                     Persona = persona.NombrePersona + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno,
                                     Organo = sorgano.Descripcion,
                                     Cargo = sperfil.Descripcion,
                                     Suplente = cargo.Suplente,
                                     Firmante = cargo.Firmante,
                                     FechaNombramiento = cargo.FechaNombramiento,
                                     FechaActaDesignacion = cargo.FechaActaDesignacion,
                                     FechaInicial = cargo.FechaInicial,
                                     FechaFinal = cargo.FechaFinal,
                                     FechaIngresoSocio = cargo.FechaIngresoSocio,
                                     Necesario = cargo.Necesario,
                                     Plaza = cargo.IdPlaza.ToString(),
                                     NivelGestion = snivel.Descripcion,
                                     EstatusCargoOrgano = cargo.EstatusCargoOrgano,
                                     OrdenCargo = sperfil.OrdenCargo == null ? 0 : sperfil.OrdenCargo,
                                     RFC = persona.Rfc
                                 }).OrderBy(x => x.Organo).ThenBy(x => x.OrdenCargo).ToList();


                foreach (var item in lstcargos)
                {
                    if (item.Plaza != null)
                    {
                        item.Plaza = lstPlazas.Where(x => x.IdPlaza.ToString() == item.Plaza).Single().Nombre;
                    }
                }
                return lstcargos;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta Cargoxorgano", ex);
                return null;
            }


        }
        public Respuesta Crear(List<CargoOrganoDom> cargoxorgano)
        {
            Respuesta resp = new Respuesta();
            resp.Resultado = false;
            List<string> lstId = new List<string>();

            List<bool> list = new List<bool>();

            try
            {
                foreach (CargoOrganoDom cargo in cargoxorgano)
                {
                    CargoxOrgano oCargo = new CargoxOrgano();
                    oCargo.IdPersona = cargo.IdPersona;
                    oCargo.IdOrgano = cargo.IdOrgano;
                    oCargo.IdPerfilCargo = cargo.IdPerfilCargo;
                    oCargo.Suplente = cargo.Suplente;
                    oCargo.Firmante = cargo.Firmante;
                    oCargo.FechaNombramiento = cargo.FechaNombramiento == "" ? null : Convert.ToDateTime(cargo.FechaNombramiento);
                    oCargo.FechaActaDesignacion = cargo.FechaActaDesignacion == "" ? null : Convert.ToDateTime(cargo.FechaActaDesignacion);
                    oCargo.FechaInicial = cargo.FechaInicial == "" ? null : Convert.ToDateTime(cargo.FechaInicial);
                    oCargo.FechaFinal = cargo.FechaFinal == "" ? null : Convert.ToDateTime(cargo.FechaFinal);
                    oCargo.FechaIngresoSocio = cargo.FechaIngresoSocio == "" ? null : Convert.ToDateTime(cargo.FechaIngresoSocio);
                    oCargo.Necesario = cargo.Necesario;
                    oCargo.IdPlaza = cargo.IdPlaza == 0 ? null : cargo.IdPlaza;
                    oCargo.IdNivelGestion = cargo.IdNivelGestion;
                    oCargo.EstatusCargoOrgano = true;
                    list.Add(repo.Insert(oCargo));
                    lstId.Add(oCargo.IdCargoOrgano.ToString());
                }

                var res = list.Contains(false);

                if (!res)
                {
                    resp.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Crear Cargo x Organo", ex);

                foreach (var item in lstId)
                {
                    var deleteitem = repo.GetFirstOrDefault(x => x.IdCargoOrgano.ToString() == item);
                    repo.Delete(deleteitem);
                }
                resp.Mensaje = "No se crearon los cargos ocurrio un error";
            }

            return resp;
        }
        public Respuesta Modificar(CargoOrganoDom cargoxorgano)
        {
            Respuesta resp = new Respuesta();

            try
            {
                var _cargoxorgano = context.CargoxOrganos.Where(x => x.IdCargoOrgano == cargoxorgano.IdCargoOrgano).SingleOrDefault();
                if (_cargoxorgano == null)
                {
                    resp.Resultado = false;
                    resp.Mensaje = "<li>No se encontro el cargo </li>";
                }

                _cargoxorgano.IdPersona = cargoxorgano.IdPersona;
                _cargoxorgano.IdOrgano = cargoxorgano.IdOrgano;
                _cargoxorgano.IdPerfilCargo = cargoxorgano.IdPerfilCargo;
                _cargoxorgano.IdPlaza = cargoxorgano.IdPlaza;
                _cargoxorgano.IdNivelGestion = cargoxorgano.IdNivelGestion;
                _cargoxorgano.Suplente = cargoxorgano.Suplente;
                _cargoxorgano.Firmante = cargoxorgano.Firmante;
                _cargoxorgano.Necesario = cargoxorgano.Necesario;
                _cargoxorgano.FechaNombramiento = cargoxorgano.FechaNombramiento == "" ? null : Convert.ToDateTime(cargoxorgano.FechaNombramiento);
                _cargoxorgano.FechaActaDesignacion = cargoxorgano.FechaActaDesignacion == "" ? null : Convert.ToDateTime(cargoxorgano.FechaActaDesignacion);
                _cargoxorgano.FechaInicial = cargoxorgano.FechaInicial == "" ? null : Convert.ToDateTime(cargoxorgano.FechaInicial);
                _cargoxorgano.FechaFinal = cargoxorgano.FechaFinal == "" ? null : Convert.ToDateTime(cargoxorgano.FechaFinal);
                _cargoxorgano.FechaIngresoSocio = cargoxorgano.FechaIngresoSocio == "" ? null : Convert.ToDateTime(cargoxorgano.FechaIngresoSocio);
                _cargoxorgano.EstatusCargoOrgano = cargoxorgano.EstatusCargoOrgano;

                resp.Resultado = repo.Update(_cargoxorgano);
            }
            catch (Exception ex)
            {
                Logger.Error("Modificar Cargo x Organo", ex);
                resp.Mensaje = "Error al modificar el cargo x organo";
                resp.Resultado = false;
            }


            return resp;
        }
        public bool Desactivar(int id)
        {
            try
            {
                var _cargoxorgano = context.CargoxOrganos.Where(x => x.IdCargoOrgano == id).FirstOrDefault();
                if (_cargoxorgano == null)
                    return false;

                _cargoxorgano.EstatusCargoOrgano = false;
                return repo.Update(_cargoxorgano);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivaa Cargo x Organo", ex);
                return false;

            }


        }
        public CargoOrganoDom RegistrobyId(int id)
        {

            return (from org in context.CargoxOrganos
                    where org.IdCargoOrgano == id
                    select new CargoOrganoDom
                    {
                        IdCargoOrgano = org.IdCargoOrgano,
                        IdPersona = org.IdPersona,
                        IdOrgano = org.IdOrgano,
                        IdPerfilCargo = org.IdPerfilCargo,
                        IdPlaza = (Int32)org.IdPlaza,
                        IdNivelGestion = org.IdNivelGestion,
                        Suplente = org.Suplente,
                        Firmante = org.Firmante,
                        Necesario = org.Necesario,
                        FechaNombramiento = org.FechaNombramiento.ToString() ?? "",
                        FechaActaDesignacion = org.FechaActaDesignacion.ToString() ?? "",
                        FechaInicial = org.FechaInicial.ToString() ?? "",
                        FechaFinal = org.FechaFinal.ToString() ?? "",
                        FechaIngresoSocio = org.FechaIngresoSocio.ToString() ?? "",
                        EstatusCargoOrgano = org.EstatusCargoOrgano
                    }).SingleOrDefault();

        }

        public List<PersonaOrganoCargo> GetPersonaOrganoCargo()
        {
            return (from cargo in context.CargoxOrganos

                    join perfil in context.PerfilCargos on cargo.IdPerfilCargo equals perfil.IdPerfilCargo into per
                    from sperfil in per.DefaultIfEmpty()

                    where sperfil.EsCargo == true && sperfil.EstatusPerfil == true
                    && cargo.IdOrgano != 0
                    && (sperfil.Descripcion == "Presidente" || sperfil.Descripcion == "Coordinador")

                    select new PersonaOrganoCargo
                    {
                        IdPersona = cargo.IdPersona,
                        IdOrgano = cargo.IdOrgano,
                        IdCargo = cargo.IdPerfilCargo,
                        DescripcionPerfil = sperfil.Descripcion

                    }).ToList();

        }

    }
}
