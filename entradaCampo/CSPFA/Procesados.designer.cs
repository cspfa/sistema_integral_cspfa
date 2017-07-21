namespace SOCIOS.Entrada_Campo.CSPFA
{
    partial class Procesados
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
            this.dgvProcesados = new System.Windows.Forms.DataGridView();
            this.cbROL = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProcesados
            // 
            this.dgvProcesados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesados.Location = new System.Drawing.Point(12, 48);
            this.dgvProcesados.Name = "dgvProcesados";
            this.dgvProcesados.Size = new System.Drawing.Size(1026, 406);
            this.dgvProcesados.TabIndex = 0;
            // 
            // cbROL
            // 
            this.cbROL.FormattingEnabled = true;
            this.cbROL.Items.AddRange(new object[] {
            "CPOCABA",
            "CPORANELAGH",
            "CPOPOLVORINES"});
            this.cbROL.Location = new System.Drawing.Point(742, 12);
            this.cbROL.Name = "cbROL";
            this.cbROL.Size = new System.Drawing.Size(215, 21);
            this.cbROL.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(963, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // Procesados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 502);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cbROL);
            this.Controls.Add(this.dgvProcesados);
            this.Name = "Procesados";
            this.Text = "Procesados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesados;
        private System.Windows.Forms.ComboBox cbROL;
        private System.Windows.Forms.Button btnFiltrar;
    }
}