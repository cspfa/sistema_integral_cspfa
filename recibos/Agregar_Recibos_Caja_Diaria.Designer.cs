namespace SOCIOS
{
    partial class Agregar_Recibos_Caja_Diaria
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
            this.tbCantidad = new System.Windows.Forms.Label();
            this.cbCaja = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Procesar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbCantidad
            // 
            this.tbCantidad.AutoSize = true;
            this.tbCantidad.Location = new System.Drawing.Point(12, 9);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(58, 13);
            this.tbCantidad.TabIndex = 0;
            this.tbCantidad.Text = "tbCantidad";
            // 
            // cbCaja
            // 
            this.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaja.FormattingEnabled = true;
            this.cbCaja.Location = new System.Drawing.Point(93, 47);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(110, 21);
            this.cbCaja.TabIndex = 81;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "CAJA DIARIA";
            // 
            // Procesar
            // 
            this.Procesar.Location = new System.Drawing.Point(12, 104);
            this.Procesar.Name = "Procesar";
            this.Procesar.Size = new System.Drawing.Size(267, 23);
            this.Procesar.TabIndex = 82;
            this.Procesar.Text = "PROCESAR RECIBOS";
            this.Procesar.UseVisualStyleBackColor = true;
            this.Procesar.Click += new System.EventHandler(this.Procesar_Click);
            // 
            // Agregar_Recibos_Caja_Diaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 154);
            this.Controls.Add(this.Procesar);
            this.Controls.Add(this.cbCaja);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbCantidad);
            this.Name = "Agregar_Recibos_Caja_Diaria";
            this.Text = "RECIBOS A CAJA DIARIA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tbCantidad;
        private System.Windows.Forms.ComboBox cbCaja;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Procesar;
    }
}