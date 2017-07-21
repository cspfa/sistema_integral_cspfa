namespace SOCIOS.bono
{
    partial class BonoOdontologico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BonoOdontologico));
            this.gpOdonto = new System.Windows.Forms.GroupBox();
            this.tbMonto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddTrat = new System.Windows.Forms.Button();
            this.cbTratamiento = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbEspecialidad = new System.Windows.Forms.Label();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEdad = new System.Windows.Forms.Label();
            this.lbNacimiento = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.FechaApto = new System.Windows.Forms.Label();
            this.btnPago = new System.Windows.Forms.Button();
            this.Grabar = new System.Windows.Forms.Button();
            this.gvTratamientos = new System.Windows.Forms.DataGridView();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.NuevoBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbSaldoTotal = new System.Windows.Forms.Label();
            this.bntImprimir = new System.Windows.Forms.Button();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbFormaPago = new System.Windows.Forms.Label();
            this.Reiniciar = new System.Windows.Forms.Button();
            this.AnularBono = new System.Windows.Forms.Button();
            this.gpOdonto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTratamientos)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpOdonto
            // 
            this.gpOdonto.Controls.Add(this.tbMonto);
            this.gpOdonto.Controls.Add(this.label8);
            this.gpOdonto.Controls.Add(this.btnAddTrat);
            this.gpOdonto.Controls.Add(this.cbTratamiento);
            this.gpOdonto.Controls.Add(this.label4);
            this.gpOdonto.Controls.Add(this.lbEspecialidad);
            this.gpOdonto.Location = new System.Drawing.Point(398, 376);
            this.gpOdonto.Name = "gpOdonto";
            this.gpOdonto.Size = new System.Drawing.Size(392, 116);
            this.gpOdonto.TabIndex = 99;
            this.gpOdonto.TabStop = false;
            this.gpOdonto.Text = "Tratamientos Odontológicos";
            this.gpOdonto.Visible = false;
            this.gpOdonto.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tbMonto
            // 
            this.tbMonto.Location = new System.Drawing.Point(113, 84);
            this.tbMonto.Name = "tbMonto";
            this.tbMonto.Size = new System.Drawing.Size(38, 20);
            this.tbMonto.TabIndex = 87;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 86;
            this.label8.Text = "VALOR";
            // 
            // btnAddTrat
            // 
            this.btnAddTrat.Location = new System.Drawing.Point(304, 86);
            this.btnAddTrat.Name = "btnAddTrat";
            this.btnAddTrat.Size = new System.Drawing.Size(75, 23);
            this.btnAddTrat.TabIndex = 84;
            this.btnAddTrat.Text = "Agregar";
            this.btnAddTrat.UseVisualStyleBackColor = true;
            this.btnAddTrat.Click += new System.EventHandler(this.btnAddTrat_Click);
            // 
            // cbTratamiento
            // 
            this.cbTratamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTratamiento.FormattingEnabled = true;
            this.cbTratamiento.Location = new System.Drawing.Point(113, 53);
            this.cbTratamiento.Name = "cbTratamiento";
            this.cbTratamiento.Size = new System.Drawing.Size(266, 21);
            this.cbTratamiento.TabIndex = 82;
            this.cbTratamiento.SelectedIndexChanged += new System.EventHandler(this.cbTratamiento_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "TRATAMIENTO";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbEspecialidad
            // 
            this.lbEspecialidad.AutoSize = true;
            this.lbEspecialidad.Location = new System.Drawing.Point(25, 27);
            this.lbEspecialidad.Name = "lbEspecialidad";
            this.lbEspecialidad.Size = new System.Drawing.Size(76, 13);
            this.lbEspecialidad.TabIndex = 73;
            this.lbEspecialidad.Text = "PRESTACION";
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(397, 567);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(265, 21);
            this.cbEspecialidad.TabIndex = 86;
            this.cbEspecialidad.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "EDAD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 83;
            this.label3.Text = "FECHA DE NACIMIENTO";
            // 
            // lbEdad
            // 
            this.lbEdad.AutoSize = true;
            this.lbEdad.Location = new System.Drawing.Point(117, 354);
            this.lbEdad.Name = "lbEdad";
            this.lbEdad.Size = new System.Drawing.Size(32, 13);
            this.lbEdad.TabIndex = 80;
            this.lbEdad.Text = "Edad";
            // 
            // lbNacimiento
            // 
            this.lbNacimiento.AutoSize = true;
            this.lbNacimiento.Location = new System.Drawing.Point(169, 354);
            this.lbNacimiento.Name = "lbNacimiento";
            this.lbNacimiento.Size = new System.Drawing.Size(90, 13);
            this.lbNacimiento.TabIndex = 79;
            this.lbNacimiento.Text = "FechaNacimiento";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(314, 354);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(54, 13);
            this.lbNombre.TabIndex = 78;
            this.lbNombre.Text = "NOMBRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "PACIENTE";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(14, 350);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(88, 20);
            this.dpFecha.TabIndex = 76;
            // 
            // FechaApto
            // 
            this.FechaApto.AutoSize = true;
            this.FechaApto.Location = new System.Drawing.Point(13, 335);
            this.FechaApto.Name = "FechaApto";
            this.FechaApto.Size = new System.Drawing.Size(45, 13);
            this.FechaApto.TabIndex = 75;
            this.FechaApto.Text = "FECHA ";
            // 
            // btnPago
            // 
            this.btnPago.Location = new System.Drawing.Point(14, 567);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(75, 23);
            this.btnPago.TabIndex = 101;
            this.btnPago.Text = "Pago Bono";
            this.btnPago.UseVisualStyleBackColor = true;
            this.btnPago.Visible = false;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // Grabar
            // 
            this.Grabar.Location = new System.Drawing.Point(105, 567);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(92, 23);
            this.Grabar.TabIndex = 100;
            this.Grabar.Text = "Imprimir Bono";
            this.Grabar.UseVisualStyleBackColor = true;
            this.Grabar.Visible = false;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // gvTratamientos
            // 
            this.gvTratamientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTratamientos.Location = new System.Drawing.Point(14, 376);
            this.gvTratamientos.Name = "gvTratamientos";
            this.gvTratamientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTratamientos.Size = new System.Drawing.Size(377, 116);
            this.gvTratamientos.TabIndex = 85;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoBank,
            this.toolStripSeparator13,
            this.CancelarBank});
            this.toolStrip4.Location = new System.Drawing.Point(14, 494);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(282, 25);
            this.toolStrip4.TabIndex = 102;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // NuevoBank
            // 
            this.NuevoBank.Image = ((System.Drawing.Image)(resources.GetObject("NuevoBank.Image")));
            this.NuevoBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuevoBank.Name = "NuevoBank";
            this.NuevoBank.Size = new System.Drawing.Size(141, 22);
            this.NuevoBank.Text = "Agregar Tratamientos";
            this.NuevoBank.Click += new System.EventHandler(this.NuevoBank_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // CancelarBank
            // 
            this.CancelarBank.Image = ((System.Drawing.Image)(resources.GetObject("CancelarBank.Image")));
            this.CancelarBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarBank.Name = "CancelarBank";
            this.CancelarBank.Size = new System.Drawing.Size(132, 22);
            this.CancelarBank.Text = "Borrar Seleccionado";
            this.CancelarBank.Click += new System.EventHandler(this.CancelarBank_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(349, 501);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(42, 13);
            this.lbTotal.TabIndex = 104;
            this.lbTotal.Text = "TOTAL";
            this.lbTotal.Visible = false;
            // 
            // lbSaldoTotal
            // 
            this.lbSaldoTotal.AutoSize = true;
            this.lbSaldoTotal.Location = new System.Drawing.Point(359, 245);
            this.lbSaldoTotal.Name = "lbSaldoTotal";
            this.lbSaldoTotal.Size = new System.Drawing.Size(0, 13);
            this.lbSaldoTotal.TabIndex = 103;
            // 
            // bntImprimir
            // 
            this.bntImprimir.Location = new System.Drawing.Point(213, 567);
            this.bntImprimir.Name = "bntImprimir";
            this.bntImprimir.Size = new System.Drawing.Size(75, 23);
            this.bntImprimir.TabIndex = 105;
            this.bntImprimir.Text = "Re-Imprimir";
            this.bntImprimir.UseVisualStyleBackColor = true;
            this.bntImprimir.Visible = false;
            this.bntImprimir.Click += new System.EventHandler(this.bntImprimir_Click);
            // 
            // tbObs
            // 
            this.tbObs.Location = new System.Drawing.Point(14, 521);
            this.tbObs.Multiline = true;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(779, 40);
            this.tbObs.TabIndex = 106;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(696, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 107;
            this.label7.Text = "OBSERVACIONES";
            // 
            // lbFormaPago
            // 
            this.lbFormaPago.AutoSize = true;
            this.lbFormaPago.Location = new System.Drawing.Point(329, 490);
            this.lbFormaPago.Name = "lbFormaPago";
            this.lbFormaPago.Size = new System.Drawing.Size(0, 13);
            this.lbFormaPago.TabIndex = 108;
            // 
            // Reiniciar
            // 
            this.Reiniciar.Location = new System.Drawing.Point(676, 567);
            this.Reiniciar.Name = "Reiniciar";
            this.Reiniciar.Size = new System.Drawing.Size(114, 23);
            this.Reiniciar.TabIndex = 109;
            this.Reiniciar.Text = "Reiniciar Pantalla";
            this.Reiniciar.UseVisualStyleBackColor = true;
            this.Reiniciar.Click += new System.EventHandler(this.Reiniciar_Click);
            // 
            // AnularBono
            // 
            this.AnularBono.Location = new System.Drawing.Point(304, 567);
            this.AnularBono.Name = "AnularBono";
            this.AnularBono.Size = new System.Drawing.Size(75, 23);
            this.AnularBono.TabIndex = 110;
            this.AnularBono.Text = "Anular";
            this.AnularBono.UseVisualStyleBackColor = true;
            this.AnularBono.Visible = false;
            this.AnularBono.Click += new System.EventHandler(this.AnularBono_Click);
            // 
            // BonoOdontologico
            // 
            this.ClientSize = new System.Drawing.Size(805, 596);
            this.Controls.Add(this.AnularBono);
            this.Controls.Add(this.Reiniciar);
            this.Controls.Add(this.lbFormaPago);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbObs);
            this.Controls.Add(this.cbEspecialidad);
            this.Controls.Add(this.bntImprimir);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.lbSaldoTotal);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.gvTratamientos);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.dpFecha);
            this.Controls.Add(this.FechaApto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gpOdonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.lbEdad);
            this.Controls.Add(this.lbNacimiento);
            this.Name = "BonoOdontologico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gpOdonto.ResumeLayout(false);
            this.gpOdonto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTratamientos)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpOdonto;
        private System.Windows.Forms.Label lbEspecialidad;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label FechaApto;
        private System.Windows.Forms.Label lbNacimiento;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbEdad;
        private System.Windows.Forms.ComboBox cbTratamiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Grabar;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.DataGridView gvTratamientos;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton NuevoBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.Button btnAddTrat;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbSaldoTotal;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.Button bntImprimir;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbFormaPago;
        private System.Windows.Forms.Button Reiniciar;
        private System.Windows.Forms.Button AnularBono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMonto;


    }
}
