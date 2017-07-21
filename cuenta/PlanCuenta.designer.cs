namespace SOCIOS.CuentaSocio
{
    partial class PlanCuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            this.lbPLanCuenta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Genero_Ingreso = new System.Windows.Forms.Button();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lbTipoViaje = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.AllowUserToAddRows = false;
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanes.Location = new System.Drawing.Point(12, 70);
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanes.Size = new System.Drawing.Size(1025, 150);
            this.dgvPlanes.TabIndex = 0;
            this.dgvPlanes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanes_CellContentClick);
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.AllowUserToAddRows = false;
            this.dgvCuotas.AllowUserToDeleteRows = false;
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Location = new System.Drawing.Point(12, 261);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuotas.Size = new System.Drawing.Size(692, 150);
            this.dgvCuotas.TabIndex = 1;
            this.dgvCuotas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuotas_CellContentClick);
            // 
            // lbPLanCuenta
            // 
            this.lbPLanCuenta.AutoSize = true;
            this.lbPLanCuenta.Location = new System.Drawing.Point(12, 25);
            this.lbPLanCuenta.Name = "lbPLanCuenta";
            this.lbPLanCuenta.Size = new System.Drawing.Size(114, 13);
            this.lbPLanCuenta.TabIndex = 2;
            this.lbPLanCuenta.Text = "PLANES DE CUENTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PAGOS";
            // 
            // Genero_Ingreso
            // 
            this.Genero_Ingreso.Location = new System.Drawing.Point(780, 315);
            this.Genero_Ingreso.Name = "Genero_Ingreso";
            this.Genero_Ingreso.Size = new System.Drawing.Size(131, 23);
            this.Genero_Ingreso.TabIndex = 4;
            this.Genero_Ingreso.Text = "Generar Ingreso";
            this.Genero_Ingreso.UseVisualStyleBackColor = true;
            this.Genero_Ingreso.Visible = false;
            this.Genero_Ingreso.Click += new System.EventHandler(this.Genero_Ingreso_Click_1);
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(707, 29);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(157, 21);
            this.cbTipo.TabIndex = 85;
            // 
            // lbTipoViaje
            // 
            this.lbTipoViaje.AutoSize = true;
            this.lbTipoViaje.Location = new System.Drawing.Point(622, 32);
            this.lbTipoViaje.Name = "lbTipoViaje";
            this.lbTipoViaje.Size = new System.Drawing.Size(28, 13);
            this.lbTipoViaje.TabIndex = 84;
            this.lbTipoViaje.Text = "Tipo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(906, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 86;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PlanCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 429);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lbTipoViaje);
            this.Controls.Add(this.Genero_Ingreso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPLanCuenta);
            this.Controls.Add(this.dgvCuotas);
            this.Controls.Add(this.dgvPlanes);
            this.Name = "PlanCuenta";
            this.Text = "PlanCuenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.DataGridView dgvCuotas;
        private System.Windows.Forms.Label lbPLanCuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Genero_Ingreso;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lbTipoViaje;
        private System.Windows.Forms.Button button1;
    }
}