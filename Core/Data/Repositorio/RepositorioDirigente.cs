using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;

namespace CPM.PlataformaDirigentes.Data.Repositorio
{
    public class RepositorioDirigente : IRepositorioDirigente
    {
        private CPMDirigentesPlataformaContext context;
        public RepositorioDirigente()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        }

        public bool CrearDirigente(Dirigente dirigente)
        {
            try
            {
                var dirigentevalidacion = context.Dirigente.Where(x => x.IdPersona == dirigente.IdPersona).FirstOrDefault();
                if (dirigentevalidacion == null)
                {


                    dirigente.Estatus = true;
                    context.Dirigente.Add(dirigente);
                    context.SaveChanges();

                    return true;



                }
                else
                {
                    var _dirigente = context.Dirigente.Where(x => x.IdPersona == dirigente.IdPersona).SingleOrDefault();


                    _dirigente.ExpedienteDigital = dirigente.ExpedienteDigital;
                    _dirigente.Curriculum = dirigente.Curriculum;
                    _dirigente.Estatus = dirigente.Estatus;

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("CrearDirigente Dirigente", ex);
                return false;
            }

        }

        public bool DesactivarDirigente(int idDirigente)
        {
            try
            {
                var _dirigente = context.Dirigente.Where(x => x.IdDirigente == idDirigente).SingleOrDefault();
                if (_dirigente == null)
                    return false;

                _dirigente.Estatus = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("DesactivarDirigente Dirigente", ex);
                return false;
            }
        }

        public Dirigente DirigentebyId(int idDirigente)
        {
            try
            {
                var dirigente = context.Dirigente.Where(x => x.IdDirigente == idDirigente).FirstOrDefault();

                if (dirigente == null)
                    return null;
                else
                    return dirigente;
            }
            catch (Exception ex)
            {
                Logger.Error("DirigentebyId Dirigente", ex);
                return null;
            }
        }

        public bool ModificarDirigente(Dirigente dirigente)
        {
            try
            {
                var _dirigente = context.Dirigente.Where(x => x.IdPersona == dirigente.IdPersona).SingleOrDefault();
                if (_dirigente == null)
                    return false;


                _dirigente.ExpedienteDigital = dirigente.ExpedienteDigital;
                _dirigente.Curriculum = dirigente.Curriculum;
                _dirigente.Estatus = dirigente.Estatus;

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("ModificarDirigente Dirigente", ex);
                return false;
            }
        }

        public List<Dirigente> ObtenerDirigente()
        {
            try
            {
                return context.Dirigente.ToList();
            }
            catch (Exception ex)
            {
                Logger.Error("ObtenerDirigente Dirigente", ex);
                return null;
            }
        }
    }
}
