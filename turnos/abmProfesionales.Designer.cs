namespace SOCIOS
{
    partial class abmProfesionales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgProfesionales = new System.Windows.Forms.DataGridView();
            this.ROL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTRATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BONO_RECIBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESPECIALIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbFiltroRoles = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbIdProf = new System.Windows.Forms.Label();
            this.btModificar = new System.Windows.Forms.Button();
            this.cbComprobante = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCuenta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cbContratos = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEspecialidades = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cbRolesNuevo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbEspec = new System.Windows.Forms.ComboBox();
            this.cbEspecNuevo = new System.Windows.Forms.Label();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbProfesionales = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbDetalle = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfesionales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgProfesionales
            // 
            this.dgProfesionales.AllowUserToAddRows = false;
            this.dgProfesionales.AllowUserToDeleteRows = false;
            this.dgProfesionales.AllowUserToResizeColumns = false;
            this.dgProfesionales.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgProfesionales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProfesionales.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgProfesionales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProfesionales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProfesionales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROL,
            this.DETALLE,
            this.NOMBRE,
            this.CONTRATO,
            this.BONO_RECIBO,
            this.CUENTA,
            this.ID,
            this.ESPECIALIDAD});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProfesionales.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgProfesionales.Location = new System.Drawing.Point(14, 45);
            this.dgProfesionales.Margin = new System.Windows.Forms.Padding(5);
            this.dgProfesionales.Name = "dgProfesionales";
            this.dgProfesionales.ReadOnly = true;
            this.dgProfesionales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProfesionales.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProfesionales.RowHeadersVisible = false;
            this.dgProfesionales.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgProfesionales.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProfesionales.Size = new System.Drawing.Size(946, 244);
            this.dgProfesionales.TabIndex = 48;
            this.dgProfesionales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProfesionales_CellClick);
            // 
            // ROL
            // 
            this.ROL.HeaderText = "ROL";
            this.ROL.Name = "ROL";
            this.ROL.ReadOnly = true;
            this.ROL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ROL.Width = 180;
            // 
            // DETALLE
            // 
            this.DETALLE.HeaderText = "DETALLE";
            this.DETALLE.Name = "DETALLE";
            this.DETALLE.ReadOnly = true;
            this.DETALLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DETALLE.Width = 200;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NOMBRE.Width = 240;
            // 
            // CONTRATO
            // 
            this.CONTRATO.HeaderText = "CONTRATO";
            this.CONTRATO.Name = "CONTRATO";
            this.CONTRATO.ReadOnly = true;
            this.CONTRATO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CONTRATO.Width = 150;
            // 
            // BONO_RECIBO
            // 
            this.BONO_RECIBO.HeaderText = "C";
            this.BONO_RECIBO.Name = "BONO_RECIBO";
            this.BONO_RECIBO.ReadOnly = true;
            this.BONO_RECIBO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BONO_RECIBO.Width = 50;
            // 
            // CUENTA
            // 
            this.CUENTA.HeaderText = "CUENTA";
            this.CUENTA.Name = "CUENTA";
            this.CUENTA.ReadOnly = true;
            this.CUENTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Visible = false;
            // 
            // ESPECIALIDAD
            // 
            this.ESPECIALIDAD.HeaderText = "ESPECIALIDAD";
            this.ESPECIALIDAD.Name = "ESPECIALIDAD";
            this.ESPECIALIDAD.ReadOnly = true;
            this.ESPECIALIDAD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ESPECIALIDAD.Visible = false;
            // 
            // cbFiltroRoles
            // 
            this.cbFiltroRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroRoles.FormattingEnabled = true;
            this.cbFiltroRoles.Location = new System.Drawing.Point(67, 11);
            this.cbFiltroRoles.Name = "cbFiltroRoles";
            this.cbFiltroRoles.Size = new System.Drawing.Size(239, 21);
            this.cbFiltroRoles.TabIndex = 49;
            this.cbFiltroRoles.SelectionChangeCommitted += new System.EventHandler(this.cbFiltroRoles_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(648, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "FILTRAR !";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(761, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "ELIMINAR PROFESIONAL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbIdProf
            // 
            this.lbIdProf.AutoSize = true;
            this.lbIdProf.Location = new System.Drawing.Point(615, 363);
            this.lbIdProf.Name = "lbIdProf";
            this.lbIdProf.Size = new System.Drawing.Size(13, 13);
            this.lbIdProf.TabIndex = 74;
            this.lbIdProf.Text = "0";
            this.lbIdProf.Visible = false;
            // 
            // btModificar
            // 
            this.btModificar.Enabled = false;
            this.btModificar.Location = new System.Drawing.Point(761, 332);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(200, 30);
            this.btModificar.TabIndex = 12;
            this.btModificar.Text = "MODIFICAR PROFESIONAL";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click_1);
            // 
            // cbComprobante
            // 
            this.cbComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComprobante.FormattingEnabled = true;
            this.cbComprobante.Location = new System.Drawing.Point(136, 410);
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.Size = new System.Drawing.Size(197, 21);
            this.cbComprobante.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(41, 414);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 72;
            this.label12.Text = "COMPROBANTE";
            // 
            // tbCuenta
            // 
            this.tbCuenta.Location = new System.Drawing.Point(442, 410);
            this.tbCuenta.Name = "tbCuenta";
            this.tbCuenta.Size = new System.Drawing.Size(99, 20);
            this.tbCuenta.TabIndex = 8;
            this.tbCuenta.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(385, 414);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "CUENTA";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(761, 404);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 30);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "LIMPIAR FORMULARIO";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(761, 296);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(200, 30);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "AGREGAR PROFESIONAL";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cbContratos
            // 
            this.cbContratos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContratos.FormattingEnabled = true;
            this.cbContratos.Location = new System.Drawing.Point(136, 384);
            this.cbContratos.Name = "cbContratos";
            this.cbContratos.Size = new System.Drawing.Size(197, 21);
            this.cbContratos.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 68;
            this.label10.Text = "CONTRATO";
            // 
            // tbCorreo
            // 
            this.tbCorreo.Location = new System.Drawing.Point(136, 359);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(197, 20);
            this.tbCorreo.TabIndex = 3;
            this.tbCorreo.Text = "@";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "CORREO";
            // 
            // tbCelular
            // 
            this.tbCelular.Location = new System.Drawing.Point(615, 410);
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(99, 20);
            this.tbCelular.TabIndex = 10;
            this.tbCelular.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "CELULAR";
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(442, 384);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(99, 20);
            this.tbTelefono.TabIndex = 7;
            this.tbTelefono.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "TELEFONO";
            // 
            // cbEspecialidades
            // 
            this.cbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidades.FormattingEnabled = true;
            this.cbEspecialidades.Location = new System.Drawing.Point(136, 330);
            this.cbEspecialidades.Name = "cbEspecialidades";
            this.cbEspecialidades.Size = new System.Drawing.Size(405, 21);
            this.cbEspecialidades.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "ESPECIALIDAD";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(615, 384);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(99, 20);
            this.tbDNI.TabIndex = 9;
            this.tbDNI.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "DNI";
            // 
            // tbMatricula
            // 
            this.tbMatricula.Location = new System.Drawing.Point(442, 359);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(99, 20);
            this.tbMatricula.TabIndex = 6;
            this.tbMatricula.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "MATRICULA";
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Location = new System.Drawing.Point(136, 304);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(405, 20);
            this.tbNombre.TabIndex = 1;
            this.tbNombre.Text = "EMPLEADOS CSPFA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "NOMBRE Y APELLIDO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.cbRolesNuevo);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbEspec);
            this.groupBox1.Controls.Add(this.cbEspecNuevo);
            this.groupBox1.Controls.Add(this.cbRoles);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbProfesionales);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 453);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 164);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AGREGAR PROFESIONAL A SECTOR O ACTIVIDAD";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(452, 117);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(259, 30);
            this.btnAgregar.TabIndex = 76;
            this.btnAgregar.Text = "AGREGAR PROFESIONAL";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cbRolesNuevo
            // 
            this.cbRolesNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRolesNuevo.FormattingEnabled = true;
            this.cbRolesNuevo.Location = new System.Drawing.Point(452, 61);
            this.cbRolesNuevo.Name = "cbRolesNuevo";
            this.cbRolesNuevo.Size = new System.Drawing.Size(259, 21);
            this.cbRolesNuevo.TabIndex = 82;
            this.cbRolesNuevo.SelectionChangeCommitted += new System.EventHandler(this.cbRolesNuevo_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(396, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "ROLES";
            // 
            // cbEspec
            // 
            this.cbEspec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspec.FormattingEnabled = true;
            this.cbEspec.Location = new System.Drawing.Point(452, 90);
            this.cbEspec.Name = "cbEspec";
            this.cbEspec.Size = new System.Drawing.Size(259, 21);
            this.cbEspec.TabIndex = 80;
            // 
            // cbEspecNuevo
            // 
            this.cbEspecNuevo.AutoSize = true;
            this.cbEspecNuevo.Location = new System.Drawing.Point(341, 94);
            this.cbEspecNuevo.Name = "cbEspecNuevo";
            this.cbEspecNuevo.Size = new System.Drawing.Size(98, 13);
            this.cbEspecNuevo.TabIndex = 81;
            this.cbEspecNuevo.Text = "ESPECIALIDADES";
            // 
            // cbRoles
            // 
            this.cbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(72, 32);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(250, 21);
            this.cbRoles.TabIndex = 78;
            this.cbRoles.SelectionChangeCommitted += new System.EventHandler(this.cbRoles_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 79;
            this.label9.Text = "ROLES";
            // 
            // cbProfesionales
            // 
            this.cbProfesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfesionales.FormattingEnabled = true;
            this.cbProfesionales.Location = new System.Drawing.Point(452, 32);
            this.cbProfesionales.Name = "cbProfesionales";
            this.cbProfesionales.Size = new System.Drawing.Size(259, 21);
            this.cbProfesionales.TabIndex = 76;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 77;
            this.label8.Text = "PROFESIONALES";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 76;
            this.label13.Text = "ROL";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(322, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 78;
            this.label15.Text = "DETALLE";
            // 
            // cbDetalle
            // 
            this.cbDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDetalle.FormattingEnabled = true;
            this.cbDetalle.Location = new System.Drawing.Point(393, 11);
            this.cbDetalle.Name = "cbDetalle";
            this.cbDetalle.Size = new System.Drawing.Size(239, 21);
            this.cbDetalle.TabIndex = 77;
            // 
            // abmProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 632);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbDetalle);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbIdProf);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.cbComprobante);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbCuenta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cbContratos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbCorreo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbCelular);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbEspecialidades);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMatricula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbFiltroRoles);
            this.Controls.Add(this.dgProfesionales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "abmProfesionales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM PROFESIONALES";
            this.Load += new System.EventHandler(this.abmProfesionales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProfesionales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProfesionales;
        private System.Windows.Forms.ComboBox cbFiltroRoles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbIdProf;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.ComboBox cbComprobante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbCuenta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ComboBox cbContratos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbCorreo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCelular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbEspecialidades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbProfesionales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbEspec;
        private System.Windows.Forms.Label cbEspecNuevo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cbRolesNuevo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTRATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BONO_RECIBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESPECIALIDAD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbDetalle;
    }
}