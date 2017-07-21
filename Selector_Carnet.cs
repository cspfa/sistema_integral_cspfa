using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class Selector_Carnet : Form
    {
        public Selector_Carnet(Image foto)
        {
            InitializeComponent();
            pictureBox.Image = foto;
            VGlobales.Imagen_Editada = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PDF_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageResizer.ImageResizer ir = new ImageResizer.ImageResizer(pictureBox.Image);

            DialogResult res = ir.ShowDialog();

            if (res == DialogResult.OK)
            {
                pictureBox.Image = ir._editedImage;
                VGlobales.Imagen_Carnet = pictureBox.Image;
                VGlobales.Imagen_Editada = true;

            }
        }
    }
}