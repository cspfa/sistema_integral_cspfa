namespace SOCIOS.bono
{
    partial class Reintegro_Bono_Turismo
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
            this.lbSaldo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReintegro = new System.Windows.Forms.TextBox();
            this.btnReintegro = new System.Windows.Forms.Button();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "SALDO";
            // 
            // lbSaldo
            // 
            this.lbSaldo.AutoSize = true;
            this.lbSaldo.BackColor = System.Drawing.Color.Transparent;
            this.lbSaldo.Location = new System.Drawing.Point(171, 23);
            this.lbSaldo.Name = "lbSaldo";
            this.lbSaldo.Size = new System.Drawing.Size(43, 13);
            this.lbSaldo.TabIndex = 1;
            this.lbSaldo.Text = "SALDO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "REINTEGRO";
            // 
            // tbReintegro
            // 
            this.tbReintegro.Location = new System.Drawing.Point(146, 82);
            this.tbReintegro.Name = "tbReintegro";
            this.tbReintegro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbReintegro.Size = new System.Drawing.Size(67, 20);
            this.tbReintegro.TabIndex = 3;
            this.tbReintegro.Text = "0";
            // 
            // btnReintegro
            // 
            this.btnReintegro.Location = new System.Drawing.Point(146, 233);
            this.btnReintegro.Name = "btnReintegro";
            this.btnReintegro.Size = new System.Drawing.Size(75, 23);
            this.btnReintegro.TabIndex = 4;
            this.btnReintegro.Text = "Reintegro";
            this.btnReintegro.UseVisualStyleBackColor = true;
            this.btnReintegro.Click += new System.EventHandler(this.btnReintegro_Click);
            // 
            // tbObs
            // 
            this.tbObs.Location = new System.Drawing.Point(25, 134);
            this.tbObs.Multiline = true;
            this.tbObs.Name = "tbObs";
            this.tbObs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbObs.Size = new System.Drawing.Size(366, 93);
            this.tbObs.TabIndex = 5;
            this.tbObs.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "OBSERVACIONES";
            // 
            // Reintegro_Bono_Turismo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(403, 268);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbObs);
            this.Controls.Add(this.btnReintegro);
            this.Controls.Add(this.tbReintegro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbSaldo);
            this.Controls.Add(this.label1);
            this.Name = "Reintegro_Bono_Turismo";
            this.Text = "Reintegro_Bono_Turismo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSaldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbReintegro;
        private System.Windows.Forms.Button btnReintegro;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.Label label3;
    }
}