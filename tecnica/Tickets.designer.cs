namespace SOCIOS.Tecnica
{
    partial class Tickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tickets));
            this.cbfiltro = new System.Windows.Forms.ComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Activo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.Cumplimentar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.cbFiltroFecha = new System.Windows.Forms.CheckBox();
            this.reporte = new System.Windows.Forms.Button();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbfiltro
            // 
            this.cbfiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfiltro.FormattingEnabled = true;
            this.cbfiltro.Location = new System.Drawing.Point(12, 12);
            this.cbfiltro.Name = "cbfiltro";
            this.cbfiltro.Size = new System.Drawing.Size(138, 21);
            this.cbfiltro.TabIndex = 104;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(71, 22);
            this.toolStripButton1.Text = "FILTRAR";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // Activo
            // 
            this.Activo.Image = ((System.Drawing.Image)(resources.GetObject("Activo.Image")));
            this.Activo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Activo.Name = "Activo";
            this.Activo.Size = new System.Drawing.Size(69, 22);
            this.Activo.Text = "ACTIVO";
            this.Activo.Click += new System.EventHandler(this.Activo_Click);
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
            this.CancelarBank.Size = new System.Drawing.Size(87, 22);
            this.CancelarBank.Text = "CANCELAR";
            this.CancelarBank.Click += new System.EventHandler(this.CancelarBank_Click);
            // 
            // Cumplimentar
            // 
            this.Cumplimentar.Image = ((System.Drawing.Image)(resources.GetObject("Cumplimentar.Image")));
            this.Cumplimentar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cumplimentar.Name = "Cumplimentar";
            this.Cumplimentar.Size = new System.Drawing.Size(128, 22);
            this.Cumplimentar.Text = "CUMPLIMENTADO";
            this.Cumplimentar.Click += new System.EventHandler(this.Cumplimentar_Click);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.Activo,
            this.toolStripSeparator13,
            this.CancelarBank,
            this.Cumplimentar,
            this.toolStripButton2});
            this.toolStrip4.Location = new System.Drawing.Point(161, 12);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(387, 25);
            this.toolStrip4.TabIndex = 103;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::SOCIOS.Properties.Resources.application_edit;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "MODIFICAR ";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1170, 303);
            this.dataGridView1.TabIndex = 105;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(792, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "HASTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(648, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "DESDE";
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(841, 14);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(88, 20);
            this.dpHasta.TabIndex = 107;
            // 
            // dpDesde
            // 
            this.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDesde.Location = new System.Drawing.Point(698, 14);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(88, 20);
            this.dpDesde.TabIndex = 106;
            // 
            // cbFiltroFecha
            // 
            this.cbFiltroFecha.AutoSize = true;
            this.cbFiltroFecha.Location = new System.Drawing.Point(564, 16);
            this.cbFiltroFecha.Name = "cbFiltroFecha";
            this.cbFiltroFecha.Size = new System.Drawing.Size(78, 17);
            this.cbFiltroFecha.TabIndex = 110;
            this.cbFiltroFecha.Text = "FiltroFecha";
            this.cbFiltroFecha.UseVisualStyleBackColor = true;
            // 
            // reporte
            // 
            this.reporte.Location = new System.Drawing.Point(1076, 9);
            this.reporte.Name = "reporte";
            this.reporte.Size = new System.Drawing.Size(75, 23);
            this.reporte.TabIndex = 111;
            this.reporte.Text = "REPORTE";
            this.reporte.UseVisualStyleBackColor = true;
            this.reporte.Visible = false;
            this.reporte.Click += new System.EventHandler(this.reporte_Click);
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 355);
            this.Controls.Add(this.reporte);
            this.Controls.Add(this.cbFiltroFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpHasta);
            this.Controls.Add(this.dpDesde);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbfiltro);
            this.Controls.Add(this.toolStrip4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tickets";
            this.Load += new System.EventHandler(this.Tickets_Load);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbfiltro;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton Activo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.ToolStripButton Cumplimentar;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.CheckBox cbFiltroFecha;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button reporte;
    }
}