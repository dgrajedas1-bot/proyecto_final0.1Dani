namespace CapaPresentacionG1
{
    partial class frmTurnosG1
    {
        /// <summary>Contenedor de componentes del diseñador.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Libera los recursos utilizados.</summary>
        /// <param name="disposing">true si se deben liberar los recursos administrados.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>Inicializa los controles del formulario.</summary>
        private void InitializeComponent()
        {
            this.lblTituloTurnosG1 = new System.Windows.Forms.Label();
            this.grpTurnoG1 = new System.Windows.Forms.GroupBox();
            this.lblIdTurnoG1 = new System.Windows.Forms.Label();
            this.txtIdTurnoG1 = new System.Windows.Forms.TextBox();
            this.lblNombreTurnoG1 = new System.Windows.Forms.Label();
            this.txtNombreTurnoG1 = new System.Windows.Forms.TextBox();
            this.lblHoraEntradaTurnoG1 = new System.Windows.Forms.Label();
            this.dtpHoraEntradaTurnoG1 = new System.Windows.Forms.DateTimePicker();
            this.lblHoraSalidaTurnoG1 = new System.Windows.Forms.Label();
            this.dtpHoraSalidaTurnoG1 = new System.Windows.Forms.DateTimePicker();
            this.lblToleranciaTurnoG1 = new System.Windows.Forms.Label();
            this.txtToleranciaTurnoG1 = new System.Windows.Forms.TextBox();
            this.btnNuevoTurnoG1 = new System.Windows.Forms.Button();
            this.btnGuardarTurnoG1 = new System.Windows.Forms.Button();
            this.btnEditarTurnoG1 = new System.Windows.Forms.Button();
            this.btnEliminarTurnoG1 = new System.Windows.Forms.Button();
            this.btnLimpiarTurnoG1 = new System.Windows.Forms.Button();
            this.dgvTurnosG1 = new System.Windows.Forms.DataGridView();
            this.grpAsignacionTurnoG1 = new System.Windows.Forms.GroupBox();
            this.lblEmpleadoAsignacionG1 = new System.Windows.Forms.Label();
            this.cmbEmpleadoAsignacionG1 = new System.Windows.Forms.ComboBox();
            this.lblTurnoAsignacionG1 = new System.Windows.Forms.Label();
            this.cmbTurnoAsignacionG1 = new System.Windows.Forms.ComboBox();
            this.lblFechaAsignacionG1 = new System.Windows.Forms.Label();
            this.dtpFechaAsignacionG1 = new System.Windows.Forms.DateTimePicker();
            this.btnAsignarTurnoG1 = new System.Windows.Forms.Button();
            this.btnEliminarAsignacionG1 = new System.Windows.Forms.Button();
            this.lblDesdeAsignacionG1 = new System.Windows.Forms.Label();
            this.dtpDesdeAsignacionG1 = new System.Windows.Forms.DateTimePicker();
            this.lblHastaAsignacionG1 = new System.Windows.Forms.Label();
            this.dtpHastaAsignacionG1 = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarAsignacionesG1 = new System.Windows.Forms.Button();
            this.dgvAsignacionesG1 = new System.Windows.Forms.DataGridView();
            this.grpTurnoG1.SuspendLayout();
            this.grpAsignacionTurnoG1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacionesG1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloTurnosG1
            // 
            this.lblTituloTurnosG1.AutoSize = true;
            this.lblTituloTurnosG1.Location = new System.Drawing.Point(30, 15);
            this.lblTituloTurnosG1.Text = "Turnos y Planificación de Horarios";
            this.lblTituloTurnosG1.Name = "lblTituloTurnosG1";
            this.lblTituloTurnosG1.TabIndex = 0;
            // 
            // grpTurnoG1
            // 
            this.grpTurnoG1.Controls.Add(this.btnLimpiarTurnoG1);
            this.grpTurnoG1.Controls.Add(this.btnEliminarTurnoG1);
            this.grpTurnoG1.Controls.Add(this.btnEditarTurnoG1);
            this.grpTurnoG1.Controls.Add(this.btnGuardarTurnoG1);
            this.grpTurnoG1.Controls.Add(this.btnNuevoTurnoG1);
            this.grpTurnoG1.Controls.Add(this.txtToleranciaTurnoG1);
            this.grpTurnoG1.Controls.Add(this.lblToleranciaTurnoG1);
            this.grpTurnoG1.Controls.Add(this.dtpHoraSalidaTurnoG1);
            this.grpTurnoG1.Controls.Add(this.lblHoraSalidaTurnoG1);
            this.grpTurnoG1.Controls.Add(this.dtpHoraEntradaTurnoG1);
            this.grpTurnoG1.Controls.Add(this.lblHoraEntradaTurnoG1);
            this.grpTurnoG1.Controls.Add(this.txtNombreTurnoG1);
            this.grpTurnoG1.Controls.Add(this.lblNombreTurnoG1);
            this.grpTurnoG1.Controls.Add(this.txtIdTurnoG1);
            this.grpTurnoG1.Controls.Add(this.lblIdTurnoG1);
            this.grpTurnoG1.Location = new System.Drawing.Point(30, 65);
            this.grpTurnoG1.Size = new System.Drawing.Size(820, 125);
            this.grpTurnoG1.Text = "Turno";
            this.grpTurnoG1.Name = "grpTurnoG1";
            this.grpTurnoG1.TabIndex = 1;
            // 
            // lblIdTurnoG1
            // 
            this.lblIdTurnoG1.AutoSize = true;
            this.lblIdTurnoG1.Location = new System.Drawing.Point(20, 38);
            this.lblIdTurnoG1.Text = "ID:";
            this.lblIdTurnoG1.Name = "lblIdTurnoG1";
            this.lblIdTurnoG1.TabIndex = 0;
            // 
            // txtIdTurnoG1
            // 
            this.txtIdTurnoG1.Location = new System.Drawing.Point(55, 35);
            this.txtIdTurnoG1.Size = new System.Drawing.Size(60, 25);
            this.txtIdTurnoG1.ReadOnly = true;
            this.txtIdTurnoG1.TabStop = false;
            this.txtIdTurnoG1.Name = "txtIdTurnoG1";
            this.txtIdTurnoG1.TabIndex = 1;
            // 
            // lblNombreTurnoG1
            // 
            this.lblNombreTurnoG1.AutoSize = true;
            this.lblNombreTurnoG1.Location = new System.Drawing.Point(135, 38);
            this.lblNombreTurnoG1.Text = "Nombre:";
            this.lblNombreTurnoG1.Name = "lblNombreTurnoG1";
            this.lblNombreTurnoG1.TabIndex = 2;
            // 
            // txtNombreTurnoG1
            // 
            this.txtNombreTurnoG1.Location = new System.Drawing.Point(200, 35);
            this.txtNombreTurnoG1.Size = new System.Drawing.Size(200, 25);
            this.txtNombreTurnoG1.MaxLength = 50;
            this.txtNombreTurnoG1.Name = "txtNombreTurnoG1";
            this.txtNombreTurnoG1.TabIndex = 3;
            // 
            // lblHoraEntradaTurnoG1
            // 
            this.lblHoraEntradaTurnoG1.AutoSize = true;
            this.lblHoraEntradaTurnoG1.Location = new System.Drawing.Point(420, 38);
            this.lblHoraEntradaTurnoG1.Text = "Entrada:";
            this.lblHoraEntradaTurnoG1.Name = "lblHoraEntradaTurnoG1";
            this.lblHoraEntradaTurnoG1.TabIndex = 4;
            // 
            // dtpHoraEntradaTurnoG1
            // 
            this.dtpHoraEntradaTurnoG1.Location = new System.Drawing.Point(485, 35);
            this.dtpHoraEntradaTurnoG1.Size = new System.Drawing.Size(80, 25);
            this.dtpHoraEntradaTurnoG1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraEntradaTurnoG1.CustomFormat = "HH:mm";
            this.dtpHoraEntradaTurnoG1.ShowUpDown = true;
            this.dtpHoraEntradaTurnoG1.Name = "dtpHoraEntradaTurnoG1";
            this.dtpHoraEntradaTurnoG1.TabIndex = 5;
            // 
            // lblHoraSalidaTurnoG1
            // 
            this.lblHoraSalidaTurnoG1.AutoSize = true;
            this.lblHoraSalidaTurnoG1.Location = new System.Drawing.Point(585, 38);
            this.lblHoraSalidaTurnoG1.Text = "Salida:";
            this.lblHoraSalidaTurnoG1.Name = "lblHoraSalidaTurnoG1";
            this.lblHoraSalidaTurnoG1.TabIndex = 6;
            // 
            // dtpHoraSalidaTurnoG1
            // 
            this.dtpHoraSalidaTurnoG1.Location = new System.Drawing.Point(640, 35);
            this.dtpHoraSalidaTurnoG1.Size = new System.Drawing.Size(80, 25);
            this.dtpHoraSalidaTurnoG1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraSalidaTurnoG1.CustomFormat = "HH:mm";
            this.dtpHoraSalidaTurnoG1.ShowUpDown = true;
            this.dtpHoraSalidaTurnoG1.Name = "dtpHoraSalidaTurnoG1";
            this.dtpHoraSalidaTurnoG1.TabIndex = 7;
            // 
            // lblToleranciaTurnoG1
            // 
            this.lblToleranciaTurnoG1.AutoSize = true;
            this.lblToleranciaTurnoG1.Location = new System.Drawing.Point(20, 83);
            this.lblToleranciaTurnoG1.Text = "Tolerancia (min):";
            this.lblToleranciaTurnoG1.Name = "lblToleranciaTurnoG1";
            this.lblToleranciaTurnoG1.TabIndex = 8;
            // 
            // txtToleranciaTurnoG1
            // 
            this.txtToleranciaTurnoG1.Location = new System.Drawing.Point(150, 80);
            this.txtToleranciaTurnoG1.Size = new System.Drawing.Size(60, 25);
            this.txtToleranciaTurnoG1.MaxLength = 3;
            this.txtToleranciaTurnoG1.Name = "txtToleranciaTurnoG1";
            this.txtToleranciaTurnoG1.TabIndex = 9;
            this.txtToleranciaTurnoG1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToleranciaTurnoG1_KeyPress);
            // 
            // btnNuevoTurnoG1
            // 
            this.btnNuevoTurnoG1.Location = new System.Drawing.Point(230, 75);
            this.btnNuevoTurnoG1.Size = new System.Drawing.Size(100, 35);
            this.btnNuevoTurnoG1.Text = "Nuevo";
            this.btnNuevoTurnoG1.Tag = "secundario";
            this.btnNuevoTurnoG1.Name = "btnNuevoTurnoG1";
            this.btnNuevoTurnoG1.TabIndex = 10;
            this.btnNuevoTurnoG1.Click += new System.EventHandler(this.btnNuevoTurnoG1_Click);
            // 
            // btnGuardarTurnoG1
            // 
            this.btnGuardarTurnoG1.Location = new System.Drawing.Point(340, 75);
            this.btnGuardarTurnoG1.Size = new System.Drawing.Size(100, 35);
            this.btnGuardarTurnoG1.Text = "Guardar";
            this.btnGuardarTurnoG1.Name = "btnGuardarTurnoG1";
            this.btnGuardarTurnoG1.TabIndex = 11;
            this.btnGuardarTurnoG1.Click += new System.EventHandler(this.btnGuardarTurnoG1_Click);
            // 
            // btnEditarTurnoG1
            // 
            this.btnEditarTurnoG1.Location = new System.Drawing.Point(450, 75);
            this.btnEditarTurnoG1.Size = new System.Drawing.Size(100, 35);
            this.btnEditarTurnoG1.Text = "Actualizar";
            this.btnEditarTurnoG1.Name = "btnEditarTurnoG1";
            this.btnEditarTurnoG1.TabIndex = 12;
            this.btnEditarTurnoG1.Click += new System.EventHandler(this.btnEditarTurnoG1_Click);
            // 
            // btnEliminarTurnoG1
            // 
            this.btnEliminarTurnoG1.Location = new System.Drawing.Point(560, 75);
            this.btnEliminarTurnoG1.Size = new System.Drawing.Size(100, 35);
            this.btnEliminarTurnoG1.Text = "Eliminar";
            this.btnEliminarTurnoG1.Tag = "peligro";
            this.btnEliminarTurnoG1.Name = "btnEliminarTurnoG1";
            this.btnEliminarTurnoG1.TabIndex = 13;
            this.btnEliminarTurnoG1.Click += new System.EventHandler(this.btnEliminarTurnoG1_Click);
            // 
            // btnLimpiarTurnoG1
            // 
            this.btnLimpiarTurnoG1.Location = new System.Drawing.Point(670, 75);
            this.btnLimpiarTurnoG1.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiarTurnoG1.Text = "Limpiar";
            this.btnLimpiarTurnoG1.Tag = "secundario";
            this.btnLimpiarTurnoG1.Name = "btnLimpiarTurnoG1";
            this.btnLimpiarTurnoG1.TabIndex = 14;
            this.btnLimpiarTurnoG1.Click += new System.EventHandler(this.btnLimpiarTurnoG1_Click);
            // 
            // dgvTurnosG1
            // 
            this.dgvTurnosG1.Location = new System.Drawing.Point(30, 200);
            this.dgvTurnosG1.Size = new System.Drawing.Size(820, 140);
            this.dgvTurnosG1.Name = "dgvTurnosG1";
            this.dgvTurnosG1.TabIndex = 2;
            this.dgvTurnosG1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnosG1_CellClick);
            // 
            // grpAsignacionTurnoG1
            // 
            this.grpAsignacionTurnoG1.Controls.Add(this.btnFiltrarAsignacionesG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.dtpHastaAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.lblHastaAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.dtpDesdeAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.lblDesdeAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.btnEliminarAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.btnAsignarTurnoG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.dtpFechaAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.lblFechaAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.cmbTurnoAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.lblTurnoAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.cmbEmpleadoAsignacionG1);
            this.grpAsignacionTurnoG1.Controls.Add(this.lblEmpleadoAsignacionG1);
            this.grpAsignacionTurnoG1.Location = new System.Drawing.Point(30, 355);
            this.grpAsignacionTurnoG1.Size = new System.Drawing.Size(820, 125);
            this.grpAsignacionTurnoG1.Text = "Asignar Turno (Planificación de Horarios)";
            this.grpAsignacionTurnoG1.Name = "grpAsignacionTurnoG1";
            this.grpAsignacionTurnoG1.TabIndex = 3;
            // 
            // lblEmpleadoAsignacionG1
            // 
            this.lblEmpleadoAsignacionG1.AutoSize = true;
            this.lblEmpleadoAsignacionG1.Location = new System.Drawing.Point(20, 38);
            this.lblEmpleadoAsignacionG1.Text = "Empleado:";
            this.lblEmpleadoAsignacionG1.Name = "lblEmpleadoAsignacionG1";
            this.lblEmpleadoAsignacionG1.TabIndex = 0;
            // 
            // cmbEmpleadoAsignacionG1
            // 
            this.cmbEmpleadoAsignacionG1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleadoAsignacionG1.Location = new System.Drawing.Point(100, 35);
            this.cmbEmpleadoAsignacionG1.Size = new System.Drawing.Size(260, 25);
            this.cmbEmpleadoAsignacionG1.Name = "cmbEmpleadoAsignacionG1";
            this.cmbEmpleadoAsignacionG1.TabIndex = 1;
            // 
            // lblTurnoAsignacionG1
            // 
            this.lblTurnoAsignacionG1.AutoSize = true;
            this.lblTurnoAsignacionG1.Location = new System.Drawing.Point(380, 38);
            this.lblTurnoAsignacionG1.Text = "Turno:";
            this.lblTurnoAsignacionG1.Name = "lblTurnoAsignacionG1";
            this.lblTurnoAsignacionG1.TabIndex = 2;
            // 
            // cmbTurnoAsignacionG1
            // 
            this.cmbTurnoAsignacionG1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurnoAsignacionG1.Location = new System.Drawing.Point(435, 35);
            this.cmbTurnoAsignacionG1.Size = new System.Drawing.Size(180, 25);
            this.cmbTurnoAsignacionG1.Name = "cmbTurnoAsignacionG1";
            this.cmbTurnoAsignacionG1.TabIndex = 3;
            // 
            // lblFechaAsignacionG1
            // 
            this.lblFechaAsignacionG1.AutoSize = true;
            this.lblFechaAsignacionG1.Location = new System.Drawing.Point(630, 38);
            this.lblFechaAsignacionG1.Text = "Fecha:";
            this.lblFechaAsignacionG1.Name = "lblFechaAsignacionG1";
            this.lblFechaAsignacionG1.TabIndex = 4;
            // 
            // dtpFechaAsignacionG1
            // 
            this.dtpFechaAsignacionG1.Location = new System.Drawing.Point(685, 35);
            this.dtpFechaAsignacionG1.Size = new System.Drawing.Size(115, 25);
            this.dtpFechaAsignacionG1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAsignacionG1.Name = "dtpFechaAsignacionG1";
            this.dtpFechaAsignacionG1.TabIndex = 5;
            // 
            // btnAsignarTurnoG1
            // 
            this.btnAsignarTurnoG1.Location = new System.Drawing.Point(20, 75);
            this.btnAsignarTurnoG1.Size = new System.Drawing.Size(120, 35);
            this.btnAsignarTurnoG1.Text = "Asignar";
            this.btnAsignarTurnoG1.Name = "btnAsignarTurnoG1";
            this.btnAsignarTurnoG1.TabIndex = 6;
            this.btnAsignarTurnoG1.Click += new System.EventHandler(this.btnAsignarTurnoG1_Click);
            // 
            // btnEliminarAsignacionG1
            // 
            this.btnEliminarAsignacionG1.Location = new System.Drawing.Point(150, 75);
            this.btnEliminarAsignacionG1.Size = new System.Drawing.Size(120, 35);
            this.btnEliminarAsignacionG1.Text = "Quitar";
            this.btnEliminarAsignacionG1.Tag = "peligro";
            this.btnEliminarAsignacionG1.Name = "btnEliminarAsignacionG1";
            this.btnEliminarAsignacionG1.TabIndex = 7;
            this.btnEliminarAsignacionG1.Click += new System.EventHandler(this.btnEliminarAsignacionG1_Click);
            // 
            // lblDesdeAsignacionG1
            // 
            this.lblDesdeAsignacionG1.AutoSize = true;
            this.lblDesdeAsignacionG1.Location = new System.Drawing.Point(290, 83);
            this.lblDesdeAsignacionG1.Text = "Ver desde:";
            this.lblDesdeAsignacionG1.Name = "lblDesdeAsignacionG1";
            this.lblDesdeAsignacionG1.TabIndex = 8;
            // 
            // dtpDesdeAsignacionG1
            // 
            this.dtpDesdeAsignacionG1.Location = new System.Drawing.Point(370, 80);
            this.dtpDesdeAsignacionG1.Size = new System.Drawing.Size(115, 25);
            this.dtpDesdeAsignacionG1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeAsignacionG1.Name = "dtpDesdeAsignacionG1";
            this.dtpDesdeAsignacionG1.TabIndex = 9;
            // 
            // lblHastaAsignacionG1
            // 
            this.lblHastaAsignacionG1.AutoSize = true;
            this.lblHastaAsignacionG1.Location = new System.Drawing.Point(495, 83);
            this.lblHastaAsignacionG1.Text = "hasta:";
            this.lblHastaAsignacionG1.Name = "lblHastaAsignacionG1";
            this.lblHastaAsignacionG1.TabIndex = 10;
            // 
            // dtpHastaAsignacionG1
            // 
            this.dtpHastaAsignacionG1.Location = new System.Drawing.Point(545, 80);
            this.dtpHastaAsignacionG1.Size = new System.Drawing.Size(115, 25);
            this.dtpHastaAsignacionG1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaAsignacionG1.Name = "dtpHastaAsignacionG1";
            this.dtpHastaAsignacionG1.TabIndex = 11;
            // 
            // btnFiltrarAsignacionesG1
            // 
            this.btnFiltrarAsignacionesG1.Location = new System.Drawing.Point(680, 75);
            this.btnFiltrarAsignacionesG1.Size = new System.Drawing.Size(100, 35);
            this.btnFiltrarAsignacionesG1.Text = "Ver";
            this.btnFiltrarAsignacionesG1.Name = "btnFiltrarAsignacionesG1";
            this.btnFiltrarAsignacionesG1.TabIndex = 12;
            this.btnFiltrarAsignacionesG1.Click += new System.EventHandler(this.btnFiltrarAsignacionesG1_Click);
            // 
            // dgvAsignacionesG1
            // 
            this.dgvAsignacionesG1.Location = new System.Drawing.Point(30, 490);
            this.dgvAsignacionesG1.Size = new System.Drawing.Size(820, 170);
            this.dgvAsignacionesG1.Name = "dgvAsignacionesG1";
            this.dgvAsignacionesG1.TabIndex = 4;
            // 
            // frmTurnosG1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 680);
            this.Controls.Add(this.dgvAsignacionesG1);
            this.Controls.Add(this.grpAsignacionTurnoG1);
            this.Controls.Add(this.dgvTurnosG1);
            this.Controls.Add(this.grpTurnoG1);
            this.Controls.Add(this.lblTituloTurnosG1);
            this.Name = "frmTurnosG1";
            this.Text = "Turnos y Planificación";
            this.AutoScroll = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTurnosG1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacionesG1)).EndInit();
            this.grpTurnoG1.ResumeLayout(false);
            this.grpTurnoG1.PerformLayout();
            this.grpAsignacionTurnoG1.ResumeLayout(false);
            this.grpAsignacionTurnoG1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloTurnosG1;
        private System.Windows.Forms.GroupBox grpTurnoG1;
        private System.Windows.Forms.Label lblIdTurnoG1;
        private System.Windows.Forms.TextBox txtIdTurnoG1;
        private System.Windows.Forms.Label lblNombreTurnoG1;
        private System.Windows.Forms.TextBox txtNombreTurnoG1;
        private System.Windows.Forms.Label lblHoraEntradaTurnoG1;
        private System.Windows.Forms.DateTimePicker dtpHoraEntradaTurnoG1;
        private System.Windows.Forms.Label lblHoraSalidaTurnoG1;
        private System.Windows.Forms.DateTimePicker dtpHoraSalidaTurnoG1;
        private System.Windows.Forms.Label lblToleranciaTurnoG1;
        private System.Windows.Forms.TextBox txtToleranciaTurnoG1;
        private System.Windows.Forms.Button btnNuevoTurnoG1;
        private System.Windows.Forms.Button btnGuardarTurnoG1;
        private System.Windows.Forms.Button btnEditarTurnoG1;
        private System.Windows.Forms.Button btnEliminarTurnoG1;
        private System.Windows.Forms.Button btnLimpiarTurnoG1;
        private System.Windows.Forms.DataGridView dgvTurnosG1;
        private System.Windows.Forms.GroupBox grpAsignacionTurnoG1;
        private System.Windows.Forms.Label lblEmpleadoAsignacionG1;
        private System.Windows.Forms.ComboBox cmbEmpleadoAsignacionG1;
        private System.Windows.Forms.Label lblTurnoAsignacionG1;
        private System.Windows.Forms.ComboBox cmbTurnoAsignacionG1;
        private System.Windows.Forms.Label lblFechaAsignacionG1;
        private System.Windows.Forms.DateTimePicker dtpFechaAsignacionG1;
        private System.Windows.Forms.Button btnAsignarTurnoG1;
        private System.Windows.Forms.Button btnEliminarAsignacionG1;
        private System.Windows.Forms.Label lblDesdeAsignacionG1;
        private System.Windows.Forms.DateTimePicker dtpDesdeAsignacionG1;
        private System.Windows.Forms.Label lblHastaAsignacionG1;
        private System.Windows.Forms.DateTimePicker dtpHastaAsignacionG1;
        private System.Windows.Forms.Button btnFiltrarAsignacionesG1;
        private System.Windows.Forms.DataGridView dgvAsignacionesG1;
    }
}
