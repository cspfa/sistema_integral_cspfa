namespace SOCIOS
{
    partial class nuevoAbmAranceles
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
            this.cbCategoriaSocial = new System.Windows.Forms.ComboBox();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSectAct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbProf = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbArancel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgAranceles = new System.Windows.Forms.DataGridView();
            this.GRUPO_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECTACT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROFESIONAL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRUPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATSOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECTACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROFESIONAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARANCEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARANCEL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE_BAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REGIMEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HABITACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tbSocioEmpleado = new System.Windows.Forms.TextBox();
            this.lbSocioEmpleado = new System.Windows.Forms.Label();
            this.tbSocioInvitado = new System.Windows.Forms.TextBox();
            this.lbSocioInvitado = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbHabitacion = new System.Windows.Forms.ComboBox();
            this.lbHabitacion = new System.Windows.Forms.Label();
            this.cbRegimen = new System.Windows.Forms.ComboBox();
            this.lbRegimen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAranceles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CATEGORIA SOCIAL";
            // 
            // cbCategoriaSocial
            // 
            this.cbCategoriaSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoriaSocial.FormattingEnabled = true;
            this.cbCategoriaSocial.Location = new System.Drawing.Point(139, 24);
            this.cbCategoriaSocial.Name = "cbCategoriaSocial";
            this.cbCategoriaSocial.Size = new System.Drawing.Size(141, 21);
            this.cbCategoriaSocial.TabIndex = 1;
            // 
            // cbRoles
            // 
            this.cbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(337, 24);
            this.cbRoles.MaxDropDownItems = 10;
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(215, 21);
            this.cbRoles.TabIndex = 2;
            this.cbRoles.SelectionChangeCommitted += new System.EventHandler(this.cbRoles_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ROLES";
            // 
            // cbSectAct
            // 
            this.cbSectAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSectAct.FormattingEnabled = true;
            this.cbSectAct.Location = new System.Drawing.Point(139, 54);
            this.cbSectAct.Name = "cbSectAct";
            this.cbSectAct.Size = new System.Drawing.Size(413, 21);
            this.cbSectAct.TabIndex = 4;
            this.cbSectAct.SelectionChangeCommitted += new System.EventHandler(this.cbSectAct_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SECTOR / ACTIVIDAD";
            // 
            // cbProf
            // 
            this.cbProf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProf.FormattingEnabled = true;
            this.cbProf.Location = new System.Drawing.Point(139, 85);
            this.cbProf.Name = "cbProf";
            this.cbProf.Size = new System.Drawing.Size(413, 21);
            this.cbProf.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "PROFESIONAL";
            // 
            // tbArancel
            // 
            this.tbArancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbArancel.Location = new System.Drawing.Point(139, 143);
            this.tbArancel.Name = "tbArancel";
            this.tbArancel.Size = new System.Drawing.Size(82, 26);
            this.tbArancel.TabIndex = 9;
            this.tbArancel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ARANCEL";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(562, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "NUEVO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(743, 52);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnModificar.Size = new System.Drawing.Size(168, 23);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgAranceles
            // 
            this.dgAranceles.AllowUserToAddRows = false;
            this.dgAranceles.AllowUserToDeleteRows = false;
            this.dgAranceles.AllowUserToResizeColumns = false;
            this.dgAranceles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgAranceles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAranceles.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgAranceles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgAranceles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAranceles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgAranceles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAranceles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GRUPO_ID,
            this.SECTACT_ID,
            this.PROFESIONAL_ID,
            this.GRUPO,
            this.CATSOC,
            this.ROL,
            this.SECTACT,
            this.PROFESIONAL,
            this.ARANCEL,
            this.ARANCEL_ID,
            this.FE_BAJA,
            this.REGIMEN,
            this.HABITACION});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAranceles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgAranceles.Location = new System.Drawing.Point(13, 177);
            this.dgAranceles.Margin = new System.Windows.Forms.Padding(5);
            this.dgAranceles.MultiSelect = false;
            this.dgAranceles.Name = "dgAranceles";
            this.dgAranceles.ReadOnly = true;
            this.dgAranceles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAranceles.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgAranceles.RowHeadersVisible = false;
            this.dgAranceles.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgAranceles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAranceles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAranceles.Size = new System.Drawing.Size(1202, 394);
            this.dgAranceles.TabIndex = 47;
            // 
            // GRUPO_ID
            // 
            this.GRUPO_ID.HeaderText = "GRUPO_ID";
            this.GRUPO_ID.Name = "GRUPO_ID";
            this.GRUPO_ID.ReadOnly = true;
            this.GRUPO_ID.Visible = false;
            // 
            // SECTACT_ID
            // 
            this.SECTACT_ID.HeaderText = "SECTACT_ID";
            this.SECTACT_ID.Name = "SECTACT_ID";
            this.SECTACT_ID.ReadOnly = true;
            this.SECTACT_ID.Visible = false;
            // 
            // PROFESIONAL_ID
            // 
            this.PROFESIONAL_ID.HeaderText = "PROFESIONAL_ID";
            this.PROFESIONAL_ID.Name = "PROFESIONAL_ID";
            this.PROFESIONAL_ID.ReadOnly = true;
            this.PROFESIONAL_ID.Visible = false;
            // 
            // GRUPO
            // 
            this.GRUPO.HeaderText = "GRUPO";
            this.GRUPO.Name = "GRUPO";
            this.GRUPO.ReadOnly = true;
            // 
            // CATSOC
            // 
            this.CATSOC.HeaderText = "CATSOC";
            this.CATSOC.Name = "CATSOC";
            this.CATSOC.ReadOnly = true;
            this.CATSOC.Width = 129;
            // 
            // ROL
            // 
            this.ROL.HeaderText = "ROL";
            this.ROL.Name = "ROL";
            this.ROL.ReadOnly = true;
            this.ROL.Width = 135;
            // 
            // SECTACT
            // 
            this.SECTACT.HeaderText = "SECTOR/ACTIVIDAD";
            this.SECTACT.Name = "SECTACT";
            this.SECTACT.ReadOnly = true;
            this.SECTACT.Width = 311;
            // 
            // PROFESIONAL
            // 
            this.PROFESIONAL.HeaderText = "PROFESIONAL";
            this.PROFESIONAL.Name = "PROFESIONAL";
            this.PROFESIONAL.ReadOnly = true;
            this.PROFESIONAL.Width = 242;
            // 
            // ARANCEL
            // 
            this.ARANCEL.HeaderText = "ARANCEL";
            this.ARANCEL.Name = "ARANCEL";
            this.ARANCEL.ReadOnly = true;
            this.ARANCEL.Width = 65;
            // 
            // ARANCEL_ID
            // 
            this.ARANCEL_ID.HeaderText = "ARANCEL_ID";
            this.ARANCEL_ID.Name = "ARANCEL_ID";
            this.ARANCEL_ID.ReadOnly = true;
            this.ARANCEL_ID.Visible = false;
            // 
            // FE_BAJA
            // 
            this.FE_BAJA.HeaderText = "FE_BAJA";
            this.FE_BAJA.Name = "FE_BAJA";
            this.FE_BAJA.ReadOnly = true;
            this.FE_BAJA.Visible = false;
            // 
            // REGIMEN
            // 
            this.REGIMEN.HeaderText = "REGIMEN";
            this.REGIMEN.Name = "REGIMEN";
            this.REGIMEN.ReadOnly = true;
            // 
            // HABITACION
            // 
            this.HABITACION.HeaderText = "HABITACION";
            this.HABITACION.Name = "HABITACION";
            this.HABITACION.ReadOnly = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(561, 23);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(170, 23);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "MOSTRAR ARANCELES";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(742, 23);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpiar.Size = new System.Drawing.Size(170, 23);
            this.btnLimpiar.TabIndex = 49;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tbSocioEmpleado
            // 
            this.tbSocioEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSocioEmpleado.Location = new System.Drawing.Point(401, 143);
            this.tbSocioEmpleado.Name = "tbSocioEmpleado";
            this.tbSocioEmpleado.Size = new System.Drawing.Size(82, 26);
            this.tbSocioEmpleado.TabIndex = 51;
            this.tbSocioEmpleado.Text = "0";
            this.tbSocioEmpleado.Visible = false;
            // 
            // lbSocioEmpleado
            // 
            this.lbSocioEmpleado.AutoSize = true;
            this.lbSocioEmpleado.Location = new System.Drawing.Point(294, 150);
            this.lbSocioEmpleado.Name = "lbSocioEmpleado";
            this.lbSocioEmpleado.Size = new System.Drawing.Size(102, 13);
            this.lbSocioEmpleado.TabIndex = 50;
            this.lbSocioEmpleado.Text = "SOCIO EMPLEADO";
            this.lbSocioEmpleado.Visible = false;
            // 
            // tbSocioInvitado
            // 
            this.tbSocioInvitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSocioInvitado.Location = new System.Drawing.Point(401, 142);
            this.tbSocioInvitado.Name = "tbSocioInvitado";
            this.tbSocioInvitado.Size = new System.Drawing.Size(82, 26);
            this.tbSocioInvitado.TabIndex = 53;
            this.tbSocioInvitado.Text = "0";
            this.tbSocioInvitado.Visible = false;
            // 
            // lbSocioInvitado
            // 
            this.lbSocioInvitado.AutoSize = true;
            this.lbSocioInvitado.Location = new System.Drawing.Point(301, 150);
            this.lbSocioInvitado.Name = "lbSocioInvitado";
            this.lbSocioInvitado.Size = new System.Drawing.Size(94, 13);
            this.lbSocioInvitado.TabIndex = 52;
            this.lbSocioInvitado.Text = "SOCIO INVITADO";
            this.lbSocioInvitado.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(562, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 23);
            this.button2.TabIndex = 54;
            this.button2.Text = "MOSTRAR HISTORIAL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbHabitacion
            // 
            this.cbHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHabitacion.Enabled = false;
            this.cbHabitacion.FormattingEnabled = true;
            this.cbHabitacion.Location = new System.Drawing.Point(315, 114);
            this.cbHabitacion.Name = "cbHabitacion";
            this.cbHabitacion.Size = new System.Drawing.Size(237, 21);
            this.cbHabitacion.TabIndex = 56;
            // 
            // lbHabitacion
            // 
            this.lbHabitacion.AutoSize = true;
            this.lbHabitacion.Enabled = false;
            this.lbHabitacion.Location = new System.Drawing.Point(275, 118);
            this.lbHabitacion.Name = "lbHabitacion";
            this.lbHabitacion.Size = new System.Drawing.Size(32, 13);
            this.lbHabitacion.TabIndex = 55;
            this.lbHabitacion.Text = "HAB.";
            // 
            // cbRegimen
            // 
            this.cbRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegimen.Enabled = false;
            this.cbRegimen.FormattingEnabled = true;
            this.cbRegimen.Location = new System.Drawing.Point(139, 114);
            this.cbRegimen.Name = "cbRegimen";
            this.cbRegimen.Size = new System.Drawing.Size(117, 21);
            this.cbRegimen.TabIndex = 58;
            // 
            // lbRegimen
            // 
            this.lbRegimen.AutoSize = true;
            this.lbRegimen.Enabled = false;
            this.lbRegimen.Location = new System.Drawing.Point(76, 118);
            this.lbRegimen.Name = "lbRegimen";
            this.lbRegimen.Size = new System.Drawing.Size(57, 13);
            this.lbRegimen.TabIndex = 57;
            this.lbRegimen.Text = "RÉGIMEN";
            // 
            // nuevoAbmAranceles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 584);
            this.Controls.Add(this.cbRegimen);
            this.Controls.Add(this.lbRegimen);
            this.Controls.Add(this.cbHabitacion);
            this.Controls.Add(this.lbHabitacion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbSocioInvitado);
            this.Controls.Add(this.lbSocioInvitado);
            this.Controls.Add(this.tbSocioEmpleado);
            this.Controls.Add(this.lbSocioEmpleado);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dgAranceles);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbArancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbProf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSectAct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbRoles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCategoriaSocial);
            this.Controls.Add(this.label1);
            this.Name = "nuevoAbmAranceles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Aranceles";
            ((System.ComponentModel.ISupportInitialize)(this.dgAranceles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategoriaSocial;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSectAct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbArancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgAranceles;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox tbSocioEmpleado;
        private System.Windows.Forms.Label lbSocioEmpleado;
        private System.Windows.Forms.TextBox tbSocioInvitado;
        private System.Windows.Forms.Label lbSocioInvitado;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbHabitacion;
        private System.Windows.Forms.Label lbHabitacion;
        private System.Windows.Forms.ComboBox cbRegimen;
        private System.Windows.Forms.Label lbRegimen;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRUPO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECTACT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROFESIONAL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GRUPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATSOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECTACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROFESIONAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARANCEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARANCEL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE_BAJA;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGIMEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn HABITACION;
    }
}