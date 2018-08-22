namespace SOCIOS
{
    partial class puntosDeVenta
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.mbPtoVta = new System.Windows.Forms.MaskedTextBox();
            this.tbNroRecibo = new System.Windows.Forms.TextBox();
            this.tbNroBono = new System.Windows.Forms.TextBox();
            this.tbCuenta = new System.Windows.Forms.TextBox();
            this.cbAccion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnNuevoPtoVta = new System.Windows.Forms.Button();
            this.lbIdPtoVta = new System.Windows.Forms.Label();
            this.lbIdDestino = new System.Windows.Forms.Label();
            this.btnModPtoVta = new System.Windows.Forms.Button();
            this.btnAddPtoVta = new System.Windows.Forms.Button();
            this.dgPtosDeVta = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTO_VTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECIBOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BONOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPtosDeVta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº PTO VTA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ROLE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nº RECIBO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nº BONO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(542, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "CUENTA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(546, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ACCION";
            // 
            // cbRoles
            // 
            this.cbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(599, 39);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(170, 21);
            this.cbRoles.TabIndex = 7;
            // 
            // mbPtoVta
            // 
            this.mbPtoVta.Location = new System.Drawing.Point(599, 66);
            this.mbPtoVta.Mask = "0000";
            this.mbPtoVta.Name = "mbPtoVta";
            this.mbPtoVta.Size = new System.Drawing.Size(100, 20);
            this.mbPtoVta.TabIndex = 8;
            // 
            // tbNroRecibo
            // 
            this.tbNroRecibo.Location = new System.Drawing.Point(599, 93);
            this.tbNroRecibo.Name = "tbNroRecibo";
            this.tbNroRecibo.Size = new System.Drawing.Size(100, 20);
            this.tbNroRecibo.TabIndex = 9;
            this.tbNroRecibo.Text = "0";
            // 
            // tbNroBono
            // 
            this.tbNroBono.Location = new System.Drawing.Point(599, 120);
            this.tbNroBono.Name = "tbNroBono";
            this.tbNroBono.Size = new System.Drawing.Size(100, 20);
            this.tbNroBono.TabIndex = 10;
            this.tbNroBono.Text = "0";
            // 
            // tbCuenta
            // 
            this.tbCuenta.Location = new System.Drawing.Point(599, 147);
            this.tbCuenta.Name = "tbCuenta";
            this.tbCuenta.Size = new System.Drawing.Size(100, 20);
            this.tbCuenta.TabIndex = 11;
            // 
            // cbAccion
            // 
            this.cbAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccion.FormattingEnabled = true;
            this.cbAccion.Location = new System.Drawing.Point(599, 174);
            this.cbAccion.Name = "cbAccion";
            this.cbAccion.Size = new System.Drawing.Size(100, 21);
            this.cbAccion.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "PUNTOS DE VENTA";
            // 
            // btnNuevoPtoVta
            // 
            this.btnNuevoPtoVta.Location = new System.Drawing.Point(598, 202);
            this.btnNuevoPtoVta.Name = "btnNuevoPtoVta";
            this.btnNuevoPtoVta.Size = new System.Drawing.Size(170, 32);
            this.btnNuevoPtoVta.TabIndex = 16;
            this.btnNuevoPtoVta.Text = "NUEVO PTO VTA";
            this.btnNuevoPtoVta.UseVisualStyleBackColor = true;
            this.btnNuevoPtoVta.Click += new System.EventHandler(this.btnNuevoPtoVta_Click);
            // 
            // lbIdPtoVta
            // 
            this.lbIdPtoVta.AutoSize = true;
            this.lbIdPtoVta.Location = new System.Drawing.Point(687, 43);
            this.lbIdPtoVta.Name = "lbIdPtoVta";
            this.lbIdPtoVta.Size = new System.Drawing.Size(0, 13);
            this.lbIdPtoVta.TabIndex = 17;
            // 
            // lbIdDestino
            // 
            this.lbIdDestino.AutoSize = true;
            this.lbIdDestino.Location = new System.Drawing.Point(690, 204);
            this.lbIdDestino.Name = "lbIdDestino";
            this.lbIdDestino.Size = new System.Drawing.Size(0, 13);
            this.lbIdDestino.TabIndex = 18;
            // 
            // btnModPtoVta
            // 
            this.btnModPtoVta.Location = new System.Drawing.Point(9, 268);
            this.btnModPtoVta.Name = "btnModPtoVta";
            this.btnModPtoVta.Size = new System.Drawing.Size(130, 32);
            this.btnModPtoVta.TabIndex = 19;
            this.btnModPtoVta.Text = "MODIFICAR PTO VTA";
            this.btnModPtoVta.UseVisualStyleBackColor = true;
            this.btnModPtoVta.Click += new System.EventHandler(this.btnModPtoVta_Click);
            // 
            // btnAddPtoVta
            // 
            this.btnAddPtoVta.Location = new System.Drawing.Point(243, 268);
            this.btnAddPtoVta.Name = "btnAddPtoVta";
            this.btnAddPtoVta.Size = new System.Drawing.Size(276, 32);
            this.btnAddPtoVta.TabIndex = 20;
            this.btnAddPtoVta.Text = "AGREGAR PTO VTA AL ROL SELECCIONADO";
            this.btnAddPtoVta.UseVisualStyleBackColor = true;
            this.btnAddPtoVta.Click += new System.EventHandler(this.btnAddPtoVta_Click);
            // 
            // dgPtosDeVta
            // 
            this.dgPtosDeVta.AllowUserToAddRows = false;
            this.dgPtosDeVta.AllowUserToDeleteRows = false;
            this.dgPtosDeVta.AllowUserToResizeColumns = false;
            this.dgPtosDeVta.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgPtosDeVta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPtosDeVta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPtosDeVta.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgPtosDeVta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPtosDeVta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPtosDeVta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPtosDeVta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPtosDeVta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PTO_VTA,
            this.ROLE,
            this.RECIBOS,
            this.BONOS,
            this.DESTINO});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPtosDeVta.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPtosDeVta.Location = new System.Drawing.Point(9, 39);
            this.dgPtosDeVta.Margin = new System.Windows.Forms.Padding(5);
            this.dgPtosDeVta.Name = "dgPtosDeVta";
            this.dgPtosDeVta.ReadOnly = true;
            this.dgPtosDeVta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPtosDeVta.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgPtosDeVta.RowHeadersVisible = false;
            this.dgPtosDeVta.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgPtosDeVta.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPtosDeVta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPtosDeVta.Size = new System.Drawing.Size(508, 221);
            this.dgPtosDeVta.TabIndex = 47;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 24;
            // 
            // PTO_VTA
            // 
            this.PTO_VTA.HeaderText = "PTO_VTA";
            this.PTO_VTA.Name = "PTO_VTA";
            this.PTO_VTA.ReadOnly = true;
            this.PTO_VTA.Width = 81;
            // 
            // ROLE
            // 
            this.ROLE.HeaderText = "ROLE";
            this.ROLE.Name = "ROLE";
            this.ROLE.ReadOnly = true;
            this.ROLE.Width = 61;
            // 
            // RECIBOS
            // 
            this.RECIBOS.HeaderText = "RECIBOS";
            this.RECIBOS.Name = "RECIBOS";
            this.RECIBOS.ReadOnly = true;
            this.RECIBOS.Width = 79;
            // 
            // BONOS
            // 
            this.BONOS.HeaderText = "BONOS";
            this.BONOS.Name = "BONOS";
            this.BONOS.ReadOnly = true;
            this.BONOS.Width = 70;
            // 
            // DESTINO
            // 
            this.DESTINO.HeaderText = "DESTINO";
            this.DESTINO.Name = "DESTINO";
            this.DESTINO.ReadOnly = true;
            this.DESTINO.Visible = false;
            this.DESTINO.Width = 80;
            // 
            // puntosDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 309);
            this.Controls.Add(this.dgPtosDeVta);
            this.Controls.Add(this.btnAddPtoVta);
            this.Controls.Add(this.btnModPtoVta);
            this.Controls.Add(this.lbIdDestino);
            this.Controls.Add(this.lbIdPtoVta);
            this.Controls.Add(this.btnNuevoPtoVta);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbAccion);
            this.Controls.Add(this.tbCuenta);
            this.Controls.Add(this.tbNroBono);
            this.Controls.Add(this.tbNroRecibo);
            this.Controls.Add(this.mbPtoVta);
            this.Controls.Add(this.cbRoles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "puntosDeVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM PUNTOS DE VENTA";
            ((System.ComponentModel.ISupportInitialize)(this.dgPtosDeVta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.MaskedTextBox mbPtoVta;
        private System.Windows.Forms.TextBox tbNroRecibo;
        private System.Windows.Forms.TextBox tbNroBono;
        private System.Windows.Forms.TextBox tbCuenta;
        private System.Windows.Forms.ComboBox cbAccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNuevoPtoVta;
        private System.Windows.Forms.Label lbIdPtoVta;
        private System.Windows.Forms.Label lbIdDestino;
        private System.Windows.Forms.Button btnModPtoVta;
        private System.Windows.Forms.Button btnAddPtoVta;
        private System.Windows.Forms.DataGridView dgPtosDeVta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTO_VTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECIBOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn BONOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINO;
    }
}