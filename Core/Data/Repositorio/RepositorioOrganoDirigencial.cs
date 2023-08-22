using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.OrganoDirigencial;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioOrganoDirigencial : IRepositorioOrganoDirigencial
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<OrganoCat> repo;
        public RepositorioOrganoDirigencial()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<OrganoCat>(context);
        }
        public List<OrganoCat> Obtener()
        {
            return context.OrganoCats.ToList();
        }

        public List<OrganoDirigencialDom> ObtenerDom()
        {
            try
            {
                var test = (from org in context.OrganoCats
                            join nivel in context.NivelGestionCats on org.IdNivelGestion equals nivel.IdNivelGestion
                            join mat in context.Materiales on org.IdMaterial equals mat.IdMaterial into gj
                            from subpet in gj.DefaultIfEmpty()

                            select new OrganoDirigencialDom
                            {
                                IdOrgano = org.IdOrgano,
                                Descripcion = org.Descripcion,
                                NivelOrgano = nivel.Descripcion,
                                AbreviaturaOrgano = org.AbreviaturaOrgano,
                                NoFirmas = org.NoFirmas,
                                Material = subpet.Descripción,
                                EstatusOrgano = org.EstatusOrgano
                            }).ToList();
                return test;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta OrganoDirigencial", ex);
                return null;
            }
        }

        public Respuesta Crear(OrganoCat item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusOrgano = true;
                if (repo.Insert(item))
                {
                    resp.Resultado = true;
                    return resp;
                }
                else
                {
                    resp.Resultado = false;
                    return resp;
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Creacion OrganoDirigencial", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public Respuesta Modificar(OrganoCat item)
        {
            Respuesta resp = new Respuesta();
            var _item = context.OrganoCats.Where(x => x.IdOrgano == item.IdOrgano).SingleOrDefault();
            if (_item == null)
            {
                resp.Resultado = false;
                resp.Mensaje = "No se encontro el registro";
                return resp;
            }
            try
            {
                _item.Descripcion = item.Descripcion;
                _item.IdNivelGestion = item.IdNivelGestion;
                _item.AbreviaturaOrgano = item.AbreviaturaOrgano;
                _item.NoFirmas = item.NoFirmas;
                _item.IdMaterial = item.IdMaterial;
                _item.EstatusOrgano = item.EstatusOrgano;
                if (repo.Update(_item))
                {
                    resp.Resultado = true;
                    return resp;
                }
                else
                {
                    resp.Resultado = false;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion OrganoDirigencial", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public bool Desactivar(int id)
        {
            var _cargo = context.OrganoCats.Where(x => x.IdOrgano == id).SingleOrDefault();
            if (_cargo == null)
                return false;
            try
            {
                _cargo.EstatusOrgano = false;
                repo.Update(_cargo);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar OrganoDirigencial", ex);
                return false;
            }
        }

        public OrganoCat RegistrobyId(int id)
        {
            var cargo = context.OrganoCats.Where(x => x.IdOrgano == id).FirstOrDefault();

            if (cargo == null)
                return null;
            else
                return cargo;

        }

        public List<SelectDom> ObtenerMateriales()
        {

            var prueba = (from clas in context.Materiales
                          select new SelectDom
                          {
                              value = clas.IdMaterial,
                              text = clas.Descripción
                          }).ToList();
            return prueba;
        }

        public List<SelectDom> ObtenerNivelGestion()
        {

            var nivel = (from clas in context.NivelGestionCats
                         select new SelectDom
                         {
                             value = clas.IdNivelGestion,
                             text = clas.Descripcion
                         }).ToList();
            return nivel;
        }

        public OrganoCat ObtenerOrganoPorDescripcion(OrganoCat organo)
        {
            //var cargo = context.OrganoCats.Where(x => x.Descripcion == descOrgano).FirstOrDefault();
            try
            {
                var cargo = (from organocat in context.OrganoCats
                             where organocat.Descripcion == organo.Descripcion && organocat.IdNivelGestion == organo.IdNivelGestion
                             select new OrganoCat
                             {
                                 IdOrgano = organocat.IdOrgano,
                                 Descripcion = organocat.Descripcion,
                                 IdNivelGestion = organocat.IdNivelGestion,
                                 AbreviaturaOrgano = organocat.AbreviaturaOrgano,
                                 NoFirmas = organocat.NoFirmas,
                                 IdMaterial = organocat.IdMaterial,
                                 EstatusOrgano = organocat.EstatusOrgano
                             }).FirstOrDefault();

                if (cargo == null)
                    return null;
                else
                    return cargo;
            }
            catch (Exception ex)
            {
                Logger.Error("Consulta OrganoDirigencial", ex);
                return null;
            }

        }



    }
}
