namespace Buffet
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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARANCEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BARRAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExportarXls = new System.Windows.Forms.Button();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnVerTodos = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.btnAsignarBarras = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBarCodeSearch = new System.Windows.Forms.TextBox();
            this.btnImprimirBarcode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgListadoAranceles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(990, 65);
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
            this.STOCK,
            this.BARRAS});
            this.dgListadoAranceles.Location = new System.Drawing.Point(12, 65);
            this.dgListadoAranceles.MultiSelect = false;
            this.dgListadoAranceles.Name = "dgListadoAranceles";
            this.dgListadoAranceles.RowHeadersVisible = false;
            this.dgListadoAranceles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgListadoAranceles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListadoAranceles.ShowCellErrors = false;
            this.dgListadoAranceles.ShowCellToolTips = false;
            this.dgListadoAranceles.ShowEditingIcon = false;
            this.dgListadoAranceles.ShowRowErrors = false;
            this.dgListadoAranceles.Size = new System.Drawing.Size(972, 435);
            this.dgListadoAranceles.TabIndex = 80;
            this.dgListadoAranceles.TabStop = false;
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
            // BARRAS
            // 
            this.BARRAS.HeaderText = "BARRAS";
            this.BARRAS.Name = "BARRAS";
            this.BARRAS.Width = 76;
            // 
            // btnExportarXls
            // 
            this.btnExportarXls.Location = new System.Drawing.Point(990, 94);
            this.btnExportarXls.Name = "btnExportarXls";
            this.btnExportarXls.Size = new System.Drawing.Size(127, 54);
            this.btnExportarXls.TabIndex = 81;
            this.btnExportarXls.Text = "EXPORTAR XLS PARA ACTUALIZACION";
            this.btnExportarXls.UseVisualStyleBackColor = true;
            this.btnExportarXls.Click += new System.EventHandler(this.btnExportarXls_Click);
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(108, 37);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(55, 20);
            this.tbStock.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "SUMAR STOCK";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 84;
            this.button1.Text = "ACTUALIZAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "CATEGORIA";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(108, 8);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(179, 21);
            this.cbCategoria.TabIndex = 86;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(293, 7);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(95, 23);
            this.btnFiltrar.TabIndex = 87;
            this.btnFiltrar.Text = "FILTRAR";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnVerTodos
            // 
            this.btnVerTodos.Location = new System.Drawing.Point(293, 35);
            this.btnVerTodos.Name = "btnVerTodos";
            this.btnVerTodos.Size = new System.Drawing.Size(95, 23);
            this.btnVerTodos.TabIndex = 88;
            this.btnVerTodos.Text = "VER TODOS";
            this.btnVerTodos.UseVisualStyleBackColor = true;
            this.btnVerTodos.Click += new System.EventHandler(this.btnVerTodos_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(990, 154);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(127, 54);
            this.btnImportar.TabIndex = 89;
            this.btnImportar.Text = "IMPORTAR XLS PARA ACTUALIZACION";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "ASIGNAR BARRAS";
            // 
            // tbBarCode
            // 
            this.tbBarCode.Location = new System.Drawing.Point(506, 8);
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.Size = new System.Drawing.Size(193, 20);
            this.tbBarCode.TabIndex = 90;
            this.tbBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBarCode_KeyPress);
            this.tbBarCode.Leave += new System.EventHandler(this.tbBarCode_Leave);
            // 
            // btnAsignarBarras
            // 
            this.btnAsignarBarras.Location = new System.Drawing.Point(705, 7);
            this.btnAsignarBarras.Name = "btnAsignarBarras";
            this.btnAsignarBarras.Size = new System.Drawing.Size(95, 23);
            this.btnAsignarBarras.TabIndex = 92;
            this.btnAsignarBarras.Text = "ASIGNAR";
            this.btnAsignarBarras.UseVisualStyleBackColor = true;
            this.btnAsignarBarras.Click += new System.EventHandler(this.btnAsignarBarras_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "BUSCAR BARRAS";
            // 
            // tbBarCodeSearch
            // 
            this.tbBarCodeSearch.Location = new System.Drawing.Point(506, 37);
            this.tbBarCodeSearch.Name = "tbBarCodeSearch";
            this.tbBarCodeSearch.Size = new System.Drawing.Size(193, 20);
            this.tbBarCodeSearch.TabIndex = 93;
            this.tbBarCodeSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBarCodeSearch_KeyPress);
            this.tbBarCodeSearch.Leave += new System.EventHandler(this.tbBarCodeSearch_Leave);
            // 
            // btnImprimirBarcode
            // 
            this.btnImprimirBarcode.Location = new System.Drawing.Point(990, 214);
            this.btnImprimirBarcode.Name = "btnImprimirBarcode";
            this.btnImprimirBarcode.Size = new System.Drawing.Size(127, 23);
            this.btnImprimirBarcode.TabIndex = 95;
            this.btnImprimirBarcode.Text = "IMPRIMIR CODIGO";
            this.btnImprimirBarcode.UseVisualStyleBackColor = true;
            this.btnImprimirBarcode.Click += new System.EventHandler(this.btnImprimirBarcode_Click);
            // 
            // listadoAranceles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 512);
            this.Controls.Add(this.btnImprimirBarcode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbBarCodeSearch);
            this.Controls.Add(this.btnAsignarBarras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBarCode);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnVerTodos);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnVerTodos;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBarCode;
        private System.Windows.Forms.Button btnAsignarBarras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBarCodeSearch;
        private System.Windows.Forms.Button btnImprimirBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARANCEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn BARRAS;
    }
}