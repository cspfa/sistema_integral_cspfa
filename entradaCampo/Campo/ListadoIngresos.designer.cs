namespace SOCIOS.Entrada_Campo
{
    partial class ListadoIngresos
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
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.Cancelar = new System.Windows.Forms.Button();
            this.ReintegrarIngreso = new System.Windows.Forms.Button();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ID_HASTA = new System.Windows.Forms.TextBox();
            this.ID_DESDE = new System.Windows.Forms.TextBox();
            this.chkID = new System.Windows.Forms.CheckBox();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.gpRol = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbROL = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTotal = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.Reimprimir = new System.Windows.Forms.Button();
            this.reintegroParcial = new System.Windows.Forms.Button();
            this.gpUsuario = new System.Windows.Forms.GroupBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btn_Reintegro_Evento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpRol.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpUsuario.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.AllowUserToDeleteRows = false;
            this.dgvIngresos.AllowUserToOrderColumns = true;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Location = new System.Drawing.Point(12, 161);
            this.dgvIngresos.MultiSelect = false;
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngresos.Size = new System.Drawing.Size(870, 302);
            this.dgvIngresos.TabIndex = 0;
            this.dgvIngresos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngresos_CellClick);
            this.dgvIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngresos_CellContentClick);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(491, 495);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 1;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Visible = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // ReintegrarIngreso
            // 
            this.ReintegrarIngreso.Location = new System.Drawing.Point(730, 478);
            this.ReintegrarIngreso.Name = "ReintegrarIngreso";
            this.ReintegrarIngreso.Size = new System.Drawing.Size(152, 23);
            this.ReintegrarIngreso.TabIndex = 2;
            this.ReintegrarIngreso.Text = "Reintegrar Total";
            this.ReintegrarIngreso.UseVisualStyleBackColor = true;
            this.ReintegrarIngreso.Click += new System.EventHandler(this.ReintegrarIngreso_Click);
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Checked = true;
            this.chkFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFecha.Location = new System.Drawing.Point(104, 19);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(100, 17);
            this.chkFecha.TabIndex = 3;
            this.chkFecha.Text = "Fitrar por Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbApellido);
            this.groupBox1.Controls.Add(this.tbNombre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbDni);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ID_HASTA);
            this.groupBox1.Controls.Add(this.ID_DESDE);
            this.groupBox1.Controls.Add(this.chkID);
            this.groupBox1.Controls.Add(this.dpHasta);
            this.groupBox1.Controls.Add(this.dpDesde);
            this.groupBox1.Controls.Add(this.chkFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(449, 66);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(80, 20);
            this.tbApellido.TabIndex = 18;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(449, 44);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(80, 20);
            this.tbNombre.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(389, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "APELLIDO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "NOMBRE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "DNI";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbDni
            // 
            this.tbDni.Location = new System.Drawing.Point(447, 20);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(80, 20);
            this.tbDni.TabIndex = 13;
            this.tbDni.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Desde";
            // 
            // ID_HASTA
            // 
            this.ID_HASTA.Location = new System.Drawing.Point(330, 65);
            this.ID_HASTA.Name = "ID_HASTA";
            this.ID_HASTA.Size = new System.Drawing.Size(42, 20);
            this.ID_HASTA.TabIndex = 8;
            this.ID_HASTA.Text = "0";
            this.ID_HASTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ID_DESDE
            // 
            this.ID_DESDE.Location = new System.Drawing.Point(330, 44);
            this.ID_DESDE.Name = "ID_DESDE";
            this.ID_DESDE.Size = new System.Drawing.Size(42, 20);
            this.ID_DESDE.TabIndex = 7;
            this.ID_DESDE.Text = "0";
            this.ID_DESDE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkID
            // 
            this.chkID.AutoSize = true;
            this.chkID.Location = new System.Drawing.Point(272, 19);
            this.chkID.Name = "chkID";
            this.chkID.Size = new System.Drawing.Size(81, 17);
            this.chkID.TabIndex = 6;
            this.chkID.Text = "Fitrar por ID";
            this.chkID.UseVisualStyleBackColor = true;
            // 
            // dpHasta
            // 
            this.dpHasta.Location = new System.Drawing.Point(49, 63);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(200, 20);
            this.dpHasta.TabIndex = 5;
            // 
            // dpDesde
            // 
            this.dpDesde.Location = new System.Drawing.Point(49, 41);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(200, 20);
            this.dpDesde.TabIndex = 4;
            // 
            // gpRol
            // 
            this.gpRol.Controls.Add(this.groupBox2);
            this.gpRol.Controls.Add(this.cbROL);
            this.gpRol.Location = new System.Drawing.Point(582, 12);
            this.gpRol.Name = "gpRol";
            this.gpRol.Size = new System.Drawing.Size(200, 64);
            this.gpRol.TabIndex = 5;
            this.gpRol.TabStop = false;
            this.gpRol.Text = "Filtrar Por ROL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(0, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 52);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtrar Por ROL";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CPOCABA",
            "CPORANELAGH",
            "CPOPOLVORINES"});
            this.comboBox1.Location = new System.Drawing.Point(19, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // cbROL
            // 
            this.cbROL.FormattingEnabled = true;
            this.cbROL.Items.AddRange(new object[] {
            "CPOCABA",
            "CPORANELAGH",
            "CPOPOLVORINES"});
            this.cbROL.Location = new System.Drawing.Point(19, 29);
            this.cbROL.Name = "cbROL";
            this.cbROL.Size = new System.Drawing.Size(157, 21);
            this.cbROL.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(797, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(16, 495);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(103, 23);
            this.btnTotal.TabIndex = 7;
            this.btnTotal.Text = "TOTAL DIA";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(164, 495);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(92, 23);
            this.btnReporte.TabIndex = 8;
            this.btnReporte.Text = "Reporte ";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // Reimprimir
            // 
            this.Reimprimir.Location = new System.Drawing.Point(279, 495);
            this.Reimprimir.Name = "Reimprimir";
            this.Reimprimir.Size = new System.Drawing.Size(75, 23);
            this.Reimprimir.TabIndex = 9;
            this.Reimprimir.Text = "Reimprimir";
            this.Reimprimir.UseVisualStyleBackColor = true;
            this.Reimprimir.Click += new System.EventHandler(this.Reimprimir_Click);
            // 
            // reintegroParcial
            // 
            this.reintegroParcial.Location = new System.Drawing.Point(572, 478);
            this.reintegroParcial.Name = "reintegroParcial";
            this.reintegroParcial.Size = new System.Drawing.Size(152, 23);
            this.reintegroParcial.TabIndex = 10;
            this.reintegroParcial.Text = "Reintegrar Parcial";
            this.reintegroParcial.UseVisualStyleBackColor = true;
            this.reintegroParcial.Click += new System.EventHandler(this.reintegroParcial_Click);
            // 
            // gpUsuario
            // 
            this.gpUsuario.Controls.Add(this.tbUser);
            this.gpUsuario.Controls.Add(this.groupBox4);
            this.gpUsuario.Location = new System.Drawing.Point(582, 82);
            this.gpUsuario.Name = "gpUsuario";
            this.gpUsuario.Size = new System.Drawing.Size(200, 64);
            this.gpUsuario.TabIndex = 8;
            this.gpUsuario.TabStop = false;
            this.gpUsuario.Text = "Filtrar Por USUARIO";
            // 
            // tbUser
            // 
            this.tbUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUser.Location = new System.Drawing.Point(19, 27);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(157, 20);
            this.tbUser.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Location = new System.Drawing.Point(0, 63);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 52);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtrar Por ROL";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "CPOCABA",
            "CPORANELAGH",
            "CPOPOLVORINES"});
            this.comboBox2.Location = new System.Drawing.Point(19, 29);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(157, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // btn_Reintegro_Evento
            // 
            this.btn_Reintegro_Evento.Location = new System.Drawing.Point(630, 507);
            this.btn_Reintegro_Evento.Name = "btn_Reintegro_Evento";
            this.btn_Reintegro_Evento.Size = new System.Drawing.Size(184, 23);
            this.btn_Reintegro_Evento.TabIndex = 11;
            this.btn_Reintegro_Evento.Text = "Reintegro Parcial Est.Evento";
            this.btn_Reintegro_Evento.UseVisualStyleBackColor = true;
            this.btn_Reintegro_Evento.Click += new System.EventHandler(this.btn_Reintegro_Evento_Click);
            // 
            // ListadoIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 530);
            this.Controls.Add(this.btn_Reintegro_Evento);
            this.Controls.Add(this.gpUsuario);
            this.Controls.Add(this.reintegroParcial);
            this.Controls.Add(this.Reimprimir);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gpRol);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ReintegrarIngreso);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.dgvIngresos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ListadoIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultimos Ingresos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpRol.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gpUsuario.ResumeLayout(false);
            this.gpUsuario.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button ReintegrarIngreso;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID_HASTA;
        private System.Windows.Forms.TextBox ID_DESDE;
        private System.Windows.Forms.CheckBox chkID;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.GroupBox gpRol;
        private System.Windows.Forms.ComboBox cbROL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button Reimprimir;
        private System.Windows.Forms.Button reintegroParcial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox gpUsuario;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btn_Reintegro_Evento;
    }
}