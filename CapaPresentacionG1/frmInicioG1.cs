using System;
using System.Drawing;
using System.Windows.Forms;
using CapaLogicaNegocioG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Panel de control de inicio: tarjetas con los conteos del día, últimas asistencias,
    /// alertas de tardanza y acceso rápido al marcaje.
    /// </summary>
    public partial class frmInicioG1 : Form
    {
        private readonly AsistenciaLogicaG1 gObjAsistenciaLogicaG1 = new AsistenciaLogicaG1();

        /// <summary>Crea el panel de inicio.</summary>
        public frmInicioG1()
        {
            InitializeComponent();
        }

        /// <summary>Aplica estilos y carga los datos reales del día.</summary>
        private void frmInicioG1_Load(object sender, EventArgs e)
        {
            SubAplicarEstilosG1();
            EstiloG1.SubEstilizarGrillaG1(dgvUltimasAsistenciasG1);
            EstiloG1.SubEstilizarGrillaG1(dgvAlertasG1);
            SubCargarDatosInicioG1();
        }

        /// <summary>
        /// Carga desde la base de datos las tarjetas (total, presentes, tardanzas),
        /// el porcentaje de asistencia y las grillas de últimas asistencias y alertas.
        /// </summary>
        public void SubCargarDatosInicioG1()
        {
            try
            {
                lblTotalG1.Text = gObjAsistenciaLogicaG1.FunTotalEmpleadosG1().ToString();
                lblPresentesG1.Text = gObjAsistenciaLogicaG1.FunPresentesHoyG1().ToString();
                lblTardanzasG1.Text = gObjAsistenciaLogicaG1.FunTardanzasHoyG1().ToString();
                lblPorcentajeG1.Text = gObjAsistenciaLogicaG1.FunPorcentajeAsistenciaHoyG1() + "%";
                dgvUltimasAsistenciasG1.DataSource = gObjAsistenciaLogicaG1.FunUltimasAsistenciasG1();
                dgvAlertasG1.DataSource = gObjAsistenciaLogicaG1.FunAlertasTardanzaG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Colores y fuentes del panel de inicio (diseño original de Fray).</summary>
        private void SubAplicarEstilosG1()
        {
            // ==========================================
            // 1. FONDO GENERAL DEL FORMULARIO
            // ==========================================
            this.BackColor = Color.FromArgb(20, 20, 20);

            // ==========================================
            // 2. PANEL DE TÍTULO (Superior)
            // ==========================================
            pnlTituloG1.BackColor = Color.FromArgb(35, 35, 35);
            lblTituloPrincipalG1.ForeColor = Color.White;
            lblTituloPrincipalG1.Font = new Font("Segoe UI", 20, FontStyle.Bold);

            // ==========================================
            // 3. TARJETAS KPI (Total, Presentes, Tardanzas)
            // ==========================================
            Panel[] panelesKPI = { pnlTotalG1, pnlPresentesG1, pnlTardanzasG1 };
            foreach (Panel pnl in panelesKPI)
            {
                pnl.BackColor = Color.FromArgb(35, 35, 35);
            }

            // Labels de Título de las tarjetas
            Label[] labelsTitulo = { lblTituloTotalG1, lblTituloPresentesG1, lblTituloTardanzasG1 };
            foreach (Label lbl in labelsTitulo)
            {
                lbl.ForeColor = Color.Gainsboro;
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            }

            // Labels de Números (Valores grandes)
            lblTotalG1.ForeColor = ColorTranslator.FromHtml("#D4AF37"); // Dorado
            lblTotalG1.Font = new Font("Segoe UI", 28, FontStyle.Bold);

            lblPresentesG1.ForeColor = ColorTranslator.FromHtml("#4CAF50"); // Verde
            lblPresentesG1.Font = new Font("Segoe UI", 28, FontStyle.Bold);

            lblTardanzasG1.ForeColor = ColorTranslator.FromHtml("#F44336"); // Rojo
            lblTardanzasG1.Font = new Font("Segoe UI", 28, FontStyle.Bold);

            // ==========================================
            // 4. BOTÓN MARCAR ASISTENCIA
            // ==========================================
            btnMarcarAsistenciaG1.BackColor = ColorTranslator.FromHtml("#D4AF37");
            btnMarcarAsistenciaG1.ForeColor = Color.Black;
            btnMarcarAsistenciaG1.FlatStyle = FlatStyle.Flat;
            btnMarcarAsistenciaG1.FlatAppearance.BorderSize = 0;
            btnMarcarAsistenciaG1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnMarcarAsistenciaG1.Cursor = Cursors.Hand;

            // ==========================================
            // 5. TÍTULOS DE SECCIONES (Últimas Asistencias y Alertas)
            // ==========================================
            lblUltimasAsistenciasG1.ForeColor = ColorTranslator.FromHtml("#D4AF37");
            lblUltimasAsistenciasG1.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            lblAlertasG1.ForeColor = ColorTranslator.FromHtml("#D4AF37");
            lblAlertasG1.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // ==========================================
            // 6. PANELES DE LISTAS (Fondo oscuro)
            // ==========================================
            pnlUltimasAsistenciasG1.BackColor = Color.FromArgb(35, 35, 35);
            pnlAlertasG1.BackColor = Color.FromArgb(35, 35, 35);

            // ==========================================
            // 7. PANEL ASISTENCIA HOY (Inferior)
            // ==========================================
            pnlAsistenciaHoyG1.BackColor = Color.FromArgb(35, 35, 35);
            lblTituloAsistenciaHoyG1.ForeColor = Color.Gainsboro;
            lblTituloAsistenciaHoyG1.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            lblPorcentajeG1.ForeColor = ColorTranslator.FromHtml("#D4AF37");
            lblPorcentajeG1.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        }

        // ==========================================
        // EVENTOS DEL BOTÓN (Hover)
        // ==========================================
        /// <summary>Aclara el botón al pasar el mouse.</summary>
        private void btnMarcarAsistenciaG1_MouseEnter(object sender, EventArgs e)
        {
            btnMarcarAsistenciaG1.BackColor = ColorTranslator.FromHtml("#E6C65C"); // Dorado más claro
        }

        /// <summary>Restaura el color del botón.</summary>
        private void btnMarcarAsistenciaG1_MouseLeave(object sender, EventArgs e)
        {
            btnMarcarAsistenciaG1.BackColor = ColorTranslator.FromHtml("#D4AF37"); // Dorado original
        }

        // ==========================================
        // EVENTO CLICK DEL BOTÓN: abre el marcaje y refresca el panel
        // ==========================================
        /// <summary>Abre la ventana de marcaje (una sola a la vez) y actualiza los datos al cerrarla.</summary>
        private void btnMarcarAsistenciaG1_Click(object sender, EventArgs e)
        {
            using (frmMarcajeG1 frmMarcajeVentanaG1 = new frmMarcajeG1())
            {
                frmMarcajeVentanaG1.ShowDialog(ParentForm);
            }
            SubCargarDatosInicioG1();
        }
    }
}
