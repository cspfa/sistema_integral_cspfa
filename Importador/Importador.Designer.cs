namespace Importador
{
    partial class Importador
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
            this.gpRed = new System.Windows.Forms.GroupBox();
            this.pnlID = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHASTA = new System.Windows.Forms.TextBox();
            this.Desde = new System.Windows.Forms.Label();
            this.tbDESDE = new System.Windows.Forms.TextBox();
            this.chkFiltro = new System.Windows.Forms.CheckBox();
            this.Importar_EC = new System.Windows.Forms.Button();
            this.cbID = new System.Windows.Forms.CheckBox();
            this.Refrescar_EC = new System.Windows.Forms.Button();
            this.lbEntradas = new System.Windows.Forms.Label();
            this.lbEntradaCampo = new System.Windows.Forms.Label();
            this.infoDepAlta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InfoDepUPD = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.InfoDepDEL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImportarDeportes = new System.Windows.Forms.Button();
            this.btnFiltrarDeportes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbResultDeportes = new System.Windows.Forms.Label();
            this.DepoRes = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbResultEC = new System.Windows.Forms.Label();
            this.gpErrores = new System.Windows.Forms.GroupBox();
            this.lBerrores = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gpRed.SuspendLayout();
            this.pnlID.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpErrores.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpRed
            // 
            this.gpRed.Controls.Add(this.pnlID);
            this.gpRed.Controls.Add(this.chkFiltro);
            this.gpRed.Controls.Add(this.Importar_EC);
            this.gpRed.Controls.Add(this.cbID);
            this.gpRed.Controls.Add(this.Refrescar_EC);
            this.gpRed.Controls.Add(this.lbEntradas);
            this.gpRed.Controls.Add(this.lbEntradaCampo);
            this.gpRed.Location = new System.Drawing.Point(15, 12);
            this.gpRed.Name = "gpRed";
            this.gpRed.Size = new System.Drawing.Size(429, 112);
            this.gpRed.TabIndex = 30;
            this.gpRed.TabStop = false;
            this.gpRed.Text = "Entradas Campo";
            this.gpRed.Visible = false;
            this.gpRed.Enter += new System.EventHandler(this.gpRed_Enter);
            // 
            // pnlID
            // 
            this.pnlID.Controls.Add(this.label1);
            this.pnlID.Controls.Add(this.tbHASTA);
            this.pnlID.Controls.Add(this.Desde);
            this.pnlID.Controls.Add(this.tbDESDE);
            this.pnlID.Location = new System.Drawing.Point(135, 11);
            this.pnlID.Name = "pnlID";
            this.pnlID.Size = new System.Drawing.Size(162, 64);
            this.pnlID.TabIndex = 32;
            this.pnlID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "HASTA";
            // 
            // tbHASTA
            // 
            this.tbHASTA.Location = new System.Drawing.Point(69, 32);
            this.tbHASTA.Name = "tbHASTA";
            this.tbHASTA.Size = new System.Drawing.Size(39, 20);
            this.tbHASTA.TabIndex = 5;
            this.tbHASTA.Text = "0";
            this.tbHASTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Desde
            // 
            this.Desde.AutoSize = true;
            this.Desde.Location = new System.Drawing.Point(10, 9);
            this.Desde.Name = "Desde";
            this.Desde.Size = new System.Drawing.Size(44, 13);
            this.Desde.TabIndex = 4;
            this.Desde.Text = "DESDE";
            // 
            // tbDESDE
            // 
            this.tbDESDE.Location = new System.Drawing.Point(69, 6);
            this.tbDESDE.Name = "tbDESDE";
            this.tbDESDE.Size = new System.Drawing.Size(39, 20);
            this.tbDESDE.TabIndex = 3;
            this.tbDESDE.Text = "0";
            this.tbDESDE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkFiltro
            // 
            this.chkFiltro.AutoSize = true;
            this.chkFiltro.Checked = true;
            this.chkFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiltro.Location = new System.Drawing.Point(6, 19);
            this.chkFiltro.Name = "chkFiltro";
            this.chkFiltro.Size = new System.Drawing.Size(123, 17);
            this.chkFiltro.TabIndex = 30;
            this.chkFiltro.Text = "Solo No Procesados";
            this.chkFiltro.UseVisualStyleBackColor = true;
            // 
            // Importar_EC
            // 
            this.Importar_EC.Location = new System.Drawing.Point(314, 83);
            this.Importar_EC.Name = "Importar_EC";
            this.Importar_EC.Size = new System.Drawing.Size(75, 23);
            this.Importar_EC.TabIndex = 34;
            this.Importar_EC.Text = "IMPORTAR";
            this.Importar_EC.UseVisualStyleBackColor = true;
            this.Importar_EC.Click += new System.EventHandler(this.Importar_EC_Click);
            // 
            // cbID
            // 
            this.cbID.AutoSize = true;
            this.cbID.Location = new System.Drawing.Point(6, 38);
            this.cbID.Name = "cbID";
            this.cbID.Size = new System.Drawing.Size(106, 17);
            this.cbID.TabIndex = 31;
            this.cbID.Text = "FILTRAR ID INT";
            this.cbID.UseVisualStyleBackColor = true;
            this.cbID.CheckedChanged += new System.EventHandler(this.cbID_CheckedChanged);
            // 
            // Refrescar_EC
            // 
            this.Refrescar_EC.Location = new System.Drawing.Point(181, 83);
            this.Refrescar_EC.Name = "Refrescar_EC";
            this.Refrescar_EC.Size = new System.Drawing.Size(75, 23);
            this.Refrescar_EC.TabIndex = 33;
            this.Refrescar_EC.Text = "Filtrar";
            this.Refrescar_EC.UseVisualStyleBackColor = true;
            this.Refrescar_EC.Click += new System.EventHandler(this.Refrescar_EC_Click);
            // 
            // lbEntradas
            // 
            this.lbEntradas.AutoSize = true;
            this.lbEntradas.Location = new System.Drawing.Point(303, 16);
            this.lbEntradas.Name = "lbEntradas";
            this.lbEntradas.Size = new System.Drawing.Size(107, 13);
            this.lbEntradas.TabIndex = 31;
            this.lbEntradas.Text = "ENTRADAS CAMPO";
            // 
            // lbEntradaCampo
            // 
            this.lbEntradaCampo.AutoSize = true;
            this.lbEntradaCampo.BackColor = System.Drawing.Color.White;
            this.lbEntradaCampo.ForeColor = System.Drawing.Color.Red;
            this.lbEntradaCampo.Location = new System.Drawing.Point(351, 38);
            this.lbEntradaCampo.Name = "lbEntradaCampo";
            this.lbEntradaCampo.Size = new System.Drawing.Size(13, 13);
            this.lbEntradaCampo.TabIndex = 32;
            this.lbEntradaCampo.Text = "0";
            // 
            // infoDepAlta
            // 
            this.infoDepAlta.AutoSize = true;
            this.infoDepAlta.BackColor = System.Drawing.Color.White;
            this.infoDepAlta.ForeColor = System.Drawing.Color.Red;
            this.infoDepAlta.Location = new System.Drawing.Point(144, 29);
            this.infoDepAlta.Name = "infoDepAlta";
            this.infoDepAlta.Size = new System.Drawing.Size(13, 13);
            this.infoDepAlta.TabIndex = 34;
            this.infoDepAlta.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "DEPORTES ALTA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // InfoDepUPD
            // 
            this.InfoDepUPD.AutoSize = true;
            this.InfoDepUPD.BackColor = System.Drawing.Color.White;
            this.InfoDepUPD.ForeColor = System.Drawing.Color.Red;
            this.InfoDepUPD.Location = new System.Drawing.Point(144, 54);
            this.InfoDepUPD.Name = "InfoDepUPD";
            this.InfoDepUPD.Size = new System.Drawing.Size(13, 13);
            this.InfoDepUPD.TabIndex = 36;
            this.InfoDepUPD.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "DEPORTES UPD";
            // 
            // InfoDepDEL
            // 
            this.InfoDepDEL.AutoSize = true;
            this.InfoDepDEL.BackColor = System.Drawing.Color.White;
            this.InfoDepDEL.ForeColor = System.Drawing.Color.Red;
            this.InfoDepDEL.Location = new System.Drawing.Point(144, 79);
            this.InfoDepDEL.Name = "InfoDepDEL";
            this.InfoDepDEL.Size = new System.Drawing.Size(13, 13);
            this.InfoDepDEL.TabIndex = 38;
            this.InfoDepDEL.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "DEPORTES DEL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnImportarDeportes);
            this.groupBox1.Controls.Add(this.btnFiltrarDeportes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.InfoDepDEL);
            this.groupBox1.Controls.Add(this.infoDepAlta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.InfoDepUPD);
            this.groupBox1.Location = new System.Drawing.Point(15, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 165);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deportes";
            this.groupBox1.Visible = false;
            // 
            // btnImportarDeportes
            // 
            this.btnImportarDeportes.Location = new System.Drawing.Point(354, 112);
            this.btnImportarDeportes.Name = "btnImportarDeportes";
            this.btnImportarDeportes.Size = new System.Drawing.Size(75, 23);
            this.btnImportarDeportes.TabIndex = 40;
            this.btnImportarDeportes.Text = "IMPORTAR";
            this.btnImportarDeportes.UseVisualStyleBackColor = true;
            this.btnImportarDeportes.Click += new System.EventHandler(this.btnImportarDeportes_Click);
            // 
            // btnFiltrarDeportes
            // 
            this.btnFiltrarDeportes.Location = new System.Drawing.Point(23, 112);
            this.btnFiltrarDeportes.Name = "btnFiltrarDeportes";
            this.btnFiltrarDeportes.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarDeportes.TabIndex = 39;
            this.btnFiltrarDeportes.Text = "Filtrar";
            this.btnFiltrarDeportes.UseVisualStyleBackColor = true;
            this.btnFiltrarDeportes.Click += new System.EventHandler(this.btnFiltrarDeportes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbResultDeportes);
            this.groupBox2.Controls.Add(this.DepoRes);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbResultEC);
            this.groupBox2.Location = new System.Drawing.Point(524, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 267);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RESULTADOS";
            // 
            // lbResultDeportes
            // 
            this.lbResultDeportes.AutoSize = true;
            this.lbResultDeportes.BackColor = System.Drawing.Color.White;
            this.lbResultDeportes.ForeColor = System.Drawing.Color.Red;
            this.lbResultDeportes.Location = new System.Drawing.Point(130, 61);
            this.lbResultDeportes.Name = "lbResultDeportes";
            this.lbResultDeportes.Size = new System.Drawing.Size(13, 13);
            this.lbResultDeportes.TabIndex = 44;
            this.lbResultDeportes.Text = "--";
            // 
            // DepoRes
            // 
            this.DepoRes.AutoSize = true;
            this.DepoRes.Location = new System.Drawing.Point(6, 61);
            this.DepoRes.Name = "DepoRes";
            this.DepoRes.Size = new System.Drawing.Size(66, 13);
            this.DepoRes.TabIndex = 43;
            this.DepoRes.Text = "DEPORTES";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "ENTRADA CAMPO";
            // 
            // lbResultEC
            // 
            this.lbResultEC.AutoSize = true;
            this.lbResultEC.BackColor = System.Drawing.Color.White;
            this.lbResultEC.ForeColor = System.Drawing.Color.Red;
            this.lbResultEC.Location = new System.Drawing.Point(130, 28);
            this.lbResultEC.Name = "lbResultEC";
            this.lbResultEC.Size = new System.Drawing.Size(13, 13);
            this.lbResultEC.TabIndex = 42;
            this.lbResultEC.Text = "--";
            // 
            // gpErrores
            // 
            this.gpErrores.Controls.Add(this.lBerrores);
            this.gpErrores.Location = new System.Drawing.Point(21, 301);
            this.gpErrores.Name = "gpErrores";
            this.gpErrores.Size = new System.Drawing.Size(661, 100);
            this.gpErrores.TabIndex = 35;
            this.gpErrores.TabStop = false;
            this.gpErrores.Text = "ERRORES";
            this.gpErrores.Visible = false;
            // 
            // lBerrores
            // 
            this.lBerrores.AutoSize = true;
            this.lBerrores.Location = new System.Drawing.Point(7, 20);
            this.lBerrores.Name = "lBerrores";
            this.lBerrores.Size = new System.Drawing.Size(10, 13);
            this.lBerrores.TabIndex = 0;
            this.lBerrores.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fechaHasta);
            this.panel1.Controls.Add(this.fechaDesde);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(181, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 64);
            this.panel1.TabIndex = 41;
            // 
            // fechaHasta
            // 
            this.fechaHasta.Location = new System.Drawing.Point(65, 32);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(200, 20);
            this.fechaHasta.TabIndex = 8;
            // 
            // fechaDesde
            // 
            this.fechaDesde.Location = new System.Drawing.Point(67, 6);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(200, 20);
            this.fechaDesde.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "HASTA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "DESDE";
            // 
            // Importador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 545);
            this.Controls.Add(this.gpErrores);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpRed);
            this.Name = "Importador";
            this.Text = "IMPORTADOR CSPFA";
            this.gpRed.ResumeLayout(false);
            this.gpRed.PerformLayout();
            this.pnlID.ResumeLayout(false);
            this.pnlID.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpErrores.ResumeLayout(false);
            this.gpErrores.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpRed;
        private System.Windows.Forms.Panel pnlID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHASTA;
        private System.Windows.Forms.Label Desde;
        private System.Windows.Forms.TextBox tbDESDE;
        private System.Windows.Forms.CheckBox chkFiltro;
        private System.Windows.Forms.CheckBox cbID;
        private System.Windows.Forms.Label lbEntradas;
        private System.Windows.Forms.Label lbEntradaCampo;
        private System.Windows.Forms.Label infoDepAlta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Importar_EC;
        private System.Windows.Forms.Button Refrescar_EC;
        private System.Windows.Forms.Label InfoDepUPD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label InfoDepDEL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImportarDeportes;
        private System.Windows.Forms.Button btnFiltrarDeportes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbResultDeportes;
        private System.Windows.Forms.Label DepoRes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbResultEC;
        private System.Windows.Forms.GroupBox gpErrores;
        private System.Windows.Forms.Label lBerrores;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

    }
}

