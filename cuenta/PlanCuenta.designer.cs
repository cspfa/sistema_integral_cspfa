namespace SOCIOS.CuentaSocio
{
    partial class PlanCuenta
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
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            this.lbPLanCuenta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Genero_Ingreso = new System.Windows.Forms.Button();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lbTipoViaje = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.butonInfoDescuento = new System.Windows.Forms.Button();
            this.gpDescuento = new System.Windows.Forms.GroupBox();
            this.GrabarNovedad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDescuento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpPlanCuota = new System.Windows.Forms.GroupBox();
            this.Seleccion = new System.Windows.Forms.LinkLabel();
            this.gpRol = new System.Windows.Forms.GroupBox();
            this.tbDni = new MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbDepuracion = new MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox();
            this.tbSocio = new MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnPago = new System.Windows.Forms.Button();
            this.gpPago = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbFormaDePago = new System.Windows.Forms.ComboBox();
            this.chkRecibo = new System.Windows.Forms.CheckBox();
            this.chkBono = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNroPago = new System.Windows.Forms.TextBox();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.lbMonto = new System.Windows.Forms.Label();
            this.lbSaldo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.gpDescuento.SuspendLayout();
            this.gpPlanCuota.SuspendLayout();
            this.gpRol.SuspendLayout();
            this.gpPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.AllowUserToAddRows = false;
            this.dgvPlanes.AllowUserToDeleteRows = false;
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanes.Location = new System.Drawing.Point(12, 123);
            this.dgvPlanes.MultiSelect = false;
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanes.Size = new System.Drawing.Size(1025, 150);
            this.dgvPlanes.TabIndex = 0;
            this.dgvPlanes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanes_CellContentClick);
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.AllowUserToAddRows = false;
            this.dgvCuotas.AllowUserToDeleteRows = false;
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Location = new System.Drawing.Point(12, 59);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuotas.Size = new System.Drawing.Size(692, 150);
            this.dgvCuotas.TabIndex = 1;
            this.dgvCuotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuotas_CellClick);
            this.dgvCuotas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuotas_CellContentClick);
            // 
            // lbPLanCuenta
            // 
            this.lbPLanCuenta.AutoSize = true;
            this.lbPLanCuenta.Location = new System.Drawing.Point(12, 25);
            this.lbPLanCuenta.Name = "lbPLanCuenta";
            this.lbPLanCuenta.Size = new System.Drawing.Size(114, 13);
            this.lbPLanCuenta.TabIndex = 2;
            this.lbPLanCuenta.Text = "PLANES DE CUENTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PAGOS";
            // 
            // Genero_Ingreso
            // 
            this.Genero_Ingreso.Location = new System.Drawing.Point(726, 14);
            this.Genero_Ingreso.Name = "Genero_Ingreso";
            this.Genero_Ingreso.Size = new System.Drawing.Size(131, 23);
            this.Genero_Ingreso.TabIndex = 4;
            this.Genero_Ingreso.Text = "Generar Ingreso";
            this.Genero_Ingreso.UseVisualStyleBackColor = true;
            this.Genero_Ingreso.Visible = false;
            this.Genero_Ingreso.Click += new System.EventHandler(this.Genero_Ingreso_Click_1);
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(51, 16);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(157, 21);
            this.cbTipo.TabIndex = 85;
            // 
            // lbTipoViaje
            // 
            this.lbTipoViaje.AutoSize = true;
            this.lbTipoViaje.Location = new System.Drawing.Point(6, 16);
            this.lbTipoViaje.Name = "lbTipoViaje";
            this.lbTipoViaje.Size = new System.Drawing.Size(28, 13);
            this.lbTipoViaje.TabIndex = 84;
            this.lbTipoViaje.Text = "Tipo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 86;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butonInfoDescuento
            // 
            this.butonInfoDescuento.Location = new System.Drawing.Point(726, 42);
            this.butonInfoDescuento.Name = "butonInfoDescuento";
            this.butonInfoDescuento.Size = new System.Drawing.Size(238, 23);
            this.butonInfoDescuento.TabIndex = 87;
            this.butonInfoDescuento.Text = "Actualizar Info Descuento";
            this.butonInfoDescuento.UseVisualStyleBackColor = true;
            this.butonInfoDescuento.Visible = false;
            this.butonInfoDescuento.Click += new System.EventHandler(this.butonInfoDescuento_Click);
            // 
            // gpDescuento
            // 
            this.gpDescuento.Controls.Add(this.GrabarNovedad);
            this.gpDescuento.Controls.Add(this.label2);
            this.gpDescuento.Controls.Add(this.cbDescuento);
            this.gpDescuento.Location = new System.Drawing.Point(726, 98);
            this.gpDescuento.Name = "gpDescuento";
            this.gpDescuento.Size = new System.Drawing.Size(311, 92);
            this.gpDescuento.TabIndex = 88;
            this.gpDescuento.TabStop = false;
            this.gpDescuento.Text = "Novedad Descuento";
            this.gpDescuento.Visible = false;
            // 
            // GrabarNovedad
            // 
            this.GrabarNovedad.Location = new System.Drawing.Point(174, 51);
            this.GrabarNovedad.Name = "GrabarNovedad";
            this.GrabarNovedad.Size = new System.Drawing.Size(131, 23);
            this.GrabarNovedad.TabIndex = 89;
            this.GrabarNovedad.Text = "Grabar Novedad";
            this.GrabarNovedad.UseVisualStyleBackColor = true;
            this.GrabarNovedad.Click += new System.EventHandler(this.GrabarNovedad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "OBSERVACION";
            // 
            // cbDescuento
            // 
            this.cbDescuento.FormattingEnabled = true;
            this.cbDescuento.Location = new System.Drawing.Point(137, 24);
            this.cbDescuento.Name = "cbDescuento";
            this.cbDescuento.Size = new System.Drawing.Size(168, 21);
            this.cbDescuento.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "CUOTA YA PAGA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(12, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "CUOTA YA INGRESADA INFO DESCUENTO";
            // 
            // gpPlanCuota
            // 
            this.gpPlanCuota.Controls.Add(this.label14);
            this.gpPlanCuota.Controls.Add(this.label13);
            this.gpPlanCuota.Controls.Add(this.lbSaldo);
            this.gpPlanCuota.Controls.Add(this.lbMonto);
            this.gpPlanCuota.Controls.Add(this.gpPago);
            this.gpPlanCuota.Controls.Add(this.btnPago);
            this.gpPlanCuota.Controls.Add(this.dgvCuotas);
            this.gpPlanCuota.Controls.Add(this.gpDescuento);
            this.gpPlanCuota.Controls.Add(this.label4);
            this.gpPlanCuota.Controls.Add(this.label1);
            this.gpPlanCuota.Controls.Add(this.Genero_Ingreso);
            this.gpPlanCuota.Controls.Add(this.label3);
            this.gpPlanCuota.Controls.Add(this.butonInfoDescuento);
            this.gpPlanCuota.Location = new System.Drawing.Point(10, 303);
            this.gpPlanCuota.Name = "gpPlanCuota";
            this.gpPlanCuota.Size = new System.Drawing.Size(1043, 345);
            this.gpPlanCuota.TabIndex = 91;
            this.gpPlanCuota.TabStop = false;
            this.gpPlanCuota.Text = "Plan de Cuotas";
            this.gpPlanCuota.Visible = false;
            // 
            // Seleccion
            // 
            this.Seleccion.AutoSize = true;
            this.Seleccion.Location = new System.Drawing.Point(449, 283);
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Size = new System.Drawing.Size(54, 13);
            this.Seleccion.TabIndex = 92;
            this.Seleccion.TabStop = true;
            this.Seleccion.Text = "Seleccion";
            this.Seleccion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Seleccion_LinkClicked);
            // 
            // gpRol
            // 
            this.gpRol.Controls.Add(this.lbTipoViaje);
            this.gpRol.Controls.Add(this.cbTipo);
            this.gpRol.Controls.Add(this.button1);
            this.gpRol.Location = new System.Drawing.Point(640, 12);
            this.gpRol.Name = "gpRol";
            this.gpRol.Size = new System.Drawing.Size(397, 50);
            this.gpRol.TabIndex = 93;
            this.gpRol.TabStop = false;
            this.gpRol.Text = "Filtro Por Rol";
            this.gpRol.Visible = false;
            // 
            // tbDni
            // 
            this.tbDni.BusinessObjectEvaluated = true;
            this.tbDni.DisabledBackColor = System.Drawing.Color.White;
            this.tbDni.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tbDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDni.Location = new System.Drawing.Point(397, 53);
            this.tbDni.Mask = "99999999";
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(92, 20);
            this.tbDni.TabIndex = 98;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(313, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 103;
            this.label11.Text = "DOCUMENTO:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(313, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 102;
            this.label10.Text = "NOMBRE:";
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(399, 78);
            this.tbNombre.MaxLength = 20;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(294, 20);
            this.tbNombre.TabIndex = 97;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "APELLIDO:";
            // 
            // tbApellido
            // 
            this.tbApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApellido.Location = new System.Drawing.Point(78, 79);
            this.tbApellido.MaxLength = 20;
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(221, 20);
            this.tbApellido.TabIndex = 96;
            // 
            // tbDepuracion
            // 
            this.tbDepuracion.BusinessObjectEvaluated = true;
            this.tbDepuracion.DisabledBackColor = System.Drawing.Color.White;
            this.tbDepuracion.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tbDepuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDepuracion.Location = new System.Drawing.Point(272, 53);
            this.tbDepuracion.Mask = "999";
            this.tbDepuracion.Name = "tbDepuracion";
            this.tbDepuracion.Size = new System.Drawing.Size(27, 20);
            this.tbDepuracion.TabIndex = 95;
            this.tbDepuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSocio
            // 
            this.tbSocio.BusinessObjectEvaluated = true;
            this.tbSocio.DisabledBackColor = System.Drawing.Color.White;
            this.tbSocio.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tbSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSocio.Location = new System.Drawing.Point(77, 53);
            this.tbSocio.Mask = "99999";
            this.tbSocio.Name = "tbSocio";
            this.tbSocio.Size = new System.Drawing.Size(44, 20);
            this.tbSocio.TabIndex = 94;
            this.tbSocio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSocio.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(177, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "DEPURACIÓN:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "N° SOCIO:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(736, 78);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 23);
            this.btnBuscar.TabIndex = 87;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnPago
            // 
            this.btnPago.Location = new System.Drawing.Point(726, 69);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(238, 23);
            this.btnPago.TabIndex = 91;
            this.btnPago.Text = "Actualizar Pago";
            this.btnPago.UseVisualStyleBackColor = true;
            this.btnPago.Visible = false;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // gpPago
            // 
            this.gpPago.Controls.Add(this.label12);
            this.gpPago.Controls.Add(this.dpFecha);
            this.gpPago.Controls.Add(this.tbNroPago);
            this.gpPago.Controls.Add(this.label9);
            this.gpPago.Controls.Add(this.label8);
            this.gpPago.Controls.Add(this.chkBono);
            this.gpPago.Controls.Add(this.chkRecibo);
            this.gpPago.Controls.Add(this.button2);
            this.gpPago.Controls.Add(this.cbFormaDePago);
            this.gpPago.Location = new System.Drawing.Point(710, 196);
            this.gpPago.Name = "gpPago";
            this.gpPago.Size = new System.Drawing.Size(327, 141);
            this.gpPago.TabIndex = 90;
            this.gpPago.TabStop = false;
            this.gpPago.Text = "Pago Cuota";
            this.gpPago.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 89;
            this.button2.Text = "Grabar Novedad";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbFormaDePago
            // 
            this.cbFormaDePago.FormattingEnabled = true;
            this.cbFormaDePago.Location = new System.Drawing.Point(101, 76);
            this.cbFormaDePago.Name = "cbFormaDePago";
            this.cbFormaDePago.Size = new System.Drawing.Size(168, 21);
            this.cbFormaDePago.TabIndex = 0;
            // 
            // chkRecibo
            // 
            this.chkRecibo.AutoSize = true;
            this.chkRecibo.Location = new System.Drawing.Point(9, 19);
            this.chkRecibo.Name = "chkRecibo";
            this.chkRecibo.Size = new System.Drawing.Size(66, 17);
            this.chkRecibo.TabIndex = 90;
            this.chkRecibo.Text = "RECIBO";
            this.chkRecibo.UseVisualStyleBackColor = true;
            this.chkRecibo.CheckedChanged += new System.EventHandler(this.chkRecibo_CheckedChanged);
            // 
            // chkBono
            // 
            this.chkBono.AutoSize = true;
            this.chkBono.Location = new System.Drawing.Point(77, 19);
            this.chkBono.Name = "chkBono";
            this.chkBono.Size = new System.Drawing.Size(57, 17);
            this.chkBono.TabIndex = 91;
            this.chkBono.Text = "BONO";
            this.chkBono.UseVisualStyleBackColor = true;
            this.chkBono.CheckedChanged += new System.EventHandler(this.chkBono_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(140, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "NUMERO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "FORMA PAGO";
            // 
            // tbNroPago
            // 
            this.tbNroPago.Location = new System.Drawing.Point(201, 14);
            this.tbNroPago.Name = "tbNroPago";
            this.tbNroPago.Size = new System.Drawing.Size(100, 20);
            this.tbNroPago.TabIndex = 93;
            // 
            // dpFecha
            // 
            this.dpFecha.Location = new System.Drawing.Point(101, 50);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(200, 20);
            this.dpFecha.TabIndex = 94;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 95;
            this.label12.Text = "FECHA";
            // 
            // lbMonto
            // 
            this.lbMonto.AutoSize = true;
            this.lbMonto.ForeColor = System.Drawing.Color.Gold;
            this.lbMonto.Location = new System.Drawing.Point(173, 24);
            this.lbMonto.Name = "lbMonto";
            this.lbMonto.Size = new System.Drawing.Size(13, 13);
            this.lbMonto.TabIndex = 92;
            this.lbMonto.Text = "0";
            // 
            // lbSaldo
            // 
            this.lbSaldo.AutoSize = true;
            this.lbSaldo.ForeColor = System.Drawing.Color.Red;
            this.lbSaldo.Location = new System.Drawing.Point(328, 24);
            this.lbSaldo.Name = "lbSaldo";
            this.lbSaldo.Size = new System.Drawing.Size(13, 13);
            this.lbSaldo.TabIndex = 93;
            this.lbSaldo.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(86, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 94;
            this.label13.Text = "MONTO PLAN:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(246, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 95;
            this.label14.Text = "SALDO";
            // 
            // PlanCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 652);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tbDni);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.tbDepuracion);
            this.Controls.Add(this.tbSocio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gpRol);
            this.Controls.Add(this.Seleccion);
            this.Controls.Add(this.lbPLanCuenta);
            this.Controls.Add(this.dgvPlanes);
            this.Controls.Add(this.gpPlanCuota);
            this.Name = "PlanCuenta";
            this.Text = "PlanCuenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.gpDescuento.ResumeLayout(false);
            this.gpDescuento.PerformLayout();
            this.gpPlanCuota.ResumeLayout(false);
            this.gpPlanCuota.PerformLayout();
            this.gpRol.ResumeLayout(false);
            this.gpRol.PerformLayout();
            this.gpPago.ResumeLayout(false);
            this.gpPago.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.DataGridView dgvCuotas;
        private System.Windows.Forms.Label lbPLanCuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Genero_Ingreso;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lbTipoViaje;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butonInfoDescuento;
        private System.Windows.Forms.GroupBox gpDescuento;
        private System.Windows.Forms.Button GrabarNovedad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDescuento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gpPlanCuota;
        private System.Windows.Forms.LinkLabel Seleccion;
        private System.Windows.Forms.GroupBox gpRol;
        private MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox tbDni;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbApellido;
        private MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox tbDepuracion;
        private MicroFour.StrataFrame.UI.Windows.Forms.MaskedTextbox tbSocio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gpPago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkBono;
        private System.Windows.Forms.CheckBox chkRecibo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbFormaDePago;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.TextBox tbNroPago;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbSaldo;
        private System.Windows.Forms.Label lbMonto;
    }
}