namespace SOCIOS.bono
{
    partial class PagoBonos
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
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblBono = new System.Windows.Forms.Label();
            this.gpPago = new System.Windows.Forms.GroupBox();
            this.lbMontoTarjeta = new System.Windows.Forms.Label();
            this.lbMonto2 = new System.Windows.Forms.Label();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.lbMonto1 = new System.Windows.Forms.Label();
            this.lbFp2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lbFp1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPorcentaje = new System.Windows.Forms.TextBox();
            this.gpPlanilla = new System.Windows.Forms.GroupBox();
            this.lbCantidadMaximaCuotas = new System.Windows.Forms.Label();
            this.lbGestion = new System.Windows.Forms.Label();
            this.tbContralor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbFechaDTO = new System.Windows.Forms.Label();
            this.dpDTO = new System.Windows.Forms.DateTimePicker();
            this.tbMontoCuotas = new System.Windows.Forms.Label();
            this.lblSaldoCuotas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCantidadCuotas = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.gpTipoPago = new System.Windows.Forms.GroupBox();
            this.cbTipoPago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaApto = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.OK = new System.Windows.Forms.Button();
            this.lbSenia = new System.Windows.Forms.Label();
            this.lbSeniaMonto = new System.Windows.Forms.TextBox();
            this.lbMontoCuotaSenia = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSeniaCuotas = new System.Windows.Forms.Label();
            this.tbSeniaCantidadCuotas = new System.Windows.Forms.TextBox();
            this.gpSenia = new System.Windows.Forms.GroupBox();
            this.lbCantidadMaximaCuotas_Efectivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpSeniaFecha = new System.Windows.Forms.DateTimePicker();
            this.lbSaldoSenia = new System.Windows.Forms.Label();
            this.gpBancaria = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTBreferencia = new System.Windows.Forms.TextBox();
            this.rbTBCiudad = new System.Windows.Forms.RadioButton();
            this.rbTBPatagonia = new System.Windows.Forms.RadioButton();
            this.lbGestionLeyenda = new System.Windows.Forms.Label();
            this.gpPago.SuspendLayout();
            this.gpPlanilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.gpTipoPago.SuspendLayout();
            this.gpSenia.SuspendLayout();
            this.gpBancaria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSaldo.Location = new System.Drawing.Point(290, 14);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(43, 13);
            this.lblSaldo.TabIndex = 3;
            this.lblSaldo.Text = "SALDO";
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Location = new System.Drawing.Point(14, 14);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(68, 13);
            this.lblBono.TabIndex = 2;
            this.lblBono.Text = "NRO_BONO";
            // 
            // gpPago
            // 
            this.gpPago.Controls.Add(this.lbMontoTarjeta);
            this.gpPago.Controls.Add(this.lbMonto2);
            this.gpPago.Controls.Add(this.btnTarjeta);
            this.gpPago.Controls.Add(this.lbMonto1);
            this.gpPago.Controls.Add(this.lbFp2);
            this.gpPago.Controls.Add(this.textBox3);
            this.gpPago.Controls.Add(this.lbFp1);
            this.gpPago.Controls.Add(this.label9);
            this.gpPago.Controls.Add(this.tbPorcentaje);
            this.gpPago.Location = new System.Drawing.Point(553, 152);
            this.gpPago.Name = "gpPago";
            this.gpPago.Size = new System.Drawing.Size(130, 194);
            this.gpPago.TabIndex = 86;
            this.gpPago.TabStop = false;
            this.gpPago.Visible = false;
            // 
            // lbMontoTarjeta
            // 
            this.lbMontoTarjeta.AutoSize = true;
            this.lbMontoTarjeta.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lbMontoTarjeta.Location = new System.Drawing.Point(33, 170);
            this.lbMontoTarjeta.Name = "lbMontoTarjeta";
            this.lbMontoTarjeta.Size = new System.Drawing.Size(13, 13);
            this.lbMontoTarjeta.TabIndex = 90;
            this.lbMontoTarjeta.Text = "0";
            this.lbMontoTarjeta.Visible = false;
            // 
            // lbMonto2
            // 
            this.lbMonto2.AutoSize = true;
            this.lbMonto2.Location = new System.Drawing.Point(33, 108);
            this.lbMonto2.Name = "lbMonto2";
            this.lbMonto2.Size = new System.Drawing.Size(47, 13);
            this.lbMonto2.TabIndex = 87;
            this.lbMonto2.Text = "MONTO";
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.Location = new System.Drawing.Point(16, 129);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(99, 31);
            this.btnTarjeta.TabIndex = 89;
            this.btnTarjeta.Text = "Calcular Tarjeta";
            this.btnTarjeta.UseVisualStyleBackColor = true;
            this.btnTarjeta.Click += new System.EventHandler(this.btnTarjeta_Click);
            // 
            // lbMonto1
            // 
            this.lbMonto1.AutoSize = true;
            this.lbMonto1.Location = new System.Drawing.Point(33, 68);
            this.lbMonto1.Name = "lbMonto1";
            this.lbMonto1.Size = new System.Drawing.Size(47, 13);
            this.lbMonto1.TabIndex = 86;
            this.lbMonto1.Text = "MONTO";
            // 
            // lbFp2
            // 
            this.lbFp2.AutoSize = true;
            this.lbFp2.Location = new System.Drawing.Point(33, 88);
            this.lbFp2.Name = "lbFp2";
            this.lbFp2.Size = new System.Drawing.Size(49, 13);
            this.lbFp2.TabIndex = 83;
            this.lbFp2.Text = "FPAGO2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(359, 11);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(57, 20);
            this.textBox3.TabIndex = 82;
            // 
            // lbFp1
            // 
            this.lbFp1.AutoSize = true;
            this.lbFp1.Location = new System.Drawing.Point(33, 48);
            this.lbFp1.Name = "lbFp1";
            this.lbFp1.Size = new System.Drawing.Size(49, 13);
            this.lbFp1.TabIndex = 79;
            this.lbFp1.Text = "FPAGO1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "%";
            // 
            // tbPorcentaje
            // 
            this.tbPorcentaje.Location = new System.Drawing.Point(56, 17);
            this.tbPorcentaje.Name = "tbPorcentaje";
            this.tbPorcentaje.Size = new System.Drawing.Size(37, 20);
            this.tbPorcentaje.TabIndex = 78;
            this.tbPorcentaje.TextChanged += new System.EventHandler(this.tbPorcentaje_TextChanged);
            // 
            // gpPlanilla
            // 
            this.gpPlanilla.Controls.Add(this.lbGestionLeyenda);
            this.gpPlanilla.Controls.Add(this.lbCantidadMaximaCuotas);
            this.gpPlanilla.Controls.Add(this.lbGestion);
            this.gpPlanilla.Controls.Add(this.tbContralor);
            this.gpPlanilla.Controls.Add(this.label2);
            this.gpPlanilla.Controls.Add(this.lbFechaDTO);
            this.gpPlanilla.Controls.Add(this.dpDTO);
            this.gpPlanilla.Controls.Add(this.tbMontoCuotas);
            this.gpPlanilla.Controls.Add(this.lblSaldoCuotas);
            this.gpPlanilla.Controls.Add(this.label6);
            this.gpPlanilla.Controls.Add(this.label4);
            this.gpPlanilla.Controls.Add(this.tbCantidadCuotas);
            this.gpPlanilla.Location = new System.Drawing.Point(10, 207);
            this.gpPlanilla.Name = "gpPlanilla";
            this.gpPlanilla.Size = new System.Drawing.Size(526, 96);
            this.gpPlanilla.TabIndex = 85;
            this.gpPlanilla.TabStop = false;
            this.gpPlanilla.Text = "Financiacion Planilla";
            this.gpPlanilla.Visible = false;
            // 
            // lbCantidadMaximaCuotas
            // 
            this.lbCantidadMaximaCuotas.AutoSize = true;
            this.lbCantidadMaximaCuotas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCantidadMaximaCuotas.Location = new System.Drawing.Point(14, 80);
            this.lbCantidadMaximaCuotas.Name = "lbCantidadMaximaCuotas";
            this.lbCantidadMaximaCuotas.Size = new System.Drawing.Size(10, 13);
            this.lbCantidadMaximaCuotas.TabIndex = 89;
            this.lbCantidadMaximaCuotas.Text = "-";
            // 
            // lbGestion
            // 
            this.lbGestion.AutoSize = true;
            this.lbGestion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbGestion.Location = new System.Drawing.Point(445, 50);
            this.lbGestion.Name = "lbGestion";
            this.lbGestion.Size = new System.Drawing.Size(55, 13);
            this.lbGestion.TabIndex = 88;
            this.lbGestion.Text = "GESTION";
            this.lbGestion.Visible = false;
            // 
            // tbContralor
            // 
            this.tbContralor.Location = new System.Drawing.Point(129, 47);
            this.tbContralor.Name = "tbContralor";
            this.tbContralor.Size = new System.Drawing.Size(57, 20);
            this.tbContralor.TabIndex = 87;
            this.tbContralor.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "CONTRALOR DTO";
            // 
            // lbFechaDTO
            // 
            this.lbFechaDTO.AutoSize = true;
            this.lbFechaDTO.Location = new System.Drawing.Point(14, 20);
            this.lbFechaDTO.Name = "lbFechaDTO";
            this.lbFechaDTO.Size = new System.Drawing.Size(141, 13);
            this.lbFechaDTO.TabIndex = 79;
            this.lbFechaDTO.Text = "MES INICIO DESCUENTO :";
            // 
            // dpDTO
            // 
            this.dpDTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDTO.Location = new System.Drawing.Point(161, 16);
            this.dpDTO.Name = "dpDTO";
            this.dpDTO.Size = new System.Drawing.Size(127, 20);
            this.dpDTO.TabIndex = 80;
            this.dpDTO.ValueChanged += new System.EventHandler(this.dpDTO_ValueChanged);
            // 
            // tbMontoCuotas
            // 
            this.tbMontoCuotas.AutoSize = true;
            this.tbMontoCuotas.Location = new System.Drawing.Point(373, 50);
            this.tbMontoCuotas.Name = "tbMontoCuotas";
            this.tbMontoCuotas.Size = new System.Drawing.Size(47, 13);
            this.tbMontoCuotas.TabIndex = 85;
            this.tbMontoCuotas.Text = "MONTO";
            // 
            // lblSaldoCuotas
            // 
            this.lblSaldoCuotas.AutoSize = true;
            this.lblSaldoCuotas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSaldoCuotas.Location = new System.Drawing.Point(310, 20);
            this.lblSaldoCuotas.Name = "lblSaldoCuotas";
            this.lblSaldoCuotas.Size = new System.Drawing.Size(43, 13);
            this.lblSaldoCuotas.TabIndex = 84;
            this.lblSaldoCuotas.Text = "SALDO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "MONTO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 79;
            this.label4.Text = "CUOTAS";
            // 
            // tbCantidadCuotas
            // 
            this.tbCantidadCuotas.Location = new System.Drawing.Point(247, 46);
            this.tbCantidadCuotas.Name = "tbCantidadCuotas";
            this.tbCantidadCuotas.Size = new System.Drawing.Size(57, 20);
            this.tbCantidadCuotas.TabIndex = 80;
            this.tbCantidadCuotas.TextChanged += new System.EventHandler(this.tbCantidadCuotas_TextChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(9, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(674, 123);
            this.dataGridView.TabIndex = 84;
            // 
            // gpTipoPago
            // 
            this.gpTipoPago.Controls.Add(this.cbTipoPago);
            this.gpTipoPago.Controls.Add(this.label3);
            this.gpTipoPago.Controls.Add(this.FechaApto);
            this.gpTipoPago.Controls.Add(this.dpFecha);
            this.gpTipoPago.Location = new System.Drawing.Point(9, 152);
            this.gpTipoPago.Name = "gpTipoPago";
            this.gpTipoPago.Size = new System.Drawing.Size(527, 52);
            this.gpTipoPago.TabIndex = 87;
            this.gpTipoPago.TabStop = false;
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPago.FormattingEnabled = true;
            this.cbTipoPago.Location = new System.Drawing.Point(302, 19);
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.Size = new System.Drawing.Size(209, 21);
            this.cbTipoPago.TabIndex = 78;
            this.cbTipoPago.SelectedIndexChanged += new System.EventHandler(this.cbTipoPago_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "FECHA:";
            // 
            // FechaApto
            // 
            this.FechaApto.AutoSize = true;
            this.FechaApto.Location = new System.Drawing.Point(224, 23);
            this.FechaApto.Name = "FechaApto";
            this.FechaApto.Size = new System.Drawing.Size(68, 13);
            this.FechaApto.TabIndex = 75;
            this.FechaApto.Text = "TIPO PAGO:";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(66, 19);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(85, 20);
            this.dpFecha.TabIndex = 77;
            this.dpFecha.ValueChanged += new System.EventHandler(this.dpFecha_ValueChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(553, 431);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(136, 35);
            this.OK.TabIndex = 88;
            this.OK.Text = "GRABAR PAGO";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lbSenia
            // 
            this.lbSenia.AutoSize = true;
            this.lbSenia.Location = new System.Drawing.Point(11, 28);
            this.lbSenia.Name = "lbSenia";
            this.lbSenia.Size = new System.Drawing.Size(42, 13);
            this.lbSenia.TabIndex = 86;
            this.lbSenia.Text = "SEÑA :";
            // 
            // lbSeniaMonto
            // 
            this.lbSeniaMonto.Location = new System.Drawing.Point(59, 24);
            this.lbSeniaMonto.Name = "lbSeniaMonto";
            this.lbSeniaMonto.Size = new System.Drawing.Size(57, 20);
            this.lbSeniaMonto.TabIndex = 87;
            this.lbSeniaMonto.Text = "0";
            this.lbSeniaMonto.TextChanged += new System.EventHandler(this.lbSeniaMonto_TextChanged);
            // 
            // lbMontoCuotaSenia
            // 
            this.lbMontoCuotaSenia.AutoSize = true;
            this.lbMontoCuotaSenia.Location = new System.Drawing.Point(431, 28);
            this.lbMontoCuotaSenia.Name = "lbMontoCuotaSenia";
            this.lbMontoCuotaSenia.Size = new System.Drawing.Size(13, 13);
            this.lbMontoCuotaSenia.TabIndex = 91;
            this.lbMontoCuotaSenia.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 90;
            this.label5.Text = "MONTO";
            // 
            // lbSeniaCuotas
            // 
            this.lbSeniaCuotas.AutoSize = true;
            this.lbSeniaCuotas.Location = new System.Drawing.Point(257, 28);
            this.lbSeniaCuotas.Name = "lbSeniaCuotas";
            this.lbSeniaCuotas.Size = new System.Drawing.Size(51, 13);
            this.lbSeniaCuotas.TabIndex = 88;
            this.lbSeniaCuotas.Text = "CUOTAS";
            // 
            // tbSeniaCantidadCuotas
            // 
            this.tbSeniaCantidadCuotas.Location = new System.Drawing.Point(314, 24);
            this.tbSeniaCantidadCuotas.Name = "tbSeniaCantidadCuotas";
            this.tbSeniaCantidadCuotas.Size = new System.Drawing.Size(57, 20);
            this.tbSeniaCantidadCuotas.TabIndex = 89;
            this.tbSeniaCantidadCuotas.TextChanged += new System.EventHandler(this.tbSeniaCantidadCuotas_TextChanged);
            // 
            // gpSenia
            // 
            this.gpSenia.Controls.Add(this.lbCantidadMaximaCuotas_Efectivo);
            this.gpSenia.Controls.Add(this.label1);
            this.gpSenia.Controls.Add(this.dpSeniaFecha);
            this.gpSenia.Controls.Add(this.lbSaldoSenia);
            this.gpSenia.Controls.Add(this.lbMontoCuotaSenia);
            this.gpSenia.Controls.Add(this.lbSenia);
            this.gpSenia.Controls.Add(this.label5);
            this.gpSenia.Controls.Add(this.lbSeniaMonto);
            this.gpSenia.Controls.Add(this.lbSeniaCuotas);
            this.gpSenia.Controls.Add(this.tbSeniaCantidadCuotas);
            this.gpSenia.Location = new System.Drawing.Point(15, 309);
            this.gpSenia.Name = "gpSenia";
            this.gpSenia.Size = new System.Drawing.Size(521, 106);
            this.gpSenia.TabIndex = 89;
            this.gpSenia.TabStop = false;
            this.gpSenia.Text = "Financiacion Efectivo";
            this.gpSenia.Visible = false;
            this.gpSenia.Enter += new System.EventHandler(this.gpSenia_Enter);
            // 
            // lbCantidadMaximaCuotas_Efectivo
            // 
            this.lbCantidadMaximaCuotas_Efectivo.AutoSize = true;
            this.lbCantidadMaximaCuotas_Efectivo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCantidadMaximaCuotas_Efectivo.Location = new System.Drawing.Point(13, 77);
            this.lbCantidadMaximaCuotas_Efectivo.Name = "lbCantidadMaximaCuotas_Efectivo";
            this.lbCantidadMaximaCuotas_Efectivo.Size = new System.Drawing.Size(10, 13);
            this.lbCantidadMaximaCuotas_Efectivo.TabIndex = 94;
            this.lbCantidadMaximaCuotas_Efectivo.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "MES INICIO FINANCIACION :";
            // 
            // dpSeniaFecha
            // 
            this.dpSeniaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpSeniaFecha.Location = new System.Drawing.Point(168, 54);
            this.dpSeniaFecha.Name = "dpSeniaFecha";
            this.dpSeniaFecha.Size = new System.Drawing.Size(130, 20);
            this.dpSeniaFecha.TabIndex = 93;
            this.dpSeniaFecha.ValueChanged += new System.EventHandler(this.dpSeniaFecha_ValueChanged);
            // 
            // lbSaldoSenia
            // 
            this.lbSaldoSenia.AutoSize = true;
            this.lbSaldoSenia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbSaldoSenia.Location = new System.Drawing.Point(186, 28);
            this.lbSaldoSenia.Name = "lbSaldoSenia";
            this.lbSaldoSenia.Size = new System.Drawing.Size(43, 13);
            this.lbSaldoSenia.TabIndex = 86;
            this.lbSaldoSenia.Text = "SALDO";
            // 
            // gpBancaria
            // 
            this.gpBancaria.Controls.Add(this.label7);
            this.gpBancaria.Controls.Add(this.tbTBreferencia);
            this.gpBancaria.Controls.Add(this.rbTBCiudad);
            this.gpBancaria.Controls.Add(this.rbTBPatagonia);
            this.gpBancaria.Location = new System.Drawing.Point(17, 421);
            this.gpBancaria.Name = "gpBancaria";
            this.gpBancaria.Size = new System.Drawing.Size(519, 53);
            this.gpBancaria.TabIndex = 90;
            this.gpBancaria.TabStop = false;
            this.gpBancaria.Text = "Transferencia Bancaria Destino";
            this.gpBancaria.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "REF  :";
            // 
            // tbTBreferencia
            // 
            this.tbTBreferencia.Location = new System.Drawing.Point(306, 18);
            this.tbTBreferencia.Name = "tbTBreferencia";
            this.tbTBreferencia.Size = new System.Drawing.Size(197, 20);
            this.tbTBreferencia.TabIndex = 95;
            // 
            // rbTBCiudad
            // 
            this.rbTBCiudad.AutoSize = true;
            this.rbTBCiudad.Location = new System.Drawing.Point(166, 19);
            this.rbTBCiudad.Name = "rbTBCiudad";
            this.rbTBCiudad.Size = new System.Drawing.Size(66, 17);
            this.rbTBCiudad.TabIndex = 1;
            this.rbTBCiudad.TabStop = true;
            this.rbTBCiudad.Text = "CIUDAD";
            this.rbTBCiudad.UseVisualStyleBackColor = true;
            // 
            // rbTBPatagonia
            // 
            this.rbTBPatagonia.AutoSize = true;
            this.rbTBPatagonia.Location = new System.Drawing.Point(58, 19);
            this.rbTBPatagonia.Name = "rbTBPatagonia";
            this.rbTBPatagonia.Size = new System.Drawing.Size(87, 17);
            this.rbTBPatagonia.TabIndex = 0;
            this.rbTBPatagonia.TabStop = true;
            this.rbTBPatagonia.Text = "PATAGONIA";
            this.rbTBPatagonia.UseVisualStyleBackColor = true;
            // 
            // lbGestionLeyenda
            // 
            this.lbGestionLeyenda.AutoSize = true;
            this.lbGestionLeyenda.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbGestionLeyenda.Location = new System.Drawing.Point(394, 20);
            this.lbGestionLeyenda.Name = "lbGestionLeyenda";
            this.lbGestionLeyenda.Size = new System.Drawing.Size(55, 13);
            this.lbGestionLeyenda.TabIndex = 90;
            this.lbGestionLeyenda.Text = "GESTION";
            this.lbGestionLeyenda.Visible = false;
            // 
            // PagoBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 476);
            this.Controls.Add(this.gpBancaria);
            this.Controls.Add(this.gpSenia);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.gpTipoPago);
            this.Controls.Add(this.gpPago);
            this.Controls.Add(this.gpPlanilla);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.lblBono);
            this.Name = "PagoBonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PagoBonos";
            this.gpPago.ResumeLayout(false);
            this.gpPago.PerformLayout();
            this.gpPlanilla.ResumeLayout(false);
            this.gpPlanilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.gpTipoPago.ResumeLayout(false);
            this.gpTipoPago.PerformLayout();
            this.gpSenia.ResumeLayout(false);
            this.gpSenia.PerformLayout();
            this.gpBancaria.ResumeLayout(false);
            this.gpBancaria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.GroupBox gpPago;
        private System.Windows.Forms.Label lbMonto2;
        private System.Windows.Forms.Label lbMonto1;
        private System.Windows.Forms.Label lbFp2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbFp1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPorcentaje;
        private System.Windows.Forms.GroupBox gpPlanilla;
        private System.Windows.Forms.Label tbMontoCuotas;
        private System.Windows.Forms.Label lblSaldoCuotas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCantidadCuotas;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox gpTipoPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FechaApto;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.ComboBox cbTipoPago;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label lbFechaDTO;
        private System.Windows.Forms.DateTimePicker dpDTO;
        private System.Windows.Forms.Label lbSenia;
        private System.Windows.Forms.TextBox lbSeniaMonto;
        private System.Windows.Forms.Label lbMontoCuotaSenia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSeniaCuotas;
        private System.Windows.Forms.TextBox tbSeniaCantidadCuotas;
        private System.Windows.Forms.GroupBox gpSenia;
        private System.Windows.Forms.Label lbSaldoSenia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpSeniaFecha;
        private System.Windows.Forms.TextBox tbContralor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbGestion;
        private System.Windows.Forms.Label lbMontoTarjeta;
        private System.Windows.Forms.Button btnTarjeta;
        private System.Windows.Forms.Label lbCantidadMaximaCuotas;
        private System.Windows.Forms.Label lbCantidadMaximaCuotas_Efectivo;
        private System.Windows.Forms.GroupBox gpBancaria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTBreferencia;
        private System.Windows.Forms.RadioButton rbTBCiudad;
        private System.Windows.Forms.RadioButton rbTBPatagonia;
        private System.Windows.Forms.Label lbGestionLeyenda;
    }
}