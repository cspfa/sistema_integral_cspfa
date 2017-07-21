namespace SOCIOS
{
    partial class datosBancarios
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
            this.CBBAJA = new System.Windows.Forms.CheckBox();
            this.BTNMODI = new System.Windows.Forms.Button();
            this.BTNNUEVO = new System.Windows.Forms.Button();
            this.TBIDTITULAR = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.DPBAJA = new System.Windows.Forms.DateTimePicker();
            this.DPALTA = new System.Windows.Forms.DateTimePicker();
            this.TBCODIGO = new System.Windows.Forms.TextBox();
            this.TBSECUENCIA = new System.Windows.Forms.TextBox();
            this.TBBANCO = new System.Windows.Forms.TextBox();
            this.TBVENCIMIENTO = new System.Windows.Forms.TextBox();
            this.TBTC = new System.Windows.Forms.TextBox();
            this.TBCBU = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.lvBancariosCargados = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.TBIDADHERENTE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBIDFAMILIAR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CBBAJA
            // 
            this.CBBAJA.AutoSize = true;
            this.CBBAJA.Location = new System.Drawing.Point(337, 242);
            this.CBBAJA.Name = "CBBAJA";
            this.CBBAJA.Size = new System.Drawing.Size(15, 14);
            this.CBBAJA.TabIndex = 50;
            this.CBBAJA.UseVisualStyleBackColor = true;
            this.CBBAJA.CheckedChanged += new System.EventHandler(this.CBBAJA_CheckedChanged);
            // 
            // BTNMODI
            // 
            this.BTNMODI.Enabled = false;
            this.BTNMODI.Location = new System.Drawing.Point(752, 238);
            this.BTNMODI.Name = "BTNMODI";
            this.BTNMODI.Size = new System.Drawing.Size(125, 23);
            this.BTNMODI.TabIndex = 49;
            this.BTNMODI.Text = "MODIFICAR";
            this.BTNMODI.UseVisualStyleBackColor = true;
            this.BTNMODI.Click += new System.EventHandler(this.BTNMODI_Click);
            // 
            // BTNNUEVO
            // 
            this.BTNNUEVO.Location = new System.Drawing.Point(752, 185);
            this.BTNNUEVO.Name = "BTNNUEVO";
            this.BTNNUEVO.Size = new System.Drawing.Size(125, 23);
            this.BTNNUEVO.TabIndex = 48;
            this.BTNNUEVO.Text = "NUEVO";
            this.BTNNUEVO.UseVisualStyleBackColor = true;
            this.BTNNUEVO.Click += new System.EventHandler(this.BTNNUEVO_Click);
            // 
            // TBIDTITULAR
            // 
            this.TBIDTITULAR.Enabled = false;
            this.TBIDTITULAR.Location = new System.Drawing.Point(461, 14);
            this.TBIDTITULAR.Name = "TBIDTITULAR";
            this.TBIDTITULAR.Size = new System.Drawing.Size(76, 20);
            this.TBIDTITULAR.TabIndex = 47;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(385, 18);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(70, 13);
            this.label61.TabIndex = 46;
            this.label61.Text = "ID_TITULAR";
            // 
            // DPBAJA
            // 
            this.DPBAJA.Enabled = false;
            this.DPBAJA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPBAJA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPBAJA.Location = new System.Drawing.Point(229, 239);
            this.DPBAJA.Name = "DPBAJA";
            this.DPBAJA.Size = new System.Drawing.Size(101, 20);
            this.DPBAJA.TabIndex = 45;
            // 
            // DPALTA
            // 
            this.DPALTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPALTA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPALTA.Location = new System.Drawing.Point(24, 239);
            this.DPALTA.Name = "DPALTA";
            this.DPALTA.Size = new System.Drawing.Size(101, 20);
            this.DPALTA.TabIndex = 44;
            // 
            // TBCODIGO
            // 
            this.TBCODIGO.Location = new System.Drawing.Point(542, 239);
            this.TBCODIGO.Name = "TBCODIGO";
            this.TBCODIGO.Size = new System.Drawing.Size(76, 20);
            this.TBCODIGO.TabIndex = 43;
            // 
            // TBSECUENCIA
            // 
            this.TBSECUENCIA.Enabled = false;
            this.TBSECUENCIA.Location = new System.Drawing.Point(440, 239);
            this.TBSECUENCIA.Name = "TBSECUENCIA";
            this.TBSECUENCIA.Size = new System.Drawing.Size(76, 20);
            this.TBSECUENCIA.TabIndex = 42;
            // 
            // TBBANCO
            // 
            this.TBBANCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBBANCO.Location = new System.Drawing.Point(542, 186);
            this.TBBANCO.Name = "TBBANCO";
            this.TBBANCO.Size = new System.Drawing.Size(186, 20);
            this.TBBANCO.TabIndex = 41;
            // 
            // TBVENCIMIENTO
            // 
            this.TBVENCIMIENTO.Location = new System.Drawing.Point(440, 186);
            this.TBVENCIMIENTO.MaxLength = 4;
            this.TBVENCIMIENTO.Name = "TBVENCIMIENTO";
            this.TBVENCIMIENTO.Size = new System.Drawing.Size(76, 20);
            this.TBVENCIMIENTO.TabIndex = 40;
            // 
            // TBTC
            // 
            this.TBTC.Location = new System.Drawing.Point(229, 186);
            this.TBTC.MaxLength = 16;
            this.TBTC.Name = "TBTC";
            this.TBTC.Size = new System.Drawing.Size(186, 20);
            this.TBTC.TabIndex = 39;
            // 
            // TBCBU
            // 
            this.TBCBU.Location = new System.Drawing.Point(24, 186);
            this.TBCBU.MaxLength = 22;
            this.TBCBU.Name = "TBCBU";
            this.TBCBU.Size = new System.Drawing.Size(186, 20);
            this.TBCBU.TabIndex = 38;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(440, 163);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(77, 13);
            this.label75.TabIndex = 37;
            this.label75.Text = "VENC (MMAA)";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(542, 163);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(44, 13);
            this.label74.TabIndex = 36;
            this.label74.Text = "BANCO";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(226, 163);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(100, 13);
            this.label73.TabIndex = 35;
            this.label73.Text = "NRO DE TARJETA";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(226, 216);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(71, 13);
            this.label72.TabIndex = 34;
            this.label72.Text = "FECHA BAJA";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(542, 216);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(49, 13);
            this.label71.TabIndex = 33;
            this.label71.Text = "CODIGO";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(440, 216);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(68, 13);
            this.label69.TabIndex = 32;
            this.label69.Text = "SECUENCIA";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(24, 216);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(72, 13);
            this.label65.TabIndex = 31;
            this.label65.Text = "FECHA ALTA";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(24, 163);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(29, 13);
            this.label62.TabIndex = 30;
            this.label62.Text = "CBU";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(24, 18);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(172, 13);
            this.label60.TabIndex = 29;
            this.label60.Text = "DATOS BANCARIOS CARGADOS";
            // 
            // lvBancariosCargados
            // 
            this.lvBancariosCargados.BackColor = System.Drawing.Color.White;
            this.lvBancariosCargados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvBancariosCargados.CausesValidation = false;
            this.lvBancariosCargados.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBancariosCargados.FullRowSelect = true;
            this.lvBancariosCargados.HideSelection = false;
            this.lvBancariosCargados.Location = new System.Drawing.Point(2, 45);
            this.lvBancariosCargados.Margin = new System.Windows.Forms.Padding(0);
            this.lvBancariosCargados.MultiSelect = false;
            this.lvBancariosCargados.Name = "lvBancariosCargados";
            this.lvBancariosCargados.ParentContainer = null;
            this.lvBancariosCargados.ShowItemToolTips = true;
            this.lvBancariosCargados.Size = new System.Drawing.Size(890, 90);
            this.lvBancariosCargados.TabIndex = 28;
            this.lvBancariosCargados.UseCompatibleStateImageBehavior = false;
            this.lvBancariosCargados.View = System.Windows.Forms.View.Details;
            this.lvBancariosCargados.Click += new System.EventHandler(this.lvBancariosCargados_Click);
            // 
            // TBIDADHERENTE
            // 
            this.TBIDADHERENTE.Enabled = false;
            this.TBIDADHERENTE.Location = new System.Drawing.Point(640, 14);
            this.TBIDADHERENTE.Name = "TBIDADHERENTE";
            this.TBIDADHERENTE.Size = new System.Drawing.Size(76, 20);
            this.TBIDADHERENTE.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(543, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "ID_ADHERENTE";
            // 
            // TBIDFAMILIAR
            // 
            this.TBIDFAMILIAR.Enabled = false;
            this.TBIDFAMILIAR.Location = new System.Drawing.Point(801, 14);
            this.TBIDFAMILIAR.Name = "TBIDFAMILIAR";
            this.TBIDFAMILIAR.Size = new System.Drawing.Size(76, 20);
            this.TBIDFAMILIAR.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(722, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "ID_FAMILIAR";
            // 
            // cbTipoTarjeta
            // 
            this.cbTipoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoTarjeta.FormattingEnabled = true;
            this.cbTipoTarjeta.Location = new System.Drawing.Point(624, 239);
            this.cbTipoTarjeta.Name = "cbTipoTarjeta";
            this.cbTipoTarjeta.Size = new System.Drawing.Size(104, 21);
            this.cbTipoTarjeta.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(648, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "TIPO TARJETA";
            // 
            // datosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 276);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTipoTarjeta);
            this.Controls.Add(this.TBIDFAMILIAR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBIDADHERENTE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBBAJA);
            this.Controls.Add(this.BTNMODI);
            this.Controls.Add(this.BTNNUEVO);
            this.Controls.Add(this.TBIDTITULAR);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.DPBAJA);
            this.Controls.Add(this.DPALTA);
            this.Controls.Add(this.TBCODIGO);
            this.Controls.Add(this.TBSECUENCIA);
            this.Controls.Add(this.TBBANCO);
            this.Controls.Add(this.TBVENCIMIENTO);
            this.Controls.Add(this.TBTC);
            this.Controls.Add(this.TBCBU);
            this.Controls.Add(this.label75);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.lvBancariosCargados);
            this.Name = "datosBancarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM DATOS BANCARIOS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CBBAJA;
        private System.Windows.Forms.Button BTNMODI;
        private System.Windows.Forms.Button BTNNUEVO;
        private System.Windows.Forms.TextBox TBIDTITULAR;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.DateTimePicker DPBAJA;
        private System.Windows.Forms.DateTimePicker DPALTA;
        private System.Windows.Forms.TextBox TBCODIGO;
        private System.Windows.Forms.TextBox TBSECUENCIA;
        private System.Windows.Forms.TextBox TBBANCO;
        private System.Windows.Forms.TextBox TBVENCIMIENTO;
        private System.Windows.Forms.TextBox TBTC;
        private System.Windows.Forms.TextBox TBCBU;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label60;
        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvBancariosCargados;
        private System.Windows.Forms.TextBox TBIDADHERENTE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBIDFAMILIAR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoTarjeta;
        private System.Windows.Forms.Label label3;

    }
}