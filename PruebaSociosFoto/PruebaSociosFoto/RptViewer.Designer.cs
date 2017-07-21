namespace SOCIOS
{
    partial class RptViewer
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            
                this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                this.SuspendLayout();
                // 
                // crystalReportViewer1
                // 
                this.crystalReportViewer1.ActiveViewIndex = -1;
                this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
                this.crystalReportViewer1.Name = "crystalReportViewer1";
                this.crystalReportViewer1.SelectionFormula = "";
                this.crystalReportViewer1.ShowGroupTreeButton = false;
                this.crystalReportViewer1.ShowRefreshButton = false;
                this.crystalReportViewer1.Size = new System.Drawing.Size(744, 555);
                this.crystalReportViewer1.TabIndex = 0;
                this.crystalReportViewer1.ViewTimeSelectionFormula = "";
                this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer_Load);
                // 
                // RptViewer
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(744, 555);
                this.Controls.Add(this.crystalReportViewer1);
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "RptViewer";
                this.ShowIcon = false;
                this.Text = "DATOS SOCIO TITULAR-FAMILIAR-ADHERENTE";
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);
            
        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}

