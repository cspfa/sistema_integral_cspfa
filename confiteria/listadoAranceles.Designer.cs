namespace Confiteria
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
            this.ARANCEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExportarXls = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgListadoAranceles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(12, 344);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(148, 23);
            this.btnPdf.TabIndex = 79;
            this.btnPdf.Text = "EXPORTAR A PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // dgListadoAranceles
            // 
            this.dgListadoAranceles.AllowUserToAddRows = false;
            this.dgListadoAranceles.AllowUserToDeleteRows = false;
            this.dgListadoAranceles.AllowUserToResizeColumns = false;
            this.dgListadoAranceles.AllowUserToResizeRows = false;
            this.dgListadoAranceles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgListadoAranceles.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgListadoAranceles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgListadoAranceles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgListadoAranceles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DETALLE,
            this.NOMBRE,
            this.ARANCEL});
            this.dgListadoAranceles.Location = new System.Drawing.Point(12, 12);
            this.dgListadoAranceles.MultiSelect = false;
            this.dgListadoAranceles.Name = "dgListadoAranceles";
            this.dgListadoAranceles.RowHeadersVisible = false;
            this.dgListadoAranceles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgListadoAranceles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListadoAranceles.ShowCellErrors = false;
            this.dgListadoAranceles.ShowCellToolTips = false;
            this.dgListadoAranceles.ShowEditingIcon = false;
            this.dgListadoAranceles.ShowRowErrors = false;
            this.dgListadoAranceles.Size = new System.Drawing.Size(657, 326);
            this.dgListadoAranceles.TabIndex = 80;
            this.dgListadoAranceles.TabStop = false;
            // 
            // ARANCEL
            // 
            this.ARANCEL.HeaderText = "ARANCEL";
            this.ARANCEL.Name = "ARANCEL";
            this.ARANCEL.Width = 82;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Width = 79;
            // 
            // DETALLE
            // 
            this.DETALLE.HeaderText = "DETALLE";
            this.DETALLE.Name = "DETALLE";
            this.DETALLE.Width = 80;
            // 
            // btnExportarXls
            // 
            this.btnExportarXls.Location = new System.Drawing.Point(166, 344);
            this.btnExportarXls.Name = "btnExportarXls";
            this.btnExportarXls.Size = new System.Drawing.Size(148, 23);
            this.btnExportarXls.TabIndex = 81;
            this.btnExportarXls.Text = "EXPORTAR A XLS";
            this.btnExportarXls.UseVisualStyleBackColor = true;
            this.btnExportarXls.Click += new System.EventHandler(this.btnExportarXls_Click);
            // 
            // listadoAranceles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 378);
            this.Controls.Add(this.btnExportarXls);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARANCEL;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExportarXls;
    }
}