namespace SOCIOS.bono
{
    partial class ReporteBonoHotel
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PersonaPasajeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.Voucher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PersonaPasajeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PersonaPasajeBindingSource
            // 
            this.PersonaPasajeBindingSource.DataSource = typeof(SOCIOS.bono.PersonaPasaje);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetPersonaPasaje";
            reportDataSource1.Value = this.PersonaPasajeBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SOCIOS.bono.BonoHotel.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(5, 47);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(801, 530);
            this.reportViewer.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(560, 12);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(109, 23);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "IMPRIMIR BONO";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Voucher
            // 
            this.Voucher.Location = new System.Drawing.Point(675, 12);
            this.Voucher.Name = "Voucher";
            this.Voucher.Size = new System.Drawing.Size(131, 23);
            this.Voucher.TabIndex = 3;
            this.Voucher.Text = "IMPRIMIR VOUCHER";
            this.Voucher.UseVisualStyleBackColor = true;
            this.Voucher.Click += new System.EventHandler(this.Voucher_Click);
            // 
            // ReporteBonoHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 617);
            this.Controls.Add(this.Voucher);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.reportViewer);
            this.Name = "ReporteBonoHotel";
            this.Text = "ReporteBonoHotel";
            this.Load += new System.EventHandler(this.ReporteBonoHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PersonaPasajeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.BindingSource PersonaPasajeBindingSource;
        private System.Windows.Forms.Button Voucher;
    }
}