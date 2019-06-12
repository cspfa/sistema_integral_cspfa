namespace SOCIOS
{
    partial class tarjetas
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbTarjetas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCuotas = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbTotalEnCuotas = new System.Windows.Forms.Label();
            this.lbValorCuota = new System.Windows.Forms.Label();
            this.btCerrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtVoucher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbCuota = new System.Windows.Forms.Label();
            this.lbTotalInteres = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TARJETA";
            // 
            // cbTarjetas
            // 
            this.cbTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTarjetas.FormattingEnabled = true;
            this.cbTarjetas.Location = new System.Drawing.Point(80, 21);
            this.cbTarjetas.Name = "cbTarjetas";
            this.cbTarjetas.Size = new System.Drawing.Size(100, 21);
            this.cbTarjetas.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CUOTAS";
            // 
            // txtCuotas
            // 
            this.txtCuotas.Location = new System.Drawing.Point(80, 49);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(100, 20);
            this.txtCuotas.TabIndex = 2;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(80, 76);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(100, 20);
            this.txtImporte.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "IMPORTE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "CALCULAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTotalEnCuotas
            // 
            this.lbTotalEnCuotas.AutoSize = true;
            this.lbTotalEnCuotas.Location = new System.Drawing.Point(198, 25);
            this.lbTotalEnCuotas.Name = "lbTotalEnCuotas";
            this.lbTotalEnCuotas.Size = new System.Drawing.Size(107, 13);
            this.lbTotalEnCuotas.TabIndex = 0;
            this.lbTotalEnCuotas.Text = "TOTAL EN CUOTAS";
            // 
            // lbValorCuota
            // 
            this.lbValorCuota.AutoSize = true;
            this.lbValorCuota.Location = new System.Drawing.Point(331, 25);
            this.lbValorCuota.Name = "lbValorCuota";
            this.lbValorCuota.Size = new System.Drawing.Size(83, 13);
            this.lbValorCuota.TabIndex = 2;
            this.lbValorCuota.Text = "VALOR CUOTA";
            // 
            // btCerrar
            // 
            this.btCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btCerrar.Location = new System.Drawing.Point(322, 154);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(100, 23);
            this.btCerrar.TabIndex = 7;
            this.btCerrar.Text = "CERRAR";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(201, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "IMPRIMIR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtVoucher
            // 
            this.txtVoucher.Location = new System.Drawing.Point(80, 103);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(100, 20);
            this.txtVoucher.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "VOUCHER";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(206, 74);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(0, 20);
            this.lbTotal.TabIndex = 12;
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCuota
            // 
            this.lbCuota.AutoSize = true;
            this.lbCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCuota.Location = new System.Drawing.Point(331, 74);
            this.lbCuota.Name = "lbCuota";
            this.lbCuota.Size = new System.Drawing.Size(0, 20);
            this.lbCuota.TabIndex = 13;
            this.lbCuota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalInteres
            // 
            this.lbTotalInteres.AutoSize = true;
            this.lbTotalInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalInteres.Location = new System.Drawing.Point(330, 116);
            this.lbTotalInteres.Name = "lbTotalInteres";
            this.lbTotalInteres.Size = new System.Drawing.Size(15, 20);
            this.lbTotalInteres.TabIndex = 14;
            this.lbTotalInteres.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "INTERES";
            // 
            // tarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 191);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbTotalInteres);
            this.Controls.Add(this.lbCuota);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.txtVoucher);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCuotas);
            this.Controls.Add(this.lbValorCuota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTarjetas);
            this.Controls.Add(this.lbTotalEnCuotas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "tarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas de Crédito - Cálculo de Cuotas";
            this.Load += new System.EventHandler(this.tarjetas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTarjetas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCuotas;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbTotalEnCuotas;
        private System.Windows.Forms.Label lbValorCuota;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtVoucher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbCuota;
        private System.Windows.Forms.Label lbTotalInteres;
        private System.Windows.Forms.Label label5;
    }
}