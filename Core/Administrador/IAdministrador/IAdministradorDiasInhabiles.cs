using CPM.PlataformaDirigentes.Models.ModeloDom.Catalogos.DiaInhabil;
using CPM.PlataformaDirigentes.Models.ModeloDom.General;
using CPM.PlataformaDirigentes.Models.Models;

namespace CPM.PlataformaDirigentes.Administrador.IAdministrador;
public interface IAdministradorDiasInhabiles
{
    public List<DiasInhabilesCat> Obtener();
    public Respuesta Crear(DiasInhabilesCat item);
    public Respuesta Modificar(DiasInhabilesCat item);
    public bool Desactivar(int id);
    public DiasInhabilesCat RegistrobyId(int id);
    public int GetSabado();
    public int GetDomingo();
    public bool UpdateSabado(bool estatus);
    public bool UpdateDomingo(bool estatus);

    public DiasInhabilesCat ObtenerDiainhabilPorFecha(DateTime? fecha);

    public List<DiasInhabilesCat> BuscarFechas(FiltroFechas filtro);

}


