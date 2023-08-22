namespace CPM.PlataformaDirigentes.Models.ModeloDom.Perfil
{
    public class PerfilPermisoResumen
    {

        // Perfil
        public string? DescripcionPerfil { get; set; }

        //Submodulo //

        public string? DescripcionSubmodulo { get; set; }
        public string? Submodulo { get; set; }

        //Permisos

        public string? Permiso { get; set; }
        public bool? Valor { get; set; }


    }
}
