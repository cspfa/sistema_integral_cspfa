namespace SOCIOS.Turismo.Solicitudes
{
    partial class Personas_Solicitud
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
            this.dgSolicitud = new System.Windows.Forms.DataGridView();
            this.lbHabitacion = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSolicitud)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSolicitud
            // 
            this.dgSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSolicitud.Location = new System.Drawing.Point(12, 42);
            this.dgSolicitud.Name = "dgSolicitud";
            this.dgSolicitud.Size = new System.Drawing.Size(381, 150);
            this.dgSolicitud.TabIndex = 0;
            // 
            // lbHabitacion
            // 
            this.lbHabitacion.AutoSize = true;
            this.lbHabitacion.Location = new System.Drawing.Point(15, 9);
            this.lbHabitacion.Name = "lbHabitacion";
            this.lbHabitacion.Size = new System.Drawing.Size(72, 13);
            this.lbHabitacion.TabIndex = 1;
            this.lbHabitacion.Text = "HABITACION";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(337, 9);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(42, 13);
            this.lbFecha.TabIndex = 2;
            this.lbFecha.Text = "FECHA";
            // 
            // Personas_Solicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 204);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.lbHabitacion);
            this.Controls.Add(this.dgSolicitud);
            this.Name = "Personas_Solicitud";
            this.Text = "Personas Solicitud";
            ((System.ComponentModel.ISupportInitialize)(this.dgSolicitud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSolicitud;
        private System.Windows.Forms.Label lbHabitacion;
        private System.Windows.Forms.Label lbFecha;
    }
}