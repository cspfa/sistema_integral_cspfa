namespace SOCIOS
{
    partial class sect_act_abm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSectAct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCodcp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCodint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEstado = new System.Windows.Forms.Button();
            this.btnModificarSectAct = new System.Windows.Forms.Button();
            this.cbSectActMod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRoleMod = new System.Windows.Forms.ComboBox();
            this.tbNuevoNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDetalleRole = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNuevoRole = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE";
            // 
            // tbSectAct
            // 
            this.tbSectAct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSectAct.Location = new System.Drawing.Point(76, 28);
            this.tbSectAct.Name = "tbSectAct";
            this.tbSectAct.Size = new System.Drawing.Size(251, 20);
            this.tbSectAct.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ROLE";
            // 
            // cbRoles
            // 
            this.cbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(390, 28);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(251, 21);
            this.cbRoles.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCodcp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbCodint);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbRoles);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbSectAct);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NUEVO SECT ACT";
            // 
            // tbCodcp
            // 
            this.tbCodcp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCodcp.Location = new System.Drawing.Point(243, 58);
            this.tbCodcp.Name = "tbCodcp";
            this.tbCodcp.Size = new System.Drawing.Size(84, 20);
            this.tbCodcp.TabIndex = 8;
            this.tbCodcp.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "CODCP";
            // 
            // tbCodint
            // 
            this.tbCodint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCodint.Location = new System.Drawing.Point(77, 58);
            this.tbCodint.Name = "tbCodint";
            this.tbCodint.Size = new System.Drawing.Size(84, 20);
            this.tbCodint.TabIndex = 6;
            this.tbCodint.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CODINT";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ACEPTAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEstado);
            this.groupBox2.Controls.Add(this.btnModificarSectAct);
            this.groupBox2.Controls.Add(this.cbSectActMod);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbRoleMod);
            this.groupBox2.Controls.Add(this.tbNuevoNombre);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 107);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MODIFICAR SECT ACT";
            // 
            // btnEstado
            // 
            this.btnEstado.Location = new System.Drawing.Point(635, 68);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(98, 23);
            this.btnEstado.TabIndex = 11;
            this.btnEstado.Text = "SUSPENDER";
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // btnModificarSectAct
            // 
            this.btnModificarSectAct.Location = new System.Drawing.Point(543, 68);
            this.btnModificarSectAct.Name = "btnModificarSectAct";
            this.btnModificarSectAct.Size = new System.Drawing.Size(75, 23);
            this.btnModificarSectAct.TabIndex = 7;
            this.btnModificarSectAct.Text = "ACEPTAR";
            this.btnModificarSectAct.UseVisualStyleBackColor = true;
            this.btnModificarSectAct.Click += new System.EventHandler(this.btnModificarSectAct_Click);
            // 
            // cbSectActMod
            // 
            this.cbSectActMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSectActMod.FormattingEnabled = true;
            this.cbSectActMod.Location = new System.Drawing.Point(390, 36);
            this.cbSectActMod.Name = "cbSectActMod";
            this.cbSectActMod.Size = new System.Drawing.Size(343, 21);
            this.cbSectActMod.TabIndex = 9;
            this.cbSectActMod.SelectionChangeCommitted += new System.EventHandler(this.cbSectActMod_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "SECACT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "NOMBRE";
            // 
            // cbRoleMod
            // 
            this.cbRoleMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoleMod.FormattingEnabled = true;
            this.cbRoleMod.Location = new System.Drawing.Point(76, 36);
            this.cbRoleMod.Name = "cbRoleMod";
            this.cbRoleMod.Size = new System.Drawing.Size(251, 21);
            this.cbRoleMod.TabIndex = 7;
            this.cbRoleMod.SelectionChangeCommitted += new System.EventHandler(this.cbRoleMod_SelectionChangeCommitted);
            // 
            // tbNuevoNombre
            // 
            this.tbNuevoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNuevoNombre.Location = new System.Drawing.Point(76, 69);
            this.tbNuevoNombre.Name = "tbNuevoNombre";
            this.tbNuevoNombre.Size = new System.Drawing.Size(251, 20);
            this.tbNuevoNombre.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ROLE";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbDetalleRole);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbNuevoRole);
            this.groupBox3.Location = new System.Drawing.Point(12, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(753, 69);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NUEVO ROLE";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "DETALLE";
            // 
            // tbDetalleRole
            // 
            this.tbDetalleRole.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDetalleRole.Location = new System.Drawing.Point(390, 28);
            this.tbDetalleRole.Name = "tbDetalleRole";
            this.tbDetalleRole.Size = new System.Drawing.Size(251, 20);
            this.tbDetalleRole.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(658, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "ACEPTAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "NOMBRE";
            // 
            // tbNuevoRole
            // 
            this.tbNuevoRole.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNuevoRole.Location = new System.Drawing.Point(76, 28);
            this.tbNuevoRole.Name = "tbNuevoRole";
            this.tbNuevoRole.Size = new System.Drawing.Size(251, 20);
            this.tbNuevoRole.TabIndex = 8;
            // 
            // sect_act_abm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 307);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "sect_act_abm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SECTORES Y ACTIVIDADES";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSectAct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbRoleMod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSectActMod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModificarSectAct;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbNuevoNombre;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNuevoRole;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.TextBox tbCodcp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCodint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbDetalleRole;
    }
}