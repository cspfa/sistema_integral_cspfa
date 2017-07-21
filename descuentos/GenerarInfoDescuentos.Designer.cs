namespace SOCIOS.descuentos
{
    partial class GenerarInfoDescuentos
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
            this.GENERAR = new System.Windows.Forms.Button();
            this.VER = new System.Windows.Forms.Button();
            this.rbPasividad = new System.Windows.Forms.RadioButton();
            this.rbActivos = new System.Windows.Forms.RadioButton();
            this.dgDescuentos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgDescuentos)).BeginInit();
            this.SuspendLayout();
            // 
            // GENERAR
            // 
            this.GENERAR.Location = new System.Drawing.Point(663, 12);
            this.GENERAR.Name = "GENERAR";
            this.GENERAR.Size = new System.Drawing.Size(75, 23);
            this.GENERAR.TabIndex = 8;
            this.GENERAR.Text = "GENERAR";
            this.GENERAR.UseVisualStyleBackColor = true;
            this.GENERAR.Visible = false;
            this.GENERAR.Click += new System.EventHandler(this.GENERAR_Click);
            // 
            // VER
            // 
            this.VER.Location = new System.Drawing.Point(543, 12);
            this.VER.Name = "VER";
            this.VER.Size = new System.Drawing.Size(96, 23);
            this.VER.TabIndex = 7;
            this.VER.Text = "VER";
            this.VER.UseVisualStyleBackColor = true;
            this.VER.Click += new System.EventHandler(this.VER_Click);
            // 
            // rbPasividad
            // 
            this.rbPasividad.AutoSize = true;
            this.rbPasividad.Location = new System.Drawing.Point(114, 12);
            this.rbPasividad.Name = "rbPasividad";
            this.rbPasividad.Size = new System.Drawing.Size(71, 17);
            this.rbPasividad.TabIndex = 6;
            this.rbPasividad.Text = "Pasividad";
            this.rbPasividad.UseVisualStyleBackColor = true;
            // 
            // rbActivos
            // 
            this.rbActivos.AutoSize = true;
            this.rbActivos.Checked = true;
            this.rbActivos.Location = new System.Drawing.Point(12, 12);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(69, 17);
            this.rbActivos.TabIndex = 5;
            this.rbActivos.TabStop = true;
            this.rbActivos.Text = "Actividad";
            this.rbActivos.UseVisualStyleBackColor = true;
            // 
            // dgDescuentos
            // 
            this.dgDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDescuentos.Location = new System.Drawing.Point(12, 41);
            this.dgDescuentos.Name = "dgDescuentos";
            this.dgDescuentos.Size = new System.Drawing.Size(749, 334);
            this.dgDescuentos.TabIndex = 10;
            // 
            // GenerarInfoDescuentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 404);
            this.Controls.Add(this.dgDescuentos);
            this.Controls.Add(this.GENERAR);
            this.Controls.Add(this.VER);
            this.Controls.Add(this.rbPasividad);
            this.Controls.Add(this.rbActivos);
            this.Name = "GenerarInfoDescuentos";
            this.Text = "GenerarInfoDescuentos";
            ((System.ComponentModel.ISupportInitialize)(this.dgDescuentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GENERAR;
        private System.Windows.Forms.Button VER;
        private System.Windows.Forms.RadioButton rbPasividad;
        private System.Windows.Forms.RadioButton rbActivos;
        private System.Windows.Forms.DataGridView dgDescuentos;
    }
}