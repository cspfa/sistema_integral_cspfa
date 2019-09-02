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
    public partial class Cargar_INFO_FC_NC : Form
    {
        int ID = 0;

        public Cargar_INFO_FC_NC(int pID )
        {
            InitializeComponent();
            ID = pID;
            this.StartPosition = FormStartPosition.CenterScreen;  



        }

        private void factura_Click(object sender, EventArgs e)
        {
            SOCIOS.Cargar_Info_Facturacion cif = new   SOCIOS.Cargar_Info_Facturacion(ID);
            cif.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SOCIOS.AFIP.Cargar_Info_Facturacion_NC cinc = new AFIP.Cargar_Info_Facturacion_NC(ID);
            cinc.ShowDialog();
        }
    }
}
