namespace SOCIOS.deportes
{
    partial class ReporteAsistencia
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
            this.cbActividad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaApto = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Reporte = new System.Windows.Forms.Button();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.lbRol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbActividad
            // 
            this.cbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActividad.FormattingEnabled = true;
            this.cbActividad.Location = new System.Drawing.Point(92, 53);
            this.cbActividad.Name = "cbActividad";
            this.cbActividad.Size = new System.Drawing.Size(373, 21);
            this.cbActividad.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "FECHA:";
            // 
            // FechaApto
            // 
            this.FechaApto.AutoSize = true;
            this.FechaApto.Location = new System.Drawing.Point(12, 61);
            this.FechaApto.Name = "FechaApto";
            this.FechaApto.Size = new System.Drawing.Size(67, 13);
            this.FechaApto.TabIndex = 76;
            this.FechaApto.Text = "ACTIVIDAD:";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(92, 82);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(85, 20);
            this.dpFecha.TabIndex = 78;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SOCIOS.deportes.Asistencias.ReporteAsistencia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 124);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(725, 324);
            this.reportViewer1.TabIndex = 79;
            this.reportViewer1.Visible = false;
            // 
            // Reporte
            // 
            this.Reporte.Location = new System.Drawing.Point(535, 26);
            this.Reporte.Name = "Reporte";
            this.Reporte.Size = new System.Drawing.Size(75, 23);
            this.Reporte.TabIndex = 80;
            this.Reporte.Text = "Reporte";
            this.Reporte.UseVisualStyleBackColor = true;
            this.Reporte.Click += new System.EventHandler(this.Reporte_Click);
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(92, 23);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(125, 21);
            this.cbRol.TabIndex = 92;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(12, 26);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(32, 13);
            this.lbRol.TabIndex = 93;
            this.lbRol.Text = "ROL:";
            // 
            // ReporteAsistencia
            // 
            this.AutoDeleteMessage = "Business_AutoDeleteMessage";
            this.AutoDeleteTitle = "Business_AutoDeleteTitle";
            this.AutoSaveChangesMessage = "Business_AutoSaveChangesMessage";
            this.AutoSaveChangesTitle = "Business_AutoSaveChangesTitle";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BrokenRulesAlertText = "Business_BrokenRulesAlertText";
            this.BrokenRulesAlertTextAdditionalRows = "Business_BrokenRulesAlertTextAdditionalRows";
            this.BrokenRulesAlertTitle = "Business_BrokenRulesAlertTitle";
            this.ClientSize = new System.Drawing.Size(752, 451);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.lbRol);
            this.Controls.Add(this.Reporte);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cbActividad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FechaApto);
            this.Controls.Add(this.dpFecha);
            this.ErrorProviderBlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.ErrorProviderIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;
            this.ErrorProviderRequiredFieldDesc = "Business_ErrorProviderRequiredFieldDesc";
            this.Name = "ReporteAsistencia";
            this.Text = "Deportes - Reporte de Asistencia";
            this.Load += new System.EventHandler(this.ReporteAsistencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbActividad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FechaApto;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button Reporte;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label lbRol;

    }
}

