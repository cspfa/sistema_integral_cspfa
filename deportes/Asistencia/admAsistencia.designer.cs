namespace SOCIOS.deportes
{
    partial class admAsistencia
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
            this.cbActividad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaApto = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.selAll = new System.Windows.Forms.Button();
            this.desAll = new System.Windows.Forms.Button();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.lbRol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbActividad
            // 
            this.cbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActividad.FormattingEnabled = true;
            this.cbActividad.Location = new System.Drawing.Point(92, 52);
            this.cbActividad.Name = "cbActividad";
            this.cbActividad.Size = new System.Drawing.Size(373, 21);
            this.cbActividad.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "FECHA:";
            // 
            // FechaApto
            // 
            this.FechaApto.AutoSize = true;
            this.FechaApto.Location = new System.Drawing.Point(12, 56);
            this.FechaApto.Name = "FechaApto";
            this.FechaApto.Size = new System.Drawing.Size(67, 13);
            this.FechaApto.TabIndex = 80;
            this.FechaApto.Text = "ACTIVIDAD:";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(92, 85);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(85, 20);
            this.dpFecha.TabIndex = 82;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 83;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(93, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(269, 390);
            this.dataGridView1.TabIndex = 84;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(221, 514);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(229, 23);
            this.button4.TabIndex = 87;
            this.button4.Text = "Procesar Asistencia";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // selAll
            // 
            this.selAll.Location = new System.Drawing.Point(15, 514);
            this.selAll.Name = "selAll";
            this.selAll.Size = new System.Drawing.Size(75, 23);
            this.selAll.TabIndex = 88;
            this.selAll.Text = "Sel. Todos";
            this.selAll.UseVisualStyleBackColor = true;
            this.selAll.Click += new System.EventHandler(this.selAll_Click);
            // 
            // desAll
            // 
            this.desAll.Location = new System.Drawing.Point(92, 514);
            this.desAll.Name = "desAll";
            this.desAll.Size = new System.Drawing.Size(75, 23);
            this.desAll.TabIndex = 89;
            this.desAll.Text = "Des.Todos";
            this.desAll.UseVisualStyleBackColor = true;
            this.desAll.Click += new System.EventHandler(this.desAll_Click);
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(92, 16);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(125, 21);
            this.cbRol.TabIndex = 90;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Location = new System.Drawing.Point(12, 19);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(32, 13);
            this.lbRol.TabIndex = 91;
            this.lbRol.Text = "ROL:";
            // 
            // admAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 544);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.lbRol);
            this.Controls.Add(this.desAll);
            this.Controls.Add(this.selAll);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbActividad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FechaApto);
            this.Controls.Add(this.dpFecha);
            this.Name = "admAsistencia";
            this.Text = "Asistencias";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbActividad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FechaApto;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button selAll;
        private System.Windows.Forms.Button desAll;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label lbRol;
    }
}