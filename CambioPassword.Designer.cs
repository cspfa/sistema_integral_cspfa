namespace SOCIOS
{
    partial class CbioPassForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.gradientFormHeader1 = new MicroFour.StrataFrame.UI.Windows.Forms.GradientFormHeader(this.components);
            this.txtPasswordCon = new System.Windows.Forms.TextBox();
            this.txtPasswordNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.erpLoginError = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new MicroFour.StrataFrame.UI.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.erpLoginError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(164, 101);
            this.txtPassword.MaxLength = 40;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(237, 20);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(164, 75);
            this.txtUsername.MaxLength = 40;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(237, 20);
            this.txtUsername.TabIndex = 10;
            this.txtUsername.TabStop = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(19, 107);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(129, 13);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "CONTRASEÑA ACTUAL:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(20, 81);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(59, 13);
            this.lblUsername.TabIndex = 15;
            this.lblUsername.Text = "USUARIO:";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(326, 196);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "&CANCELAR";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Location = new System.Drawing.Point(245, 196);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(75, 23);
            this.cmdLimpiar.TabIndex = 15;
            this.cmdLimpiar.Text = "&LIMPIAR";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(164, 196);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 14;
            this.cmdOk.Text = "&APLICAR";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // gradientFormHeader1
            // 
            this.gradientFormHeader1.DetailText = "Por favor ingrese contraseña actual y su nueva contraseña";
            this.gradientFormHeader1.Location = new System.Drawing.Point(0, 0);
            this.gradientFormHeader1.Name = "gradientFormHeader1";
            this.gradientFormHeader1.ParentContainer = null;
            this.gradientFormHeader1.PropertyToLocalize = "Title";
            this.gradientFormHeader1.SeparatorLine = false;
            this.gradientFormHeader1.Size = new System.Drawing.Size(429, 60);
            this.gradientFormHeader1.TabIndex = 9;
            this.gradientFormHeader1.TabStop = false;
            this.gradientFormHeader1.Title = "Cambio de Contraseña";
            // 
            // txtPasswordCon
            // 
            this.txtPasswordCon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPasswordCon.Location = new System.Drawing.Point(164, 155);
            this.txtPasswordCon.MaxLength = 40;
            this.txtPasswordCon.Name = "txtPasswordCon";
            this.txtPasswordCon.PasswordChar = '*';
            this.txtPasswordCon.Size = new System.Drawing.Size(237, 20);
            this.txtPasswordCon.TabIndex = 13;
            this.txtPasswordCon.UseSystemPasswordChar = true;
            this.txtPasswordCon.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPasswordNew.Location = new System.Drawing.Point(164, 129);
            this.txtPasswordNew.MaxLength = 40;
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.PasswordChar = '*';
            this.txtPasswordNew.Size = new System.Drawing.Size(237, 20);
            this.txtPasswordNew.TabIndex = 12;
            this.txtPasswordNew.UseSystemPasswordChar = true;
            this.txtPasswordNew.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "CONFIRME CONTRASEÑA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "CONTRASEÑA NUEVA:";
            // 
            // erpLoginError
            // 
            this.erpLoginError.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 196);
            this.button1.Name = "button1";
            this.button1.ParentContainer = null;
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "A&YUDA";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CbioPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 237);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPasswordCon);
            this.Controls.Add(this.txtPasswordNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.gradientFormHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CbioPassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CambioPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erpLoginError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        protected System.Windows.Forms.Label lblPassword;
        protected System.Windows.Forms.Label lblUsername;
        protected System.Windows.Forms.Button cmdCancel;
        protected System.Windows.Forms.Button cmdLimpiar;
        protected System.Windows.Forms.Button cmdOk;
        private MicroFour.StrataFrame.UI.Windows.Forms.GradientFormHeader gradientFormHeader1;
        protected System.Windows.Forms.TextBox txtPasswordCon;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider erpLoginError;
        protected System.Windows.Forms.TextBox txtPasswordNew;
        private MicroFour.StrataFrame.UI.Windows.Forms.Button button1;
    }
}