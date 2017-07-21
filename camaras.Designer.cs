namespace SOCIOS
{
    partial class camaras
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVerImagenes = new System.Windows.Forms.Button();
            this.cbCamaras = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHoraHasta = new System.Windows.Forms.MaskedTextBox();
            this.tbFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHoraDesde = new System.Windows.Forms.MaskedTextBox();
            this.tbFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnVerImagenes);
            this.groupBox1.Controls.Add(this.cbCamaras);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbHoraHasta);
            this.groupBox1.Controls.Add(this.tbFechaHasta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbHoraDesde);
            this.groupBox1.Controls.Add(this.tbFechaDesde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "COPIAR IMAGENES";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVerImagenes
            // 
            this.btnVerImagenes.Location = new System.Drawing.Point(71, 99);
            this.btnVerImagenes.Name = "btnVerImagenes";
            this.btnVerImagenes.Size = new System.Drawing.Size(135, 23);
            this.btnVerImagenes.TabIndex = 9;
            this.btnVerImagenes.Text = "VER CAMARAS";
            this.btnVerImagenes.UseVisualStyleBackColor = true;
            this.btnVerImagenes.Click += new System.EventHandler(this.btnVerImagenes_Click);
            // 
            // cbCamaras
            // 
            this.cbCamaras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamaras.FormattingEnabled = true;
            this.cbCamaras.Location = new System.Drawing.Point(282, 30);
            this.cbCamaras.Name = "cbCamaras";
            this.cbCamaras.Size = new System.Drawing.Size(197, 21);
            this.cbCamaras.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "CAMARA";
            // 
            // tbHoraHasta
            // 
            this.tbHoraHasta.Location = new System.Drawing.Point(154, 66);
            this.tbHoraHasta.Mask = "00:00";
            this.tbHoraHasta.Name = "tbHoraHasta";
            this.tbHoraHasta.Size = new System.Drawing.Size(52, 20);
            this.tbHoraHasta.TabIndex = 6;
            this.tbHoraHasta.Text = "1000";
            this.tbHoraHasta.ValidatingType = typeof(System.DateTime);
            // 
            // tbFechaHasta
            // 
            this.tbFechaHasta.Location = new System.Drawing.Point(71, 66);
            this.tbFechaHasta.Mask = "00/00/0000";
            this.tbFechaHasta.Name = "tbFechaHasta";
            this.tbFechaHasta.Size = new System.Drawing.Size(76, 20);
            this.tbFechaHasta.TabIndex = 5;
            this.tbFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "HASTA";
            // 
            // tbHoraDesde
            // 
            this.tbHoraDesde.Location = new System.Drawing.Point(154, 30);
            this.tbHoraDesde.Mask = "00:00";
            this.tbHoraDesde.Name = "tbHoraDesde";
            this.tbHoraDesde.Size = new System.Drawing.Size(52, 20);
            this.tbHoraDesde.TabIndex = 3;
            this.tbHoraDesde.Text = "0800";
            this.tbHoraDesde.ValidatingType = typeof(System.DateTime);
            // 
            // tbFechaDesde
            // 
            this.tbFechaDesde.Location = new System.Drawing.Point(71, 30);
            this.tbFechaDesde.Mask = "00/00/0000";
            this.tbFechaDesde.Name = "tbFechaDesde";
            this.tbFechaDesde.Size = new System.Drawing.Size(76, 20);
            this.tbFechaDesde.TabIndex = 2;
            this.tbFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DESDE";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(282, 99);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(197, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 12;
            // 
            // camaras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 164);
            this.Controls.Add(this.groupBox1);
            this.Name = "camaras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camaras";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbCamaras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbHoraHasta;
        private System.Windows.Forms.MaskedTextBox tbFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbHoraDesde;
        private System.Windows.Forms.MaskedTextBox tbFechaDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerImagenes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;

    }
}