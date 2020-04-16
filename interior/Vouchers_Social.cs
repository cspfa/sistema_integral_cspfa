using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.interior
{
    public partial class Vouchers_Social : Form
    {
        SOCIOS.Turismo.VoucherUtils vu = new Turismo.VoucherUtils();

        public Vouchers_Social()
        {
            InitializeComponent();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            dgcDatos.DataSource = vu.getVouchers_Social(dpDesde.Value, dpHasta.Value);

        }
    }
}
