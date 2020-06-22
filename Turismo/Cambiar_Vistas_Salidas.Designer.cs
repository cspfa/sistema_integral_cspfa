namespace SOCIOS.Turismo
{
    partial class Cambiar_Vistas_Salidas
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
            this.cbBono = new System.Windows.Forms.CheckBox();
            this.cbWeb = new System.Windows.Forms.CheckBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbBono
            // 
            this.cbBono.AutoSize = true;
            this.cbBono.Checked = true;
            this.cbBono.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBono.Location = new System.Drawing.Point(193, 35);
            this.cbBono.Name = "cbBono";
            this.cbBono.Size = new System.Drawing.Size(104, 17);
            this.cbBono.TabIndex = 175;
            this.cbBono.Text = "Mostrar en Bono";
            this.cbBono.UseVisualStyleBackColor = true;
            // 
            // cbWeb
            // 
            this.cbWeb.AutoSize = true;
            this.cbWeb.Checked = true;
            this.cbWeb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWeb.Location = new System.Drawing.Point(51, 35);
            this.cbWeb.Name = "cbWeb";
            this.cbWeb.Size = new System.Drawing.Size(102, 17);
            this.cbWeb.TabIndex = 174;
            this.cbWeb.Text = "Mostrar en Web";
            this.cbWeb.UseVisualStyleBackColor = true;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(12, 9);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(41, 13);
            this.lbNombre.TabIndex = 176;
            this.lbNombre.Text = "lbTitulo";
            // 
            // btnGrabar
            // 
            this.btnGrabar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGrabar.Location = new System.Drawing.Point(112, 66);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(89, 23);
            this.btnGrabar.TabIndex = 177;
            this.btnGrabar.Text = "ACTUALIZAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Cambiar_Vistas_Salidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 101);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.cbBono);
            this.Controls.Add(this.cbWeb);
            this.Name = "Cambiar_Vistas_Salidas";
            this.Text = "Cambio Modo Web / Bono";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbBono;
        private System.Windows.Forms.CheckBox cbWeb;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Button btnGrabar;
    }
}