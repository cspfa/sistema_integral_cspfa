namespace SOCIOS.Turismo.Hoteles
{
    partial class Info_Habitacion
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
            this.dataGridDispo = new System.Windows.Forms.DataGridView();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.lbNombreHabitacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNombreHotel = new System.Windows.Forms.Label();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.NuevoBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDispo)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridDispo
            // 
            this.dataGridDispo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDispo.Location = new System.Drawing.Point(12, 67);
            this.dataGridDispo.Name = "dataGridDispo";
            this.dataGridDispo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDispo.Size = new System.Drawing.Size(530, 202);
            this.dataGridDispo.TabIndex = 0;
            this.dataGridDispo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDispo_CellClick);
            // 
            // dpFecha
            // 
            this.dpFecha.Location = new System.Drawing.Point(12, 22);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(200, 20);
            this.dpFecha.TabIndex = 1;
            this.dpFecha.ValueChanged += new System.EventHandler(this.dpFecha_ValueChanged);
            // 
            // lbNombreHabitacion
            // 
            this.lbNombreHabitacion.AutoSize = true;
            this.lbNombreHabitacion.Location = new System.Drawing.Point(416, 39);
            this.lbNombreHabitacion.Name = "lbNombreHabitacion";
            this.lbNombreHabitacion.Size = new System.Drawing.Size(75, 13);
            this.lbNombreHabitacion.TabIndex = 3;
            this.lbNombreHabitacion.Text = "[NombreHotel]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Habitacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hotel";
            // 
            // lbNombreHotel
            // 
            this.lbNombreHotel.AutoSize = true;
            this.lbNombreHotel.Location = new System.Drawing.Point(416, 8);
            this.lbNombreHotel.Name = "lbNombreHotel";
            this.lbNombreHotel.Size = new System.Drawing.Size(75, 13);
            this.lbNombreHotel.TabIndex = 5;
            this.lbNombreHotel.Text = "[NombreHotel]";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoBank,
            this.toolStripSeparator13,
            this.toolStripButton1});
            this.toolStrip4.Location = new System.Drawing.Point(159, 282);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(170, 25);
            this.toolStrip4.TabIndex = 76;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // NuevoBank
            // 
            this.NuevoBank.Image = global::SOCIOS.Properties.Resources.delete;
            this.NuevoBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuevoBank.Name = "NuevoBank";
            this.NuevoBank.Size = new System.Drawing.Size(63, 22);
            this.NuevoBank.Text = "Liberar";
            this.NuevoBank.Click += new System.EventHandler(this.NuevoBank_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::SOCIOS.Properties.Resources.Untitled__1049_;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(98, 22);
            this.toolStripButton1.Text = "Info Personas";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Info_Habitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 323);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNombreHotel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNombreHabitacion);
            this.Controls.Add(this.dpFecha);
            this.Controls.Add(this.dataGridDispo);
            this.Name = "Info_Habitacion";
            this.Text = "Solicitudes Asociadas Ocupacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Info_Habitacion_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Info_Habitacion_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDispo)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDispo;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label lbNombreHabitacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNombreHotel;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton NuevoBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}