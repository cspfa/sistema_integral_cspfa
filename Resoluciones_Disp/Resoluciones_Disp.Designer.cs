namespace Resoluciones_Disp
{
    partial class Resoluciones_Disp
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgResolucionesDisposiciones = new System.Windows.Forms.DataGridView();
            this.ANIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnArchivo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgResolucionesDisposiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgResolucionesDisposiciones
            // 
            this.dgResolucionesDisposiciones.AllowUserToAddRows = false;
            this.dgResolucionesDisposiciones.AllowUserToDeleteRows = false;
            this.dgResolucionesDisposiciones.AllowUserToResizeColumns = false;
            this.dgResolucionesDisposiciones.AllowUserToResizeRows = false;
            this.dgResolucionesDisposiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResolucionesDisposiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ANIO,
            this.NUMERO,
            this.DESCRIPCION});
            this.dgResolucionesDisposiciones.Location = new System.Drawing.Point(12, 60);
            this.dgResolucionesDisposiciones.MultiSelect = false;
            this.dgResolucionesDisposiciones.Name = "dgResolucionesDisposiciones";
            this.dgResolucionesDisposiciones.Size = new System.Drawing.Size(795, 340);
            this.dgResolucionesDisposiciones.TabIndex = 0;
            // 
            // ANIO
            // 
            this.ANIO.HeaderText = "Año";
            this.ANIO.Name = "ANIO";
            // 
            // NUMERO
            // 
            this.NUMERO.HeaderText = "Numero";
            this.NUMERO.Name = "NUMERO";
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "Descripcion";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.Width = 550;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "BUSCAR:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "EN";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Todos"});
            this.cbTipo.Location = new System.Drawing.Point(312, 21);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(160, 21);
            this.cbTipo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(479, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "POR";
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Items.AddRange(new object[] {
            "Numero",
            "Descripcion",
            "Año"});
            this.cbFiltro.Location = new System.Drawing.Point(521, 21);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(121, 21);
            this.cbFiltro.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(732, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(826, 60);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(826, 102);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(826, 146);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 24);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnArchivo
            // 
            this.btnArchivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnArchivo.Location = new System.Drawing.Point(826, 191);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(75, 24);
            this.btnArchivo.TabIndex = 11;
            this.btnArchivo.Text = "ARCHIVO";
            this.btnArchivo.UseVisualStyleBackColor = true;
            // 
            // Resoluciones_Disp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 412);
            this.Controls.Add(this.btnArchivo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgResolucionesDisposiciones);
            this.Name = "Resoluciones_Disp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resoluciones y Disposiciones";
            this.Load += new System.EventHandler(this.ResolucionesDisposiciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResolucionesDisposiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgResolucionesDisposiciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
    }
}

