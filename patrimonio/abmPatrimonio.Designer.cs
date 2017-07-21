namespace SOCIOS
{
    partial class abmPatrimonio
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
            this.dgPatrimonio = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIV_PATR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOMICILIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LATITUD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LONGITUD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTipo = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.cbDivPatrimonio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevoPatrimonio = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLongitud = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbLatitud = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDomicilio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCP = new System.Windows.Forms.TextBox();
            this.cbProvincias = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatrimonio)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPatrimonio
            // 
            this.dgPatrimonio.AllowUserToAddRows = false;
            this.dgPatrimonio.AllowUserToDeleteRows = false;
            this.dgPatrimonio.AllowUserToResizeColumns = false;
            this.dgPatrimonio.AllowUserToResizeRows = false;
            this.dgPatrimonio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPatrimonio.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgPatrimonio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPatrimonio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatrimonio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TIPO,
            this.DIV_PATR,
            this.NUMERO,
            this.NOMBRE,
            this.DOMICILIO,
            this.LATITUD,
            this.LONGITUD});
            this.dgPatrimonio.Location = new System.Drawing.Point(12, 12);
            this.dgPatrimonio.Name = "dgPatrimonio";
            this.dgPatrimonio.RowHeadersVisible = false;
            this.dgPatrimonio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatrimonio.Size = new System.Drawing.Size(508, 351);
            this.dgPatrimonio.TabIndex = 0;
            this.dgPatrimonio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatrimonio_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 24;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.Width = 57;
            // 
            // DIV_PATR
            // 
            this.DIV_PATR.HeaderText = "DIV_PATR";
            this.DIV_PATR.Name = "DIV_PATR";
            this.DIV_PATR.Width = 85;
            // 
            // NUMERO
            // 
            this.NUMERO.HeaderText = "NUMERO";
            this.NUMERO.Name = "NUMERO";
            this.NUMERO.Width = 80;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Width = 79;
            // 
            // DOMICILIO
            // 
            this.DOMICILIO.HeaderText = "DOMICILIO";
            this.DOMICILIO.Name = "DOMICILIO";
            this.DOMICILIO.Width = 87;
            // 
            // LATITUD
            // 
            this.LATITUD.HeaderText = "LATITUD";
            this.LATITUD.Name = "LATITUD";
            this.LATITUD.Visible = false;
            this.LATITUD.Width = 78;
            // 
            // LONGITUD
            // 
            this.LONGITUD.HeaderText = "LONGITUD";
            this.LONGITUD.Name = "LONGITUD";
            this.LONGITUD.Visible = false;
            this.LONGITUD.Width = 88;
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(43, 30);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(32, 13);
            this.lbTipo.TabIndex = 2;
            this.lbTipo.Text = "TIPO";
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(79, 26);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(249, 21);
            this.cbTipo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "NOMBRE";
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Location = new System.Drawing.Point(79, 53);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(249, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // cbDivPatrimonio
            // 
            this.cbDivPatrimonio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDivPatrimonio.FormattingEnabled = true;
            this.cbDivPatrimonio.Location = new System.Drawing.Point(371, 26);
            this.cbDivPatrimonio.Name = "cbDivPatrimonio";
            this.cbDivPatrimonio.Size = new System.Drawing.Size(177, 21);
            this.cbDivPatrimonio.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "DIV";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbProvincias);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbCP);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnNuevoPatrimonio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbLongitud);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbLatitud);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbDomicilio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNumero);
            this.groupBox1.Controls.Add(this.cbTipo);
            this.groupBox1.Controls.Add(this.cbDivPatrimonio);
            this.groupBox1.Controls.Add(this.lbTipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbNombre);
            this.groupBox1.Location = new System.Drawing.Point(526, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 168);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ABM PATRIMONIO";
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(462, 131);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(86, 23);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevoPatrimonio
            // 
            this.btnNuevoPatrimonio.Location = new System.Drawing.Point(371, 131);
            this.btnNuevoPatrimonio.Name = "btnNuevoPatrimonio";
            this.btnNuevoPatrimonio.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoPatrimonio.TabIndex = 7;
            this.btnNuevoPatrimonio.Text = "NUEVO";
            this.btnNuevoPatrimonio.UseVisualStyleBackColor = true;
            this.btnNuevoPatrimonio.Click += new System.EventHandler(this.btnNuevoPatrimonio_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "LON";
            // 
            // tbLongitud
            // 
            this.tbLongitud.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbLongitud.Location = new System.Drawing.Point(371, 78);
            this.tbLongitud.Name = "tbLongitud";
            this.tbLongitud.Size = new System.Drawing.Size(177, 20);
            this.tbLongitud.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "LAT";
            // 
            // tbLatitud
            // 
            this.tbLatitud.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbLatitud.Location = new System.Drawing.Point(371, 53);
            this.tbLatitud.Name = "tbLatitud";
            this.tbLatitud.Size = new System.Drawing.Size(177, 20);
            this.tbLatitud.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "DOMICILIO";
            // 
            // tbDomicilio
            // 
            this.tbDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDomicilio.Location = new System.Drawing.Point(79, 78);
            this.tbDomicilio.Name = "tbDomicilio";
            this.tbDomicilio.Size = new System.Drawing.Size(249, 20);
            this.tbDomicilio.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "#";
            // 
            // tbNumero
            // 
            this.tbNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNumero.Location = new System.Drawing.Point(79, 104);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(64, 20);
            this.tbNumero.TabIndex = 9;
            this.tbNumero.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(508, 189);
            this.dataGridView1.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "SERVICIOS";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(526, 186);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(563, 393);
            this.webBrowser1.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "CP";
            // 
            // tbCP
            // 
            this.tbCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCP.Location = new System.Drawing.Point(182, 104);
            this.tbCP.Name = "tbCP";
            this.tbCP.Size = new System.Drawing.Size(64, 20);
            this.tbCP.TabIndex = 16;
            this.tbCP.Text = "0";
            // 
            // cbProvincias
            // 
            this.cbProvincias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvincias.FormattingEnabled = true;
            this.cbProvincias.Location = new System.Drawing.Point(371, 104);
            this.cbProvincias.Name = "cbProvincias";
            this.cbProvincias.Size = new System.Drawing.Size(177, 21);
            this.cbProvincias.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "PROV";
            // 
            // abmPatrimonio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 591);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgPatrimonio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "abmPatrimonio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM PATRIMONIO";
            ((System.ComponentModel.ISupportInitialize)(this.dgPatrimonio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPatrimonio;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.ComboBox cbDivPatrimonio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDomicilio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLongitud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbLatitud;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevoPatrimonio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIV_PATR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOMICILIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LATITUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LONGITUD;
        private System.Windows.Forms.ComboBox cbProvincias;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCP;
    }
}