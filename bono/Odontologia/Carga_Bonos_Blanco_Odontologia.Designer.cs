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
            this.label2 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.cbProfesionales = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOdontologia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(72, 124);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(94, 23);
            this.Imprimir.TabIndex = 157;
            this.Imprimir.Text = "IMPRIMIR";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 158;
            this.label2.Text = "Cantidad:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(94, 80);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(31, 20);
            this.tbCantidad.TabIndex = 159;
            // 
            // cbProfesionales
            // 
            this.cbProfesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfesionales.FormattingEnabled = true;
            this.cbProfesionales.Location = new System.Drawing.Point(94, 53);
            this.cbProfesionales.Name = "cbProfesionales";
            this.cbProfesionales.Size = new System.Drawing.Size(203, 21);
            this.cbProfesionales.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 162;
            this.label3.Text = "Profesionales:";
            // 
            // cbOdontologia
            // 
            this.cbOdontologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOdontologia.FormattingEnabled = true;
            this.cbOdontologia.Location = new System.Drawing.Point(94, 26);
            this.cbOdontologia.Name = "cbOdontologia";
            this.cbOdontologia.Size = new System.Drawing.Size(203, 21);
            this.cbOdontologia.TabIndex = 161;
            this.cbOdontologia.SelectedIndexChanged += new System.EventHandler(this.cbOdontologia_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 160;
            this.label4.Text = "Especialidad:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Carga_Bonos_Blanco_Odontologia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 156);
            this.Controls.Add(this.cbProfesionales);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbOdontologia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Imprimir);
            this.Name = "Carga_Bonos_Blanco_Odontologia";
            this.Text = "Cargas Bonos En Blanco";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Imprimir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.ComboBox cbProfesionales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOdontologia;
        private System.Windows.Forms.Label label4;
    }
}