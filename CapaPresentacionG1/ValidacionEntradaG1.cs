using System.Windows.Forms;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Filtros de teclado (KeyPress) para que cada caja de texto solo acepte el tipo de dato correcto.
    /// </summary>
    public static class ValidacionEntradaG1
    {
        /// <summary>Permite solo dígitos (códigos, IDs, minutos).</summary>
        /// <param name="sender">Caja de texto.</param>
        /// <param name="e">Tecla presionada.</param>
        public static void SubSoloNumerosG1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        /// <summary>Permite dígitos y un solo punto decimal (salarios).</summary>
        /// <param name="sender">Caja de texto.</param>
        /// <param name="e">Tecla presionada.</param>
        public static void SubSoloDecimalG1(object sender, KeyPressEventArgs e)
        {
            TextBox txtG1 = sender as TextBox;
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && txtG1 != null && !txtG1.Text.Contains(".")) return;
            e.Handled = true;
        }

        /// <summary>Permite solo letras y espacios (nombres, apellidos).</summary>
        /// <param name="sender">Caja de texto.</param>
        /// <param name="e">Tecla presionada.</param>
        public static void SubSoloLetrasG1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }

        /// <summary>Convierte el texto a entero; devuelve 0 si no es válido.</summary>
        /// <param name="strTextoG1">Texto a convertir.</param>
        /// <returns>Número entero o 0.</returns>
        public static int FunEnteroG1(string strTextoG1)
        {
            int intValorG1;
            return int.TryParse((strTextoG1 ?? "").Trim(), out intValorG1) ? intValorG1 : 0;
        }
    }
}
