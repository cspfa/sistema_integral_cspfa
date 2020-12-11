namespace SOCIOS.entradaCampo.CSPFA
{
    partial class ConfiguracionAforo
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
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPileta = new System.Windows.Forms.TextBox();
            this.tbDia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(12, 72);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(197, 23);
            this.btnGrabar.TabIndex = 0;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Piletas X Turno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aforo x Dia ";
            // 
            // tbPileta
            // 
            this.tbPileta.Location = new System.Drawing.Point(122, 5);
            this.tbPileta.Name = "tbPileta";
            this.tbPileta.Size = new System.Drawing.Size(55, 20);
            this.tbPileta.TabIndex = 3;
            // 
            // tbDia
            // 
            this.tbDia.Location = new System.Drawing.Point(122, 34);
            this.tbDia.Name = "tbDia";
            this.tbDia.Size = new System.Drawing.Size(55, 20);
            this.tbDia.TabIndex = 4;
            // 
            // ConfiguracionAforo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 100);
            this.Controls.Add(this.tbDia);
            this.Controls.Add(this.tbPileta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGrabar);
            this.Name = "ConfiguracionAforo";
            this.Text = "Limites Aforo";
            this.Load += new System.EventHandler(this.ConfiguracionAforo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPileta;
        private System.Windows.Forms.TextBox tbDia;
    }
}