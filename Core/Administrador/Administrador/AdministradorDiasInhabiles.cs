using CPM.PlataformaDirigentes.Administrador.IAdministrador;
using CPM.PlataformaDirigentes.Data.Contexto;
using CPM.PlataformaDirigentes.Data.IRepositorio;
using CPM.PlataformaDirigentes.Data.Repositorio;
using CPM.PlataformaDirigentes.Helpers;
using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.DiaInhabil;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;
using MGenericRepository;

namespace CPM.PlataformaDirigentes.Administrador.Administrador;

public class AdministradorDiasInhabiles : IAdministradorDiasInhabiles
{
    private readonly CPMDirigentesPlataformaContext context;
    IRepositorioDiasInhabiles repo;
    IGenericRepository<DiasInhabilesCat> repoGen;
    IGenericRepository<FinSemanaInhabilCat> repoFin;

    public AdministradorDiasInhabiles()
    {
        this.repo = new RepositorioDiasInhabiles();
        this.context = new CPMDirigentesPlataformaContext(Configuracion.GetConnectionString());
        this.repoGen = new GenericRepository<DiasInhabilesCat>(context);
        this.repoFin = new GenericRepository<FinSemanaInhabilCat>(context);
    }
    public List<DiasInhabilesCat> Obtener()
    {
        return repo.Obtener();
    }

    public Respuesta Crear(DiasInhabilesCat genero)
    {
        Respuesta resp = new Respuesta();
        DiasInhabilesCat dia = ObtenerDiainhabilPorFecha(genero.Fecha);
        if (dia == null)
        {
            return repo.Crear(genero);
        }
        else
        {
            resp.Resultado = false;
            resp.Mensaje = "Ya existe un dia inhabil con la misma fecha.";
            return resp;
        }

    }
    public Respuesta Modificar(DiasInhabilesCat item)
    {
        Respuesta resp = new Respuesta();
        DiasInhabilesCat dia = ObtenerDiainhabilPorFecha(item.Fecha);
        if (dia == null || dia.IdDiaInhabil == item.IdDiaInhabil)
        {
            return repo.Modificar(item);
        }
        else
        {
            resp.Resultado = false;
            resp.Mensaje = "Ya existe un dia inhabil con la misma fecha.";
            return resp;
        }

    }

    public bool Desactivar(int id)
    {
        return repo.Desactivar(id);
    }

    public DiasInhabilesCat RegistrobyId(int id)
    {
        return repo.RegistrobyId(id);
    }

    public int GetSabado()
    {
        var sabado = repoFin.GetFirstOrDefault(x => x.Dia == "Sabado");
        return Convert.ToInt16(sabado.Estatus);
    }

    public int GetDomingo()
    {
        var domingo = repoFin.GetFirstOrDefault(x => x.Dia == "Domingo");
        return Convert.ToInt16(domingo.Estatus);
    }

    public bool UpdateSabado(bool estatus)
    {
        var sabado = repoFin.GetFirstOrDefault(x => x.Dia == "Sabado");
        sabado.Estatus = estatus;
        return repoFin.Update(sabado);

    }

    public bool UpdateDomingo(bool estatus)
    {
        var domingo = repoFin.GetFirstOrDefault(x => x.Dia == "Domingo");
        domingo.Estatus = estatus;
        return repoFin.Update(domingo);
    }

    public DiasInhabilesCat ObtenerDiainhabilPorFecha(DateTime? fecha)
    {
        return repo.ObtenerDiaInhabilPorFecha(fecha);
    }

    public List<DiasInhabilesCat> BuscarFechas(FiltroFechas filtro)
    {
        return repo.BuscarFechas(filtro);
    }
}
