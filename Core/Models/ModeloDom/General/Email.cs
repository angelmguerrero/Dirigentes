namespace CPM.PlataformaDirigentes.Models.ModeloDom.General
{
    public class Email
    {

        public string addListTo { get; set; }
        public string Subject { get; set; }

        public bool isBodyHTML { get; set; }

        public string Body { get; set; }

        public string? addCc { get; set; }

        public string? addCco { get; set; }

    }
}
