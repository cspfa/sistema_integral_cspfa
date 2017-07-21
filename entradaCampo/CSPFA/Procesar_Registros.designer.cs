namespace SOCIOS.Entrada_Campo
{
    partial class Procesar_Registros
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
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.btnAbrirXLS = new System.Windows.Forms.Button();
            this.lbArchivoXLS = new System.Windows.Forms.Label();
            this.Importar = new System.Windows.Forms.Button();
            this.Grabar = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.lbTextoProceso = new System.Windows.Forms.Label();
            this.lbGrabar = new System.Windows.Forms.Label();
            this.procesarRed = new System.Windows.Forms.Button();
            this.gpRed = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbROLES = new System.Windows.Forms.ComboBox();
            this.regRed = new System.Windows.Forms.Button();
            this.pnlID = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHASTA = new System.Windows.Forms.TextBox();
            this.Desde = new System.Windows.Forms.Label();
            this.tbDESDE = new System.Windows.Forms.TextBox();
            this.chkFiltro = new System.Windows.Forms.CheckBox();
            this.cbID = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.gpRed.SuspendLayout();
            this.pnlID.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Location = new System.Drawing.Point(12, 151);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.Size = new System.Drawing.Size(1002, 195);
            this.dgvIngresos.TabIndex = 1;
            this.dgvIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngresos_CellContentClick);
            // 
            // btnAbrirXLS
            // 
            this.btnAbrirXLS.Location = new System.Drawing.Point(12, 12);
            this.btnAbrirXLS.Name = "btnAbrirXLS";
            this.btnAbrirXLS.Size = new System.Drawing.Size(147, 23);
            this.btnAbrirXLS.TabIndex = 18;
            this.btnAbrirXLS.Text = "ABRIR XLS";
            this.btnAbrirXLS.UseVisualStyleBackColor = true;
            this.btnAbrirXLS.Click += new System.EventHandler(this.btnAbrirXLS_Click);
            // 
            // lbArchivoXLS
            // 
            this.lbArchivoXLS.AutoSize = true;
            this.lbArchivoXLS.Location = new System.Drawing.Point(249, 12);
            this.lbArchivoXLS.Name = "lbArchivoXLS";
            this.lbArchivoXLS.Size = new System.Drawing.Size(198, 13);
            this.lbArchivoXLS.TabIndex = 17;
            this.lbArchivoXLS.Text = "ARCHIVO SELECCIONADO: NINGUNO";
            // 
            // Importar
            // 
            this.Importar.Location = new System.Drawing.Point(12, 41);
            this.Importar.Name = "Importar";
            this.Importar.Size = new System.Drawing.Size(147, 23);
            this.Importar.TabIndex = 19;
            this.Importar.Text = "IMPORTAR";
            this.Importar.UseVisualStyleBackColor = true;
            this.Importar.Click += new System.EventHandler(this.Importar_Click);
            // 
            // Grabar
            // 
            this.Grabar.Location = new System.Drawing.Point(939, 359);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(75, 52);
            this.Grabar.TabIndex = 20;
            this.Grabar.Text = "Grabar Registros";
            this.Grabar.UseVisualStyleBackColor = true;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lbTextoProceso
            // 
            this.lbTextoProceso.AutoSize = true;
            this.lbTextoProceso.Location = new System.Drawing.Point(456, 13);
            this.lbTextoProceso.Name = "lbTextoProceso";
            this.lbTextoProceso.Size = new System.Drawing.Size(135, 13);
            this.lbTextoProceso.TabIndex = 26;
            this.lbTextoProceso.Text = "-LISTO PARA PROCESAR";
            // 
            // lbGrabar
            // 
            this.lbGrabar.AutoSize = true;
            this.lbGrabar.Location = new System.Drawing.Point(12, 96);
            this.lbGrabar.Name = "lbGrabar";
            this.lbGrabar.Size = new System.Drawing.Size(10, 13);
            this.lbGrabar.TabIndex = 27;
            this.lbGrabar.Text = "-";
            // 
            // procesarRed
            // 
            this.procesarRed.Location = new System.Drawing.Point(12, 70);
            this.procesarRed.Name = "procesarRed";
            this.procesarRed.Size = new System.Drawing.Size(147, 23);
            this.procesarRed.TabIndex = 28;
            this.procesarRed.Text = "Procesar Desde Red";
            this.procesarRed.UseVisualStyleBackColor = true;
            this.procesarRed.Click += new System.EventHandler(this.procesarRed_Click);
            // 
            // gpRed
            // 
            this.gpRed.Controls.Add(this.label2);
            this.gpRed.Controls.Add(this.cbROLES);
            this.gpRed.Controls.Add(this.regRed);
            this.gpRed.Controls.Add(this.pnlID);
            this.gpRed.Controls.Add(this.chkFiltro);
            this.gpRed.Controls.Add(this.cbID);
            this.gpRed.Location = new System.Drawing.Point(175, 28);
            this.gpRed.Name = "gpRed";
            this.gpRed.Size = new System.Drawing.Size(501, 112);
            this.gpRed.TabIndex = 29;
            this.gpRed.TabStop = false;
            this.gpRed.Text = "Filtros Datos de Red";
            this.gpRed.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "ROL";
            // 
            // cbROLES
            // 
            this.cbROLES.FormattingEnabled = true;
            this.cbROLES.Location = new System.Drawing.Point(41, 45);
            this.cbROLES.Name = "cbROLES";
            this.cbROLES.Size = new System.Drawing.Size(88, 21);
            this.cbROLES.TabIndex = 33;
            // 
            // regRed
            // 
            this.regRed.Location = new System.Drawing.Point(336, 80);
            this.regRed.Name = "regRed";
            this.regRed.Size = new System.Drawing.Size(147, 23);
            this.regRed.TabIndex = 30;
            this.regRed.Text = "Registros Desde Red";
            this.regRed.UseVisualStyleBackColor = true;
            this.regRed.Click += new System.EventHandler(this.regRed_Click);
            // 
            // pnlID
            // 
            this.pnlID.Controls.Add(this.label1);
            this.pnlID.Controls.Add(this.tbHASTA);
            this.pnlID.Controls.Add(this.Desde);
            this.pnlID.Controls.Add(this.tbDESDE);
            this.pnlID.Location = new System.Drawing.Point(283, 10);
            this.pnlID.Name = "pnlID";
            this.pnlID.Size = new System.Drawing.Size(200, 64);
            this.pnlID.TabIndex = 32;
            this.pnlID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "HASTA";
            // 
            // tbHASTA
            // 
            this.tbHASTA.Location = new System.Drawing.Point(83, 32);
            this.tbHASTA.Name = "tbHASTA";
            this.tbHASTA.Size = new System.Drawing.Size(60, 20);
            this.tbHASTA.TabIndex = 5;
            this.tbHASTA.Text = "0";
            this.tbHASTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Desde
            // 
            this.Desde.AutoSize = true;
            this.Desde.Location = new System.Drawing.Point(16, 9);
            this.Desde.Name = "Desde";
            this.Desde.Size = new System.Drawing.Size(44, 13);
            this.Desde.TabIndex = 4;
            this.Desde.Text = "DESDE";
            // 
            // tbDESDE
            // 
            this.tbDESDE.Location = new System.Drawing.Point(83, 6);
            this.tbDESDE.Name = "tbDESDE";
            this.tbDESDE.Size = new System.Drawing.Size(60, 20);
            this.tbDESDE.TabIndex = 3;
            this.tbDESDE.Text = "0";
            this.tbDESDE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkFiltro
            // 
            this.chkFiltro.AutoSize = true;
            this.chkFiltro.Checked = true;
            this.chkFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiltro.Location = new System.Drawing.Point(6, 19);
            this.chkFiltro.Name = "chkFiltro";
            this.chkFiltro.Size = new System.Drawing.Size(123, 17);
            this.chkFiltro.TabIndex = 30;
            this.chkFiltro.Text = "Solo No Procesados";
            this.chkFiltro.UseVisualStyleBackColor = true;
            // 
            // cbID
            // 
            this.cbID.AutoSize = true;
            this.cbID.Location = new System.Drawing.Point(168, 19);
            this.cbID.Name = "cbID";
            this.cbID.Size = new System.Drawing.Size(106, 17);
            this.cbID.TabIndex = 31;
            this.cbID.Text = "FILTRAR ID INT";
            this.cbID.UseVisualStyleBackColor = true;
            this.cbID.CheckedChanged += new System.EventHandler(this.cbID_CheckedChanged);
            // 
            // Procesar_Registros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 425);
            this.Controls.Add(this.gpRed);
            this.Controls.Add(this.procesarRed);
            this.Controls.Add(this.lbGrabar);
            this.Controls.Add(this.lbTextoProceso);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.Importar);
            this.Controls.Add(this.btnAbrirXLS);
            this.Controls.Add(this.lbArchivoXLS);
            this.Controls.Add(this.dgvIngresos);
            this.Name = "Procesar_Registros";
            this.Text = "Registros_Procesados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.gpRed.ResumeLayout(false);
            this.gpRed.PerformLayout();
            this.pnlID.ResumeLayout(false);
            this.pnlID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.Button btnAbrirXLS;
        private System.Windows.Forms.Label lbArchivoXLS;
        private System.Windows.Forms.Button Importar;
        private System.Windows.Forms.Button Grabar;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lbTextoProceso;
        private System.Windows.Forms.Label lbGrabar;
        private System.Windows.Forms.Button procesarRed;
        private System.Windows.Forms.GroupBox gpRed;
        private System.Windows.Forms.Button regRed;
        private System.Windows.Forms.Panel pnlID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHASTA;
        private System.Windows.Forms.Label Desde;
        private System.Windows.Forms.TextBox tbDESDE;
        private System.Windows.Forms.CheckBox chkFiltro;
        private System.Windows.Forms.CheckBox cbID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbROLES;
    }
}