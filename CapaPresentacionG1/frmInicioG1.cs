using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacionG1
{
    public partial class frmInicioG1 : Form
    {
        public frmInicioG1()
        {
            InitializeComponent();
        }

        private void frmInicioG1_Load(object sender, EventArgs e)
        {
            SubAplicarEstilosG1();
        }

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
        private void btnMarcarAsistenciaG1_MouseEnter(object sender, EventArgs e)
        {
            btnMarcarAsistenciaG1.BackColor = ColorTranslator.FromHtml("#E6C65C"); // Dorado más claro
        }

        private void btnMarcarAsistenciaG1_MouseLeave(object sender, EventArgs e)
        {
            btnMarcarAsistenciaG1.BackColor = ColorTranslator.FromHtml("#D4AF37"); // Dorado original
        }

        // ==========================================
        // EVENTO CLICK DEL BOTÓN (Aquí irá la lógica después)
        // ==========================================
        private void btnMarcarAsistenciaG1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí se abrirá el formulario para marcar asistencia.", "Información");
            // Ejemplo: 
            // frmRegistroAsistenciaG1 objRegistro = new frmRegistroAsistenciaG1();
            // objRegistro.ShowDialog();
        }
    }
}