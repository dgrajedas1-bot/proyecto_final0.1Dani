using System;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidadesG1;
using CapaLogicaNegocioG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Ventana de marcaje: el empleado ingresa su código numérico (001) y registra su ingreso o salida.
    /// La validación horaria contra SQL Express la hace AsistenciaLogicaG1.
    /// </summary>
    public partial class frmMarcajeG1 : Form
    {
        private readonly AsistenciaLogicaG1 gObjAsistenciaLogicaG1 = new AsistenciaLogicaG1();
        private readonly Timer gTmrRelojG1 = new Timer();

        /// <summary>Crea la ventana de marcaje.</summary>
        public frmMarcajeG1()
        {
            InitializeComponent();
        }

        /// <summary>Aplica estilo e inicia el reloj.</summary>
        private void frmMarcajeG1_Load(object sender, EventArgs e)
        {
            EstiloG1.SubAplicarFormularioG1(this);
            lblRelojG1.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblRelojG1.ForeColor = Color.White;
            txtCodigoEmpleadoG1.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnRegistrarIngresoG1.BackColor = EstiloG1.ColorDoradoG1;
            SubActualizarRelojG1(null, EventArgs.Empty);
            gTmrRelojG1.Interval = 1000;
            gTmrRelojG1.Tick += SubActualizarRelojG1;
            gTmrRelojG1.Start();
            txtCodigoEmpleadoG1.Focus();
        }

        /// <summary>Muestra la fecha y hora actual.</summary>
        private void SubActualizarRelojG1(object sender, EventArgs e)
        {
            lblRelojG1.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
        }

        /// <summary>Solo permite números en el código.</summary>
        private void txtCodigoEmpleadoG1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionEntradaG1.SubSoloNumerosG1(sender, e);
        }

        /// <summary>Registra el ingreso.</summary>
        private void btnRegistrarIngresoG1_Click(object sender, EventArgs e)
        {
            SubMarcarG1(true);
        }

        /// <summary>Registra la salida.</summary>
        private void btnRegistrarSalidaG1_Click(object sender, EventArgs e)
        {
            SubMarcarG1(false);
        }

        /// <summary>Llama a la lógica de marcaje y muestra el resultado con color.</summary>
        /// <param name="blnIngresoG1">True para ingreso, false para salida.</param>
        private void SubMarcarG1(bool blnIngresoG1)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoEmpleadoG1.Text))
            {
                EstiloG1.SubAdvertenciaG1("Ingrese el código del empleado (ejemplo: 001).");
                txtCodigoEmpleadoG1.Focus();
                return;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                ResultadoMarcajeG1 objResultadoG1 = blnIngresoG1
                    ? gObjAsistenciaLogicaG1.SubRegistrarIngresoG1(txtCodigoEmpleadoG1.Text)
                    : gObjAsistenciaLogicaG1.SubRegistrarSalidaG1(txtCodigoEmpleadoG1.Text);

                lblResultadoG1.Text = objResultadoG1.MensajeG1;
                if (!objResultadoG1.ExitosoG1) lblResultadoG1.ForeColor = EstiloG1.ColorRojoG1;
                else if (objResultadoG1.EstadoG1 == "Tarde" && blnIngresoG1) lblResultadoG1.ForeColor = EstiloG1.ColorDoradoG1;
                else lblResultadoG1.ForeColor = EstiloG1.ColorVerdeG1;

                if (objResultadoG1.ExitosoG1) txtCodigoEmpleadoG1.Clear();
            }
            catch (Exception exErrorG1)
            {
                lblResultadoG1.ForeColor = EstiloG1.ColorRojoG1;
                lblResultadoG1.Text = exErrorG1.Message;
                if (!(exErrorG1 is ArgumentException)) EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
            finally
            {
                Cursor = Cursors.Default;
                txtCodigoEmpleadoG1.Focus();
            }
        }

        /// <summary>Cierra la ventana.</summary>
        private void btnCerrarG1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>Detiene el reloj al cerrar.</summary>
        private void frmMarcajeG1_FormClosed(object sender, FormClosedEventArgs e)
        {
            gTmrRelojG1.Stop();
            gTmrRelojG1.Dispose();
        }
    }
}
