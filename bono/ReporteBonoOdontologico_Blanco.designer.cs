namespace SOCIOS.bono
{
    partial class ReporteBonoOdontologico_Blanco
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Print = new System.Windows.Forms.Button();
            this.cbOrden = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Refrescar = new System.Windows.Forms.Button();
            this.TratamientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imprimir_Todo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TratamientoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TratamientoBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SOCIOS.bono.BonoOdontologico_Blanco.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 31);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(740, 492);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.Load += new System.EventHandler(this.reportViewer_Load);
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
            // cbOrden
            // 
            this.cbOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrden.FormattingEnabled = true;
            this.cbOrden.Items.AddRange(new object[] {
            "ORIGINAL",
            "DUPLICADO",
            "TRIPLICADO"});
            this.cbOrden.Location = new System.Drawing.Point(64, 4);
            this.cbOrden.Name = "cbOrden";
            this.cbOrden.Size = new System.Drawing.Size(175, 21);
            this.cbOrden.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "ORDEN";
            // 
            // Refrescar
            // 
            this.Refrescar.Location = new System.Drawing.Point(265, 2);
            this.Refrescar.Name = "Refrescar";
            this.Refrescar.Size = new System.Drawing.Size(75, 23);
            this.Refrescar.TabIndex = 91;
            this.Refrescar.Text = "Refrescar";
            this.Refrescar.UseVisualStyleBackColor = true;
            this.Refrescar.Click += new System.EventHandler(this.Refrescar_Click);
            // 
            // TratamientoBindingSource
            // 
            this.TratamientoBindingSource.DataSource = typeof(SOCIOS.bono.Tratamiento);
            // 
            // imprimir_Todo
            // 
            this.imprimir_Todo.Location = new System.Drawing.Point(567, 529);
            this.imprimir_Todo.Name = "imprimir_Todo";
            this.imprimir_Todo.Size = new System.Drawing.Size(185, 23);
            this.imprimir_Todo.TabIndex = 92;
            this.imprimir_Todo.Text = "Imprimir Directo O,D,T";
            this.imprimir_Todo.UseVisualStyleBackColor = true;
            this.imprimir_Todo.Click += new System.EventHandler(this.imprimir_Todo_Click);
            // 
            // ReporteBonoOdontologico_Blanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 564);
            this.Controls.Add(this.imprimir_Todo);
            this.Controls.Add(this.Refrescar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOrden);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.reportViewer);
            this.Name = "ReporteBonoOdontologico_Blanco";
            this.Text = "ReporteBonoOdontologico";
            this.Load += new System.EventHandler(this.ReporteBonoOdontologico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TratamientoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource TratamientoBindingSource;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.ComboBox cbOrden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Refrescar;
        private System.Windows.Forms.Button imprimir_Todo;
    }
}