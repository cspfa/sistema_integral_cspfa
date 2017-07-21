namespace SOCIOS
{
    partial class nuevoUsuario
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassOne = new System.Windows.Forms.TextBox();
            this.tbPassTwo = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbMiddleName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE DE USUARIO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CONTRASEÑA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "REPETIR CONTRASEÑA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "PRIMER NOMBRE:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "APELLIDO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "SEGUNDO NOMBRE:";
            // 
            // tbUserName
            // 
            this.tbUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUserName.Location = new System.Drawing.Point(148, 15);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(156, 20);
            this.tbUserName.TabIndex = 1;
            // 
            // tbPassOne
            // 
            this.tbPassOne.Location = new System.Drawing.Point(148, 46);
            this.tbPassOne.Name = "tbPassOne";
            this.tbPassOne.Size = new System.Drawing.Size(156, 20);
            this.tbPassOne.TabIndex = 2;
            // 
            // tbPassTwo
            // 
            this.tbPassTwo.Location = new System.Drawing.Point(148, 77);
            this.tbPassTwo.Name = "tbPassTwo";
            this.tbPassTwo.Size = new System.Drawing.Size(156, 20);
            this.tbPassTwo.TabIndex = 3;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(148, 108);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(156, 20);
            this.tbFirstName.TabIndex = 4;
            // 
            // tbMiddleName
            // 
            this.tbMiddleName.Location = new System.Drawing.Point(148, 139);
            this.tbMiddleName.Name = "tbMiddleName";
            this.tbMiddleName.Size = new System.Drawing.Size(156, 20);
            this.tbMiddleName.TabIndex = 5;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(148, 170);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(156, 20);
            this.tbLastName.TabIndex = 6;
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Location = new System.Drawing.Point(316, 169);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(133, 23);
            this.btnCrearUsuario.TabIndex = 7;
            this.btnCrearUsuario.Text = "CREAR USUARIO";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(316, 138);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(133, 23);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // nuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 205);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbMiddleName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.tbPassTwo);
            this.Controls.Add(this.tbPassOne);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "nuevoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NUEVO USUARIO";
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
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassOne;
        private System.Windows.Forms.TextBox tbPassTwo;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbMiddleName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.Button btnLimpiar;
    }
}