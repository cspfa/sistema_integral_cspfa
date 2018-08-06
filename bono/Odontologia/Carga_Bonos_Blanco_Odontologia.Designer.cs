namespace SOCIOS.bono.Bonos
{
    partial class Carga_Bonos_Blanco_Odontologia
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
            this.Imprimir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCODIGOS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(89, 104);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(94, 23);
            this.Imprimir.TabIndex = 157;
            this.Imprimir.Text = "IMPRIMIR";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 156;
            this.label1.Text = "Tipo Bono:";
            // 
            // cbCODIGOS
            // 
            this.cbCODIGOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCODIGOS.FormattingEnabled = true;
            this.cbCODIGOS.Location = new System.Drawing.Point(89, 27);
            this.cbCODIGOS.Name = "cbCODIGOS";
            this.cbCODIGOS.Size = new System.Drawing.Size(212, 21);
            this.cbCODIGOS.TabIndex = 155;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 158;
            this.label2.Text = "Cantidad:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(89, 58);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(31, 20);
            this.tbCantidad.TabIndex = 159;
            // 
            // Carga_Bonos_Blanco_Turismo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 153);
            this.Controls.Add(this.tbCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCODIGOS);
            this.Name = "Carga_Bonos_Blanco_Turismo";
            this.Text = "Cargas Bonos En Blanco";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Imprimir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCODIGOS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCantidad;
    }
}