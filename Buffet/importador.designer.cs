namespace Buffet
{
    partial class importador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgCajasAnteriores = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EFECTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARJETAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCUENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESPECIALES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgComandas = new System.Windows.Forms.DataGridView();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOM_SOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_SOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_DEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_COMANDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.pbImportar = new System.Windows.Forms.ProgressBar();
            this.btnImportarArticulos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCajasAnteriores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgComandas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCajasAnteriores
            // 
            this.dgCajasAnteriores.AllowUserToAddRows = false;
            this.dgCajasAnteriores.AllowUserToDeleteRows = false;
            this.dgCajasAnteriores.AllowUserToResizeColumns = false;
            this.dgCajasAnteriores.AllowUserToResizeRows = false;
            this.dgCajasAnteriores.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgCajasAnteriores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgCajasAnteriores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCajasAnteriores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FECHA,
            this.USUARIO,
            this.EFECTIVO,
            this.TARJETAS,
            this.DESCUENTO,
            this.ESPECIALES});
            this.dgCajasAnteriores.Location = new System.Drawing.Point(12, 36);
            this.dgCajasAnteriores.MultiSelect = false;
            this.dgCajasAnteriores.Name = "dgCajasAnteriores";
            this.dgCajasAnteriores.ReadOnly = true;
            this.dgCajasAnteriores.RowHeadersVisible = false;
            this.dgCajasAnteriores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCajasAnteriores.Size = new System.Drawing.Size(785, 135);
            this.dgCajasAnteriores.TabIndex = 30;
            this.dgCajasAnteriores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCajasAnteriores_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // FECHA
            // 
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            // 
            // USUARIO
            // 
            this.USUARIO.HeaderText = "USUARIO";
            this.USUARIO.Name = "USUARIO";
            this.USUARIO.ReadOnly = true;
            // 
            // EFECTIVO
            // 
            this.EFECTIVO.HeaderText = "EFECTIVO";
            this.EFECTIVO.Name = "EFECTIVO";
            this.EFECTIVO.ReadOnly = true;
            // 
            // TARJETAS
            // 
            this.TARJETAS.HeaderText = "TARJETAS";
            this.TARJETAS.Name = "TARJETAS";
            this.TARJETAS.ReadOnly = true;
            // 
            // DESCUENTO
            // 
            this.DESCUENTO.HeaderText = "DESCUENTO";
            this.DESCUENTO.Name = "DESCUENTO";
            this.DESCUENTO.ReadOnly = true;
            // 
            // ESPECIALES
            // 
            this.ESPECIALES.HeaderText = "ESPECIALES";
            this.ESPECIALES.Name = "ESPECIALES";
            this.ESPECIALES.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "CAJAS DIARIAS A IMPORTAR";
            // 
            // dgComandas
            // 
            this.dgComandas.AllowUserToAddRows = false;
            this.dgComandas.AllowUserToDeleteRows = false;
            this.dgComandas.AllowUserToResizeColumns = false;
            this.dgComandas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgComandas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgComandas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgComandas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgComandas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgComandas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgComandas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgComandas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CANTIDAD,
            this.IMPORTE,
            this.DATE,
            this.NOM_SOC,
            this.NRO_SOC,
            this.NRO_DEP,
            this.ID_COMANDA});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgComandas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgComandas.Location = new System.Drawing.Point(12, 209);
            this.dgComandas.Margin = new System.Windows.Forms.Padding(5);
            this.dgComandas.Name = "dgComandas";
            this.dgComandas.ReadOnly = true;
            this.dgComandas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgComandas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgComandas.RowHeadersVisible = false;
            this.dgComandas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgComandas.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgComandas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgComandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgComandas.Size = new System.Drawing.Size(785, 248);
            this.dgComandas.TabIndex = 60;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.HeaderText = "#";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            this.CANTIDAD.Width = 60;
            // 
            // IMPORTE
            // 
            this.IMPORTE.HeaderText = "IMPORTE";
            this.IMPORTE.Name = "IMPORTE";
            this.IMPORTE.ReadOnly = true;
            this.IMPORTE.Width = 75;
            // 
            // DATE
            // 
            this.DATE.HeaderText = "FECHA";
            this.DATE.Name = "DATE";
            this.DATE.ReadOnly = true;
            // 
            // NOM_SOC
            // 
            this.NOM_SOC.HeaderText = "NOMBRE Y APELLIDO";
            this.NOM_SOC.Name = "NOM_SOC";
            this.NOM_SOC.ReadOnly = true;
            this.NOM_SOC.Width = 220;
            // 
            // NRO_SOC
            // 
            this.NRO_SOC.HeaderText = "SOC";
            this.NRO_SOC.Name = "NRO_SOC";
            this.NRO_SOC.ReadOnly = true;
            this.NRO_SOC.Width = 55;
            // 
            // NRO_DEP
            // 
            this.NRO_DEP.HeaderText = "DEP";
            this.NRO_DEP.Name = "NRO_DEP";
            this.NRO_DEP.ReadOnly = true;
            this.NRO_DEP.Width = 55;
            // 
            // ID_COMANDA
            // 
            this.ID_COMANDA.HeaderText = "ID_COMANDA";
            this.ID_COMANDA.Name = "ID_COMANDA";
            this.ID_COMANDA.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "COMANDAS A IMPORTAR";
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(382, 462);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(186, 23);
            this.btnImportar.TabIndex = 62;
            this.btnImportar.Text = "IMPORTAR";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // pbImportar
            // 
            this.pbImportar.Location = new System.Drawing.Point(12, 465);
            this.pbImportar.Name = "pbImportar";
            this.pbImportar.Size = new System.Drawing.Size(364, 20);
            this.pbImportar.TabIndex = 87;
            this.pbImportar.Visible = false;
            // 
            // btnImportarArticulos
            // 
            this.btnImportarArticulos.Location = new System.Drawing.Point(574, 462);
            this.btnImportarArticulos.Name = "btnImportarArticulos";
            this.btnImportarArticulos.Size = new System.Drawing.Size(186, 23);
            this.btnImportarArticulos.TabIndex = 88;
            this.btnImportarArticulos.Text = "IMPORTAR ARTICULOS";
            this.btnImportarArticulos.UseVisualStyleBackColor = true;
            this.btnImportarArticulos.Click += new System.EventHandler(this.BtnImportarArticulos_Click);
            // 
            // importador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 500);
            this.Controls.Add(this.btnImportarArticulos);
            this.Controls.Add(this.pbImportar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgComandas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCajasAnteriores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "importador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importador Confiteria";
            ((System.ComponentModel.ISupportInitialize)(this.dgCajasAnteriores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgComandas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCajasAnteriores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EFECTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARJETAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCUENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESPECIALES;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgComandas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.ProgressBar pbImportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOM_SOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_SOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_DEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_COMANDA;
        private System.Windows.Forms.Button btnImportarArticulos;
    }
}