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
            this.btnCruzar = new System.Windows.Forms.Button();
            this.btnAbrirXLS = new System.Windows.Forms.Button();
            this.lbArchivoXLS = new System.Windows.Forms.Label();
            this.btnAbrirTXT = new System.Windows.Forms.Button();
            this.lbArchivoTXT = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCruzarConNetos = new System.Windows.Forms.TabPage();
            this.btnListadoFinal = new System.Windows.Forms.Button();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.tbPromocion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpAdto = new System.Windows.Forms.DateTimePicker();
            this.btnImportarRegistros = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgAspirantes = new System.Windows.Forms.DataGridView();
            this.dgNetos = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tpCruzarConNetos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAspirantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNetos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCruzar
            // 
            this.btnCruzar.Location = new System.Drawing.Point(12, 70);
            this.btnCruzar.Name = "btnCruzar";
            this.btnCruzar.Size = new System.Drawing.Size(158, 23);
            this.btnCruzar.TabIndex = 19;
            this.btnCruzar.Text = "OBTENER NRO AFILIADO";
            this.btnCruzar.UseVisualStyleBackColor = true;
            this.btnCruzar.Click += new System.EventHandler(this.btnCruzar_Click);
            // 
            // btnAbrirXLS
            // 
            this.btnAbrirXLS.Location = new System.Drawing.Point(12, 41);
            this.btnAbrirXLS.Name = "btnAbrirXLS";
            this.btnAbrirXLS.Size = new System.Drawing.Size(158, 23);
            this.btnAbrirXLS.TabIndex = 16;
            this.btnAbrirXLS.Text = "ABRIR XLS ESCUELA";
            this.btnAbrirXLS.UseVisualStyleBackColor = true;
            this.btnAbrirXLS.Click += new System.EventHandler(this.btnAbrirXLS_Click);
            // 
            // lbArchivoXLS
            // 
            this.lbArchivoXLS.AutoSize = true;
            this.lbArchivoXLS.Location = new System.Drawing.Point(185, 46);
            this.lbArchivoXLS.Name = "lbArchivoXLS";
            this.lbArchivoXLS.Size = new System.Drawing.Size(198, 13);
            this.lbArchivoXLS.TabIndex = 15;
            this.lbArchivoXLS.Text = "ARCHIVO SELECCIONADO: NINGUNO";
            // 
            // btnAbrirTXT
            // 
            this.btnAbrirTXT.Location = new System.Drawing.Point(12, 12);
            this.btnAbrirTXT.Name = "btnAbrirTXT";
            this.btnAbrirTXT.Size = new System.Drawing.Size(158, 23);
            this.btnAbrirTXT.TabIndex = 14;
            this.btnAbrirTXT.Text = "ABRIR TXT NETOS";
            this.btnAbrirTXT.UseVisualStyleBackColor = true;
            this.btnAbrirTXT.Click += new System.EventHandler(this.btnAbrirTXT_Click);
            // 
            // lbArchivoTXT
            // 
            this.lbArchivoTXT.AutoSize = true;
            this.lbArchivoTXT.Location = new System.Drawing.Point(185, 17);
            this.lbArchivoTXT.Name = "lbArchivoTXT";
            this.lbArchivoTXT.Size = new System.Drawing.Size(198, 13);
            this.lbArchivoTXT.TabIndex = 13;
            this.lbArchivoTXT.Text = "ARCHIVO SELECCIONADO: NINGUNO";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(187, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(195, 18);
            this.progressBar1.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCruzarConNetos);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 632);
            this.tabControl1.TabIndex = 31;
            // 
            // tpCruzarConNetos
            // 
            this.tpCruzarConNetos.Controls.Add(this.btnListadoFinal);
            this.tpCruzarConNetos.Controls.Add(this.pbFoto);
            this.tpCruzarConNetos.Controls.Add(this.tbPromocion);
            this.tpCruzarConNetos.Controls.Add(this.label4);
            this.tpCruzarConNetos.Controls.Add(this.label3);
            this.tpCruzarConNetos.Controls.Add(this.dpAdto);
            this.tpCruzarConNetos.Controls.Add(this.btnImportarRegistros);
            this.tpCruzarConNetos.Controls.Add(this.button2);
            this.tpCruzarConNetos.Controls.Add(this.button3);
            this.tpCruzarConNetos.Controls.Add(this.label2);
            this.tpCruzarConNetos.Controls.Add(this.label1);
            this.tpCruzarConNetos.Controls.Add(this.dgAspirantes);
            this.tpCruzarConNetos.Controls.Add(this.dgNetos);
            this.tpCruzarConNetos.Controls.Add(this.btnAbrirTXT);
            this.tpCruzarConNetos.Controls.Add(this.progressBar1);
            this.tpCruzarConNetos.Controls.Add(this.lbArchivoTXT);
            this.tpCruzarConNetos.Controls.Add(this.lbArchivoXLS);
            this.tpCruzarConNetos.Controls.Add(this.btnAbrirXLS);
            this.tpCruzarConNetos.Controls.Add(this.btnCruzar);
            this.tpCruzarConNetos.Location = new System.Drawing.Point(4, 22);
            this.tpCruzarConNetos.Name = "tpCruzarConNetos";
            this.tpCruzarConNetos.Padding = new System.Windows.Forms.Padding(3);
            this.tpCruzarConNetos.Size = new System.Drawing.Size(883, 606);
            this.tpCruzarConNetos.TabIndex = 0;
            this.tpCruzarConNetos.Text = "PROCESAR E INSERTAR DATOS";
            this.tpCruzarConNetos.UseVisualStyleBackColor = true;
            // 
            // btnListadoFinal
            // 
            this.btnListadoFinal.Location = new System.Drawing.Point(716, 570);
            this.btnListadoFinal.Name = "btnListadoFinal";
            this.btnListadoFinal.Size = new System.Drawing.Size(153, 23);
            this.btnListadoFinal.TabIndex = 50;
            this.btnListadoFinal.Text = "LISTADO CON NRO SOC";
            this.btnListadoFinal.UseVisualStyleBackColor = true;
            this.btnListadoFinal.Click += new System.EventHandler(this.btnListadoFinal_Click);
            // 
            // pbFoto
            // 
            this.pbFoto.Image = ((System.Drawing.Image)(resources.GetObject("pbFoto.Image")));
            this.pbFoto.Location = new System.Drawing.Point(815, 8);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(62, 73);
            this.pbFoto.TabIndex = 44;
            this.pbFoto.TabStop = false;
            this.pbFoto.Visible = false;
            // 
            // tbPromocion
            // 
            this.tbPromocion.Location = new System.Drawing.Point(365, 571);
            this.tbPromocion.Name = "tbPromocion";
            this.tbPromocion.Size = new System.Drawing.Size(58, 20);
            this.tbPromocion.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 575);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "PROMOCION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "A_DTO";
            // 
            // dpAdto
            // 
            this.dpAdto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpAdto.Location = new System.Drawing.Point(488, 571);
            this.dpAdto.Name = "dpAdto";
            this.dpAdto.Size = new System.Drawing.Size(89, 20);
            this.dpAdto.TabIndex = 46;
            // 
            // btnImportarRegistros
            // 
            this.btnImportarRegistros.Location = new System.Drawing.Point(583, 570);
            this.btnImportarRegistros.Name = "btnImportarRegistros";
            this.btnImportarRegistros.Size = new System.Drawing.Size(127, 23);
            this.btnImportarRegistros.TabIndex = 45;
            this.btnImportarRegistros.Text = "INSERTAR SOCIOS";
            this.btnImportarRegistros.UseVisualStyleBackColor = true;
            this.btnImportarRegistros.Click += new System.EventHandler(this.btnImportarRegistros_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 570);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "OBTENER NRO SOCIO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 570);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = "CONTROL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "DATOS XLS ESCUELA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "DATOS TXT NETOS";
            // 
            // dgAspirantes
            // 
            this.dgAspirantes.AllowUserToAddRows = false;
            this.dgAspirantes.AllowUserToDeleteRows = false;
            this.dgAspirantes.AllowUserToResizeColumns = false;
            this.dgAspirantes.AllowUserToResizeRows = false;
            this.dgAspirantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAspirantes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgAspirantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgAspirantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAspirantes.Location = new System.Drawing.Point(13, 358);
            this.dgAspirantes.Name = "dgAspirantes";
            this.dgAspirantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAspirantes.Size = new System.Drawing.Size(856, 195);
            this.dgAspirantes.TabIndex = 25;
            // 
            // dgNetos
            // 
            this.dgNetos.AllowUserToAddRows = false;
            this.dgNetos.AllowUserToDeleteRows = false;
            this.dgNetos.AllowUserToResizeColumns = false;
            this.dgNetos.AllowUserToResizeRows = false;
            this.dgNetos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgNetos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgNetos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgNetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNetos.Location = new System.Drawing.Point(13, 128);
            this.dgNetos.Name = "dgNetos";
            this.dgNetos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgNetos.Size = new System.Drawing.Size(856, 195);
            this.dgNetos.TabIndex = 25;
            // 
            // cargaEscuela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 656);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "cargaEscuela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARGA ASPIRANTES ESCUELA DE SUBOFICIALES";
            this.tabControl1.ResumeLayout(false);
            this.tpCruzarConNetos.ResumeLayout(false);
            this.tpCruzarConNetos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAspirantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNetos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirTXT;
        private System.Windows.Forms.Label lbArchivoTXT;
        private System.Windows.Forms.Button btnAbrirXLS;
        private System.Windows.Forms.Label lbArchivoXLS;
        private System.Windows.Forms.Button btnCruzar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCruzarConNetos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgNetos;
        private System.Windows.Forms.DataGridView dgAspirantes;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.TextBox tbPromocion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpAdto;
        private System.Windows.Forms.Button btnImportarRegistros;
        private System.Windows.Forms.Button btnListadoFinal;
    }
}