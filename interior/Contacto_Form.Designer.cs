namespace SOCIOS.interior
{
    partial class Contacto_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbDesde = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpInfo = new System.Windows.Forms.GroupBox();
            this.cbSocial = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbProcedencia = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbTel2 = new System.Windows.Forms.Label();
            this.lbTel1 = new System.Windows.Forms.Label();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbNroSocio = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbDni = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbFechaVisto = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbVisto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbFechaContacto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PROCESAR = new System.Windows.Forms.Button();
            this.Descartar = new System.Windows.Forms.Button();
            this.gpInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "DESDE";
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbDesde.ForeColor = System.Drawing.Color.Red;
            this.lbDesde.Location = new System.Drawing.Point(91, 28);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(14, 18);
            this.lbDesde.TabIndex = 1;
            this.lbDesde.Text = "-";
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbHasta.ForeColor = System.Drawing.Color.Red;
            this.lbHasta.Location = new System.Drawing.Point(322, 28);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(14, 18);
            this.lbHasta.TabIndex = 3;
            this.lbHasta.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(250, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "HASTA";
            // 
            // lbCantidad
            // 
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbCantidad.ForeColor = System.Drawing.Color.Red;
            this.lbCantidad.Location = new System.Drawing.Point(91, 67);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(14, 18);
            this.lbCantidad.TabIndex = 5;
            this.lbCantidad.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "PLAZAS";
            // 
            // gpInfo
            // 
            this.gpInfo.Controls.Add(this.cbSocial);
            this.gpInfo.Controls.Add(this.label1);
            this.gpInfo.Controls.Add(this.lbCantidad);
            this.gpInfo.Controls.Add(this.lbDesde);
            this.gpInfo.Controls.Add(this.label6);
            this.gpInfo.Controls.Add(this.label4);
            this.gpInfo.Controls.Add(this.lbHasta);
            this.gpInfo.Location = new System.Drawing.Point(12, 12);
            this.gpInfo.Name = "gpInfo";
            this.gpInfo.Size = new System.Drawing.Size(434, 114);
            this.gpInfo.TabIndex = 6;
            this.gpInfo.TabStop = false;
            this.gpInfo.Text = "Info Reserva";
            // 
            // cbSocial
            // 
            this.cbSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSocial.Enabled = false;
            this.cbSocial.FormattingEnabled = true;
            this.cbSocial.Location = new System.Drawing.Point(251, 64);
            this.cbSocial.Name = "cbSocial";
            this.cbSocial.Size = new System.Drawing.Size(183, 21);
            this.cbSocial.TabIndex = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbProcedencia);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lbEmail);
            this.groupBox1.Controls.Add(this.lbTel2);
            this.groupBox1.Controls.Add(this.lbTel1);
            this.groupBox1.Controls.Add(this.tbObs);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lbNombre);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbNroSocio);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbDni);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(7, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 307);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Socio";
            // 
            // lbProcedencia
            // 
            this.lbProcedencia.AutoSize = true;
            this.lbProcedencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbProcedencia.Location = new System.Drawing.Point(260, 92);
            this.lbProcedencia.Name = "lbProcedencia";
            this.lbProcedencia.Size = new System.Drawing.Size(14, 18);
            this.lbProcedencia.TabIndex = 24;
            this.lbProcedencia.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(259, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 18);
            this.label15.TabIndex = 23;
            this.label15.Text = "PROCEDENCIA";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbEmail.Location = new System.Drawing.Point(117, 148);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(14, 18);
            this.lbEmail.TabIndex = 22;
            this.lbEmail.Text = "-";
            // 
            // lbTel2
            // 
            this.lbTel2.AutoSize = true;
            this.lbTel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbTel2.Location = new System.Drawing.Point(117, 121);
            this.lbTel2.Name = "lbTel2";
            this.lbTel2.Size = new System.Drawing.Size(14, 18);
            this.lbTel2.TabIndex = 21;
            this.lbTel2.Text = "-";
            // 
            // lbTel1
            // 
            this.lbTel1.AutoSize = true;
            this.lbTel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbTel1.Location = new System.Drawing.Point(117, 92);
            this.lbTel1.Name = "lbTel1";
            this.lbTel1.Size = new System.Drawing.Size(14, 18);
            this.lbTel1.TabIndex = 20;
            this.lbTel1.Text = "-";
            // 
            // tbObs
            // 
            this.tbObs.Enabled = false;
            this.tbObs.Location = new System.Drawing.Point(14, 211);
            this.tbObs.Multiline = true;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(406, 90);
            this.tbObs.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(11, 177);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 18);
            this.label14.TabIndex = 18;
            this.label14.Text = "OBS";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(11, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 18);
            this.label13.TabIndex = 17;
            this.label13.Text = "EMAIL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(11, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 18);
            this.label12.TabIndex = 16;
            this.label12.Text = "TEL 2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(11, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 18);
            this.label11.TabIndex = 15;
            this.label11.Text = "TEL 1";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbNombre.Location = new System.Drawing.Point(117, 60);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(14, 18);
            this.lbNombre.TabIndex = 14;
            this.lbNombre.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(11, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 18);
            this.label10.TabIndex = 13;
            this.label10.Text = "NOMBRE";
            // 
            // lbNroSocio
            // 
            this.lbNroSocio.AutoSize = true;
            this.lbNroSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbNroSocio.Location = new System.Drawing.Point(391, 27);
            this.lbNroSocio.Name = "lbNroSocio";
            this.lbNroSocio.Size = new System.Drawing.Size(14, 18);
            this.lbNroSocio.TabIndex = 12;
            this.lbNroSocio.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(260, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "NRO SOCIO";
            // 
            // lbDni
            // 
            this.lbDni.AutoSize = true;
            this.lbDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbDni.Location = new System.Drawing.Point(53, 27);
            this.lbDni.Name = "lbDni";
            this.lbDni.Size = new System.Drawing.Size(14, 18);
            this.lbDni.TabIndex = 10;
            this.lbDni.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "DNI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbFechaVisto);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbVisto);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbFechaContacto);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(452, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 241);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Reserva";
            // 
            // lbFechaVisto
            // 
            this.lbFechaVisto.AutoSize = true;
            this.lbFechaVisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbFechaVisto.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbFechaVisto.Location = new System.Drawing.Point(19, 138);
            this.lbFechaVisto.Name = "lbFechaVisto";
            this.lbFechaVisto.Size = new System.Drawing.Size(14, 18);
            this.lbFechaVisto.TabIndex = 10;
            this.lbFechaVisto.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(6, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "FECHA VISTO";
            // 
            // lbVisto
            // 
            this.lbVisto.AutoSize = true;
            this.lbVisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbVisto.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbVisto.Location = new System.Drawing.Point(19, 85);
            this.lbVisto.Name = "lbVisto";
            this.lbVisto.Size = new System.Drawing.Size(14, 18);
            this.lbVisto.TabIndex = 8;
            this.lbVisto.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(19, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "VISTO";
            // 
            // lbFechaContacto
            // 
            this.lbFechaContacto.AutoSize = true;
            this.lbFechaContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbFechaContacto.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbFechaContacto.Location = new System.Drawing.Point(19, 35);
            this.lbFechaContacto.Name = "lbFechaContacto";
            this.lbFechaContacto.Size = new System.Drawing.Size(14, 18);
            this.lbFechaContacto.TabIndex = 6;
            this.lbFechaContacto.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(19, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "FECHA";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // PROCESAR
            // 
            this.PROCESAR.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PROCESAR.Location = new System.Drawing.Point(474, 280);
            this.PROCESAR.Name = "PROCESAR";
            this.PROCESAR.Size = new System.Drawing.Size(100, 56);
            this.PROCESAR.TabIndex = 9;
            this.PROCESAR.Text = "PROCESAR";
            this.PROCESAR.UseVisualStyleBackColor = true;
            this.PROCESAR.Click += new System.EventHandler(this.PROCESAR_Click);
            // 
            // Descartar
            // 
            this.Descartar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Descartar.Location = new System.Drawing.Point(474, 343);
            this.Descartar.Name = "Descartar";
            this.Descartar.Size = new System.Drawing.Size(100, 56);
            this.Descartar.TabIndex = 10;
            this.Descartar.Text = "DESCARTAR";
            this.Descartar.UseVisualStyleBackColor = true;
            this.Descartar.Click += new System.EventHandler(this.Descartar_Click);
            // 
            // Contacto_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 451);
            this.Controls.Add(this.Descartar);
            this.Controls.Add(this.PROCESAR);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpInfo);
            this.Name = "Contacto_Form";
            this.Text = "Contacto_Form";
            this.gpInfo.ResumeLayout(false);
            this.gpInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gpInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbFechaVisto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbVisto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbFechaContacto;
        private System.Windows.Forms.Label lbDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbNroSocio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbTel2;
        private System.Windows.Forms.Label lbTel1;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button PROCESAR;
        private System.Windows.Forms.ComboBox cbSocial;
        private System.Windows.Forms.Label lbProcedencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button Descartar;
    }
}