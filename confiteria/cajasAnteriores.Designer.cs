namespace Confiteria
{
    partial class cajasAnteriores
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
            this.dgCajasAnteriores = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EFECTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARJETAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCUENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESPECIALES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimirListado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCajasAnteriores)).BeginInit();
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
            this.dgCajasAnteriores.Location = new System.Drawing.Point(12, 12);
            this.dgCajasAnteriores.MultiSelect = false;
            this.dgCajasAnteriores.Name = "dgCajasAnteriores";
            this.dgCajasAnteriores.ReadOnly = true;
            this.dgCajasAnteriores.RowHeadersVisible = false;
            this.dgCajasAnteriores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCajasAnteriores.Size = new System.Drawing.Size(669, 437);
            this.dgCajasAnteriores.TabIndex = 29;
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
            // btnImprimirListado
            // 
            this.btnImprimirListado.Location = new System.Drawing.Point(13, 460);
            this.btnImprimirListado.Name = "btnImprimirListado";
            this.btnImprimirListado.Size = new System.Drawing.Size(143, 23);
            this.btnImprimirListado.TabIndex = 30;
            this.btnImprimirListado.Text = "IMPRIMIR LISTADO";
            this.btnImprimirListado.UseVisualStyleBackColor = true;
            this.btnImprimirListado.Click += new System.EventHandler(this.btnImprimirListado_Click);
            // 
            // cajasAnteriores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 495);
            this.Controls.Add(this.btnImprimirListado);
            this.Controls.Add(this.dgCajasAnteriores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "cajasAnteriores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAJAS ANTERIORES";
            this.Load += new System.EventHandler(this.cajasAnteriores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCajasAnteriores)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnImprimirListado;
    }
}