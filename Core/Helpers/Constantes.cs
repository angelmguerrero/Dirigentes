namespace CPM.PlataformaDirigentes.Helpers
{
    public class Constantes
    {

        //Cuerpo correo. CFE
        public const string CONST_EMAIL_BODY_TEXT_DEPOSITO_ARCHIVO_CONCILIACION_CFE_OK =
           "El archivo de pagos CFE fue colocado para conciliación exitosamente.<br><br>" +
           "Fecha/Hora:  [[[fecha]]] <br> " +
           "Nombre de archivo: [[[nombrearchivo]]] <br> " +
           "Fecha de encabezado: [[[fechaencabezado]]] <br> " +
           "Número de registros: [[[registros]]] <br> " +
           "Monto total: $ [[[monto]]] <br><br>" +
           "En caso de dudas contactar a [[[telefonoCpm]]] y [[[correoCpm]]].";

        //Template
        public const string CONST_EMAIL_TEMPLATE_FORMULARIO = "/wwwroot/emailTemplateFormulario.html";
        //public const string CONST_EMAIL_TEMPLATE_FORMULARIO = "~/Content/EmailTemplates/emailTemplateFormulario.html";
    }
}
