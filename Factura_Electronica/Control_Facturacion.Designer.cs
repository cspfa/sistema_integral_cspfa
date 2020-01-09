namespace SOCIOS.Factura_Electronica
{
    partial class Control_Facturacion
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
            this.tbDesde = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ComboPtoVenta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHasta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRecibos = new System.Windows.Forms.DataGridView();
            this.btnConsulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDesde
            // 
            this.tbDesde.Location = new System.Drawing.Point(323, 3);
            this.tbDesde.Name = "tbDesde";
            this.tbDesde.Size = new System.Drawing.Size(115, 20);
            this.tbDesde.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(273, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 91;
            this.label12.Text = "DESDE";
            // 
            // ComboPtoVenta
            // 
            this.ComboPtoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboPtoVenta.FormattingEnabled = true;
            this.ComboPtoVenta.Location = new System.Drawing.Point(142, 1);
            this.ComboPtoVenta.Name = "ComboPtoVenta";
            this.ComboPtoVenta.Size = new System.Drawing.Size(115, 21);
            this.ComboPtoVenta.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "PUNTO_DE_VENTA";
            // 
            // tbHasta
            // 
            this.tbHasta.Location = new System.Drawing.Point(497, 3);
            this.tbHasta.Name = "tbHasta";
            this.tbHasta.Size = new System.Drawing.Size(115, 20);
            this.tbHasta.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "HASTA";
            // 
            // dgvRecibos
            // 
            this.dgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecibos.Location = new System.Drawing.Point(12, 28);
            this.dgvRecibos.Name = "dgvRecibos";
            this.dgvRecibos.Size = new System.Drawing.Size(804, 379);
            this.dgvRecibos.TabIndex = 95;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(627, 3);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnConsulta.TabIndex = 96;
            this.btnConsulta.Text = "Consultar";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // Control_Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 419);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.dgvRecibos);
            this.Controls.Add(this.tbHasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDesde);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ComboPtoVenta);
            this.Controls.Add(this.label3);
            this.Name = "Control_Facturacion";
            this.Text = "Control_Facturacion";
            this.Load += new System.EventHandler(this.Control_Facturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDesde;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ComboPtoVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRecibos;
        private System.Windows.Forms.Button btnConsulta;
    }
}