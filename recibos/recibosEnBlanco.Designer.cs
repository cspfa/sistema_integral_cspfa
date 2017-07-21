namespace SOCIOS
{
    partial class recibosEnBlanco
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmarImpresion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.MaskedTextBox();
            this.btnImprimirManual = new System.Windows.Forms.Button();
            this.tbDesde = new System.Windows.Forms.MaskedTextBox();
            this.tbHasta = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbComprobantes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvPuntosDeVenta = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.cbExcel = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DESDE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "HASTA";
            // 
            // btnConfirmarImpresion
            // 
            this.btnConfirmarImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarImpresion.Location = new System.Drawing.Point(654, 97);
            this.btnConfirmarImpresion.Name = "btnConfirmarImpresion";
            this.btnConfirmarImpresion.Size = new System.Drawing.Size(98, 27);
            this.btnConfirmarImpresion.TabIndex = 2;
            this.btnConfirmarImpresion.Text = "IMPRIMIR";
            this.btnConfirmarImpresion.UseVisualStyleBackColor = true;
            this.btnConfirmarImpresion.Click += new System.EventHandler(this.btnConfirmarImpresion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(589, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CANTIDAD";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantidad.Location = new System.Drawing.Point(654, 39);
            this.tbCantidad.Mask = "9999";
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(98, 21);
            this.tbCantidad.TabIndex = 3;
            this.tbCantidad.TextChanged += new System.EventHandler(this.tbCantidad_TextChanged);
            // 
            // btnImprimirManual
            // 
            this.btnImprimirManual.Enabled = false;
            this.btnImprimirManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirManual.Location = new System.Drawing.Point(654, 130);
            this.btnImprimirManual.Name = "btnImprimirManual";
            this.btnImprimirManual.Size = new System.Drawing.Size(98, 27);
            this.btnImprimirManual.TabIndex = 5;
            this.btnImprimirManual.Text = "RE-IMPRIMIR";
            this.btnImprimirManual.UseVisualStyleBackColor = true;
            this.btnImprimirManual.Click += new System.EventHandler(this.btnImprimirManual_Click);
            // 
            // tbDesde
            // 
            this.tbDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDesde.Location = new System.Drawing.Point(486, 70);
            this.tbDesde.Mask = "999999";
            this.tbDesde.Name = "tbDesde";
            this.tbDesde.Size = new System.Drawing.Size(98, 21);
            this.tbDesde.TabIndex = 6;
            // 
            // tbHasta
            // 
            this.tbHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHasta.Location = new System.Drawing.Point(654, 70);
            this.tbHasta.Mask = "999999";
            this.tbHasta.Name = "tbHasta";
            this.tbHasta.Size = new System.Drawing.Size(98, 21);
            this.tbHasta.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "TIPO";
            // 
            // cbComprobantes
            // 
            this.cbComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComprobantes.FormattingEnabled = true;
            this.cbComprobantes.Location = new System.Drawing.Point(486, 39);
            this.cbComprobantes.Name = "cbComprobantes";
            this.cbComprobantes.Size = new System.Drawing.Size(98, 21);
            this.cbComprobantes.TabIndex = 4;
            this.cbComprobantes.SelectedIndexChanged += new System.EventHandler(this.reset);
            this.cbComprobantes.SelectionChangeCommitted += new System.EventHandler(this.cbComprobantes_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "PUNTO DE VENTA";
            // 
            // lvPuntosDeVenta
            // 
            this.lvPuntosDeVenta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvPuntosDeVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPuntosDeVenta.CausesValidation = false;
            this.lvPuntosDeVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPuntosDeVenta.FullRowSelect = true;
            this.lvPuntosDeVenta.GridLines = true;
            this.lvPuntosDeVenta.HideSelection = false;
            this.lvPuntosDeVenta.Location = new System.Drawing.Point(15, 40);
            this.lvPuntosDeVenta.Margin = new System.Windows.Forms.Padding(0);
            this.lvPuntosDeVenta.MultiSelect = false;
            this.lvPuntosDeVenta.Name = "lvPuntosDeVenta";
            this.lvPuntosDeVenta.ParentContainer = null;
            this.lvPuntosDeVenta.ShowItemToolTips = true;
            this.lvPuntosDeVenta.Size = new System.Drawing.Size(412, 220);
            this.lvPuntosDeVenta.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPuntosDeVenta.TabIndex = 9;
            this.lvPuntosDeVenta.UseCompatibleStateImageBehavior = false;
            this.lvPuntosDeVenta.View = System.Windows.Forms.View.Details;
            this.lvPuntosDeVenta.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvPuntosDeVenta_MouseUp);
            // 
            // cbExcel
            // 
            this.cbExcel.AutoSize = true;
            this.cbExcel.Checked = true;
            this.cbExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExcel.Location = new System.Drawing.Point(486, 103);
            this.cbExcel.Name = "cbExcel";
            this.cbExcel.Size = new System.Drawing.Size(60, 17);
            this.cbExcel.TabIndex = 10;
            this.cbExcel.Text = "EXCEL";
            this.cbExcel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(654, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 27);
            this.button1.TabIndex = 11;
            this.button1.Text = "RESERVAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // recibosEnBlanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 279);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbExcel);
            this.Controls.Add(this.lvPuntosDeVenta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbHasta);
            this.Controls.Add(this.tbDesde);
            this.Controls.Add(this.btnImprimirManual);
            this.Controls.Add(this.cbComprobantes);
            this.Controls.Add(this.tbCantidad);
            this.Controls.Add(this.btnConfirmarImpresion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "recibosEnBlanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Impresión o Reserva de Comprobantes en Blanco";
            this.Load += new System.EventHandler(this.recibosEnBlanco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmarImpresion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbCantidad;
        private System.Windows.Forms.Button btnImprimirManual;
        private System.Windows.Forms.MaskedTextBox tbDesde;
        private System.Windows.Forms.MaskedTextBox tbHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbComprobantes;
        private System.Windows.Forms.Label label6;
        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvPuntosDeVenta;
        private System.Windows.Forms.CheckBox cbExcel;
        private System.Windows.Forms.Button button1;
    }
}