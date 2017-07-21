namespace SOCIOS.deportes
{
    partial class DescuentoDeportes
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
            this.dataGridDtoDepo = new System.Windows.Forms.DataGridView();
            this.TXT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.XLS = new System.Windows.Forms.Button();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.lbRol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDtoDepo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridDtoDepo
            // 
            this.dataGridDtoDepo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDtoDepo.Location = new System.Drawing.Point(12, 39);
            this.dataGridDtoDepo.Name = "dataGridDtoDepo";
            this.dataGridDtoDepo.Size = new System.Drawing.Size(1253, 503);
            this.dataGridDtoDepo.TabIndex = 0;
            // 
            // TXT
            // 
            this.TXT.Location = new System.Drawing.Point(13, 561);
            this.TXT.Name = "TXT";
            this.TXT.Size = new System.Drawing.Size(101, 23);
            this.TXT.TabIndex = 1;
            this.TXT.Text = "TXT ACT";
            this.TXT.UseVisualStyleBackColor = true;
            this.TXT.Visible = false;
            this.TXT.Click += new System.EventHandler(this.TXT_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 561);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "TXTS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // XLS
            // 
            this.XLS.Location = new System.Drawing.Point(336, 561);
            this.XLS.Name = "XLS";
            this.XLS.Size = new System.Drawing.Size(75, 23);
            this.XLS.TabIndex = 3;
            this.XLS.Text = "XLS";
            this.XLS.UseVisualStyleBackColor = true;
            this.XLS.Click += new System.EventHandler(this.XLS_Click);
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(92, 6);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(125, 21);
            this.cbRol.TabIndex = 96;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(12, 9);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(32, 13);
            this.lbRol.TabIndex = 97;
            this.lbRol.Text = "ROL:";
            // 
            // DescuentoDeportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 596);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.lbRol);
            this.Controls.Add(this.XLS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TXT);
            this.Controls.Add(this.dataGridDtoDepo);
            this.Name = "DescuentoDeportes";
            this.Text = "DescuentoDeportes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDtoDepo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDtoDepo;
        private System.Windows.Forms.Button TXT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button XLS;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label lbRol;
    }
}