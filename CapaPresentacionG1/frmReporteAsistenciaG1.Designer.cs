namespace CapaPresentacionG1
{
    partial class frmReporteAsistenciaG1
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
            this.lblTituloReporteG1 = new System.Windows.Forms.Label();
            this.lblDesdeReporteG1 = new System.Windows.Forms.Label();
            this.dtpDesdeReporteG1 = new System.Windows.Forms.DateTimePicker();
            this.lblHastaReporteG1 = new System.Windows.Forms.Label();
            this.dtpHastaReporteG1 = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarReporteG1 = new System.Windows.Forms.Button();
            this.btnLimpiarReporteG1 = new System.Windows.Forms.Button();
            this.btnMarcarAsistenciaReporteG1 = new System.Windows.Forms.Button();
            this.dgvReporteAsistenciaG1 = new System.Windows.Forms.DataGridView();
            this.lblResumenReporteG1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteAsistenciaG1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloReporteG1
            // 
            this.lblTituloReporteG1.AutoSize = true;
            this.lblTituloReporteG1.Location = new System.Drawing.Point(30, 15);
            this.lblTituloReporteG1.Text = "Reporte de Asistencia";
            this.lblTituloReporteG1.Name = "lblTituloReporteG1";
            this.lblTituloReporteG1.TabIndex = 0;
            // 
            // lblDesdeReporteG1
            // 
            this.lblDesdeReporteG1.AutoSize = true;
            this.lblDesdeReporteG1.Location = new System.Drawing.Point(30, 78);
            this.lblDesdeReporteG1.Text = "Desde:";
            this.lblDesdeReporteG1.Name = "lblDesdeReporteG1";
            this.lblDesdeReporteG1.TabIndex = 1;
            // 
            // dtpDesdeReporteG1
            // 
            this.dtpDesdeReporteG1.Location = new System.Drawing.Point(85, 75);
            this.dtpDesdeReporteG1.Size = new System.Drawing.Size(120, 25);
            this.dtpDesdeReporteG1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeReporteG1.Name = "dtpDesdeReporteG1";
            this.dtpDesdeReporteG1.TabIndex = 2;
            // 
            // lblHastaReporteG1
            // 
            this.lblHastaReporteG1.AutoSize = true;
            this.lblHastaReporteG1.Location = new System.Drawing.Point(225, 78);
            this.lblHastaReporteG1.Text = "Hasta:";
            this.lblHastaReporteG1.Name = "lblHastaReporteG1";
            this.lblHastaReporteG1.TabIndex = 3;
            // 
            // dtpHastaReporteG1
            // 
            this.dtpHastaReporteG1.Location = new System.Drawing.Point(280, 75);
            this.dtpHastaReporteG1.Size = new System.Drawing.Size(120, 25);
            this.dtpHastaReporteG1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaReporteG1.Name = "dtpHastaReporteG1";
            this.dtpHastaReporteG1.TabIndex = 4;
            // 
            // btnGenerarReporteG1
            // 
            this.btnGenerarReporteG1.Location = new System.Drawing.Point(420, 70);
            this.btnGenerarReporteG1.Size = new System.Drawing.Size(120, 35);
            this.btnGenerarReporteG1.Text = "Generar";
            this.btnGenerarReporteG1.Name = "btnGenerarReporteG1";
            this.btnGenerarReporteG1.TabIndex = 5;
            this.btnGenerarReporteG1.Click += new System.EventHandler(this.btnGenerarReporteG1_Click);
            // 
            // btnLimpiarReporteG1
            // 
            this.btnLimpiarReporteG1.Location = new System.Drawing.Point(550, 70);
            this.btnLimpiarReporteG1.Size = new System.Drawing.Size(120, 35);
            this.btnLimpiarReporteG1.Text = "Hoy";
            this.btnLimpiarReporteG1.Tag = "secundario";
            this.btnLimpiarReporteG1.Name = "btnLimpiarReporteG1";
            this.btnLimpiarReporteG1.TabIndex = 6;
            this.btnLimpiarReporteG1.Click += new System.EventHandler(this.btnLimpiarReporteG1_Click);
            // 
            // btnMarcarAsistenciaReporteG1
            // 
            this.btnMarcarAsistenciaReporteG1.Location = new System.Drawing.Point(680, 70);
            this.btnMarcarAsistenciaReporteG1.Size = new System.Drawing.Size(170, 35);
            this.btnMarcarAsistenciaReporteG1.Text = "Marcar Asistencia";
            this.btnMarcarAsistenciaReporteG1.Tag = "secundario";
            this.btnMarcarAsistenciaReporteG1.Name = "btnMarcarAsistenciaReporteG1";
            this.btnMarcarAsistenciaReporteG1.TabIndex = 7;
            this.btnMarcarAsistenciaReporteG1.Click += new System.EventHandler(this.btnMarcarAsistenciaReporteG1_Click);
            // 
            // dgvReporteAsistenciaG1
            // 
            this.dgvReporteAsistenciaG1.Location = new System.Drawing.Point(30, 120);
            this.dgvReporteAsistenciaG1.Size = new System.Drawing.Size(820, 400);
            this.dgvReporteAsistenciaG1.Name = "dgvReporteAsistenciaG1";
            this.dgvReporteAsistenciaG1.TabIndex = 8;
            this.dgvReporteAsistenciaG1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvReporteAsistenciaG1_CellFormatting);
            // 
            // lblResumenReporteG1
            // 
            this.lblResumenReporteG1.Location = new System.Drawing.Point(30, 530);
            this.lblResumenReporteG1.Size = new System.Drawing.Size(820, 40);
            this.lblResumenReporteG1.Text = "";
            this.lblResumenReporteG1.Name = "lblResumenReporteG1";
            this.lblResumenReporteG1.TabIndex = 9;
            // 
            // frmReporteAsistenciaG1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 590);
            this.Controls.Add(this.lblResumenReporteG1);
            this.Controls.Add(this.dgvReporteAsistenciaG1);
            this.Controls.Add(this.btnMarcarAsistenciaReporteG1);
            this.Controls.Add(this.btnLimpiarReporteG1);
            this.Controls.Add(this.btnGenerarReporteG1);
            this.Controls.Add(this.dtpHastaReporteG1);
            this.Controls.Add(this.lblHastaReporteG1);
            this.Controls.Add(this.dtpDesdeReporteG1);
            this.Controls.Add(this.lblDesdeReporteG1);
            this.Controls.Add(this.lblTituloReporteG1);
            this.Name = "frmReporteAsistenciaG1";
            this.Text = "Reporte de Asistencia";
            this.AutoScroll = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReporteAsistenciaG1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteAsistenciaG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloReporteG1;
        private System.Windows.Forms.Label lblDesdeReporteG1;
        private System.Windows.Forms.DateTimePicker dtpDesdeReporteG1;
        private System.Windows.Forms.Label lblHastaReporteG1;
        private System.Windows.Forms.DateTimePicker dtpHastaReporteG1;
        private System.Windows.Forms.Button btnGenerarReporteG1;
        private System.Windows.Forms.Button btnLimpiarReporteG1;
        private System.Windows.Forms.Button btnMarcarAsistenciaReporteG1;
        private System.Windows.Forms.DataGridView dgvReporteAsistenciaG1;
        private System.Windows.Forms.Label lblResumenReporteG1;
    }
}
