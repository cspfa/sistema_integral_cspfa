namespace Convenios
{
    partial class Convenios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tbAnioBuscador = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNroIntBuscador = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRegGralBuscador = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDetalleBuscador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarEmpresa = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.dgResultadosBuscador = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVerPdf = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.lbArchivo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dpFin = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dpInicio = new System.Windows.Forms.DateTimePicker();
            this.tbObsevaciones = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbEmpresas = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbTipoConvenio = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbAnio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbNroInt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbRegGral = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbDetalle = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbEmpresaBuscador = new System.Windows.Forms.ComboBox();
            this.CONVENIO_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_REG_GRAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_INTERNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESDE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HASTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_EMPRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAZON_SOCIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultadosBuscador)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEmpresaBuscador);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.tbAnioBuscador);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbNroIntBuscador);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbRegGralBuscador);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbDetalleBuscador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSCADOR";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(346, 72);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(145, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tbAnioBuscador
            // 
            this.tbAnioBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAnioBuscador.Location = new System.Drawing.Point(257, 47);
            this.tbAnioBuscador.Name = "tbAnioBuscador";
            this.tbAnioBuscador.Size = new System.Drawing.Size(79, 20);
            this.tbAnioBuscador.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "AÑO";
            // 
            // tbNroIntBuscador
            // 
            this.tbNroIntBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNroIntBuscador.Location = new System.Drawing.Point(77, 47);
            this.tbNroIntBuscador.Name = "tbNroIntBuscador";
            this.tbNroIntBuscador.Size = new System.Drawing.Size(79, 20);
            this.tbNroIntBuscador.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "NRO INT";
            // 
            // tbRegGralBuscador
            // 
            this.tbRegGralBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRegGralBuscador.Location = new System.Drawing.Point(411, 20);
            this.tbRegGralBuscador.Name = "tbRegGralBuscador";
            this.tbRegGralBuscador.Size = new System.Drawing.Size(79, 20);
            this.tbRegGralBuscador.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "REG GRAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "EMPRESA";
            // 
            // tbDetalleBuscador
            // 
            this.tbDetalleBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDetalleBuscador.Location = new System.Drawing.Point(77, 20);
            this.tbDetalleBuscador.Name = "tbDetalleBuscador";
            this.tbDetalleBuscador.Size = new System.Drawing.Size(260, 20);
            this.tbDetalleBuscador.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DETALLE";
            // 
            // btnAgregarEmpresa
            // 
            this.btnAgregarEmpresa.AutoSize = true;
            this.btnAgregarEmpresa.Location = new System.Drawing.Point(680, 24);
            this.btnAgregarEmpresa.Name = "btnAgregarEmpresa";
            this.btnAgregarEmpresa.Size = new System.Drawing.Size(92, 13);
            this.btnAgregarEmpresa.TabIndex = 13;
            this.btnAgregarEmpresa.TabStop = true;
            this.btnAgregarEmpresa.Text = "ABM EMPRESAS";
            this.btnAgregarEmpresa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAgregarEmpresa_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "RESULTADOS DE LA BÚSQUEDA";
            // 
            // dgResultadosBuscador
            // 
            this.dgResultadosBuscador.AllowUserToAddRows = false;
            this.dgResultadosBuscador.AllowUserToDeleteRows = false;
            this.dgResultadosBuscador.AllowUserToResizeColumns = false;
            this.dgResultadosBuscador.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgResultadosBuscador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgResultadosBuscador.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgResultadosBuscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgResultadosBuscador.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgResultadosBuscador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultadosBuscador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CONVENIO_ID,
            this.NRO_REG_GRAL,
            this.NRO_INTERNO,
            this.DESDE,
            this.HASTA,
            this.ID_EMPRESA,
            this.RAZON_SOCIAL,
            this.DETALLE,
            this.ID_TIPO,
            this.TIPO,
            this.OBSERVACIONES});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgResultadosBuscador.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgResultadosBuscador.Location = new System.Drawing.Point(12, 168);
            this.dgResultadosBuscador.Margin = new System.Windows.Forms.Padding(5);
            this.dgResultadosBuscador.Name = "dgResultadosBuscador";
            this.dgResultadosBuscador.ReadOnly = true;
            this.dgResultadosBuscador.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgResultadosBuscador.RowHeadersVisible = false;
            this.dgResultadosBuscador.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgResultadosBuscador.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResultadosBuscador.Size = new System.Drawing.Size(1286, 333);
            this.dgResultadosBuscador.TabIndex = 47;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(674, 71);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(103, 23);
            this.btnEliminar.TabIndex = 48;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVerPdf
            // 
            this.btnVerPdf.Location = new System.Drawing.Point(674, 97);
            this.btnVerPdf.Name = "btnVerPdf";
            this.btnVerPdf.Size = new System.Drawing.Size(103, 23);
            this.btnVerPdf.TabIndex = 49;
            this.btnVerPdf.Text = "VER PDF";
            this.btnVerPdf.UseVisualStyleBackColor = true;
            this.btnVerPdf.Click += new System.EventHandler(this.btnVerPdf_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(674, 45);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(103, 23);
            this.btnNuevo.TabIndex = 50;
            this.btnNuevo.Text = "ACEPTAR";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(77, 98);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(79, 20);
            this.btnExaminar.TabIndex = 15;
            this.btnExaminar.Text = "EXAMINAR";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // lbArchivo
            // 
            this.lbArchivo.AutoSize = true;
            this.lbArchivo.Location = new System.Drawing.Point(171, 102);
            this.lbArchivo.Name = "lbArchivo";
            this.lbArchivo.Size = new System.Drawing.Size(162, 13);
            this.lbArchivo.TabIndex = 16;
            this.lbArchivo.Text = "No se seleccionó ningún archivo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dpFin);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.btnAgregarEmpresa);
            this.groupBox2.Controls.Add(this.dpInicio);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.tbObsevaciones);
            this.groupBox2.Controls.Add(this.btnVerPdf);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbEmpresas);
            this.groupBox2.Controls.Add(this.lbArchivo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnExaminar);
            this.groupBox2.Controls.Add(this.cbTipoConvenio);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbAnio);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbNroInt);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbRegGral);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbDetalle);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(515, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 131);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATOS DEL CONVENIO";
            // 
            // dpFin
            // 
            this.dpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFin.Location = new System.Drawing.Point(571, 73);
            this.dpFin.Name = "dpFin";
            this.dpFin.Size = new System.Drawing.Size(95, 20);
            this.dpFin.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(541, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "FIN";
            // 
            // dpInicio
            // 
            this.dpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpInicio.Location = new System.Drawing.Point(406, 73);
            this.dpInicio.Name = "dpInicio";
            this.dpInicio.Size = new System.Drawing.Size(95, 20);
            this.dpInicio.TabIndex = 18;
            // 
            // tbObsevaciones
            // 
            this.tbObsevaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObsevaciones.Location = new System.Drawing.Point(77, 73);
            this.tbObsevaciones.Name = "tbObsevaciones";
            this.tbObsevaciones.Size = new System.Drawing.Size(260, 20);
            this.tbObsevaciones.TabIndex = 53;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(362, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "INICIO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "OBSERV";
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Location = new System.Drawing.Point(406, 20);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(259, 21);
            this.cbEmpresas.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "PDF";
            // 
            // cbTipoConvenio
            // 
            this.cbTipoConvenio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoConvenio.FormattingEnabled = true;
            this.cbTipoConvenio.Location = new System.Drawing.Point(529, 46);
            this.cbTipoConvenio.Name = "cbTipoConvenio";
            this.cbTipoConvenio.Size = new System.Drawing.Size(137, 21);
            this.cbTipoConvenio.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(491, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "TIPO";
            // 
            // tbAnio
            // 
            this.tbAnio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAnio.Location = new System.Drawing.Point(406, 46);
            this.tbAnio.Name = "tbAnio";
            this.tbAnio.Size = new System.Drawing.Size(79, 20);
            this.tbAnio.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(371, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "AÑO";
            // 
            // tbNroInt
            // 
            this.tbNroInt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNroInt.Location = new System.Drawing.Point(258, 46);
            this.tbNroInt.Name = "tbNroInt";
            this.tbNroInt.Size = new System.Drawing.Size(79, 20);
            this.tbNroInt.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(170, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "NRO INTERNO";
            // 
            // tbRegGral
            // 
            this.tbRegGral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRegGral.Location = new System.Drawing.Point(77, 46);
            this.tbRegGral.Name = "tbRegGral";
            this.tbRegGral.Size = new System.Drawing.Size(79, 20);
            this.tbRegGral.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "REG GRAL";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(342, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "EMPRESA";
            // 
            // tbDetalle
            // 
            this.tbDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDetalle.Location = new System.Drawing.Point(77, 20);
            this.tbDetalle.Name = "tbDetalle";
            this.tbDetalle.Size = new System.Drawing.Size(260, 20);
            this.tbDetalle.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "DETALLE";
            // 
            // cbEmpresaBuscador
            // 
            this.cbEmpresaBuscador.FormattingEnabled = true;
            this.cbEmpresaBuscador.Location = new System.Drawing.Point(77, 73);
            this.cbEmpresaBuscador.Name = "cbEmpresaBuscador";
            this.cbEmpresaBuscador.Size = new System.Drawing.Size(259, 21);
            this.cbEmpresaBuscador.TabIndex = 54;
            // 
            // CONVENIO_ID
            // 
            this.CONVENIO_ID.HeaderText = "CONVENIO_ID";
            this.CONVENIO_ID.Name = "CONVENIO_ID";
            this.CONVENIO_ID.ReadOnly = true;
            // 
            // NRO_REG_GRAL
            // 
            this.NRO_REG_GRAL.HeaderText = "NRO_REG_GRAL";
            this.NRO_REG_GRAL.Name = "NRO_REG_GRAL";
            this.NRO_REG_GRAL.ReadOnly = true;
            // 
            // NRO_INTERNO
            // 
            this.NRO_INTERNO.HeaderText = "NRO_INTERNO";
            this.NRO_INTERNO.Name = "NRO_INTERNO";
            this.NRO_INTERNO.ReadOnly = true;
            // 
            // DESDE
            // 
            this.DESDE.HeaderText = "DESDE";
            this.DESDE.Name = "DESDE";
            this.DESDE.ReadOnly = true;
            // 
            // HASTA
            // 
            this.HASTA.HeaderText = "HASTA";
            this.HASTA.Name = "HASTA";
            this.HASTA.ReadOnly = true;
            // 
            // ID_EMPRESA
            // 
            this.ID_EMPRESA.HeaderText = "ID_EMPRESA";
            this.ID_EMPRESA.Name = "ID_EMPRESA";
            this.ID_EMPRESA.ReadOnly = true;
            // 
            // RAZON_SOCIAL
            // 
            this.RAZON_SOCIAL.HeaderText = "RAZON_SOCIAL";
            this.RAZON_SOCIAL.Name = "RAZON_SOCIAL";
            this.RAZON_SOCIAL.ReadOnly = true;
            // 
            // DETALLE
            // 
            this.DETALLE.HeaderText = "DETALLE";
            this.DETALLE.Name = "DETALLE";
            this.DETALLE.ReadOnly = true;
            // 
            // ID_TIPO
            // 
            this.ID_TIPO.HeaderText = "ID_TIPO";
            this.ID_TIPO.Name = "ID_TIPO";
            this.ID_TIPO.ReadOnly = true;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            // 
            // OBSERVACIONES
            // 
            this.OBSERVACIONES.HeaderText = "OBSERVACIONES";
            this.OBSERVACIONES.Name = "OBSERVACIONES";
            this.OBSERVACIONES.ReadOnly = true;
            // 
            // Convenios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 515);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgResultadosBuscador);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Convenios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convenios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultadosBuscador)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDetalleBuscador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRegGralBuscador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNroIntBuscador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAnioBuscador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgResultadosBuscador;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVerPdf;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.LinkLabel btnAgregarEmpresa;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Label lbArchivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbTipoConvenio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbAnio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbNroInt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbRegGral;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbDetalle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbEmpresas;
        private System.Windows.Forms.TextBox tbObsevaciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dpFin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dpInicio;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbEmpresaBuscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONVENIO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_REG_GRAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_INTERNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESDE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HASTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_EMPRESA;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAZON_SOCIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACIONES;
    }
}

