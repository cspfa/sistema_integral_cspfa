namespace SOCIOS.Factura_Electronica
{
    partial class Testing_Facturacion
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
            this.tbPuntoVenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.tbMonto = new System.Windows.Forms.TextBox();
            this.lbmonto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTipoComprobante = new System.Windows.Forms.ComboBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.Facturar = new System.Windows.Forms.Button();
            this.lbResult = new System.Windows.Forms.Label();
            this.lbCAE = new System.Windows.Forms.Label();
            this.lbVencimiento = new System.Windows.Forms.Label();
            this.lbNumero = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPuntoVenta
            // 
            this.tbPuntoVenta.Location = new System.Drawing.Point(119, 11);
            this.tbPuntoVenta.Name = "tbPuntoVenta";
            this.tbPuntoVenta.Size = new System.Drawing.Size(37, 20);
            this.tbPuntoVenta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PtoVenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(119, 38);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(159, 20);
            this.dtFecha.TabIndex = 3;
            // 
            // tbMonto
            // 
            this.tbMonto.Location = new System.Drawing.Point(119, 124);
            this.tbMonto.Name = "tbMonto";
            this.tbMonto.Size = new System.Drawing.Size(105, 20);
            this.tbMonto.TabIndex = 4;
            // 
            // lbmonto
            // 
            this.lbmonto.AutoSize = true;
            this.lbmonto.Location = new System.Drawing.Point(15, 124);
            this.lbmonto.Name = "lbmonto";
            this.lbmonto.Size = new System.Drawing.Size(37, 13);
            this.lbmonto.TabIndex = 5;
            this.lbmonto.Text = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo Comprobante";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo Documento";
            // 
            // cbTipoComprobante
            // 
            this.cbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoComprobante.FormattingEnabled = true;
            this.cbTipoComprobante.Location = new System.Drawing.Point(119, 64);
            this.cbTipoComprobante.Name = "cbTipoComprobante";
            this.cbTipoComprobante.Size = new System.Drawing.Size(161, 21);
            this.cbTipoComprobante.TabIndex = 48;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(119, 94);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(37, 21);
            this.cbTipoDocumento.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Documento";
            // 
            // tbDni
            // 
            this.tbDni.Location = new System.Drawing.Point(230, 94);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(106, 20);
            this.tbDni.TabIndex = 51;
            // 
            // Facturar
            // 
            this.Facturar.Location = new System.Drawing.Point(16, 165);
            this.Facturar.Name = "Facturar";
            this.Facturar.Size = new System.Drawing.Size(75, 23);
            this.Facturar.TabIndex = 52;
            this.Facturar.Text = "Facturar";
            this.Facturar.UseVisualStyleBackColor = true;
            this.Facturar.Click += new System.EventHandler(this.Facturar_Click);
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbResult.Location = new System.Drawing.Point(116, 165);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(10, 13);
            this.lbResult.TabIndex = 53;
            this.lbResult.Text = "-";
            // 
            // lbCAE
            // 
            this.lbCAE.AutoSize = true;
            this.lbCAE.ForeColor = System.Drawing.Color.Maroon;
            this.lbCAE.Location = new System.Drawing.Point(16, 213);
            this.lbCAE.Name = "lbCAE";
            this.lbCAE.Size = new System.Drawing.Size(28, 13);
            this.lbCAE.TabIndex = 54;
            this.lbCAE.Text = "CAE";
            this.lbCAE.Click += new System.EventHandler(this.label6_Click);
            // 
            // lbVencimiento
            // 
            this.lbVencimiento.AutoSize = true;
            this.lbVencimiento.ForeColor = System.Drawing.Color.Maroon;
            this.lbVencimiento.Location = new System.Drawing.Point(18, 232);
            this.lbVencimiento.Name = "lbVencimiento";
            this.lbVencimiento.Size = new System.Drawing.Size(65, 13);
            this.lbVencimiento.TabIndex = 55;
            this.lbVencimiento.Text = "Vencimiento";
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.ForeColor = System.Drawing.Color.Maroon;
            this.lbNumero.Location = new System.Drawing.Point(15, 191);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(44, 13);
            this.lbNumero.TabIndex = 56;
            this.lbNumero.Text = "Numero";
            // 
            // Testing_Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 254);
            this.Controls.Add(this.lbNumero);
            this.Controls.Add(this.lbVencimiento);
            this.Controls.Add(this.lbCAE);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.Facturar);
            this.Controls.Add(this.tbDni);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTipoDocumento);
            this.Controls.Add(this.cbTipoComprobante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbmonto);
            this.Controls.Add(this.tbMonto);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPuntoVenta);
            this.Name = "Testing_Facturacion";
            this.Text = "Testear Configuracion Facturacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPuntoVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.TextBox tbMonto;
        private System.Windows.Forms.Label lbmonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTipoComprobante;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.Button Facturar;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label lbCAE;
        private System.Windows.Forms.Label lbVencimiento;
        private System.Windows.Forms.Label lbNumero;
    }
}