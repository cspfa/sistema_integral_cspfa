namespace SOCIOS
{
    partial class Cambio_clave
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
            this.label1 = new MicroFour.StrataFrame.UI.Windows.Forms.Label();
            this.label2 = new MicroFour.StrataFrame.UI.Windows.Forms.Label();
            this.label3 = new MicroFour.StrataFrame.UI.Windows.Forms.Label();
            this.textbox1 = new MicroFour.StrataFrame.UI.Windows.Forms.Textbox();
            this.button1 = new MicroFour.StrataFrame.UI.Windows.Forms.Button();
            this.button2 = new MicroFour.StrataFrame.UI.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.IgnoreManageReadOnlyState = true;
            this.label1.Location = new System.Drawing.Point(38, 15);
            this.label1.Name = "label1";
            this.label1.ParentContainer = null;
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "USUARIO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.IgnoreManageReadOnlyState = true;
            this.label2.Location = new System.Drawing.Point(128, 17);
            this.label2.Name = "label2";
            this.label2.ParentContainer = null;
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.IgnoreManageReadOnlyState = true;
            this.label3.Location = new System.Drawing.Point(22, 54);
            this.label3.Name = "label3";
            this.label3.ParentContainer = null;
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "PASSWORD:";
            // 
            // textbox1
            // 
            this.textbox1.BindingEditable = true;
            this.textbox1.BusinessObjectEvaluated = true;
            this.textbox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textbox1.Location = new System.Drawing.Point(131, 53);
            this.textbox1.MaxLength = 20;
            this.textbox1.Name = "textbox1";
            this.textbox1.PasswordChar = 'X';
            this.textbox1.Size = new System.Drawing.Size(124, 20);
            this.textbox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 133);
            this.button1.Name = "button1";
            this.button1.ParentContainer = null;
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ACEPTAR";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 133);
            this.button2.Name = "button2";
            this.button2.ParentContainer = null;
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "CERRAR";
            // 
            // Cambio_clave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 174);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cambio_clave";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAMBIAR LA CLAVE DE USUARIO";
            this.Load += new System.EventHandler(this.Cambio_clave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MicroFour.StrataFrame.UI.Windows.Forms.Label label1;
        private MicroFour.StrataFrame.UI.Windows.Forms.Label label2;
        private MicroFour.StrataFrame.UI.Windows.Forms.Label label3;
        private MicroFour.StrataFrame.UI.Windows.Forms.Textbox textbox1;
        private MicroFour.StrataFrame.UI.Windows.Forms.Button button1;
        private MicroFour.StrataFrame.UI.Windows.Forms.Button button2;
    }
}