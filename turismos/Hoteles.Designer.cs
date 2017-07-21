namespace SOCIOS.turismos
{
    partial class Hoteles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hoteles));
            this.gpHotel = new MicroFour.StrataFrame.UI.Windows.Forms.ThemedGroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbResponsable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCuit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEstrellas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDomicilio = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvHotel = new System.Windows.Forms.DataGridView();
            this.tbFiltro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.NuevoBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelarBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gpHotel)).BeginInit();
            this.gpHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotel)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpHotel
            // 
            this.gpHotel.BaseBackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpHotel.BorderColor = System.Drawing.Color.SteelBlue;
            this.gpHotel.Controls.Add(this.btnSave);
            this.gpHotel.Controls.Add(this.tbResponsable);
            this.gpHotel.Controls.Add(this.label4);
            this.gpHotel.Controls.Add(this.tbCuit);
            this.gpHotel.Controls.Add(this.label3);
            this.gpHotel.Controls.Add(this.cbEstrellas);
            this.gpHotel.Controls.Add(this.label2);
            this.gpHotel.Controls.Add(this.tbTelefono);
            this.gpHotel.Controls.Add(this.label1);
            this.gpHotel.Controls.Add(this.cbLocalidad);
            this.gpHotel.Controls.Add(this.cbProvincia);
            this.gpHotel.Controls.Add(this.tbObservaciones);
            this.gpHotel.Controls.Add(this.label14);
            this.gpHotel.Controls.Add(this.tbDomicilio);
            this.gpHotel.Controls.Add(this.tbNombre);
            this.gpHotel.Controls.Add(this.label13);
            this.gpHotel.Controls.Add(this.label12);
            this.gpHotel.Controls.Add(this.label11);
            this.gpHotel.Controls.Add(this.label10);
            this.gpHotel.CornerStyle = MicroFour.StrataFrame.UI.ThemedGroupBoxCornerType.Squared;
            this.gpHotel.GradientBegin = System.Drawing.Color.White;
            this.gpHotel.GradientEnd = System.Drawing.Color.White;
            this.gpHotel.Location = new System.Drawing.Point(12, 266);
            this.gpHotel.Name = "gpHotel";
            this.gpHotel.Size = new System.Drawing.Size(623, 237);
            this.gpHotel.TabIndex = 45;
            this.gpHotel.Title = "DATOS HOTEL";
            this.gpHotel.TitleHeadingGradientBegin = System.Drawing.Color.SteelBlue;
            this.gpHotel.TitleHeadingGradientEnd = System.Drawing.Color.SteelBlue;
            this.gpHotel.TitleShadow = false;
            this.gpHotel.TitleStyle = MicroFour.StrataFrame.UI.ThemedGroupBoxTitleType.HeadingInGroupBox;
            this.gpHotel.TitleTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpHotel.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(470, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Grabar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbResponsable
            // 
            this.tbResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbResponsable.Location = new System.Drawing.Point(470, 140);
            this.tbResponsable.Name = "tbResponsable";
            this.tbResponsable.Size = new System.Drawing.Size(148, 20);
            this.tbResponsable.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "RESPONSABLE";
            // 
            // tbCuit
            // 
            this.tbCuit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCuit.Location = new System.Drawing.Point(91, 139);
            this.tbCuit.Name = "tbCuit";
            this.tbCuit.Size = new System.Drawing.Size(158, 20);
            this.tbCuit.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "CUIT";
            // 
            // cbEstrellas
            // 
            this.cbEstrellas.FormattingEnabled = true;
            this.cbEstrellas.Location = new System.Drawing.Point(470, 108);
            this.cbEstrellas.Name = "cbEstrellas";
            this.cbEstrellas.Size = new System.Drawing.Size(82, 21);
            this.cbEstrellas.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "ESTRELLAS";
            // 
            // tbTelefono
            // 
            this.tbTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTelefono.Location = new System.Drawing.Point(91, 113);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(240, 20);
            this.tbTelefono.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "TELEFONO";
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.FormattingEnabled = true;
            this.cbLocalidad.Location = new System.Drawing.Point(414, 64);
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(204, 21);
            this.cbLocalidad.TabIndex = 22;
            // 
            // cbProvincia
            // 
            this.cbProvincia.FormattingEnabled = true;
            this.cbProvincia.Location = new System.Drawing.Point(91, 65);
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(217, 21);
            this.cbProvincia.TabIndex = 21;
            this.cbProvincia.SelectedIndexChanged += new System.EventHandler(this.cbProvincia_SelectedIndexChanged);
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Location = new System.Drawing.Point(91, 169);
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.Size = new System.Drawing.Size(527, 20);
            this.tbObservaciones.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 173);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "OBSERV.";
            // 
            // tbDomicilio
            // 
            this.tbDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDomicilio.Location = new System.Drawing.Point(91, 92);
            this.tbDomicilio.Name = "tbDomicilio";
            this.tbDomicilio.Size = new System.Drawing.Size(527, 20);
            this.tbDomicilio.TabIndex = 5;
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Location = new System.Drawing.Point(91, 38);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(527, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "DOMICILIO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(340, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "LOCALIDAD";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "PROVINCIA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "NOMBRE";
            // 
            // dgvHotel
            // 
            this.dgvHotel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHotel.Location = new System.Drawing.Point(13, 56);
            this.dgvHotel.Name = "dgvHotel";
            this.dgvHotel.Size = new System.Drawing.Size(622, 179);
            this.dgvHotel.TabIndex = 46;
            this.dgvHotel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHotel_CellContentClick);
            // 
            // tbFiltro
            // 
            this.tbFiltro.Location = new System.Drawing.Point(74, 16);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(165, 20);
            this.tbFiltro.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "FILTRO";
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(259, 16);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(135, 21);
            this.cbFiltro.TabIndex = 47;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(426, 14);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 48;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoBank,
            this.toolStripSeparator13,
            this.toolStripButton1,
            this.CancelarBank});
            this.toolStrip4.Location = new System.Drawing.Point(263, 238);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(229, 25);
            this.toolStrip4.TabIndex = 75;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // NuevoBank
            // 
            this.NuevoBank.Image = ((System.Drawing.Image)(resources.GetObject("NuevoBank.Image")));
            this.NuevoBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuevoBank.Name = "NuevoBank";
            this.NuevoBank.Size = new System.Drawing.Size(62, 22);
            this.NuevoBank.Text = "Nuevo";
            this.NuevoBank.Click += new System.EventHandler(this.NuevoBank_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // CancelarBank
            // 
            this.CancelarBank.Image = ((System.Drawing.Image)(resources.GetObject("CancelarBank.Image")));
            this.CancelarBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarBank.Name = "CancelarBank";
            this.CancelarBank.Size = new System.Drawing.Size(49, 22);
            this.CancelarBank.Text = "Baja";
            this.CancelarBank.Click += new System.EventHandler(this.CancelarBank_Click);
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
            // Hoteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(647, 515);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cbFiltro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbFiltro);
            this.Controls.Add(this.dgvHotel);
            this.Controls.Add(this.gpHotel);
            this.Name = "Hoteles";
            this.Text = "Hoteles";
            this.Load += new System.EventHandler(this.Hoteles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gpHotel)).EndInit();
            this.gpHotel.ResumeLayout(false);
            this.gpHotel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotel)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MicroFour.StrataFrame.UI.Windows.Forms.ThemedGroupBox gpHotel;
        private System.Windows.Forms.TextBox tbObservaciones;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbDomicilio;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbResponsable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEstrellas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLocalidad;
        private System.Windows.Forms.ComboBox cbProvincia;
        private System.Windows.Forms.DataGridView dgvHotel;
        private System.Windows.Forms.TextBox tbFiltro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton NuevoBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton CancelarBank;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}