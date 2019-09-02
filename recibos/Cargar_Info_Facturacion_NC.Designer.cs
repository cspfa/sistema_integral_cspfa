namespace SOCIOS.AFIP
{
    partial class Cargar_Info_Facturacion_NC
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
            this.lbAerta = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbVencimiento = new System.Windows.Forms.TextBox();
            this.lbCAE = new System.Windows.Forms.TextBox();
            this.lbNumero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboPtoVenta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGrabarInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbAerta
            // 
            this.lbAerta.AutoSize = true;
            this.lbAerta.ForeColor = System.Drawing.Color.Red;
            this.lbAerta.Location = new System.Drawing.Point(12, 9);
            this.lbAerta.Name = "lbAerta";
            this.lbAerta.Size = new System.Drawing.Size(49, 13);
            this.lbAerta.TabIndex = 0;
            this.lbAerta.Text = "ALERTA";
            this.lbAerta.Visible = false;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(12, 34);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(25, 13);
            this.lbInfo.TabIndex = 1;
            this.lbInfo.Text = "Info";
            this.lbInfo.Visible = false;
            // 
            // lbVencimiento
            // 
            this.lbVencimiento.Location = new System.Drawing.Point(142, 127);
            this.lbVencimiento.Name = "lbVencimiento";
            this.lbVencimiento.Size = new System.Drawing.Size(149, 20);
            this.lbVencimiento.TabIndex = 116;
            // 
            // lbCAE
            // 
            this.lbCAE.Location = new System.Drawing.Point(142, 107);
            this.lbCAE.Name = "lbCAE";
            this.lbCAE.Size = new System.Drawing.Size(149, 20);
            this.lbCAE.TabIndex = 115;
            // 
            // lbNumero
            // 
            this.lbNumero.Location = new System.Drawing.Point(142, 87);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(79, 20);
            this.lbNumero.TabIndex = 114;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(12, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 13);
            this.label9.TabIndex = 113;
            this.label9.Text = "Vencimiento(AAAAMMDD)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(87, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "CAE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(71, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 111;
            this.label7.Text = "Numero";
            // 
            // ComboPtoVenta
            // 
            this.ComboPtoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboPtoVenta.FormattingEnabled = true;
            this.ComboPtoVenta.Location = new System.Drawing.Point(142, 60);
            this.ComboPtoVenta.Name = "ComboPtoVenta";
            this.ComboPtoVenta.Size = new System.Drawing.Size(115, 21);
            this.ComboPtoVenta.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 109;
            this.label3.Text = "P.Venta (Elec)";
            // 
            // btnGrabarInfo
            // 
            this.btnGrabarInfo.Location = new System.Drawing.Point(209, 153);
            this.btnGrabarInfo.Name = "btnGrabarInfo";
            this.btnGrabarInfo.Size = new System.Drawing.Size(75, 23);
            this.btnGrabarInfo.TabIndex = 117;
            this.btnGrabarInfo.Text = "Grabar Info";
            this.btnGrabarInfo.UseVisualStyleBackColor = true;
            this.btnGrabarInfo.Click += new System.EventHandler(this.btnGrabarInfo_Click);
            // 
            // Cargar_Info_Facturacion_NC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 188);
            this.Controls.Add(this.btnGrabarInfo);
            this.Controls.Add(this.lbVencimiento);
            this.Controls.Add(this.lbCAE);
            this.Controls.Add(this.lbNumero);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ComboPtoVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbAerta);
            this.Name = "Cargar_Info_Facturacion_NC";
            this.Text = "Cargar  info NC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAerta;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox lbVencimiento;
        private System.Windows.Forms.TextBox lbCAE;
        private System.Windows.Forms.TextBox lbNumero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ComboPtoVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGrabarInfo;
    }
}