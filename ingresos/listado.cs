using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace SOCIOS
{
    public partial class listadoPresentes : Form
    {
        public listadoPresentes()
        {
            InitializeComponent();

            listadoPersonas lp = new listadoPersonas();
            newLabel nl = new newLabel();
            newBullet nb = new newBullet();

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "DEPORTES")
            {
                button1.Enabled = true;
                btnListado.Enabled = true;
            }
            
            DataRow[] fRows1 = lp.listado(1);

            for (int i = 0; i <= fRows1.Length - 1; i++)
            {
                Control l = nl.label(i, fRows1[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows1[i][1])));
                panel1.Controls.Add(l);
                panel1.Controls.Add(b);
            }

            DataRow[] fRows2 = lp.listado(2);

            for (int i = 0; i <= fRows2.Length - 1; i++)
            {
                Control l = nl.label(i, fRows2[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows2[i][1])));
                panel2.Controls.Add(l);
                panel2.Controls.Add(b);
            }

            DataRow[] fRows3 = lp.listado(3);

            for (int i = 0; i <= fRows3.Length - 1; i++)
            {
                Control l = nl.label(i, fRows3[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows3[i][1])));
                panel3.Controls.Add(l);
                panel3.Controls.Add(b);
            }

            DataRow[] fRows4 = lp.listado(4);

            for (int i = 0; i <= fRows4.Length - 1; i++)
            {
                Control l = nl.label(i, fRows4[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows4[i][1])));
                panel4.Controls.Add(l);
                panel4.Controls.Add(b);
            }

            DataRow[] fRows5 = lp.listado(5);

            for (int i = 0; i <= fRows5.Length - 1; i++)
            {
                Control l = nl.label(i, fRows5[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows5[i][1])));
                panel5.Controls.Add(l);
                panel5.Controls.Add(b);
            }

            DataRow[] fRows6 = lp.listado(6);

            for (int i = 0; i <= fRows6.Length - 1; i++)
            {
                Control l = nl.label(i, fRows6[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows6[i][1])));
                panel6.Controls.Add(l);
                panel6.Controls.Add(b);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is PictureBox)
                    c.Dispose();
            }

            foreach (Control c in panel2.Controls)
            {
                if (c is PictureBox)
                    c.Dispose();
            }

            foreach (Control c in panel3.Controls)
            {
                if (c is PictureBox)
                    c.Dispose();
            }

            foreach (Control c in panel4.Controls)
            {
                if (c is PictureBox)
                    c.Dispose();
            }

            foreach (Control c in panel5.Controls)
            {
                if (c is PictureBox)
                    c.Dispose();
            }

            foreach (Control c in panel6.Controls)
            {
                if (c is PictureBox)
                    c.Dispose();
            }

            listadoPersonas lp = new listadoPersonas();
            newLabel nl = new newLabel();
            newBullet nb = new newBullet();

            DataRow[] fRows1 = lp.listado(1);

            for (int i = 0; i <= fRows1.Length - 1; i++)
            {
                Control l = nl.label(i, fRows1[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows1[i][1])));
                panel1.Controls.Add(l);
                panel1.Controls.Add(b);
            }

            DataRow[] fRows2 = lp.listado(2);

            for (int i = 0; i <= fRows2.Length - 1; i++)
            {
                Control l = nl.label(i, fRows2[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows2[i][1])));
                panel2.Controls.Add(l);
                panel2.Controls.Add(b);
            }

            DataRow[] fRows3 = lp.listado(3);

            for (int i = 0; i <= fRows3.Length - 1; i++)
            {
                Control l = nl.label(i, fRows3[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows3[i][1])));
                panel3.Controls.Add(l);
                panel3.Controls.Add(b);
            }

            DataRow[] fRows4 = lp.listado(4);

            for (int i = 0; i <= fRows4.Length - 1; i++)
            {
                Control l = nl.label(i, fRows4[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows4[i][1])));
                panel4.Controls.Add(l);
                panel4.Controls.Add(b);
            }

            DataRow[] fRows5 = lp.listado(5);

            for (int i = 0; i <= fRows5.Length - 1; i++)
            {
                Control l = nl.label(i, fRows5[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows5[i][1])));
                panel5.Controls.Add(l);
                panel5.Controls.Add(b);
            }

            DataRow[] fRows6 = lp.listado(6);

            for (int i = 0; i <= fRows6.Length - 1; i++)
            {
                Control l = nl.label(i, fRows6[i][0].ToString());
                Control b = nb.nBullet(i, int.Parse(string.Format("{0}", fRows6[i][1])));
                panel6.Controls.Add(l);
                panel6.Controls.Add(b);
            }
        }

        private PrintDocument docToPrint = new PrintDocument();

        private void btnListado_Click(object sender, EventArgs e)
        {
            listadoMovimientos lm = new listadoMovimientos();
            lm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abmPersonas ap = new abmPersonas();
            ap.ShowDialog();
        }
    }
}
