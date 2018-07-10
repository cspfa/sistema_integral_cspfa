namespace SOCIOS.Turismo
{
    partial class Stats_Hoteles
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
            this.Desde = new System.Windows.Forms.DateTimePicker();
            this.Hasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GrillaDatos = new System.Windows.Forms.DataGridView();
            this.Filtrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // Desde
            // 
            this.Desde.Location = new System.Drawing.Point(63, 12);
            this.Desde.Name = "Desde";
            this.Desde.Size = new System.Drawing.Size(200, 20);
            this.Desde.TabIndex = 0;
            // 
            // Hasta
            // 
            this.Hasta.Location = new System.Drawing.Point(340, 11);
            this.Hasta.Name = "Hasta";
            this.Hasta.Size = new System.Drawing.Size(200, 20);
            this.Hasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DESDE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "HASTA";
            // 
            // GrillaDatos
            // 
            this.GrillaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaDatos.Location = new System.Drawing.Point(16, 61);
            this.GrillaDatos.Name = "GrillaDatos";
            this.GrillaDatos.Size = new System.Drawing.Size(521, 276);
            this.GrillaDatos.TabIndex = 4;
            // 
            // Filtrar
            // 
            this.Filtrar.Location = new System.Drawing.Point(465, 32);
            this.Filtrar.Name = "Filtrar";
            this.Filtrar.Size = new System.Drawing.Size(75, 23);
            this.Filtrar.TabIndex = 5;
            this.Filtrar.Text = "Filtrar";
            this.Filtrar.UseVisualStyleBackColor = true;
            this.Filtrar.Click += new System.EventHandler(this.Filtrar_Click);
            // 
            // Stats_Hoteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 384);
            this.Controls.Add(this.Filtrar);
            this.Controls.Add(this.GrillaDatos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hasta);
            this.Controls.Add(this.Desde);
            this.Name = "Stats_Hoteles";
            this.Text = "Stats_Hoteles";
            ((System.ComponentModel.ISupportInitialize)(this.GrillaDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Desde;
        private System.Windows.Forms.DateTimePicker Hasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GrillaDatos;
        private System.Windows.Forms.Button Filtrar;
    }
}