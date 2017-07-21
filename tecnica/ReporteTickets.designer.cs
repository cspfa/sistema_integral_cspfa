namespace SOCIOS.Tecnica
{
    partial class ReporteTickets
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
            this.TicketReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TicketReporteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TicketReporteBindingSource
            // 
            this.TicketReporteBindingSource.DataSource = typeof(SOCIOS.Tecnica.TicketReporte);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TicketReporteBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SOCIOS.tecnica.repoTickets.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 27);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(1050, 439);
            this.reportViewer.TabIndex = 0;
            // 
            // ReporteTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 499);
            this.Controls.Add(this.reportViewer);
            this.Name = "ReporteTickets";
            this.Text = "ReporteTickets";
            this.Load += new System.EventHandler(this.ReporteTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TicketReporteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource TicketReporteBindingSource;
    }
}