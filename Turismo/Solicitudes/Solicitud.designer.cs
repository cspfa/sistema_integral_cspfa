namespace SOCIOS.Turismo.Solicitudes
{
    partial class Solicitud
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
            this.nvSolicitud = new System.Windows.Forms.Button();
            this.gpSolicitud = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbDias = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.gpSolicitud.SuspendLayout();
            this.SuspendLayout();
            // 
            // nvSolicitud
            // 
            this.nvSolicitud.Location = new System.Drawing.Point(38, 380);
            this.nvSolicitud.Name = "nvSolicitud";
            this.nvSolicitud.Size = new System.Drawing.Size(211, 23);
            this.nvSolicitud.TabIndex = 1;
            this.nvSolicitud.Text = "Nueva Solicitud";
            this.nvSolicitud.UseVisualStyleBackColor = true;
            this.nvSolicitud.Click += new System.EventHandler(this.nvSolicitud_Click);
            // 
            // gpSolicitud
            // 
            this.gpSolicitud.Controls.Add(this.label5);
            this.gpSolicitud.Controls.Add(this.lbDias);
            this.gpSolicitud.Controls.Add(this.btnGrabar);
            this.gpSolicitud.Controls.Add(this.cbTipo);
            this.gpSolicitud.Controls.Add(this.dpHasta);
            this.gpSolicitud.Controls.Add(this.dpDesde);
            this.gpSolicitud.Controls.Add(this.lbCantidad);
            this.gpSolicitud.Controls.Add(this.label3);
            this.gpSolicitud.Controls.Add(this.label4);
            this.gpSolicitud.Controls.Add(this.label2);
            this.gpSolicitud.Controls.Add(this.label1);
            this.gpSolicitud.Location = new System.Drawing.Point(38, 409);
            this.gpSolicitud.Name = "gpSolicitud";
            this.gpSolicitud.Size = new System.Drawing.Size(733, 190);
            this.gpSolicitud.TabIndex = 0;
            this.gpSolicitud.TabStop = false;
            this.gpSolicitud.Text = "Nueva Solicitud";
            this.gpSolicitud.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 126;
            this.label5.Text = "NOCHES";
            // 
            // lbDias
            // 
            this.lbDias.AutoSize = true;
            this.lbDias.Location = new System.Drawing.Point(316, 134);
            this.lbDias.Name = "lbDias";
            this.lbDias.Size = new System.Drawing.Size(34, 13);
            this.lbDias.TabIndex = 125;
            this.lbDias.Text = "[Dias]";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(497, 161);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(211, 23);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Grabar Solicitud";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cbTipo
            // 
            this.cbTipo.BackColor = System.Drawing.Color.White;
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(475, 47);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(233, 21);
            this.cbTipo.TabIndex = 124;
            // 
            // dpHasta
            // 
            this.dpHasta.Location = new System.Drawing.Point(475, 98);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(233, 20);
            this.dpHasta.TabIndex = 6;
            this.dpHasta.ValueChanged += new System.EventHandler(this.dpHasta_ValueChanged);
            // 
            // dpDesde
            // 
            this.dpDesde.Location = new System.Drawing.Point(151, 98);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(220, 20);
            this.dpDesde.TabIndex = 5;
            this.dpDesde.ValueChanged += new System.EventHandler(this.dpDesde_ValueChanged);
            // 
            // lbCantidad
            // 
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Location = new System.Drawing.Point(316, 50);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(55, 13);
            this.lbCantidad.TabIndex = 4;
            this.lbCantidad.Text = "[Cantidad]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo Habitacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad Personas";
            // 
            // btnAnular
            // 
            this.btnAnular.Enabled = false;
            this.btnAnular.Location = new System.Drawing.Point(287, 380);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(211, 23);
            this.btnAnular.TabIndex = 2;
            this.btnAnular.Text = "Reiniciar";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // Solicitud
            // 
            this.ClientSize = new System.Drawing.Size(829, 611);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.nvSolicitud);
            this.Controls.Add(this.gpSolicitud);
            this.Name = "Solicitud";
            this.gpSolicitud.ResumeLayout(false);
            this.gpSolicitud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpSolicitud;
        private System.Windows.Forms.Button nvSolicitud;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label lbDias;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Label label5;
    }
}
