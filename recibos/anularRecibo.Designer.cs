namespace SOCIOS
{
    partial class anularRecibo
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
            this.tbNroRecibo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbNroBono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUndoBono = new System.Windows.Forms.Button();
            this.btnUndoRecibo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPtoVta = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbNroRecibo
            // 
            this.tbNroRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroRecibo.Location = new System.Drawing.Point(137, 65);
            this.tbNroRecibo.Name = "tbNroRecibo";
            this.tbNroRecibo.Size = new System.Drawing.Size(100, 29);
            this.tbNroRecibo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "RECIBO Nº:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "ANULAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "ANULAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbNroBono
            // 
            this.tbNroBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroBono.Location = new System.Drawing.Point(137, 110);
            this.tbNroBono.Name = "tbNroBono";
            this.tbNroBono.Size = new System.Drawing.Size(100, 29);
            this.tbNroBono.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "BONO Nº:";
            // 
            // btnUndoBono
            // 
            this.btnUndoBono.Location = new System.Drawing.Point(359, 110);
            this.btnUndoBono.Name = "btnUndoBono";
            this.btnUndoBono.Size = new System.Drawing.Size(153, 29);
            this.btnUndoBono.TabIndex = 9;
            this.btnUndoBono.Text = "DESHACER ANULADO";
            this.btnUndoBono.UseVisualStyleBackColor = true;
            this.btnUndoBono.Click += new System.EventHandler(this.btnUndoBono_Click);
            // 
            // btnUndoRecibo
            // 
            this.btnUndoRecibo.Location = new System.Drawing.Point(359, 65);
            this.btnUndoRecibo.Name = "btnUndoRecibo";
            this.btnUndoRecibo.Size = new System.Drawing.Size(153, 29);
            this.btnUndoRecibo.TabIndex = 8;
            this.btnUndoRecibo.Text = "DESHACER ANULADO";
            this.btnUndoRecibo.UseVisualStyleBackColor = true;
            this.btnUndoRecibo.Click += new System.EventHandler(this.btnUndoRecibo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "PTO VTA:";
            // 
            // cbPtoVta
            // 
            this.cbPtoVta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPtoVta.FormattingEnabled = true;
            this.cbPtoVta.Location = new System.Drawing.Point(137, 18);
            this.cbPtoVta.Name = "cbPtoVta";
            this.cbPtoVta.Size = new System.Drawing.Size(100, 32);
            this.cbPtoVta.TabIndex = 10;
            // 
            // anularRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 167);
            this.Controls.Add(this.cbPtoVta);
            this.Controls.Add(this.btnUndoBono);
            this.Controls.Add(this.btnUndoRecibo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbNroBono);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbNroRecibo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "anularRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Anular Recibo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNroRecibo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbNroBono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUndoBono;
        private System.Windows.Forms.Button btnUndoRecibo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPtoVta;

    }
}