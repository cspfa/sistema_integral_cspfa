namespace SOCIOS.bono.Bonos
{
    partial class UPDATE_BONO_BLANCO
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_ID = new System.Windows.Forms.Label();
            this.lb_ID_ROL = new System.Windows.Forms.Label();
            this.lb_TIPO = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSoc = new System.Windows.Forms.TextBox();
            this.tbDep = new System.Windows.Forms.TextBox();
            this.btnCarga = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID INTERNO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "NUMERADOR (ID_ROL)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "TIPO:";
            // 
            // lb_ID
            // 
            this.lb_ID.AutoSize = true;
            this.lb_ID.ForeColor = System.Drawing.Color.Chocolate;
            this.lb_ID.Location = new System.Drawing.Point(195, 13);
            this.lb_ID.Name = "lb_ID";
            this.lb_ID.Size = new System.Drawing.Size(10, 13);
            this.lb_ID.TabIndex = 3;
            this.lb_ID.Text = "-";
            // 
            // lb_ID_ROL
            // 
            this.lb_ID_ROL.AutoSize = true;
            this.lb_ID_ROL.ForeColor = System.Drawing.Color.Chocolate;
            this.lb_ID_ROL.Location = new System.Drawing.Point(195, 40);
            this.lb_ID_ROL.Name = "lb_ID_ROL";
            this.lb_ID_ROL.Size = new System.Drawing.Size(10, 13);
            this.lb_ID_ROL.TabIndex = 4;
            this.lb_ID_ROL.Text = "-";
            // 
            // lb_TIPO
            // 
            this.lb_TIPO.AutoSize = true;
            this.lb_TIPO.ForeColor = System.Drawing.Color.Chocolate;
            this.lb_TIPO.Location = new System.Drawing.Point(195, 65);
            this.lb_TIPO.Name = "lb_TIPO";
            this.lb_TIPO.Size = new System.Drawing.Size(10, 13);
            this.lb_TIPO.TabIndex = 5;
            this.lb_TIPO.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "NRO_SOC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "NRO_DEP";
            // 
            // tbSoc
            // 
            this.tbSoc.Location = new System.Drawing.Point(171, 94);
            this.tbSoc.Name = "tbSoc";
            this.tbSoc.Size = new System.Drawing.Size(82, 20);
            this.tbSoc.TabIndex = 8;
            // 
            // tbDep
            // 
            this.tbDep.Location = new System.Drawing.Point(171, 126);
            this.tbDep.Name = "tbDep";
            this.tbDep.Size = new System.Drawing.Size(82, 20);
            this.tbDep.TabIndex = 9;
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(38, 174);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(167, 23);
            this.btnCarga.TabIndex = 10;
            this.btnCarga.Text = "COMPLETAR CARGA";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // UPDATE_BONO_BLANCO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 208);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.tbDep);
            this.Controls.Add(this.tbSoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_TIPO);
            this.Controls.Add(this.lb_ID_ROL);
            this.Controls.Add(this.lb_ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UPDATE_BONO_BLANCO";
            this.Text = "CARGAR BONO EN BLANCO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_ID;
        private System.Windows.Forms.Label lb_ID_ROL;
        private System.Windows.Forms.Label lb_TIPO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSoc;
        private System.Windows.Forms.TextBox tbDep;
        private System.Windows.Forms.Button btnCarga;
    }
}