namespace SOCIOS.deportes
{
    partial class admActividades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admActividades));
            this.cbActividad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaApto = new System.Windows.Forms.Label();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.NuevoBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.tbAnioDto = new System.Windows.Forms.TextBox();
            this.tbMesDTO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.gpValores = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDescuento = new System.Windows.Forms.TextBox();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.gpValores.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbActividad
            // 
            this.cbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActividad.FormattingEnabled = true;
            this.cbActividad.Location = new System.Drawing.Point(98, 31);
            this.cbActividad.Name = "cbActividad";
            this.cbActividad.Size = new System.Drawing.Size(373, 21);
            this.cbActividad.TabIndex = 54;
            this.cbActividad.SelectedIndexChanged += new System.EventHandler(this.cbActividad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "FECHA:";
            // 
            // FechaApto
            // 
            this.FechaApto.AutoSize = true;
            this.FechaApto.Location = new System.Drawing.Point(19, 35);
            this.FechaApto.Name = "FechaApto";
            this.FechaApto.Size = new System.Drawing.Size(67, 13);
            this.FechaApto.TabIndex = 72;
            this.FechaApto.Text = "ACTIVIDAD:";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoBank,
            this.toolStripSeparator13,
            this.CancelarBank});
            this.toolStrip4.Location = new System.Drawing.Point(239, 158);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(151, 25);
            this.toolStrip4.TabIndex = 74;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // NuevoBank
            // 
            this.NuevoBank.Image = ((System.Drawing.Image)(resources.GetObject("NuevoBank.Image")));
            this.NuevoBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuevoBank.Name = "NuevoBank";
            this.NuevoBank.Size = new System.Drawing.Size(62, 22);
            this.NuevoBank.Text = "Nuevo";
            this.NuevoBank.Click += new System.EventHandler(this.NuevoBank_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // CancelarBank
            // 
            this.CancelarBank.Image = ((System.Drawing.Image)(resources.GetObject("CancelarBank.Image")));
            this.CancelarBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarBank.Name = "CancelarBank";
            this.CancelarBank.Size = new System.Drawing.Size(49, 22);
            this.CancelarBank.Text = "Baja";
            this.CancelarBank.Click += new System.EventHandler(this.CancelarBank_Click_1);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(99, 99);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(163, 23);
            this.btnGrabar.TabIndex = 79;
            this.btnGrabar.Text = "GUARDAR ACTIVIDAD";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // tbAnioDto
            // 
            this.tbAnioDto.Location = new System.Drawing.Point(415, 66);
            this.tbAnioDto.Name = "tbAnioDto";
            this.tbAnioDto.Size = new System.Drawing.Size(57, 20);
            this.tbAnioDto.TabIndex = 78;
            // 
            // tbMesDTO
            // 
            this.tbMesDTO.Location = new System.Drawing.Point(271, 66);
            this.tbMesDTO.Name = "tbMesDTO";
            this.tbMesDTO.Size = new System.Drawing.Size(57, 20);
            this.tbMesDTO.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "AÑO DTO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "MES DTO:";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(99, 66);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(85, 20);
            this.dpFecha.TabIndex = 74;
            this.dpFecha.Visible = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(10, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(620, 135);
            this.dataGridView.TabIndex = 76;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // gpValores
            // 
            this.gpValores.Controls.Add(this.label1);
            this.gpValores.Controls.Add(this.tbDescuento);
            this.gpValores.Controls.Add(this.cbActividad);
            this.gpValores.Controls.Add(this.btnGrabar);
            this.gpValores.Controls.Add(this.label2);
            this.gpValores.Controls.Add(this.tbAnioDto);
            this.gpValores.Controls.Add(this.FechaApto);
            this.gpValores.Controls.Add(this.dpFecha);
            this.gpValores.Controls.Add(this.tbMesDTO);
            this.gpValores.Controls.Add(this.label3);
            this.gpValores.Controls.Add(this.label4);
            this.gpValores.Location = new System.Drawing.Point(12, 189);
            this.gpValores.Name = "gpValores";
            this.gpValores.Size = new System.Drawing.Size(614, 140);
            this.gpValores.TabIndex = 80;
            this.gpValores.TabStop = false;
            this.gpValores.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "% S-Cargo";
            // 
            // tbDescuento
            // 
            this.tbDescuento.Location = new System.Drawing.Point(435, 99);
            this.tbDescuento.Name = "tbDescuento";
            this.tbDescuento.Size = new System.Drawing.Size(36, 20);
            this.tbDescuento.TabIndex = 80;
            this.tbDescuento.Text = "0";
            this.tbDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // admActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 349);
            this.Controls.Add(this.gpValores);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip4);
            this.ErrorProviderBlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.ErrorProviderIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "admActividades";
            this.Text = "Actividades del Socio";
            this.Load += new System.EventHandler(this.admActividades_Load);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.gpValores.ResumeLayout(false);
            this.gpValores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbActividad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FechaApto;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton NuevoBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox tbAnioDto;
        private System.Windows.Forms.TextBox tbMesDTO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox gpValores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDescuento;

    }
}

