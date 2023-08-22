namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class Permiso
    {
        public int IdPermiso { get; set; }
        public int IdPerfilCargo { get; set; }
        public int IdSubModulo { get; set; }
        public bool? Todos { get; set; }
        public bool? Crear { get; set; }
        public bool? Editar { get; set; }
        public bool? Consultar { get; set; }
        public bool? Eliminar { get; set; }
        public bool? Descargar { get; set; }
        public bool? Cargar { get; set; }
        public bool? Autorizar { get; set; }
        public bool? Historico { get; set; }
        public bool EstatusPermiso { get; set; }

    }
}
