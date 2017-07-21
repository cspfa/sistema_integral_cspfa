namespace TestApp
{
    partial class StandAloneTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StandAloneTestForm));
            this.imageResizer1 = new ImageResizer.ImageResizer();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // imageResizer1
            // 
            this.imageResizer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageResizer1.Location = new System.Drawing.Point(0, 0);
            this.imageResizer1.MinimumSize = new System.Drawing.Size(550, 300);
            this.imageResizer1.Name = "imageResizer1";
            this.imageResizer1.RequiredHeight = 0;
            this.imageResizer1.RequiredWidth = 0;
            this.imageResizer1.Size = new System.Drawing.Size(572, 323);
            this.imageResizer1.StandAloneMode = true;
            this.imageResizer1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.Location = new System.Drawing.Point(449, 180);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(123, 50);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.codeproject.com/KB/graphics/ImageResizer.aspx";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // StandAloneTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 323);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.imageResizer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StandAloneTestForm";
            this.Text = "http://www.codeproject.com/KB/graphics/ImageResizer.aspx";
            this.ResumeLayout(false);

        }

        #endregion

        private ImageResizer.ImageResizer imageResizer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}