using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioNivelDirigencial : IRepositorioNivelDirigencial
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<NivelDirigencial> repo;

        public RepositorioNivelDirigencial()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<NivelDirigencial>(context);

        }

        public List<NivelDirigencial> Obtener()
        {
            return context.NivelDirigencials.ToList();
        }

        public List<NivelDirigencial> ObtenerActivas()
        {
            return context.NivelDirigencials.Where(x => x.EstatusNivelDirigencial == true).ToList();
        }
        public Respuesta Crear(NivelDirigencial item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                item.EstatusNivelDirigencial = true;
                context.NivelDirigencials.Add(item);
                context.SaveChanges();
                resp.Resultado = true;
                return resp;

            }
            catch (Exception ex)
            {
                Logger.Error("Crear NivelDirigencial", ex);
                resp.Resultado = false;
                return resp;
            }
        }

        public bool Desactivar(int id)
        {

            try
            {
                var _item = context.NivelDirigencials.Where(x => x.IdNivelDirigencial == id).SingleOrDefault();
                if (_item == null)
                    return false;
                _item.EstatusNivelDirigencial = false;
                return repo.Update(_item);
            }
            catch (Exception ex)
            {
                Logger.Error("Desactivar NivelDirigencial", ex);
                return false;
            }
        }

        public Respuesta Modificar(NivelDirigencial item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                var _item = context.NivelDirigencials.Where(x => x.IdNivelDirigencial == item.IdNivelDirigencial).SingleOrDefault();
                if (_item == null)
                {
                    resp.Resultado = false;
                    resp.Mensaje = "No se encontro el registro";
                    return resp;
                }


                _item.IdNivelDirigencialCat = item.IdNivelDirigencialCat;
                _item.FechaIngreso = item.FechaIngreso;
                _item.FinPeriodo = item.FinPeriodo;
                _item.Periodo = item.Periodo;
                _item.Aperiodo = item.Aperiodo;
                _item.IdCondicionIngreso = item.IdCondicionIngreso;
                resp.Resultado = repo.Update(_item);

                return resp;
            }
            catch (Exception ex)
            {
                Logger.Error("Modificacion NivelDirigencial", ex);
                resp.Resultado = false;
                return resp;
            }
        }
        public Respuesta CrearOModificar(NivelDirigencial item)
        {
            Respuesta resp = new Respuesta();
            try
            {
                var _item = context.NivelDirigencials.Where(x => x.IdNivelDirigencial == item.IdNivelDirigencial).SingleOrDefault();
                if (_item == null)
                {
                    resp.Resultado = false;
                    resp.Mensaje = "No se encontro el registro";
                    return resp;
                }
                if (item.IdNivelDirigencialCat == _item.IdNivelDirigencialCat)
                {
                    _item.IdNivelDirigencialCat = item.IdNivelDirigencialCat;
                    _item.FechaIngreso = item.FechaIngreso;
                    _item.FinPeriodo = item.FinPeriodo;
                    _item.Periodo = item.Periodo;
                    _item.Aperiodo = item.Aperiodo;
                    _item.IdCondicionIngreso = item.IdCondicionIngreso;
                    resp.Resultado = repo.Update(_item);

                    return resp;
                }
                else
                {

                    try
                    {

                        var _niveldirigencial = new NivelDirigencial();

                        _niveldirigencial.IdNivelDirigencialCat = item.IdNivelDirigencialCat;
                        _niveldirigencial.IdPersona = item.IdPersona;
                        _niveldirigencial.EstatusNivelDirigencial = true;
                        _niveldirigencial.FechaIngreso = item.FechaIngreso;
                        _niveldirigencial.FinPeriodo = item.FinPeriodo;
                        _niveldirigencial.Periodo = item.Periodo;
                        _niveldirigencial.Aperiodo = item.Aperiodo;
                        _niveldirigencial.IdCondicionIngreso = item.IdCondicionIngreso;
                        context.NivelDirigencials.Add(_niveldirigencial);
                        context.SaveChanges();

                        resp.Resultado = true;
                        return resp;

                    }
                    catch (Exception ex)
                    {
                        resp.Resultado = false;
                        return resp;
                    }

                }


            }
            catch (Exception ex)
            {
                Logger.Error("CrearOModificar NivelDirigencial", ex);
                return null;
            }

        }


        public NivelDirigencial RegistrobyId(int id)
        {
            try
            {
                var item = context.NivelDirigencials.Where(x => x.IdNivelDirigencial == id).FirstOrDefault();

                if (item == null)
                    return null;
                else
                    return item;
            }
            catch (Exception ex)
            {
                Logger.Error("RegistrobyId NivelDirigencial", ex);
                return null;
            }

        }
        public NivelDirigencial RegistrobyIdPersona(int idPersona)
        {
            try
            {
                var item = context.NivelDirigencials.Where(x => x.IdPersona == idPersona).OrderByDescending(x => x.IdNivelDirigencial).FirstOrDefault();
                //(x=> x.IdNivelDirigencial).FirstOrDefault


                if (item == null)
                    return null;
                else
                    return item;
            }
            catch (Exception ex)
            {
                Logger.Error("RegistrobyIdPersona NivelDirigencial", ex);
                return null;
            }

        }
    }
}
