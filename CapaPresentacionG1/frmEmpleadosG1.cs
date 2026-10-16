using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using CapaEntidadesG1;
using CapaLogicaNegocioG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Gestión de empleados: nuevo, guardar, actualizar, eliminar/desactivar, buscar y limpiar.
    /// El código del empleado es numérico de 3 dígitos (001).
    /// </summary>
    public partial class frmEmpleadosG1 : Form
    {
        private readonly EmpleadoLogicaG1 gObjEmpleadoLogicaG1 = new EmpleadoLogicaG1();
        private readonly DepartamentoLogicaG1 gObjDeptoLogicaG1 = new DepartamentoLogicaG1();

        /// <summary>Crea el formulario de empleados.</summary>
        public frmEmpleadosG1()
        {
            InitializeComponent();
        }

        /// <summary>Aplica estilo, carga departamentos y empleados.</summary>
        private void frmEmpleadosG1_Load(object sender, EventArgs e)
        {
            EstiloG1.SubAplicarFormularioG1(this);
            try
            {
                cmbDepartamentoEmpleadoG1.DataSource = gObjDeptoLogicaG1.FunListarG1();
                cmbDepartamentoEmpleadoG1.DisplayMember = "NombreDepartamento";
                cmbDepartamentoEmpleadoG1.ValueMember = "IdDepartamento";
                cmbDepartamentoEmpleadoG1.SelectedIndex = -1;
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
            SubCargarEmpleadosG1("");
            SubLimpiarG1();
        }

        /// <summary>Carga la grilla con un filtro.</summary>
        /// <param name="strFiltroG1">Texto a buscar (vacío = todos).</param>
        private void SubCargarEmpleadosG1(string strFiltroG1)
        {
            try
            {
                dgvEmpleadosG1.DataSource = gObjEmpleadoLogicaG1.FunListarG1(strFiltroG1);
                if (dgvEmpleadosG1.Columns.Contains("IdEmpleado")) dgvEmpleadosG1.Columns["IdEmpleado"].HeaderText = "ID";
                if (dgvEmpleadosG1.Columns.Contains("IdDepartamento")) dgvEmpleadosG1.Columns["IdDepartamento"].Visible = false;
                if (dgvEmpleadosG1.Columns.Contains("SalarioBase"))
                {
                    dgvEmpleadosG1.Columns["SalarioBase"].HeaderText = "Salario (Q)";
                    dgvEmpleadosG1.Columns["SalarioBase"].DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>
        /// Lee y convierte los datos del formulario a un empleado (con TryParse).
        /// </summary>
        /// <returns>Empleado o null si algún dato numérico no es válido.</returns>
        private EmpleadoG1 FunLeerFormularioG1()
        {
            decimal decSalarioG1;
            if (!decimal.TryParse(txtSalarioEmpleadoG1.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decSalarioG1))
            {
                EstiloG1.SubAdvertenciaG1("Ingrese un salario válido (solo números, ejemplo: 4500.00).");
                txtSalarioEmpleadoG1.Focus();
                return null;
            }
            if (cmbDepartamentoEmpleadoG1.SelectedValue == null)
            {
                EstiloG1.SubAdvertenciaG1("Seleccione un departamento.");
                cmbDepartamentoEmpleadoG1.Focus();
                return null;
            }
            return new EmpleadoG1
            {
                IdEmpleado = ValidacionEntradaG1.FunEnteroG1(txtIdEmpleadoG1.Text),
                CodigoCarnet = txtCodigoEmpleadoG1.Text,
                Nombres = txtNombresEmpleadoG1.Text,
                Apellidos = txtApellidosEmpleadoG1.Text,
                IdDepartamento = Convert.ToInt32(cmbDepartamentoEmpleadoG1.SelectedValue),
                Puesto = txtPuestoEmpleadoG1.Text,
                SalarioBase = decSalarioG1,
                Activo = chkActivoEmpleadoG1.Checked
            };
        }

        /// <summary>Limpia el formulario y sugiere el siguiente código.</summary>
        private void btnNuevoEmpleadoG1_Click(object sender, EventArgs e)
        {
            SubLimpiarG1();
            try
            {
                txtCodigoEmpleadoG1.Text = gObjEmpleadoLogicaG1.FunSiguienteCodigoG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
            txtNombresEmpleadoG1.Focus();
        }

        /// <summary>Guarda un empleado nuevo.</summary>
        private void btnGuardarEmpleadoG1_Click(object sender, EventArgs e)
        {
            if (txtIdEmpleadoG1.Text.Length > 0)
            {
                EstiloG1.SubAdvertenciaG1("Está editando un empleado existente. Use \"Actualizar\" o presione \"Nuevo\".");
                return;
            }
            EmpleadoG1 objEmpleadoG1 = FunLeerFormularioG1();
            if (objEmpleadoG1 == null) return;
            try
            {
                gObjEmpleadoLogicaG1.SubGuardarG1(objEmpleadoG1);
                EstiloG1.SubInformacionG1("Empleado " + objEmpleadoG1.CodigoCarnet + " guardado correctamente.");
                SubLimpiarG1();
                SubCargarEmpleadosG1("");
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Actualiza el empleado seleccionado.</summary>
        private void btnEditarEmpleadoG1_Click(object sender, EventArgs e)
        {
            if (txtIdEmpleadoG1.Text.Length == 0)
            {
                EstiloG1.SubAdvertenciaG1("Seleccione un empleado de la lista para editarlo.");
                return;
            }
            EmpleadoG1 objEmpleadoG1 = FunLeerFormularioG1();
            if (objEmpleadoG1 == null) return;
            try
            {
                gObjEmpleadoLogicaG1.SubActualizarG1(objEmpleadoG1);
                EstiloG1.SubInformacionG1("Empleado actualizado correctamente.");
                SubLimpiarG1();
                SubCargarEmpleadosG1(txtBuscarEmpleadoG1.Text);
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Elimina el empleado; si tiene historial, lo desactiva.</summary>
        private void btnEliminarEmpleadoG1_Click(object sender, EventArgs e)
        {
            int intIdG1 = ValidacionEntradaG1.FunEnteroG1(txtIdEmpleadoG1.Text);
            if (intIdG1 <= 0)
            {
                EstiloG1.SubAdvertenciaG1("Seleccione un empleado de la lista.");
                return;
            }
            if (!EstiloG1.FunConfirmarG1("¿Desea eliminar al empleado " + txtCodigoEmpleadoG1.Text + "?\n" +
                                        "Si ya tiene marcaciones o turnos, solo se desactivará.")) return;
            try
            {
                bool blnEliminadoG1 = gObjEmpleadoLogicaG1.FunEliminarG1(intIdG1);
                EstiloG1.SubInformacionG1(blnEliminadoG1
                    ? "Empleado eliminado correctamente."
                    : "El empleado tiene historial, así que se desactivó en lugar de eliminarse.");
                SubLimpiarG1();
                SubCargarEmpleadosG1(txtBuscarEmpleadoG1.Text);
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Limpia el formulario.</summary>
        private void btnLimpiarEmpleadoG1_Click(object sender, EventArgs e)
        {
            SubLimpiarG1();
        }

        /// <summary>Filtra la grilla por código o nombre.</summary>
        private void btnBuscarEmpleadoG1_Click(object sender, EventArgs e)
        {
            SubCargarEmpleadosG1(txtBuscarEmpleadoG1.Text);
            if (dgvEmpleadosG1.Rows.Count == 0) EstiloG1.SubInformacionG1("No se encontraron empleados con ese criterio.");
        }

        /// <summary>Quita el filtro.</summary>
        private void btnVerTodosEmpleadosG1_Click(object sender, EventArgs e)
        {
            txtBuscarEmpleadoG1.Clear();
            SubCargarEmpleadosG1("");
        }

        /// <summary>Carga la fila seleccionada en el formulario.</summary>
        private void dgvEmpleadosG1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataGridViewRow dgrFilaG1 = dgvEmpleadosG1.Rows[e.RowIndex];
                txtIdEmpleadoG1.Text = Convert.ToString(dgrFilaG1.Cells["IdEmpleado"].Value);
                txtCodigoEmpleadoG1.Text = Convert.ToString(dgrFilaG1.Cells["Codigo"].Value);
                txtNombresEmpleadoG1.Text = Convert.ToString(dgrFilaG1.Cells["Nombres"].Value);
                txtApellidosEmpleadoG1.Text = Convert.ToString(dgrFilaG1.Cells["Apellidos"].Value);
                txtPuestoEmpleadoG1.Text = Convert.ToString(dgrFilaG1.Cells["Puesto"].Value);
                txtSalarioEmpleadoG1.Text = Convert.ToDecimal(dgrFilaG1.Cells["SalarioBase"].Value).ToString("0.00", CultureInfo.InvariantCulture);
                object objDeptoG1 = dgrFilaG1.Cells["IdDepartamento"].Value;
                if (objDeptoG1 == null || objDeptoG1 == DBNull.Value) cmbDepartamentoEmpleadoG1.SelectedIndex = -1;
                else cmbDepartamentoEmpleadoG1.SelectedValue = Convert.ToInt32(objDeptoG1);
                object objActivoG1 = dgrFilaG1.Cells["Activo"].Value;
                chkActivoEmpleadoG1.Checked = objActivoG1 != null && objActivoG1 != DBNull.Value && Convert.ToBoolean(objActivoG1);
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubErrorG1("No se pudo cargar el empleado: " + exErrorG1.Message);
            }
        }

        /// <summary>Solo números en el código.</summary>
        private void txtCodigoEmpleadoG1_KeyPress(object sender, KeyPressEventArgs e) { ValidacionEntradaG1.SubSoloNumerosG1(sender, e); }

        /// <summary>Solo letras en los nombres.</summary>
        private void txtNombresEmpleadoG1_KeyPress(object sender, KeyPressEventArgs e) { ValidacionEntradaG1.SubSoloLetrasG1(sender, e); }

        /// <summary>Solo letras en los apellidos.</summary>
        private void txtApellidosEmpleadoG1_KeyPress(object sender, KeyPressEventArgs e) { ValidacionEntradaG1.SubSoloLetrasG1(sender, e); }

        /// <summary>Solo letras en el puesto.</summary>
        private void txtPuestoEmpleadoG1_KeyPress(object sender, KeyPressEventArgs e) { ValidacionEntradaG1.SubSoloLetrasG1(sender, e); }

        /// <summary>Solo números y punto decimal en el salario.</summary>
        private void txtSalarioEmpleadoG1_KeyPress(object sender, KeyPressEventArgs e) { ValidacionEntradaG1.SubSoloDecimalG1(sender, e); }

        /// <summary>Deja el formulario vacío para un registro nuevo.</summary>
        private void SubLimpiarG1()
        {
            txtIdEmpleadoG1.Clear();
            txtCodigoEmpleadoG1.Clear();
            txtNombresEmpleadoG1.Clear();
            txtApellidosEmpleadoG1.Clear();
            txtPuestoEmpleadoG1.Clear();
            txtSalarioEmpleadoG1.Clear();
            cmbDepartamentoEmpleadoG1.SelectedIndex = -1;
            chkActivoEmpleadoG1.Checked = true;
            txtCodigoEmpleadoG1.Focus();
        }
    }
}
