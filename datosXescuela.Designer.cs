namespace SOCIOS
{
    partial class datosXescuela
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
            this.btnExaminarTxt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTxt = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbXls = new System.Windows.Forms.Label();
            this.btnExaminarXls = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExaminarTxt
            // 
            this.btnExaminarTxt.Location = new System.Drawing.Point(21, 32);
            this.btnExaminarTxt.Name = "btnExaminarTxt";
            this.btnExaminarTxt.Size = new System.Drawing.Size(75, 23);
            this.btnExaminarTxt.TabIndex = 0;
            this.btnExaminarTxt.Text = "Examinar...";
            this.btnExaminarTxt.UseVisualStyleBackColor = true;
            this.btnExaminarTxt.Click += new System.EventHandler(this.btnExaminarTxt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTxt);
            this.groupBox1.Controls.Add(this.btnExaminarTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivo TXT";
            // 
            // lbTxt
            // 
            this.lbTxt.AutoSize = true;
            this.lbTxt.Location = new System.Drawing.Point(103, 37);
            this.lbTxt.Name = "lbTxt";
            this.lbTxt.Size = new System.Drawing.Size(124, 13);
            this.lbTxt.TabIndex = 1;
            this.lbTxt.Text = "Archivo no seleccionado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbXls);
            this.groupBox2.Controls.Add(this.btnExaminarXls);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 76);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archivo XLS";
            // 
            // lbXls
            // 
            this.lbXls.AutoSize = true;
            this.lbXls.Location = new System.Drawing.Point(103, 37);
            this.lbXls.Name = "lbXls";
            this.lbXls.Size = new System.Drawing.Size(124, 13);
            this.lbXls.TabIndex = 1;
            this.lbXls.Text = "Archivo no seleccionado";
            // 
            // btnExaminarXls
            // 
            this.btnExaminarXls.Location = new System.Drawing.Point(21, 32);
            this.btnExaminarXls.Name = "btnExaminarXls";
            this.btnExaminarXls.Size = new System.Drawing.Size(75, 23);
            this.btnExaminarXls.TabIndex = 0;
            this.btnExaminarXls.Text = "Examinar...";
            this.btnExaminarXls.UseVisualStyleBackColor = true;
            this.btnExaminarXls.Click += new System.EventHandler(this.btnExaminarXls_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(514, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "PROCESAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(12, 176);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(496, 35);
            this.pbar.TabIndex = 4;
            this.pbar.Visible = false;
            // 
            // datosXescuela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 226);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "datosXescuela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cruce de datos...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExaminarTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbXls;
        private System.Windows.Forms.Button btnExaminarXls;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar pbar;
    }
}