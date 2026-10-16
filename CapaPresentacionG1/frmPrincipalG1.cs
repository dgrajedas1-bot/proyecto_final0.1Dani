using System;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidadesG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Menú principal. Muestra cada módulo dentro de pnlContenedorG1 (una sola ventana,
    /// sin duplicados) y permite cerrar sesión para volver al login.
    /// </summary>
    public partial class frmPrincipalG1 : Form
    {
        private readonly UsuarioG1 gObjUsuarioG1;
        private Form gFrmActualG1;
        private Button gBtnActivoG1;

        /// <summary>Indica si el usuario salió con "Cerrar Sesión" (true) o cerró la ventana (false).</summary>
        public bool CerroSesionG1 { get; private set; }

        /// <summary>Constructor que usa el diseñador; equivale a no tener usuario.</summary>
        public frmPrincipalG1() : this(null)
        {
        }

        /// <summary>Crea el menú principal para el usuario autenticado.</summary>
        /// <param name="objUsuarioG1">Usuario que inició sesión.</param>
        public frmPrincipalG1(UsuarioG1 objUsuarioG1)
        {
            InitializeComponent();
            gObjUsuarioG1 = objUsuarioG1;
        }

        /// <summary>Aplica estilo, muestra el usuario y abre el inicio.</summary>
        private void frmPrincipalG1_Load(object sender, EventArgs e)
        {
            BackColor = EstiloG1.ColorFondoG1;
            pnlEncabezadoG1.BackColor = EstiloG1.ColorPanelG1;
            pnlMenuG1.BackColor = Color.FromArgb(28, 28, 28);
            pnlContenedorG1.BackColor = EstiloG1.ColorFondoG1;
            lblSistemaG1.ForeColor = EstiloG1.ColorDoradoG1;
            lblSistemaG1.Font = EstiloG1.FuenteSubtituloG1;
            lblNombreUsuarioG1.ForeColor = Color.White;
            lblNombreUsuarioG1.Font = EstiloG1.FuenteBotonG1;
            lblNombreUsuarioG1.Text = gObjUsuarioG1 != null ? gObjUsuarioG1.NombreCompletoG1 : "Sin sesión";

            foreach (Control ctlG1 in pnlMenuG1.Controls)
            {
                Button btnMenuG1 = ctlG1 as Button;
                if (btnMenuG1 == null) continue;
                btnMenuG1.FlatStyle = FlatStyle.Flat;
                btnMenuG1.FlatAppearance.BorderSize = 0;
                btnMenuG1.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
                btnMenuG1.BackColor = Color.FromArgb(28, 28, 28);
                btnMenuG1.ForeColor = EstiloG1.ColorTextoSecundarioG1;
                btnMenuG1.Font = EstiloG1.FuenteBotonG1;
                btnMenuG1.Cursor = Cursors.Hand;
            }
            btnCerrarSesionG1.ForeColor = EstiloG1.ColorRojoG1;
            SubAbrirInicioG1();
        }

        /// <summary>Abre el panel de inicio y conecta su evento para navegar al reporte.</summary>
        private void SubAbrirInicioG1()
        {
            frmInicioG1 frmInicioVentanaG1 = new frmInicioG1();
            SubAbrirFormularioG1(frmInicioVentanaG1, btnInicioG1);
        }

        /// <summary>
        /// Muestra un formulario dentro del contenedor. Si ya está abierto uno del mismo tipo,
        /// no se crea otro; el anterior se cierra para no dejar ventanas duplicadas.
        /// </summary>
        /// <param name="frmNuevoG1">Formulario a mostrar.</param>
        /// <param name="btnOrigenG1">Botón del menú que queda resaltado.</param>
        public void SubAbrirFormularioG1(Form frmNuevoG1, Button btnOrigenG1)
        {
            if (gFrmActualG1 != null && gFrmActualG1.GetType() == frmNuevoG1.GetType())
            {
                frmNuevoG1.Dispose();
                return;
            }
            try
            {
                if (gFrmActualG1 != null)
                {
                    gFrmActualG1.Close();
                    gFrmActualG1.Dispose();
                }
                gFrmActualG1 = frmNuevoG1;
                frmNuevoG1.TopLevel = false;
                frmNuevoG1.FormBorderStyle = FormBorderStyle.None;
                frmNuevoG1.Dock = DockStyle.Fill;
                pnlContenedorG1.Controls.Add(frmNuevoG1);
                frmNuevoG1.Show();
                frmNuevoG1.BringToFront();
                SubResaltarBotonG1(btnOrigenG1);
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubErrorG1("No se pudo abrir la pantalla: " + exErrorG1.Message);
            }
        }

        /// <summary>Resalta en dorado el botón del módulo abierto.</summary>
        /// <param name="btnBotonG1">Botón a resaltar.</param>
        private void SubResaltarBotonG1(Button btnBotonG1)
        {
            if (gBtnActivoG1 != null)
            {
                gBtnActivoG1.BackColor = Color.FromArgb(28, 28, 28);
                gBtnActivoG1.ForeColor = EstiloG1.ColorTextoSecundarioG1;
            }
            gBtnActivoG1 = btnBotonG1;
            if (gBtnActivoG1 != null)
            {
                gBtnActivoG1.BackColor = EstiloG1.ColorPanelG1;
                gBtnActivoG1.ForeColor = EstiloG1.ColorDoradoG1;
            }
        }

        /// <summary>Abre el panel de inicio.</summary>
        private void btnInicioG1_Click(object sender, EventArgs e) { SubAbrirInicioG1(); }

        /// <summary>Abre la gestión de empleados.</summary>
        private void btnEmpleadosG1_Click(object sender, EventArgs e) { SubAbrirFormularioG1(new frmEmpleadosG1(), btnEmpleadosG1); }

        /// <summary>Abre turnos y planificación de horarios.</summary>
        private void btnTurnosG1_Click(object sender, EventArgs e) { SubAbrirFormularioG1(new frmTurnosG1(), btnTurnosG1); }

        /// <summary>Abre la gestión de departamentos.</summary>
        private void btnDepartamentosG1_Click(object sender, EventArgs e) { SubAbrirFormularioG1(new frmDepartamentosG1(), btnDepartamentosG1); }

        /// <summary>Abre el reporte de asistencia.</summary>
        private void btnAsistenciaG1_Click(object sender, EventArgs e) { SubAbrirFormularioG1(new frmReporteAsistenciaG1(), btnAsistenciaG1); }

        /// <summary>Confirma y cierra la sesión para volver al login.</summary>
        private void btnCerrarSesionG1_Click(object sender, EventArgs e)
        {
            if (!EstiloG1.FunConfirmarG1("¿Desea cerrar sesión?")) return;
            CerroSesionG1 = true;
            Close();
        }
    }
}
