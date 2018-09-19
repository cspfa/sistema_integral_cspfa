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
            this.label2 = new System.Windows.Forms.Label();
            this.dpAdto = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMotivos = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lvCuotasAdeudadas = new MicroFour.StrataFrame.UI.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarCuotas = new System.Windows.Forms.Button();
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
            this.lvDatosSocio.Location = new System.Drawing.Point(11, 13);
            this.lvDatosSocio.Margin = new System.Windows.Forms.Padding(0);
            this.lvDatosSocio.MultiSelect = false;
            this.lvDatosSocio.Name = "lvDatosSocio";
            this.lvDatosSocio.ParentContainer = null;
            this.lvDatosSocio.ShowItemToolTips = true;
            this.lvDatosSocio.Size = new System.Drawing.Size(553, 56);
            this.lvDatosSocio.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDatosSocio.TabIndex = 7;
            this.lvDatosSocio.UseCompatibleStateImageBehavior = false;
            this.lvDatosSocio.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "FECHA A DTO";
            // 
            // dpAdto
            // 
            this.dpAdto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpAdto.Location = new System.Drawing.Point(102, 81);
            this.dpAdto.Name = "dpAdto";
            this.dpAdto.Size = new System.Drawing.Size(84, 20);
            this.dpAdto.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "MOTIVO NO ALCANZA";
            // 
            // cbMotivos
            // 
            this.cbMotivos.FormattingEnabled = true;
            this.cbMotivos.Location = new System.Drawing.Point(322, 81);
            this.cbMotivos.Name = "cbMotivos";
            this.cbMotivos.Size = new System.Drawing.Size(161, 21);
            this.cbMotivos.TabIndex = 11;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(489, 80);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 22);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lvCuotasAdeudadas
            // 
            this.lvCuotasAdeudadas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCuotasAdeudadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvCuotasAdeudadas.CausesValidation = false;
            this.lvCuotasAdeudadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCuotasAdeudadas.FullRowSelect = true;
            this.lvCuotasAdeudadas.HideSelection = false;
            this.lvCuotasAdeudadas.Location = new System.Drawing.Point(11, 142);
            this.lvCuotasAdeudadas.Margin = new System.Windows.Forms.Padding(0);
            this.lvCuotasAdeudadas.Name = "lvCuotasAdeudadas";
            this.lvCuotasAdeudadas.ParentContainer = null;
            this.lvCuotasAdeudadas.ShowItemToolTips = true;
            this.lvCuotasAdeudadas.Size = new System.Drawing.Size(553, 134);
            this.lvCuotasAdeudadas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCuotasAdeudadas.TabIndex = 13;
            this.lvCuotasAdeudadas.UseCompatibleStateImageBehavior = false;
            this.lvCuotasAdeudadas.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "CUOTAS ADEUDADAS";
            // 
            // btnEliminarCuotas
            // 
            this.btnEliminarCuotas.Location = new System.Drawing.Point(373, 286);
            this.btnEliminarCuotas.Name = "btnEliminarCuotas";
            this.btnEliminarCuotas.Size = new System.Drawing.Size(194, 22);
            this.btnEliminarCuotas.TabIndex = 15;
            this.btnEliminarCuotas.Text = "MARCAR CUOTA COMO PAGA";
            this.btnEliminarCuotas.UseVisualStyleBackColor = true;
            this.btnEliminarCuotas.Click += new System.EventHandler(this.btnEliminarCuotas_Click);
            // 
            // noAlcanza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 320);
            this.Controls.Add(this.btnEliminarCuotas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCuotasAdeudadas);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbMotivos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpAdto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvDatosSocio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "noAlcanza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NO ALCANZA CUOTA SOCIAL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvDatosSocio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpAdto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMotivos;
        private System.Windows.Forms.Button btnAceptar;
        private MicroFour.StrataFrame.UI.Windows.Forms.ListView lvCuotasAdeudadas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarCuotas;
    }
}