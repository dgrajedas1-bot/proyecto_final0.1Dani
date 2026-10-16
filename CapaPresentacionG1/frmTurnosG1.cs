using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidadesG1;
using CapaLogicaNegocioG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Turnos (crear, actualizar, eliminar) y planificación de horarios
    /// (asignar turnos a empleados por fecha).
    /// </summary>
    public partial class frmTurnosG1 : Form
    {
        private readonly TurnoLogicaG1 gObjTurnoLogicaG1 = new TurnoLogicaG1();
        private readonly EmpleadoLogicaG1 gObjEmpleadoLogicaG1 = new EmpleadoLogicaG1();

        /// <summary>Crea el formulario de turnos.</summary>
        public frmTurnosG1()
        {
            InitializeComponent();
        }

        /// <summary>Aplica estilo y carga turnos, empleados y asignaciones.</summary>
        private void frmTurnosG1_Load(object sender, EventArgs e)
        {
            EstiloG1.SubAplicarFormularioG1(this);
            dtpDesdeAsignacionG1.Value = DateTime.Today.AddDays(-7);
            dtpHastaAsignacionG1.Value = DateTime.Today.AddDays(14);
            dtpFechaAsignacionG1.Value = DateTime.Today;
            SubLimpiarTurnoG1();
            SubCargarTurnosG1();
            try
            {
                cmbEmpleadoAsignacionG1.DataSource = gObjEmpleadoLogicaG1.FunListarActivosG1();
                cmbEmpleadoAsignacionG1.DisplayMember = "NombreCompleto";
                cmbEmpleadoAsignacionG1.ValueMember = "IdEmpleado";
                cmbEmpleadoAsignacionG1.SelectedIndex = -1;
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
            SubCargarAsignacionesG1();
        }

        /// <summary>Carga la grilla y la lista desplegable de turnos.</summary>
        private void SubCargarTurnosG1()
        {
            try
            {
                DataTable dtTurnosG1 = gObjTurnoLogicaG1.FunListarG1();
                dgvTurnosG1.DataSource = dtTurnosG1;
                cmbTurnoAsignacionG1.DataSource = dtTurnosG1.Copy();
                cmbTurnoAsignacionG1.DisplayMember = "NombreTurno";
                cmbTurnoAsignacionG1.ValueMember = "IdTurno";
                cmbTurnoAsignacionG1.SelectedIndex = -1;
                if (dgvTurnosG1.Columns.Contains("IdTurno")) dgvTurnosG1.Columns["IdTurno"].HeaderText = "ID";
                if (dgvTurnosG1.Columns.Contains("ToleranciaMinutos")) dgvTurnosG1.Columns["ToleranciaMinutos"].HeaderText = "Tolerancia (min)";
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Carga las asignaciones del rango elegido.</summary>
        private void SubCargarAsignacionesG1()
        {
            try
            {
                dgvAsignacionesG1.DataSource = gObjTurnoLogicaG1.FunListarAsignacionesG1(dtpDesdeAsignacionG1.Value, dtpHastaAsignacionG1.Value);
                if (dgvAsignacionesG1.Columns.Contains("IdAsignacion")) dgvAsignacionesG1.Columns["IdAsignacion"].HeaderText = "ID";
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Lee los datos del turno con validación numérica de la tolerancia.</summary>
        /// <returns>Turno o null si la tolerancia no es válida.</returns>
        private TurnoG1 FunLeerTurnoG1()
        {
            int intToleranciaG1;
            if (!int.TryParse(txtToleranciaTurnoG1.Text.Trim(), out intToleranciaG1))
            {
                EstiloG1.SubAdvertenciaG1("Ingrese la tolerancia en minutos (solo números, de 0 a 120).");
                txtToleranciaTurnoG1.Focus();
                return null;
            }
            TimeSpan tsEntradaG1 = dtpHoraEntradaTurnoG1.Value.TimeOfDay;
            TimeSpan tsSalidaG1 = dtpHoraSalidaTurnoG1.Value.TimeOfDay;
            return new TurnoG1
            {
                IdTurno = ValidacionEntradaG1.FunEnteroG1(txtIdTurnoG1.Text),
                NombreTurno = txtNombreTurnoG1.Text,
                HoraEntrada = new TimeSpan(tsEntradaG1.Hours, tsEntradaG1.Minutes, 0),
                HoraSalida = new TimeSpan(tsSalidaG1.Hours, tsSalidaG1.Minutes, 0),
                ToleranciaMinutos = intToleranciaG1
            };
        }

        /// <summary>Prepara un turno nuevo.</summary>
        private void btnNuevoTurnoG1_Click(object sender, EventArgs e)
        {
            SubLimpiarTurnoG1();
        }

        /// <summary>Guarda un turno nuevo.</summary>
        private void btnGuardarTurnoG1_Click(object sender, EventArgs e)
        {
            if (txtIdTurnoG1.Text.Length > 0)
            {
                EstiloG1.SubAdvertenciaG1("Está editando un turno existente. Use \"Actualizar\" o presione \"Nuevo\".");
                return;
            }
            TurnoG1 objTurnoG1 = FunLeerTurnoG1();
            if (objTurnoG1 == null) return;
            try
            {
                gObjTurnoLogicaG1.SubGuardarG1(objTurnoG1);
                EstiloG1.SubInformacionG1("Turno guardado correctamente.");
                SubLimpiarTurnoG1();
                SubCargarTurnosG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Actualiza el turno seleccionado.</summary>
        private void btnEditarTurnoG1_Click(object sender, EventArgs e)
        {
            if (txtIdTurnoG1.Text.Length == 0)
            {
                EstiloG1.SubAdvertenciaG1("Seleccione un turno de la lista para editarlo.");
                return;
            }
            TurnoG1 objTurnoG1 = FunLeerTurnoG1();
            if (objTurnoG1 == null) return;
            try
            {
                gObjTurnoLogicaG1.SubActualizarG1(objTurnoG1);
                EstiloG1.SubInformacionG1("Turno actualizado correctamente.");
                SubLimpiarTurnoG1();
                SubCargarTurnosG1();
                SubCargarAsignacionesG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Elimina el turno seleccionado (si no tiene asignaciones).</summary>
        private void btnEliminarTurnoG1_Click(object sender, EventArgs e)
        {
            int intIdG1 = ValidacionEntradaG1.FunEnteroG1(txtIdTurnoG1.Text);
            if (intIdG1 <= 0)
            {
                EstiloG1.SubAdvertenciaG1("Seleccione un turno de la lista.");
                return;
            }
            if (!EstiloG1.FunConfirmarG1("¿Está seguro de eliminar el turno \"" + txtNombreTurnoG1.Text + "\"?")) return;
            try
            {
                gObjTurnoLogicaG1.SubEliminarG1(intIdG1);
                EstiloG1.SubInformacionG1("Turno eliminado correctamente.");
                SubLimpiarTurnoG1();
                SubCargarTurnosG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Limpia los datos del turno.</summary>
        private void btnLimpiarTurnoG1_Click(object sender, EventArgs e)
        {
            SubLimpiarTurnoG1();
        }

        /// <summary>Asigna el turno elegido al empleado en la fecha elegida.</summary>
        private void btnAsignarTurnoG1_Click(object sender, EventArgs e)
        {
            if (cmbEmpleadoAsignacionG1.SelectedValue == null)
            {
                EstiloG1.SubAdvertenciaG1("Seleccione un empleado.");
                return;
            }
            if (cmbTurnoAsignacionG1.SelectedValue == null)
            {
                EstiloG1.SubAdvertenciaG1("Seleccione un turno.");
                return;
            }
            try
            {
                gObjTurnoLogicaG1.SubAsignarG1(new AsignacionTurnoG1
                {
                    IdEmpleado = Convert.ToInt32(cmbEmpleadoAsignacionG1.SelectedValue),
                    IdTurno = Convert.ToInt32(cmbTurnoAsignacionG1.SelectedValue),
                    FechaProgramada = dtpFechaAsignacionG1.Value.Date
                });
                EstiloG1.SubInformacionG1("Turno asignado correctamente.");
                SubCargarAsignacionesG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Quita la asignación seleccionada en la grilla.</summary>
        private void btnEliminarAsignacionG1_Click(object sender, EventArgs e)
        {
            if (dgvAsignacionesG1.CurrentRow == null)
            {
                EstiloG1.SubAdvertenciaG1("Seleccione una asignación de la lista.");
                return;
            }
            if (!EstiloG1.FunConfirmarG1("¿Desea quitar la asignación seleccionada?")) return;
            try
            {
                gObjTurnoLogicaG1.SubEliminarAsignacionG1(Convert.ToInt32(dgvAsignacionesG1.CurrentRow.Cells["IdAsignacion"].Value));
                SubCargarAsignacionesG1();
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubManejarExcepcionG1(exErrorG1);
            }
        }

        /// <summary>Recarga las asignaciones del rango.</summary>
        private void btnFiltrarAsignacionesG1_Click(object sender, EventArgs e)
        {
            SubCargarAsignacionesG1();
        }

        /// <summary>Solo números en la tolerancia.</summary>
        private void txtToleranciaTurnoG1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionEntradaG1.SubSoloNumerosG1(sender, e);
        }

        /// <summary>Carga el turno seleccionado para editarlo.</summary>
        private void dgvTurnosG1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataGridViewRow dgrFilaG1 = dgvTurnosG1.Rows[e.RowIndex];
                txtIdTurnoG1.Text = Convert.ToString(dgrFilaG1.Cells["IdTurno"].Value);
                txtNombreTurnoG1.Text = Convert.ToString(dgrFilaG1.Cells["NombreTurno"].Value);
                dtpHoraEntradaTurnoG1.Value = DateTime.Today.Add((TimeSpan)dgrFilaG1.Cells["HoraEntrada"].Value);
                dtpHoraSalidaTurnoG1.Value = DateTime.Today.Add((TimeSpan)dgrFilaG1.Cells["HoraSalida"].Value);
                txtToleranciaTurnoG1.Text = Convert.ToString(dgrFilaG1.Cells["ToleranciaMinutos"].Value);
            }
            catch (Exception exErrorG1)
            {
                EstiloG1.SubErrorG1("No se pudo cargar el turno: " + exErrorG1.Message);
            }
        }

        /// <summary>Deja los datos del turno con valores por defecto.</summary>
        private void SubLimpiarTurnoG1()
        {
            txtIdTurnoG1.Clear();
            txtNombreTurnoG1.Clear();
            dtpHoraEntradaTurnoG1.Value = DateTime.Today.AddHours(8);
            dtpHoraSalidaTurnoG1.Value = DateTime.Today.AddHours(17);
            txtToleranciaTurnoG1.Text = "10";
            txtNombreTurnoG1.Focus();
        }
    }
}
