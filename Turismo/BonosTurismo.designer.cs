namespace SOCIOS.bono
{
    partial class BonosTurismo
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
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBlanco = new System.Windows.Forms.CheckBox();
            this.btn_CARGAR_BONO_BLANCO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBonos
            // 
            this.dgBonos.AllowUserToAddRows = false;
            this.dgBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBonos.Location = new System.Drawing.Point(16, 80);
            this.dgBonos.Name = "dgBonos";
            this.dgBonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBonos.Size = new System.Drawing.Size(829, 323);
            this.dgBonos.TabIndex = 0;
            this.dgBonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBonos_CellClick);
            this.dgBonos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBonos_CellContentClick);
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(581, 409);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(130, 30);
            this.Imprimir.TabIndex = 1;
            this.Imprimir.Text = "IMPRIMIR BONO";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // Anular
            // 
            this.Anular.Location = new System.Drawing.Point(717, 409);
            this.Anular.Name = "Anular";
            this.Anular.Size = new System.Drawing.Size(130, 30);
            this.Anular.TabIndex = 2;
            this.Anular.Text = "ANULAR BONO";
            this.Anular.UseVisualStyleBackColor = true;
            this.Anular.Click += new System.EventHandler(this.Anular_Click);
            // 
            // dpDesde
            // 
            this.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDesde.Location = new System.Drawing.Point(72, 17);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(88, 20);
            this.dpDesde.TabIndex = 77;
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(233, 17);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(88, 20);
            this.dpHasta.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "DESDE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "HASTA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "FILTRO";
            // 
            // cbFiltro
            // 
            this.cbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(396, 17);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(130, 21);
            this.cbFiltro.TabIndex = 87;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(752, 16);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(95, 23);
            this.btnFiltro.TabIndex = 88;
            this.btnFiltro.Text = "BUSCAR";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(607, 17);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(130, 21);
            this.cbEstado.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "ESTADO";
            // 
            // chkBlanco
            // 
            this.chkBlanco.AutoSize = true;
            this.chkBlanco.Location = new System.Drawing.Point(607, 57);
            this.chkBlanco.Name = "chkBlanco";
            this.chkBlanco.Size = new System.Drawing.Size(128, 17);
            this.chkBlanco.TabIndex = 91;
            this.chkBlanco.Text = "BONOS EN BLANCO";
            this.chkBlanco.UseVisualStyleBackColor = true;
            // 
            // btn_CARGAR_BONO_BLANCO
            // 
            this.btn_CARGAR_BONO_BLANCO.Location = new System.Drawing.Point(448, 409);
            this.btn_CARGAR_BONO_BLANCO.Name = "btn_CARGAR_BONO_BLANCO";
            this.btn_CARGAR_BONO_BLANCO.Size = new System.Drawing.Size(118, 30);
            this.btn_CARGAR_BONO_BLANCO.TabIndex = 92;
            this.btn_CARGAR_BONO_BLANCO.Text = "CARGAR BONO";
            this.btn_CARGAR_BONO_BLANCO.UseVisualStyleBackColor = true;
            this.btn_CARGAR_BONO_BLANCO.Visible = false;
            this.btn_CARGAR_BONO_BLANCO.Click += new System.EventHandler(this.btn_CARGAR_BONO_BLANCO_Click);
            // 
            // BonosTurismo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.btn_CARGAR_BONO_BLANCO);
            this.Controls.Add(this.chkBlanco);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.label4);
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
            this.Name = "BonosTurismo";
            this.Text = "Bonos Turismo";
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
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBlanco;
        private System.Windows.Forms.Button btn_CARGAR_BONO_BLANCO;
    }
}