namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class PersonalAdministrativoCat
    {
        public int IdPersonalAdministrativo { get; set; }
        public string NombreParticipanteOculto { get; set; }
        public string CorreoParticipante { get; set; }
        public bool EstatusPersonalAdministrativo { get; set; }
    }
}
