namespace SOCIOS.bono.Odontologia
{
    partial class Selector_Bono_Odontologia
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
            this.cbOdontologia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProfesionales = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Boton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbOdontologia
            // 
            this.cbOdontologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOdontologia.FormattingEnabled = true;
            this.cbOdontologia.Location = new System.Drawing.Point(96, 12);
            this.cbOdontologia.Name = "cbOdontologia";
            this.cbOdontologia.Size = new System.Drawing.Size(203, 21);
            this.cbOdontologia.TabIndex = 3;
            this.cbOdontologia.SelectedIndexChanged += new System.EventHandler(this.cbOdontologia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Especialidad:";
            // 
            // cbProfesionales
            // 
            this.cbProfesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfesionales.FormattingEnabled = true;
            this.cbProfesionales.Location = new System.Drawing.Point(96, 39);
            this.cbProfesionales.Name = "cbProfesionales";
            this.cbProfesionales.Size = new System.Drawing.Size(203, 21);
            this.cbProfesionales.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Profesionales:";
            // 
            // Boton
            // 
            this.Boton.Location = new System.Drawing.Point(96, 73);
            this.Boton.Name = "Boton";
            this.Boton.Size = new System.Drawing.Size(75, 23);
            this.Boton.TabIndex = 6;
            this.Boton.Text = "Bono";
            this.Boton.UseVisualStyleBackColor = true;
            this.Boton.Click += new System.EventHandler(this.Boton_Click);
            // 
            // Selector_Bono_Odontologia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 108);
            this.Controls.Add(this.Boton);
            this.Controls.Add(this.cbProfesionales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbOdontologia);
            this.Controls.Add(this.label1);
            this.Name = "Selector_Bono_Odontologia";
            this.Text = "Selector_Bono_Odontologia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOdontologia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProfesionales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Boton;
    }
}