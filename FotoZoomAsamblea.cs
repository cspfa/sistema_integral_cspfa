using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class FotoZoomAsamblea : Form
    {
        public FotoZoomAsamblea()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = IngresoAsamblea.fotoZoom;
        }

    }
}