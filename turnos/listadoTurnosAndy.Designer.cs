namespace SOCIOS
{
    partial class listadoTurnos
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
            this.cbEspecialidades = new System.Windows.Forms.ComboBox();
            this.cbProfesionales = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvListadoTurnos = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBono = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Especialidad:";
            // 
            // cbEspecialidades
            // 
            this.cbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidades.FormattingEnabled = true;
            this.cbEspecialidades.Location = new System.Drawing.Point(92, 18);
            this.cbEspecialidades.Name = "cbEspecialidades";
            this.cbEspecialidades.Size = new System.Drawing.Size(203, 21);
            this.cbEspecialidades.TabIndex = 1;
            this.cbEspecialidades.SelectedIndexChanged += new System.EventHandler(this.cbEspecialidades_SelectedIndexChanged);
            this.cbEspecialidades.SelectionChangeCommitted += new System.EventHandler(this.cbEspecialidades_SelectionChangeCommitted);
            // 
            // cbProfesionales
            // 
            this.cbProfesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfesionales.FormattingEnabled = true;
            this.cbProfesionales.Location = new System.Drawing.Point(388, 18);
            this.cbProfesionales.Name = "cbProfesionales";
            this.cbProfesionales.Size = new System.Drawing.Size(224, 21);
            this.cbProfesionales.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Profesionales:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(92, 51);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "VER TURNOS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvListadoTurnos
            // 
            this.dgvListadoTurnos.AllowUserToAddRows = false;
            this.dgvListadoTurnos.AllowUserToDeleteRows = false;
            this.dgvListadoTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoTurnos.Location = new System.Drawing.Point(10, 83);
            this.dgvListadoTurnos.MultiSelect = false;
            this.dgvListadoTurnos.Name = "dgvListadoTurnos";
            this.dgvListadoTurnos.ReadOnly = true;
            this.dgvListadoTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoTurnos.Size = new System.Drawing.Size(1158, 386);
            this.dgvListadoTurnos.TabIndex = 6;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(503, 45);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(109, 32);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha:";
            // 
            // btnBono
            // 
            this.btnBono.Location = new System.Drawing.Point(618, 45);
            this.btnBono.Name = "btnBono";
            this.btnBono.Size = new System.Drawing.Size(106, 32);
            this.btnBono.TabIndex = 9;
            this.btnBono.Text = "BONO";
            this.btnBono.UseVisualStyleBackColor = true;
            this.btnBono.Visible = false;
            this.btnBono.Click += new System.EventHandler(this.btnBono_Click);
            // 
            // listadoTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 483);
            this.Controls.Add(this.btnBono);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dgvListadoTurnos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cbProfesionales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEspecialidades);
            this.Controls.Add(this.label1);
            this.Name = "listadoTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Turnos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEspecialidades;
        private System.Windows.Forms.ComboBox cbProfesionales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvListadoTurnos;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBono;
    }
}