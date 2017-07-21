namespace SOCIOS.Entrada_Campo
{
    partial class ReporteIngresosCampo
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
            this.ReporteEntradaCampoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DisponibilidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteEntradaCampoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisponibilidadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReporteEntradaCampoBindingSource
            // 
            this.ReporteEntradaCampoBindingSource.DataSource = typeof(Reportes.ReporteEntradaCampo);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetReporte";
            reportDataSource1.Value = this.ReporteEntradaCampoBindingSource;
            reportDataSource2.Name = "DataSetReintegros";
            reportDataSource2.Value = this.ReporteEntradaCampoBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SOCIOS.entradaCampo.Reporte.ReporteIngresosCampo.rdlc";
            this.reportViewer.LocalReport.ReportPath = "ReporteEntradaCampo.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(-8, 24);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(867, 391);
            this.reportViewer.TabIndex = 0;
            // 
            // DisponibilidadBindingSource
            // 
            this.DisponibilidadBindingSource.DataSource = typeof(SOCIOS.Turismo.Hotel.Disponibilidad);
            // 
            // ReporteIngresosCampo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 427);
            this.Controls.Add(this.reportViewer);
            this.Name = "ReporteIngresosCampo";
            this.Text = "INGRESOS CAMPO";
            this.Load += new System.EventHandler(this.ReporteIngresosCampo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteEntradaCampoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisponibilidadBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource ReporteEntradaCampoBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource DisponibilidadBindingSource;
    }
}