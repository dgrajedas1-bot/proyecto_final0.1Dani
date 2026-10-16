using System;
using System.Windows.Forms;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Punto de entrada de la aplicación.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Inicia la aplicación en el formulario de inicio de sesión y captura errores no controlados.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (s, e) =>
                MessageBox.Show("Ocurrió un error inesperado: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Run(new frmLoginG1());
        }
    }
}
