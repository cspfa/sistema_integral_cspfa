using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Turismo
{
    public partial class Cambiar_Vistas_Salidas : Form
    {
        int ID;
        bo_Turismo dlog = new bo_Turismo();
        public Cambiar_Vistas_Salidas(int pID, bool Bono, bool Web,string Titulo)
        {
            InitializeComponent();
            lbNombre.Text = Titulo;
            cbBono.Checked = Bono;
            cbWeb.Checked = Web;
            ID = pID;
              

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int Bono = 0;
            if (cbBono.Checked)
                Bono = 1;
            int Web = 0;
            if (cbWeb.Checked)
                Web = 1;
            dlog.Salida_UPD_VISTAS(ID,(int) Bono,(int) Web);
        }
    }
}
