namespace SOCIOS
{
    partial class FichaAdherente
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
            this.components = new System.ComponentModel.Container();
            this.gradientFormHeader1 = new MicroFour.StrataFrame.UI.Windows.Forms.GradientFormHeader(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientFormHeader1
            // 
            this.gradientFormHeader1.DetailText = "Utilice las barras de desplazamiento para ver la ficha completa";
            this.gradientFormHeader1.HeaderImage = global::SOCIOS.Properties.Resources.Contact;
            this.gradientFormHeader1.Location = new System.Drawing.Point(-3, -2);
            this.gradientFormHeader1.Name = "gradientFormHeader1";
            this.gradientFormHeader1.ParentContainer = this;
            this.gradientFormHeader1.PropertyToLocalize = "Title";
            this.gradientFormHeader1.Size = new System.Drawing.Size(759, 61);
            this.gradientFormHeader1.TabIndex = 0;
            this.gradientFormHeader1.TabStop = false;
            this.gradientFormHeader1.Title = "FICHA ESCANEADA";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-2, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 401);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(755, 1126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FichaAdherente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gradientFormHeader1);
            this.Name = "FichaAdherente";
            this.Text = "ADHERENTES";
            this.Load += new System.EventHandler(this.Cargo_Ficha);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MicroFour.StrataFrame.UI.Windows.Forms.GradientFormHeader gradientFormHeader1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

