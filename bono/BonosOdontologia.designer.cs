namespace SOCIOS.bono
{
    partial class BonosOdontologia
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
            this.dgBonos = new System.Windows.Forms.DataGridView();
            this.Imprimir = new System.Windows.Forms.Button();
            this.Anular = new System.Windows.Forms.Button();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBonos
            // 
            this.dgBonos.AllowUserToAddRows = false;
            this.dgBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBonos.Location = new System.Drawing.Point(12, 35);
            this.dgBonos.Name = "dgBonos";
            this.dgBonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBonos.Size = new System.Drawing.Size(697, 385);
            this.dgBonos.TabIndex = 0;
            this.dgBonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBonos_CellClick);
            this.dgBonos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBonos_CellContentClick);
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(12, 446);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(75, 23);
            this.Imprimir.TabIndex = 1;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // Anular
            // 
            this.Anular.Location = new System.Drawing.Point(629, 446);
            this.Anular.Name = "Anular";
            this.Anular.Size = new System.Drawing.Size(75, 23);
            this.Anular.TabIndex = 2;
            this.Anular.Text = "Anular";
            this.Anular.UseVisualStyleBackColor = true;
            this.Anular.Click += new System.EventHandler(this.Anular_Click);
            // 
            // dpDesde
            // 
            this.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDesde.Location = new System.Drawing.Point(63, 5);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(88, 20);
            this.dpDesde.TabIndex = 77;
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(243, 5);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(88, 20);
            this.dpHasta.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "DESDE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "HASTA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "FILTRO";
            // 
            // cbFiltro
            // 
            this.cbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(411, 6);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(130, 21);
            this.cbFiltro.TabIndex = 87;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(583, 6);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(95, 23);
            this.btnFiltro.TabIndex = 88;
            this.btnFiltro.Text = "BUSCAR";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // BonosOdontologia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 481);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.cbFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpHasta);
            this.Controls.Add(this.dpDesde);
            this.Controls.Add(this.Anular);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.dgBonos);
            this.Name = "BonosOdontologia";
            this.Text = "Bonos Odontologicos";
            ((System.ComponentModel.ISupportInitialize)(this.dgBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBonos;
        private System.Windows.Forms.Button Imprimir;
        private System.Windows.Forms.Button Anular;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.Button btnFiltro;
    }
}