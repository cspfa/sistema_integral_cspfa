namespace SOCIOS.Turismo
{
    partial class AgregarLocalidad
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
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.dgvLocalidad = new System.Windows.Forms.DataGridView();
            this.gpAgregar = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tbAbrev = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalidad)).BeginInit();
            this.gpAgregar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbProvincia
            // 
            this.cbProvincia.BackColor = System.Drawing.Color.White;
            this.cbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvincia.FormattingEnabled = true;
            this.cbProvincia.Location = new System.Drawing.Point(12, 12);
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(286, 21);
            this.cbProvincia.TabIndex = 119;
            this.cbProvincia.SelectedIndexChanged += new System.EventHandler(this.cbProvincia_SelectedIndexChanged);
            // 
            // dgvLocalidad
            // 
            this.dgvLocalidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalidad.Location = new System.Drawing.Point(12, 39);
            this.dgvLocalidad.Name = "dgvLocalidad";
            this.dgvLocalidad.Size = new System.Drawing.Size(286, 150);
            this.dgvLocalidad.TabIndex = 120;
            // 
            // gpAgregar
            // 
            this.gpAgregar.Controls.Add(this.btnAgregar);
            this.gpAgregar.Controls.Add(this.tbAbrev);
            this.gpAgregar.Controls.Add(this.tbNombre);
            this.gpAgregar.Controls.Add(this.label2);
            this.gpAgregar.Controls.Add(this.label1);
            this.gpAgregar.Location = new System.Drawing.Point(304, 12);
            this.gpAgregar.Name = "gpAgregar";
            this.gpAgregar.Size = new System.Drawing.Size(174, 177);
            this.gpAgregar.TabIndex = 121;
            this.gpAgregar.TabStop = false;
            this.gpAgregar.Text = "Nueva Localidad";
            // 
            // btnAgregar
            // 
            this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAgregar.Location = new System.Drawing.Point(6, 133);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(158, 29);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tbAbrev
            // 
            this.tbAbrev.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAbrev.Location = new System.Drawing.Point(6, 95);
            this.tbAbrev.Name = "tbAbrev";
            this.tbAbrev.Size = new System.Drawing.Size(158, 20);
            this.tbAbrev.TabIndex = 3;
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Location = new System.Drawing.Point(10, 44);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(158, 20);
            this.tbNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Abreviatura";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // AgregarLocalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 202);
            this.Controls.Add(this.gpAgregar);
            this.Controls.Add(this.dgvLocalidad);
            this.Controls.Add(this.cbProvincia);
            this.Name = "AgregarLocalidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarLocalidad";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalidad)).EndInit();
            this.gpAgregar.ResumeLayout(false);
            this.gpAgregar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProvincia;
        private System.Windows.Forms.DataGridView dgvLocalidad;
        private System.Windows.Forms.GroupBox gpAgregar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox tbAbrev;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}