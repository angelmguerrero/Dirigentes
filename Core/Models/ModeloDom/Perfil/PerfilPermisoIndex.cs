namespace CPM.PlataformaDirigentes.Models.ModeloDom.Perfil
{
    public class PerfilPermisoIndex
    {
        // Modulo

        public int IdModulo { get; set; }

        //Perfil

        public int IdPerfilCargo { get; set; }
        public string DescripcionPerfil { get; set; }
        public bool? EstatusPerfil { get; set; }
        public int? OrdenCargo { get; set; }
        public bool? EsCargo { get; set; }

        public string Tipo { get; set; }

        // Columnas de tabla
        public string PerfilesPermisos { get; set; }
        public string Usuarios { get; set; }
        public string Catalogo { get; set; }
        public string PadronDirigentes { get; set; }
        public string Convocatorias { get; set; }
        public string LogisticaJocaps { get; set; }
        public string RequerimientosAdicionales { get; set; }
        public string IndicadoresReporteria { get; set; }
        public string Blog { get; set; }

        // Permiso

        public bool? Todos { get; set; }
        public bool? Crear { get; set; }
        public bool? Editar { get; set; }
        public bool? Consultar { get; set; }
        public bool? Eliminar { get; set; }
        public bool? Descargar { get; set; }
        public bool? Cargar { get; set; }
        public bool? Autorizar { get; set; }
        public bool? Historico { get; set; }

    }
}
