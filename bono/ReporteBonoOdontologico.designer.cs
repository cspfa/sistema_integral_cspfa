namespace SOCIOS.bono
{
    partial class ReporteBonoOdontologico
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
            this.TratamientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TratamientoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TratamientoBindingSource
            // 
            this.TratamientoBindingSource.DataSource = typeof(SOCIOS.bono.Tratamiento);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TratamientoBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SOCIOS.bono.BonoOdontologico.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 12);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(740, 515);
            this.reportViewer.TabIndex = 0;
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(12, 529);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(75, 23);
            this.Print.TabIndex = 1;
            this.Print.Text = "Imprimir";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // ReporteBonoOdontologico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 564);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.reportViewer);
            this.Name = "ReporteBonoOdontologico";
            this.Text = "ReporteBonoOdontologico";
            this.Load += new System.EventHandler(this.ReporteBonoOdontologico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TratamientoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource TratamientoBindingSource;
        private System.Windows.Forms.Button Print;
    }
}