using System;
using System.Windows.Forms;
using CapaEntidadesG1;
using CapaLogicaNegocioG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Gestión de departamentos: crear, editar, buscar y eliminar.
    /// Ya no contiene SQL; usa DepartamentoLogicaG1.
    /// </summary>
    public partial class frmDepartamentosG1 : Form
    {
        private readonly DepartamentoLogicaG1 gObjDeptoLogicaG1 = new DepartamentoLogicaG1();

        /// <summary>Crea el formulario de departamentos.</summary>
        public frmDepartamentosG1()
        {
            InitializeComponent();
        }

        /// <summary>Aplica estilo y carga la lista.</summary>
        private void frmDepartamentosG1_Load(object sender, EventArgs e)
        {
            EstiloG1.SubAplicarFormularioG1(this);
            SubCargarDepartamentosG1();
        }

        // ==========================================
        // EVENTOS DE LOS BOTONES
        // ==========================================

        /// <summary>Prepara el formulario para un departamento nuevo.</summary>
        private void btnNuevoDeptoG1_Click(object sender, EventArgs e)
        {
            SubLimpiarDeptoG1();
        }

        /// <summary>Guarda un departamento nuevo.</summary>
        private void btnGuardarDeptoG1_Click(object sender, EventArgs e)
        {
            if (txtIdDeptoG1.Text.Length > 0)
            {
                EstiloG1.SubAdvertenciaG1("Está editando un departamento existente. Use \"Actualizar\" o presione \"Nuevo\".");
                return;
            }
            try
            {
                gObjDeptoLogicaG1.SubGuardarG1(txtNombreDeptoG1.Text);
                EstiloG1.SubInformacionG1("Departamento guardado correctamente.");
                SubLimpiarDeptoG1();
                SubCargarDepartamentosG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Actualiza el departamento seleccionado.</summary>
        private void btnEditarDeptoG1_Click(object sender, EventArgs e)
        {
            try
            {
                gObjDeptoLogicaG1.SubActualizarG1(ValidacionEntradaG1.FunEnteroG1(txtIdDeptoG1.Text), txtNombreDeptoG1.Text);
                EstiloG1.SubInformacionG1("Departamento actualizado correctamente.");
                SubLimpiarDeptoG1();
                SubCargarDepartamentosG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Limpia la sección de nuevo/editar.</summary>
        private void btnLimpiarDeptoG1_Click(object sender, EventArgs e)
        {
            SubLimpiarDeptoG1();
        }

        /// <summary>Busca un departamento por ID.</summary>
        private void btnBuscarDeptoG1_Click(object sender, EventArgs e)
        {
            int intIdG1;
            if (!int.TryParse(txtIdEliminarG1.Text.Trim(), out intIdG1) || intIdG1 <= 0)
            {
                EstiloG1.SubAdvertenciaG1("Ingrese un ID numérico válido.");
                txtIdEliminarG1.Focus();
                return;
            }
            try
            {
                DepartamentoG1 objDeptoG1 = gObjDeptoLogicaG1.FunBuscarG1(intIdG1);
                if (objDeptoG1 == null)
                {
                    EstiloG1.SubInformacionG1("Departamento no encontrado.");
                    txtNombreEliminarG1.Clear();
                    return;
                }
                txtNombreEliminarG1.Text = objDeptoG1.NombreDepartamentoG1;
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Elimina el departamento indicado (si no tiene empleados).</summary>
        private void btnEliminarDeptoG1_Click(object sender, EventArgs e)
        {
            int intIdG1;
            if (!int.TryParse(txtIdEliminarG1.Text.Trim(), out intIdG1) || intIdG1 <= 0)
            {
                EstiloG1.SubAdvertenciaG1("Ingrese el ID numérico del departamento a eliminar.");
                txtIdEliminarG1.Focus();
                return;
            }
            if (!EstiloG1.FunConfirmarG1("¿Está seguro de eliminar este departamento?")) return;
            try
            {
                gObjDeptoLogicaG1.SubEliminarG1(intIdG1);
                EstiloG1.SubInformacionG1("Departamento eliminado correctamente.");
                SubLimpiarEliminarG1();
                SubCargarDepartamentosG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Limpia la sección de buscar/eliminar.</summary>
        private void btnLimpiarEliminarG1_Click(object sender, EventArgs e)
        {
            SubLimpiarEliminarG1();
        }

        /// <summary>Solo números en el ID.</summary>
        private void txtIdEliminarG1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionEntradaG1.SubSoloNumerosG1(sender, e);
        }

        /// <summary>Al hacer clic en una fila, la carga para editar o eliminar.</summary>
        private void dgvDepartamentosG1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dgrFilaG1 = dgvDepartamentosG1.Rows[e.RowIndex];
            txtIdDeptoG1.Text = Convert.ToString(dgrFilaG1.Cells["IdDepartamento"].Value);
            txtNombreDeptoG1.Text = Convert.ToString(dgrFilaG1.Cells["NombreDepartamento"].Value);
            txtIdEliminarG1.Text = txtIdDeptoG1.Text;
            txtNombreEliminarG1.Text = txtNombreDeptoG1.Text;
        }

        // ==========================================
        // MÉTODOS AUXILIARES
        // ==========================================

        /// <summary>Limpia los campos de nuevo/editar.</summary>
        private void SubLimpiarDeptoG1()
        {
            txtIdDeptoG1.Clear();
            txtNombreDeptoG1.Clear();
            txtNombreDeptoG1.Focus();
        }

        /// <summary>Limpia los campos de buscar/eliminar.</summary>
        private void SubLimpiarEliminarG1()
        {
            txtIdEliminarG1.Clear();
            txtNombreEliminarG1.Clear();
            txtIdEliminarG1.Focus();
        }

        /// <summary>Carga la lista de departamentos en la grilla.</summary>
        private void SubCargarDepartamentosG1()
        {
            try
            {
                dgvDepartamentosG1.DataSource = gObjDeptoLogicaG1.FunListarG1();
                if (dgvDepartamentosG1.Columns.Contains("IdDepartamento")) dgvDepartamentosG1.Columns["IdDepartamento"].HeaderText = "ID";
                if (dgvDepartamentosG1.Columns.Contains("NombreDepartamento")) dgvDepartamentosG1.Columns["NombreDepartamento"].HeaderText = "Departamento";
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }
    }
}
