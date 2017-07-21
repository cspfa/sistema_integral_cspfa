namespace SOCIOS.confiteria
{
    partial class listadoAranceles
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
            this.btnPdf = new System.Windows.Forms.Button();
            this.dgListadoAranceles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgListadoAranceles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(703, 344);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(148, 23);
            this.btnPdf.TabIndex = 79;
            this.btnPdf.Text = "EXPORTAR A PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            // 
            // dgListadoAranceles
            // 
            this.dgListadoAranceles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListadoAranceles.Location = new System.Drawing.Point(12, 12);
            this.dgListadoAranceles.Name = "dgListadoAranceles";
            this.dgListadoAranceles.Size = new System.Drawing.Size(839, 326);
            this.dgListadoAranceles.TabIndex = 80;
            // 
            // listadoAranceles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 378);
            this.Controls.Add(this.dgListadoAranceles);
            this.Controls.Add(this.btnPdf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "listadoAranceles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "listadoAranceles";
            this.Load += new System.EventHandler(this.listadoAranceles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgListadoAranceles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.DataGridView dgListadoAranceles;
    }
}