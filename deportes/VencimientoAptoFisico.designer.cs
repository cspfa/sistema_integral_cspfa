namespace SOCIOS.deportes
{
    partial class VencimientoAptoFisico
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
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.lbRol = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Vencimientos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMes = new System.Windows.Forms.TextBox();
            this.tbAnio = new System.Windows.Forms.TextBox();
            this.XLS = new System.Windows.Forms.Button();
            this.fltrar = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.filtrar_Venc = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.XLS_SIN_FECHA = new System.Windows.Forms.Button();
            this.SinFecha = new System.Windows.Forms.DataGridView();
            this.Filtar_Vencimiento = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vencimientos)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SinFecha)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(92, 17);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(125, 21);
            this.cbRol.TabIndex = 94;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(12, 20);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(32, 13);
            this.lbRol.TabIndex = 95;
            this.lbRol.Text = "ROL:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fltrar);
            this.tabPage2.Controls.Add(this.XLS);
            this.tabPage2.Controls.Add(this.tbAnio);
            this.tabPage2.Controls.Add(this.tbMes);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Vencimientos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(673, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vencimientos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Vencimientos
            // 
            this.Vencimientos.AllowUserToAddRows = false;
            this.Vencimientos.AllowUserToDeleteRows = false;
            this.Vencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Vencimientos.Location = new System.Drawing.Point(3, 32);
            this.Vencimientos.Name = "Vencimientos";
            this.Vencimientos.Size = new System.Drawing.Size(661, 207);
            this.Vencimientos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "AÑO";
            // 
            // tbMes
            // 
            this.tbMes.Location = new System.Drawing.Point(42, 5);
            this.tbMes.Name = "tbMes";
            this.tbMes.Size = new System.Drawing.Size(43, 20);
            this.tbMes.TabIndex = 4;
            this.tbMes.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbAnio
            // 
            this.tbAnio.Location = new System.Drawing.Point(136, 6);
            this.tbAnio.Name = "tbAnio";
            this.tbAnio.Size = new System.Drawing.Size(43, 20);
            this.tbAnio.TabIndex = 5;
            // 
            // XLS
            // 
            this.XLS.Location = new System.Drawing.Point(589, 256);
            this.XLS.Name = "XLS";
            this.XLS.Size = new System.Drawing.Size(75, 23);
            this.XLS.TabIndex = 6;
            this.XLS.Text = "XLS";
            this.XLS.UseVisualStyleBackColor = true;
            this.XLS.Click += new System.EventHandler(this.XLS_Click);
            // 
            // fltrar
            // 
            this.fltrar.Location = new System.Drawing.Point(223, 6);
            this.fltrar.Name = "fltrar";
            this.fltrar.Size = new System.Drawing.Size(75, 23);
            this.fltrar.TabIndex = 7;
            this.fltrar.Text = "Filtrar";
            this.fltrar.UseVisualStyleBackColor = true;
            this.fltrar.Click += new System.EventHandler(this.fltrar_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.filtrar_Venc);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Grilla);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(673, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Envio Avisos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Grilla
            // 
            this.Grilla.AllowUserToAddRows = false;
            this.Grilla.AllowUserToDeleteRows = false;
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(6, 34);
            this.Grilla.Name = "Grilla";
            this.Grilla.Size = new System.Drawing.Size(649, 235);
            this.Grilla.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enviar Avisos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // filtrar_Venc
            // 
            this.filtrar_Venc.Location = new System.Drawing.Point(77, 5);
            this.filtrar_Venc.Name = "filtrar_Venc";
            this.filtrar_Venc.Size = new System.Drawing.Size(75, 23);
            this.filtrar_Venc.TabIndex = 2;
            this.filtrar_Venc.Text = "Filtrar";
            this.filtrar_Venc.UseVisualStyleBackColor = true;
            this.filtrar_Venc.Click += new System.EventHandler(this.filtrar_Venc_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(11, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 324);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Filtar_Vencimiento);
            this.tabPage3.Controls.Add(this.XLS_SIN_FECHA);
            this.tabPage3.Controls.Add(this.SinFecha);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(673, 298);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sin Fecha Apto";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // XLS_SIN_FECHA
            // 
            this.XLS_SIN_FECHA.Location = new System.Drawing.Point(589, 262);
            this.XLS_SIN_FECHA.Name = "XLS_SIN_FECHA";
            this.XLS_SIN_FECHA.Size = new System.Drawing.Size(75, 23);
            this.XLS_SIN_FECHA.TabIndex = 8;
            this.XLS_SIN_FECHA.Text = "XLS";
            this.XLS_SIN_FECHA.UseVisualStyleBackColor = true;
            this.XLS_SIN_FECHA.Click += new System.EventHandler(this.XLS_SIN_FECHA_Click);
            // 
            // SinFecha
            // 
            this.SinFecha.AllowUserToAddRows = false;
            this.SinFecha.AllowUserToDeleteRows = false;
            this.SinFecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SinFecha.Location = new System.Drawing.Point(9, 38);
            this.SinFecha.Name = "SinFecha";
            this.SinFecha.Size = new System.Drawing.Size(661, 207);
            this.SinFecha.TabIndex = 7;
            // 
            // Filtar_Vencimiento
            // 
            this.Filtar_Vencimiento.Location = new System.Drawing.Point(249, 9);
            this.Filtar_Vencimiento.Name = "Filtar_Vencimiento";
            this.Filtar_Vencimiento.Size = new System.Drawing.Size(144, 23);
            this.Filtar_Vencimiento.TabIndex = 9;
            this.Filtar_Vencimiento.Text = "Click Para Filtrar";
            this.Filtar_Vencimiento.UseVisualStyleBackColor = true;
            this.Filtar_Vencimiento.Click += new System.EventHandler(this.Filtar_Vencimiento_Click);
            // 
            // VencimientoAptoFisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 426);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.lbRol);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "VencimientoAptoFisico";
            this.Text = "Vencimientos Aptos";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vencimientos)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SinFecha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label lbRol;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button fltrar;
        private System.Windows.Forms.Button XLS;
        private System.Windows.Forms.TextBox tbAnio;
        private System.Windows.Forms.TextBox tbMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Vencimientos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button filtrar_Venc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button XLS_SIN_FECHA;
        private System.Windows.Forms.DataGridView SinFecha;
        private System.Windows.Forms.Button Filtar_Vencimiento;
    }
}