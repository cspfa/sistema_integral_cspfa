namespace SOCIOS.registroSocios
{
    partial class cargaEscuela
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cargaEscuela));
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btnCruzar = new System.Windows.Forms.Button();
            this.btnAbrirXLS = new System.Windows.Forms.Button();
            this.lbArchivoXLS = new System.Windows.Forms.Label();
            this.btnAbrirTXT = new System.Windows.Forms.Button();
            this.lbArchivoTXT = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgNetos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgAspirantes = new System.Windows.Forms.DataGridView();
            this.btnImportarRegistros = new System.Windows.Forms.Button();
            this.dpAdto = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPromocion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNetos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAspirantes)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFoto
            // 
            this.pbFoto.Image = ((System.Drawing.Image)(resources.GetObject("pbFoto.Image")));
            this.pbFoto.Location = new System.Drawing.Point(1027, 12);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(62, 73);
            this.pbFoto.TabIndex = 11;
            this.pbFoto.TabStop = false;
            this.pbFoto.Visible = false;
            // 
            // btnCruzar
            // 
            this.btnCruzar.Location = new System.Drawing.Point(12, 70);
            this.btnCruzar.Name = "btnCruzar";
            this.btnCruzar.Size = new System.Drawing.Size(93, 23);
            this.btnCruzar.TabIndex = 19;
            this.btnCruzar.Text = "NRO AFILIADO";
            this.btnCruzar.UseVisualStyleBackColor = true;
            this.btnCruzar.Click += new System.EventHandler(this.btnCruzar_Click);
            // 
            // btnAbrirXLS
            // 
            this.btnAbrirXLS.Location = new System.Drawing.Point(12, 41);
            this.btnAbrirXLS.Name = "btnAbrirXLS";
            this.btnAbrirXLS.Size = new System.Drawing.Size(93, 23);
            this.btnAbrirXLS.TabIndex = 16;
            this.btnAbrirXLS.Text = "ABRIR XLS";
            this.btnAbrirXLS.UseVisualStyleBackColor = true;
            this.btnAbrirXLS.Click += new System.EventHandler(this.btnAbrirXLS_Click);
            // 
            // lbArchivoXLS
            // 
            this.lbArchivoXLS.AutoSize = true;
            this.lbArchivoXLS.Location = new System.Drawing.Point(111, 46);
            this.lbArchivoXLS.Name = "lbArchivoXLS";
            this.lbArchivoXLS.Size = new System.Drawing.Size(198, 13);
            this.lbArchivoXLS.TabIndex = 15;
            this.lbArchivoXLS.Text = "ARCHIVO SELECCIONADO: NINGUNO";
            // 
            // btnAbrirTXT
            // 
            this.btnAbrirTXT.Location = new System.Drawing.Point(12, 12);
            this.btnAbrirTXT.Name = "btnAbrirTXT";
            this.btnAbrirTXT.Size = new System.Drawing.Size(93, 23);
            this.btnAbrirTXT.TabIndex = 14;
            this.btnAbrirTXT.Text = "ABRIR TXT";
            this.btnAbrirTXT.UseVisualStyleBackColor = true;
            this.btnAbrirTXT.Click += new System.EventHandler(this.btnAbrirTXT_Click);
            // 
            // lbArchivoTXT
            // 
            this.lbArchivoTXT.AutoSize = true;
            this.lbArchivoTXT.Location = new System.Drawing.Point(111, 17);
            this.lbArchivoTXT.Name = "lbArchivoTXT";
            this.lbArchivoTXT.Size = new System.Drawing.Size(198, 13);
            this.lbArchivoTXT.TabIndex = 13;
            this.lbArchivoTXT.Text = "ARCHIVO SELECCIONADO: NINGUNO";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(114, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(562, 18);
            this.progressBar1.TabIndex = 16;
            // 
            // dgNetos
            // 
            this.dgNetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNetos.Location = new System.Drawing.Point(13, 127);
            this.dgNetos.Name = "dgNetos";
            this.dgNetos.Size = new System.Drawing.Size(664, 202);
            this.dgNetos.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ARCHIVO TXT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "ARCHIVO XLS";
            // 
            // dgAspirantes
            // 
            this.dgAspirantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAspirantes.Location = new System.Drawing.Point(13, 364);
            this.dgAspirantes.Name = "dgAspirantes";
            this.dgAspirantes.Size = new System.Drawing.Size(1077, 202);
            this.dgAspirantes.TabIndex = 21;
            // 
            // btnImportarRegistros
            // 
            this.btnImportarRegistros.Location = new System.Drawing.Point(934, 332);
            this.btnImportarRegistros.Name = "btnImportarRegistros";
            this.btnImportarRegistros.Size = new System.Drawing.Size(155, 23);
            this.btnImportarRegistros.TabIndex = 24;
            this.btnImportarRegistros.Text = "IMPORTAR REGISTROS";
            this.btnImportarRegistros.UseVisualStyleBackColor = true;
            this.btnImportarRegistros.Click += new System.EventHandler(this.btnImportarRegistros_Click);
            // 
            // dpAdto
            // 
            this.dpAdto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpAdto.Location = new System.Drawing.Point(826, 335);
            this.dpAdto.Name = "dpAdto";
            this.dpAdto.Size = new System.Drawing.Size(102, 20);
            this.dpAdto.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(779, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "A_DTO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(747, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "PROMOCION";
            // 
            // tbPromocion
            // 
            this.tbPromocion.Location = new System.Drawing.Point(827, 304);
            this.tbPromocion.Name = "tbPromocion";
            this.tbPromocion.Size = new System.Drawing.Size(100, 20);
            this.tbPromocion.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(935, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "ACTUALIZAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(935, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "SON SOCIOS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cargaEscuela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 578);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbPromocion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpAdto);
            this.Controls.Add(this.btnImportarRegistros);
            this.Controls.Add(this.btnCruzar);
            this.Controls.Add(this.btnAbrirXLS);
            this.Controls.Add(this.lbArchivoXLS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAbrirTXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbArchivoTXT);
            this.Controls.Add(this.pbFoto);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dgAspirantes);
            this.Controls.Add(this.dgNetos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "cargaEscuela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARGA MASIVA ESCUELA DE SUBOFICIALES";
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNetos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAspirantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnAbrirTXT;
        private System.Windows.Forms.Label lbArchivoTXT;
        private System.Windows.Forms.Button btnAbrirXLS;
        private System.Windows.Forms.Label lbArchivoXLS;
        private System.Windows.Forms.Button btnCruzar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dgNetos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgAspirantes;
        private System.Windows.Forms.Button btnImportarRegistros;
        private System.Windows.Forms.DateTimePicker dpAdto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPromocion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}