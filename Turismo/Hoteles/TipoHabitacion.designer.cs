namespace SOCIOS.Turismo
{
    partial class TipoHabitacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipoHabitacion));
            this.AccionesGrilla = new System.Windows.Forms.ToolStrip();
            this.NuevoBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.dgvTipoHabitacion = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTipo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpDatos = new System.Windows.Forms.GroupBox();
            this.tbCamas = new System.Windows.Forms.TextBox();
            this.lbTipoHab = new System.Windows.Forms.Label();
            this.chkPersona = new System.Windows.Forms.CheckBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.AccionesGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoHabitacion)).BeginInit();
            this.gpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccionesGrilla
            // 
            this.AccionesGrilla.Dock = System.Windows.Forms.DockStyle.None;
            this.AccionesGrilla.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.AccionesGrilla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoBank,
            this.toolStripSeparator13,
            this.CancelarBank});
            this.AccionesGrilla.Location = new System.Drawing.Point(154, 172);
            this.AccionesGrilla.Name = "AccionesGrilla";
            this.AccionesGrilla.Size = new System.Drawing.Size(137, 25);
            this.AccionesGrilla.TabIndex = 113;
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
            this.CancelarBank.Click += new System.EventHandler(this.CancelarBank_Click_1);
            // 
            // dgvTipoHabitacion
            // 
            this.dgvTipoHabitacion.AllowUserToAddRows = false;
            this.dgvTipoHabitacion.AllowUserToDeleteRows = false;
            this.dgvTipoHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoHabitacion.Location = new System.Drawing.Point(33, 12);
            this.dgvTipoHabitacion.Name = "dgvTipoHabitacion";
            this.dgvTipoHabitacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTipoHabitacion.Size = new System.Drawing.Size(507, 150);
            this.dgvTipoHabitacion.TabIndex = 114;
            this.dgvTipoHabitacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipoHabitacion_CellClick);
            this.dgvTipoHabitacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipoHabitacion_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TIPO";
            // 
            // tbTipo
            // 
            this.tbTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTipo.Location = new System.Drawing.Point(77, 13);
            this.tbTipo.Name = "tbTipo";
            this.tbTipo.Size = new System.Drawing.Size(246, 20);
            this.tbTipo.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 146;
            this.label7.Text = "CAMAS";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(411, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 36);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "GUARDAR";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gpDatos
            // 
            this.gpDatos.Controls.Add(this.cbTipo);
            this.gpDatos.Controls.Add(this.chkPersona);
            this.gpDatos.Controls.Add(this.lbTipoHab);
            this.gpDatos.Controls.Add(this.btnSave);
            this.gpDatos.Controls.Add(this.tbCamas);
            this.gpDatos.Controls.Add(this.label7);
            this.gpDatos.Controls.Add(this.tbTipo);
            this.gpDatos.Controls.Add(this.label1);
            this.gpDatos.Location = new System.Drawing.Point(31, 200);
            this.gpDatos.Name = "gpDatos";
            this.gpDatos.Size = new System.Drawing.Size(509, 120);
            this.gpDatos.TabIndex = 115;
            this.gpDatos.TabStop = false;
            this.gpDatos.Visible = false;
            // 
            // tbCamas
            // 
            this.tbCamas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCamas.Location = new System.Drawing.Point(77, 50);
            this.tbCamas.Name = "tbCamas";
            this.tbCamas.Size = new System.Drawing.Size(94, 20);
            this.tbCamas.TabIndex = 165;
            // 
            // lbTipoHab
            // 
            this.lbTipoHab.AutoSize = true;
            this.lbTipoHab.Location = new System.Drawing.Point(87, 86);
            this.lbTipoHab.Name = "lbTipoHab";
            this.lbTipoHab.Size = new System.Drawing.Size(60, 13);
            this.lbTipoHab.TabIndex = 166;
            this.lbTipoHab.Text = "TIPO HAB.";
            this.lbTipoHab.Visible = false;
            // 
            // chkPersona
            // 
            this.chkPersona.AutoSize = true;
            this.chkPersona.Location = new System.Drawing.Point(6, 85);
            this.chkPersona.Name = "chkPersona";
            this.chkPersona.Size = new System.Drawing.Size(75, 17);
            this.chkPersona.TabIndex = 167;
            this.chkPersona.Text = "X Persona";
            this.chkPersona.UseVisualStyleBackColor = true;
            this.chkPersona.CheckedChanged += new System.EventHandler(this.chkPersona_CheckedChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.BackColor = System.Drawing.Color.White;
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(153, 81);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(205, 21);
            this.cbTipo.TabIndex = 168;
            this.cbTipo.Visible = false;
            // 
            // TipoHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 332);
            this.Controls.Add(this.gpDatos);
            this.Controls.Add(this.dgvTipoHabitacion);
            this.Controls.Add(this.AccionesGrilla);
            this.Name = "TipoHabitacion";
            this.Text = "TipoHabitacion";
            this.AccionesGrilla.ResumeLayout(false);
            this.AccionesGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoHabitacion)).EndInit();
            this.gpDatos.ResumeLayout(false);
            this.gpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip AccionesGrilla;
        private System.Windows.Forms.ToolStripButton NuevoBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.DataGridView dgvTipoHabitacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gpDatos;
        private System.Windows.Forms.TextBox tbCamas;
        private System.Windows.Forms.CheckBox chkPersona;
        private System.Windows.Forms.Label lbTipoHab;
        private System.Windows.Forms.ComboBox cbTipo;
    }
}