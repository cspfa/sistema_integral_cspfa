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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExportarXls = new System.Windows.Forms.Button();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARANCEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgListadoAranceles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(598, 69);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(127, 23);
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
            this.ID,
            this.DETALLE,
            this.NOMBRE,
            this.ARANCEL,
            this.STOCK});
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
            this.dgListadoAranceles.Size = new System.Drawing.Size(548, 395);
            this.dgListadoAranceles.TabIndex = 80;
            this.dgListadoAranceles.TabStop = false;
            // 
            // btnExportarXls
            // 
            this.btnExportarXls.Location = new System.Drawing.Point(598, 98);
            this.btnExportarXls.Name = "btnExportarXls";
            this.btnExportarXls.Size = new System.Drawing.Size(127, 23);
            this.btnExportarXls.TabIndex = 81;
            this.btnExportarXls.Text = "EXPORTAR A XLS";
            this.btnExportarXls.UseVisualStyleBackColor = true;
            this.btnExportarXls.Click += new System.EventHandler(this.btnExportarXls_Click);
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(670, 14);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(55, 20);
            this.tbStock.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "NUEVO STOCK";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(598, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 84;
            this.button1.Text = "ACTUALIZAR STOCK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 43;
            // 
            // DETALLE
            // 
            this.DETALLE.HeaderText = "DETALLE";
            this.DETALLE.Name = "DETALLE";
            this.DETALLE.Width = 80;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Width = 79;
            // 
            // ARANCEL
            // 
            this.ARANCEL.HeaderText = "ARANCEL";
            this.ARANCEL.Name = "ARANCEL";
            this.ARANCEL.Width = 82;
            // 
            // STOCK
            // 
            this.STOCK.HeaderText = "STOCK";
            this.STOCK.Name = "STOCK";
            this.STOCK.Width = 68;
            // 
            // listadoAranceles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 419);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbStock);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.DataGridView dgListadoAranceles;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExportarXls;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARANCEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK;
    }
}