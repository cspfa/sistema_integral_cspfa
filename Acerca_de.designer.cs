namespace SOCIOS
{
    partial class Acerca_de
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
            MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem detailWindowItem1 = new MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem();
            MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem detailWindowItem2 = new MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem();
            MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem detailWindowItem3 = new MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem();
            MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem detailWindowItem4 = new MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem();
            MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem detailWindowItem5 = new MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem();
            MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem detailWindowItem6 = new MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acerca_de));
            this.themedDetailWindow1 = new MicroFour.StrataFrame.UI.Windows.Forms.ThemedDetailWindow();
            this.pictureBox1 = new MicroFour.StrataFrame.UI.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // themedDetailWindow1
            // 
            this.themedDetailWindow1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            detailWindowItem1.Description = "Producto:";
            detailWindowItem1.Name = "DetailWindowItem1";
            detailWindowItem1.Value = "SISTEMA PARA SOCIOS";
            detailWindowItem2.Description = "Version:";
            detailWindowItem2.Name = "DetailWindowItem2";
            detailWindowItem2.Value = "VS2005.001";
            detailWindowItem3.Description = "Compañia:";
            detailWindowItem3.Name = "DetailWindowItem3";
            detailWindowItem3.Value = "C.S.P.F.A.";
            detailWindowItem4.Description = "Plataforma:";
            detailWindowItem4.Name = "DetailWindowItem4";
            detailWindowItem4.Value = "Windows & Linux";
            detailWindowItem5.Description = "Description:";
            detailWindowItem5.Name = "DetailWindowItem5";
            detailWindowItem5.Value = "Cliente - Servidor";
            detailWindowItem6.Description = "Licencia:";
            detailWindowItem6.Name = "DetailWindowItem6";
            detailWindowItem6.Value = "GNU";
            this.themedDetailWindow1.Items.AddRange(new MicroFour.StrataFrame.UI.Windows.Forms.DetailWindowItem[] {
            detailWindowItem1,
            detailWindowItem2,
            detailWindowItem3,
            detailWindowItem4,
            detailWindowItem5,
            detailWindowItem6});
            this.themedDetailWindow1.Location = new System.Drawing.Point(12, 166);
            this.themedDetailWindow1.Name = "themedDetailWindow1";
            this.themedDetailWindow1.ParentContainer = this;
            this.themedDetailWindow1.Size = new System.Drawing.Size(529, 118);
            this.themedDetailWindow1.TabIndex = 26;
            this.themedDetailWindow1.Text = "themedDetailWindow1";
            this.themedDetailWindow1.Click += new System.EventHandler(this.themedDetailWindow1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(529, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Acerca_de
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 292);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.themedDetailWindow1);
            this.ErrorProviderBlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.ErrorProviderIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Acerca_de";
            this.Text = "ACERCA";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MicroFour.StrataFrame.UI.Windows.Forms.ThemedDetailWindow themedDetailWindow1;
        private MicroFour.StrataFrame.UI.Windows.Forms.PictureBox pictureBox1;

    }
}

