namespace CPM.PlataformaDirigentes.Models.ModeloDom.Perfil
{
    public class PerfilPermiso
    {

        // Modulo

        public int IdModulo { get; set; }
        public string? DescripcionModulo { get; set; }
        public bool? EstatusModulo { get; set; }

        //Submodulo //

        public int IdSubModulo { get; set; }
        public string? DescripcionSubmodulo { get; set; }
        public bool? EstatusSubModulo { get; set; }

        //Perfil

        public int IdPerfilCargo { get; set; }
        public string DescripcionPerfil { get; set; }
        public bool? EstatusPerfil { get; set; }
        public int? OrdenCargo { get; set; }
        public bool? EsCargo { get; set; }

        //Permiso

        public int IdPermiso { get; set; }
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
