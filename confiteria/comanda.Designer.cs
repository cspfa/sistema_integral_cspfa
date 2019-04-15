namespace Confiteria
{
    partial class comanda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgSocio = new System.Windows.Forms.DataGridView();
            this.NRO_SOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BARRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECUENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AFILIADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BENEFICIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMesa = new System.Windows.Forms.TextBox();
            this.cbSectAct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbProf = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPRESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnImprimirComanda = new System.Windows.Forms.Button();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnQuitarItem = new System.Windows.Forms.Button();
            this.tbNroComanda = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCerrarComanda = new System.Windows.Forms.Button();
            this.tbPersonas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMozo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbFormaDePago = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbImporteItem = new System.Windows.Forms.TextBox();
            this.tbContralor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dpFechaComanda = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgResultados = new System.Windows.Forms.DataGridView();
            this.tbItemObservacion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbConsume = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbTipoDeComanda = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbDescuento = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbComandaBorrador = new System.Windows.Forms.TextBox();
            this.tbIdComanda = new System.Windows.Forms.TextBox();
            this.lbStockMenor10 = new System.Windows.Forms.Label();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSocio
            // 
            this.dgSocio.AllowUserToAddRows = false;
            this.dgSocio.AllowUserToDeleteRows = false;
            this.dgSocio.AllowUserToResizeColumns = false;
            this.dgSocio.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgSocio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgSocio.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgSocio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSocio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSocio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgSocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSocio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NRO_SOC,
            this.NRO_DEP,
            this.BARRA,
            this.NOMBRE,
            this.SECUENCIA,
            this.AFILIADO,
            this.BENEFICIO});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSocio.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgSocio.Location = new System.Drawing.Point(14, 14);
            this.dgSocio.Margin = new System.Windows.Forms.Padding(5);
            this.dgSocio.MultiSelect = false;
            this.dgSocio.Name = "dgSocio";
            this.dgSocio.ReadOnly = true;
            this.dgSocio.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSocio.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgSocio.RowHeadersVisible = false;
            this.dgSocio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgSocio.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgSocio.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSocio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSocio.Size = new System.Drawing.Size(701, 42);
            this.dgSocio.TabIndex = 48;
            // 
            // NRO_SOC
            // 
            this.NRO_SOC.HeaderText = "NRO_SOC";
            this.NRO_SOC.Name = "NRO_SOC";
            this.NRO_SOC.ReadOnly = true;
            this.NRO_SOC.Visible = false;
            // 
            // NRO_DEP
            // 
            this.NRO_DEP.HeaderText = "NRO_DEP";
            this.NRO_DEP.Name = "NRO_DEP";
            this.NRO_DEP.ReadOnly = true;
            this.NRO_DEP.Visible = false;
            // 
            // BARRA
            // 
            this.BARRA.HeaderText = "BARRA";
            this.BARRA.Name = "BARRA";
            this.BARRA.ReadOnly = true;
            this.BARRA.Visible = false;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE Y APELLIDO";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 300;
            // 
            // SECUENCIA
            // 
            this.SECUENCIA.HeaderText = "SECUENCIA";
            this.SECUENCIA.Name = "SECUENCIA";
            this.SECUENCIA.ReadOnly = true;
            this.SECUENCIA.Visible = false;
            // 
            // AFILIADO
            // 
            this.AFILIADO.HeaderText = "AFILIADO";
            this.AFILIADO.Name = "AFILIADO";
            this.AFILIADO.ReadOnly = true;
            // 
            // BENEFICIO
            // 
            this.BENEFICIO.HeaderText = "BENEFICIO";
            this.BENEFICIO.Name = "BENEFICIO";
            this.BENEFICIO.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "MESA Nº";
            // 
            // tbMesa
            // 
            this.tbMesa.Location = new System.Drawing.Point(82, 228);
            this.tbMesa.Name = "tbMesa";
            this.tbMesa.ReadOnly = true;
            this.tbMesa.Size = new System.Drawing.Size(51, 20);
            this.tbMesa.TabIndex = 50;
            // 
            // cbSectAct
            // 
            this.cbSectAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSectAct.FormattingEnabled = true;
            this.cbSectAct.Location = new System.Drawing.Point(190, 260);
            this.cbSectAct.Name = "cbSectAct";
            this.cbSectAct.Size = new System.Drawing.Size(195, 21);
            this.cbSectAct.TabIndex = 56;
            this.cbSectAct.SelectionChangeCommitted += new System.EventHandler(this.cbSectAct_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "TIPO";
            // 
            // cbProf
            // 
            this.cbProf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProf.FormattingEnabled = true;
            this.cbProf.Location = new System.Drawing.Point(460, 260);
            this.cbProf.Name = "cbProf";
            this.cbProf.Size = new System.Drawing.Size(254, 21);
            this.cbProf.TabIndex = 57;
            this.cbProf.SelectionChangeCommitted += new System.EventHandler(this.cbProf_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "ITEM";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(82, 260);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(51, 20);
            this.tbCantidad.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "CANTIDAD";
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.AllowUserToResizeColumns = false;
            this.dgItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgItems.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CANTIDAD,
            this.TIPO,
            this.ITEM,
            this.VALOR,
            this.SUBTOTAL,
            this.ITEM_ID,
            this.TIPO_ID,
            this.ID,
            this.DEL,
            this.IMPRESO,
            this.OBSERVACION});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgItems.Location = new System.Drawing.Point(13, 377);
            this.dgItems.Margin = new System.Windows.Forms.Padding(5);
            this.dgItems.MultiSelect = false;
            this.dgItems.Name = "dgItems";
            this.dgItems.ReadOnly = true;
            this.dgItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgItems.RowHeadersVisible = false;
            this.dgItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgItems.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItems.Size = new System.Drawing.Size(702, 199);
            this.dgItems.TabIndex = 66;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.HeaderText = "#";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            this.CANTIDAD.Width = 30;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            this.TIPO.Width = 150;
            // 
            // ITEM
            // 
            this.ITEM.HeaderText = "ITEM";
            this.ITEM.Name = "ITEM";
            this.ITEM.ReadOnly = true;
            this.ITEM.Width = 200;
            // 
            // VALOR
            // 
            this.VALOR.HeaderText = "VALOR";
            this.VALOR.Name = "VALOR";
            this.VALOR.ReadOnly = true;
            this.VALOR.Width = 60;
            // 
            // SUBTOTAL
            // 
            this.SUBTOTAL.HeaderText = "SUBT";
            this.SUBTOTAL.Name = "SUBTOTAL";
            this.SUBTOTAL.ReadOnly = true;
            this.SUBTOTAL.Width = 60;
            // 
            // ITEM_ID
            // 
            this.ITEM_ID.HeaderText = "ITEM_ID";
            this.ITEM_ID.Name = "ITEM_ID";
            this.ITEM_ID.ReadOnly = true;
            this.ITEM_ID.Visible = false;
            // 
            // TIPO_ID
            // 
            this.TIPO_ID.HeaderText = "TIPO_ID";
            this.TIPO_ID.Name = "TIPO_ID";
            this.TIPO_ID.ReadOnly = true;
            this.TIPO_ID.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // DEL
            // 
            this.DEL.HeaderText = "DEL";
            this.DEL.Name = "DEL";
            this.DEL.ReadOnly = true;
            this.DEL.Visible = false;
            // 
            // IMPRESO
            // 
            this.IMPRESO.HeaderText = "IMPRESO";
            this.IMPRESO.Name = "IMPRESO";
            this.IMPRESO.ReadOnly = true;
            this.IMPRESO.Visible = false;
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.HeaderText = "OBSERVACION";
            this.OBSERVACION.Name = "OBSERVACION";
            this.OBSERVACION.ReadOnly = true;
            this.OBSERVACION.Width = 200;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(460, 346);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(121, 23);
            this.btnAgregar.TabIndex = 64;
            this.btnAgregar.Text = "AGREGAR ITEM";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnImprimirComanda
            // 
            this.btnImprimirComanda.Location = new System.Drawing.Point(155, 622);
            this.btnImprimirComanda.Name = "btnImprimirComanda";
            this.btnImprimirComanda.Size = new System.Drawing.Size(177, 36);
            this.btnImprimirComanda.TabIndex = 60;
            this.btnImprimirComanda.Text = "CERRAR MESA E IMPRIMIR";
            this.btnImprimirComanda.UseVisualStyleBackColor = true;
            this.btnImprimirComanda.Click += new System.EventHandler(this.btnImprimirComanda_Click);
            // 
            // tbTotal
            // 
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(612, 587);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(102, 29);
            this.tbTotal.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(558, 595);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "TOTAL";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(14, 622);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(129, 36);
            this.btnGuardar.TabIndex = 65;
            this.btnGuardar.Text = "GUARDAR MESA";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnQuitarItem
            // 
            this.btnQuitarItem.Location = new System.Drawing.Point(593, 346);
            this.btnQuitarItem.Name = "btnQuitarItem";
            this.btnQuitarItem.Size = new System.Drawing.Size(121, 23);
            this.btnQuitarItem.TabIndex = 65;
            this.btnQuitarItem.Text = "QUITAR ITEM";
            this.btnQuitarItem.UseVisualStyleBackColor = true;
            this.btnQuitarItem.Click += new System.EventHandler(this.btnQuitarItem_Click);
            // 
            // tbNroComanda
            // 
            this.tbNroComanda.Location = new System.Drawing.Point(332, 228);
            this.tbNroComanda.Name = "tbNroComanda";
            this.tbNroComanda.ReadOnly = true;
            this.tbNroComanda.Size = new System.Drawing.Size(51, 20);
            this.tbNroComanda.TabIndex = 52;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 622);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 36);
            this.button1.TabIndex = 68;
            this.button1.Text = "IMPRIMIR COMANDA COCINA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCerrarComanda
            // 
            this.btnCerrarComanda.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarComanda.Location = new System.Drawing.Point(539, 622);
            this.btnCerrarComanda.Name = "btnCerrarComanda";
            this.btnCerrarComanda.Size = new System.Drawing.Size(178, 36);
            this.btnCerrarComanda.TabIndex = 69;
            this.btnCerrarComanda.Text = "CERRAR VENTANA";
            this.btnCerrarComanda.UseVisualStyleBackColor = true;
            this.btnCerrarComanda.Click += new System.EventHandler(this.btnCerrarComanda_Click);
            // 
            // tbPersonas
            // 
            this.tbPersonas.Location = new System.Drawing.Point(190, 228);
            this.tbPersonas.Name = "tbPersonas";
            this.tbPersonas.Size = new System.Drawing.Size(33, 20);
            this.tbPersonas.TabIndex = 51;
            this.tbPersonas.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "PERS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "COMANDA";
            // 
            // cbMozo
            // 
            this.cbMozo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMozo.FormattingEnabled = true;
            this.cbMozo.Location = new System.Drawing.Point(82, 291);
            this.cbMozo.Name = "cbMozo";
            this.cbMozo.Size = new System.Drawing.Size(303, 21);
            this.cbMozo.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "MOZO";
            // 
            // cbFormaDePago
            // 
            this.cbFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaDePago.FormattingEnabled = true;
            this.cbFormaDePago.Location = new System.Drawing.Point(155, 591);
            this.cbFormaDePago.Name = "cbFormaDePago";
            this.cbFormaDePago.Size = new System.Drawing.Size(177, 21);
            this.cbFormaDePago.TabIndex = 76;
            this.cbFormaDePago.SelectionChangeCommitted += new System.EventHandler(this.cbFormaDePago_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 595);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "FORMA DE PAGO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(563, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 78;
            this.label10.Text = "$";
            // 
            // tbImporteItem
            // 
            this.tbImporteItem.Location = new System.Drawing.Point(583, 228);
            this.tbImporteItem.Name = "tbImporteItem";
            this.tbImporteItem.ReadOnly = true;
            this.tbImporteItem.Size = new System.Drawing.Size(51, 20);
            this.tbImporteItem.TabIndex = 54;
            // 
            // tbContralor
            // 
            this.tbContralor.Location = new System.Drawing.Point(451, 591);
            this.tbContralor.Name = "tbContralor";
            this.tbContralor.ReadOnly = true;
            this.tbContralor.Size = new System.Drawing.Size(72, 20);
            this.tbContralor.TabIndex = 80;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(345, 595);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 79;
            this.label11.Text = "Nº CONTRALOR ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(403, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 81;
            this.label12.Text = "FECHA";
            // 
            // dpFechaComanda
            // 
            this.dpFechaComanda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaComanda.Location = new System.Drawing.Point(460, 228);
            this.dpFechaComanda.Name = "dpFechaComanda";
            this.dpFechaComanda.Size = new System.Drawing.Size(96, 20);
            this.dpFechaComanda.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 85;
            this.label13.Text = "BUSCAR";
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(82, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(632, 20);
            this.textBox1.TabIndex = 86;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // dgResultados
            // 
            this.dgResultados.AllowUserToAddRows = false;
            this.dgResultados.AllowUserToDeleteRows = false;
            this.dgResultados.AllowUserToResizeColumns = false;
            this.dgResultados.AllowUserToResizeRows = false;
            this.dgResultados.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultados.ColumnHeadersVisible = false;
            this.dgResultados.Location = new System.Drawing.Point(82, 90);
            this.dgResultados.MultiSelect = false;
            this.dgResultados.Name = "dgResultados";
            this.dgResultados.RowHeadersVisible = false;
            this.dgResultados.Size = new System.Drawing.Size(632, 97);
            this.dgResultados.TabIndex = 87;
            this.dgResultados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultados_CellClick);
            // 
            // tbItemObservacion
            // 
            this.tbItemObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbItemObservacion.Location = new System.Drawing.Point(460, 291);
            this.tbItemObservacion.MaxLength = 31;
            this.tbItemObservacion.Name = "tbItemObservacion";
            this.tbItemObservacion.Size = new System.Drawing.Size(254, 20);
            this.tbItemObservacion.TabIndex = 59;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(424, 295);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 90;
            this.label14.Text = "OBS";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(50, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 92;
            this.label15.Text = "CB";
            // 
            // tbConsume
            // 
            this.tbConsume.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbConsume.Location = new System.Drawing.Point(82, 347);
            this.tbConsume.MaxLength = 100;
            this.tbConsume.Name = "tbConsume";
            this.tbConsume.Size = new System.Drawing.Size(303, 20);
            this.tbConsume.TabIndex = 63;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 350);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 13);
            this.label16.TabIndex = 94;
            this.label16.Text = "CONSUME";
            // 
            // cbTipoDeComanda
            // 
            this.cbTipoDeComanda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeComanda.FormattingEnabled = true;
            this.cbTipoDeComanda.Location = new System.Drawing.Point(461, 318);
            this.cbTipoDeComanda.Name = "cbTipoDeComanda";
            this.cbTipoDeComanda.Size = new System.Drawing.Size(120, 21);
            this.cbTipoDeComanda.TabIndex = 61;
            this.cbTipoDeComanda.SelectionChangeCommitted += new System.EventHandler(this.cbTipoDeComanda_SelectionChangeCommitted);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(395, 322);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 96;
            this.label17.Text = "TIPO COM";
            // 
            // tbDescuento
            // 
            this.tbDescuento.Enabled = false;
            this.tbDescuento.Location = new System.Drawing.Point(593, 318);
            this.tbDescuento.Name = "tbDescuento";
            this.tbDescuento.Size = new System.Drawing.Size(33, 20);
            this.tbDescuento.TabIndex = 62;
            this.tbDescuento.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(631, 322);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 13);
            this.label18.TabIndex = 98;
            this.label18.Text = "% DESCUENTO";
            // 
            // tbComandaBorrador
            // 
            this.tbComandaBorrador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbComandaBorrador.Location = new System.Drawing.Point(82, 321);
            this.tbComandaBorrador.MaxLength = 100;
            this.tbComandaBorrador.Name = "tbComandaBorrador";
            this.tbComandaBorrador.Size = new System.Drawing.Size(303, 20);
            this.tbComandaBorrador.TabIndex = 63;
            this.tbComandaBorrador.Text = "0";
            // 
            // tbIdComanda
            // 
            this.tbIdComanda.Location = new System.Drawing.Point(332, 202);
            this.tbIdComanda.Name = "tbIdComanda";
            this.tbIdComanda.ReadOnly = true;
            this.tbIdComanda.Size = new System.Drawing.Size(51, 20);
            this.tbIdComanda.TabIndex = 99;
            this.tbIdComanda.Visible = false;
            // 
            // lbStockMenor10
            // 
            this.lbStockMenor10.AutoSize = true;
            this.lbStockMenor10.ForeColor = System.Drawing.Color.Red;
            this.lbStockMenor10.Location = new System.Drawing.Point(461, 202);
            this.lbStockMenor10.Name = "lbStockMenor10";
            this.lbStockMenor10.Size = new System.Drawing.Size(170, 13);
            this.lbStockMenor10.TabIndex = 100;
            this.lbStockMenor10.Text = "STOCK MENOR A 10 UNIDADES";
            this.lbStockMenor10.Visible = false;
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(663, 228);
            this.tbStock.Name = "tbStock";
            this.tbStock.ReadOnly = true;
            this.tbStock.Size = new System.Drawing.Size(51, 20);
            this.tbStock.TabIndex = 101;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(643, 232);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 13);
            this.label19.TabIndex = 102;
            this.label19.Text = "#";
            // 
            // comanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 669);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbStock);
            this.Controls.Add(this.lbStockMenor10);
            this.Controls.Add(this.tbIdComanda);
            this.Controls.Add(this.tbDescuento);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cbTipoDeComanda);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbComandaBorrador);
            this.Controls.Add(this.tbConsume);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbItemObservacion);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgResultados);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dpFechaComanda);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbContralor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbImporteItem);
            this.Controls.Add(this.cbFormaDePago);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbMozo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPersonas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCerrarComanda);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbNroComanda);
            this.Controls.Add(this.btnQuitarItem);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnImprimirComanda);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.tbCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbProf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSectAct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMesa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgSocio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(746, 500);
            this.Name = "comanda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPRESIÓN DE COMANDA CONFITERIA SEDE SOCIAL";
            ((System.ComponentModel.ISupportInitialize)(this.dgSocio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSocio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMesa;
        private System.Windows.Forms.ComboBox cbSectAct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnImprimirComanda;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnQuitarItem;
        private System.Windows.Forms.TextBox tbNroComanda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCerrarComanda;
        private System.Windows.Forms.TextBox tbPersonas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMozo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbFormaDePago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbImporteItem;
        private System.Windows.Forms.TextBox tbContralor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dpFechaComanda;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgResultados;
        private System.Windows.Forms.TextBox tbItemObservacion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbConsume;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbTipoDeComanda;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbDescuento;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPRESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION;
        private System.Windows.Forms.TextBox tbComandaBorrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_SOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn BARRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECUENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AFILIADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BENEFICIO;
        private System.Windows.Forms.TextBox tbIdComanda;
        private System.Windows.Forms.Label lbStockMenor10;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.Label label19;
    }
}