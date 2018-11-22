namespace SOCIOS.Res_Disp
{
    partial class Resoluciones_Dispocisiones
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
            this.dgResu = new System.Windows.Forms.DataGridView();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.Buscar = new System.Windows.Forms.Label();
            this.tbTexto = new System.Windows.Forms.TextBox();
            this.Tipo = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboCriterio = new System.Windows.Forms.ComboBox();
            this.Nuevo = new System.Windows.Forms.Button();
            this.Modificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgResu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgResu
            // 
            this.dgResu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResu.Location = new System.Drawing.Point(3, 64);
            this.dgResu.MultiSelect = false;
            this.dgResu.Name = "dgResu";
            this.dgResu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResu.Size = new System.Drawing.Size(828, 158);
            this.dgResu.TabIndex = 0;
            this.dgResu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResu_CellContentClick);
            this.dgResu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgResu_CellFormatting);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(709, 35);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 1;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // Buscar
            // 
            this.Buscar.AutoSize = true;
            this.Buscar.Location = new System.Drawing.Point(13, 12);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(51, 13);
            this.Buscar.TabIndex = 2;
            this.Buscar.Text = "BUSCAR";
            // 
            // tbTexto
            // 
            this.tbTexto.Location = new System.Drawing.Point(70, 9);
            this.tbTexto.Name = "tbTexto";
            this.tbTexto.Size = new System.Drawing.Size(344, 20);
            this.tbTexto.TabIndex = 3;
            // 
            // Tipo
            // 
            this.Tipo.AutoSize = true;
            this.Tipo.Location = new System.Drawing.Point(420, 12);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(22, 13);
            this.Tipo.TabIndex = 4;
            this.Tipo.Text = "EN";
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(448, 8);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(147, 21);
            this.comboTipo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(601, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "POR";
            // 
            // ComboCriterio
            // 
            this.ComboCriterio.FormattingEnabled = true;
            this.ComboCriterio.Location = new System.Drawing.Point(637, 8);
            this.ComboCriterio.Name = "ComboCriterio";
            this.ComboCriterio.Size = new System.Drawing.Size(147, 21);
            this.ComboCriterio.TabIndex = 7;
            this.ComboCriterio.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Nuevo
            // 
            this.Nuevo.Image = global::SOCIOS.Properties.Resources.add;
            this.Nuevo.Location = new System.Drawing.Point(172, 228);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(36, 23);
            this.Nuevo.TabIndex = 8;
            this.Nuevo.UseVisualStyleBackColor = true;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // Modificar
            // 
            this.Modificar.Image = global::SOCIOS.Properties.Resources.application_edit;
            this.Modificar.Location = new System.Drawing.Point(214, 228);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(36, 23);
            this.Modificar.TabIndex = 10;
            this.Modificar.UseVisualStyleBackColor = true;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // Resoluciones_Dispocisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 330);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.ComboCriterio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.tbTexto);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.dgResu);
            this.Name = "Resoluciones_Dispocisiones";
            this.Text = "Resoluciones_Dispocisiones";
            ((System.ComponentModel.ISupportInitialize)(this.dgResu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgResu;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label Buscar;
        private System.Windows.Forms.TextBox tbTexto;
        private System.Windows.Forms.Label Tipo;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboCriterio;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Button Modificar;
    }
}