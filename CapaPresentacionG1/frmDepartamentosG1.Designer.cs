namespace CapaPresentacionG1
{
    partial class frmDepartamentosG1
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
            this.lblTituloDepartamentosG1 = new System.Windows.Forms.Label();
            this.grpNuevoDeptoG1 = new System.Windows.Forms.GroupBox();
            this.lblIdDeptoG1 = new System.Windows.Forms.Label();
            this.txtIdDeptoG1 = new System.Windows.Forms.TextBox();
            this.lblNombreDeptoG1 = new System.Windows.Forms.Label();
            this.txtNombreDeptoG1 = new System.Windows.Forms.TextBox();
            this.btnNuevoDeptoG1 = new System.Windows.Forms.Button();
            this.btnGuardarDeptoG1 = new System.Windows.Forms.Button();
            this.btnEditarDeptoG1 = new System.Windows.Forms.Button();
            this.btnLimpiarDeptoG1 = new System.Windows.Forms.Button();
            this.lblSeccionListaDeptoG1 = new System.Windows.Forms.Label();
            this.dgvDepartamentosG1 = new System.Windows.Forms.DataGridView();
            this.grpEliminarDeptoG1 = new System.Windows.Forms.GroupBox();
            this.lblIdEliminarG1 = new System.Windows.Forms.Label();
            this.txtIdEliminarG1 = new System.Windows.Forms.TextBox();
            this.lblNombreEliminarG1 = new System.Windows.Forms.Label();
            this.txtNombreEliminarG1 = new System.Windows.Forms.TextBox();
            this.btnBuscarDeptoG1 = new System.Windows.Forms.Button();
            this.btnEliminarDeptoG1 = new System.Windows.Forms.Button();
            this.btnLimpiarEliminarG1 = new System.Windows.Forms.Button();
            this.grpNuevoDeptoG1.SuspendLayout();
            this.grpEliminarDeptoG1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentosG1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloDepartamentosG1
            // 
            this.lblTituloDepartamentosG1.AutoSize = true;
            this.lblTituloDepartamentosG1.Location = new System.Drawing.Point(30, 15);
            this.lblTituloDepartamentosG1.Text = "Gestión de Departamentos";
            this.lblTituloDepartamentosG1.Name = "lblTituloDepartamentosG1";
            this.lblTituloDepartamentosG1.TabIndex = 0;
            // 
            // grpNuevoDeptoG1
            // 
            this.grpNuevoDeptoG1.Controls.Add(this.btnLimpiarDeptoG1);
            this.grpNuevoDeptoG1.Controls.Add(this.btnEditarDeptoG1);
            this.grpNuevoDeptoG1.Controls.Add(this.btnGuardarDeptoG1);
            this.grpNuevoDeptoG1.Controls.Add(this.btnNuevoDeptoG1);
            this.grpNuevoDeptoG1.Controls.Add(this.txtNombreDeptoG1);
            this.grpNuevoDeptoG1.Controls.Add(this.lblNombreDeptoG1);
            this.grpNuevoDeptoG1.Controls.Add(this.txtIdDeptoG1);
            this.grpNuevoDeptoG1.Controls.Add(this.lblIdDeptoG1);
            this.grpNuevoDeptoG1.Location = new System.Drawing.Point(30, 70);
            this.grpNuevoDeptoG1.Size = new System.Drawing.Size(800, 130);
            this.grpNuevoDeptoG1.Text = "Nuevo / Editar Departamento";
            this.grpNuevoDeptoG1.Name = "grpNuevoDeptoG1";
            this.grpNuevoDeptoG1.TabIndex = 1;
            // 
            // lblIdDeptoG1
            // 
            this.lblIdDeptoG1.AutoSize = true;
            this.lblIdDeptoG1.Location = new System.Drawing.Point(20, 38);
            this.lblIdDeptoG1.Text = "ID:";
            this.lblIdDeptoG1.Name = "lblIdDeptoG1";
            this.lblIdDeptoG1.TabIndex = 0;
            // 
            // txtIdDeptoG1
            // 
            this.txtIdDeptoG1.Location = new System.Drawing.Point(60, 35);
            this.txtIdDeptoG1.Size = new System.Drawing.Size(80, 25);
            this.txtIdDeptoG1.ReadOnly = true;
            this.txtIdDeptoG1.TabStop = false;
            this.txtIdDeptoG1.Name = "txtIdDeptoG1";
            this.txtIdDeptoG1.TabIndex = 1;
            // 
            // lblNombreDeptoG1
            // 
            this.lblNombreDeptoG1.AutoSize = true;
            this.lblNombreDeptoG1.Location = new System.Drawing.Point(20, 83);
            this.lblNombreDeptoG1.Text = "Nombre:";
            this.lblNombreDeptoG1.Name = "lblNombreDeptoG1";
            this.lblNombreDeptoG1.TabIndex = 2;
            // 
            // txtNombreDeptoG1
            // 
            this.txtNombreDeptoG1.Location = new System.Drawing.Point(90, 80);
            this.txtNombreDeptoG1.Size = new System.Drawing.Size(270, 25);
            this.txtNombreDeptoG1.MaxLength = 100;
            this.txtNombreDeptoG1.Name = "txtNombreDeptoG1";
            this.txtNombreDeptoG1.TabIndex = 3;
            // 
            // btnNuevoDeptoG1
            // 
            this.btnNuevoDeptoG1.Location = new System.Drawing.Point(400, 30);
            this.btnNuevoDeptoG1.Size = new System.Drawing.Size(120, 35);
            this.btnNuevoDeptoG1.Text = "Nuevo";
            this.btnNuevoDeptoG1.Tag = "secundario";
            this.btnNuevoDeptoG1.Name = "btnNuevoDeptoG1";
            this.btnNuevoDeptoG1.TabIndex = 4;
            this.btnNuevoDeptoG1.Click += new System.EventHandler(this.btnNuevoDeptoG1_Click);
            // 
            // btnGuardarDeptoG1
            // 
            this.btnGuardarDeptoG1.Location = new System.Drawing.Point(530, 30);
            this.btnGuardarDeptoG1.Size = new System.Drawing.Size(120, 35);
            this.btnGuardarDeptoG1.Text = "Guardar";
            this.btnGuardarDeptoG1.Name = "btnGuardarDeptoG1";
            this.btnGuardarDeptoG1.TabIndex = 5;
            this.btnGuardarDeptoG1.Click += new System.EventHandler(this.btnGuardarDeptoG1_Click);
            // 
            // btnEditarDeptoG1
            // 
            this.btnEditarDeptoG1.Location = new System.Drawing.Point(660, 30);
            this.btnEditarDeptoG1.Size = new System.Drawing.Size(120, 35);
            this.btnEditarDeptoG1.Text = "Actualizar";
            this.btnEditarDeptoG1.Name = "btnEditarDeptoG1";
            this.btnEditarDeptoG1.TabIndex = 6;
            this.btnEditarDeptoG1.Click += new System.EventHandler(this.btnEditarDeptoG1_Click);
            // 
            // btnLimpiarDeptoG1
            // 
            this.btnLimpiarDeptoG1.Location = new System.Drawing.Point(400, 75);
            this.btnLimpiarDeptoG1.Size = new System.Drawing.Size(120, 35);
            this.btnLimpiarDeptoG1.Text = "Limpiar";
            this.btnLimpiarDeptoG1.Tag = "secundario";
            this.btnLimpiarDeptoG1.Name = "btnLimpiarDeptoG1";
            this.btnLimpiarDeptoG1.TabIndex = 7;
            this.btnLimpiarDeptoG1.Click += new System.EventHandler(this.btnLimpiarDeptoG1_Click);
            // 
            // lblSeccionListaDeptoG1
            // 
            this.lblSeccionListaDeptoG1.AutoSize = true;
            this.lblSeccionListaDeptoG1.Location = new System.Drawing.Point(30, 215);
            this.lblSeccionListaDeptoG1.Text = "Lista de Departamentos";
            this.lblSeccionListaDeptoG1.Name = "lblSeccionListaDeptoG1";
            this.lblSeccionListaDeptoG1.TabIndex = 2;
            // 
            // dgvDepartamentosG1
            // 
            this.dgvDepartamentosG1.Location = new System.Drawing.Point(30, 245);
            this.dgvDepartamentosG1.Size = new System.Drawing.Size(800, 170);
            this.dgvDepartamentosG1.Name = "dgvDepartamentosG1";
            this.dgvDepartamentosG1.TabIndex = 3;
            this.dgvDepartamentosG1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartamentosG1_CellClick);
            // 
            // grpEliminarDeptoG1
            // 
            this.grpEliminarDeptoG1.Controls.Add(this.btnLimpiarEliminarG1);
            this.grpEliminarDeptoG1.Controls.Add(this.btnEliminarDeptoG1);
            this.grpEliminarDeptoG1.Controls.Add(this.btnBuscarDeptoG1);
            this.grpEliminarDeptoG1.Controls.Add(this.txtNombreEliminarG1);
            this.grpEliminarDeptoG1.Controls.Add(this.lblNombreEliminarG1);
            this.grpEliminarDeptoG1.Controls.Add(this.txtIdEliminarG1);
            this.grpEliminarDeptoG1.Controls.Add(this.lblIdEliminarG1);
            this.grpEliminarDeptoG1.Location = new System.Drawing.Point(30, 430);
            this.grpEliminarDeptoG1.Size = new System.Drawing.Size(800, 130);
            this.grpEliminarDeptoG1.Text = "Buscar / Eliminar Departamento";
            this.grpEliminarDeptoG1.Name = "grpEliminarDeptoG1";
            this.grpEliminarDeptoG1.TabIndex = 4;
            // 
            // lblIdEliminarG1
            // 
            this.lblIdEliminarG1.AutoSize = true;
            this.lblIdEliminarG1.Location = new System.Drawing.Point(20, 38);
            this.lblIdEliminarG1.Text = "ID:";
            this.lblIdEliminarG1.Name = "lblIdEliminarG1";
            this.lblIdEliminarG1.TabIndex = 0;
            // 
            // txtIdEliminarG1
            // 
            this.txtIdEliminarG1.Location = new System.Drawing.Point(60, 35);
            this.txtIdEliminarG1.Size = new System.Drawing.Size(80, 25);
            this.txtIdEliminarG1.MaxLength = 9;
            this.txtIdEliminarG1.Name = "txtIdEliminarG1";
            this.txtIdEliminarG1.TabIndex = 1;
            this.txtIdEliminarG1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdEliminarG1_KeyPress);
            // 
            // lblNombreEliminarG1
            // 
            this.lblNombreEliminarG1.AutoSize = true;
            this.lblNombreEliminarG1.Location = new System.Drawing.Point(20, 83);
            this.lblNombreEliminarG1.Text = "Nombre:";
            this.lblNombreEliminarG1.Name = "lblNombreEliminarG1";
            this.lblNombreEliminarG1.TabIndex = 2;
            // 
            // txtNombreEliminarG1
            // 
            this.txtNombreEliminarG1.Location = new System.Drawing.Point(90, 80);
            this.txtNombreEliminarG1.Size = new System.Drawing.Size(270, 25);
            this.txtNombreEliminarG1.ReadOnly = true;
            this.txtNombreEliminarG1.TabStop = false;
            this.txtNombreEliminarG1.Name = "txtNombreEliminarG1";
            this.txtNombreEliminarG1.TabIndex = 3;
            // 
            // btnBuscarDeptoG1
            // 
            this.btnBuscarDeptoG1.Location = new System.Drawing.Point(400, 30);
            this.btnBuscarDeptoG1.Size = new System.Drawing.Size(120, 35);
            this.btnBuscarDeptoG1.Text = "Buscar";
            this.btnBuscarDeptoG1.Name = "btnBuscarDeptoG1";
            this.btnBuscarDeptoG1.TabIndex = 4;
            this.btnBuscarDeptoG1.Click += new System.EventHandler(this.btnBuscarDeptoG1_Click);
            // 
            // btnEliminarDeptoG1
            // 
            this.btnEliminarDeptoG1.Location = new System.Drawing.Point(530, 30);
            this.btnEliminarDeptoG1.Size = new System.Drawing.Size(120, 35);
            this.btnEliminarDeptoG1.Text = "Eliminar";
            this.btnEliminarDeptoG1.Tag = "peligro";
            this.btnEliminarDeptoG1.Name = "btnEliminarDeptoG1";
            this.btnEliminarDeptoG1.TabIndex = 5;
            this.btnEliminarDeptoG1.Click += new System.EventHandler(this.btnEliminarDeptoG1_Click);
            // 
            // btnLimpiarEliminarG1
            // 
            this.btnLimpiarEliminarG1.Location = new System.Drawing.Point(400, 75);
            this.btnLimpiarEliminarG1.Size = new System.Drawing.Size(120, 35);
            this.btnLimpiarEliminarG1.Text = "Limpiar";
            this.btnLimpiarEliminarG1.Tag = "secundario";
            this.btnLimpiarEliminarG1.Name = "btnLimpiarEliminarG1";
            this.btnLimpiarEliminarG1.TabIndex = 6;
            this.btnLimpiarEliminarG1.Click += new System.EventHandler(this.btnLimpiarEliminarG1_Click);
            // 
            // frmDepartamentosG1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 580);
            this.Controls.Add(this.grpEliminarDeptoG1);
            this.Controls.Add(this.dgvDepartamentosG1);
            this.Controls.Add(this.lblSeccionListaDeptoG1);
            this.Controls.Add(this.grpNuevoDeptoG1);
            this.Controls.Add(this.lblTituloDepartamentosG1);
            this.Name = "frmDepartamentosG1";
            this.Text = "Gestión de Departamentos";
            this.AutoScroll = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDepartamentosG1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentosG1)).EndInit();
            this.grpNuevoDeptoG1.ResumeLayout(false);
            this.grpNuevoDeptoG1.PerformLayout();
            this.grpEliminarDeptoG1.ResumeLayout(false);
            this.grpEliminarDeptoG1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloDepartamentosG1;
        private System.Windows.Forms.GroupBox grpNuevoDeptoG1;
        private System.Windows.Forms.Label lblIdDeptoG1;
        private System.Windows.Forms.TextBox txtIdDeptoG1;
        private System.Windows.Forms.Label lblNombreDeptoG1;
        private System.Windows.Forms.TextBox txtNombreDeptoG1;
        private System.Windows.Forms.Button btnNuevoDeptoG1;
        private System.Windows.Forms.Button btnGuardarDeptoG1;
        private System.Windows.Forms.Button btnEditarDeptoG1;
        private System.Windows.Forms.Button btnLimpiarDeptoG1;
        private System.Windows.Forms.Label lblSeccionListaDeptoG1;
        private System.Windows.Forms.DataGridView dgvDepartamentosG1;
        private System.Windows.Forms.GroupBox grpEliminarDeptoG1;
        private System.Windows.Forms.Label lblIdEliminarG1;
        private System.Windows.Forms.TextBox txtIdEliminarG1;
        private System.Windows.Forms.Label lblNombreEliminarG1;
        private System.Windows.Forms.TextBox txtNombreEliminarG1;
        private System.Windows.Forms.Button btnBuscarDeptoG1;
        private System.Windows.Forms.Button btnEliminarDeptoG1;
        private System.Windows.Forms.Button btnLimpiarEliminarG1;
    }
}
