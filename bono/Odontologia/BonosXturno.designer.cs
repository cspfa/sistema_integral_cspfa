namespace SOCIOS.bono.Odontologia
{
    partial class BonosXturno
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
            this.cbBono = new System.Windows.Forms.ComboBox();
            this.Imprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbBono
            // 
            this.cbBono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBono.FormattingEnabled = true;
            this.cbBono.Location = new System.Drawing.Point(12, 21);
            this.cbBono.Name = "cbBono";
            this.cbBono.Size = new System.Drawing.Size(358, 21);
            this.cbBono.TabIndex = 88;
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(142, 65);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(75, 23);
            this.Imprimir.TabIndex = 89;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // BonosXturno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 100);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.cbBono);
            this.Name = "BonosXturno";
            this.Text = "Bonos X Turno";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBono;
        private System.Windows.Forms.Button Imprimir;
    }
}