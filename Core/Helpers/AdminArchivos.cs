namespace CPM.PlataformaDirigentes.Helpers
{
    public class AdminArchivos
    {

        public static string CargarArchivo(byte[] data, string nombre, string tipo, string extension)
        {
            // Checking no of files injected in Request object  
            string fname = string.Empty;

            //Obtener ruta VNX
            string ruta = Configuracion.GetRutaVNX();
            string carpetavnx = Configuracion.GetCarpetaVNX();
            string rutaCombinada = System.IO.Path.Combine(ruta, carpetavnx, "");

            // SE REEMPLAZAN ACENTOS, FJCG 070220
            nombre = nombre.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");
            nombre = nombre.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");

            rutaCombinada = rutaCombinada.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");
            rutaCombinada = rutaCombinada.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");

            try
            {
                if (!Directory.Exists(rutaCombinada))
                { Directory.CreateDirectory(rutaCombinada); }


                //string extension = ConfigurationManager.AppSettings["ExtencionPDF"];
                //var extension = System.IO.Path.GetExtension(Request.Files[0].FileName);

                string fileNameCompete = String.Format("{0}{1}", nombre, extension);
                //string fileNameCompete = System.IO.Path.GetFileName(Request.Files[0].FileName);
                fname = System.IO.Path.Combine(rutaCombinada, fileNameCompete);

                if (tipo == "D")
                {
                    if (File.Exists(fname))
                    {
                        File.Delete(fname);
                    }


                    using (FileStream fs = System.IO.File.Create(fname))
                    {
                        //  using (Stream fi = File.OpenWrite(fname))
                        //  {
                        fs.Write(data, 0, data.Length);
                        //  }


                    }
                }



                // Returns message that successfully uploaded  
                return fname;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public static byte[] Download(string carpeta, string nombre, string tipo, string extension)
        {
            // SE REEMPLAZAN ACENTOS, FJCG 070220
            nombre = nombre.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");
            nombre = nombre.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");

            carpeta = carpeta.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");
            carpeta = carpeta.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");

            try
            {

                string ruta = Configuracion.GetRutaVNX();
                string carpetavnx = Configuracion.GetCarpetaVNX();

                string filePath = string.Empty;
                // string fileName;
                nombre = nombre + extension;
                if (carpeta == "" && tipo == "C")
                    filePath = System.IO.Path.Combine(ruta, carpetavnx, carpeta, nombre);
                if (carpeta == "" && tipo == "D")
                    filePath = System.IO.Path.Combine(ruta, carpetavnx, carpeta);
                if (carpeta != "" && tipo == "D")
                    filePath = System.IO.Path.Combine(ruta, carpeta);
                if (carpeta != "" && tipo == "C")
                    filePath = System.IO.Path.Combine(ruta, carpeta, nombre);
                filePath = filePath.Replace("//", "\\");
                string fullName = Path.Combine(filePath, nombre);

                //jpeg jpg jpe

                var validaExistencia = System.IO.File.Exists(fullName);

                if (validaExistencia)
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(fullName);
                    return fileBytes; //File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, nombre);
                }
                else
                {
                    return null; //new FileStreamResult(ReporteViewerObj.obtenerArchivoNormal(fullName), "text/html");
                }

                //return new FileStreamResult(ReporteViewerObj.obtenerArchivoNormal(fullName),contentType);

            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }

        }
    }
}
