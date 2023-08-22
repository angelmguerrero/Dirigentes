using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.DiaInhabil;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using LoggerUtility.LogUtility;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Data.Repositorio;

public class RepositorioDiasInhabiles : IRepositorioDiasInhabiles
{
    private readonly CPMDirigentesPlataformaContext context;
    IGenericRepository<DiasInhabilesCat> repo;
    public RepositorioDiasInhabiles()
    {
        this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        repo = new GenericRepository<DiasInhabilesCat>(context);

    }
    public List<DiasInhabilesCat> Obtener()
    {
        return repo.Get();

    }
    public Respuesta Crear(DiasInhabilesCat item)
    {
        Respuesta resp = new Respuesta();
        try
        {
            item.EstatusDiaInhabil = true;
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
            Logger.Error("Creacion DiaInhabil", ex);
            resp.Resultado = false;
            return resp;
        }
    }

    public Respuesta Modificar(DiasInhabilesCat item)
    {
        Respuesta resp = new Respuesta();
        var _item = repo.GetFirstOrDefault(x => x.IdDiaInhabil == item.IdDiaInhabil);
        if (_item == null)
        {
            resp.Resultado = false;
            resp.Mensaje = "No se encontro el registro";
            return resp;
        }

        try
        {
            _item.Fecha = item.Fecha;
            _item.Descripcion = item.Descripcion;
            _item.EstatusDiaInhabil = item.EstatusDiaInhabil;
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
            Logger.Error("Modificacion DiaInhabil", ex);
            resp.Resultado = false;
            return resp;
        }
    }

    public bool Desactivar(int id)
    {
        var _item = repo.GetFirstOrDefault(x => x.IdDiaInhabil == id);
        if (_item == null)
            return false;
        try
        {
            _item.EstatusDiaInhabil = false;
            repo.Update(_item);
            return true;
        }
        catch (Exception ex)
        {
            Logger.Error("Error Desactivar Dias Inhabiles", ex);
            return false;
        }

    }

    public DiasInhabilesCat RegistrobyId(int id)
    {
        return repo.GetFirstOrDefault(x => x.IdDiaInhabil == id);
    }

    public DiasInhabilesCat ObtenerDiaInhabilPorFecha(DateTime? fecha)
    {
        var dia = context.DiasInhabilesCats.Where(x => x.Fecha == fecha).FirstOrDefault();

        if (dia == null)
            return null;
        else
            return dia;
    }

    public List<DiasInhabilesCat> BuscarFechas(FiltroFechas filtro)
    {
        List<DiasInhabilesCat> consulta = new List<DiasInhabilesCat>();
        try
        {
            if (filtro.FechaInicio == null && filtro.FechaFin == null)
            {
                consulta = (from dia in context.DiasInhabilesCats
                            where dia.Fecha.Value.Year == DateTime.Now.Year
                            select new DiasInhabilesCat
                            {
                                IdDiaInhabil = dia.IdDiaInhabil,
                                Descripcion = dia.Descripcion,
                                Fecha = dia.Fecha,
                                EstatusDiaInhabil = dia.EstatusDiaInhabil
                            }
                            ).ToList();
            }
            else
            {
                consulta = (from dia in context.DiasInhabilesCats
                            where dia.Fecha >= filtro.FechaInicio && dia.Fecha <= filtro.FechaFin
                            select new DiasInhabilesCat
                            {
                                IdDiaInhabil = dia.IdDiaInhabil,
                                Descripcion = dia.Descripcion,
                                Fecha = dia.Fecha,
                                EstatusDiaInhabil = dia.EstatusDiaInhabil
                            }
                               ).ToList();
            }

            return consulta;
        }
        catch (Exception ex)
        {
            Logger.Error("Error BuscarFechas Dias Inhabiles", ex);
            return null;
        }

    }


}