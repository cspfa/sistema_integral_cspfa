namespace SOCIOS
{
    partial class solicitudTitular
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
            this.dtpADTO = new System.Windows.Forms.DateTimePicker();
            this.cbOrigenAlta = new System.Windows.Forms.ComboBox();
            this.btnVer = new System.Windows.Forms.Button();
            this.rbPasividad = new System.Windows.Forms.RadioButton();
            this.rbActividad = new System.Windows.Forms.RadioButton();
            this.rbAlfabetico = new System.Windows.Forms.RadioButton();
            this.rbAfiliado = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLegajo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbO = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbA = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.mtbPCRJP3 = new System.Windows.Forms.MaskedTextBox();
            this.mtbPCRJP2 = new System.Windows.Forms.MaskedTextBox();
            this.mtbPCRJP1 = new System.Windows.Forms.MaskedTextBox();
            this.laIndividual = new System.Windows.Forms.Label();
            this.mtbACRJP2 = new System.Windows.Forms.MaskedTextBox();
            this.mtbAAR = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbAlta = new System.Windows.Forms.RadioButton();
            this.rbBaja = new System.Windows.Forms.RadioButton();
            this.newDataSet1 = new SOCIOS.NewDataSet();
            this.newDataSet2 = new SOCIOS.NewDataSet();
            this.newDataSet3 = new SOCIOS.NewDataSet();
            this.gbDestino = new System.Windows.Forms.GroupBox();
            this.cbD = new System.Windows.Forms.CheckBox();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbRangoLP = new System.Windows.Forms.CheckBox();
            this.tbDesde = new System.Windows.Forms.TextBox();
            this.tbHasta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet3)).BeginInit();
            this.gbDestino.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpADTO
            // 
            this.dtpADTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpADTO.Location = new System.Drawing.Point(58, 32);
            this.dtpADTO.Name = "dtpADTO";
            this.dtpADTO.Size = new System.Drawing.Size(104, 20);
            this.dtpADTO.TabIndex = 18;
            // 
            // cbOrigenAlta
            // 
            this.cbOrigenAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigenAlta.FormattingEnabled = true;
            this.cbOrigenAlta.Location = new System.Drawing.Point(46, 31);
            this.cbOrigenAlta.Name = "cbOrigenAlta";
            this.cbOrigenAlta.Size = new System.Drawing.Size(152, 21);
            this.cbOrigenAlta.TabIndex = 17;
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(814, 103);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(185, 29);
            this.btnVer.TabIndex = 15;
            this.btnVer.Text = "IMPRIMIR SOLICITUDES";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // rbPasividad
            // 
            this.rbPasividad.AutoSize = true;
            this.rbPasividad.Location = new System.Drawing.Point(93, 33);
            this.rbPasividad.Name = "rbPasividad";
            this.rbPasividad.Size = new System.Drawing.Size(71, 17);
            this.rbPasividad.TabIndex = 20;
            this.rbPasividad.TabStop = true;
            this.rbPasividad.Text = "Pasividad";
            this.rbPasividad.UseVisualStyleBackColor = true;
            this.rbPasividad.Click += new System.EventHandler(this.rbPasividad_Click);
            // 
            // rbActividad
            // 
            this.rbActividad.AutoSize = true;
            this.rbActividad.Location = new System.Drawing.Point(18, 33);
            this.rbActividad.Name = "rbActividad";
            this.rbActividad.Size = new System.Drawing.Size(69, 17);
            this.rbActividad.TabIndex = 19;
            this.rbActividad.TabStop = true;
            this.rbActividad.Text = "Actividad";
            this.rbActividad.UseVisualStyleBackColor = true;
            this.rbActividad.Click += new System.EventHandler(this.rbActividad_Click);
            // 
            // rbAlfabetico
            // 
            this.rbAlfabetico.AutoSize = true;
            this.rbAlfabetico.Location = new System.Drawing.Point(17, 33);
            this.rbAlfabetico.Name = "rbAlfabetico";
            this.rbAlfabetico.Size = new System.Drawing.Size(72, 17);
            this.rbAlfabetico.TabIndex = 21;
            this.rbAlfabetico.TabStop = true;
            this.rbAlfabetico.Text = "Alfabético";
            this.rbAlfabetico.UseVisualStyleBackColor = true;
            // 
            // rbAfiliado
            // 
            this.rbAfiliado.AutoSize = true;
            this.rbAfiliado.Location = new System.Drawing.Point(95, 33);
            this.rbAfiliado.Name = "rbAfiliado";
            this.rbAfiliado.Size = new System.Drawing.Size(59, 17);
            this.rbAfiliado.TabIndex = 22;
            this.rbAfiliado.TabStop = true;
            this.rbAfiliado.Text = "Afiliado";
            this.rbAfiliado.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLegajo);
            this.groupBox1.Controls.Add(this.rbAlfabetico);
            this.groupBox1.Controls.Add(this.rbAfiliado);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 74);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenamiento";
            // 
            // rbLegajo
            // 
            this.rbLegajo.AutoSize = true;
            this.rbLegajo.Location = new System.Drawing.Point(160, 33);
            this.rbLegajo.Name = "rbLegajo";
            this.rbLegajo.Size = new System.Drawing.Size(38, 17);
            this.rbLegajo.TabIndex = 23;
            this.rbLegajo.TabStop = true;
            this.rbLegajo.Text = "LP";
            this.rbLegajo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbActividad);
            this.groupBox2.Controls.Add(this.rbPasividad);
            this.groupBox2.Location = new System.Drawing.Point(225, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 74);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado Policial";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbO);
            this.groupBox3.Controls.Add(this.cbOrigenAlta);
            this.groupBox3.Location = new System.Drawing.Point(12, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 74);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Origen Alta";
            // 
            // cbO
            // 
            this.cbO.AutoSize = true;
            this.cbO.Location = new System.Drawing.Point(14, 35);
            this.cbO.Name = "cbO";
            this.cbO.Size = new System.Drawing.Size(15, 14);
            this.cbO.TabIndex = 19;
            this.cbO.UseVisualStyleBackColor = true;
            this.cbO.CheckedChanged += new System.EventHandler(this.cbO_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbA);
            this.groupBox4.Controls.Add(this.dtpADTO);
            this.groupBox4.Location = new System.Drawing.Point(622, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(185, 74);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ADTO";
            // 
            // cbA
            // 
            this.cbA.AutoSize = true;
            this.cbA.Location = new System.Drawing.Point(18, 34);
            this.cbA.Name = "cbA";
            this.cbA.Size = new System.Drawing.Size(15, 14);
            this.cbA.TabIndex = 20;
            this.cbA.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.mtbPCRJP3);
            this.groupBox5.Controls.Add(this.mtbPCRJP2);
            this.groupBox5.Controls.Add(this.mtbPCRJP1);
            this.groupBox5.Controls.Add(this.laIndividual);
            this.groupBox5.Controls.Add(this.mtbACRJP2);
            this.groupBox5.Controls.Add(this.mtbAAR);
            this.groupBox5.Location = new System.Drawing.Point(416, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 74);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Solicitud Individual";
            // 
            // mtbPCRJP3
            // 
            this.mtbPCRJP3.Location = new System.Drawing.Point(158, 31);
            this.mtbPCRJP3.Mask = "9";
            this.mtbPCRJP3.Name = "mtbPCRJP3";
            this.mtbPCRJP3.Size = new System.Drawing.Size(21, 20);
            this.mtbPCRJP3.TabIndex = 5;
            // 
            // mtbPCRJP2
            // 
            this.mtbPCRJP2.Location = new System.Drawing.Point(100, 31);
            this.mtbPCRJP2.Mask = "999999";
            this.mtbPCRJP2.Name = "mtbPCRJP2";
            this.mtbPCRJP2.Size = new System.Drawing.Size(52, 20);
            this.mtbPCRJP2.TabIndex = 4;
            // 
            // mtbPCRJP1
            // 
            this.mtbPCRJP1.Location = new System.Drawing.Point(73, 31);
            this.mtbPCRJP1.Mask = "99";
            this.mtbPCRJP1.Name = "mtbPCRJP1";
            this.mtbPCRJP1.Size = new System.Drawing.Size(21, 20);
            this.mtbPCRJP1.TabIndex = 3;
            // 
            // laIndividual
            // 
            this.laIndividual.AutoSize = true;
            this.laIndividual.Location = new System.Drawing.Point(21, 35);
            this.laIndividual.Name = "laIndividual";
            this.laIndividual.Size = new System.Drawing.Size(41, 13);
            this.laIndividual.TabIndex = 2;
            this.laIndividual.Text = "Afiliado";
            // 
            // mtbACRJP2
            // 
            this.mtbACRJP2.Location = new System.Drawing.Point(100, 31);
            this.mtbACRJP2.Mask = "999999";
            this.mtbACRJP2.Name = "mtbACRJP2";
            this.mtbACRJP2.Size = new System.Drawing.Size(52, 20);
            this.mtbACRJP2.TabIndex = 1;
            // 
            // mtbAAR
            // 
            this.mtbAAR.Location = new System.Drawing.Point(73, 31);
            this.mtbAAR.Mask = "9";
            this.mtbAAR.Name = "mtbAAR";
            this.mtbAAR.Size = new System.Drawing.Size(21, 20);
            this.mtbAAR.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(814, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 29);
            this.button2.TabIndex = 29;
            this.button2.Text = "IMPRIMIR EN TRIPTICO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbAlta);
            this.groupBox6.Controls.Add(this.rbBaja);
            this.groupBox6.Location = new System.Drawing.Point(622, 97);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(185, 74);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Estado CSPFA";
            // 
            // rbAlta
            // 
            this.rbAlta.AutoSize = true;
            this.rbAlta.Location = new System.Drawing.Point(18, 33);
            this.rbAlta.Name = "rbAlta";
            this.rbAlta.Size = new System.Drawing.Size(43, 17);
            this.rbAlta.TabIndex = 19;
            this.rbAlta.TabStop = true;
            this.rbAlta.Text = "Alta";
            this.rbAlta.UseVisualStyleBackColor = true;
            // 
            // rbBaja
            // 
            this.rbBaja.AutoSize = true;
            this.rbBaja.Location = new System.Drawing.Point(121, 33);
            this.rbBaja.Name = "rbBaja";
            this.rbBaja.Size = new System.Drawing.Size(46, 17);
            this.rbBaja.TabIndex = 20;
            this.rbBaja.TabStop = true;
            this.rbBaja.Text = "Baja";
            this.rbBaja.UseVisualStyleBackColor = true;
            // 
            // newDataSet1
            // 
            this.newDataSet1.DataSetName = "NewDataSet";
            this.newDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // newDataSet2
            // 
            this.newDataSet2.DataSetName = "NewDataSet";
            this.newDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // newDataSet3
            // 
            this.newDataSet3.DataSetName = "NewDataSet";
            this.newDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gbDestino
            // 
            this.gbDestino.Controls.Add(this.cbD);
            this.gbDestino.Controls.Add(this.cbDestino);
            this.gbDestino.Enabled = false;
            this.gbDestino.Location = new System.Drawing.Point(225, 97);
            this.gbDestino.Name = "gbDestino";
            this.gbDestino.Size = new System.Drawing.Size(391, 74);
            this.gbDestino.TabIndex = 26;
            this.gbDestino.TabStop = false;
            this.gbDestino.Text = "Destino";
            // 
            // cbD
            // 
            this.cbD.AutoSize = true;
            this.cbD.Location = new System.Drawing.Point(14, 35);
            this.cbD.Name = "cbD";
            this.cbD.Size = new System.Drawing.Size(15, 14);
            this.cbD.TabIndex = 19;
            this.cbD.UseVisualStyleBackColor = true;
            // 
            // cbDestino
            // 
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(46, 31);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(324, 21);
            this.cbDestino.TabIndex = 17;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.tbHasta);
            this.groupBox7.Controls.Add(this.tbDesde);
            this.groupBox7.Controls.Add(this.cbRangoLP);
            this.groupBox7.Location = new System.Drawing.Point(813, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(186, 74);
            this.groupBox7.TabIndex = 27;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "RANGO LP";
            // 
            // cbRangoLP
            // 
            this.cbRangoLP.AutoSize = true;
            this.cbRangoLP.Location = new System.Drawing.Point(18, 32);
            this.cbRangoLP.Name = "cbRangoLP";
            this.cbRangoLP.Size = new System.Drawing.Size(15, 14);
            this.cbRangoLP.TabIndex = 20;
            this.cbRangoLP.UseVisualStyleBackColor = true;
            // 
            // tbDesde
            // 
            this.tbDesde.Location = new System.Drawing.Point(40, 29);
            this.tbDesde.Name = "tbDesde";
            this.tbDesde.Size = new System.Drawing.Size(49, 20);
            this.tbDesde.TabIndex = 21;
            // 
            // tbHasta
            // 
            this.tbHasta.Location = new System.Drawing.Point(113, 29);
            this.tbHasta.Name = "tbHasta";
            this.tbHasta.Size = new System.Drawing.Size(49, 20);
            this.tbHasta.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "-";
            // 
            // solicitudTitular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 182);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.gbDestino);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "solicitudTitular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solicitud Titular";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet3)).EndInit();
            this.gbDestino.ResumeLayout(false);
            this.gbDestino.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpADTO;
        private System.Windows.Forms.ComboBox cbOrigenAlta;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.RadioButton rbPasividad;
        private System.Windows.Forms.RadioButton rbActividad;
        private System.Windows.Forms.RadioButton rbAlfabetico;
        private System.Windows.Forms.RadioButton rbAfiliado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label laIndividual;
        private System.Windows.Forms.MaskedTextBox mtbACRJP2;
        private System.Windows.Forms.MaskedTextBox mtbAAR;
        private System.Windows.Forms.MaskedTextBox mtbPCRJP3;
        private System.Windows.Forms.MaskedTextBox mtbPCRJP2;
        private System.Windows.Forms.MaskedTextBox mtbPCRJP1;
        private System.Windows.Forms.CheckBox cbO;
        private System.Windows.Forms.CheckBox cbA;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbLegajo;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbAlta;
        private System.Windows.Forms.RadioButton rbBaja;
        private NewDataSet newDataSet1;
        private NewDataSet newDataSet2;
        private NewDataSet newDataSet3;
        private System.Windows.Forms.GroupBox gbDestino;
        private System.Windows.Forms.CheckBox cbD;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cbRangoLP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHasta;
        private System.Windows.Forms.TextBox tbDesde;
    }
}