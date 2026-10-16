using System;
using System.Data;
using System.Windows.Forms;
using CapaLogicaNegocioG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Reporte de asistencia por periodo (dgvReporteAsistenciaG1): retrasos, horas trabajadas,
    /// horas extras, pago de extras y ausencias.
    /// </summary>
    public partial class frmReporteAsistenciaG1 : Form
    {
        private readonly AsistenciaLogicaG1 gObjAsistenciaLogicaG1 = new AsistenciaLogicaG1();

        /// <summary>Crea el formulario del reporte.</summary>
        public frmReporteAsistenciaG1()
        {
            InitializeComponent();
        }

        /// <summary>Aplica estilo y muestra el reporte de los últimos 7 días.</summary>
        private void frmReporteAsistenciaG1_Load(object sender, EventArgs e)
        {
            EstiloG1.SubAplicarFormularioG1(this);
            dtpDesdeReporteG1.Value = DateTime.Today.AddDays(-7);
            dtpHastaReporteG1.Value = DateTime.Today;
            SubGenerarReporteG1();
        }

        /// <summary>Consulta el reporte, ajusta encabezados y calcula el resumen.</summary>
        private void SubGenerarReporteG1()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable dtReporteG1 = gObjAsistenciaLogicaG1.FunReporteAsistenciaG1(dtpDesdeReporteG1.Value, dtpHastaReporteG1.Value);
                dgvReporteAsistenciaG1.DataSource = dtReporteG1;
                SubFormatearColumnaG1("Codigo", "Código", null);
                SubFormatearColumnaG1("MinutosRetardo", "Retardo (min)", null);
                SubFormatearColumnaG1("HorasTrabajadas", "Horas trab.", "N2");
                SubFormatearColumnaG1("HorasExtras", "Horas extra", "N2");
                SubFormatearColumnaG1("PagoHorasExtras", "Pago extras (Q)", "N2");

                int intTardanzasG1 = 0, intAusenciasG1 = 0;
                decimal decExtrasG1 = 0, decPagoG1 = 0;
                foreach (DataRow drFilaG1 in dtReporteG1.Rows)
                {
                    string strEstadoG1 = Convert.ToString(drFilaG1["Estado"]);
                    if (strEstadoG1 == "Tarde") intTardanzasG1++;
                    if (strEstadoG1 == "Ausente") intAusenciasG1++;
                    decExtrasG1 += drFilaG1["HorasExtras"] == DBNull.Value ? 0 : Convert.ToDecimal(drFilaG1["HorasExtras"]);
                    decPagoG1 += drFilaG1["PagoHorasExtras"] == DBNull.Value ? 0 : Convert.ToDecimal(drFilaG1["PagoHorasExtras"]);
                }
                lblResumenReporteG1.Text = "Registros: " + dtReporteG1.Rows.Count + "   |   Tardanzas: " + intTardanzasG1 +
                                           "   |   Ausencias: " + intAusenciasG1 + "   |   Horas extra: " + decExtrasG1.ToString("N2") +
                                           "   |   Pago extras: Q " + decPagoG1.ToString("N2");
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>Cambia el encabezado y el formato de una columna si existe.</summary>
        /// <param name="strColumnaG1">Nombre de la columna.</param>
        /// <param name="strEncabezadoG1">Texto del encabezado.</param>
        /// <param name="strFormatoG1">Formato numérico o null.</param>
        private void SubFormatearColumnaG1(string strColumnaG1, string strEncabezadoG1, string strFormatoG1)
        {
            if (!dgvReporteAsistenciaG1.Columns.Contains(strColumnaG1)) return;
            dgvReporteAsistenciaG1.Columns[strColumnaG1].HeaderText = strEncabezadoG1;
            if (strFormatoG1 != null) dgvReporteAsistenciaG1.Columns[strColumnaG1].DefaultCellStyle.Format = strFormatoG1;
        }

        /// <summary>Genera el reporte del rango elegido.</summary>
        private void btnGenerarReporteG1_Click(object sender, EventArgs e)
        {
            SubGenerarReporteG1();
        }

        /// <summary>Muestra solo el día de hoy.</summary>
        private void btnLimpiarReporteG1_Click(object sender, EventArgs e)
        {
            dtpDesdeReporteG1.Value = DateTime.Today;
            dtpHastaReporteG1.Value = DateTime.Today;
            SubGenerarReporteG1();
        }

        /// <summary>Abre el marcaje y refresca el reporte.</summary>
        private void btnMarcarAsistenciaReporteG1_Click(object sender, EventArgs e)
        {
            using (frmMarcajeG1 frmMarcajeVentanaG1 = new frmMarcajeG1())
            {
                frmMarcajeVentanaG1.ShowDialog(ParentForm);
            }
            SubGenerarReporteG1();
        }

        /// <summary>Colorea el estado: dorado para Tarde, rojo para Ausente, verde para Presente.</summary>
        private void dgvReporteAsistenciaG1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvReporteAsistenciaG1.Columns[e.ColumnIndex].Name != "Estado" || e.Value == null) return;
            string strEstadoG1 = e.Value.ToString();
            if (strEstadoG1 == "Tarde") e.CellStyle.ForeColor = EstiloG1.ColorDoradoG1;
            else if (strEstadoG1 == "Ausente") e.CellStyle.ForeColor = EstiloG1.ColorRojoG1;
            else if (strEstadoG1 == "Presente") e.CellStyle.ForeColor = EstiloG1.ColorVerdeG1;
        }
    }
}
