namespace SOCIOS.Factura_Electronica
{
    partial class Consulta_Facturacion
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
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DGV_FACTURAS = new System.Windows.Forms.DataGridView();
            this.Consulta = new System.Windows.Forms.Button();
            this.ComboPtoVenta = new System.Windows.Forms.ComboBox();
            this.btnConsultaUnitaria = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FACTURAS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpDesde
            // 
            this.dpDesde.Location = new System.Drawing.Point(77, 12);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(200, 20);
            this.dpDesde.TabIndex = 0;
            // 
            // dpHasta
            // 
            this.dpHasta.Location = new System.Drawing.Point(357, 11);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(200, 20);
            this.dpHasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DESDE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "HASTA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "PUNTO_DE_VENTA";
            // 
            // DGV_FACTURAS
            // 
            this.DGV_FACTURAS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_FACTURAS.Location = new System.Drawing.Point(16, 68);
            this.DGV_FACTURAS.Name = "DGV_FACTURAS";
            this.DGV_FACTURAS.Size = new System.Drawing.Size(805, 310);
            this.DGV_FACTURAS.TabIndex = 6;
            // 
            // Consulta
            // 
            this.Consulta.Location = new System.Drawing.Point(416, 35);
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(141, 23);
            this.Consulta.TabIndex = 7;
            this.Consulta.Text = "CONSULTA x FECHA";
            this.Consulta.UseVisualStyleBackColor = true;
            this.Consulta.Click += new System.EventHandler(this.Consulta_Click);
            // 
            // ComboPtoVenta
            // 
            this.ComboPtoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboPtoVenta.FormattingEnabled = true;
            this.ComboPtoVenta.Location = new System.Drawing.Point(162, 45);
            this.ComboPtoVenta.Name = "ComboPtoVenta";
            this.ComboPtoVenta.Size = new System.Drawing.Size(115, 21);
            this.ComboPtoVenta.TabIndex = 84;
            // 
            // btnConsultaUnitaria
            // 
            this.btnConsultaUnitaria.Location = new System.Drawing.Point(6, 24);
            this.btnConsultaUnitaria.Name = "btnConsultaUnitaria";
            this.btnConsultaUnitaria.Size = new System.Drawing.Size(141, 23);
            this.btnConsultaUnitaria.TabIndex = 85;
            this.btnConsultaUnitaria.Text = "CONSULTA UNITARIA";
            this.btnConsultaUnitaria.UseVisualStyleBackColor = true;
            this.btnConsultaUnitaria.Click += new System.EventHandler(this.btnConsultaUnitaria_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConsultaUnitaria);
            this.groupBox1.Location = new System.Drawing.Point(656, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 55);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta por Numero";
            // 
            // Consulta_Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 390);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ComboPtoVenta);
            this.Controls.Add(this.Consulta);
            this.Controls.Add(this.DGV_FACTURAS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpHasta);
            this.Controls.Add(this.dpDesde);
            this.Name = "Consulta_Facturacion";
            this.Text = "CONSULTA INFO EN AFIP";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FACTURAS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGV_FACTURAS;
        private System.Windows.Forms.Button Consulta;
        private System.Windows.Forms.ComboBox ComboPtoVenta;
        private System.Windows.Forms.Button btnConsultaUnitaria;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}