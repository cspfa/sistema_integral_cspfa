namespace SOCIOS
{
    partial class mainIngresos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbNombre = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.laTituloCargo = new System.Windows.Forms.Label();
            this.laCargo = new System.Windows.Forms.Label();
            this.laEscalafon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.laEstado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.enEntidad = new System.Windows.Forms.Label();
            this.mtbHora = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.laFecha = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.laFechaSalidaEntrada = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSalidaEntrada = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dtpInforme = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // cbNombre
            // 
            this.cbNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbNombre.FormattingEnabled = true;
            this.cbNombre.Location = new System.Drawing.Point(89, 31);
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.Size = new System.Drawing.Size(201, 21);
            this.cbNombre.TabIndex = 1;
            this.cbNombre.SelectionChangeCommitted += new System.EventHandler(this.cbNombre_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Registrar Ingreso";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // laTituloCargo
            // 
            this.laTituloCargo.AutoSize = true;
            this.laTituloCargo.Location = new System.Drawing.Point(35, 75);
            this.laTituloCargo.Name = "laTituloCargo";
            this.laTituloCargo.Size = new System.Drawing.Size(38, 13);
            this.laTituloCargo.TabIndex = 3;
            this.laTituloCargo.Text = "Cargo:";
            // 
            // laCargo
            // 
            this.laCargo.AutoSize = true;
            this.laCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.laCargo.Location = new System.Drawing.Point(89, 75);
            this.laCargo.Name = "laCargo";
            this.laCargo.Size = new System.Drawing.Size(19, 13);
            this.laCargo.TabIndex = 4;
            this.laCargo.Text = "...";
            // 
            // laEscalafon
            // 
            this.laEscalafon.AutoSize = true;
            this.laEscalafon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laEscalafon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.laEscalafon.Location = new System.Drawing.Point(89, 111);
            this.laEscalafon.Name = "laEscalafon";
            this.laEscalafon.Size = new System.Drawing.Size(19, 13);
            this.laEscalafon.TabIndex = 6;
            this.laEscalafon.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Escalafón:";
            // 
            // laEstado
            // 
            this.laEstado.AutoSize = true;
            this.laEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.laEstado.Location = new System.Drawing.Point(89, 147);
            this.laEstado.Name = "laEstado";
            this.laEstado.Size = new System.Drawing.Size(19, 13);
            this.laEstado.TabIndex = 8;
            this.laEstado.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Estado:";
            // 
            // enEntidad
            // 
            this.enEntidad.AutoSize = true;
            this.enEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enEntidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.enEntidad.Location = new System.Drawing.Point(310, 35);
            this.enEntidad.Name = "enEntidad";
            this.enEntidad.Size = new System.Drawing.Size(192, 13);
            this.enEntidad.TabIndex = 9;
            this.enEntidad.Text = "No se seleccionó ningún nombre";
            // 
            // mtbHora
            // 
            this.mtbHora.Location = new System.Drawing.Point(392, 144);
            this.mtbHora.Mask = "00:00";
            this.mtbHora.Name = "mtbHora";
            this.mtbHora.Size = new System.Drawing.Size(42, 20);
            this.mtbHora.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.laFecha);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.mtbHora);
            this.groupBox1.Controls.Add(this.laFechaSalidaEntrada);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbSalidaEntrada);
            this.groupBox1.Controls.Add(this.cbNombre);
            this.groupBox1.Controls.Add(this.enEntidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.laTituloCargo);
            this.groupBox1.Controls.Add(this.laCargo);
            this.groupBox1.Controls.Add(this.laEstado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.laEscalafon);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 181);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la persona";
            // 
            // laFecha
            // 
            this.laFecha.Location = new System.Drawing.Point(392, 108);
            this.laFecha.Mask = "00/00/0000";
            this.laFecha.Name = "laFecha";
            this.laFecha.Size = new System.Drawing.Size(78, 20);
            this.laFecha.TabIndex = 12;
            this.laFecha.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Hora:";
            // 
            // laFechaSalidaEntrada
            // 
            this.laFechaSalidaEntrada.AutoSize = true;
            this.laFechaSalidaEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laFechaSalidaEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.laFechaSalidaEntrada.Location = new System.Drawing.Point(392, 75);
            this.laFechaSalidaEntrada.Name = "laFechaSalidaEntrada";
            this.laFechaSalidaEntrada.Size = new System.Drawing.Size(19, 13);
            this.laFechaSalidaEntrada.TabIndex = 11;
            this.laFechaSalidaEntrada.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha:";
            // 
            // lbSalidaEntrada
            // 
            this.lbSalidaEntrada.AutoSize = true;
            this.lbSalidaEntrada.Location = new System.Drawing.Point(310, 75);
            this.lbSalidaEntrada.Name = "lbSalidaEntrada";
            this.lbSalidaEntrada.Size = new System.Drawing.Size(69, 13);
            this.lbSalidaEntrada.TabIndex = 10;
            this.lbSalidaEntrada.Text = "Ultima salida:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Imprimir informe";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // dtpInforme
            // 
            this.dtpInforme.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInforme.Location = new System.Drawing.Point(118, 216);
            this.dtpInforme.Name = "dtpInforme";
            this.dtpInforme.Size = new System.Drawing.Size(111, 20);
            this.dtpInforme.TabIndex = 17;
            this.dtpInforme.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha del informe:";
            this.label2.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 249);
            this.Controls.Add(this.dtpInforme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(610, 287);
            this.MinimumSize = new System.Drawing.Size(610, 287);
            this.Name = "mainForm";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Ingreso del Personal y Directivos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNombre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label laTituloCargo;
        private System.Windows.Forms.Label laCargo;
        private System.Windows.Forms.Label laEscalafon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label laEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label enEntidad;
        private System.Windows.Forms.MaskedTextBox mtbHora;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSalidaEntrada;
        private System.Windows.Forms.Label laFechaSalidaEntrada;
        private System.Windows.Forms.MaskedTextBox laFecha;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtpInforme;
        private System.Windows.Forms.Label label2;
    }
}

