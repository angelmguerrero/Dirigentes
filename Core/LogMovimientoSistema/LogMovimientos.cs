using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Helpers;
using CPMPlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace LogMovimientoSistema
{
    public class LogMovimientos
    {
        private CPMDirigentesPlataformaContext context;
        IGenericRepository<LogGeneral> repo;
        public LogMovimientos()
        {
            this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
            repo = new GenericRepository<LogGeneral>(context);

        }
        public bool logMovimientos(string correo, string nombre, string idSubModulo, string Movimiento, string Descripcion = "", string tabla = "")
        {
            LogGeneral mov = new LogGeneral();
            try
            {
                var modul = idSubModulo.ToString().Split(',');
                mov.IdModulo = Convert.ToInt16(modul[0]);
                mov.IdSubmodulo = Convert.ToInt16(modul[1]);
                mov.TipoMovimiento = Movimiento.ToString();
                mov.Descripcion = Descripcion;
                mov.UsuarioNombre = nombre;
                mov.UsuarioCorreo = correo;
                mov.Fecha = DateTime.Now;
                mov.Tabla = tabla;

                var result = repo.Insert(mov);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(nombre, ex);
                return false;
            }


        }
    }
}
