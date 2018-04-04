namespace SOCIOS
{
    partial class anular_op
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbObsAnulaOp = new System.Windows.Forms.TextBox();
            this.btnAnularOp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OBSERVACIONES";
            // 
            // tbObsAnulaOp
            // 
            this.tbObsAnulaOp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObsAnulaOp.Location = new System.Drawing.Point(12, 28);
            this.tbObsAnulaOp.Multiline = true;
            this.tbObsAnulaOp.Name = "tbObsAnulaOp";
            this.tbObsAnulaOp.Size = new System.Drawing.Size(550, 91);
            this.tbObsAnulaOp.TabIndex = 1;
            // 
            // btnAnularOp
            // 
            this.btnAnularOp.Location = new System.Drawing.Point(382, 125);
            this.btnAnularOp.Name = "btnAnularOp";
            this.btnAnularOp.Size = new System.Drawing.Size(180, 23);
            this.btnAnularOp.TabIndex = 2;
            this.btnAnularOp.Text = "ANULAR ORDEN DE PAGO";
            this.btnAnularOp.UseVisualStyleBackColor = true;
            this.btnAnularOp.Click += new System.EventHandler(this.btnAnularOp_Click_1);
            // 
            // anular_op
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 157);
            this.Controls.Add(this.btnAnularOp);
            this.Controls.Add(this.tbObsAnulaOp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "anular_op";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANULAR ORDEN DE PAGO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbObsAnulaOp;
        private System.Windows.Forms.Button btnAnularOp;
    }
}