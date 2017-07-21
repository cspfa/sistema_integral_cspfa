namespace SOCIOS.Tecnica
{
    partial class ABM_Seguimiento
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbSeguimiento = new System.Windows.Forms.TextBox();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.Grabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FECHA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SEGUIMIENTO";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbSeguimiento
            // 
            this.tbSeguimiento.Location = new System.Drawing.Point(12, 62);
            this.tbSeguimiento.Multiline = true;
            this.tbSeguimiento.Name = "tbSeguimiento";
            this.tbSeguimiento.Size = new System.Drawing.Size(498, 158);
            this.tbSeguimiento.TabIndex = 2;
            // 
            // dpFecha
            // 
            this.dpFecha.Location = new System.Drawing.Point(310, 15);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(200, 20);
            this.dpFecha.TabIndex = 3;
            // 
            // Grabar
            // 
            this.Grabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Grabar.Location = new System.Drawing.Point(435, 226);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(75, 23);
            this.Grabar.TabIndex = 4;
            this.Grabar.Text = "Nuevo";
            this.Grabar.UseVisualStyleBackColor = true;
            this.Grabar.Visible = false;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // ABM_Seguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 261);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.dpFecha);
            this.Controls.Add(this.tbSeguimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ABM_Seguimiento";
            this.Text = "ABM_Seguimiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSeguimiento;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Button Grabar;
    }
}