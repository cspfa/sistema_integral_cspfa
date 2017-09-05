namespace SOCIOS.confiteria
{
    partial class listadoComandas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listadoComandas));
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgComandas = new System.Windows.Forms.DataGridView();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANULADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOM_SOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_SOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BARRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AFILIADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BENEFICIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCUENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTRALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORMA_DE_PAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BORRADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONSUME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERSONAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPRESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFormaDePago = new System.Windows.Forms.ComboBox();
            this.cmComandas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirComandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirSolicitudDeDescuentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularComandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desanularComandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarFormaDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarTipoDeComandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmSolicitudes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbComprobante = new System.Windows.Forms.Label();
            this.cbSoloAnuladas = new System.Windows.Forms.CheckBox();
            this.lbImporteTotalListado = new System.Windows.Forms.Label();
            this.lbComensalesListados = new System.Windows.Forms.Label();
            this.lbPromedioComandaListado = new System.Windows.Forms.Label();
            this.lbTotalComandasListadas = new System.Windows.Forms.Label();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.cbTipoDeComanda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHoraDesde = new System.Windows.Forms.MaskedTextBox();
            this.tbHoraHasta = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgComandas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.cmComandas.SuspendLayout();
            this.cmSolicitudes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpDesde
            // 
            this.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDesde.Location = new System.Drawing.Point(620, 9);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(86, 20);
            this.dpDesde.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(572, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DESDE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(768, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "HASTA";
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(815, 9);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(86, 20);
            this.dpHasta.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1236, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(70, 28);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgComandas
            // 
            this.dgComandas.AllowUserToAddRows = false;
            this.dgComandas.AllowUserToDeleteRows = false;
            this.dgComandas.AllowUserToResizeColumns = false;
            this.dgComandas.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgComandas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgComandas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgComandas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgComandas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgComandas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgComandas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgComandas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CANTIDAD,
            this.ANULADA,
            this.FECHA,
            this.IMPORTE,
            this.NOM_SOC,
            this.NRO_SOC,
            this.NRO_DEP,
            this.BARRA,
            this.AFILIADO,
            this.BENEFICIO,
            this.DESCUENTO,
            this.CONTRALOR,
            this.FORMA_DE_PAGO,
            this.BORRADOR,
            this.CONSUME,
            this.PERSONAS});
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgComandas.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgComandas.Location = new System.Drawing.Point(13, 41);
            this.dgComandas.Margin = new System.Windows.Forms.Padding(5);
            this.dgComandas.Name = "dgComandas";
            this.dgComandas.ReadOnly = true;
            this.dgComandas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgComandas.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgComandas.RowHeadersVisible = false;
            this.dgComandas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgComandas.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgComandas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgComandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgComandas.Size = new System.Drawing.Size(1307, 291);
            this.dgComandas.TabIndex = 59;
            this.dgComandas.Click += new System.EventHandler(this.dgComandas_Click);
            this.dgComandas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgComandas_MouseDown);
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.HeaderText = "#";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            this.CANTIDAD.Width = 60;
            // 
            // ANULADA
            // 
            this.ANULADA.HeaderText = "ANULADA";
            this.ANULADA.Name = "ANULADA";
            this.ANULADA.ReadOnly = true;
            this.ANULADA.Width = 70;
            // 
            // FECHA
            // 
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            this.FECHA.Width = 140;
            // 
            // IMPORTE
            // 
            this.IMPORTE.HeaderText = "IMPORTE";
            this.IMPORTE.Name = "IMPORTE";
            this.IMPORTE.ReadOnly = true;
            this.IMPORTE.Width = 75;
            // 
            // NOM_SOC
            // 
            this.NOM_SOC.HeaderText = "NOMBRE Y APELLIDO";
            this.NOM_SOC.Name = "NOM_SOC";
            this.NOM_SOC.ReadOnly = true;
            this.NOM_SOC.Width = 220;
            // 
            // NRO_SOC
            // 
            this.NRO_SOC.HeaderText = "SOC";
            this.NRO_SOC.Name = "NRO_SOC";
            this.NRO_SOC.ReadOnly = true;
            this.NRO_SOC.Width = 55;
            // 
            // NRO_DEP
            // 
            this.NRO_DEP.HeaderText = "DEP";
            this.NRO_DEP.Name = "NRO_DEP";
            this.NRO_DEP.ReadOnly = true;
            this.NRO_DEP.Width = 55;
            // 
            // BARRA
            // 
            this.BARRA.HeaderText = "/";
            this.BARRA.Name = "BARRA";
            this.BARRA.ReadOnly = true;
            this.BARRA.Width = 30;
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
            // DESCUENTO
            // 
            this.DESCUENTO.HeaderText = "DESC";
            this.DESCUENTO.Name = "DESCUENTO";
            this.DESCUENTO.ReadOnly = true;
            this.DESCUENTO.Width = 60;
            // 
            // CONTRALOR
            // 
            this.CONTRALOR.HeaderText = "CONTRA";
            this.CONTRALOR.Name = "CONTRALOR";
            this.CONTRALOR.ReadOnly = true;
            this.CONTRALOR.Width = 60;
            // 
            // FORMA_DE_PAGO
            // 
            this.FORMA_DE_PAGO.HeaderText = "F PAGO";
            this.FORMA_DE_PAGO.Name = "FORMA_DE_PAGO";
            this.FORMA_DE_PAGO.ReadOnly = true;
            // 
            // BORRADOR
            // 
            this.BORRADOR.HeaderText = "CB";
            this.BORRADOR.Name = "BORRADOR";
            this.BORRADOR.ReadOnly = true;
            this.BORRADOR.Width = 75;
            // 
            // CONSUME
            // 
            this.CONSUME.HeaderText = "CONSUME";
            this.CONSUME.Name = "CONSUME";
            this.CONSUME.ReadOnly = true;
            // 
            // PERSONAS
            // 
            this.PERSONAS.HeaderText = "PERSONAS";
            this.PERSONAS.Name = "PERSONAS";
            this.PERSONAS.ReadOnly = true;
            this.PERSONAS.Visible = false;
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.AllowUserToResizeColumns = false;
            this.dgItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.dgItems.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.COM,
            this.ITEM,
            this.CANT,
            this.TIPO,
            this.VALOR,
            this.SUBTOTAL,
            this.TIPO_DETALLE,
            this.ITEM_DETALLE,
            this.IMPRESO});
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle31;
            this.dgItems.Location = new System.Drawing.Point(13, 423);
            this.dgItems.Margin = new System.Windows.Forms.Padding(5);
            this.dgItems.Name = "dgItems";
            this.dgItems.ReadOnly = true;
            this.dgItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.dgItems.RowHeadersVisible = false;
            this.dgItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgItems.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItems.Size = new System.Drawing.Size(1307, 233);
            this.dgItems.TabIndex = 62;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // COM
            // 
            this.COM.HeaderText = "COM";
            this.COM.Name = "COM";
            this.COM.ReadOnly = true;
            this.COM.Width = 50;
            // 
            // ITEM
            // 
            this.ITEM.HeaderText = "ITEM";
            this.ITEM.Name = "ITEM";
            this.ITEM.ReadOnly = true;
            this.ITEM.Visible = false;
            // 
            // CANT
            // 
            this.CANT.HeaderText = "CANT";
            this.CANT.Name = "CANT";
            this.CANT.ReadOnly = true;
            this.CANT.Width = 50;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            this.TIPO.Visible = false;
            // 
            // VALOR
            // 
            this.VALOR.HeaderText = "VALOR";
            this.VALOR.Name = "VALOR";
            this.VALOR.ReadOnly = true;
            // 
            // SUBTOTAL
            // 
            this.SUBTOTAL.HeaderText = "SUBTOTAL";
            this.SUBTOTAL.Name = "SUBTOTAL";
            this.SUBTOTAL.ReadOnly = true;
            // 
            // TIPO_DETALLE
            // 
            this.TIPO_DETALLE.HeaderText = "TIPO_DETALLE";
            this.TIPO_DETALLE.Name = "TIPO_DETALLE";
            this.TIPO_DETALLE.ReadOnly = true;
            this.TIPO_DETALLE.Width = 310;
            // 
            // ITEM_DETALLE
            // 
            this.ITEM_DETALLE.HeaderText = "ITEM_DETALLE";
            this.ITEM_DETALLE.Name = "ITEM_DETALLE";
            this.ITEM_DETALLE.ReadOnly = true;
            this.ITEM_DETALLE.Width = 310;
            // 
            // IMPRESO
            // 
            this.IMPRESO.HeaderText = "IMPRESO";
            this.IMPRESO.Name = "IMPRESO";
            this.IMPRESO.ReadOnly = true;
            this.IMPRESO.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "DETALLE DE LA COMANDA SELECCIONADA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(984, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "FORMA DE PAGO";
            // 
            // cbFormaDePago
            // 
            this.cbFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaDePago.FormattingEnabled = true;
            this.cbFormaDePago.Location = new System.Drawing.Point(1084, 9);
            this.cbFormaDePago.Name = "cbFormaDePago";
            this.cbFormaDePago.Size = new System.Drawing.Size(135, 21);
            this.cbFormaDePago.TabIndex = 65;
            // 
            // cmComandas
            // 
            this.cmComandas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirComandaToolStripMenuItem,
            this.imprimirSolicitudDeDescuentoToolStripMenuItem,
            this.anularComandaToolStripMenuItem,
            this.modificarItemsToolStripMenuItem,
            this.desanularComandaToolStripMenuItem,
            this.cambiarFormaDePagoToolStripMenuItem,
            this.cambiarTipoDeComandaToolStripMenuItem});
            this.cmComandas.Name = "cmComandas";
            this.cmComandas.Size = new System.Drawing.Size(224, 158);
            // 
            // imprimirComandaToolStripMenuItem
            // 
            this.imprimirComandaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirComandaToolStripMenuItem.Image")));
            this.imprimirComandaToolStripMenuItem.Name = "imprimirComandaToolStripMenuItem";
            this.imprimirComandaToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.imprimirComandaToolStripMenuItem.Text = "Imprimir Comanda";
            this.imprimirComandaToolStripMenuItem.Click += new System.EventHandler(this.imprimirComandaToolStripMenuItem_Click);
            // 
            // imprimirSolicitudDeDescuentoToolStripMenuItem
            // 
            this.imprimirSolicitudDeDescuentoToolStripMenuItem.Image = global::SOCIOS.Properties.Resources.printer;
            this.imprimirSolicitudDeDescuentoToolStripMenuItem.Name = "imprimirSolicitudDeDescuentoToolStripMenuItem";
            this.imprimirSolicitudDeDescuentoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.imprimirSolicitudDeDescuentoToolStripMenuItem.Text = "Imprimir Solicitud de Descuento";
            this.imprimirSolicitudDeDescuentoToolStripMenuItem.Visible = false;
            this.imprimirSolicitudDeDescuentoToolStripMenuItem.Click += new System.EventHandler(this.imprimirSolicitudDeDescuentoToolStripMenuItem_Click);
            // 
            // anularComandaToolStripMenuItem
            // 
            this.anularComandaToolStripMenuItem.Image = global::SOCIOS.Properties.Resources.delete1;
            this.anularComandaToolStripMenuItem.Name = "anularComandaToolStripMenuItem";
            this.anularComandaToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.anularComandaToolStripMenuItem.Text = "Anular Comanda";
            this.anularComandaToolStripMenuItem.Click += new System.EventHandler(this.anularComandaToolStripMenuItem_Click);
            // 
            // modificarItemsToolStripMenuItem
            // 
            this.modificarItemsToolStripMenuItem.Image = global::SOCIOS.Properties.Resources.application_edit;
            this.modificarItemsToolStripMenuItem.Name = "modificarItemsToolStripMenuItem";
            this.modificarItemsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.modificarItemsToolStripMenuItem.Text = "Agregar o quitar items";
            this.modificarItemsToolStripMenuItem.Visible = false;
            this.modificarItemsToolStripMenuItem.Click += new System.EventHandler(this.modificarItemsToolStripMenuItem_Click);
            // 
            // desanularComandaToolStripMenuItem
            // 
            this.desanularComandaToolStripMenuItem.Image = global::SOCIOS.Properties.Resources.accept;
            this.desanularComandaToolStripMenuItem.Name = "desanularComandaToolStripMenuItem";
            this.desanularComandaToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.desanularComandaToolStripMenuItem.Text = "Desanular Comanda";
            this.desanularComandaToolStripMenuItem.Click += new System.EventHandler(this.desanularComandaToolStripMenuItem_Click);
            // 
            // cambiarFormaDePagoToolStripMenuItem
            // 
            this.cambiarFormaDePagoToolStripMenuItem.Image = global::SOCIOS.Properties.Resources.money;
            this.cambiarFormaDePagoToolStripMenuItem.Name = "cambiarFormaDePagoToolStripMenuItem";
            this.cambiarFormaDePagoToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.cambiarFormaDePagoToolStripMenuItem.Text = "Cambiar Forma de Pago";
            // 
            // cambiarTipoDeComandaToolStripMenuItem
            // 
            this.cambiarTipoDeComandaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cambiarTipoDeComandaToolStripMenuItem.Image")));
            this.cambiarTipoDeComandaToolStripMenuItem.Name = "cambiarTipoDeComandaToolStripMenuItem";
            this.cambiarTipoDeComandaToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.cambiarTipoDeComandaToolStripMenuItem.Text = "Cambiar Tipo de Comanda";
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Location = new System.Drawing.Point(104, 9);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(185, 21);
            this.cbTipoComprobante.TabIndex = 68;
            this.cbTipoComprobante.SelectionChangeCommitted += new System.EventHandler(this.cbTipoComprobante_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "COMPROBANTE";
            // 
            // cmSolicitudes
            // 
            this.cmSolicitudes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3});
            this.cmSolicitudes.Name = "cmComandas";
            this.cmSolicitudes.Size = new System.Drawing.Size(155, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem1.Text = "Imprimir Solicitud";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::SOCIOS.Properties.Resources.delete1;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem3.Text = "Anular Solicitud";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // lbComprobante
            // 
            this.lbComprobante.AutoSize = true;
            this.lbComprobante.Location = new System.Drawing.Point(1230, 403);
            this.lbComprobante.Name = "lbComprobante";
            this.lbComprobante.Size = new System.Drawing.Size(90, 13);
            this.lbComprobante.TabIndex = 69;
            this.lbComprobante.Text = "COMPROBANTE";
            this.lbComprobante.Visible = false;
            // 
            // cbSoloAnuladas
            // 
            this.cbSoloAnuladas.AutoSize = true;
            this.cbSoloAnuladas.Location = new System.Drawing.Point(463, 11);
            this.cbSoloAnuladas.Name = "cbSoloAnuladas";
            this.cbSoloAnuladas.Size = new System.Drawing.Size(84, 17);
            this.cbSoloAnuladas.TabIndex = 71;
            this.cbSoloAnuladas.Text = "ANULADAS";
            this.cbSoloAnuladas.UseVisualStyleBackColor = true;
            // 
            // lbImporteTotalListado
            // 
            this.lbImporteTotalListado.AutoSize = true;
            this.lbImporteTotalListado.Location = new System.Drawing.Point(16, 346);
            this.lbImporteTotalListado.Name = "lbImporteTotalListado";
            this.lbImporteTotalListado.Size = new System.Drawing.Size(97, 13);
            this.lbImporteTotalListado.TabIndex = 72;
            this.lbImporteTotalListado.Text = "IMPORTE TOTAL:";
            // 
            // lbComensalesListados
            // 
            this.lbComensalesListados.AutoSize = true;
            this.lbComensalesListados.Location = new System.Drawing.Point(314, 346);
            this.lbComensalesListados.Name = "lbComensalesListados";
            this.lbComensalesListados.Size = new System.Drawing.Size(149, 13);
            this.lbComensalesListados.TabIndex = 74;
            this.lbComensalesListados.Text = "COMENSALES ESTIMADOS:";
            // 
            // lbPromedioComandaListado
            // 
            this.lbPromedioComandaListado.AutoSize = true;
            this.lbPromedioComandaListado.Location = new System.Drawing.Point(664, 346);
            this.lbPromedioComandaListado.Name = "lbPromedioComandaListado";
            this.lbPromedioComandaListado.Size = new System.Drawing.Size(125, 13);
            this.lbPromedioComandaListado.TabIndex = 76;
            this.lbPromedioComandaListado.Text = "PROMEDIO COMANDA:";
            // 
            // lbTotalComandasListadas
            // 
            this.lbTotalComandasListadas.AutoSize = true;
            this.lbTotalComandasListadas.Location = new System.Drawing.Point(990, 346);
            this.lbTotalComandasListadas.Name = "lbTotalComandasListadas";
            this.lbTotalComandasListadas.Size = new System.Drawing.Size(109, 13);
            this.lbTotalComandasListadas.TabIndex = 78;
            this.lbTotalComandasListadas.Text = "TOTAL COMANDAS:";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Location = new System.Drawing.Point(1202, 341);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(118, 23);
            this.btnExportarExcel.TabIndex = 79;
            this.btnExportarExcel.Text = "EXPORTAR XLS";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // cbTipoDeComanda
            // 
            this.cbTipoDeComanda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeComanda.FormattingEnabled = true;
            this.cbTipoDeComanda.Location = new System.Drawing.Point(329, 9);
            this.cbTipoDeComanda.Name = "cbTipoDeComanda";
            this.cbTipoDeComanda.Size = new System.Drawing.Size(117, 21);
            this.cbTipoDeComanda.TabIndex = 81;
            this.cbTipoDeComanda.SelectionChangeCommitted += new System.EventHandler(this.cbTipoDeComanda_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 80;
            this.label6.Text = "TIPO";
            // 
            // tbHoraDesde
            // 
            this.tbHoraDesde.Location = new System.Drawing.Point(710, 9);
            this.tbHoraDesde.Mask = "00";
            this.tbHoraDesde.Name = "tbHoraDesde";
            this.tbHoraDesde.Size = new System.Drawing.Size(42, 20);
            this.tbHoraDesde.TabIndex = 82;
            this.tbHoraDesde.Text = "01";
            // 
            // tbHoraHasta
            // 
            this.tbHoraHasta.Location = new System.Drawing.Point(905, 9);
            this.tbHoraHasta.Mask = "00";
            this.tbHoraHasta.Name = "tbHoraHasta";
            this.tbHoraHasta.Size = new System.Drawing.Size(42, 20);
            this.tbHoraHasta.TabIndex = 84;
            this.tbHoraHasta.Text = "24";
            // 
            // listadoComandas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 669);
            this.Controls.Add(this.tbHoraHasta);
            this.Controls.Add(this.tbHoraDesde);
            this.Controls.Add(this.cbTipoDeComanda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.lbTotalComandasListadas);
            this.Controls.Add(this.lbPromedioComandaListado);
            this.Controls.Add(this.lbComensalesListados);
            this.Controls.Add(this.lbImporteTotalListado);
            this.Controls.Add(this.lbComprobante);
            this.Controls.Add(this.cbTipoComprobante);
            this.Controls.Add(this.cbSoloAnuladas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbFormaDePago);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgComandas);
            this.Controls.Add(this.dpHasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpDesde);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "listadoComandas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTADO DE COMANDAS Y SOLICITUDES DE DESCUENTO CONFITERÍA SEDE SOCIAL";
            this.Load += new System.EventHandler(this.listadoComandas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgComandas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.cmComandas.ResumeLayout(false);
            this.cmSolicitudes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgComandas;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPRESO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFormaDePago;
        private System.Windows.Forms.ContextMenuStrip cmComandas;
        private System.Windows.Forms.ToolStripMenuItem imprimirComandaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirSolicitudDeDescuentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularComandaToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbTipoComprobante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmSolicitudes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Label lbComprobante;
        private System.Windows.Forms.ToolStripMenuItem modificarItemsToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbSoloAnuladas;
        private System.Windows.Forms.ToolStripMenuItem desanularComandaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cambiarFormaDePagoToolStripMenuItem;
        private System.Windows.Forms.Label lbImporteTotalListado;
        private System.Windows.Forms.Label lbComensalesListados;
        private System.Windows.Forms.Label lbPromedioComandaListado;
        private System.Windows.Forms.Label lbTotalComandasListadas;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.ToolStripMenuItem cambiarTipoDeComandaToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbTipoDeComanda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANULADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOM_SOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_SOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn BARRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AFILIADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BENEFICIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCUENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTRALOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMA_DE_PAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BORRADOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONSUME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERSONAS;
        private System.Windows.Forms.MaskedTextBox tbHoraDesde;
        private System.Windows.Forms.MaskedTextBox tbHoraHasta;
    }
}