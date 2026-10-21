namespace CapaPresentacionG1
{
    partial class frmPrincipalG1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipalG1));
            this.pnlEncabezadoG1 = new System.Windows.Forms.Panel();
            this.lblNombreUsuarioG1 = new System.Windows.Forms.Label();
            this.lblSistemaG1 = new System.Windows.Forms.Label();
            this.pnlMenuG1 = new System.Windows.Forms.Panel();
            this.btnInicioG1 = new System.Windows.Forms.Button();
            this.btnEmpleadosG1 = new System.Windows.Forms.Button();
            this.btnTurnosG1 = new System.Windows.Forms.Button();
            this.btnDepartamentosG1 = new System.Windows.Forms.Button();
            this.btnAsistenciaG1 = new System.Windows.Forms.Button();
            this.btnCerrarSesionG1 = new System.Windows.Forms.Button();
            this.pnlContenedorG1 = new System.Windows.Forms.Panel();
            this.pnlEncabezadoG1.SuspendLayout();
            this.pnlMenuG1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezadoG1
            // 
            this.pnlEncabezadoG1.Controls.Add(this.lblNombreUsuarioG1);
            this.pnlEncabezadoG1.Controls.Add(this.lblSistemaG1);
            this.pnlEncabezadoG1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezadoG1.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezadoG1.Name = "pnlEncabezadoG1";
            this.pnlEncabezadoG1.Size = new System.Drawing.Size(943, 39);
            this.pnlEncabezadoG1.TabIndex = 0;
            // 
            // lblNombreUsuarioG1
            // 
            this.lblNombreUsuarioG1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreUsuarioG1.Location = new System.Drawing.Point(600, 10);
            this.lblNombreUsuarioG1.Name = "lblNombreUsuarioG1";
            this.lblNombreUsuarioG1.Size = new System.Drawing.Size(330, 18);
            this.lblNombreUsuarioG1.TabIndex = 1;
            this.lblNombreUsuarioG1.Text = "Nombre de Empleado";
            this.lblNombreUsuarioG1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSistemaG1
            // 
            this.lblSistemaG1.AutoSize = true;
            this.lblSistemaG1.Location = new System.Drawing.Point(13, 10);
            this.lblSistemaG1.Name = "lblSistemaG1";
            this.lblSistemaG1.Size = new System.Drawing.Size(163, 13);
            this.lblSistemaG1.TabIndex = 0;
            this.lblSistemaG1.Text = "GRUPO 1 · Control de Asistencia";
            // 
            // pnlMenuG1
            // 
            this.pnlMenuG1.Controls.Add(this.btnInicioG1);
            this.pnlMenuG1.Controls.Add(this.btnEmpleadosG1);
            this.pnlMenuG1.Controls.Add(this.btnTurnosG1);
            this.pnlMenuG1.Controls.Add(this.btnDepartamentosG1);
            this.pnlMenuG1.Controls.Add(this.btnAsistenciaG1);
            this.pnlMenuG1.Controls.Add(this.btnCerrarSesionG1);
            this.pnlMenuG1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuG1.Location = new System.Drawing.Point(0, 39);
            this.pnlMenuG1.Name = "pnlMenuG1";
            this.pnlMenuG1.Size = new System.Drawing.Size(171, 568);
            this.pnlMenuG1.TabIndex = 1;
            // 
            // btnInicioG1
            // 
            this.btnInicioG1.Location = new System.Drawing.Point(0, 17);
            this.btnInicioG1.Name = "btnInicioG1";
            this.btnInicioG1.Size = new System.Drawing.Size(171, 39);
            this.btnInicioG1.TabIndex = 0;
            this.btnInicioG1.Text = "   Inicio";
            this.btnInicioG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicioG1.Click += new System.EventHandler(this.btnInicioG1_Click);
            // 
            // btnEmpleadosG1
            // 
            this.btnEmpleadosG1.Location = new System.Drawing.Point(0, 61);
            this.btnEmpleadosG1.Name = "btnEmpleadosG1";
            this.btnEmpleadosG1.Size = new System.Drawing.Size(171, 39);
            this.btnEmpleadosG1.TabIndex = 1;
            this.btnEmpleadosG1.Text = "   Empleados";
            this.btnEmpleadosG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleadosG1.Click += new System.EventHandler(this.btnEmpleadosG1_Click);
            // 
            // btnTurnosG1
            // 
            this.btnTurnosG1.Location = new System.Drawing.Point(0, 104);
            this.btnTurnosG1.Name = "btnTurnosG1";
            this.btnTurnosG1.Size = new System.Drawing.Size(171, 39);
            this.btnTurnosG1.TabIndex = 2;
            this.btnTurnosG1.Text = "   Turnos";
            this.btnTurnosG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTurnosG1.Click += new System.EventHandler(this.btnTurnosG1_Click);
            // 
            // btnDepartamentosG1
            // 
            this.btnDepartamentosG1.Location = new System.Drawing.Point(0, 147);
            this.btnDepartamentosG1.Name = "btnDepartamentosG1";
            this.btnDepartamentosG1.Size = new System.Drawing.Size(171, 39);
            this.btnDepartamentosG1.TabIndex = 3;
            this.btnDepartamentosG1.Text = "   Departamentos";
            this.btnDepartamentosG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartamentosG1.Click += new System.EventHandler(this.btnDepartamentosG1_Click);
            // 
            // btnAsistenciaG1
            // 
            this.btnAsistenciaG1.Location = new System.Drawing.Point(0, 191);
            this.btnAsistenciaG1.Name = "btnAsistenciaG1";
            this.btnAsistenciaG1.Size = new System.Drawing.Size(171, 39);
            this.btnAsistenciaG1.TabIndex = 4;
            this.btnAsistenciaG1.Text = "   Asistencia";
            this.btnAsistenciaG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsistenciaG1.Click += new System.EventHandler(this.btnAsistenciaG1_Click);
            // 
            // btnCerrarSesionG1
            // 
            this.btnCerrarSesionG1.Location = new System.Drawing.Point(0, 520);
            this.btnCerrarSesionG1.Name = "btnCerrarSesionG1";
            this.btnCerrarSesionG1.Size = new System.Drawing.Size(171, 39);
            this.btnCerrarSesionG1.TabIndex = 5;
            this.btnCerrarSesionG1.Text = "   Cerrar Sesión";
            this.btnCerrarSesionG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesionG1.Click += new System.EventHandler(this.btnCerrarSesionG1_Click);
            // 
            // pnlContenedorG1
            // 
            this.pnlContenedorG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorG1.Location = new System.Drawing.Point(171, 39);
            this.pnlContenedorG1.Name = "pnlContenedorG1";
            this.pnlContenedorG1.Size = new System.Drawing.Size(772, 568);
            this.pnlContenedorG1.TabIndex = 2;
            // 
            // frmPrincipalG1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 607);
            this.Controls.Add(this.pnlContenedorG1);
            this.Controls.Add(this.pnlMenuG1);
            this.Controls.Add(this.pnlEncabezadoG1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(859, 595);
            this.Name = "frmPrincipalG1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Control de Asistencia - RRHH";
            this.Load += new System.EventHandler(this.frmPrincipalG1_Load);
            this.pnlEncabezadoG1.ResumeLayout(false);
            this.pnlEncabezadoG1.PerformLayout();
            this.pnlMenuG1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezadoG1;
        private System.Windows.Forms.Label lblSistemaG1;
        private System.Windows.Forms.Label lblNombreUsuarioG1;
        private System.Windows.Forms.Panel pnlMenuG1;
        private System.Windows.Forms.Button btnInicioG1;
        private System.Windows.Forms.Button btnEmpleadosG1;
        private System.Windows.Forms.Button btnTurnosG1;
        private System.Windows.Forms.Button btnDepartamentosG1;
        private System.Windows.Forms.Button btnAsistenciaG1;
        private System.Windows.Forms.Button btnCerrarSesionG1;
        private System.Windows.Forms.Panel pnlContenedorG1;
    }
}
