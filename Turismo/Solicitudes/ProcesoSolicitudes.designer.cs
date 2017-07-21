namespace SOCIOS.Turismo.Solicitudes
{
    partial class ProcesoSolicitudes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesoSolicitudes));
            this.tabSolicitudes = new System.Windows.Forms.TabControl();
            this.tbSolicitudes = new System.Windows.Forms.TabPage();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.Procesar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.gpUpdateSolicitud = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbDias = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gvSolicitudes = new System.Windows.Forms.DataGridView();
            this.tbHotel = new System.Windows.Forms.TabPage();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAlojamiento = new System.Windows.Forms.DataGridView();
            this.gpSolicitud = new System.Windows.Forms.GroupBox();
            this.lbTotalPersonas = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.btnMarcarDisponibilidad = new System.Windows.Forms.Button();
            this.dgvFechas = new System.Windows.Forms.DataGridView();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.gpMarca = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbPersonas = new System.Windows.Forms.Label();
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.DispoHoteles = new System.Windows.Forms.Button();
            this.tabSolicitudes.SuspendLayout();
            this.tbSolicitudes.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.gpUpdateSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudes)).BeginInit();
            this.tbHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlojamiento)).BeginInit();
            this.gpSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.gpMarca.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSolicitudes
            // 
            this.tabSolicitudes.Controls.Add(this.tbSolicitudes);
            this.tabSolicitudes.Controls.Add(this.tbHotel);
            this.tabSolicitudes.Location = new System.Drawing.Point(12, 12);
            this.tabSolicitudes.Name = "tabSolicitudes";
            this.tabSolicitudes.SelectedIndex = 0;
            this.tabSolicitudes.Size = new System.Drawing.Size(835, 508);
            this.tabSolicitudes.TabIndex = 0;
            // 
            // tbSolicitudes
            // 
            this.tbSolicitudes.Controls.Add(this.toolStrip4);
            this.tbSolicitudes.Controls.Add(this.gpUpdateSolicitud);
            this.tbSolicitudes.Controls.Add(this.gvSolicitudes);
            this.tbSolicitudes.Location = new System.Drawing.Point(4, 22);
            this.tbSolicitudes.Name = "tbSolicitudes";
            this.tbSolicitudes.Padding = new System.Windows.Forms.Padding(3);
            this.tbSolicitudes.Size = new System.Drawing.Size(827, 482);
            this.tbSolicitudes.TabIndex = 0;
            this.tbSolicitudes.Text = "Solicitudes";
            this.tbSolicitudes.UseVisualStyleBackColor = true;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Procesar,
            this.toolStripSeparator13,
            this.toolStripButton1,
            this.CancelarBank});
            this.toolStrip4.Location = new System.Drawing.Point(241, 226);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(223, 25);
            this.toolStrip4.TabIndex = 76;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // Procesar
            // 
            this.Procesar.Enabled = false;
            this.Procesar.Image = global::SOCIOS.Properties.Resources.bullet_green;
            this.Procesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Procesar.Name = "Procesar";
            this.Procesar.Size = new System.Drawing.Size(87, 22);
            this.Procesar.Text = "Seleccionar";
            this.Procesar.Click += new System.EventHandler(this.Procesar_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(78, 22);
            this.toolStripButton1.Text = "Modificar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // CancelarBank
            // 
            this.CancelarBank.Image = ((System.Drawing.Image)(resources.GetObject("CancelarBank.Image")));
            this.CancelarBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarBank.Name = "CancelarBank";
            this.CancelarBank.Size = new System.Drawing.Size(49, 22);
            this.CancelarBank.Text = "Baja";
            // 
            // gpUpdateSolicitud
            // 
            this.gpUpdateSolicitud.Controls.Add(this.btnUpdate);
            this.gpUpdateSolicitud.Controls.Add(this.lbDias);
            this.gpUpdateSolicitud.Controls.Add(this.cbTipo);
            this.gpUpdateSolicitud.Controls.Add(this.dpHasta);
            this.gpUpdateSolicitud.Controls.Add(this.dpDesde);
            this.gpUpdateSolicitud.Controls.Add(this.label3);
            this.gpUpdateSolicitud.Controls.Add(this.label4);
            this.gpUpdateSolicitud.Controls.Add(this.label2);
            this.gpUpdateSolicitud.Location = new System.Drawing.Point(154, 259);
            this.gpUpdateSolicitud.Name = "gpUpdateSolicitud";
            this.gpUpdateSolicitud.Size = new System.Drawing.Size(461, 196);
            this.gpUpdateSolicitud.TabIndex = 1;
            this.gpUpdateSolicitud.TabStop = false;
            this.gpUpdateSolicitud.Text = "gpSolicitud";
            this.gpUpdateSolicitud.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(358, 167);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 133;
            this.btnUpdate.Text = "Modificar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lbDias
            // 
            this.lbDias.AutoSize = true;
            this.lbDias.Location = new System.Drawing.Point(355, 103);
            this.lbDias.Name = "lbDias";
            this.lbDias.Size = new System.Drawing.Size(34, 13);
            this.lbDias.TabIndex = 132;
            this.lbDias.Text = "[Dias]";
            // 
            // cbTipo
            // 
            this.cbTipo.BackColor = System.Drawing.Color.White;
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(107, 40);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(233, 21);
            this.cbTipo.TabIndex = 131;
            // 
            // dpHasta
            // 
            this.dpHasta.Location = new System.Drawing.Point(107, 130);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(233, 20);
            this.dpHasta.TabIndex = 130;
            this.dpHasta.ValueChanged += new System.EventHandler(this.dpHasta_ValueChanged);
            // 
            // dpDesde
            // 
            this.dpDesde.Location = new System.Drawing.Point(107, 86);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(233, 20);
            this.dpDesde.TabIndex = 129;
            this.dpDesde.ValueChanged += new System.EventHandler(this.dpDesde_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 126;
            this.label2.Text = "Tipo Habitacion";
            // 
            // gvSolicitudes
            // 
            this.gvSolicitudes.AllowUserToAddRows = false;
            this.gvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSolicitudes.Location = new System.Drawing.Point(6, 54);
            this.gvSolicitudes.MultiSelect = false;
            this.gvSolicitudes.Name = "gvSolicitudes";
            this.gvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSolicitudes.Size = new System.Drawing.Size(798, 159);
            this.gvSolicitudes.TabIndex = 0;
            this.gvSolicitudes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSolicitudes_CellClick);
            this.gvSolicitudes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSolicitudes_CellContentClick);
            this.gvSolicitudes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvSolicitudes_CellFormatting);
            // 
            // tbHotel
            // 
            this.tbHotel.Controls.Add(this.btnConfirmar);
            this.tbHotel.Controls.Add(this.label1);
            this.tbHotel.Controls.Add(this.dgvAlojamiento);
            this.tbHotel.Controls.Add(this.gpSolicitud);
            this.tbHotel.Controls.Add(this.gpMarca);
            this.tbHotel.Location = new System.Drawing.Point(4, 22);
            this.tbHotel.Name = "tbHotel";
            this.tbHotel.Padding = new System.Windows.Forms.Padding(3);
            this.tbHotel.Size = new System.Drawing.Size(827, 482);
            this.tbHotel.TabIndex = 1;
            this.tbHotel.Text = "Hotel";
            this.tbHotel.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(524, 433);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(163, 23);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SELECCIONE DISPONIBILIDAD EN BASE A CANTIDAD PERSONAS Y FECHA";
            // 
            // dgvAlojamiento
            // 
            this.dgvAlojamiento.AllowUserToAddRows = false;
            this.dgvAlojamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlojamiento.Location = new System.Drawing.Point(12, 287);
            this.dgvAlojamiento.Name = "dgvAlojamiento";
            this.dgvAlojamiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlojamiento.Size = new System.Drawing.Size(503, 117);
            this.dgvAlojamiento.TabIndex = 2;
            // 
            // gpSolicitud
            // 
            this.gpSolicitud.Controls.Add(this.lbTotalPersonas);
            this.gpSolicitud.Controls.Add(this.l);
            this.gpSolicitud.Controls.Add(this.btnMarcarDisponibilidad);
            this.gpSolicitud.Controls.Add(this.dgvFechas);
            this.gpSolicitud.Controls.Add(this.dgvPersonas);
            this.gpSolicitud.Location = new System.Drawing.Point(6, 32);
            this.gpSolicitud.Name = "gpSolicitud";
            this.gpSolicitud.Size = new System.Drawing.Size(804, 232);
            this.gpSolicitud.TabIndex = 1;
            this.gpSolicitud.TabStop = false;
            this.gpSolicitud.Enter += new System.EventHandler(this.gpSolicitud_Enter);
            // 
            // lbTotalPersonas
            // 
            this.lbTotalPersonas.AutoSize = true;
            this.lbTotalPersonas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTotalPersonas.Location = new System.Drawing.Point(214, 31);
            this.lbTotalPersonas.Name = "lbTotalPersonas";
            this.lbTotalPersonas.Size = new System.Drawing.Size(13, 13);
            this.lbTotalPersonas.TabIndex = 7;
            this.lbTotalPersonas.Text = "0";
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(6, 31);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(202, 13);
            this.l.TabIndex = 6;
            this.l.Text = "CANTIDAD DE PERSONAS SOLICITUD";
            // 
            // btnMarcarDisponibilidad
            // 
            this.btnMarcarDisponibilidad.Location = new System.Drawing.Point(518, 198);
            this.btnMarcarDisponibilidad.Name = "btnMarcarDisponibilidad";
            this.btnMarcarDisponibilidad.Size = new System.Drawing.Size(142, 23);
            this.btnMarcarDisponibilidad.TabIndex = 6;
            this.btnMarcarDisponibilidad.Text = "Marcar Disponibilidad";
            this.btnMarcarDisponibilidad.UseVisualStyleBackColor = true;
            this.btnMarcarDisponibilidad.Click += new System.EventHandler(this.btnMarcarDisponibilidad_Click);
            // 
            // dgvFechas
            // 
            this.dgvFechas.AllowUserToAddRows = false;
            this.dgvFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFechas.Location = new System.Drawing.Point(673, 31);
            this.dgvFechas.Name = "dgvFechas";
            this.dgvFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFechas.Size = new System.Drawing.Size(125, 185);
            this.dgvFechas.TabIndex = 1;
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Location = new System.Drawing.Point(6, 66);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonas.Size = new System.Drawing.Size(503, 150);
            this.dgvPersonas.TabIndex = 0;
            // 
            // gpMarca
            // 
            this.gpMarca.Controls.Add(this.label5);
            this.gpMarca.Controls.Add(this.lbFecha);
            this.gpMarca.Controls.Add(this.lbPersonas);
            this.gpMarca.Controls.Add(this.btnDisponibilidad);
            this.gpMarca.Location = new System.Drawing.Point(524, 287);
            this.gpMarca.Name = "gpMarca";
            this.gpMarca.Size = new System.Drawing.Size(286, 117);
            this.gpMarca.TabIndex = 5;
            this.gpMarca.TabStop = false;
            this.gpMarca.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(38, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Personas";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbFecha.Location = new System.Drawing.Point(203, 32);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(51, 13);
            this.lbFecha.TabIndex = 4;
            this.lbFecha.Text = "Personas";
            // 
            // lbPersonas
            // 
            this.lbPersonas.AutoSize = true;
            this.lbPersonas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbPersonas.Location = new System.Drawing.Point(112, 32);
            this.lbPersonas.Name = "lbPersonas";
            this.lbPersonas.Size = new System.Drawing.Size(51, 13);
            this.lbPersonas.TabIndex = 3;
            this.lbPersonas.Text = "Personas";
            // 
            // btnDisponibilidad
            // 
            this.btnDisponibilidad.Location = new System.Drawing.Point(86, 63);
            this.btnDisponibilidad.Name = "btnDisponibilidad";
            this.btnDisponibilidad.Size = new System.Drawing.Size(107, 23);
            this.btnDisponibilidad.TabIndex = 2;
            this.btnDisponibilidad.Text = "Marcar ";
            this.btnDisponibilidad.UseVisualStyleBackColor = true;
            this.btnDisponibilidad.Click += new System.EventHandler(this.btnDisponibilidad_Click);
            // 
            // DispoHoteles
            // 
            this.DispoHoteles.Location = new System.Drawing.Point(673, 526);
            this.DispoHoteles.Name = "DispoHoteles";
            this.DispoHoteles.Size = new System.Drawing.Size(170, 23);
            this.DispoHoteles.TabIndex = 1;
            this.DispoHoteles.Text = "Dispo Hoteles";
            this.DispoHoteles.UseVisualStyleBackColor = true;
            this.DispoHoteles.Click += new System.EventHandler(this.DispoHoteles_Click);
            // 
            // ProcesoSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 558);
            this.Controls.Add(this.DispoHoteles);
            this.Controls.Add(this.tabSolicitudes);
            this.Name = "ProcesoSolicitudes";
            this.Text = "SolicitudesABM";
            this.tabSolicitudes.ResumeLayout(false);
            this.tbSolicitudes.ResumeLayout(false);
            this.tbSolicitudes.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.gpUpdateSolicitud.ResumeLayout(false);
            this.gpUpdateSolicitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudes)).EndInit();
            this.tbHotel.ResumeLayout(false);
            this.tbHotel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlojamiento)).EndInit();
            this.gpSolicitud.ResumeLayout(false);
            this.gpSolicitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.gpMarca.ResumeLayout(false);
            this.gpMarca.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSolicitudes;
        private System.Windows.Forms.TabPage tbSolicitudes;
        private System.Windows.Forms.DataGridView gvSolicitudes;
        private System.Windows.Forms.TabPage tbHotel;
        private System.Windows.Forms.GroupBox gpUpdateSolicitud;
        private System.Windows.Forms.Label lbDias;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton Procesar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAlojamiento;
        private System.Windows.Forms.GroupBox gpSolicitud;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbPersonas;
        private System.Windows.Forms.Button btnDisponibilidad;
        private System.Windows.Forms.DataGridView dgvFechas;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.Button btnMarcarDisponibilidad;
        private System.Windows.Forms.GroupBox gpMarca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTotalPersonas;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button DispoHoteles;
    }
}