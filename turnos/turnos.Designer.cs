namespace SOCIOS
{
    partial class turnos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(turnos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.cbPrimeraVez = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSocioAsignado = new System.Windows.Forms.Label();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lbAsignado = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVerAgenda = new System.Windows.Forms.Button();
            this.tbObraSocialContacto = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbTelefonoContacto = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTelefono = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbObraSocial = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelarDia = new System.Windows.Forms.Button();
            this.tbIdTurno = new System.Windows.Forms.TextBox();
            this.tbDiaHoraId = new System.Windows.Forms.TextBox();
            this.dpMes = new System.Windows.Forms.DateTimePicker();
            this.lbNombreSocio = new System.Windows.Forms.Label();
            this.cbProfesionales = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEspecialidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTipo = new System.Windows.Forms.TextBox();
            this.dgvListadoDias = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbObraSocial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbIntereses = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbTelefono = new System.Windows.Forms.MaskedTextBox();
            this.lbAtencion = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDias)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbObservaciones);
            this.groupBox1.Controls.Add(this.cbPrimeraVez);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbSocioAsignado);
            this.groupBox1.Controls.Add(this.btnAsignar);
            this.groupBox1.Controls.Add(this.lbAsignado);
            this.groupBox1.Location = new System.Drawing.Point(16, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 153);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL TURNO SELECCIONADO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "OBSERVACIONES:";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Location = new System.Drawing.Point(119, 122);
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.Size = new System.Drawing.Size(362, 20);
            this.tbObservaciones.TabIndex = 5;
            // 
            // cbPrimeraVez
            // 
            this.cbPrimeraVez.AutoSize = true;
            this.cbPrimeraVez.Location = new System.Drawing.Point(11, 84);
            this.cbPrimeraVez.Name = "cbPrimeraVez";
            this.cbPrimeraVez.Size = new System.Drawing.Size(99, 17);
            this.cbPrimeraVez.TabIndex = 4;
            this.cbPrimeraVez.Text = "PRIMERA VEZ";
            this.cbPrimeraVez.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(334, 81);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 35);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "CANCELAR TURNO";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 2;
            // 
            // lbSocioAsignado
            // 
            this.lbSocioAsignado.AutoSize = true;
            this.lbSocioAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSocioAsignado.Location = new System.Drawing.Point(8, 56);
            this.lbSocioAsignado.Name = "lbSocioAsignado";
            this.lbSocioAsignado.Size = new System.Drawing.Size(11, 13);
            this.lbSocioAsignado.TabIndex = 2;
            this.lbSocioAsignado.Text = "-";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAsignar.Location = new System.Drawing.Point(119, 81);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(141, 35);
            this.btnAsignar.TabIndex = 1;
            this.btnAsignar.Text = "ASIGNAR TURNO";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // lbAsignado
            // 
            this.lbAsignado.AutoSize = true;
            this.lbAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAsignado.Location = new System.Drawing.Point(8, 32);
            this.lbAsignado.Name = "lbAsignado";
            this.lbAsignado.Size = new System.Drawing.Size(11, 13);
            this.lbAsignado.TabIndex = 0;
            this.lbAsignado.Text = "-";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVerAgenda);
            this.groupBox2.Controls.Add(this.tbObraSocialContacto);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbTelefonoContacto);
            this.groupBox2.Controls.Add(this.lbEmail);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbTelefono);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbObraSocial);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnCancelarDia);
            this.groupBox2.Controls.Add(this.tbIdTurno);
            this.groupBox2.Controls.Add(this.tbDiaHoraId);
            this.groupBox2.Controls.Add(this.dpMes);
            this.groupBox2.Controls.Add(this.lbNombreSocio);
            this.groupBox2.Controls.Add(this.cbProfesionales);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbEspecialidades);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 270);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATOS DEL TURNO";
            // 
            // btnVerAgenda
            // 
            this.btnVerAgenda.Location = new System.Drawing.Point(246, 225);
            this.btnVerAgenda.Name = "btnVerAgenda";
            this.btnVerAgenda.Size = new System.Drawing.Size(235, 36);
            this.btnVerAgenda.TabIndex = 62;
            this.btnVerAgenda.Text = "VER AGENDA";
            this.btnVerAgenda.UseVisualStyleBackColor = true;
            this.btnVerAgenda.Click += new System.EventHandler(this.btnVerAgenda_Click);
            // 
            // tbObraSocialContacto
            // 
            this.tbObraSocialContacto.AutoSize = true;
            this.tbObraSocialContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObraSocialContacto.Location = new System.Drawing.Point(285, 67);
            this.tbObraSocialContacto.Name = "tbObraSocialContacto";
            this.tbObraSocialContacto.Size = new System.Drawing.Size(103, 13);
            this.tbObraSocialContacto.TabIndex = 74;
            this.tbObraSocialContacto.Text = "NO DISPONIBLE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(285, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "NO DISPONIBLE";
            // 
            // tbTelefonoContacto
            // 
            this.tbTelefonoContacto.AutoSize = true;
            this.tbTelefonoContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTelefonoContacto.Location = new System.Drawing.Point(285, 98);
            this.tbTelefonoContacto.Name = "tbTelefonoContacto";
            this.tbTelefonoContacto.Size = new System.Drawing.Size(103, 13);
            this.tbTelefonoContacto.TabIndex = 71;
            this.tbTelefonoContacto.Text = "NO DISPONIBLE";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(111, 129);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(103, 13);
            this.lbEmail.TabIndex = 70;
            this.lbEmail.Text = "NO DISPONIBLE";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 69;
            this.label9.Text = "EMAIL:";
            // 
            // lbTelefono
            // 
            this.lbTelefono.AutoSize = true;
            this.lbTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTelefono.Location = new System.Drawing.Point(111, 98);
            this.lbTelefono.Name = "lbTelefono";
            this.lbTelefono.Size = new System.Drawing.Size(103, 13);
            this.lbTelefono.TabIndex = 68;
            this.lbTelefono.Text = "NO DISPONIBLE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "TELEFONO:";
            // 
            // lbObraSocial
            // 
            this.lbObraSocial.AutoSize = true;
            this.lbObraSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObraSocial.Location = new System.Drawing.Point(111, 67);
            this.lbObraSocial.Name = "lbObraSocial";
            this.lbObraSocial.Size = new System.Drawing.Size(103, 13);
            this.lbObraSocial.TabIndex = 66;
            this.lbObraSocial.Text = "NO DISPONIBLE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "OBRA SOCIAL:";
            // 
            // btnCancelarDia
            // 
            this.btnCancelarDia.Location = new System.Drawing.Point(360, 225);
            this.btnCancelarDia.Name = "btnCancelarDia";
            this.btnCancelarDia.Size = new System.Drawing.Size(121, 36);
            this.btnCancelarDia.TabIndex = 64;
            this.btnCancelarDia.Text = "CANCELAR DIA";
            this.btnCancelarDia.UseVisualStyleBackColor = true;
            this.btnCancelarDia.Visible = false;
            this.btnCancelarDia.Click += new System.EventHandler(this.btnCancelarDia_Click);
            // 
            // tbIdTurno
            // 
            this.tbIdTurno.Location = new System.Drawing.Point(334, -4);
            this.tbIdTurno.Name = "tbIdTurno";
            this.tbIdTurno.Size = new System.Drawing.Size(101, 20);
            this.tbIdTurno.TabIndex = 63;
            this.tbIdTurno.Visible = false;
            // 
            // tbDiaHoraId
            // 
            this.tbDiaHoraId.Location = new System.Drawing.Point(227, -4);
            this.tbDiaHoraId.Name = "tbDiaHoraId";
            this.tbDiaHoraId.Size = new System.Drawing.Size(101, 20);
            this.tbDiaHoraId.TabIndex = 63;
            this.tbDiaHoraId.Visible = false;
            // 
            // dpMes
            // 
            this.dpMes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpMes.Location = new System.Drawing.Point(112, 225);
            this.dpMes.Name = "dpMes";
            this.dpMes.Size = new System.Drawing.Size(128, 20);
            this.dpMes.TabIndex = 60;
            // 
            // lbNombreSocio
            // 
            this.lbNombreSocio.AutoSize = true;
            this.lbNombreSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreSocio.Location = new System.Drawing.Point(111, 36);
            this.lbNombreSocio.Name = "lbNombreSocio";
            this.lbNombreSocio.Size = new System.Drawing.Size(45, 13);
            this.lbNombreSocio.TabIndex = 59;
            this.lbNombreSocio.Text = "SOCIO";
            // 
            // cbProfesionales
            // 
            this.cbProfesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfesionales.FormattingEnabled = true;
            this.cbProfesionales.Location = new System.Drawing.Point(112, 191);
            this.cbProfesionales.Name = "cbProfesionales";
            this.cbProfesionales.Size = new System.Drawing.Size(371, 21);
            this.cbProfesionales.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "MES:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "PROFESIONAL:";
            // 
            // cbEspecialidades
            // 
            this.cbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidades.FormattingEnabled = true;
            this.cbEspecialidades.Location = new System.Drawing.Point(112, 157);
            this.cbEspecialidades.Name = "cbEspecialidades";
            this.cbEspecialidades.Size = new System.Drawing.Size(371, 21);
            this.cbEspecialidades.TabIndex = 54;
            this.cbEspecialidades.SelectionChangeCommitted += new System.EventHandler(this.cbEspecialidades_SelectionChangeCommitted_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "ESPECIALIDAD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "SOCIO:";
            // 
            // tbTipo
            // 
            this.tbTipo.Location = new System.Drawing.Point(169, 12);
            this.tbTipo.Name = "tbTipo";
            this.tbTipo.Size = new System.Drawing.Size(61, 20);
            this.tbTipo.TabIndex = 73;
            this.tbTipo.Visible = false;
            // 
            // dgvListadoDias
            // 
            this.dgvListadoDias.AllowUserToAddRows = false;
            this.dgvListadoDias.AllowUserToDeleteRows = false;
            this.dgvListadoDias.AllowUserToResizeColumns = false;
            this.dgvListadoDias.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvListadoDias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListadoDias.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvListadoDias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListadoDias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvListadoDias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListadoDias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListadoDias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListadoDias.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListadoDias.Location = new System.Drawing.Point(8, 21);
            this.dgvListadoDias.Margin = new System.Windows.Forms.Padding(5);
            this.dgvListadoDias.MultiSelect = false;
            this.dgvListadoDias.Name = "dgvListadoDias";
            this.dgvListadoDias.ReadOnly = true;
            this.dgvListadoDias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListadoDias.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListadoDias.RowHeadersVisible = false;
            this.dgvListadoDias.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgvListadoDias.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListadoDias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoDias.Size = new System.Drawing.Size(264, 397);
            this.dgvListadoDias.TabIndex = 61;
            this.dgvListadoDias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoDias_CellClick_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvListadoDias);
            this.groupBox3.Location = new System.Drawing.Point(511, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 429);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DIAS Y HORARIOS DEL PROFESIONAL";
            // 
            // tbObraSocial
            // 
            this.tbObraSocial.Location = new System.Drawing.Point(485, 58);
            this.tbObraSocial.Name = "tbObraSocial";
            this.tbObraSocial.Size = new System.Drawing.Size(118, 20);
            this.tbObraSocial.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(414, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "O SOCIAL:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(610, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 50);
            this.button2.TabIndex = 44;
            this.button2.Text = "GUARDAR DATOS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(103, 30);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(225, 20);
            this.tbEmail.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(40, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "EMAIL:";
            // 
            // tbIntereses
            // 
            this.tbIntereses.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbIntereses.Location = new System.Drawing.Point(103, 57);
            this.tbIntereses.Name = "tbIntereses";
            this.tbIntereses.Size = new System.Drawing.Size(225, 20);
            this.tbIntereses.TabIndex = 42;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 13);
            this.label19.TabIndex = 43;
            this.label19.Text = "INTERESES:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(406, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "TELEFONO:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbTelefono);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.tbObraSocial);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.tbIntereses);
            this.groupBox4.Controls.Add(this.tbEmail);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(16, 451);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(775, 88);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "INFORMACION DE CONTACTO";
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(486, 30);
            this.tbTelefono.Mask = "99999999999999";
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(116, 20);
            this.tbTelefono.TabIndex = 41;
            // 
            // lbAtencion
            // 
            this.lbAtencion.AutoSize = true;
            this.lbAtencion.BackColor = System.Drawing.Color.Yellow;
            this.lbAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAtencion.ForeColor = System.Drawing.Color.DimGray;
            this.lbAtencion.Location = new System.Drawing.Point(16, 550);
            this.lbAtencion.Name = "lbAtencion";
            this.lbAtencion.Padding = new System.Windows.Forms.Padding(5);
            this.lbAtencion.Size = new System.Drawing.Size(10, 25);
            this.lbAtencion.TabIndex = 74;
            this.lbAtencion.Visible = false;
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(673, 558);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(101, 20);
            this.tbDNI.TabIndex = 75;
            // 
            // turnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 590);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.lbAtencion);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tbTipo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "turnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Turnos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.turnos_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDias)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbAsignado;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbSocioAsignado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnVerAgenda;
        private System.Windows.Forms.TextBox tbDiaHoraId;
        private System.Windows.Forms.DateTimePicker dpMes;
        private System.Windows.Forms.Label lbNombreSocio;
        private System.Windows.Forms.ComboBox cbProfesionales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEspecialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListadoDias;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbIdTurno;
        private System.Windows.Forms.Button btnCancelarDia;
        private System.Windows.Forms.Label lbObraSocial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbObraSocial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbIntereses;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.MaskedTextBox tbTelefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label tbTelefonoContacto;
        private System.Windows.Forms.TextBox tbTipo;
        private System.Windows.Forms.Label tbObraSocialContacto;
        private System.Windows.Forms.CheckBox cbPrimeraVez;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbObservaciones;
        private System.Windows.Forms.Label lbAtencion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbDNI;
    }
}