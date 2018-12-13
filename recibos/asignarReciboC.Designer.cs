namespace SOCIOS
{
    partial class asignarReciboC
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
            this.cbPtosDeVta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNroReciboC = new System.Windows.Forms.TextBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PUNTO DE VENTA";
            // 
            // cbPtosDeVta
            // 
            this.cbPtosDeVta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPtosDeVta.FormattingEnabled = true;
            this.cbPtosDeVta.Location = new System.Drawing.Point(128, 18);
            this.cbPtosDeVta.Name = "cbPtosDeVta";
            this.cbPtosDeVta.Size = new System.Drawing.Size(121, 21);
            this.cbPtosDeVta.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "NRO RECIBO C";
            // 
            // tbNroReciboC
            // 
            this.tbNroReciboC.Location = new System.Drawing.Point(128, 51);
            this.tbNroReciboC.Name = "tbNroReciboC";
            this.tbNroReciboC.Size = new System.Drawing.Size(121, 20);
            this.tbNroReciboC.TabIndex = 3;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(128, 83);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(121, 23);
            this.btnAsignar.TabIndex = 4;
            this.btnAsignar.Text = "ASIGNAR";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // asignarReciboC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 122);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.tbNroReciboC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPtosDeVta);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "asignarReciboC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASIGNAR RECIBO C";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPtosDeVta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNroReciboC;
        private System.Windows.Forms.Button btnAsignar;
    }
}