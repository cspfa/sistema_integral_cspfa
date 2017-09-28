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
            this.butonInfoDescuento = new System.Windows.Forms.Button();
            this.gpDescuento = new System.Windows.Forms.GroupBox();
            this.GrabarNovedad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDescuento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpPlanCuota = new System.Windows.Forms.GroupBox();
            this.Seleccion = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.gpDescuento.SuspendLayout();
            this.gpPlanCuota.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.AllowUserToAddRows = false;
            this.dgvPlanes.AllowUserToDeleteRows = false;
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanes.Location = new System.Drawing.Point(12, 58);
            this.dgvPlanes.MultiSelect = false;
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
            this.dgvCuotas.Location = new System.Drawing.Point(12, 54);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuotas.Size = new System.Drawing.Size(692, 150);
            this.dgvCuotas.TabIndex = 1;
            this.dgvCuotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuotas_CellClick);
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
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PAGOS";
            // 
            // Genero_Ingreso
            // 
            this.Genero_Ingreso.Location = new System.Drawing.Point(726, 54);
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
            // butonInfoDescuento
            // 
            this.butonInfoDescuento.Location = new System.Drawing.Point(726, 83);
            this.butonInfoDescuento.Name = "butonInfoDescuento";
            this.butonInfoDescuento.Size = new System.Drawing.Size(238, 23);
            this.butonInfoDescuento.TabIndex = 87;
            this.butonInfoDescuento.Text = "Actualizar Info Descuento";
            this.butonInfoDescuento.UseVisualStyleBackColor = true;
            this.butonInfoDescuento.Visible = false;
            this.butonInfoDescuento.Click += new System.EventHandler(this.butonInfoDescuento_Click);
            // 
            // gpDescuento
            // 
            this.gpDescuento.Controls.Add(this.GrabarNovedad);
            this.gpDescuento.Controls.Add(this.label2);
            this.gpDescuento.Controls.Add(this.cbDescuento);
            this.gpDescuento.Location = new System.Drawing.Point(726, 112);
            this.gpDescuento.Name = "gpDescuento";
            this.gpDescuento.Size = new System.Drawing.Size(311, 92);
            this.gpDescuento.TabIndex = 88;
            this.gpDescuento.TabStop = false;
            this.gpDescuento.Text = "Novedad Descuento";
            this.gpDescuento.Visible = false;
            // 
            // GrabarNovedad
            // 
            this.GrabarNovedad.Location = new System.Drawing.Point(174, 51);
            this.GrabarNovedad.Name = "GrabarNovedad";
            this.GrabarNovedad.Size = new System.Drawing.Size(131, 23);
            this.GrabarNovedad.TabIndex = 89;
            this.GrabarNovedad.Text = "Grabar Novedad";
            this.GrabarNovedad.UseVisualStyleBackColor = true;
            this.GrabarNovedad.Click += new System.EventHandler(this.GrabarNovedad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "OBSERVACION";
            // 
            // cbDescuento
            // 
            this.cbDescuento.FormattingEnabled = true;
            this.cbDescuento.Location = new System.Drawing.Point(137, 24);
            this.cbDescuento.Name = "cbDescuento";
            this.cbDescuento.Size = new System.Drawing.Size(168, 21);
            this.cbDescuento.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "CUOTA YA PAGA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(12, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "CUOTA YA INGRESADA INFO DESCUENTO";
            // 
            // gpPlanCuota
            // 
            this.gpPlanCuota.Controls.Add(this.dgvCuotas);
            this.gpPlanCuota.Controls.Add(this.gpDescuento);
            this.gpPlanCuota.Controls.Add(this.label4);
            this.gpPlanCuota.Controls.Add(this.label1);
            this.gpPlanCuota.Controls.Add(this.Genero_Ingreso);
            this.gpPlanCuota.Controls.Add(this.label3);
            this.gpPlanCuota.Controls.Add(this.butonInfoDescuento);
            this.gpPlanCuota.Location = new System.Drawing.Point(10, 245);
            this.gpPlanCuota.Name = "gpPlanCuota";
            this.gpPlanCuota.Size = new System.Drawing.Size(1043, 274);
            this.gpPlanCuota.TabIndex = 91;
            this.gpPlanCuota.TabStop = false;
            this.gpPlanCuota.Text = "Plan de Cuotas";
            this.gpPlanCuota.Visible = false;
            // 
            // Seleccion
            // 
            this.Seleccion.AutoSize = true;
            this.Seleccion.Location = new System.Drawing.Point(449, 211);
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Size = new System.Drawing.Size(54, 13);
            this.Seleccion.TabIndex = 92;
            this.Seleccion.TabStop = true;
            this.Seleccion.Text = "Seleccion";
            this.Seleccion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Seleccion_LinkClicked);
            // 
            // PlanCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 531);
            this.Controls.Add(this.Seleccion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lbTipoViaje);
            this.Controls.Add(this.lbPLanCuenta);
            this.Controls.Add(this.dgvPlanes);
            this.Controls.Add(this.gpPlanCuota);
            this.Name = "PlanCuenta";
            this.Text = "PlanCuenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.gpDescuento.ResumeLayout(false);
            this.gpDescuento.PerformLayout();
            this.gpPlanCuota.ResumeLayout(false);
            this.gpPlanCuota.PerformLayout();
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
        private System.Windows.Forms.Button butonInfoDescuento;
        private System.Windows.Forms.GroupBox gpDescuento;
        private System.Windows.Forms.Button GrabarNovedad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDescuento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gpPlanCuota;
        private System.Windows.Forms.LinkLabel Seleccion;
    }
}