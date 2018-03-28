namespace SOCIOS.deportes
{
    partial class Responsables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Responsables));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.NuevoBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.gpNuevo = new System.Windows.Forms.GroupBox();
            this.btnGranar = new System.Windows.Forms.Button();
            this.tbVinculo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.gpNuevo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(516, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoBank,
            this.toolStripSeparator13,
            this.CancelarBank});
            this.toolStrip4.Location = new System.Drawing.Point(200, 165);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(151, 25);
            this.toolStrip4.TabIndex = 76;
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
            this.CancelarBank.Click += new System.EventHandler(this.CancelarBank_Click);
            // 
            // gpNuevo
            // 
            this.gpNuevo.Controls.Add(this.btnGranar);
            this.gpNuevo.Controls.Add(this.tbVinculo);
            this.gpNuevo.Controls.Add(this.label6);
            this.gpNuevo.Controls.Add(this.tbMail);
            this.gpNuevo.Controls.Add(this.label5);
            this.gpNuevo.Controls.Add(this.tbTelefono);
            this.gpNuevo.Controls.Add(this.label4);
            this.gpNuevo.Controls.Add(this.tbApellido);
            this.gpNuevo.Controls.Add(this.label3);
            this.gpNuevo.Controls.Add(this.tbDni);
            this.gpNuevo.Controls.Add(this.label2);
            this.gpNuevo.Controls.Add(this.tbNombre);
            this.gpNuevo.Controls.Add(this.label1);
            this.gpNuevo.Location = new System.Drawing.Point(31, 193);
            this.gpNuevo.Name = "gpNuevo";
            this.gpNuevo.Size = new System.Drawing.Size(474, 118);
            this.gpNuevo.TabIndex = 77;
            this.gpNuevo.TabStop = false;
            this.gpNuevo.Text = "Nuevo ";
            this.gpNuevo.Visible = false;
            // 
            // btnGranar
            // 
            this.btnGranar.Location = new System.Drawing.Point(293, 71);
            this.btnGranar.Name = "btnGranar";
            this.btnGranar.Size = new System.Drawing.Size(75, 23);
            this.btnGranar.TabIndex = 90;
            this.btnGranar.Text = "Nuevo";
            this.btnGranar.UseVisualStyleBackColor = true;
            this.btnGranar.Click += new System.EventHandler(this.btnGranar_Click);
            // 
            // tbVinculo
            // 
            this.tbVinculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbVinculo.Location = new System.Drawing.Point(293, 45);
            this.tbVinculo.MaxLength = 200;
            this.tbVinculo.Name = "tbVinculo";
            this.tbVinculo.Size = new System.Drawing.Size(141, 20);
            this.tbVinculo.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Vinculo";
            // 
            // tbMail
            // 
            this.tbMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbMail.Location = new System.Drawing.Point(293, 19);
            this.tbMail.MaxLength = 200;
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(141, 20);
            this.tbMail.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Email";
            // 
            // tbTelefono
            // 
            this.tbTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTelefono.Location = new System.Drawing.Point(71, 91);
            this.tbTelefono.MaxLength = 200;
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(141, 20);
            this.tbTelefono.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Telefono";
            // 
            // tbApellido
            // 
            this.tbApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbApellido.Location = new System.Drawing.Point(71, 67);
            this.tbApellido.MaxLength = 200;
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(141, 20);
            this.tbApellido.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Apellido";
            // 
            // tbDni
            // 
            this.tbDni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDni.Location = new System.Drawing.Point(114, 19);
            this.tbDni.MaxLength = 200;
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(98, 20);
            this.tbDni.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "DNI";
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Location = new System.Drawing.Point(71, 45);
            this.tbNombre.MaxLength = 200;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(141, 20);
            this.tbNombre.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Nombre";
            // 
            // btnGrabar
            // 
            this.btnGrabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGrabar.Location = new System.Drawing.Point(226, 332);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 91;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            // 
            // Responsables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 394);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.gpNuevo);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Responsables";
            this.Text = "Responsables";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.gpNuevo.ResumeLayout(false);
            this.gpNuevo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton NuevoBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.GroupBox gpNuevo;
        private System.Windows.Forms.Button btnGranar;
        private System.Windows.Forms.TextBox tbVinculo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrabar;
    }
}