using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class FotoZoom : Form
    {
        public FotoZoom()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Familiares.fotoZoom;
        }

    }
}