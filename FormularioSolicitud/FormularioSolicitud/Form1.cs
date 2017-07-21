using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listadoDeControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoDeControl lc = new listadoDeControl();
            lc.ShowDialog();
        }

        private void solicitudTitularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solicitudTitular st = new solicitudTitular();
            st.ShowDialog();
        }
    }
}
