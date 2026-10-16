using System;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidadesG1;
using CapaLogicaNegocioG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Formulario de inicio de sesión. Valida al usuario y abre el menú principal;
    /// al cerrar sesión vuelve a mostrarse.
    /// </summary>
    public partial class frmLoginG1 : Form
    {
        private readonly UsuarioLogicaG1 gObjUsuarioLogicaG1 = new UsuarioLogicaG1();

        /// <summary>Crea el formulario de inicio de sesión.</summary>
        public frmLoginG1()
        {
            InitializeComponent();
        }

        /// <summary>Aplica el estilo y carga las imágenes.</summary>
        private void frmLoginG1_Load(object sender, EventArgs e)
        {
            EstiloG1.SubAplicarFormularioG1(this);
            lblTituloG1.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblUsuarioG1.ForeColor = EstiloG1.ColorDoradoG1;
            lblContrasenaG1.ForeColor = EstiloG1.ColorDoradoG1;
            lblUsuarioG1.Font = EstiloG1.FuenteSubtituloG1;
            lblContrasenaG1.Font = EstiloG1.FuenteSubtituloG1;
            btnIniciarSesionG1.Font = EstiloG1.FuenteSubtituloG1;
            picLogoG1.Image = RecursosG1.FunCargarImagenG1("icono_grupo.png");
            picUsuarioG1.Image = RecursosG1.FunCargarImagenG1("icon_usuario.png");
            picContrasenaG1.Image = RecursosG1.FunCargarImagenG1("icon_contrasena.png");
        }

        /// <summary>Valida credenciales y abre el menú principal.</summary>
        private void btnIniciarSesionG1_Click(object sender, EventArgs e)
        {
            UsuarioG1 objUsuarioG1;
            try
            {
                Cursor = Cursors.WaitCursor;
                objUsuarioG1 = gObjUsuarioLogicaG1.FunIniciarSesionG1(txtUsuarioG1.Text, txtContrasenaG1.Text);
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
                txtContrasenaG1.Clear();
                txtContrasenaG1.Focus();
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            SesionG1.UsuarioActualG1 = objUsuarioG1;
            Hide();
            bool blnCerroSesionG1;
            using (frmPrincipalG1 frmPrincipalVentanaG1 = new frmPrincipalG1(objUsuarioG1))
            {
                frmPrincipalVentanaG1.ShowDialog();
                blnCerroSesionG1 = frmPrincipalVentanaG1.CerroSesionG1;
            }
            SesionG1.UsuarioActualG1 = null;

            if (blnCerroSesionG1)
            {
                txtContrasenaG1.Clear();
                Show();
                txtUsuarioG1.Focus();
            }
            else
            {
                Close();
            }
        }

        /// <summary>Cierra la aplicación.</summary>
        private void btnSalirG1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
