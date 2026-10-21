namespace CapaPresentacionG1
{
    partial class frmMarcajeG1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarcajeG1));
            this.lblTituloMarcajeG1 = new System.Windows.Forms.Label();
            this.lblRelojG1 = new System.Windows.Forms.Label();
            this.lblCodigoEmpleadoG1 = new System.Windows.Forms.Label();
            this.txtCodigoEmpleadoG1 = new System.Windows.Forms.TextBox();
            this.btnRegistrarIngresoG1 = new System.Windows.Forms.Button();
            this.btnRegistrarSalidaG1 = new System.Windows.Forms.Button();
            this.lblResultadoG1 = new System.Windows.Forms.Label();
            this.btnCerrarG1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTituloMarcajeG1
            // 
            this.lblTituloMarcajeG1.Location = new System.Drawing.Point(17, 13);
            this.lblTituloMarcajeG1.Name = "lblTituloMarcajeG1";
            this.lblTituloMarcajeG1.Size = new System.Drawing.Size(377, 35);
            this.lblTituloMarcajeG1.TabIndex = 0;
            this.lblTituloMarcajeG1.Text = "Marcar Asistencia";
            this.lblTituloMarcajeG1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRelojG1
            // 
            this.lblRelojG1.Location = new System.Drawing.Point(17, 52);
            this.lblRelojG1.Name = "lblRelojG1";
            this.lblRelojG1.Size = new System.Drawing.Size(377, 26);
            this.lblRelojG1.TabIndex = 1;
            this.lblRelojG1.Text = "00:00:00";
            this.lblRelojG1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodigoEmpleadoG1
            // 
            this.lblCodigoEmpleadoG1.AutoSize = true;
            this.lblCodigoEmpleadoG1.Location = new System.Drawing.Point(51, 95);
            this.lblCodigoEmpleadoG1.Name = "lblCodigoEmpleadoG1";
            this.lblCodigoEmpleadoG1.Size = new System.Drawing.Size(148, 13);
            this.lblCodigoEmpleadoG1.TabIndex = 2;
            this.lblCodigoEmpleadoG1.Text = "Código de empleado (ej. 001):";
            // 
            // txtCodigoEmpleadoG1
            // 
            this.txtCodigoEmpleadoG1.Location = new System.Drawing.Point(51, 120);
            this.txtCodigoEmpleadoG1.MaxLength = 3;
            this.txtCodigoEmpleadoG1.Name = "txtCodigoEmpleadoG1";
            this.txtCodigoEmpleadoG1.Size = new System.Drawing.Size(309, 20);
            this.txtCodigoEmpleadoG1.TabIndex = 3;
            this.txtCodigoEmpleadoG1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoEmpleadoG1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoEmpleadoG1_KeyPress);
            // 
            // btnRegistrarIngresoG1
            // 
            this.btnRegistrarIngresoG1.Location = new System.Drawing.Point(51, 160);
            this.btnRegistrarIngresoG1.Name = "btnRegistrarIngresoG1";
            this.btnRegistrarIngresoG1.Size = new System.Drawing.Size(146, 39);
            this.btnRegistrarIngresoG1.TabIndex = 4;
            this.btnRegistrarIngresoG1.Text = "Registrar Ingreso";
            this.btnRegistrarIngresoG1.Click += new System.EventHandler(this.btnRegistrarIngresoG1_Click);
            // 
            // btnRegistrarSalidaG1
            // 
            this.btnRegistrarSalidaG1.Location = new System.Drawing.Point(214, 160);
            this.btnRegistrarSalidaG1.Name = "btnRegistrarSalidaG1";
            this.btnRegistrarSalidaG1.Size = new System.Drawing.Size(146, 39);
            this.btnRegistrarSalidaG1.TabIndex = 5;
            this.btnRegistrarSalidaG1.Text = "Registrar Salida";
            this.btnRegistrarSalidaG1.Click += new System.EventHandler(this.btnRegistrarSalidaG1_Click);
            // 
            // lblResultadoG1
            // 
            this.lblResultadoG1.Location = new System.Drawing.Point(26, 212);
            this.lblResultadoG1.Name = "lblResultadoG1";
            this.lblResultadoG1.Size = new System.Drawing.Size(360, 78);
            this.lblResultadoG1.TabIndex = 6;
            this.lblResultadoG1.Text = "Ingrese su código y presione el botón correspondiente.";
            this.lblResultadoG1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrarG1
            // 
            this.btnCerrarG1.Location = new System.Drawing.Point(137, 299);
            this.btnCerrarG1.Name = "btnCerrarG1";
            this.btnCerrarG1.Size = new System.Drawing.Size(137, 30);
            this.btnCerrarG1.TabIndex = 7;
            this.btnCerrarG1.Tag = "secundario";
            this.btnCerrarG1.Text = "Cerrar";
            this.btnCerrarG1.Click += new System.EventHandler(this.btnCerrarG1_Click);
            // 
            // frmMarcajeG1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 342);
            this.Controls.Add(this.btnCerrarG1);
            this.Controls.Add(this.lblResultadoG1);
            this.Controls.Add(this.btnRegistrarSalidaG1);
            this.Controls.Add(this.btnRegistrarIngresoG1);
            this.Controls.Add(this.txtCodigoEmpleadoG1);
            this.Controls.Add(this.lblCodigoEmpleadoG1);
            this.Controls.Add(this.lblRelojG1);
            this.Controls.Add(this.lblTituloMarcajeG1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMarcajeG1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marcar Asistencia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMarcajeG1_FormClosed);
            this.Load += new System.EventHandler(this.frmMarcajeG1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloMarcajeG1;
        private System.Windows.Forms.Label lblRelojG1;
        private System.Windows.Forms.Label lblCodigoEmpleadoG1;
        private System.Windows.Forms.TextBox txtCodigoEmpleadoG1;
        private System.Windows.Forms.Button btnRegistrarIngresoG1;
        private System.Windows.Forms.Button btnRegistrarSalidaG1;
        private System.Windows.Forms.Label lblResultadoG1;
        private System.Windows.Forms.Button btnCerrarG1;
    }
}
