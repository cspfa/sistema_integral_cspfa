namespace SOCIOS.bono.Bonos
{
    partial class Carga_Bono_Blanco_Socio
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btn_Bono = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.gpFecha = new System.Windows.Forms.GroupBox();
            this.gpID = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.cbFecha = new System.Windows.Forms.CheckBox();
            this.cbID = new System.Windows.Forms.CheckBox();
            this.Refrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.gpFecha.SuspendLayout();
            this.gpID.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 121);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(503, 214);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDatos_DataBindingComplete);
            // 
            // btn_Bono
            // 
            this.btn_Bono.Location = new System.Drawing.Point(132, 345);
            this.btn_Bono.Name = "btn_Bono";
            this.btn_Bono.Size = new System.Drawing.Size(103, 23);
            this.btn_Bono.TabIndex = 1;
            this.btn_Bono.Text = "COMPLETAR";
            this.btn_Bono.UseVisualStyleBackColor = true;
            this.btn_Bono.Click += new System.EventHandler(this.btn_Bono_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "HASTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "DESDE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(67, 48);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(88, 20);
            this.dpHasta.TabIndex = 82;
            // 
            // dpDesde
            // 
            this.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDesde.Location = new System.Drawing.Point(67, 19);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(88, 20);
            this.dpDesde.TabIndex = 81;
            // 
            // gpFecha
            // 
            this.gpFecha.Controls.Add(this.dpDesde);
            this.gpFecha.Controls.Add(this.label2);
            this.gpFecha.Controls.Add(this.label1);
            this.gpFecha.Controls.Add(this.dpHasta);
            this.gpFecha.Location = new System.Drawing.Point(12, 34);
            this.gpFecha.Name = "gpFecha";
            this.gpFecha.Size = new System.Drawing.Size(161, 74);
            this.gpFecha.TabIndex = 85;
            this.gpFecha.TabStop = false;
            this.gpFecha.Text = "Filtro Por Fecha";
            this.gpFecha.Visible = false;
            // 
            // gpID
            // 
            this.gpID.Controls.Add(this.label3);
            this.gpID.Controls.Add(this.tbID);
            this.gpID.Location = new System.Drawing.Point(179, 34);
            this.gpID.Name = "gpID";
            this.gpID.Size = new System.Drawing.Size(130, 53);
            this.gpID.TabIndex = 86;
            this.gpID.TabStop = false;
            this.gpID.Text = "Filtrar por ID";
            this.gpID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "SECUENCIA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(90, 19);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(32, 20);
            this.tbID.TabIndex = 0;
            // 
            // cbFecha
            // 
            this.cbFecha.AutoSize = true;
            this.cbFecha.Location = new System.Drawing.Point(21, 3);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(103, 17);
            this.cbFecha.TabIndex = 87;
            this.cbFecha.Text = "Filtrar Por Fecha";
            this.cbFecha.UseVisualStyleBackColor = true;
            this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
            // 
            // cbID
            // 
            this.cbID.AutoSize = true;
            this.cbID.Location = new System.Drawing.Point(179, 3);
            this.cbID.Name = "cbID";
            this.cbID.Size = new System.Drawing.Size(124, 17);
            this.cbID.TabIndex = 88;
            this.cbID.Text = "Filtrar por Numerador";
            this.cbID.UseVisualStyleBackColor = true;
            this.cbID.CheckedChanged += new System.EventHandler(this.cbID_CheckedChanged);
            // 
            // Refrescar
            // 
            this.Refrescar.Location = new System.Drawing.Point(180, 94);
            this.Refrescar.Name = "Refrescar";
            this.Refrescar.Size = new System.Drawing.Size(129, 23);
            this.Refrescar.TabIndex = 89;
            this.Refrescar.Text = "Fltrar";
            this.Refrescar.UseVisualStyleBackColor = true;
            this.Refrescar.Click += new System.EventHandler(this.Refrescar_Click);
            // 
            // Carga_Bono_Blanco_Socio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 380);
            this.Controls.Add(this.Refrescar);
            this.Controls.Add(this.cbID);
            this.Controls.Add(this.cbFecha);
            this.Controls.Add(this.gpID);
            this.Controls.Add(this.gpFecha);
            this.Controls.Add(this.btn_Bono);
            this.Controls.Add(this.dgvDatos);
            this.Name = "Carga_Bono_Blanco_Socio";
            this.Text = "Completar Bono Blanco";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.gpFecha.ResumeLayout(false);
            this.gpFecha.PerformLayout();
            this.gpID.ResumeLayout(false);
            this.gpID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btn_Bono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.GroupBox gpFecha;
        private System.Windows.Forms.GroupBox gpID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.CheckBox cbFecha;
        private System.Windows.Forms.CheckBox cbID;
        private System.Windows.Forms.Button Refrescar;
    }
}