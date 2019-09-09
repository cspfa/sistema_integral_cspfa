using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Confiteria
{
    public partial class agregarItem : Form
    {
        public agregarItem()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Utils u = new Utils();

            if(tbNombre.Text !="" && tbPrecio.Text != "")
            {
                int ID = u.putNuevoItem(tbNombre.Text.Trim(), tbPrecio.Text.Trim());
            }
        }
    }
}
