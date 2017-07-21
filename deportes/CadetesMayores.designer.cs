namespace SOCIOS.deportes
{
    partial class CadetesMayores
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
            this.GrillaDatos = new System.Windows.Forms.DataGridView();
            this.Procesar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // GrillaDatos
            // 
            this.GrillaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDatos.Location = new System.Drawing.Point(12, 45);
            this.GrillaDatos.Name = "GrillaDatos";
            this.GrillaDatos.Size = new System.Drawing.Size(697, 241);
            this.GrillaDatos.TabIndex = 0;
            // 
            // Procesar
            // 
            this.Procesar.Location = new System.Drawing.Point(12, 312);
            this.Procesar.Name = "Procesar";
            this.Procesar.Size = new System.Drawing.Size(191, 23);
            this.Procesar.TabIndex = 1;
            this.Procesar.Text = "Procesar y Dar de Baja";
            this.Procesar.UseVisualStyleBackColor = true;
            this.Procesar.Click += new System.EventHandler(this.Procesar_Click);
            // 
            // CadetesMayores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 377);
            this.Controls.Add(this.Procesar);
            this.Controls.Add(this.GrillaDatos);
            this.Name = "CadetesMayores";
            this.Text = "Cadetes Mayores";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GrillaDatos;
        private System.Windows.Forms.Button Procesar;
    }
}