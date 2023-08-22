using CPMDecoderCitas;

namespace CPM.PlataformaDirigentes.Helpers
{
    public class Security
    {

        public static string deCryp(string text)
        {
            try
            {
				return EncDecCitas.Desencriptar(text);
			}
            catch(Exception)
            {
                return text;
            }
                       
        }

        public static string enCryp(string text)
        {
            return EncDecCitas.Encriptar(text);
        }

    }
}
