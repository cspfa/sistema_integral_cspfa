namespace SOCIOS
{
    partial class Selector_Carnet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selector_Carnet));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PDF = new System.Windows.Forms.Button();
            this.CARNET = new System.Windows.Forms.Button();
            this.pictureBox = new MicroFour.StrataFrame.UI.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PDF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CONVENCIONAL";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // PDF
            // 
            this.PDF.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.PDF.Image = ((System.Drawing.Image)(resources.GetObject("PDF.Image")));
            this.PDF.Location = new System.Drawing.Point(12, 29);
            this.PDF.Name = "PDF";
            this.PDF.Size = new System.Drawing.Size(75, 72);
            this.PDF.TabIndex = 4;
            this.PDF.UseVisualStyleBackColor = true;
            this.PDF.Click += new System.EventHandler(this.PDF_Click);
            // 
            // CARNET
            // 
            this.CARNET.DialogResult = System.Windows.Forms.DialogResult.No;
            this.CARNET.Image = ((System.Drawing.Image)(resources.GetObject("CARNET.Image")));
            this.CARNET.Location = new System.Drawing.Point(157, 29);
            this.CARNET.Name = "CARNET";
            this.CARNET.Size = new System.Drawing.Size(75, 72);
            this.CARNET.TabIndex = 5;
            this.CARNET.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(35, 143);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(83, 72);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Editar Foto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Selector_Carnet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 243);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.CARNET);
            this.Controls.Add(this.PDF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Selector_Carnet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione Salida";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PDF;
        private System.Windows.Forms.Button CARNET;
        private MicroFour.StrataFrame.UI.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button1;

    }
}