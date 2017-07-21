using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.descuentos
{   
    public partial class ARCHIVOS_PROCESADOS : Form
    {
        TXT_Utils tu = new TXT_Utils();
        public ARCHIVOS_PROCESADOS()
        {
            InitializeComponent();
            tbMes.Text  = System.DateTime.Now.Month.ToString();
            tbAnio.Text = System.DateTime.Now.Year.ToString();
                     

            Filtrar();

        }

        private void Filtrar()
        {
            int mes = Int32.Parse(tbMes.Text);
            int anio = Int32.Parse(tbAnio.Text);

            if (rbActivos.Checked)
                dataGridView1.DataSource = tu.TXT_ACT_MES(mes, anio);
            else
                dataGridView1.DataSource = tu.TXT_PAS_MES(mes, anio);
        }

        private void VER_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivos.Checked)
                rbPasividad.Checked = false;
            else
                rbPasividad.Checked = true;
        }

        private void rbPasividad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPasividad.Checked)
                rbActivos.Checked = false;
            else
                rbActivos.Checked = true;
        }
    }
}
