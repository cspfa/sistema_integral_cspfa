namespace SOCIOS.registroSocios
{
    partial class noAlcanza
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
            this.lvDatosSocio = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.lvTarjetas = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvCbus = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvDatosSocio
            // 
            this.lvDatosSocio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvDatosSocio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDatosSocio.CausesValidation = false;
            this.lvDatosSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDatosSocio.FullRowSelect = true;
            this.lvDatosSocio.HideSelection = false;
            this.lvDatosSocio.Location = new System.Drawing.Point(15, 31);
            this.lvDatosSocio.Margin = new System.Windows.Forms.Padding(0);
            this.lvDatosSocio.MultiSelect = false;
            this.lvDatosSocio.Name = "lvDatosSocio";
            this.lvDatosSocio.ParentContainer = null;
            this.lvDatosSocio.ShowItemToolTips = true;
            this.lvDatosSocio.Size = new System.Drawing.Size(772, 44);
            this.lvDatosSocio.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDatosSocio.TabIndex = 7;
            this.lvDatosSocio.UseCompatibleStateImageBehavior = false;
            this.lvDatosSocio.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "REGISTRO SELECCIONADO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "FECHA A DTO";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 346);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(84, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "MOTIVO NO ALCANZA";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(322, 346);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(489, 345);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(568, 345);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 13;
            this.btnListar.Text = "LISTAR";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // lvTarjetas
            // 
            this.lvTarjetas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvTarjetas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTarjetas.CausesValidation = false;
            this.lvTarjetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTarjetas.FullRowSelect = true;
            this.lvTarjetas.HideSelection = false;
            this.lvTarjetas.Location = new System.Drawing.Point(15, 105);
            this.lvTarjetas.Margin = new System.Windows.Forms.Padding(0);
            this.lvTarjetas.MultiSelect = false;
            this.lvTarjetas.Name = "lvTarjetas";
            this.lvTarjetas.ParentContainer = null;
            this.lvTarjetas.ShowItemToolTips = true;
            this.lvTarjetas.Size = new System.Drawing.Size(772, 98);
            this.lvTarjetas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTarjetas.TabIndex = 14;
            this.lvTarjetas.UseCompatibleStateImageBehavior = false;
            this.lvTarjetas.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "TARJETAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "CBUS";
            // 
            // lvCbus
            // 
            this.lvCbus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCbus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvCbus.CausesValidation = false;
            this.lvCbus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCbus.FullRowSelect = true;
            this.lvCbus.HideSelection = false;
            this.lvCbus.Location = new System.Drawing.Point(16, 237);
            this.lvCbus.Margin = new System.Windows.Forms.Padding(0);
            this.lvCbus.MultiSelect = false;
            this.lvCbus.Name = "lvCbus";
            this.lvCbus.ParentContainer = null;
            this.lvCbus.ShowItemToolTips = true;
            this.lvCbus.Size = new System.Drawing.Size(772, 98);
            this.lvCbus.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCbus.TabIndex = 16;
            this.lvCbus.UseCompatibleStateImageBehavior = false;
            this.lvCbus.View = System.Windows.Forms.View.Details;
            // 
            // noAlcanza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 380);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lvCbus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvTarjetas);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvDatosSocio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "noAlcanza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NO ALCANZA CUOTA SOCIAL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvDatosSocio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnListar;
        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvTarjetas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvCbus;
    }
}