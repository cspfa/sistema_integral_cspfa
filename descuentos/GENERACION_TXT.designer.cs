namespace SOCIOS.descuentos
{
    partial class GENERACION_TXT
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
            this.rbActivos = new System.Windows.Forms.RadioButton();
            this.rbPasividad = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VER = new System.Windows.Forms.Button();
            this.GENERAR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbActivos
            // 
            this.rbActivos.AutoSize = true;
            this.rbActivos.Checked = true;
            this.rbActivos.Location = new System.Drawing.Point(12, 12);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(69, 17);
            this.rbActivos.TabIndex = 0;
            this.rbActivos.TabStop = true;
            this.rbActivos.Text = "Actividad";
            this.rbActivos.UseVisualStyleBackColor = true;
            this.rbActivos.CheckedChanged += new System.EventHandler(this.rbActivos_CheckedChanged);
            // 
            // rbPasividad
            // 
            this.rbPasividad.AutoSize = true;
            this.rbPasividad.Location = new System.Drawing.Point(114, 12);
            this.rbPasividad.Name = "rbPasividad";
            this.rbPasividad.Size = new System.Drawing.Size(71, 17);
            this.rbPasividad.TabIndex = 1;
            this.rbPasividad.Text = "Pasividad";
            this.rbPasividad.UseVisualStyleBackColor = true;
            this.rbPasividad.CheckedChanged += new System.EventHandler(this.rbPasividad_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(861, 509);
            this.dataGridView1.TabIndex = 2;
            // 
            // VER
            // 
            this.VER.Location = new System.Drawing.Point(200, 9);
            this.VER.Name = "VER";
            this.VER.Size = new System.Drawing.Size(96, 23);
            this.VER.TabIndex = 3;
            this.VER.Text = "VER";
            this.VER.UseVisualStyleBackColor = true;
            this.VER.Click += new System.EventHandler(this.VER_Click);
            // 
            // GENERAR
            // 
            this.GENERAR.Location = new System.Drawing.Point(320, 9);
            this.GENERAR.Name = "GENERAR";
            this.GENERAR.Size = new System.Drawing.Size(75, 23);
            this.GENERAR.TabIndex = 4;
            this.GENERAR.Text = "GENERAR";
            this.GENERAR.UseVisualStyleBackColor = true;
            this.GENERAR.Visible = false;
            this.GENERAR.Click += new System.EventHandler(this.GENERAR_Click);
            // 
            // GENERACION_TXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 556);
            this.Controls.Add(this.GENERAR);
            this.Controls.Add(this.VER);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rbPasividad);
            this.Controls.Add(this.rbActivos);
            this.Name = "GENERACION_TXT";
            this.Text = "GENERACION_TXT";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbActivos;
        private System.Windows.Forms.RadioButton rbPasividad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button VER;
        private System.Windows.Forms.Button GENERAR;
    }
}