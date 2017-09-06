namespace SOCIOS.deportes.Asistencia
{
    partial class VerificacionAsistencia
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
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.lbRol = new System.Windows.Forms.Label();
            this.Reporte = new System.Windows.Forms.Button();
            this.cbActividad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaApto = new System.Windows.Forms.Label();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dpFEchaHasta = new System.Windows.Forms.DateTimePicker();
            this.label89 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(92, 6);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(125, 21);
            this.cbRol.TabIndex = 99;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(12, 9);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(32, 13);
            this.lbRol.TabIndex = 100;
            this.lbRol.Text = "ROL:";
            // 
            // Reporte
            // 
            this.Reporte.Location = new System.Drawing.Point(535, 9);
            this.Reporte.Name = "Reporte";
            this.Reporte.Size = new System.Drawing.Size(75, 23);
            this.Reporte.TabIndex = 98;
            this.Reporte.Text = "Reporte";
            this.Reporte.UseVisualStyleBackColor = true;
            this.Reporte.Click += new System.EventHandler(this.Reporte_Click);
            // 
            // cbActividad
            // 
            this.cbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActividad.FormattingEnabled = true;
            this.cbActividad.Location = new System.Drawing.Point(92, 36);
            this.cbActividad.Name = "cbActividad";
            this.cbActividad.Size = new System.Drawing.Size(373, 21);
            this.cbActividad.TabIndex = 94;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "DESDE:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FechaApto
            // 
            this.FechaApto.AutoSize = true;
            this.FechaApto.Location = new System.Drawing.Point(12, 44);
            this.FechaApto.Name = "FechaApto";
            this.FechaApto.Size = new System.Drawing.Size(67, 13);
            this.FechaApto.TabIndex = 95;
            this.FechaApto.Text = "ACTIVIDAD:";
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(92, 59);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(85, 20);
            this.dpFechaDesde.TabIndex = 97;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SOCIOS.deportes.Asistencia.VerificacionAsistencia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 91);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(683, 246);
            this.reportViewer1.TabIndex = 101;
            // 
            // dpFEchaHasta
            // 
            this.dpFEchaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFEchaHasta.Location = new System.Drawing.Point(236, 59);
            this.dpFEchaHasta.Name = "dpFEchaHasta";
            this.dpFEchaHasta.Size = new System.Drawing.Size(85, 20);
            this.dpFEchaHasta.TabIndex = 102;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(183, 65);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(43, 13);
            this.label89.TabIndex = 103;
            this.label89.Text = "HASTA";
            // 
            // VerificacionAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 345);
            this.Controls.Add(this.label89);
            this.Controls.Add(this.dpFEchaHasta);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.lbRol);
            this.Controls.Add(this.Reporte);
            this.Controls.Add(this.cbActividad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FechaApto);
            this.Controls.Add(this.dpFechaDesde);
            this.Name = "VerificacionAsistencia";
            this.Text = "VerificacionAsistencia";
            this.Load += new System.EventHandler(this.VerificacionAsistencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label lbRol;
        private System.Windows.Forms.Button Reporte;
        private System.Windows.Forms.ComboBox cbActividad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FechaApto;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dpFEchaHasta;
        private System.Windows.Forms.Label label89;
    }
}