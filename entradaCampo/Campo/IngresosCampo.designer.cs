namespace SOCIOS.Entrada_Campo
{
    partial class IngresosCampo
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
            this.chkFiltro = new System.Windows.Forms.CheckBox();
            this.XLS = new System.Windows.Forms.Button();
            this.tbDESDE = new System.Windows.Forms.TextBox();
            this.cbID = new System.Windows.Forms.CheckBox();
            this.pnlID = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHASTA = new System.Windows.Forms.TextBox();
            this.Desde = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            this.pnlID.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Location = new System.Drawing.Point(11, 82);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.Size = new System.Drawing.Size(871, 375);
            this.dgvIngresos.TabIndex = 0;
            // 
            // chkFiltro
            // 
            this.chkFiltro.AutoSize = true;
            this.chkFiltro.Checked = true;
            this.chkFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiltro.Location = new System.Drawing.Point(12, 12);
            this.chkFiltro.Name = "chkFiltro";
            this.chkFiltro.Size = new System.Drawing.Size(123, 17);
            this.chkFiltro.TabIndex = 1;
            this.chkFiltro.Text = "Solo No Procesados";
            this.chkFiltro.UseVisualStyleBackColor = true;
            this.chkFiltro.CheckedChanged += new System.EventHandler(this.chkFiltro_CheckedChanged);
            // 
            // XLS
            // 
            this.XLS.Location = new System.Drawing.Point(289, 463);
            this.XLS.Name = "XLS";
            this.XLS.Size = new System.Drawing.Size(285, 34);
            this.XLS.TabIndex = 2;
            this.XLS.Text = "Procesar y Generar Archivo";
            this.XLS.UseVisualStyleBackColor = true;
            this.XLS.Click += new System.EventHandler(this.XLS_Click);
            // 
            // tbDESDE
            // 
            this.tbDESDE.Location = new System.Drawing.Point(83, 6);
            this.tbDESDE.Name = "tbDESDE";
            this.tbDESDE.Size = new System.Drawing.Size(27, 20);
            this.tbDESDE.TabIndex = 3;
            this.tbDESDE.Text = "0";
            // 
            // cbID
            // 
            this.cbID.AutoSize = true;
            this.cbID.Location = new System.Drawing.Point(174, 12);
            this.cbID.Name = "cbID";
            this.cbID.Size = new System.Drawing.Size(106, 17);
            this.cbID.TabIndex = 4;
            this.cbID.Text = "FILTRAR ID INT";
            this.cbID.UseVisualStyleBackColor = true;
            this.cbID.CheckedChanged += new System.EventHandler(this.cbID_CheckedChanged);
            // 
            // pnlID
            // 
            this.pnlID.Controls.Add(this.label1);
            this.pnlID.Controls.Add(this.tbHASTA);
            this.pnlID.Controls.Add(this.Desde);
            this.pnlID.Controls.Add(this.tbDESDE);
            this.pnlID.Location = new System.Drawing.Point(289, 3);
            this.pnlID.Name = "pnlID";
            this.pnlID.Size = new System.Drawing.Size(200, 64);
            this.pnlID.TabIndex = 5;
            this.pnlID.Visible = false;
            this.pnlID.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlID_Paint);
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
            this.tbHASTA.Size = new System.Drawing.Size(27, 20);
            this.tbHASTA.TabIndex = 5;
            this.tbHASTA.Text = "0";
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
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(577, 6);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnFiltro.TabIndex = 6;
            this.btnFiltro.Text = "SELECCIONAR";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // IngresosCampo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(894, 498);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.pnlID);
            this.Controls.Add(this.cbID);
            this.Controls.Add(this.XLS);
            this.Controls.Add(this.chkFiltro);
            this.Controls.Add(this.dgvIngresos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IngresosCampo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngresosCampo";
            this.Load += new System.EventHandler(this.IngresosCampo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.pnlID.ResumeLayout(false);
            this.pnlID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.CheckBox chkFiltro;
        private System.Windows.Forms.Button XLS;
        private System.Windows.Forms.TextBox tbDESDE;
        private System.Windows.Forms.CheckBox cbID;
        private System.Windows.Forms.Panel pnlID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHASTA;
        private System.Windows.Forms.Label Desde;
        private System.Windows.Forms.Button btnFiltro;
    }
}