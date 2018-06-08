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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRazonSocialBuscador = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tbRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTiposBuscador = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgResultadosBuscador = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregarEmpresa = new System.Windows.Forms.LinkLabel();
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
            this.groupBox2.Controls.Add(this.btnAgregarEmpresa);
            this.groupBox2.Controls.Add(this.cbTiposBuscador);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox2);
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
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(104, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(260, 20);
            this.textBox2.TabIndex = 14;
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
            // cbTiposBuscador
            // 
            this.cbTiposBuscador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTiposBuscador.FormattingEnabled = true;
            this.cbTiposBuscador.Location = new System.Drawing.Point(104, 66);
            this.cbTiposBuscador.Name = "cbTiposBuscador";
            this.cbTiposBuscador.Size = new System.Drawing.Size(260, 21);
            this.cbTiposBuscador.TabIndex = 16;
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
            // dgResultadosBuscador
            // 
            this.dgResultadosBuscador.AllowUserToAddRows = false;
            this.dgResultadosBuscador.AllowUserToDeleteRows = false;
            this.dgResultadosBuscador.AllowUserToResizeColumns = false;
            this.dgResultadosBuscador.AllowUserToResizeRows = false;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgResultadosBuscador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.dgResultadosBuscador.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgResultadosBuscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgResultadosBuscador.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgResultadosBuscador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgResultadosBuscador.DefaultCellStyle = dataGridViewCellStyle35;
            this.dgResultadosBuscador.Location = new System.Drawing.Point(12, 208);
            this.dgResultadosBuscador.Margin = new System.Windows.Forms.Padding(5);
            this.dgResultadosBuscador.Name = "dgResultadosBuscador";
            this.dgResultadosBuscador.ReadOnly = true;
            this.dgResultadosBuscador.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dgResultadosBuscador.RowHeadersVisible = false;
            this.dgResultadosBuscador.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgResultadosBuscador.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgResultadosBuscador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResultadosBuscador.Size = new System.Drawing.Size(483, 207);
            this.dgResultadosBuscador.TabIndex = 49;
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
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(419, 180);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 51;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregarEmpresa
            // 
            this.btnAgregarEmpresa.AutoSize = true;
            this.btnAgregarEmpresa.Location = new System.Drawing.Point(369, 71);
            this.btnAgregarEmpresa.Name = "btnAgregarEmpresa";
            this.btnAgregarEmpresa.Size = new System.Drawing.Size(107, 13);
            this.btnAgregarEmpresa.TabIndex = 17;
            this.btnAgregarEmpresa.TabStop = true;
            this.btnAgregarEmpresa.Text = "NUEVA LOCALIDAD";
            // 
            // Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 430);
            this.Controls.Add(this.btnEditar);
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox tbRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTiposBuscador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgResultadosBuscador;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.LinkLabel btnAgregarEmpresa;
    }
}