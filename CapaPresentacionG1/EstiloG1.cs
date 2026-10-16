using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Estilo visual común de la aplicación, tomado del formulario de inicio (frmInicioG1):
    /// fondo oscuro, paneles gris oscuro, acento dorado y fuente Segoe UI.
    /// </summary>
    public static class EstiloG1
    {
        /// <summary>Fondo general (igual que frmInicioG1).</summary>
        public static readonly Color ColorFondoG1 = Color.FromArgb(20, 20, 20);
        /// <summary>Fondo de paneles, tarjetas y grupos.</summary>
        public static readonly Color ColorPanelG1 = Color.FromArgb(35, 35, 35);
        /// <summary>Fondo de cajas de texto y listas.</summary>
        public static readonly Color ColorEntradaG1 = Color.FromArgb(45, 45, 45);
        /// <summary>Dorado principal.</summary>
        public static readonly Color ColorDoradoG1 = ColorTranslator.FromHtml("#D4AF37");
        /// <summary>Dorado claro para el efecto al pasar el mouse.</summary>
        public static readonly Color ColorDoradoClaroG1 = ColorTranslator.FromHtml("#E6C65C");
        /// <summary>Verde para estados positivos.</summary>
        public static readonly Color ColorVerdeG1 = ColorTranslator.FromHtml("#4CAF50");
        /// <summary>Rojo para alertas y eliminar.</summary>
        public static readonly Color ColorRojoG1 = ColorTranslator.FromHtml("#F44336");
        /// <summary>Texto secundario.</summary>
        public static readonly Color ColorTextoSecundarioG1 = Color.Gainsboro;

        /// <summary>Fuente de títulos principales.</summary>
        public static readonly Font FuenteTituloG1 = new Font("Segoe UI", 20, FontStyle.Bold);
        /// <summary>Fuente de subtítulos y secciones.</summary>
        public static readonly Font FuenteSubtituloG1 = new Font("Segoe UI", 12, FontStyle.Bold);
        /// <summary>Fuente de texto normal.</summary>
        public static readonly Font FuenteTextoG1 = new Font("Segoe UI", 10, FontStyle.Regular);
        /// <summary>Fuente de botones.</summary>
        public static readonly Font FuenteBotonG1 = new Font("Segoe UI", 10, FontStyle.Bold);

        /// <summary>Etiqueta (Tag) para botones secundarios: fondo oscuro con borde dorado.</summary>
        public const string TagSecundarioG1 = "secundario";
        /// <summary>Etiqueta (Tag) para botones de eliminar: fondo rojo.</summary>
        public const string TagPeligroG1 = "peligro";

        /// <summary>
        /// Aplica el estilo oscuro/dorado a un formulario y a todos sus controles.
        /// Las etiquetas cuyo nombre empieza con "lblTitulo" se pintan como título dorado.
        /// </summary>
        /// <param name="frmFormularioG1">Formulario a estilizar.</param>
        public static void SubAplicarFormularioG1(Form frmFormularioG1)
        {
            frmFormularioG1.BackColor = ColorFondoG1;
            frmFormularioG1.ForeColor = Color.White;
            frmFormularioG1.Font = FuenteTextoG1;
            SubAplicarControlesG1(frmFormularioG1.Controls);
        }

        /// <summary>Recorre recursivamente una colección de controles y les aplica el estilo.</summary>
        /// <param name="colControlesG1">Controles a estilizar.</param>
        public static void SubAplicarControlesG1(Control.ControlCollection colControlesG1)
        {
            foreach (Control ctlControlG1 in colControlesG1)
            {
                if (ctlControlG1 is Button)
                {
                    SubEstilizarBotonG1((Button)ctlControlG1);
                }
                else if (ctlControlG1 is DataGridView)
                {
                    SubEstilizarGrillaG1((DataGridView)ctlControlG1);
                }
                else if (ctlControlG1 is TextBox)
                {
                    TextBox txtG1 = (TextBox)ctlControlG1;
                    txtG1.BackColor = txtG1.ReadOnly ? ColorPanelG1 : ColorEntradaG1;
                    txtG1.ForeColor = Color.White;
                    txtG1.BorderStyle = BorderStyle.FixedSingle;
                    txtG1.Font = FuenteTextoG1;
                }
                else if (ctlControlG1 is ComboBox)
                {
                    ComboBox cmbG1 = (ComboBox)ctlControlG1;
                    cmbG1.BackColor = ColorEntradaG1;
                    cmbG1.ForeColor = Color.White;
                    cmbG1.FlatStyle = FlatStyle.Flat;
                    cmbG1.Font = FuenteTextoG1;
                }
                else if (ctlControlG1 is DateTimePicker)
                {
                    ctlControlG1.Font = FuenteTextoG1;
                }
                else if (ctlControlG1 is CheckBox)
                {
                    ctlControlG1.ForeColor = ColorTextoSecundarioG1;
                    ctlControlG1.Font = FuenteTextoG1;
                }
                else if (ctlControlG1 is GroupBox)
                {
                    ctlControlG1.BackColor = ColorPanelG1;
                    ctlControlG1.ForeColor = ColorDoradoG1;
                    ctlControlG1.Font = FuenteSubtituloG1;
                    SubAplicarControlesG1(ctlControlG1.Controls);
                }
                else if (ctlControlG1 is Label)
                {
                    if (ctlControlG1.Name.StartsWith("lblTitulo", StringComparison.Ordinal))
                    {
                        ctlControlG1.ForeColor = ColorDoradoG1;
                        ctlControlG1.Font = FuenteTituloG1;
                    }
                    else if (ctlControlG1.Name.StartsWith("lblSeccion", StringComparison.Ordinal))
                    {
                        ctlControlG1.ForeColor = ColorDoradoG1;
                        ctlControlG1.Font = FuenteSubtituloG1;
                    }
                    else
                    {
                        ctlControlG1.ForeColor = ColorTextoSecundarioG1;
                        ctlControlG1.Font = FuenteTextoG1;
                    }
                }
                else if (ctlControlG1 is Panel)
                {
                    ctlControlG1.BackColor = ColorPanelG1;
                    SubAplicarControlesG1(ctlControlG1.Controls);
                }
            }
        }

        /// <summary>
        /// Estiliza un botón: dorado con texto negro (principal), oscuro con borde dorado
        /// (Tag "secundario") o rojo (Tag "peligro"). Incluye efecto al pasar el mouse.
        /// </summary>
        /// <param name="btnBotonG1">Botón a estilizar.</param>
        public static void SubEstilizarBotonG1(Button btnBotonG1)
        {
            string strTipoG1 = btnBotonG1.Tag as string;
            Color colNormalG1;
            Color colHoverG1;
            if (strTipoG1 == TagSecundarioG1)
            {
                colNormalG1 = ColorPanelG1;
                colHoverG1 = Color.FromArgb(55, 55, 55);
                btnBotonG1.ForeColor = ColorDoradoG1;
                btnBotonG1.FlatAppearance.BorderSize = 1;
                btnBotonG1.FlatAppearance.BorderColor = ColorDoradoG1;
            }
            else if (strTipoG1 == TagPeligroG1)
            {
                colNormalG1 = ColorRojoG1;
                colHoverG1 = ColorTranslator.FromHtml("#E57373");
                btnBotonG1.ForeColor = Color.White;
                btnBotonG1.FlatAppearance.BorderSize = 0;
            }
            else
            {
                colNormalG1 = ColorDoradoG1;
                colHoverG1 = ColorDoradoClaroG1;
                btnBotonG1.ForeColor = Color.Black;
                btnBotonG1.FlatAppearance.BorderSize = 0;
            }
            btnBotonG1.BackColor = colNormalG1;
            btnBotonG1.FlatStyle = FlatStyle.Flat;
            btnBotonG1.Font = FuenteBotonG1;
            btnBotonG1.Cursor = Cursors.Hand;
            btnBotonG1.UseVisualStyleBackColor = false;
            btnBotonG1.MouseEnter += (s, e) => btnBotonG1.BackColor = colHoverG1;
            btnBotonG1.MouseLeave += (s, e) => btnBotonG1.BackColor = colNormalG1;
        }

        /// <summary>Estiliza una grilla con fondo oscuro, encabezados dorados y selección de fila completa.</summary>
        /// <param name="dgvGrillaG1">Grilla a estilizar.</param>
        public static void SubEstilizarGrillaG1(DataGridView dgvGrillaG1)
        {
            dgvGrillaG1.BackgroundColor = ColorPanelG1;
            dgvGrillaG1.BorderStyle = BorderStyle.None;
            dgvGrillaG1.GridColor = Color.FromArgb(60, 60, 60);
            dgvGrillaG1.EnableHeadersVisualStyles = false;
            dgvGrillaG1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvGrillaG1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dgvGrillaG1.ColumnHeadersDefaultCellStyle.ForeColor = ColorDoradoG1;
            dgvGrillaG1.ColumnHeadersDefaultCellStyle.Font = FuenteBotonG1;
            dgvGrillaG1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(28, 28, 28);
            dgvGrillaG1.DefaultCellStyle.BackColor = ColorPanelG1;
            dgvGrillaG1.DefaultCellStyle.ForeColor = Color.White;
            dgvGrillaG1.DefaultCellStyle.Font = FuenteTextoG1;
            dgvGrillaG1.DefaultCellStyle.SelectionBackColor = ColorDoradoG1;
            dgvGrillaG1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvGrillaG1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(42, 42, 42);
            dgvGrillaG1.RowHeadersVisible = false;
            dgvGrillaG1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrillaG1.MultiSelect = false;
            dgvGrillaG1.ReadOnly = true;
            dgvGrillaG1.AllowUserToAddRows = false;
            dgvGrillaG1.AllowUserToDeleteRows = false;
            dgvGrillaG1.AllowUserToResizeRows = false;
            dgvGrillaG1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>Muestra un mensaje de advertencia (dato inválido).</summary>
        /// <param name="strMensajeG1">Mensaje.</param>
        public static void SubAdvertenciaG1(string strMensajeG1)
        {
            MessageBox.Show(strMensajeG1, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>Muestra un mensaje de error.</summary>
        /// <param name="strMensajeG1">Mensaje.</param>
        public static void SubErrorG1(string strMensajeG1)
        {
            MessageBox.Show(strMensajeG1, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>Muestra un mensaje informativo.</summary>
        /// <param name="strMensajeG1">Mensaje.</param>
        public static void SubInformacionG1(string strMensajeG1)
        {
            MessageBox.Show(strMensajeG1, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra el mensaje adecuado según el tipo de excepción: advertencia para validaciones
        /// (ArgumentException), error para problemas de base de datos y errores inesperados.
        /// </summary>
        /// <param name="exErrorG1">Excepción capturada.</param>
        public static void SubManejarExcepcionG1(Exception exErrorG1)
        {
            if (exErrorG1 is ArgumentException) SubAdvertenciaG1(exErrorG1.Message);
            else if (exErrorG1 is InvalidOperationException) SubErrorG1(exErrorG1.Message);
            else SubErrorG1("Ocurrió un error inesperado: " + exErrorG1.Message);
        }

        /// <summary>Pregunta Sí/No al usuario.</summary>
        /// <param name="strPreguntaG1">Pregunta.</param>
        /// <returns>True si respondió Sí.</returns>
        public static bool FunConfirmarG1(string strPreguntaG1)
        {
            return MessageBox.Show(strPreguntaG1, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
