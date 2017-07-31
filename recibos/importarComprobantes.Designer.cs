namespace SOCIOS
{
    partial class importarComprobantes
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
            this.lbConexion = new System.Windows.Forms.Label();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbConexion
            // 
            this.lbConexion.AutoSize = true;
            this.lbConexion.Location = new System.Drawing.Point(16, 16);
            this.lbConexion.Name = "lbConexion";
            this.lbConexion.Size = new System.Drawing.Size(270, 13);
            this.lbConexion.TabIndex = 0;
            this.lbConexion.Text = "CONEXIÓN CON LA BASE DE DATOS: Desconectada";
            // 
            // lbCantidad
            // 
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Location = new System.Drawing.Point(16, 39);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(255, 13);
            this.lbCantidad.TabIndex = 1;
            this.lbCantidad.Text = "CANTIDAD DE COMPROBANTES A IMPORTAR: 0";
            // 
            // importarComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 273);
            this.Controls.Add(this.lbCantidad);
            this.Controls.Add(this.lbConexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "importarComprobantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.importarComprobantes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbConexion;
        private System.Windows.Forms.Label lbCantidad;
    }
}