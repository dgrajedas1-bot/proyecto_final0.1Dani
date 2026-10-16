namespace CapaPresentacionG1
{
    partial class frmLoginG1
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
            this.picLogoG1 = new System.Windows.Forms.PictureBox();
            this.lblTituloG1 = new System.Windows.Forms.Label();
            this.picUsuarioG1 = new System.Windows.Forms.PictureBox();
            this.lblUsuarioG1 = new System.Windows.Forms.Label();
            this.txtUsuarioG1 = new System.Windows.Forms.TextBox();
            this.picContrasenaG1 = new System.Windows.Forms.PictureBox();
            this.lblContrasenaG1 = new System.Windows.Forms.Label();
            this.txtContrasenaG1 = new System.Windows.Forms.TextBox();
            this.btnIniciarSesionG1 = new System.Windows.Forms.Button();
            this.btnSalirG1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuarioG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContrasenaG1)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogoG1
            // 
            this.picLogoG1.Location = new System.Drawing.Point(150, 20);
            this.picLogoG1.Name = "picLogoG1";
            this.picLogoG1.Size = new System.Drawing.Size(120, 85);
            this.picLogoG1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoG1.TabIndex = 0;
            this.picLogoG1.TabStop = false;
            // 
            // lblTituloG1
            // 
            this.lblTituloG1.Location = new System.Drawing.Point(10, 115);
            this.lblTituloG1.Name = "lblTituloG1";
            this.lblTituloG1.Size = new System.Drawing.Size(400, 45);
            this.lblTituloG1.TabIndex = 1;
            this.lblTituloG1.Text = "CONTROL DE ASISTENCIA";
            this.lblTituloG1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picUsuarioG1
            // 
            this.picUsuarioG1.Location = new System.Drawing.Point(50, 180);
            this.picUsuarioG1.Name = "picUsuarioG1";
            this.picUsuarioG1.Size = new System.Drawing.Size(24, 24);
            this.picUsuarioG1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsuarioG1.TabIndex = 2;
            this.picUsuarioG1.TabStop = false;
            // 
            // lblUsuarioG1
            // 
            this.lblUsuarioG1.AutoSize = true;
            this.lblUsuarioG1.Location = new System.Drawing.Point(80, 181);
            this.lblUsuarioG1.Name = "lblUsuarioG1";
            this.lblUsuarioG1.Size = new System.Drawing.Size(70, 21);
            this.lblUsuarioG1.TabIndex = 3;
            this.lblUsuarioG1.Text = "Usuario:";
            // 
            // txtUsuarioG1
            // 
            this.txtUsuarioG1.Location = new System.Drawing.Point(50, 210);
            this.txtUsuarioG1.MaxLength = 50;
            this.txtUsuarioG1.Name = "txtUsuarioG1";
            this.txtUsuarioG1.Size = new System.Drawing.Size(320, 25);
            this.txtUsuarioG1.TabIndex = 4;
            // 
            // picContrasenaG1
            // 
            this.picContrasenaG1.Location = new System.Drawing.Point(50, 250);
            this.picContrasenaG1.Name = "picContrasenaG1";
            this.picContrasenaG1.Size = new System.Drawing.Size(24, 24);
            this.picContrasenaG1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picContrasenaG1.TabIndex = 5;
            this.picContrasenaG1.TabStop = false;
            // 
            // lblContrasenaG1
            // 
            this.lblContrasenaG1.AutoSize = true;
            this.lblContrasenaG1.Location = new System.Drawing.Point(80, 251);
            this.lblContrasenaG1.Name = "lblContrasenaG1";
            this.lblContrasenaG1.Size = new System.Drawing.Size(95, 21);
            this.lblContrasenaG1.TabIndex = 6;
            this.lblContrasenaG1.Text = "Contraseña:";
            // 
            // txtContrasenaG1
            // 
            this.txtContrasenaG1.Location = new System.Drawing.Point(50, 280);
            this.txtContrasenaG1.MaxLength = 100;
            this.txtContrasenaG1.Name = "txtContrasenaG1";
            this.txtContrasenaG1.PasswordChar = '●';
            this.txtContrasenaG1.Size = new System.Drawing.Size(320, 25);
            this.txtContrasenaG1.TabIndex = 7;
            // 
            // btnIniciarSesionG1
            // 
            this.btnIniciarSesionG1.Location = new System.Drawing.Point(50, 330);
            this.btnIniciarSesionG1.Name = "btnIniciarSesionG1";
            this.btnIniciarSesionG1.Size = new System.Drawing.Size(320, 45);
            this.btnIniciarSesionG1.TabIndex = 8;
            this.btnIniciarSesionG1.Text = "Iniciar Sesión";
            this.btnIniciarSesionG1.Click += new System.EventHandler(this.btnIniciarSesionG1_Click);
            // 
            // btnSalirG1
            // 
            this.btnSalirG1.Location = new System.Drawing.Point(50, 385);
            this.btnSalirG1.Name = "btnSalirG1";
            this.btnSalirG1.Size = new System.Drawing.Size(320, 35);
            this.btnSalirG1.TabIndex = 9;
            this.btnSalirG1.Tag = "secundario";
            this.btnSalirG1.Text = "Salir";
            this.btnSalirG1.Click += new System.EventHandler(this.btnSalirG1_Click);
            // 
            // frmLoginG1
            // 
            this.AcceptButton = this.btnIniciarSesionG1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 445);
            this.Controls.Add(this.picLogoG1);
            this.Controls.Add(this.lblTituloG1);
            this.Controls.Add(this.picUsuarioG1);
            this.Controls.Add(this.lblUsuarioG1);
            this.Controls.Add(this.txtUsuarioG1);
            this.Controls.Add(this.picContrasenaG1);
            this.Controls.Add(this.lblContrasenaG1);
            this.Controls.Add(this.txtContrasenaG1);
            this.Controls.Add(this.btnIniciarSesionG1);
            this.Controls.Add(this.btnSalirG1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLoginG1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.Load += new System.EventHandler(this.frmLoginG1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuarioG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picContrasenaG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picLogoG1;
        private System.Windows.Forms.Label lblTituloG1;
        private System.Windows.Forms.PictureBox picUsuarioG1;
        private System.Windows.Forms.Label lblUsuarioG1;
        private System.Windows.Forms.TextBox txtUsuarioG1;
        private System.Windows.Forms.PictureBox picContrasenaG1;
        private System.Windows.Forms.Label lblContrasenaG1;
        private System.Windows.Forms.TextBox txtContrasenaG1;
        private System.Windows.Forms.Button btnIniciarSesionG1;
        private System.Windows.Forms.Button btnSalirG1;
    }
}
