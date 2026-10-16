using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using CapaAccesoDatosG1;

namespace CapaPresentacionG1
{
    public partial class frmDepartamentosG1 : Form
    {
        // Declaración de controles
        private TextBox txtIdDeptoG1;
        private TextBox txtNombreDeptoG1;
        private TextBox txtIdEliminarG1;
        private TextBox txtNombreEliminarG1;
        private DataGridView dgvDepartamentosG1;
        private Button btnGuardarDeptoG1;
        private Button btnLimpiarDeptoG1;
        private Button btnBuscarDeptoG1;
        private Button btnEliminarDeptoG1;
        private Button btnLimpiarEliminarG1;

        public frmDepartamentosG1()
        {
            InitializeComponent();
            SubDisenarDepartamentosG1();
            SubCargarDepartamentosG1();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Name = "frmDepartamentosG1";
            this.ResumeLayout(false);
        }

        private void SubDisenarDepartamentosG1()
        {
            // Colores
            Color colorFondo = ColorTranslator.FromHtml("#cbddd1");
            Color colorCuadros = ColorTranslator.FromHtml("#f6f6e9");
            Color colorBotones = ColorTranslator.FromHtml("#457d58");
            Color colorTexto = ColorTranslator.FromHtml("#1f5014");
            Font fuenteTitulo = new Font("Nunito", 16, FontStyle.Bold);
            Font fuenteSubtitulo = new Font("Nunito", 12, FontStyle.Bold);
            Font fuenteTexto = new Font("Nunito", 10, FontStyle.Regular);

            // Formulario
            this.Text = "Gestión de Departamentos";
            this.Size = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = colorFondo;

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Gestión de Departamentos";
            lblTitulo.Font = fuenteTitulo;
            lblTitulo.ForeColor = colorTexto;
            lblTitulo.Location = new Point(300, 20);
            lblTitulo.Size = new Size(300, 40);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            // SECCIÓN NUEVO DEPARTAMENTO
            GroupBox gpbNuevo = new GroupBox();
            gpbNuevo.Text = "Nuevo Departamento";
            gpbNuevo.Font = fuenteSubtitulo;
            gpbNuevo.ForeColor = colorTexto;
            gpbNuevo.BackColor = colorCuadros;
            gpbNuevo.Location = new Point(50, 80);
            gpbNuevo.Size = new Size(800, 150);
            this.Controls.Add(gpbNuevo);

            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Font = fuenteTexto;
            lblId.ForeColor = colorTexto;
            lblId.Location = new Point(30, 40);
            lblId.Size = new Size(40, 20);
            gpbNuevo.Controls.Add(lblId);

            txtIdDeptoG1 = new TextBox();
            txtIdDeptoG1.Name = "txtIdDeptoG1";
            txtIdDeptoG1.Location = new Point(70, 40);
            txtIdDeptoG1.Size = new Size(100, 25);
            txtIdDeptoG1.ReadOnly = true;
            gpbNuevo.Controls.Add(txtIdDeptoG1);

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Font = fuenteTexto;
            lblNombre.ForeColor = colorTexto;
            lblNombre.Location = new Point(30, 80);
            lblNombre.Size = new Size(60, 20);
            gpbNuevo.Controls.Add(lblNombre);

            txtNombreDeptoG1 = new TextBox();
            txtNombreDeptoG1.Name = "txtNombreDeptoG1";
            txtNombreDeptoG1.Location = new Point(100, 80);
            txtNombreDeptoG1.Size = new Size(250, 25);
            gpbNuevo.Controls.Add(txtNombreDeptoG1);

            btnGuardarDeptoG1 = new Button();
            btnGuardarDeptoG1.Name = "btnGuardarDeptoG1";
            btnGuardarDeptoG1.Text = "Guardar";
            btnGuardarDeptoG1.Font = fuenteTexto;
            btnGuardarDeptoG1.BackColor = colorBotones;
            btnGuardarDeptoG1.ForeColor = Color.White;
            btnGuardarDeptoG1.FlatStyle = FlatStyle.Flat;
            btnGuardarDeptoG1.Location = new Point(400, 40);
            btnGuardarDeptoG1.Size = new Size(120, 35);
            btnGuardarDeptoG1.Click += new EventHandler(btnGuardarDeptoG1_Click);
            gpbNuevo.Controls.Add(btnGuardarDeptoG1);

            btnLimpiarDeptoG1 = new Button();
            btnLimpiarDeptoG1.Name = "btnLimpiarDeptoG1";
            btnLimpiarDeptoG1.Text = "Limpiar";
            btnLimpiarDeptoG1.Font = fuenteTexto;
            btnLimpiarDeptoG1.BackColor = colorBotones;
            btnLimpiarDeptoG1.ForeColor = Color.White;
            btnLimpiarDeptoG1.FlatStyle = FlatStyle.Flat;
            btnLimpiarDeptoG1.Location = new Point(400, 85);
            btnLimpiarDeptoG1.Size = new Size(120, 35);
            btnLimpiarDeptoG1.Click += new EventHandler(btnLimpiarDeptoG1_Click);
            gpbNuevo.Controls.Add(btnLimpiarDeptoG1);

            // SECCIÓN LISTA DE DEPARTAMENTOS
            Label lblLista = new Label();
            lblLista.Text = "Lista de Departamentos";
            lblLista.Font = fuenteSubtitulo;
            lblLista.ForeColor = colorTexto;
            lblLista.Location = new Point(50, 250);
            lblLista.Size = new Size(250, 25);
            this.Controls.Add(lblLista);

            dgvDepartamentosG1 = new DataGridView();
            dgvDepartamentosG1.Name = "dgvDepartamentosG1";
            dgvDepartamentosG1.Location = new Point(50, 280);
            dgvDepartamentosG1.Size = new Size(800, 150);
            dgvDepartamentosG1.BackgroundColor = Color.White;
            dgvDepartamentosG1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDepartamentosG1.ReadOnly = true;
            dgvDepartamentosG1.AllowUserToAddRows = false;
            this.Controls.Add(dgvDepartamentosG1);

            // SECCIÓN ELIMINAR DEPARTAMENTO
            GroupBox gpbEliminar = new GroupBox();
            gpbEliminar.Text = "Eliminar Departamento";
            gpbEliminar.Font = fuenteSubtitulo;
            gpbEliminar.ForeColor = colorTexto;
            gpbEliminar.BackColor = colorCuadros;
            gpbEliminar.Location = new Point(50, 450);
            gpbEliminar.Size = new Size(800, 150);
            this.Controls.Add(gpbEliminar);

            Label lblIdEliminar = new Label();
            lblIdEliminar.Text = "ID:";
            lblIdEliminar.Font = fuenteTexto;
            lblIdEliminar.ForeColor = colorTexto;
            lblIdEliminar.Location = new Point(30, 40);
            lblIdEliminar.Size = new Size(40, 20);
            gpbEliminar.Controls.Add(lblIdEliminar);

            txtIdEliminarG1 = new TextBox();
            txtIdEliminarG1.Name = "txtIdEliminarG1";
            txtIdEliminarG1.Location = new Point(70, 40);
            txtIdEliminarG1.Size = new Size(100, 25);
            gpbEliminar.Controls.Add(txtIdEliminarG1);

            Label lblNombreEliminar = new Label();
            lblNombreEliminar.Text = "Nombre:";
            lblNombreEliminar.Font = fuenteTexto;
            lblNombreEliminar.ForeColor = colorTexto;
            lblNombreEliminar.Location = new Point(30, 80);
            lblNombreEliminar.Size = new Size(60, 20);
            gpbEliminar.Controls.Add(lblNombreEliminar);

            txtNombreEliminarG1 = new TextBox();
            txtNombreEliminarG1.Name = "txtNombreEliminarG1";
            txtNombreEliminarG1.Location = new Point(100, 80);
            txtNombreEliminarG1.Size = new Size(250, 25);
            txtNombreEliminarG1.ReadOnly = true;
            gpbEliminar.Controls.Add(txtNombreEliminarG1);

            btnBuscarDeptoG1 = new Button();
            btnBuscarDeptoG1.Name = "btnBuscarDeptoG1";
            btnBuscarDeptoG1.Text = "Buscar";
            btnBuscarDeptoG1.Font = fuenteTexto;
            btnBuscarDeptoG1.BackColor = colorBotones;
            btnBuscarDeptoG1.ForeColor = Color.White;
            btnBuscarDeptoG1.FlatStyle = FlatStyle.Flat;
            btnBuscarDeptoG1.Location = new Point(400, 35);
            btnBuscarDeptoG1.Size = new Size(120, 35);
            btnBuscarDeptoG1.Click += new EventHandler(btnBuscarDeptoG1_Click);
            gpbEliminar.Controls.Add(btnBuscarDeptoG1);

            btnEliminarDeptoG1 = new Button();
            btnEliminarDeptoG1.Name = "btnEliminarDeptoG1";
            btnEliminarDeptoG1.Text = "Eliminar";
            btnEliminarDeptoG1.Font = fuenteTexto;
            btnEliminarDeptoG1.BackColor = colorBotones;
            btnEliminarDeptoG1.ForeColor = Color.White;
            btnEliminarDeptoG1.FlatStyle = FlatStyle.Flat;
            btnEliminarDeptoG1.Location = new Point(530, 35);
            btnEliminarDeptoG1.Size = new Size(120, 35);
            btnEliminarDeptoG1.Click += new EventHandler(btnEliminarDeptoG1_Click);
            gpbEliminar.Controls.Add(btnEliminarDeptoG1);

            btnLimpiarEliminarG1 = new Button();
            btnLimpiarEliminarG1.Name = "btnLimpiarEliminarG1";
            btnLimpiarEliminarG1.Text = "Limpiar";
            btnLimpiarEliminarG1.Font = fuenteTexto;
            btnLimpiarEliminarG1.BackColor = colorBotones;
            btnLimpiarEliminarG1.ForeColor = Color.White;
            btnLimpiarEliminarG1.FlatStyle = FlatStyle.Flat;
            btnLimpiarEliminarG1.Location = new Point(400, 80);
            btnLimpiarEliminarG1.Size = new Size(120, 35);
            btnLimpiarEliminarG1.Click += new EventHandler(btnLimpiarEliminarG1_Click);
            gpbEliminar.Controls.Add(btnLimpiarEliminarG1);
        }

