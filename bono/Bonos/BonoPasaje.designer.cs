namespace SOCIOS.bono
{
    partial class BonoPasaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BonoPasaje));
            this.pagBono = new System.Windows.Forms.Button();
            this.gpPasaje = new System.Windows.Forms.GroupBox();
            this.chkVuelta = new System.Windows.Forms.CheckBox();
            this.dpFechaVuelta = new System.Windows.Forms.DateTimePicker();
            this.chkSetVuelta = new System.Windows.Forms.CheckBox();
            this.tbBoletoVuelta = new System.Windows.Forms.TextBox();
            this.lbBoletoVuelta = new System.Windows.Forms.Label();
            this.btnLocalidad = new System.Windows.Forms.Button();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddTrat = new System.Windows.Forms.Button();
            this.tbUnitario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.tbBoleto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLocalidadHasta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProvinciaHasta = new System.Windows.Forms.ComboBox();
            this.cbLocalidadDesde = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProvinciaDesde = new System.Windows.Forms.ComboBox();
            this.AnularBono = new System.Windows.Forms.Button();
            this.Reiniciar = new System.Windows.Forms.Button();
            this.bntImprimir = new System.Windows.Forms.Button();
            this.Grabar = new System.Windows.Forms.Button();
            this.AccionesGrilla = new System.Windows.Forms.ToolStrip();
            this.NuevoBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.gvPasajes = new System.Windows.Forms.DataGridView();
            this.Empresa = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.cbTipoViaje = new System.Windows.Forms.ComboBox();
            this.rbAereo = new System.Windows.Forms.RadioButton();
            this.rbMicro = new System.Windows.Forms.RadioButton();
            this.lbTipoViaje = new System.Windows.Forms.Label();
            this.gpDatos = new System.Windows.Forms.GroupBox();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.dpFechaBono = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lbSaldoTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fpago = new System.Windows.Forms.Label();
            this.gpPasaje.SuspendLayout();
            this.AccionesGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPasajes)).BeginInit();
            this.gpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagBono
            // 
            this.pagBono.Location = new System.Drawing.Point(10, 494);
            this.pagBono.Name = "pagBono";
            this.pagBono.Size = new System.Drawing.Size(75, 23);
            this.pagBono.TabIndex = 114;
            this.pagBono.Text = "Pago Bono";
            this.pagBono.UseVisualStyleBackColor = true;
            this.pagBono.Click += new System.EventHandler(this.pagBono_Click);
            // 
            // gpPasaje
            // 
            this.gpPasaje.Controls.Add(this.chkVuelta);
            this.gpPasaje.Controls.Add(this.dpFechaVuelta);
            this.gpPasaje.Controls.Add(this.chkSetVuelta);
            this.gpPasaje.Controls.Add(this.tbBoletoVuelta);
            this.gpPasaje.Controls.Add(this.lbBoletoVuelta);
            this.gpPasaje.Controls.Add(this.btnLocalidad);
            this.gpPasaje.Controls.Add(this.dpFecha);
            this.gpPasaje.Controls.Add(this.label6);
            this.gpPasaje.Controls.Add(this.btnAddTrat);
            this.gpPasaje.Controls.Add(this.tbUnitario);
            this.gpPasaje.Controls.Add(this.label5);
            this.gpPasaje.Controls.Add(this.tbCantidad);
            this.gpPasaje.Controls.Add(this.tbBoleto);
            this.gpPasaje.Controls.Add(this.label4);
            this.gpPasaje.Controls.Add(this.label3);
            this.gpPasaje.Controls.Add(this.cbLocalidadHasta);
            this.gpPasaje.Controls.Add(this.label2);
            this.gpPasaje.Controls.Add(this.cbProvinciaHasta);
            this.gpPasaje.Controls.Add(this.cbLocalidadDesde);
            this.gpPasaje.Controls.Add(this.label1);
            this.gpPasaje.Controls.Add(this.cbProvinciaDesde);
            this.gpPasaje.Location = new System.Drawing.Point(550, 326);
            this.gpPasaje.Name = "gpPasaje";
            this.gpPasaje.Size = new System.Drawing.Size(403, 325);
            this.gpPasaje.TabIndex = 117;
            this.gpPasaje.TabStop = false;
            this.gpPasaje.Text = "Pasaje";
            this.gpPasaje.Visible = false;
            // 
            // chkVuelta
            // 
            this.chkVuelta.AutoSize = true;
            this.chkVuelta.Enabled = false;
            this.chkVuelta.Location = new System.Drawing.Point(309, 176);
            this.chkVuelta.Name = "chkVuelta";
            this.chkVuelta.Size = new System.Drawing.Size(56, 17);
            this.chkVuelta.TabIndex = 139;
            this.chkVuelta.Text = "Vuelta";
            this.chkVuelta.UseVisualStyleBackColor = true;
            this.chkVuelta.CheckedChanged += new System.EventHandler(this.chkVuelta_CheckedChanged);
            // 
            // dpFechaVuelta
            // 
            this.dpFechaVuelta.Enabled = false;
            this.dpFechaVuelta.Location = new System.Drawing.Point(65, 230);
            this.dpFechaVuelta.Name = "dpFechaVuelta";
            this.dpFechaVuelta.Size = new System.Drawing.Size(233, 20);
            this.dpFechaVuelta.TabIndex = 138;
            // 
            // chkSetVuelta
            // 
            this.chkSetVuelta.AutoSize = true;
            this.chkSetVuelta.Location = new System.Drawing.Point(309, 148);
            this.chkSetVuelta.Name = "chkSetVuelta";
            this.chkSetVuelta.Size = new System.Drawing.Size(82, 17);
            this.chkSetVuelta.TabIndex = 136;
            this.chkSetVuelta.Text = "Ida y Vuelta";
            this.chkSetVuelta.UseVisualStyleBackColor = true;
            this.chkSetVuelta.CheckedChanged += new System.EventHandler(this.chkSetVuelta_CheckedChanged);
            // 
            // tbBoletoVuelta
            // 
            this.tbBoletoVuelta.Enabled = false;
            this.tbBoletoVuelta.Location = new System.Drawing.Point(66, 174);
            this.tbBoletoVuelta.Name = "tbBoletoVuelta";
            this.tbBoletoVuelta.Size = new System.Drawing.Size(233, 20);
            this.tbBoletoVuelta.TabIndex = 135;
            // 
            // lbBoletoVuelta
            // 
            this.lbBoletoVuelta.AutoSize = true;
            this.lbBoletoVuelta.Location = new System.Drawing.Point(9, 178);
            this.lbBoletoVuelta.Name = "lbBoletoVuelta";
            this.lbBoletoVuelta.Size = new System.Drawing.Size(50, 13);
            this.lbBoletoVuelta.TabIndex = 134;
            this.lbBoletoVuelta.Text = "B. Vuelta";
            // 
            // btnLocalidad
            // 
            this.btnLocalidad.Location = new System.Drawing.Point(309, 30);
            this.btnLocalidad.Name = "btnLocalidad";
            this.btnLocalidad.Size = new System.Drawing.Size(82, 58);
            this.btnLocalidad.TabIndex = 133;
            this.btnLocalidad.Text = "Agregar Localidad";
            this.btnLocalidad.UseVisualStyleBackColor = true;
            this.btnLocalidad.Click += new System.EventHandler(this.btnLocalidad_Click);
            // 
            // dpFecha
            // 
            this.dpFecha.Location = new System.Drawing.Point(66, 202);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(233, 20);
            this.dpFecha.TabIndex = 132;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 131;
            this.label6.Text = "Fecha";
            // 
            // btnAddTrat
            // 
            this.btnAddTrat.Location = new System.Drawing.Point(309, 279);
            this.btnAddTrat.Name = "btnAddTrat";
            this.btnAddTrat.Size = new System.Drawing.Size(82, 23);
            this.btnAddTrat.TabIndex = 118;
            this.btnAddTrat.Text = "Confirmar";
            this.btnAddTrat.UseVisualStyleBackColor = true;
            this.btnAddTrat.Click += new System.EventHandler(this.btnAddTrat_Click);
            // 
            // tbUnitario
            // 
            this.tbUnitario.Location = new System.Drawing.Point(225, 280);
            this.tbUnitario.Name = "tbUnitario";
            this.tbUnitario.Size = new System.Drawing.Size(74, 20);
            this.tbUnitario.TabIndex = 129;
            this.tbUnitario.Text = "0";
            this.tbUnitario.TextChanged += new System.EventHandler(this.tbUnitario_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 128;
            this.label5.Text = "Importe Unitario";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(66, 280);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(29, 20);
            this.tbCantidad.TabIndex = 127;
            this.tbCantidad.Text = "1";
            this.tbCantidad.Visible = false;
            this.tbCantidad.TextChanged += new System.EventHandler(this.tbCantidad_TextChanged);
            // 
            // tbBoleto
            // 
            this.tbBoleto.Location = new System.Drawing.Point(66, 146);
            this.tbBoleto.Name = "tbBoleto";
            this.tbBoleto.Size = new System.Drawing.Size(233, 20);
            this.tbBoleto.TabIndex = 126;
            this.tbBoleto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBoleto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 125;
            this.label4.Text = "Cantidad";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 124;
            this.label3.Text = "B. Ida";
            // 
            // cbLocalidadHasta
            // 
            this.cbLocalidadHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalidadHasta.FormattingEnabled = true;
            this.cbLocalidadHasta.Location = new System.Drawing.Point(66, 117);
            this.cbLocalidadHasta.Name = "cbLocalidadHasta";
            this.cbLocalidadHasta.Size = new System.Drawing.Size(233, 21);
            this.cbLocalidadHasta.TabIndex = 123;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "Hasta";
            // 
            // cbProvinciaHasta
            // 
            this.cbProvinciaHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvinciaHasta.FormattingEnabled = true;
            this.cbProvinciaHasta.Location = new System.Drawing.Point(66, 88);
            this.cbProvinciaHasta.Name = "cbProvinciaHasta";
            this.cbProvinciaHasta.Size = new System.Drawing.Size(233, 21);
            this.cbProvinciaHasta.TabIndex = 121;
            this.cbProvinciaHasta.SelectedIndexChanged += new System.EventHandler(this.cbProvinciaHasta_SelectedIndexChanged);
            // 
            // cbLocalidadDesde
            // 
            this.cbLocalidadDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalidadDesde.FormattingEnabled = true;
            this.cbLocalidadDesde.Location = new System.Drawing.Point(66, 59);
            this.cbLocalidadDesde.Name = "cbLocalidadDesde";
            this.cbLocalidadDesde.Size = new System.Drawing.Size(233, 21);
            this.cbLocalidadDesde.TabIndex = 120;
            this.cbLocalidadDesde.SelectedIndexChanged += new System.EventHandler(this.cbLocalidadDesde_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "Desde";
            // 
            // cbProvinciaDesde
            // 
            this.cbProvinciaDesde.BackColor = System.Drawing.Color.White;
            this.cbProvinciaDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvinciaDesde.FormattingEnabled = true;
            this.cbProvinciaDesde.Location = new System.Drawing.Point(66, 30);
            this.cbProvinciaDesde.Name = "cbProvinciaDesde";
            this.cbProvinciaDesde.Size = new System.Drawing.Size(233, 21);
            this.cbProvinciaDesde.TabIndex = 118;
            this.cbProvinciaDesde.SelectedIndexChanged += new System.EventHandler(this.cbProvinciaDesde_SelectedIndexChanged);
            // 
            // AnularBono
            // 
            this.AnularBono.Location = new System.Drawing.Point(959, 533);
            this.AnularBono.Name = "AnularBono";
            this.AnularBono.Size = new System.Drawing.Size(134, 23);
            this.AnularBono.TabIndex = 116;
            this.AnularBono.Text = "Anular";
            this.AnularBono.UseVisualStyleBackColor = true;
            this.AnularBono.Visible = false;
            this.AnularBono.Click += new System.EventHandler(this.AnularBono_Click);
            // 
            // Reiniciar
            // 
            this.Reiniciar.Location = new System.Drawing.Point(959, 437);
            this.Reiniciar.Name = "Reiniciar";
            this.Reiniciar.Size = new System.Drawing.Size(134, 23);
            this.Reiniciar.TabIndex = 115;
            this.Reiniciar.Text = "Reiniciar Pantalla";
            this.Reiniciar.UseVisualStyleBackColor = true;
            this.Reiniciar.Click += new System.EventHandler(this.Reiniciar_Click);
            // 
            // bntImprimir
            // 
            this.bntImprimir.Location = new System.Drawing.Point(959, 495);
            this.bntImprimir.Name = "bntImprimir";
            this.bntImprimir.Size = new System.Drawing.Size(134, 23);
            this.bntImprimir.TabIndex = 114;
            this.bntImprimir.Text = "Imprimir";
            this.bntImprimir.UseVisualStyleBackColor = true;
            this.bntImprimir.Visible = false;
            this.bntImprimir.Click += new System.EventHandler(this.bntImprimir_Click);
            // 
            // Grabar
            // 
            this.Grabar.Location = new System.Drawing.Point(959, 466);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(134, 23);
            this.Grabar.TabIndex = 112;
            this.Grabar.Text = "Grabar Bono";
            this.Grabar.UseVisualStyleBackColor = true;
            this.Grabar.Visible = false;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // AccionesGrilla
            // 
            this.AccionesGrilla.Dock = System.Windows.Forms.DockStyle.None;
            this.AccionesGrilla.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.AccionesGrilla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoBank,
            this.toolStripSeparator13,
            this.CancelarBank});
            this.AccionesGrilla.Location = new System.Drawing.Point(97, 493);
            this.AccionesGrilla.Name = "AccionesGrilla";
            this.AccionesGrilla.Size = new System.Drawing.Size(140, 25);
            this.AccionesGrilla.TabIndex = 111;
            this.AccionesGrilla.Text = "toolStrip4";
            // 
            // NuevoBank
            // 
            this.NuevoBank.Image = ((System.Drawing.Image)(resources.GetObject("NuevoBank.Image")));
            this.NuevoBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuevoBank.Name = "NuevoBank";
            this.NuevoBank.Size = new System.Drawing.Size(59, 22);
            this.NuevoBank.Text = "Setear";
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
            this.CancelarBank.Size = new System.Drawing.Size(72, 22);
            this.CancelarBank.Text = "Reiniciar";
            this.CancelarBank.Click += new System.EventHandler(this.CancelarBank_Click);
            // 
            // gvPasajes
            // 
            this.gvPasajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPasajes.Location = new System.Drawing.Point(9, 356);
            this.gvPasajes.Name = "gvPasajes";
            this.gvPasajes.Size = new System.Drawing.Size(532, 132);
            this.gvPasajes.TabIndex = 110;
            this.gvPasajes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPasajes_CellContentClick);
            // 
            // Empresa
            // 
            this.Empresa.AutoSize = true;
            this.Empresa.Location = new System.Drawing.Point(279, 330);
            this.Empresa.Name = "Empresa";
            this.Empresa.Size = new System.Drawing.Size(48, 13);
            this.Empresa.TabIndex = 85;
            this.Empresa.Text = "Empresa";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(338, 326);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(201, 21);
            this.cbEmpresa.TabIndex = 84;
            // 
            // cbTipoViaje
            // 
            this.cbTipoViaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoViaje.FormattingEnabled = true;
            this.cbTipoViaje.Location = new System.Drawing.Point(174, 326);
            this.cbTipoViaje.Name = "cbTipoViaje";
            this.cbTipoViaje.Size = new System.Drawing.Size(94, 21);
            this.cbTipoViaje.TabIndex = 83;
            this.cbTipoViaje.SelectedIndexChanged += new System.EventHandler(this.cbTipoViaje_SelectedIndexChanged);
            // 
            // rbAereo
            // 
            this.rbAereo.AutoSize = true;
            this.rbAereo.Location = new System.Drawing.Point(71, 328);
            this.rbAereo.Name = "rbAereo";
            this.rbAereo.Size = new System.Drawing.Size(53, 17);
            this.rbAereo.TabIndex = 2;
            this.rbAereo.TabStop = true;
            this.rbAereo.Text = "Aereo";
            this.rbAereo.UseVisualStyleBackColor = true;
            this.rbAereo.CheckedChanged += new System.EventHandler(this.rbAereo_CheckedChanged);
            // 
            // rbMicro
            // 
            this.rbMicro.AutoSize = true;
            this.rbMicro.Location = new System.Drawing.Point(9, 328);
            this.rbMicro.Name = "rbMicro";
            this.rbMicro.Size = new System.Drawing.Size(51, 17);
            this.rbMicro.TabIndex = 1;
            this.rbMicro.TabStop = true;
            this.rbMicro.Text = "Micro";
            this.rbMicro.UseVisualStyleBackColor = true;
            this.rbMicro.CheckedChanged += new System.EventHandler(this.btnMicro_CheckedChanged);
            // 
            // lbTipoViaje
            // 
            this.lbTipoViaje.AutoSize = true;
            this.lbTipoViaje.Location = new System.Drawing.Point(135, 330);
            this.lbTipoViaje.Name = "lbTipoViaje";
            this.lbTipoViaje.Size = new System.Drawing.Size(28, 13);
            this.lbTipoViaje.TabIndex = 0;
            this.lbTipoViaje.Text = "Tipo";
            // 
            // gpDatos
            // 
            this.gpDatos.Controls.Add(this.tbObs);
            this.gpDatos.Controls.Add(this.dpFechaBono);
            this.gpDatos.Controls.Add(this.label7);
            this.gpDatos.Controls.Add(this.lbSaldoTotal);
            this.gpDatos.Controls.Add(this.label8);
            this.gpDatos.Controls.Add(this.fpago);
            this.gpDatos.Location = new System.Drawing.Point(11, 518);
            this.gpDatos.Name = "gpDatos";
            this.gpDatos.Size = new System.Drawing.Size(529, 167);
            this.gpDatos.TabIndex = 122;
            this.gpDatos.TabStop = false;
            // 
            // tbObs
            // 
            this.tbObs.Location = new System.Drawing.Point(6, 85);
            this.tbObs.Multiline = true;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(517, 63);
            this.tbObs.TabIndex = 108;
            this.tbObs.TextChanged += new System.EventHandler(this.tbObs_TextChanged);
            // 
            // dpFechaBono
            // 
            this.dpFechaBono.Location = new System.Drawing.Point(314, 14);
            this.dpFechaBono.Name = "dpFechaBono";
            this.dpFechaBono.Size = new System.Drawing.Size(200, 20);
            this.dpFechaBono.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 109;
            this.label7.Text = "OBSERVACIONES";
            // 
            // lbSaldoTotal
            // 
            this.lbSaldoTotal.AutoSize = true;
            this.lbSaldoTotal.Location = new System.Drawing.Point(60, 18);
            this.lbSaldoTotal.Name = "lbSaldoTotal";
            this.lbSaldoTotal.Size = new System.Drawing.Size(13, 13);
            this.lbSaldoTotal.TabIndex = 118;
            this.lbSaldoTotal.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 119;
            this.label8.Text = "TOTAL";
            // 
            // fpago
            // 
            this.fpago.AutoSize = true;
            this.fpago.Location = new System.Drawing.Point(108, 39);
            this.fpago.Name = "fpago";
            this.fpago.Size = new System.Drawing.Size(67, 13);
            this.fpago.TabIndex = 120;
            this.fpago.Text = "[FormaPago]";
            // 
            // BonoPasaje
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1094, 697);
            this.Controls.Add(this.pagBono);
            this.Controls.Add(this.gpPasaje);
            this.Controls.Add(this.AnularBono);
            this.Controls.Add(this.Reiniciar);
            this.Controls.Add(this.bntImprimir);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.AccionesGrilla);
            this.Controls.Add(this.gvPasajes);
            this.Controls.Add(this.Empresa);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.cbTipoViaje);
            this.Controls.Add(this.rbAereo);
            this.Controls.Add(this.rbMicro);
            this.Controls.Add(this.lbTipoViaje);
            this.Controls.Add(this.gpDatos);
            this.Name = "BonoPasaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BonoPasaje_Load);
            this.gpPasaje.ResumeLayout(false);
            this.gpPasaje.PerformLayout();
            this.AccionesGrilla.ResumeLayout(false);
            this.AccionesGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPasajes)).EndInit();
            this.gpDatos.ResumeLayout(false);
            this.gpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTipoViaje;
        private System.Windows.Forms.RadioButton rbMicro;
        private System.Windows.Forms.RadioButton rbAereo;
        private System.Windows.Forms.ComboBox cbTipoViaje;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label Empresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.ToolStrip AccionesGrilla;
        private System.Windows.Forms.ToolStripButton NuevoBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.DataGridView gvPasajes;
        private System.Windows.Forms.Button AnularBono;
        private System.Windows.Forms.Button Reiniciar;
        private System.Windows.Forms.Button bntImprimir;
        private System.Windows.Forms.Button Grabar;
        private System.Windows.Forms.GroupBox gpPasaje;
        private System.Windows.Forms.TextBox tbUnitario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.TextBox tbBoleto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLocalidadHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProvinciaHasta;
        private System.Windows.Forms.ComboBox cbLocalidadDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProvinciaDesde;
        private System.Windows.Forms.Button btnAddTrat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label lbSaldoTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label fpago;
        private System.Windows.Forms.DateTimePicker dpFechaBono;
        private System.Windows.Forms.GroupBox gpDatos;
        private System.Windows.Forms.Button pagBono;
        private System.Windows.Forms.Button btnLocalidad;
        private System.Windows.Forms.CheckBox chkVuelta;
        private System.Windows.Forms.DateTimePicker dpFechaVuelta;
        private System.Windows.Forms.CheckBox chkSetVuelta;
        private System.Windows.Forms.TextBox tbBoletoVuelta;
        private System.Windows.Forms.Label lbBoletoVuelta;
    }
}
