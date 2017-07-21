namespace SOCIOS
{
    partial class diasyhorarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(diasyhorarios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelarDia = new System.Windows.Forms.Button();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbHasta = new System.Windows.Forms.MaskedTextBox();
            this.tbDesde = new System.Windows.Forms.MaskedTextBox();
            this.lbEspecialidad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnNuevoDia = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.cbProfesionales = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvListadoDias = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDias)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelarDia);
            this.groupBox1.Controls.Add(this.cbTurno);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbHasta);
            this.groupBox1.Controls.Add(this.tbDesde);
            this.groupBox1.Controls.Add(this.lbEspecialidad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnVer);
            this.groupBox1.Controls.Add(this.btnNuevoDia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtFecha);
            this.groupBox1.Controls.Add(this.cbProfesionales);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Día";
            // 
            // btnCancelarDia
            // 
            this.btnCancelarDia.Location = new System.Drawing.Point(87, 191);
            this.btnCancelarDia.Name = "btnCancelarDia";
            this.btnCancelarDia.Size = new System.Drawing.Size(200, 24);
            this.btnCancelarDia.TabIndex = 65;
            this.btnCancelarDia.Text = "CANCELAR DIA";
            this.btnCancelarDia.UseVisualStyleBackColor = true;
            this.btnCancelarDia.Visible = false;
            this.btnCancelarDia.Click += new System.EventHandler(this.btnCancelarDia_Click);
            // 
            // cbTurno
            // 
            this.cbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Location = new System.Drawing.Point(87, 163);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(59, 21);
            this.cbTurno.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Turno";
            // 
            // tbHasta
            // 
            this.tbHasta.Location = new System.Drawing.Point(228, 130);
            this.tbHasta.Mask = "00:00";
            this.tbHasta.Name = "tbHasta";
            this.tbHasta.Size = new System.Drawing.Size(59, 20);
            this.tbHasta.TabIndex = 5;
            this.tbHasta.ValidatingType = typeof(System.DateTime);
            // 
            // tbDesde
            // 
            this.tbDesde.Location = new System.Drawing.Point(87, 130);
            this.tbDesde.Mask = "00:00";
            this.tbDesde.Name = "tbDesde";
            this.tbDesde.Size = new System.Drawing.Size(59, 20);
            this.tbDesde.TabIndex = 4;
            this.tbDesde.ValidatingType = typeof(System.DateTime);
            // 
            // lbEspecialidad
            // 
            this.lbEspecialidad.AutoSize = true;
            this.lbEspecialidad.Location = new System.Drawing.Point(85, 68);
            this.lbEspecialidad.Name = "lbEspecialidad";
            this.lbEspecialidad.Size = new System.Drawing.Size(84, 13);
            this.lbEspecialidad.TabIndex = 2;
            this.lbEspecialidad.Text = "ESPECIALIDAD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Especialidad";
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(228, 162);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(59, 23);
            this.btnVer.TabIndex = 8;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNuevoDia
            // 
            this.btnNuevoDia.Location = new System.Drawing.Point(163, 162);
            this.btnNuevoDia.Name = "btnNuevoDia";
            this.btnNuevoDia.Size = new System.Drawing.Size(59, 23);
            this.btnNuevoDia.TabIndex = 7;
            this.btnNuevoDia.Text = "Aceptar";
            this.btnNuevoDia.UseVisualStyleBackColor = true;
            this.btnNuevoDia.Click += new System.EventHandler(this.btnNuevoDia_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Desde";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Fecha";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(87, 97);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(100, 20);
            this.dtFecha.TabIndex = 3;
            // 
            // cbProfesionales
            // 
            this.cbProfesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfesionales.FormattingEnabled = true;
            this.cbProfesionales.Location = new System.Drawing.Point(87, 31);
            this.cbProfesionales.Name = "cbProfesionales";
            this.cbProfesionales.Size = new System.Drawing.Size(200, 21);
            this.cbProfesionales.TabIndex = 1;
            this.cbProfesionales.SelectionChangeCommitted += new System.EventHandler(this.cbProfesionales_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Profesional";
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
            this.dgvListadoDias.Location = new System.Drawing.Point(321, 20);
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
            this.dgvListadoDias.Size = new System.Drawing.Size(266, 356);
            this.dgvListadoDias.TabIndex = 47;
            // 
            // diasyhorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 384);
            this.Controls.Add(this.dgvListadoDias);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "diasyhorarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Días y Horarios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.ComboBox cbProfesionales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNuevoDia;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label lbEspecialidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbHasta;
        private System.Windows.Forms.MaskedTextBox tbDesde;
        private System.Windows.Forms.DataGridView dgvListadoDias;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelarDia;
    }
}