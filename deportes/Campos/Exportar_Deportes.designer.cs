﻿namespace SOCIOS.deportes.Campos
{
    partial class Exportar_Deportes
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
            this.gpRed = new System.Windows.Forms.GroupBox();
            this.cbAsistencia = new System.Windows.Forms.CheckBox();
            this.cb_Deportes = new System.Windows.Forms.CheckBox();
            this.lbRol = new System.Windows.Forms.Label();
            this.cbROLES = new System.Windows.Forms.ComboBox();
            this.regRed = new System.Windows.Forms.Button();
            this.pnlID = new System.Windows.Forms.Panel();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Desde = new System.Windows.Forms.Label();
            this.dgDeportes = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.gpRed.SuspendLayout();
            this.pnlID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeportes)).BeginInit();
            this.SuspendLayout();
            // 
            // gpRed
            // 
            this.gpRed.Controls.Add(this.cbAsistencia);
            this.gpRed.Controls.Add(this.cb_Deportes);
            this.gpRed.Controls.Add(this.lbRol);
            this.gpRed.Controls.Add(this.cbROLES);
            this.gpRed.Controls.Add(this.regRed);
            this.gpRed.Controls.Add(this.pnlID);
            this.gpRed.Location = new System.Drawing.Point(12, 12);
            this.gpRed.Name = "gpRed";
            this.gpRed.Size = new System.Drawing.Size(882, 110);
            this.gpRed.TabIndex = 30;
            this.gpRed.TabStop = false;
            this.gpRed.Text = "Filtros Datos de Red";
            // 
            // cbAsistencia
            // 
            this.cbAsistencia.AutoSize = true;
            this.cbAsistencia.Checked = true;
            this.cbAsistencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAsistencia.Location = new System.Drawing.Point(444, 42);
            this.cbAsistencia.Name = "cbAsistencia";
            this.cbAsistencia.Size = new System.Drawing.Size(89, 17);
            this.cbAsistencia.TabIndex = 36;
            this.cbAsistencia.Text = "ASISTENCIA";
            this.cbAsistencia.UseVisualStyleBackColor = true;
            // 
            // cb_Deportes
            // 
            this.cb_Deportes.AutoSize = true;
            this.cb_Deportes.Checked = true;
            this.cb_Deportes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Deportes.Location = new System.Drawing.Point(444, 14);
            this.cb_Deportes.Name = "cb_Deportes";
            this.cb_Deportes.Size = new System.Drawing.Size(169, 17);
            this.cb_Deportes.TabIndex = 35;
            this.cb_Deportes.Text = "DEPORTES Y ACTIVIDADES";
            this.cb_Deportes.UseVisualStyleBackColor = true;
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(6, 19);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(29, 13);
            this.lbRol.TabIndex = 34;
            this.lbRol.Text = "ROL";
            // 
            // cbROLES
            // 
            this.cbROLES.FormattingEnabled = true;
            this.cbROLES.Location = new System.Drawing.Point(41, 16);
            this.cbROLES.Name = "cbROLES";
            this.cbROLES.Size = new System.Drawing.Size(88, 21);
            this.cbROLES.TabIndex = 33;
            this.cbROLES.SelectedIndexChanged += new System.EventHandler(this.cbROLES_SelectedIndexChanged);
            // 
            // regRed
            // 
            this.regRed.Location = new System.Drawing.Point(135, 80);
            this.regRed.Name = "regRed";
            this.regRed.Size = new System.Drawing.Size(147, 23);
            this.regRed.TabIndex = 30;
            this.regRed.Text = "Registros Desde Red";
            this.regRed.UseVisualStyleBackColor = true;
            this.regRed.Click += new System.EventHandler(this.regRed_Click);
            // 
            // pnlID
            // 
            this.pnlID.Controls.Add(this.fechaHasta);
            this.pnlID.Controls.Add(this.fechaDesde);
            this.pnlID.Controls.Add(this.label1);
            this.pnlID.Controls.Add(this.Desde);
            this.pnlID.Location = new System.Drawing.Point(135, 10);
            this.pnlID.Name = "pnlID";
            this.pnlID.Size = new System.Drawing.Size(286, 64);
            this.pnlID.TabIndex = 32;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "HASTA";
            // 
            // Desde
            // 
            this.Desde.AutoSize = true;
            this.Desde.Location = new System.Drawing.Point(16, 9);
            this.Desde.Name = "Desde";
            this.Desde.Size = new System.Drawing.Size(44, 13);
            this.Desde.TabIndex = 4;
            this.Desde.Text = "DESDE";
            // 
            // dgDeportes
            // 
            this.dgDeportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeportes.Location = new System.Drawing.Point(12, 128);
            this.dgDeportes.Name = "dgDeportes";
            this.dgDeportes.Size = new System.Drawing.Size(882, 291);
            this.dgDeportes.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(819, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "PROCESAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exportar_Deportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 484);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgDeportes);
            this.Controls.Add(this.gpRed);
            this.Name = "Exportar_Deportes";
            this.Text = "Exportar_Deportes";
            this.gpRed.ResumeLayout(false);
            this.gpRed.PerformLayout();
            this.pnlID.ResumeLayout(false);
            this.pnlID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpRed;
        private System.Windows.Forms.Label lbRol;
        private System.Windows.Forms.ComboBox cbROLES;
        private System.Windows.Forms.Button regRed;
        private System.Windows.Forms.Panel pnlID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Desde;
        private System.Windows.Forms.DataGridView dgDeportes;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbAsistencia;
        private System.Windows.Forms.CheckBox cb_Deportes;
    }
}