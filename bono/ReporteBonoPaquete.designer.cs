namespace SOCIOS.bono
{
    partial class ReporteBonoPaquete
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PasajeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PersonaPasajeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PasajeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonaPasajeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PasajeBindingSource
            // 
            this.PasajeBindingSource.DataSource = typeof(SOCIOS.bono.Pasaje);
            // 
            // PersonaPasajeBindingSource
            // 
            this.PersonaPasajeBindingSource.DataSource = typeof(SOCIOS.bono.PersonaPasaje);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetPasaje";
            reportDataSource1.Value = this.PasajeBindingSource;
            reportDataSource2.Name = "DataSetPersonaPasaje";
            reportDataSource2.Value = this.PersonaPasajeBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SOCIOS.bono.BonoPaquete.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(22, 12);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(801, 594);
            this.reportViewer.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(22, 612);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // ReporteBonoPaquete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 647);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.reportViewer);
            this.Name = "ReporteBonoPaquete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteBonoPaquete";
            this.Load += new System.EventHandler(this.ReporteBonoPaquete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PasajeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonaPasajeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource PasajeBindingSource;
        private System.Windows.Forms.BindingSource PersonaPasajeBindingSource;
        private System.Windows.Forms.Button btnImprimir;
    }
}