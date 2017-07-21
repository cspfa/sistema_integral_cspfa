namespace SOCIOS.entradaCampo.Campo
{
    partial class EntradaEvento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradaEvento));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.Pago = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.Button();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMonto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpCantidad = new System.Windows.Forms.GroupBox();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.lbTexto = new System.Windows.Forms.Label();
            this.gpReintegro = new System.Windows.Forms.GroupBox();
            this.lbReintegro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gpCantidad.SuspendLayout();
            this.gpReintegro.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(182, 272);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(136, 30);
            this.btnImprimir.TabIndex = 32;
            this.btnImprimir.Text = "IMPRIMIR TICKET";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Pago
            // 
            this.Pago.Image = ((System.Drawing.Image)(resources.GetObject("Pago.Image")));
            this.Pago.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Pago.Location = new System.Drawing.Point(12, 229);
            this.Pago.Name = "Pago";
            this.Pago.Size = new System.Drawing.Size(82, 30);
            this.Pago.TabIndex = 31;
            this.Pago.Text = "INGRESO";
            this.Pago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pago.UseVisualStyleBackColor = true;
            this.Pago.Click += new System.EventHandler(this.Pago_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(306, 166);
            this.dataGridView1.TabIndex = 33;
            // 
            // Delete
            // 
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Delete.Location = new System.Drawing.Point(212, 229);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(106, 30);
            this.Delete.TabIndex = 34;
            this.Delete.Text = "BORRAR TODO";
            this.Delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // lbCantidad
            // 
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Location = new System.Drawing.Point(59, 270);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(13, 13);
            this.lbCantidad.TabIndex = 35;
            this.lbCantidad.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "TOTAL";
            // 
            // lbMonto
            // 
            this.lbMonto.AutoSize = true;
            this.lbMonto.Location = new System.Drawing.Point(59, 289);
            this.lbMonto.Name = "lbMonto";
            this.lbMonto.Size = new System.Drawing.Size(13, 13);
            this.lbMonto.TabIndex = 37;
            this.lbMonto.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "$";
            // 
            // gpCantidad
            // 
            this.gpCantidad.Controls.Add(this.tbCantidad);
            this.gpCantidad.Controls.Add(this.lbTexto);
            this.gpCantidad.Location = new System.Drawing.Point(15, 305);
            this.gpCantidad.Name = "gpCantidad";
            this.gpCantidad.Size = new System.Drawing.Size(122, 66);
            this.gpCantidad.TabIndex = 39;
            this.gpCantidad.TabStop = false;
            this.gpCantidad.Text = "Ingreso Por Cantidad";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(85, 27);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(23, 20);
            this.tbCantidad.TabIndex = 1;
            this.tbCantidad.Text = "1";
            this.tbCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTexto
            // 
            this.lbTexto.AutoSize = true;
            this.lbTexto.Location = new System.Drawing.Point(6, 27);
            this.lbTexto.Name = "lbTexto";
            this.lbTexto.Size = new System.Drawing.Size(62, 13);
            this.lbTexto.TabIndex = 0;
            this.lbTexto.Text = "CANTIDAD";
            // 
            // gpReintegro
            // 
            this.gpReintegro.Controls.Add(this.lbReintegro);
            this.gpReintegro.Location = new System.Drawing.Point(100, 12);
            this.gpReintegro.Name = "gpReintegro";
            this.gpReintegro.Size = new System.Drawing.Size(106, 36);
            this.gpReintegro.TabIndex = 40;
            this.gpReintegro.TabStop = false;
            this.gpReintegro.Text = "Monto Reintegro";
            // 
            // lbReintegro
            // 
            this.lbReintegro.AutoSize = true;
            this.lbReintegro.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbReintegro.Location = new System.Drawing.Point(39, 16);
            this.lbReintegro.Name = "lbReintegro";
            this.lbReintegro.Size = new System.Drawing.Size(13, 13);
            this.lbReintegro.TabIndex = 0;
            this.lbReintegro.Text = "0";
            // 
            // EntradaEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 380);
            this.Controls.Add(this.gpReintegro);
            this.Controls.Add(this.gpCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCantidad);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.Pago);
            this.Name = "EntradaEvento";
            this.Text = "EntradaEvento";
            this.Load += new System.EventHandler(this.EntradaEvento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gpCantidad.ResumeLayout(false);
            this.gpCantidad.PerformLayout();
            this.gpReintegro.ResumeLayout(false);
            this.gpReintegro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button Pago;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpCantidad;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label lbTexto;
        private System.Windows.Forms.GroupBox gpReintegro;
        private System.Windows.Forms.Label lbReintegro;
    }
}