using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class IntegratedTestForm : Form
    {
        public IntegratedTestForm()
        {
            InitializeComponent();

            imageResizer1.WorkComplete += new ImageResizer.WorkCompleteDelegate(imageResizer1_WorkComplete);
        }

        void imageResizer1_WorkComplete(object sender, bool complete)
        {
            if (complete)
            {
                picMain.Image = imageResizer1.GetEditedImage();
            }
            else
            {
                picMain.Image = TestApp.Properties.Resources.NoImage;
            }

            imageResizer1.Reset();
            btnUpload.Enabled = true;
            picMain.Visible = true;
            imageResizer1.Visible = false;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            btnUpload.Enabled = false;
            picMain.Visible = false;
            imageResizer1.Visible = true;
        }
    }
}