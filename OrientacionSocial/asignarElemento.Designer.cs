namespace OrientacionSocial
{
    partial class asignarElemento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgDatosSocio = new System.Windows.Forms.DataGridView();
            this.APELLIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_SOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACRJP2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_DTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_EMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoElemento = new System.Windows.Forms.ComboBox();
            this.dgElementos = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXISTENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dpFechaRetira = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dpFechaDevuelve = new System.Windows.Forms.DateTimePicker();
            this.cbFormaDePago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dpFechaDto = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.tbObesrvaciones = new System.Windows.Forms.TextBox();
            this.tbDomicilio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosSocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgElementos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "REGISTRO SELECCIONADO";
            // 
            // dgDatosSocio
            // 
            this.dgDatosSocio.AllowUserToAddRows = false;
            this.dgDatosSocio.AllowUserToDeleteRows = false;
            this.dgDatosSocio.AllowUserToResizeColumns = false;
            this.dgDatosSocio.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgDatosSocio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDatosSocio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDatosSocio.BackgroundColor = System.Drawing.Color.White;
            this.dgDatosSocio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgDatosSocio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDatosSocio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDatosSocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatosSocio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.APELLIDO,
            this.NOMBRE,
            this.NRO_SOC,
            this.NRO_DEP,
            this.CATEGORIA,
            this.ACRJP2,
            this.COD_DTO,
            this.ID_EMP});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDatosSocio.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgDatosSocio.Location = new System.Drawing.Point(14, 35);
            this.dgDatosSocio.Margin = new System.Windows.Forms.Padding(5);
            this.dgDatosSocio.Name = "dgDatosSocio";
            this.dgDatosSocio.ReadOnly = true;
            this.dgDatosSocio.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDatosSocio.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDatosSocio.RowHeadersVisible = false;
            this.dgDatosSocio.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgDatosSocio.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDatosSocio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDatosSocio.Size = new System.Drawing.Size(801, 33);
            this.dgDatosSocio.TabIndex = 47;
            // 
            // APELLIDO
            // 
            this.APELLIDO.HeaderText = "APELLIDO";
            this.APELLIDO.Name = "APELLIDO";
            this.APELLIDO.ReadOnly = true;
            this.APELLIDO.Width = 82;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 77;
            // 
            // NRO_SOC
            // 
            this.NRO_SOC.HeaderText = "NRO_SOC";
            this.NRO_SOC.Name = "NRO_SOC";
            this.NRO_SOC.ReadOnly = true;
            this.NRO_SOC.Width = 82;
            // 
            // NRO_DEP
            // 
            this.NRO_DEP.HeaderText = "NRO_DEP";
            this.NRO_DEP.Name = "NRO_DEP";
            this.NRO_DEP.ReadOnly = true;
            this.NRO_DEP.Width = 82;
            // 
            // CATEGORIA
            // 
            this.CATEGORIA.HeaderText = "CATEGORÍA";
            this.CATEGORIA.Name = "CATEGORIA";
            this.CATEGORIA.ReadOnly = true;
            this.CATEGORIA.Width = 92;
            // 
            // ACRJP2
            // 
            this.ACRJP2.HeaderText = "ACRJP2";
            this.ACRJP2.Name = "ACRJP2";
            this.ACRJP2.ReadOnly = true;
            this.ACRJP2.Width = 70;
            // 
            // COD_DTO
            // 
            this.COD_DTO.HeaderText = "COD_DTO";
            this.COD_DTO.Name = "COD_DTO";
            this.COD_DTO.ReadOnly = true;
            this.COD_DTO.Width = 82;
            // 
            // ID_EMP
            // 
            this.ID_EMP.HeaderText = "ID EMP";
            this.ID_EMP.Name = "ID_EMP";
            this.ID_EMP.ReadOnly = true;
            this.ID_EMP.Width = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "TIPO DE ELEMENTO";
            // 
            // cbTipoElemento
            // 
            this.cbTipoElemento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoElemento.FormattingEnabled = true;
            this.cbTipoElemento.Location = new System.Drawing.Point(130, 78);
            this.cbTipoElemento.Name = "cbTipoElemento";
            this.cbTipoElemento.Size = new System.Drawing.Size(207, 21);
            this.cbTipoElemento.TabIndex = 49;
            // 
            // dgElementos
            // 
            this.dgElementos.AllowUserToAddRows = false;
            this.dgElementos.AllowUserToDeleteRows = false;
            this.dgElementos.AllowUserToResizeColumns = false;
            this.dgElementos.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgElementos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgElementos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgElementos.BackgroundColor = System.Drawing.Color.White;
            this.dgElementos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgElementos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgElementos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgElementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgElementos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.STOCK,
            this.EXISTENCIA,
            this.ESTADO});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgElementos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgElementos.Location = new System.Drawing.Point(15, 107);
            this.dgElementos.Margin = new System.Windows.Forms.Padding(5);
            this.dgElementos.Name = "dgElementos";
            this.dgElementos.ReadOnly = true;
            this.dgElementos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgElementos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgElementos.RowHeadersVisible = false;
            this.dgElementos.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgElementos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgElementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgElementos.Size = new System.Drawing.Size(801, 208);
            this.dgElementos.TabIndex = 50;
            // 
            // CODIGO
            // 
            this.CODIGO.HeaderText = "CODIGO";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Width = 72;
            // 
            // STOCK
            // 
            this.STOCK.HeaderText = "STOCK";
            this.STOCK.Name = "STOCK";
            this.STOCK.ReadOnly = true;
            this.STOCK.Width = 66;
            // 
            // EXISTENCIA
            // 
            this.EXISTENCIA.HeaderText = "EXISTENCIA";
            this.EXISTENCIA.Name = "EXISTENCIA";
            this.EXISTENCIA.ReadOnly = true;
            this.EXISTENCIA.Width = 93;
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "ESTADO";
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.ReadOnly = true;
            this.ESTADO.Width = 74;
            // 
            // dpFechaRetira
            // 
            this.dpFechaRetira.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaRetira.Location = new System.Drawing.Point(106, 328);
            this.dpFechaRetira.Name = "dpFechaRetira";
            this.dpFechaRetira.Size = new System.Drawing.Size(85, 20);
            this.dpFechaRetira.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "FECHA RETIRA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "FECHA DEVUELVE";
            // 
            // dpFechaDevuelve
            // 
            this.dpFechaDevuelve.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDevuelve.Location = new System.Drawing.Point(311, 328);
            this.dpFechaDevuelve.Name = "dpFechaDevuelve";
            this.dpFechaDevuelve.Size = new System.Drawing.Size(85, 20);
            this.dpFechaDevuelve.TabIndex = 53;
            // 
            // cbFormaDePago
            // 
            this.cbFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaDePago.FormattingEnabled = true;
            this.cbFormaDePago.Location = new System.Drawing.Point(510, 328);
            this.cbFormaDePago.Name = "cbFormaDePago";
            this.cbFormaDePago.Size = new System.Drawing.Size(126, 21);
            this.cbFormaDePago.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "FORMA DE PAGO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(645, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "FECHA A DTO";
            // 
            // dpFechaDto
            // 
            this.dpFechaDto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDto.Location = new System.Drawing.Point(732, 328);
            this.dpFechaDto.Name = "dpFechaDto";
            this.dpFechaDto.Size = new System.Drawing.Size(85, 20);
            this.dpFechaDto.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "OBSERV";
            // 
            // tbObesrvaciones
            // 
            this.tbObesrvaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObesrvaciones.Location = new System.Drawing.Point(106, 356);
            this.tbObesrvaciones.Name = "tbObesrvaciones";
            this.tbObesrvaciones.Size = new System.Drawing.Size(710, 20);
            this.tbObesrvaciones.TabIndex = 60;
            // 
            // tbDomicilio
            // 
            this.tbDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDomicilio.Location = new System.Drawing.Point(105, 383);
            this.tbDomicilio.Name = "tbDomicilio";
            this.tbDomicilio.Size = new System.Drawing.Size(291, 20);
            this.tbDomicilio.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "DOMICILIO";
            // 
            // asignarElemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 597);
            this.Controls.Add(this.tbDomicilio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbObesrvaciones);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dpFechaDto);
            this.Controls.Add(this.cbFormaDePago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dpFechaDevuelve);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpFechaRetira);
            this.Controls.Add(this.dgElementos);
            this.Controls.Add(this.cbTipoElemento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgDatosSocio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "asignarElemento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASIGNAR ELEMENTO ORTOPÉDICO";
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosSocio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgElementos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDatosSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn APELLIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_SOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACRJP2;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_DTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_EMP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoElemento;
        private System.Windows.Forms.DataGridView dgElementos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXISTENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADO;
        private System.Windows.Forms.DateTimePicker dpFechaRetira;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpFechaDevuelve;
        private System.Windows.Forms.ComboBox cbFormaDePago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpFechaDto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbObesrvaciones;
        private System.Windows.Forms.TextBox tbDomicilio;
        private System.Windows.Forms.Label label8;
    }
}