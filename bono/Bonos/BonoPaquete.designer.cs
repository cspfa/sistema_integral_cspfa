﻿namespace SOCIOS.bono
{
    partial class BonoPaquete
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
            this.lbTipoViaje = new System.Windows.Forms.Label();
            this.cbPaquete = new System.Windows.Forms.ComboBox();
            this.tbObs = new System.Windows.Forms.TextBox();
            this.AnularBono = new System.Windows.Forms.Button();
            this.Reiniciar = new System.Windows.Forms.Button();
            this.bntImprimir = new System.Windows.Forms.Button();
            this.Grabar = new System.Windows.Forms.Button();
            this.InfoPaquete = new System.Windows.Forms.Button();
            this.Seleccion = new System.Windows.Forms.Button();
            this.Deseleccionar = new System.Windows.Forms.Button();
            this.lbSaldoTotal = new System.Windows.Forms.Label();
            this.lbSocios = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbInvitados = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pagBono = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbInterCirculo = new System.Windows.Forms.Label();
            this.fpago = new System.Windows.Forms.Label();
            this.dpFechaBono = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gpDatos = new System.Windows.Forms.GroupBox();
            this.gpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTipoViaje
            // 
            this.lbTipoViaje.AutoSize = true;
            this.lbTipoViaje.Location = new System.Drawing.Point(37, 378);
            this.lbTipoViaje.Name = "lbTipoViaje";
            this.lbTipoViaje.Size = new System.Drawing.Size(28, 13);
            this.lbTipoViaje.TabIndex = 0;
            this.lbTipoViaje.Text = "Tipo";
            // 
            // cbPaquete
            // 
            this.cbPaquete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaquete.FormattingEnabled = true;
            this.cbPaquete.Location = new System.Drawing.Point(99, 378);
            this.cbPaquete.Name = "cbPaquete";
            this.cbPaquete.Size = new System.Drawing.Size(269, 21);
            this.cbPaquete.TabIndex = 83;
            this.cbPaquete.SelectedIndexChanged += new System.EventHandler(this.cbPaquete_SelectedIndexChanged);
            // 
            // tbObs
            // 
            this.tbObs.Location = new System.Drawing.Point(50, 552);
            this.tbObs.Multiline = true;
            this.tbObs.Name = "tbObs";
            this.tbObs.Size = new System.Drawing.Size(727, 83);
            this.tbObs.TabIndex = 108;
            this.tbObs.TextChanged += new System.EventHandler(this.tbObs_TextChanged);
            // 
            // AnularBono
            // 
            this.AnularBono.Location = new System.Drawing.Point(851, 588);
            this.AnularBono.Name = "AnularBono";
            this.AnularBono.Size = new System.Drawing.Size(92, 23);
            this.AnularBono.TabIndex = 116;
            this.AnularBono.Text = "Anular";
            this.AnularBono.UseVisualStyleBackColor = true;
            this.AnularBono.Visible = false;
            this.AnularBono.Click += new System.EventHandler(this.AnularBono_Click);
            // 
            // Reiniciar
            // 
            this.Reiniciar.Location = new System.Drawing.Point(789, 617);
            this.Reiniciar.Name = "Reiniciar";
            this.Reiniciar.Size = new System.Drawing.Size(154, 23);
            this.Reiniciar.TabIndex = 115;
            this.Reiniciar.Text = "Reiniciar Pantalla";
            this.Reiniciar.UseVisualStyleBackColor = true;
            // 
            // bntImprimir
            // 
            this.bntImprimir.Location = new System.Drawing.Point(851, 559);
            this.bntImprimir.Name = "bntImprimir";
            this.bntImprimir.Size = new System.Drawing.Size(92, 23);
            this.bntImprimir.TabIndex = 114;
            this.bntImprimir.Text = "Imprimir";
            this.bntImprimir.UseVisualStyleBackColor = true;
            this.bntImprimir.Visible = false;
            this.bntImprimir.Click += new System.EventHandler(this.bntImprimir_Click);
            // 
            // Grabar
            // 
            this.Grabar.Location = new System.Drawing.Point(851, 526);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(92, 23);
            this.Grabar.TabIndex = 112;
            this.Grabar.Text = "Grabar Bono";
            this.Grabar.UseVisualStyleBackColor = true;
            this.Grabar.Visible = false;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // InfoPaquete
            // 
            this.InfoPaquete.Location = new System.Drawing.Point(389, 376);
            this.InfoPaquete.Name = "InfoPaquete";
            this.InfoPaquete.Size = new System.Drawing.Size(160, 23);
            this.InfoPaquete.TabIndex = 130;
            this.InfoPaquete.Text = "Info Paquete";
            this.InfoPaquete.UseVisualStyleBackColor = true;
            this.InfoPaquete.Click += new System.EventHandler(this.InfoPaquete_Click);
            // 
            // Seleccion
            // 
            this.Seleccion.Location = new System.Drawing.Point(389, 405);
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Size = new System.Drawing.Size(160, 23);
            this.Seleccion.TabIndex = 131;
            this.Seleccion.Text = "Seleccionar";
            this.Seleccion.UseVisualStyleBackColor = true;
            this.Seleccion.Click += new System.EventHandler(this.Seleccion_Click);
            // 
            // Deseleccionar
            // 
            this.Deseleccionar.Location = new System.Drawing.Point(555, 405);
            this.Deseleccionar.Name = "Deseleccionar";
            this.Deseleccionar.Size = new System.Drawing.Size(160, 23);
            this.Deseleccionar.TabIndex = 132;
            this.Deseleccionar.Text = "Deseleccionar";
            this.Deseleccionar.UseVisualStyleBackColor = true;
            this.Deseleccionar.Visible = false;
            this.Deseleccionar.Click += new System.EventHandler(this.Deseleccionar_Click);
            // 
            // lbSaldoTotal
            // 
            this.lbSaldoTotal.AutoSize = true;
            this.lbSaldoTotal.Location = new System.Drawing.Point(218, 85);
            this.lbSaldoTotal.Name = "lbSaldoTotal";
            this.lbSaldoTotal.Size = new System.Drawing.Size(13, 13);
            this.lbSaldoTotal.TabIndex = 118;
            this.lbSaldoTotal.Text = "0";
            // 
            // lbSocios
            // 
            this.lbSocios.AutoSize = true;
            this.lbSocios.Location = new System.Drawing.Point(96, 25);
            this.lbSocios.Name = "lbSocios";
            this.lbSocios.Size = new System.Drawing.Size(47, 13);
            this.lbSocios.TabIndex = 132;
            this.lbSocios.Text = "SOCIOS";
            this.lbSocios.Click += new System.EventHandler(this.lbSocios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "INVITADOS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 109;
            this.label7.Text = "OBSERVACIONES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "SOCIOS";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // lbInvitados
            // 
            this.lbInvitados.AutoSize = true;
            this.lbInvitados.Location = new System.Drawing.Point(329, 25);
            this.lbInvitados.Name = "lbInvitados";
            this.lbInvitados.Size = new System.Drawing.Size(65, 13);
            this.lbInvitados.TabIndex = 133;
            this.lbInvitados.Text = "INVITADOS";
            this.lbInvitados.Click += new System.EventHandler(this.lbInvitados_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(143, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 119;
            this.label8.Text = "TOTAL";
            // 
            // pagBono
            // 
            this.pagBono.Location = new System.Drawing.Point(17, 53);
            this.pagBono.Name = "pagBono";
            this.pagBono.Size = new System.Drawing.Size(75, 23);
            this.pagBono.TabIndex = 114;
            this.pagBono.Text = "Pago Bono";
            this.pagBono.UseVisualStyleBackColor = true;
            this.pagBono.Click += new System.EventHandler(this.pagBono_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 135;
            this.label6.Text = "INTERCIRCULO";
            // 
            // lbInterCirculo
            // 
            this.lbInterCirculo.AutoSize = true;
            this.lbInterCirculo.Location = new System.Drawing.Point(329, 53);
            this.lbInterCirculo.Name = "lbInterCirculo";
            this.lbInterCirculo.Size = new System.Drawing.Size(65, 13);
            this.lbInterCirculo.TabIndex = 136;
            this.lbInterCirculo.Text = "INVITADOS";
            // 
            // fpago
            // 
            this.fpago.AutoSize = true;
            this.fpago.Location = new System.Drawing.Point(327, 109);
            this.fpago.Name = "fpago";
            this.fpago.Size = new System.Drawing.Size(67, 13);
            this.fpago.TabIndex = 120;
            this.fpago.Text = "[FormaPago]";
            // 
            // dpFechaBono
            // 
            this.dpFechaBono.Location = new System.Drawing.Point(398, 78);
            this.dpFechaBono.Name = "dpFechaBono";
            this.dpFechaBono.Size = new System.Drawing.Size(200, 20);
            this.dpFechaBono.TabIndex = 132;
            this.dpFechaBono.ValueChanged += new System.EventHandler(this.dpFechaBono_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "FECHA";
            // 
            // gpDatos
            // 
            this.gpDatos.Controls.Add(this.label2);
            this.gpDatos.Controls.Add(this.dpFechaBono);
            this.gpDatos.Controls.Add(this.fpago);
            this.gpDatos.Controls.Add(this.lbInterCirculo);
            this.gpDatos.Controls.Add(this.label6);
            this.gpDatos.Controls.Add(this.pagBono);
            this.gpDatos.Controls.Add(this.label8);
            this.gpDatos.Controls.Add(this.lbInvitados);
            this.gpDatos.Controls.Add(this.label4);
            this.gpDatos.Controls.Add(this.label7);
            this.gpDatos.Controls.Add(this.label1);
            this.gpDatos.Controls.Add(this.lbSocios);
            this.gpDatos.Controls.Add(this.lbSaldoTotal);
            this.gpDatos.Location = new System.Drawing.Point(33, 427);
            this.gpDatos.Name = "gpDatos";
            this.gpDatos.Size = new System.Drawing.Size(750, 244);
            this.gpDatos.TabIndex = 122;
            this.gpDatos.TabStop = false;
            this.gpDatos.Visible = false;
            // 
            // BonoPaquete
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 675);
            this.Controls.Add(this.Deseleccionar);
            this.Controls.Add(this.Seleccion);
            this.Controls.Add(this.InfoPaquete);
            this.Controls.Add(this.AnularBono);
            this.Controls.Add(this.Reiniciar);
            this.Controls.Add(this.bntImprimir);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.tbObs);
            this.Controls.Add(this.cbPaquete);
            this.Controls.Add(this.lbTipoViaje);
            this.Controls.Add(this.gpDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BonoPaquete";
            this.Load += new System.EventHandler(this.BonoPaquete_Load);
            this.gpDatos.ResumeLayout(false);
            this.gpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTipoViaje;
        private System.Windows.Forms.ComboBox cbPaquete;
        private System.Windows.Forms.TextBox tbObs;
        private System.Windows.Forms.Button AnularBono;
        private System.Windows.Forms.Button Reiniciar;
        private System.Windows.Forms.Button bntImprimir;
        private System.Windows.Forms.Button Grabar;
        private System.Windows.Forms.Button InfoPaquete;
        private System.Windows.Forms.Button Seleccion;
        private System.Windows.Forms.Button Deseleccionar;
        private System.Windows.Forms.Label lbSaldoTotal;
        private System.Windows.Forms.Label lbSocios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbInvitados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button pagBono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbInterCirculo;
        private System.Windows.Forms.Label fpago;
        private System.Windows.Forms.DateTimePicker dpFechaBono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpDatos;
    }
}
