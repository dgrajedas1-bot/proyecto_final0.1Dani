using System;
using System.Drawing;
using System.IO;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Carga las imágenes de la carpeta "icon" que se copia junto al ejecutable.
    /// Si una imagen no existe, devuelve null y la aplicación sigue funcionando.
    /// </summary>
    public static class RecursosG1
    {
        /// <summary>Carga una imagen de la carpeta icon sin dejar el archivo bloqueado.</summary>
        /// <param name="strArchivoG1">Nombre del archivo (ej. icono_grupo.png).</param>
        /// <returns>La imagen o null si no se encontró.</returns>
        public static Image FunCargarImagenG1(string strArchivoG1)
        {
            try
            {
                string strRutaG1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon", strArchivoG1);
                if (!File.Exists(strRutaG1)) return null;
                using (FileStream fsArchivoG1 = new FileStream(strRutaG1, FileMode.Open, FileAccess.Read))
                using (Image imgOriginalG1 = Image.FromStream(fsArchivoG1))
                {
                    return new Bitmap(imgOriginalG1);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
