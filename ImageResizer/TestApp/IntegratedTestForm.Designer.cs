namespace TestApp
{
    partial class IntegratedTestForm
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.imageResizer1 = new ImageResizer.ImageResizer();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(12, 12);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload Pic";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // picMain
            // 
            this.picMain.Image = global::TestApp.Properties.Resources.NoImage;
            this.picMain.InitialImage = null;
            this.picMain.Location = new System.Drawing.Point(93, 12);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(550, 300);
            this.picMain.TabIndex = 2;
            this.picMain.TabStop = false;
            // 
            // imageResizer1
            // 
            this.imageResizer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageResizer1.Location = new System.Drawing.Point(93, 12);
            this.imageResizer1.MinimumSize = new System.Drawing.Size(550, 300);
            this.imageResizer1.Name = "imageResizer1";
            this.imageResizer1.RequiredHeight = 100;
            this.imageResizer1.RequiredWidth = 100;
            this.imageResizer1.Size = new System.Drawing.Size(550, 300);
            this.imageResizer1.StandAloneMode = false;
            this.imageResizer1.TabIndex = 1;
            this.imageResizer1.Visible = false;
            // 
            // IntegratedTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 315);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.imageResizer1);
            this.Name = "IntegratedTestForm";
            this.Text = "Integrated Test (control displayed and used as needed)";
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private ImageResizer.ImageResizer imageResizer1;
        private System.Windows.Forms.PictureBox picMain;
    }
}