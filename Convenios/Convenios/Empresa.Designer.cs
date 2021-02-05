namespace Convenios
{
    partial class Empresa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRazonSocialBuscador = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarEmpresa = new System.Windows.Forms.LinkLabel();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDomicilio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tbRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgResultadosBuscador = new System.Windows.Forms.DataGridView();
            this.ID_EMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAZON_SOCIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOMICILIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_LOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOCALIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLimpiarEmpresa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultadosBuscador)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RAZÓN SOCIAL";
            // 
            // tbRazonSocialBuscador
            // 
            this.tbRazonSocialBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRazonSocialBuscador.Location = new System.Drawing.Point(104, 20);
            this.tbRazonSocialBuscador.Name = "tbRazonSocialBuscador";
            this.tbRazonSocialBuscador.Size = new System.Drawing.Size(260, 20);
            this.tbRazonSocialBuscador.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(372, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(99, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.tbRazonSocialBuscador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 57);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSCADOR";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimpiarEmpresa);
            this.groupBox2.Controls.Add(this.btnAgregarEmpresa);
            this.groupBox2.Controls.Add(this.cbLocalidad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbDomicilio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Controls.Add(this.tbRazonSocial);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 102);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATOS DE LA EMPRESA";
            // 
            // btnAgregarEmpresa
            // 
            this.btnAgregarEmpresa.AutoSize = true;
            this.btnAgregarEmpresa.Location = new System.Drawing.Point(371, 71);
            this.btnAgregarEmpresa.Name = "btnAgregarEmpresa";
            this.btnAgregarEmpresa.Size = new System.Drawing.Size(107, 13);
            this.btnAgregarEmpresa.TabIndex = 17;
            this.btnAgregarEmpresa.TabStop = true;
            this.btnAgregarEmpresa.Text = "ABM LOCALIDADES";
            this.btnAgregarEmpresa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAgregarEmpresa_LinkClicked);
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalidad.FormattingEnabled = true;
            this.cbLocalidad.Location = new System.Drawing.Point(104, 66);
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(260, 21);
            this.cbLocalidad.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "LOCALIDAD";
            // 
            // tbDomicilio
            // 
            this.tbDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDomicilio.Location = new System.Drawing.Point(104, 43);
            this.tbDomicilio.Name = "tbDomicilio";
            this.tbDomicilio.Size = new System.Drawing.Size(260, 20);
            this.tbDomicilio.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "DOMICILIO";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(372, 20);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "GUARDAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // tbRazonSocial
            // 
            this.tbRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbRazonSocial.Location = new System.Drawing.Point(104, 20);
            this.tbRazonSocial.Name = "tbRazonSocial";
            this.tbRazonSocial.Size = new System.Drawing.Size(260, 20);
            this.tbRazonSocial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "RAZÓN SOCIAL";
            // 
            // dgResultadosBuscador
            // 
            this.dgResultadosBuscador.AllowUserToAddRows = false;
            this.dgResultadosBuscador.AllowUserToDeleteRows = false;
            this.dgResultadosBuscador.AllowUserToResizeColumns = false;
            this.dgResultadosBuscador.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgResultadosBuscador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgResultadosBuscador.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgResultadosBuscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgResultadosBuscador.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgResultadosBuscador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultadosBuscador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_EMP,
            this.RAZON_SOCIAL,
            this.DOMICILIO,
            this.ID_LOC,
            this.LOCALIDAD});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgResultadosBuscador.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgResultadosBuscador.Location = new System.Drawing.Point(12, 208);
            this.dgResultadosBuscador.Margin = new System.Windows.Forms.Padding(5);
            this.dgResultadosBuscador.Name = "dgResultadosBuscador";
            this.dgResultadosBuscador.ReadOnly = true;
            this.dgResultadosBuscador.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgResultadosBuscador.RowHeadersVisible = false;
            this.dgResultadosBuscador.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgResultadosBuscador.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResultadosBuscador.Size = new System.Drawing.Size(483, 207);
            this.dgResultadosBuscador.TabIndex = 49;
            this.dgResultadosBuscador.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultadosBuscador_CellContentClick);
            // 
            // ID_EMP
            // 
            this.ID_EMP.HeaderText = "ID_EMPRESA";
            this.ID_EMP.Name = "ID_EMP";
            this.ID_EMP.ReadOnly = true;
            this.ID_EMP.Visible = false;
            this.ID_EMP.Width = 5;
            // 
            // RAZON_SOCIAL
            // 
            this.RAZON_SOCIAL.HeaderText = "RAZÓN SOCIAL";
            this.RAZON_SOCIAL.Name = "RAZON_SOCIAL";
            this.RAZON_SOCIAL.ReadOnly = true;
            this.RAZON_SOCIAL.Width = 175;
            // 
            // DOMICILIO
            // 
            this.DOMICILIO.HeaderText = "DOMICILIO";
            this.DOMICILIO.Name = "DOMICILIO";
            this.DOMICILIO.ReadOnly = true;
            this.DOMICILIO.Width = 145;
            // 
            // ID_LOC
            // 
            this.ID_LOC.HeaderText = "ID_LOCALIDAD";
            this.ID_LOC.Name = "ID_LOC";
            this.ID_LOC.ReadOnly = true;
            this.ID_LOC.Visible = false;
            this.ID_LOC.Width = 5;
            // 
            // LOCALIDAD
            // 
            this.LOCALIDAD.HeaderText = "LOCALIDAD";
            this.LOCALIDAD.Name = "LOCALIDAD";
            this.LOCALIDAD.ReadOnly = true;
            this.LOCALIDAD.Width = 150;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "RESULTADOS";
            // 
            // btnLimpiarEmpresa
            // 
            this.btnLimpiarEmpresa.Location = new System.Drawing.Point(372, 45);
            this.btnLimpiarEmpresa.Name = "btnLimpiarEmpresa";
            this.btnLimpiarEmpresa.Size = new System.Drawing.Size(99, 23);
            this.btnLimpiarEmpresa.TabIndex = 18;
            this.btnLimpiarEmpresa.Text = "LIMPIAR";
            this.btnLimpiarEmpresa.UseVisualStyleBackColor = true;
            this.btnLimpiarEmpresa.Click += new System.EventHandler(this.BtnLimpiarEmpresa_Click);
            // 
            // Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 430);
            this.Controls.Add(this.dgResultadosBuscador);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Empresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultadosBuscador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRazonSocialBuscador;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbDomicilio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox tbRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLocalidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgResultadosBuscador;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel btnAgregarEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_EMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAZON_SOCIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOMICILIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_LOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOCALIDAD;
        private System.Windows.Forms.Button btnLimpiarEmpresa;
    }
}