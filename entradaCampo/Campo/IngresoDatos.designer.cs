namespace SOCIOS.Entrada_Campo
{
    partial class IngresoDatos
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
            this.tbDni = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.DNI = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.chkPersonalPolicial = new System.Windows.Forms.CheckBox();
            this.lbLegajoNroSocio = new System.Windows.Forms.Label();
            this.tbLegajoNroSocio = new System.Windows.Forms.TextBox();
            this.chkSocio = new System.Windows.Forms.CheckBox();
            this.cbEvento = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbDni
            // 
            this.tbDni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDni.Location = new System.Drawing.Point(122, 16);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(205, 20);
            this.tbDni.TabIndex = 0;
            this.tbDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDni_KeyPress);
            // 
            // tbNombre
            // 
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Location = new System.Drawing.Point(122, 42);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(205, 20);
            this.tbNombre.TabIndex = 1;
            this.tbNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbApellido
            // 
            this.tbApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbApellido.Location = new System.Drawing.Point(122, 68);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(205, 20);
            this.tbApellido.TabIndex = 2;
            this.tbApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.Location = new System.Drawing.Point(12, 19);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(26, 13);
            this.DNI.TabIndex = 3;
            this.DNI.Text = "DNI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "NOMBRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "APELLIDO";
            // 
            // btnIngreso
            // 
            this.btnIngreso.Location = new System.Drawing.Point(252, 158);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(75, 23);
            this.btnIngreso.TabIndex = 6;
            this.btnIngreso.Text = "Ingreso";
            this.btnIngreso.UseVisualStyleBackColor = true;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // chkPersonalPolicial
            // 
            this.chkPersonalPolicial.AutoSize = true;
            this.chkPersonalPolicial.Location = new System.Drawing.Point(15, 96);
            this.chkPersonalPolicial.Name = "chkPersonalPolicial";
            this.chkPersonalPolicial.Size = new System.Drawing.Size(106, 17);
            this.chkPersonalPolicial.TabIndex = 7;
            this.chkPersonalPolicial.Text = "Personal Policial ";
            this.chkPersonalPolicial.UseVisualStyleBackColor = true;
            this.chkPersonalPolicial.CheckedChanged += new System.EventHandler(this.chkPersonal_CheckedChanged);
            // 
            // lbLegajoNroSocio
            // 
            this.lbLegajoNroSocio.AutoSize = true;
            this.lbLegajoNroSocio.Location = new System.Drawing.Point(18, 126);
            this.lbLegajoNroSocio.Name = "lbLegajoNroSocio";
            this.lbLegajoNroSocio.Size = new System.Drawing.Size(48, 13);
            this.lbLegajoNroSocio.TabIndex = 9;
            this.lbLegajoNroSocio.Text = "LEGAJO";
            this.lbLegajoNroSocio.Visible = false;
            // 
            // tbLegajoNroSocio
            // 
            this.tbLegajoNroSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbLegajoNroSocio.Location = new System.Drawing.Point(122, 123);
            this.tbLegajoNroSocio.Name = "tbLegajoNroSocio";
            this.tbLegajoNroSocio.Size = new System.Drawing.Size(205, 20);
            this.tbLegajoNroSocio.TabIndex = 8;
            this.tbLegajoNroSocio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbLegajoNroSocio.Visible = false;
            // 
            // chkSocio
            // 
            this.chkSocio.AutoSize = true;
            this.chkSocio.Location = new System.Drawing.Point(127, 96);
            this.chkSocio.Name = "chkSocio";
            this.chkSocio.Size = new System.Drawing.Size(68, 17);
            this.chkSocio.TabIndex = 10;
            this.chkSocio.Text = "Es Socio";
            this.chkSocio.UseVisualStyleBackColor = true;
            this.chkSocio.CheckedChanged += new System.EventHandler(this.chkSocio_CheckedChanged);
            // 
            // cbEvento
            // 
            this.cbEvento.AutoSize = true;
            this.cbEvento.Location = new System.Drawing.Point(201, 96);
            this.cbEvento.Name = "cbEvento";
            this.cbEvento.Size = new System.Drawing.Size(130, 17);
            this.cbEvento.TabIndex = 11;
            this.cbEvento.Text = "Est. Evento Deportivo";
            this.cbEvento.UseVisualStyleBackColor = true;
            // 
            // IngresoDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 193);
            this.Controls.Add(this.cbEvento);
            this.Controls.Add(this.chkSocio);
            this.Controls.Add(this.lbLegajoNroSocio);
            this.Controls.Add(this.tbLegajoNroSocio);
            this.Controls.Add(this.chkPersonalPolicial);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbDni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IngresoDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de Socio a Campo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label DNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.CheckBox chkPersonalPolicial;
        private System.Windows.Forms.Label lbLegajoNroSocio;
        private System.Windows.Forms.TextBox tbLegajoNroSocio;
        private System.Windows.Forms.CheckBox chkSocio;
        private System.Windows.Forms.CheckBox cbEvento;
    }
}