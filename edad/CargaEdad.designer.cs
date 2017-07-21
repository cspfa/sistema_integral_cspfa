namespace SOCIOS
{
    partial class CargaEdad
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
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbApellido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTipo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbEdad = new System.Windows.Forms.Label();
            this.Grabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(114, 147);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(98, 20);
            this.dpFecha.TabIndex = 0;
            this.dpFecha.ValueChanged += new System.EventHandler(this.dpFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOMBRE";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(114, 22);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(35, 13);
            this.lbNombre.TabIndex = 2;
            this.lbNombre.Text = "label2";
            // 
            // lbApellido
            // 
            this.lbApellido.AutoSize = true;
            this.lbApellido.Location = new System.Drawing.Point(114, 65);
            this.lbApellido.Name = "lbApellido";
            this.lbApellido.Size = new System.Drawing.Size(35, 13);
            this.lbApellido.TabIndex = 4;
            this.lbApellido.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "APELLIDO";
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(114, 108);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(35, 13);
            this.lbTipo.TabIndex = 6;
            this.lbTipo.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "TIPO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "FECHA";
            // 
            // lbEdad
            // 
            this.lbEdad.AutoSize = true;
            this.lbEdad.Location = new System.Drawing.Point(114, 181);
            this.lbEdad.Name = "lbEdad";
            this.lbEdad.Size = new System.Drawing.Size(35, 13);
            this.lbEdad.TabIndex = 8;
            this.lbEdad.Text = "label8";
            // 
            // Grabar
            // 
            this.Grabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Grabar.Location = new System.Drawing.Point(166, 206);
            this.Grabar.Name = "Grabar";
            this.Grabar.Size = new System.Drawing.Size(167, 23);
            this.Grabar.TabIndex = 9;
            this.Grabar.Text = "GRABAR F. NACIMIENTO";
            this.Grabar.UseVisualStyleBackColor = true;
            this.Grabar.Click += new System.EventHandler(this.Grabar_Click);
            // 
            // CargaEdad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 241);
            this.Controls.Add(this.Grabar);
            this.Controls.Add(this.lbEdad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbTipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbApellido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpFecha);
            this.Name = "CargaEdad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODIFICAR EDAD DEL FAMILIAR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbEdad;
        private System.Windows.Forms.Button Grabar;
    }
}