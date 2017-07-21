namespace SOCIOS
{
    partial class informeAranceles
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
            this.dgvAranceles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAranceles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAranceles
            // 
            this.dgvAranceles.AllowUserToAddRows = false;
            this.dgvAranceles.AllowUserToDeleteRows = false;
            this.dgvAranceles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAranceles.Location = new System.Drawing.Point(12, 12);
            this.dgvAranceles.Name = "dgvAranceles";
            this.dgvAranceles.ReadOnly = true;
            this.dgvAranceles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAranceles.Size = new System.Drawing.Size(884, 369);
            this.dgvAranceles.TabIndex = 1;
            // 
            // informeAranceles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 393);
            this.Controls.Add(this.dgvAranceles);
            this.Name = "informeAranceles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe Aranceles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAranceles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAranceles;
    }
}