namespace SOCIOS.bono
{
    partial class BonoPaquete
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
            this.lbTipoViaje = new System.Windows.Forms.Label();
            this.cbPaquete = new System.Windows.Forms.ComboBox();
            this.AnularBono = new System.Windows.Forms.Button();
            this.Reiniciar = new System.Windows.Forms.Button();
            this.bntImprimir = new System.Windows.Forms.Button();
            this.Grabar = new System.Windows.Forms.Button();
            this.InfoPaquete = new System.Windows.Forms.Button();
            this.Seleccion = new System.Windows.Forms.Button();
            this.Deseleccionar = new System.Windows.Forms.Button();
            this.lbSaldoTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pagBono = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.fpago = new System.Windows.Forms.Label();
            this.dpFechaBono = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboFilial = new System.Windows.Forms.GroupBox();
            this.titPtoVenta = new System.Windows.Forms.Label();
            this.cbAfip = new System.Windows.Forms.CheckBox();
            this.cbRecibo = new System.Windows.Forms.CheckBox();
            this.lbPtoVta = new System.Windows.Forms.Label();
            this.tbReciboFilial = new System.Windows.Forms.TextBox();
            this.lbComisionDirectiva = new System.Windows.Forms.Label();
            this.lbFilial = new System.Windows.Forms.Label();
            this.cbComisionDirectiva = new System.Windows.Forms.ComboBox();
            this.combo_Filial = new System.Windows.Forms.ComboBox();
            this.lbLeyendaCocheCama = new System.Windows.Forms.Label();
            this.cbFilial = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.InfoInvi = new System.Windows.Forms.Label();
            this.InfoMenor = new System.Windows.Forms.Label();
            this.infoInter = new System.Windows.Forms.Label();
            this.infoSocio = new System.Windows.Forms.Label();
            this.tbMenor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInterCirculo = new System.Windows.Forms.TextBox();
            this.tbInvitados = new System.Windows.Forms.TextBox();
            this.tbSocios = new System.Windows.Forms.TextBox();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.cbCocheCama = new System.Windows.Forms.CheckBox();
            this.comboFilial.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTipoViaje
            // 
            this.lbTipoViaje.AutoSize = true;
            this.lbTipoViaje.Location = new System.Drawing.Point(37, 378);
            this.lbTipoViaje.Name = "lbTipoViaje";
            this.lbTipoViaje.Size = new System.Drawing.Size(28, 13);
            this.lbTipoViaje.TabIndex = 0;
            this.lbTipoViaje.Text = "Tipo";
            // 
            // cbPaquete
            // 
            this.cbPaquete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaquete.FormattingEnabled = true;
            this.cbPaquete.Location = new System.Drawing.Point(99, 378);
            this.cbPaquete.Name = "cbPaquete";
            this.cbPaquete.Size = new System.Drawing.Size(269, 21);
            this.cbPaquete.TabIndex = 83;
            this.cbPaquete.SelectedIndexChanged += new System.EventHandler(this.cbPaquete_SelectedIndexChanged);
            // 
            // AnularBono
            // 
            this.AnularBono.Location = new System.Drawing.Point(851, 643);
            this.AnularBono.Name = "AnularBono";
            this.AnularBono.Size = new System.Drawing.Size(92, 23);
            this.AnularBono.TabIndex = 116;
            this.AnularBono.Text = "Anular";
            this.AnularBono.UseVisualStyleBackColor = true;
            this.AnularBono.Visible = false;
            this.AnularBono.Click += new System.EventHandler(this.AnularBono_Click);
            // 
            // Reiniciar
            // 
            this.Reiniciar.Location = new System.Drawing.Point(789, 672);
            this.Reiniciar.Name = "Reiniciar";
            this.Reiniciar.Size = new System.Drawing.Size(154, 23);
            this.Reiniciar.TabIndex = 115;
            this.Reiniciar.Text = "Reiniciar Pantalla";
            this.Reiniciar.UseVisualStyleBackColor = true;
            // 
            // bntImprimir
            // 
            this.bntImprimir.Location = new System.Drawing.Point(851, 614);
            this.bntImprimir.Name = "bntImprimir";
            this.bntImprimir.Size = new System.Drawing.Size(92, 23);
            this.bntImprimir.TabIndex = 114;
            this.bntImprimir.Text = "Imprimir";
            this.bntImprimir.UseVisualStyleBackColor = true;
            this.bntImprimir.Visible = false;
            this.bntImprimir.Click += new System.EventHandler(this.bntImprimir_Click);
            // 
            // Grabar
            // 
            this.Grabar.Location = new System.Drawing.Point(851, 581);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(92, 23);
            this.Grabar.TabIndex = 112;
            this.Grabar.Text = "Grabar Bono";
            this.Grabar.UseVisualStyleBackColor = true;
            this.Grabar.Visible = false;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // InfoPaquete
            // 
            this.InfoPaquete.Location = new System.Drawing.Point(389, 376);
            this.InfoPaquete.Name = "InfoPaquete";
            this.InfoPaquete.Size = new System.Drawing.Size(160, 23);
            this.InfoPaquete.TabIndex = 130;
            this.InfoPaquete.Text = "Info Paquete";
            this.InfoPaquete.UseVisualStyleBackColor = true;
            this.InfoPaquete.Click += new System.EventHandler(this.InfoPaquete_Click);
            // 
            // Seleccion
            // 
            this.Seleccion.Location = new System.Drawing.Point(389, 405);
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Size = new System.Drawing.Size(160, 23);
            this.Seleccion.TabIndex = 131;
            this.Seleccion.Text = "Seleccionar";
            this.Seleccion.UseVisualStyleBackColor = true;
            this.Seleccion.Click += new System.EventHandler(this.Seleccion_Click);
            // 
            // Deseleccionar
            // 
            this.Deseleccionar.Location = new System.Drawing.Point(555, 405);
            this.Deseleccionar.Name = "Deseleccionar";
            this.Deseleccionar.Size = new System.Drawing.Size(160, 23);
            this.Deseleccionar.TabIndex = 132;
            this.Deseleccionar.Text = "Deseleccionar";
            this.Deseleccionar.UseVisualStyleBackColor = true;
            this.Deseleccionar.Visible = false;
            this.Deseleccionar.Click += new System.EventHandler(this.Deseleccionar_Click);
            // 
            // lbSaldoTotal
            // 
            this.lbSaldoTotal.AutoSize = true;
            this.lbSaldoTotal.Location = new System.Drawing.Point(218, 114);
            this.lbSaldoTotal.Name = "lbSaldoTotal";
            this.lbSaldoTotal.Size = new System.Drawing.Size(13, 13);
            this.lbSaldoTotal.TabIndex = 118;
            this.lbSaldoTotal.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "INVITADOS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 109;
            this.label7.Text = "OBSERVACIONES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "SOCIOS";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(143, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 119;
            this.label8.Text = "TOTAL";
            // 
            // pagBono
            // 
            this.pagBono.Location = new System.Drawing.Point(17, 82);
            this.pagBono.Name = "pagBono";
            this.pagBono.Size = new System.Drawing.Size(75, 23);
            this.pagBono.TabIndex = 114;
            this.pagBono.Text = "Pago Bono";
            this.pagBono.UseVisualStyleBackColor = true;
            this.pagBono.Click += new System.EventHandler(this.pagBono_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 135;
            this.label6.Text = "INTERCIRCULO";
            // 
            // fpago
            // 
            this.fpago.AutoSize = true;
            this.fpago.Location = new System.Drawing.Point(327, 126);
            this.fpago.Name = "fpago";
            this.fpago.Size = new System.Drawing.Size(67, 13);
            this.fpago.TabIndex = 120;
            this.fpago.Text = "[FormaPago]";
            // 
            // dpFechaBono
            // 
            this.dpFechaBono.Location = new System.Drawing.Point(398, 107);
            this.dpFechaBono.Name = "dpFechaBono";
            this.dpFechaBono.Size = new System.Drawing.Size(200, 20);
            this.dpFechaBono.TabIndex = 132;
            this.dpFechaBono.ValueChanged += new System.EventHandler(this.dpFechaBono_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "FECHA";
            // 
            // comboFilial
            // 
            this.comboFilial.Controls.Add(this.titPtoVenta);
            this.comboFilial.Controls.Add(this.cbAfip);
            this.comboFilial.Controls.Add(this.cbRecibo);
            this.comboFilial.Controls.Add(this.lbPtoVta);
            this.comboFilial.Controls.Add(this.tbReciboFilial);
            this.comboFilial.Controls.Add(this.lbComisionDirectiva);
            this.comboFilial.Controls.Add(this.lbFilial);
            this.comboFilial.Controls.Add(this.cbComisionDirectiva);
            this.comboFilial.Controls.Add(this.combo_Filial);
            this.comboFilial.Controls.Add(this.lbLeyendaCocheCama);
            this.comboFilial.Controls.Add(this.cbFilial);
            this.comboFilial.Controls.Add(this.label5);
            this.comboFilial.Controls.Add(this.InfoInvi);
            this.comboFilial.Controls.Add(this.InfoMenor);
            this.comboFilial.Controls.Add(this.infoInter);
            this.comboFilial.Controls.Add(this.infoSocio);
            this.comboFilial.Controls.Add(this.tbMenor);
            this.comboFilial.Controls.Add(this.label3);
            this.comboFilial.Controls.Add(this.tbInterCirculo);
            this.comboFilial.Controls.Add(this.tbInvitados);
            this.comboFilial.Controls.Add(this.tbSocios);
            this.comboFilial.Controls.Add(this.label2);
            this.comboFilial.Controls.Add(this.dpFechaBono);
            this.comboFilial.Controls.Add(this.fpago);
            this.comboFilial.Controls.Add(this.label6);
            this.comboFilial.Controls.Add(this.pagBono);
            this.comboFilial.Controls.Add(this.label8);
            this.comboFilial.Controls.Add(this.label4);
            this.comboFilial.Controls.Add(this.label7);
            this.comboFilial.Controls.Add(this.label1);
            this.comboFilial.Controls.Add(this.lbSaldoTotal);
            this.comboFilial.Location = new System.Drawing.Point(33, 427);
            this.comboFilial.Name = "comboFilial";
            this.comboFilial.Size = new System.Drawing.Size(750, 288);
            this.comboFilial.TabIndex = 122;
            this.comboFilial.TabStop = false;
            this.comboFilial.Visible = false;
            // 
            // titPtoVenta
            // 
            this.titPtoVenta.AutoSize = true;
            this.titPtoVenta.ForeColor = System.Drawing.Color.Chocolate;
            this.titPtoVenta.Location = new System.Drawing.Point(533, 250);
            this.titPtoVenta.Name = "titPtoVenta";
            this.titPtoVenta.Size = new System.Drawing.Size(53, 13);
            this.titPtoVenta.TabIndex = 180;
            this.titPtoVenta.Text = "PTO VTA";
            this.titPtoVenta.Visible = false;
            // 
            // cbAfip
            // 
            this.cbAfip.AutoSize = true;
            this.cbAfip.Location = new System.Drawing.Point(451, 266);
            this.cbAfip.Name = "cbAfip";
            this.cbAfip.Size = new System.Drawing.Size(110, 17);
            this.cbAfip.TabIndex = 179;
            this.cbAfip.Text = "Comprobante Afip";
            this.cbAfip.UseVisualStyleBackColor = true;
            this.cbAfip.Visible = false;
            this.cbAfip.CheckedChanged += new System.EventHandler(this.cbAfip_CheckedChanged);
            // 
            // cbRecibo
            // 
            this.cbRecibo.AutoSize = true;
            this.cbRecibo.Location = new System.Drawing.Point(451, 250);
            this.cbRecibo.Name = "cbRecibo";
            this.cbRecibo.Size = new System.Drawing.Size(60, 17);
            this.cbRecibo.TabIndex = 178;
            this.cbRecibo.Text = "Recibo";
            this.cbRecibo.UseVisualStyleBackColor = true;
            this.cbRecibo.Visible = false;
            this.cbRecibo.CheckedChanged += new System.EventHandler(this.cbRecibo_CheckedChanged);
            // 
            // lbPtoVta
            // 
            this.lbPtoVta.AutoSize = true;
            this.lbPtoVta.ForeColor = System.Drawing.Color.Chocolate;
            this.lbPtoVta.Location = new System.Drawing.Point(592, 250);
            this.lbPtoVta.Name = "lbPtoVta";
            this.lbPtoVta.Size = new System.Drawing.Size(10, 13);
            this.lbPtoVta.TabIndex = 177;
            this.lbPtoVta.Text = "-";
            this.lbPtoVta.Visible = false;
            // 
            // tbReciboFilial
            // 
            this.tbReciboFilial.Location = new System.Drawing.Point(662, 247);
            this.tbReciboFilial.Name = "tbReciboFilial";
            this.tbReciboFilial.Size = new System.Drawing.Size(75, 20);
            this.tbReciboFilial.TabIndex = 170;
            this.tbReciboFilial.Visible = false;
            // 
            // lbComisionDirectiva
            // 
            this.lbComisionDirectiva.AutoSize = true;
            this.lbComisionDirectiva.Location = new System.Drawing.Point(20, 229);
            this.lbComisionDirectiva.Name = "lbComisionDirectiva";
            this.lbComisionDirectiva.Size = new System.Drawing.Size(78, 13);
            this.lbComisionDirectiva.TabIndex = 165;
            this.lbComisionDirectiva.Text = "AUTORIZADO";
            // 
            // lbFilial
            // 
            this.lbFilial.AutoSize = true;
            this.lbFilial.Location = new System.Drawing.Point(609, 250);
            this.lbFilial.Name = "lbFilial";
            this.lbFilial.Size = new System.Drawing.Size(47, 13);
            this.lbFilial.TabIndex = 169;
            this.lbFilial.Text = "RECIBO";
            this.lbFilial.Visible = false;
            this.lbFilial.Click += new System.EventHandler(this.lbFilial_Click);
            // 
            // cbComisionDirectiva
            // 
            this.cbComisionDirectiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComisionDirectiva.FormattingEnabled = true;
            this.cbComisionDirectiva.Location = new System.Drawing.Point(119, 227);
            this.cbComisionDirectiva.Name = "cbComisionDirectiva";
            this.cbComisionDirectiva.Size = new System.Drawing.Size(251, 21);
            this.cbComisionDirectiva.TabIndex = 164;
            this.cbComisionDirectiva.Visible = false;
            // 
            // combo_Filial
            // 
            this.combo_Filial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Filial.FormattingEnabled = true;
            this.combo_Filial.Location = new System.Drawing.Point(480, 224);
            this.combo_Filial.Name = "combo_Filial";
            this.combo_Filial.Size = new System.Drawing.Size(193, 21);
            this.combo_Filial.TabIndex = 167;
            this.combo_Filial.Visible = false;
            this.combo_Filial.SelectedIndexChanged += new System.EventHandler(this.combo_Filial_SelectedIndexChanged);
            // 
            // lbLeyendaCocheCama
            // 
            this.lbLeyendaCocheCama.AutoSize = true;
            this.lbLeyendaCocheCama.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbLeyendaCocheCama.Location = new System.Drawing.Point(21, 132);
            this.lbLeyendaCocheCama.Name = "lbLeyendaCocheCama";
            this.lbLeyendaCocheCama.Size = new System.Drawing.Size(272, 13);
            this.lbLeyendaCocheCama.TabIndex = 146;
            this.lbLeyendaCocheCama.Text = "LAS TARIFAS INCLUYEN EL PAGO DE COCHE CAMA";
            // 
            // cbFilial
            // 
            this.cbFilial.AutoSize = true;
            this.cbFilial.Location = new System.Drawing.Point(376, 228);
            this.cbFilial.Name = "cbFilial";
            this.cbFilial.Size = new System.Drawing.Size(98, 17);
            this.cbFilial.TabIndex = 168;
            this.cbFilial.Text = "Recibo de Filial";
            this.cbFilial.UseVisualStyleBackColor = true;
            this.cbFilial.CheckedChanged += new System.EventHandler(this.cbFilial_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(14, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(497, 13);
            this.label5.TabIndex = 145;
            this.label5.Text = "LO INDICADO EN CADA CAMPO DE TARIFA ES EL PRECIO INDIVIDUAL CARGADO EN LA SALIDA";
            // 
            // InfoInvi
            // 
            this.InfoInvi.AutoSize = true;
            this.InfoInvi.ForeColor = System.Drawing.SystemColors.Highlight;
            this.InfoInvi.Location = new System.Drawing.Point(566, 54);
            this.InfoInvi.Name = "InfoInvi";
            this.InfoInvi.Size = new System.Drawing.Size(32, 13);
            this.InfoInvi.TabIndex = 144;
            this.InfoInvi.Text = "INFO";
            // 
            // InfoMenor
            // 
            this.InfoMenor.AutoSize = true;
            this.InfoMenor.ForeColor = System.Drawing.SystemColors.Highlight;
            this.InfoMenor.Location = new System.Drawing.Point(566, 86);
            this.InfoMenor.Name = "InfoMenor";
            this.InfoMenor.Size = new System.Drawing.Size(32, 13);
            this.InfoMenor.TabIndex = 143;
            this.InfoMenor.Text = "INFO";
            // 
            // infoInter
            // 
            this.infoInter.AutoSize = true;
            this.infoInter.ForeColor = System.Drawing.SystemColors.Highlight;
            this.infoInter.Location = new System.Drawing.Point(282, 82);
            this.infoInter.Name = "infoInter";
            this.infoInter.Size = new System.Drawing.Size(32, 13);
            this.infoInter.TabIndex = 142;
            this.infoInter.Text = "INFO";
            // 
            // infoSocio
            // 
            this.infoSocio.AutoSize = true;
            this.infoSocio.ForeColor = System.Drawing.SystemColors.Highlight;
            this.infoSocio.Location = new System.Drawing.Point(282, 54);
            this.infoSocio.Name = "infoSocio";
            this.infoSocio.Size = new System.Drawing.Size(32, 13);
            this.infoSocio.TabIndex = 141;
            this.infoSocio.Text = "INFO";
            // 
            // tbMenor
            // 
            this.tbMenor.Location = new System.Drawing.Point(475, 79);
            this.tbMenor.Name = "tbMenor";
            this.tbMenor.Size = new System.Drawing.Size(63, 20);
            this.tbMenor.TabIndex = 140;
            this.tbMenor.TextChanged += new System.EventHandler(this.tbMenor_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 139;
            this.label3.Text = "MENOR";
            // 
            // tbInterCirculo
            // 
            this.tbInterCirculo.Location = new System.Drawing.Point(203, 77);
            this.tbInterCirculo.Name = "tbInterCirculo";
            this.tbInterCirculo.Size = new System.Drawing.Size(63, 20);
            this.tbInterCirculo.TabIndex = 138;
            this.tbInterCirculo.TextChanged += new System.EventHandler(this.tbInterCirculo_TextChanged);
            // 
            // tbInvitados
            // 
            this.tbInvitados.Location = new System.Drawing.Point(475, 51);
            this.tbInvitados.Name = "tbInvitados";
            this.tbInvitados.Size = new System.Drawing.Size(63, 20);
            this.tbInvitados.TabIndex = 137;
            this.tbInvitados.TextChanged += new System.EventHandler(this.tbInvitados_TextChanged);
            // 
            // tbSocios
            // 
            this.tbSocios.Location = new System.Drawing.Point(204, 51);
            this.tbSocios.Name = "tbSocios";
            this.tbSocios.Size = new System.Drawing.Size(63, 20);
            this.tbSocios.TabIndex = 136;
            this.tbSocios.TextChanged += new System.EventHandler(this.tbSocios_TextChanged);
            // 
            // tbObs
            // 
            this.tbObs.Location = new System.Drawing.Point(50, 578);
            this.tbObs.Multiline = true;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(727, 70);
            this.tbObs.TabIndex = 108;
            this.tbObs.TextChanged += new System.EventHandler(this.tbObs_TextChanged);
            // 
            // cbCocheCama
            // 
            this.cbCocheCama.AutoSize = true;
            this.cbCocheCama.Location = new System.Drawing.Point(217, 409);
            this.cbCocheCama.Name = "cbCocheCama";
            this.cbCocheCama.Size = new System.Drawing.Size(131, 17);
            this.cbCocheCama.TabIndex = 133;
            this.cbCocheCama.Text = "Precio c/Coche Cama";
            this.cbCocheCama.UseVisualStyleBackColor = true;
            // 
            // BonoPaquete
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 759);
            this.Controls.Add(this.cbCocheCama);
            this.Controls.Add(this.Deseleccionar);
            this.Controls.Add(this.Seleccion);
            this.Controls.Add(this.InfoPaquete);
            this.Controls.Add(this.AnularBono);
            this.Controls.Add(this.Reiniciar);
            this.Controls.Add(this.bntImprimir);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.tbObs);
            this.Controls.Add(this.cbPaquete);
            this.Controls.Add(this.lbTipoViaje);
            this.Controls.Add(this.comboFilial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BonoPaquete";
            this.Load += new System.EventHandler(this.BonoPaquete_Load);
            this.comboFilial.ResumeLayout(false);
            this.comboFilial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTipoViaje;
        private System.Windows.Forms.ComboBox cbPaquete;
        private System.Windows.Forms.Button AnularBono;
        private System.Windows.Forms.Button Reiniciar;
        private System.Windows.Forms.Button bntImprimir;
        private System.Windows.Forms.Button Grabar;
        private System.Windows.Forms.Button InfoPaquete;
        private System.Windows.Forms.Button Seleccion;
        private System.Windows.Forms.Button Deseleccionar;
        private System.Windows.Forms.Label lbSaldoTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button pagBono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label fpago;
        private System.Windows.Forms.DateTimePicker dpFechaBono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox comboFilial;
        private System.Windows.Forms.TextBox tbMenor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInterCirculo;
        private System.Windows.Forms.TextBox tbInvitados;
        private System.Windows.Forms.TextBox tbSocios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label InfoInvi;
        private System.Windows.Forms.Label InfoMenor;
        private System.Windows.Forms.Label infoInter;
        private System.Windows.Forms.Label infoSocio;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.CheckBox cbCocheCama;
        private System.Windows.Forms.Label lbLeyendaCocheCama;
        private System.Windows.Forms.Label lbComisionDirectiva;
        private System.Windows.Forms.ComboBox cbComisionDirectiva;
        private System.Windows.Forms.TextBox tbReciboFilial;
        private System.Windows.Forms.Label lbFilial;
        private System.Windows.Forms.ComboBox combo_Filial;
        private System.Windows.Forms.CheckBox cbFilial;
        private System.Windows.Forms.Label titPtoVenta;
        private System.Windows.Forms.CheckBox cbAfip;
        private System.Windows.Forms.CheckBox cbRecibo;
        private System.Windows.Forms.Label lbPtoVta;
    }
}
