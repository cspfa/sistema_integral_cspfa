namespace EjemploWebcam
{
    partial class Form1
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
            this.cboDispositivos = new System.Windows.Forms.ComboBox();
            this.pbFotoUser = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIniciarCapturar = new System.Windows.Forms.Button();
            this.lbMensajes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUser)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboDispositivos
            // 
            this.cboDispositivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDispositivos.FormattingEnabled = true;
            this.cboDispositivos.Location = new System.Drawing.Point(29, 43);
            this.cboDispositivos.Name = "cboDispositivos";
            this.cboDispositivos.Size = new System.Drawing.Size(107, 21);
            this.cboDispositivos.TabIndex = 100;
            this.cboDispositivos.TabStop = false;
            // 
            // pbFotoUser
            // 
            this.pbFotoUser.Location = new System.Drawing.Point(17, 28);
            this.pbFotoUser.Name = "pbFotoUser";
            this.pbFotoUser.Size = new System.Drawing.Size(640, 480);
            this.pbFotoUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoUser.TabIndex = 1;
            this.pbFotoUser.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 70);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar dispositivo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbFotoUser);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(678, 528);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vista de cámara";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.btnIniciarCapturar);
            this.groupBox4.Location = new System.Drawing.Point(160, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(530, 70);
            this.groupBox4.TabIndex = 101;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Controles";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(198, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "GUARDAR COMO [ E ]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIniciarCapturar
            // 
            this.btnIniciarCapturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarCapturar.Location = new System.Drawing.Point(19, 24);
            this.btnIniciarCapturar.Name = "btnIniciarCapturar";
            this.btnIniciarCapturar.Size = new System.Drawing.Size(173, 31);
            this.btnIniciarCapturar.TabIndex = 0;
            this.btnIniciarCapturar.Text = "INICIAR CAMARA [ Q ]";
            this.btnIniciarCapturar.UseVisualStyleBackColor = true;
            this.btnIniciarCapturar.Click += new System.EventHandler(this.btnIniciarCapturar_Click);
            // 
            // lbMensajes
            // 
            this.lbMensajes.AutoSize = true;
            this.lbMensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensajes.Location = new System.Drawing.Point(16, 634);
            this.lbMensajes.Name = "lbMensajes";
            this.lbMensajes.Size = new System.Drawing.Size(0, 24);
            this.lbMensajes.TabIndex = 102;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 671);
            this.Controls.Add(this.lbMensajes);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cboDispositivos);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar Foto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoUser)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDispositivos;
        private System.Windows.Forms.PictureBox pbFotoUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIniciarCapturar;
        private System.Windows.Forms.Label lbMensajes;
    }
}

