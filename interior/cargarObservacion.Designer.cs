namespace SOCIOS
{
    partial class cargarObservacion
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
            this.lvDatosSocio = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tbObservacion = new System.Windows.Forms.TextBox();
            this.lvObservaciones = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FECHA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OBSERVACION = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvDatosSocio
            // 
            this.lvDatosSocio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvDatosSocio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDatosSocio.CausesValidation = false;
            this.lvDatosSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDatosSocio.FullRowSelect = true;
            this.lvDatosSocio.HideSelection = false;
            this.lvDatosSocio.Location = new System.Drawing.Point(9, 9);
            this.lvDatosSocio.Margin = new System.Windows.Forms.Padding(0);
            this.lvDatosSocio.MultiSelect = false;
            this.lvDatosSocio.Name = "lvDatosSocio";
            this.lvDatosSocio.ParentContainer = null;
            this.lvDatosSocio.ShowItemToolTips = true;
            this.lvDatosSocio.Size = new System.Drawing.Size(663, 44);
            this.lvDatosSocio.TabIndex = 4;
            this.lvDatosSocio.UseCompatibleStateImageBehavior = false;
            this.lvDatosSocio.View = System.Windows.Forms.View.Details;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(495, 61);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(177, 30);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "AGREGAR OBSERVACION";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tbObservacion
            // 
            this.tbObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservacion.Location = new System.Drawing.Point(9, 66);
            this.tbObservacion.Name = "tbObservacion";
            this.tbObservacion.Size = new System.Drawing.Size(479, 20);
            this.tbObservacion.TabIndex = 6;
            // 
            // lvObservaciones
            // 
            this.lvObservaciones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvObservaciones.CausesValidation = false;
            this.lvObservaciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.FECHA,
            this.OBSERVACION});
            this.lvObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvObservaciones.FullRowSelect = true;
            this.lvObservaciones.HideSelection = false;
            this.lvObservaciones.Location = new System.Drawing.Point(9, 100);
            this.lvObservaciones.Margin = new System.Windows.Forms.Padding(0);
            this.lvObservaciones.MultiSelect = false;
            this.lvObservaciones.Name = "lvObservaciones";
            this.lvObservaciones.ParentContainer = null;
            this.lvObservaciones.ShowItemToolTips = true;
            this.lvObservaciones.Size = new System.Drawing.Size(663, 160);
            this.lvObservaciones.TabIndex = 7;
            this.lvObservaciones.UseCompatibleStateImageBehavior = false;
            this.lvObservaciones.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // FECHA
            // 
            this.FECHA.Text = "FECHA";
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.Text = "OBSERVACION";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(496, 269);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(177, 30);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "ELIMINAR OBSERVACION";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cargarObservacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 309);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lvObservaciones);
            this.Controls.Add(this.tbObservacion);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lvDatosSocio);
            this.Name = "cargarObservacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OBSERVACIONES INTERIOR Y FILIALES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvDatosSocio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox tbObservacion;
        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvObservaciones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader FECHA;
        private System.Windows.Forms.ColumnHeader OBSERVACION;
    }
}