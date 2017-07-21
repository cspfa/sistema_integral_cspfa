namespace SOCIOS
{
    partial class registro_llamadas
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
            this.dgLlamadas = new System.Windows.Forms.DataGridView();
            this.tbInterno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDestino = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgLlamadas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLlamadas
            // 
            this.dgLlamadas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgLlamadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLlamadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLlamadas.Location = new System.Drawing.Point(12, 58);
            this.dgLlamadas.Name = "dgLlamadas";
            this.dgLlamadas.Size = new System.Drawing.Size(465, 518);
            this.dgLlamadas.TabIndex = 0;
            // 
            // tbInterno
            // 
            this.tbInterno.Location = new System.Drawing.Point(86, 21);
            this.tbInterno.Name = "tbInterno";
            this.tbInterno.Size = new System.Drawing.Size(57, 20);
            this.tbInterno.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "INTERNO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DESTINO";
            // 
            // tbDestino
            // 
            this.tbDestino.Location = new System.Drawing.Point(236, 21);
            this.tbDestino.Name = "tbDestino";
            this.tbDestino.Size = new System.Drawing.Size(100, 20);
            this.tbDestino.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(357, 20);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // registro_llamadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 588);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDestino);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbInterno);
            this.Controls.Add(this.dgLlamadas);
            this.Name = "registro_llamadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de llamadas";
            ((System.ComponentModel.ISupportInitialize)(this.dgLlamadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLlamadas;
        private System.Windows.Forms.TextBox tbInterno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDestino;
        private System.Windows.Forms.Button btnAceptar;




    }
}