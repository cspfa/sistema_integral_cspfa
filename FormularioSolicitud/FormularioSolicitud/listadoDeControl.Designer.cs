namespace SOCIOS
{
    partial class listadoDeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listadoDeControl));
            this.rbActividad = new System.Windows.Forms.RadioButton();
            this.rbPasividad = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOrigenAlta = new System.Windows.Forms.ComboBox();
            this.dtpADTO = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // rbActividad
            // 
            this.rbActividad.AutoSize = true;
            this.rbActividad.Location = new System.Drawing.Point(22, 29);
            this.rbActividad.Name = "rbActividad";
            this.rbActividad.Size = new System.Drawing.Size(69, 17);
            this.rbActividad.TabIndex = 0;
            this.rbActividad.TabStop = true;
            this.rbActividad.Text = "Actividad";
            this.rbActividad.UseVisualStyleBackColor = true;
            // 
            // rbPasividad
            // 
            this.rbPasividad.AutoSize = true;
            this.rbPasividad.Location = new System.Drawing.Point(106, 29);
            this.rbPasividad.Name = "rbPasividad";
            this.rbPasividad.Size = new System.Drawing.Size(71, 17);
            this.rbPasividad.TabIndex = 1;
            this.rbPasividad.TabStop = true;
            this.rbPasividad.Text = "Pasividad";
            this.rbPasividad.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ADTO:";
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(616, 26);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(75, 23);
            this.btnVer.TabIndex = 7;
            this.btnVer.Text = "Ver...";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Origen Alta:";
            // 
            // cbOrigenAlta
            // 
            this.cbOrigenAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigenAlta.FormattingEnabled = true;
            this.cbOrigenAlta.Location = new System.Drawing.Point(441, 27);
            this.cbOrigenAlta.Name = "cbOrigenAlta";
            this.cbOrigenAlta.Size = new System.Drawing.Size(160, 21);
            this.cbOrigenAlta.TabIndex = 10;
            // 
            // dtpADTO
            // 
            this.dtpADTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpADTO.Location = new System.Drawing.Point(247, 27);
            this.dtpADTO.Name = "dtpADTO";
            this.dtpADTO.Size = new System.Drawing.Size(102, 20);
            this.dtpADTO.TabIndex = 11;
            // 
            // listadoDeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 72);
            this.Controls.Add(this.dtpADTO);
            this.Controls.Add(this.cbOrigenAlta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbPasividad);
            this.Controls.Add(this.rbActividad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(736, 110);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(736, 110);
            this.Name = "listadoDeControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbActividad;
        private System.Windows.Forms.RadioButton rbPasividad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOrigenAlta;
        private System.Windows.Forms.DateTimePicker dtpADTO;
    }
}