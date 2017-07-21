namespace SOCIOS.descuentos
{
    partial class ARCHIVOS_PROCESADOS
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
            this.VER = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rbPasividad = new System.Windows.Forms.RadioButton();
            this.rbActivos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMes = new System.Windows.Forms.TextBox();
            this.tbAnio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // VER
            // 
            this.VER.Location = new System.Drawing.Point(391, 6);
            this.VER.Name = "VER";
            this.VER.Size = new System.Drawing.Size(96, 23);
            this.VER.TabIndex = 7;
            this.VER.Text = "FILTRAR";
            this.VER.UseVisualStyleBackColor = true;
            this.VER.Click += new System.EventHandler(this.VER_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(861, 509);
            this.dataGridView1.TabIndex = 6;
            // 
            // rbPasividad
            // 
            this.rbPasividad.AutoSize = true;
            this.rbPasividad.Location = new System.Drawing.Point(114, 9);
            this.rbPasividad.Name = "rbPasividad";
            this.rbPasividad.Size = new System.Drawing.Size(71, 17);
            this.rbPasividad.TabIndex = 5;
            this.rbPasividad.Text = "Pasividad";
            this.rbPasividad.UseVisualStyleBackColor = true;
            this.rbPasividad.CheckedChanged += new System.EventHandler(this.rbPasividad_CheckedChanged);
            // 
            // rbActivos
            // 
            this.rbActivos.AutoSize = true;
            this.rbActivos.Checked = true;
            this.rbActivos.Location = new System.Drawing.Point(12, 9);
            this.rbActivos.Name = "rbActivos";
            this.rbActivos.Size = new System.Drawing.Size(69, 17);
            this.rbActivos.TabIndex = 4;
            this.rbActivos.TabStop = true;
            this.rbActivos.Text = "Actividad";
            this.rbActivos.UseVisualStyleBackColor = true;
            this.rbActivos.CheckedChanged += new System.EventHandler(this.rbActivos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "FECHA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "/";
            // 
            // tbMes
            // 
            this.tbMes.Location = new System.Drawing.Point(262, 6);
            this.tbMes.Name = "tbMes";
            this.tbMes.Size = new System.Drawing.Size(28, 20);
            this.tbMes.TabIndex = 10;
            // 
            // tbAnio
            // 
            this.tbAnio.Location = new System.Drawing.Point(314, 6);
            this.tbAnio.Name = "tbAnio";
            this.tbAnio.Size = new System.Drawing.Size(61, 20);
            this.tbAnio.TabIndex = 11;
            // 
            // ARCHIVOS_PROCESADOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 547);
            this.Controls.Add(this.tbAnio);
            this.Controls.Add(this.tbMes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VER);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rbPasividad);
            this.Controls.Add(this.rbActivos);
            this.Name = "ARCHIVOS_PROCESADOS";
            this.Text = "ARCHIVOS_PROCESADOS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VER;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rbPasividad;
        private System.Windows.Forms.RadioButton rbActivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMes;
        private System.Windows.Forms.TextBox tbAnio;
    }
}