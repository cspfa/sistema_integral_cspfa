using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Entrada_Campo.CSPFA
{
    public partial class Procesados : Form
    {
        EntradaCampoService es = new EntradaCampoService();
        public Procesados()
        {
            InitializeComponent();

            dgvProcesados.DataSource = es.getIngresos(false, false,0,0,false,"").ToList();

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
             dgvProcesados.DataSource = es.getIngresos(false, false,0,0,false,"").Where(x => x.ROL == cbROL.Text).ToList();
        }
    }
}
