namespace SOCIOS.Turismo
{
    partial class HabitacionHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HabitacionHotel));
            this.cbHotel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHabitacion = new System.Windows.Forms.DataGridView();
            this.gpHabitacionTipo = new System.Windows.Forms.GroupBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPlaza = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.AccionesGrilla = new System.Windows.Forms.ToolStrip();
            this.NuevoBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.Filtrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacion)).BeginInit();
            this.gpHabitacionTipo.SuspendLayout();
            this.AccionesGrilla.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbHotel
            // 
            this.cbHotel.BackColor = System.Drawing.Color.White;
            this.cbHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHotel.FormattingEnabled = true;
            this.cbHotel.Location = new System.Drawing.Point(70, 12);
            this.cbHotel.Name = "cbHotel";
            this.cbHotel.Size = new System.Drawing.Size(233, 21);
            this.cbHotel.TabIndex = 119;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "HOTEL";
            // 
            // dgvHabitacion
            // 
            this.dgvHabitacion.AllowUserToAddRows = false;
            this.dgvHabitacion.AllowUserToDeleteRows = false;
            this.dgvHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitacion.Location = new System.Drawing.Point(24, 49);
            this.dgvHabitacion.Name = "dgvHabitacion";
            this.dgvHabitacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabitacion.Size = new System.Drawing.Size(386, 150);
            this.dgvHabitacion.TabIndex = 121;
            this.dgvHabitacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitacion_CellClick);
            this.dgvHabitacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitacion_CellContentClick);
            // 
            // gpHabitacionTipo
            // 
            this.gpHabitacionTipo.Controls.Add(this.btnGrabar);
            this.gpHabitacionTipo.Controls.Add(this.tbNombre);
            this.gpHabitacionTipo.Controls.Add(this.label4);
            this.gpHabitacionTipo.Controls.Add(this.tbPlaza);
            this.gpHabitacionTipo.Controls.Add(this.label3);
            this.gpHabitacionTipo.Controls.Add(this.label2);
            this.gpHabitacionTipo.Controls.Add(this.cbTipo);
            this.gpHabitacionTipo.Location = new System.Drawing.Point(45, 237);
            this.gpHabitacionTipo.Name = "gpHabitacionTipo";
            this.gpHabitacionTipo.Size = new System.Drawing.Size(347, 156);
            this.gpHabitacionTipo.TabIndex = 122;
            this.gpHabitacionTipo.TabStop = false;
            this.gpHabitacionTipo.Visible = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(246, 127);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 129;
            this.btnGrabar.Text = "Guardar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(149, 92);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(172, 20);
            this.tbNombre.TabIndex = 128;
            this.tbNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "NOMBRE/NUMERO";
            // 
            // tbPlaza
            // 
            this.tbPlaza.Location = new System.Drawing.Point(234, 61);
            this.tbPlaza.Name = "tbPlaza";
            this.tbPlaza.Size = new System.Drawing.Size(87, 20);
            this.tbPlaza.TabIndex = 126;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 125;
            this.label3.Text = "PLAZAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 124;
            this.label2.Text = "TIPO";
            // 
            // cbTipo
            // 
            this.cbTipo.BackColor = System.Drawing.Color.White;
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(88, 29);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(233, 21);
            this.cbTipo.TabIndex = 123;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // AccionesGrilla
            // 
            this.AccionesGrilla.Dock = System.Windows.Forms.DockStyle.None;
            this.AccionesGrilla.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.AccionesGrilla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoBank,
            this.toolStripSeparator13,
            this.CancelarBank});
            this.AccionesGrilla.Location = new System.Drawing.Point(142, 202);
            this.AccionesGrilla.Name = "AccionesGrilla";
            this.AccionesGrilla.Size = new System.Drawing.Size(137, 25);
            this.AccionesGrilla.TabIndex = 123;
            this.AccionesGrilla.Text = "toolStrip4";
            // 
            // NuevoBank
            // 
            this.NuevoBank.Image = ((System.Drawing.Image)(resources.GetObject("NuevoBank.Image")));
            this.NuevoBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuevoBank.Name = "NuevoBank";
            this.NuevoBank.Size = new System.Drawing.Size(69, 22);
            this.NuevoBank.Text = "Agregar";
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
            this.CancelarBank.Size = new System.Drawing.Size(59, 22);
            this.CancelarBank.Text = "Borrar";
            this.CancelarBank.Click += new System.EventHandler(this.CancelarBank_Click);
            // 
            // Filtrar
            // 
            this.Filtrar.Location = new System.Drawing.Point(317, 12);
            this.Filtrar.Name = "Filtrar";
            this.Filtrar.Size = new System.Drawing.Size(75, 23);
            this.Filtrar.TabIndex = 130;
            this.Filtrar.Text = "Ver";
            this.Filtrar.UseVisualStyleBackColor = true;
            this.Filtrar.Click += new System.EventHandler(this.Filtrar_Click);
            // 
            // HabitacionHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 405);
            this.Controls.Add(this.Filtrar);
            this.Controls.Add(this.AccionesGrilla);
            this.Controls.Add(this.gpHabitacionTipo);
            this.Controls.Add(this.dgvHabitacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHotel);
            this.Name = "HabitacionHotel";
            this.Text = "HabitacionHotel";
            this.Load += new System.EventHandler(this.HabitacionHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacion)).EndInit();
            this.gpHabitacionTipo.ResumeLayout(false);
            this.gpHabitacionTipo.PerformLayout();
            this.AccionesGrilla.ResumeLayout(false);
            this.AccionesGrilla.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbHotel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHabitacion;
        private System.Windows.Forms.GroupBox gpHabitacionTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPlaza;
        private System.Windows.Forms.ToolStrip AccionesGrilla;
        private System.Windows.Forms.ToolStripButton NuevoBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button Filtrar;
    }
}