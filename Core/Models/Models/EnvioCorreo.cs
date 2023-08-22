namespace CPM.PlataformaDirigentes.Models.Models
{
    public partial class EnvioCorreo
    {
        public int Id { get; set; }
        public string Destinatario { get; set; } = null!;
        public string Copia { get; set; } = null!;
        public string Oculto { get; set; } = null!;
        public string Asunto { get; set; } = null!;
        public string Mensaje { get; set; } = null!;
        public DateTime FechaEnvio { get; set; }
        public bool Enviado { get; set; }
    }
}
