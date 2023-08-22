using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.DiaInhabil;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Data.IRepositorio;


public interface IRepositorioDiasInhabiles
{

    public List<DiasInhabilesCat> Obtener();
    public Respuesta Crear(DiasInhabilesCat genero);
    public Respuesta Modificar(DiasInhabilesCat genero);

    public bool Desactivar(int id);

    public DiasInhabilesCat RegistrobyId(int id);
    public DiasInhabilesCat ObtenerDiaInhabilPorFecha(DateTime? fecha);
    public List<DiasInhabilesCat> BuscarFechas(FiltroFechas filtro);


}


