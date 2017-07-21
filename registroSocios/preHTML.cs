using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class preHTML : Form
    {
        public preHTML(string html)
        {
            InitializeComponent();
            webBrowser.DocumentText = html;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printhtml p = new printhtml();

            try
            {
                p.printHTML("temp.html");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
