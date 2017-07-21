namespace SOCIOS.Bienestar
{
    partial class DatosBienestar
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
            this.DataBienestar = new System.Windows.Forms.DataGridView();
            this.Importar = new System.Windows.Forms.Button();
            this.btnAbrirXLS = new System.Windows.Forms.Button();
            this.lbArchivoXLS = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbTextoProceso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataBienestar)).BeginInit();
            this.SuspendLayout();
            // 
            // DataBienestar
            // 
            this.DataBienestar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBienestar.Location = new System.Drawing.Point(12, 102);
            this.DataBienestar.Name = "DataBienestar";
            this.DataBienestar.Size = new System.Drawing.Size(847, 237);
            this.DataBienestar.TabIndex = 0;
            // 
            // Importar
            // 
            this.Importar.Location = new System.Drawing.Point(12, 41);
            this.Importar.Name = "Importar";
            this.Importar.Size = new System.Drawing.Size(93, 23);
            this.Importar.TabIndex = 22;
            this.Importar.Text = "IMPORTAR";
            this.Importar.UseVisualStyleBackColor = true;
            this.Importar.Click += new System.EventHandler(this.Importar_Click);
            // 
            // btnAbrirXLS
            // 
            this.btnAbrirXLS.Location = new System.Drawing.Point(12, 12);
            this.btnAbrirXLS.Name = "btnAbrirXLS";
            this.btnAbrirXLS.Size = new System.Drawing.Size(93, 23);
            this.btnAbrirXLS.TabIndex = 21;
            this.btnAbrirXLS.Text = "ABRIR XLS";
            this.btnAbrirXLS.UseVisualStyleBackColor = true;
            this.btnAbrirXLS.Click += new System.EventHandler(this.btnAbrirXLS_Click);
            // 
            // lbArchivoXLS
            // 
            this.lbArchivoXLS.AutoSize = true;
            this.lbArchivoXLS.Location = new System.Drawing.Point(144, 17);
            this.lbArchivoXLS.Name = "lbArchivoXLS";
            this.lbArchivoXLS.Size = new System.Drawing.Size(198, 13);
            this.lbArchivoXLS.TabIndex = 20;
            this.lbArchivoXLS.Text = "ARCHIVO SELECCIONADO: NINGUNO";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(147, 41);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(159, 23);
            this.progressBar.TabIndex = 23;
            // 
            // lbTextoProceso
            // 
            this.lbTextoProceso.AutoSize = true;
            this.lbTextoProceso.Location = new System.Drawing.Point(348, 17);
            this.lbTextoProceso.Name = "lbTextoProceso";
            this.lbTextoProceso.Size = new System.Drawing.Size(135, 13);
            this.lbTextoProceso.TabIndex = 24;
            this.lbTextoProceso.Text = "-LISTO PARA PROCESAR";
            // 
            // DatosBienestar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 388);
            this.Controls.Add(this.lbTextoProceso);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Importar);
            this.Controls.Add(this.btnAbrirXLS);
            this.Controls.Add(this.lbArchivoXLS);
            this.Controls.Add(this.DataBienestar);
            this.Name = "DatosBienestar";
            this.Text = "DatosBienestar";
            ((System.ComponentModel.ISupportInitialize)(this.DataBienestar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataBienestar;
        private System.Windows.Forms.Button Importar;
        private System.Windows.Forms.Button btnAbrirXLS;
        private System.Windows.Forms.Label lbArchivoXLS;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbTextoProceso;
    }
}