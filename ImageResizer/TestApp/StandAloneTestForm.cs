using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class StandAloneTestForm : Form
    {
        public StandAloneTestForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codeproject.com/KB/graphics/ImageResizer.aspx");
        }
    }
}