namespace SOCIOS.Tecnica
{
    partial class PasarEstado
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
            this.lbDato = new System.Windows.Forms.Label();
            this.lbTecnico = new System.Windows.Forms.Label();
            this.cbTecnico = new System.Windows.Forms.ComboBox();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDato
            // 
            this.lbDato.AutoSize = true;
            this.lbDato.Location = new System.Drawing.Point(12, 16);
            this.lbDato.Name = "lbDato";
            this.lbDato.Size = new System.Drawing.Size(35, 13);
            this.lbDato.TabIndex = 0;
            this.lbDato.Text = "label1";
            // 
            // lbTecnico
            // 
            this.lbTecnico.AutoSize = true;
            this.lbTecnico.Location = new System.Drawing.Point(197, 151);
            this.lbTecnico.Name = "lbTecnico";
            this.lbTecnico.Size = new System.Drawing.Size(54, 13);
            this.lbTecnico.TabIndex = 1;
            this.lbTecnico.Text = "TECNICO";
            // 
            // cbTecnico
            // 
            this.cbTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTecnico.FormattingEnabled = true;
            this.cbTecnico.Location = new System.Drawing.Point(257, 147);
            this.cbTecnico.Name = "cbTecnico";
            this.cbTecnico.Size = new System.Drawing.Size(200, 21);
            this.cbTecnico.TabIndex = 2;
            // 
            // tbObs
            // 
            this.tbObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObs.Location = new System.Drawing.Point(12, 39);
            this.tbObs.Multiline = true;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(648, 103);
            this.tbObs.TabIndex = 1;
            // 
            // btnGrabar
            // 
            this.btnGrabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGrabar.Location = new System.Drawing.Point(464, 146);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(191, 23);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click_1);
            // 
            // PasarEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 177);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbObs);
            this.Controls.Add(this.cbTecnico);
            this.Controls.Add(this.lbTecnico);
            this.Controls.Add(this.lbDato);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PasarEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAMBIAR ESTADO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDato;
        private System.Windows.Forms.Label lbTecnico;
        private System.Windows.Forms.ComboBox cbTecnico;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.Button btnGrabar;
    }
}