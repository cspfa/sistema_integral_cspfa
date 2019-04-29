namespace SOCIOS
{
    partial class Condicion_IVA
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
            this.lbInfo = new System.Windows.Forms.Label();
            this.Grabar = new System.Windows.Forms.Button();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(13, 13);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(10, 13);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Text = "-";
            // 
            // Grabar
            // 
            this.Grabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Grabar.Location = new System.Drawing.Point(75, 86);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(75, 23);
            this.Grabar.TabIndex = 1;
            this.Grabar.Text = "Grabar";
            this.Grabar.UseVisualStyleBackColor = true;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // cbTipo
            // 
            this.cbTipo.BackColor = System.Drawing.Color.White;
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(16, 38);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(166, 21);
            this.cbTipo.TabIndex = 4;
            // 
            // Condicion_IVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 121);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.lbInfo);
            this.Name = "Condicion_IVA";
            this.Text = "Condicion IVA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button Grabar;
        private System.Windows.Forms.ComboBox cbTipo;
    }
}