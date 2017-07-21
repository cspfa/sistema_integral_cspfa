namespace SOCIOS.bono.Pagos
{
    partial class Anulacion_Bono_Turismo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anulacion_Bono_Turismo));
            this.Reintegro = new System.Windows.Forms.Button();
            this.Anulacion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Reintegro
            // 
            this.Reintegro.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Reintegro.Image = ((System.Drawing.Image)(resources.GetObject("Reintegro.Image")));
            this.Reintegro.Location = new System.Drawing.Point(166, 12);
            this.Reintegro.Name = "Reintegro";
            this.Reintegro.Size = new System.Drawing.Size(55, 51);
            this.Reintegro.TabIndex = 7;
            this.Reintegro.UseVisualStyleBackColor = true;
            this.Reintegro.Click += new System.EventHandler(this.Reintegro_Click);
            // 
            // Anulacion
            // 
            this.Anulacion.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Anulacion.Image = global::SOCIOS.Properties.Resources.Untitled__635_;
            this.Anulacion.Location = new System.Drawing.Point(33, 12);
            this.Anulacion.Name = "Anulacion";
            this.Anulacion.Size = new System.Drawing.Size(61, 51);
            this.Anulacion.TabIndex = 6;
            this.Anulacion.UseVisualStyleBackColor = true;
            this.Anulacion.Click += new System.EventHandler(this.Anulacion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "REINTEGRO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ANULAR";
            // 
            // Anulacion_Bono_Turismo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 109);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reintegro);
            this.Controls.Add(this.Anulacion);
            this.Name = "Anulacion_Bono_Turismo";
            this.Text = "ANULACION";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Reintegro;
        private System.Windows.Forms.Button Anulacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}