        // ==========================================
        // EVENTOS DE LOS BOTONES
        // ==========================================

        private void btnGuardarDeptoG1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreDeptoG1.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del departamento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = ConexionG1.SubObtenerConexionG1())
                {
                    conexion.Open();
                    string query = "INSERT INTO Departamentos (NombreDepartamento) VALUES (@nombre)";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", txtNombreDeptoG1.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Departamento guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SubLimpiarDeptoG1();
                    SubCargarDepartamentosG1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarDeptoG1_Click(object sender, EventArgs e)
        {
            SubLimpiarDeptoG1();
        }

        private void btnBuscarDeptoG1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEliminarG1.Text))
            {
                MessageBox.Show("Ingrese el ID del departamento a buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = ConexionG1.SubObtenerConexionG1())
                {
                    conexion.Open();
                    string query = "SELECT NombreDepartamento FROM Departamentos WHERE IdDepartamento = @id";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", txtIdEliminarG1.Text.Trim());

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNombreEliminarG1.Text = reader["NombreDepartamento"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Departamento no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombreEliminarG1.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDeptoG1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEliminarG1.Text))
            {
                MessageBox.Show("Ingrese el ID del departamento a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este departamento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No) return;

            try
            {
                using (SqlConnection conexion = ConexionG1.SubObtenerConexionG1())
                {
                    conexion.Open();
                    string query = "DELETE FROM Departamentos WHERE IdDepartamento = @id";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", txtIdEliminarG1.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Departamento eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SubLimpiarEliminarG1();
                    SubCargarDepartamentosG1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarEliminarG1_Click(object sender, EventArgs e)
        {
            SubLimpiarEliminarG1();
        }

        // ==========================================
        // MÉTODOS AUXILIARES
        // ==========================================

        private void SubLimpiarDeptoG1()
        {
            txtIdDeptoG1.Clear();
            txtNombreDeptoG1.Clear();
            txtNombreDeptoG1.Focus();
        }

        private void SubLimpiarEliminarG1()
        {
            txtIdEliminarG1.Clear();
            txtNombreEliminarG1.Clear();
            txtIdEliminarG1.Focus();
        }

        private void SubCargarDepartamentosG1()
        {
            try
            {
                using (SqlConnection conexion = ConexionG1.SubObtenerConexionG1())
                {
                    conexion.Open();
                    string query = "SELECT IdDepartamento, NombreDepartamento FROM Departamentos";
                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dgvDepartamentosG1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}