namespace SOCIOS.Tecnica
{
    partial class UpdateTicket
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
            this.tbObs = new System.Windows.Forms.TextBox();
            this.cbTecnico = new System.Windows.Forms.ComboBox();
            this.lbTecnico = new System.Windows.Forms.Label();
            this.lbDato = new System.Windows.Forms.Label();
            this.cbPrioridad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDisponibles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGrabar.Location = new System.Drawing.Point(632, 155);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(191, 23);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // tbObs
            // 
            this.tbObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObs.Location = new System.Drawing.Point(12, 32);
            this.tbObs.Multiline = true;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(811, 103);
            this.tbObs.TabIndex = 7;
            this.tbObs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbObs_KeyUp);
            // 
            // cbTecnico
            // 
            this.cbTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTecnico.FormattingEnabled = true;
            this.cbTecnico.Location = new System.Drawing.Point(72, 155);
            this.cbTecnico.Name = "cbTecnico";
            this.cbTecnico.Size = new System.Drawing.Size(200, 21);
            this.cbTecnico.TabIndex = 8;
            // 
            // lbTecnico
            // 
            this.lbTecnico.AutoSize = true;
            this.lbTecnico.Location = new System.Drawing.Point(12, 159);
            this.lbTecnico.Name = "lbTecnico";
            this.lbTecnico.Size = new System.Drawing.Size(54, 13);
            this.lbTecnico.TabIndex = 6;
            this.lbTecnico.Text = "TECNICO";
            // 
            // lbDato
            // 
            this.lbDato.AutoSize = true;
            this.lbDato.Location = new System.Drawing.Point(12, 9);
            this.lbDato.Name = "lbDato";
            this.lbDato.Size = new System.Drawing.Size(35, 13);
            this.lbDato.TabIndex = 5;
            this.lbDato.Text = "label1";
            // 
            // cbPrioridad
            // 
            this.cbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrioridad.FormattingEnabled = true;
            this.cbPrioridad.Location = new System.Drawing.Point(380, 156);
            this.cbPrioridad.Name = "cbPrioridad";
            this.cbPrioridad.Size = new System.Drawing.Size(140, 21);
            this.cbPrioridad.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "PRIORIDAD:";
            // 
            // lbDisponibles
            // 
            this.lbDisponibles.AutoSize = true;
            this.lbDisponibles.Location = new System.Drawing.Point(12, 138);
            this.lbDisponibles.Name = "lbDisponibles";
            this.lbDisponibles.Size = new System.Drawing.Size(177, 13);
            this.lbDisponibles.TabIndex = 12;
            this.lbDisponibles.Text = "CARACTERES DISPONIBLES: 300";
            // 
            // UpdateTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 183);
            this.Controls.Add(this.lbDisponibles);
            this.Controls.Add(this.cbPrioridad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbObs);
            this.Controls.Add(this.cbTecnico);
            this.Controls.Add(this.lbTecnico);
            this.Controls.Add(this.lbDato);
            this.Name = "UpdateTicket";
            this.Text = "CambiarComentario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.ComboBox cbTecnico;
        private System.Windows.Forms.Label lbTecnico;
        private System.Windows.Forms.Label lbDato;
        private System.Windows.Forms.ComboBox cbPrioridad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbDisponibles;
    }
}