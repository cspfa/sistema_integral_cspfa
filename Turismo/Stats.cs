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
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
            IniciarFiltros();
        }

        private void IniciarFiltros()
        {
            dpDesde.Text = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1).ToShortDateString();
            dpHasta.Text = new DateTime(System.DateTime.Now.AddMonths(1).Year, System.DateTime.Now.AddMonths(1).Month, 1).ToShortDateString();
            cbFiltro.Items.Insert(0, "PASAJES");
            cbFiltro.Items.Insert(1, "SALIDAS");
            cbFiltro.Items.Insert(2, "HOTELES");
            cbFiltro.SelectedValue = 0;
            cbFiltro.Refresh();

        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            this.RefrescarGrilla();
        }


        private void RefrescarGrilla()
        {

            int Tipo = cbFiltro.SelectedIndex;
            if (Tipo == 0)
            {
                dgvStats.DataSource = (new TurismoStats()).Stats_Memoria_Pasajes(dpDesde.Value, dpHasta.Value);
            } else if (Tipo ==2)
              dgvStats.DataSource = (new TurismoStats()).Stats_Memoria_Hoteles(Tipo, dpDesde.Value, dpHasta.Value);


        }
    }
}
