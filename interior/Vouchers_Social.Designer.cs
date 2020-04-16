namespace SOCIOS.interior
{
    partial class Vouchers_Social
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.dgcDatos = new System.Windows.Forms.DataGridView();
            this.Anular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgcDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "HASTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "DESDE";
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(243, 5);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(88, 20);
            this.dpHasta.TabIndex = 82;
            // 
            // dpDesde
            // 
            this.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDesde.Location = new System.Drawing.Point(63, 5);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(88, 20);
            this.dpDesde.TabIndex = 81;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(576, 6);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(95, 23);
            this.btnFiltro.TabIndex = 89;
            this.btnFiltro.Text = "BUSCAR";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // dgcDatos
            // 
            this.dgcDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcDatos.Location = new System.Drawing.Point(15, 35);
            this.dgcDatos.Name = "dgcDatos";
            this.dgcDatos.Size = new System.Drawing.Size(642, 256);
            this.dgcDatos.TabIndex = 90;
            // 
            // Anular
            // 
            this.Anular.Location = new System.Drawing.Point(576, 297);
            this.Anular.Name = "Anular";
            this.Anular.Size = new System.Drawing.Size(81, 23);
            this.Anular.TabIndex = 91;
            this.Anular.Text = "Anular";
            this.Anular.UseVisualStyleBackColor = true;
            // 
            // Vouchers_Social
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 330);
            this.Controls.Add(this.Anular);
            this.Controls.Add(this.dgcDatos);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpHasta);
            this.Controls.Add(this.dpDesde);
            this.Name = "Vouchers_Social";
            this.Text = "Vouchers_Social";
            ((System.ComponentModel.ISupportInitialize)(this.dgcDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.DataGridView dgcDatos;
        private System.Windows.Forms.Button Anular;
    }
}