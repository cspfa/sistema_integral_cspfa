using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.deportes.Campos
{
    public partial class Exportar_Deportes : Form
    {
        public Exportar_Deportes()
        {
            InitializeComponent();
            this.InicializarCombos();

        }

        private void InicializarCombos()
        {
            cbROLES.Items.Add("CPOCABA");
            fechaDesde.Value = System.DateTime.Now.AddDays(-1);
            fechaHasta.Value = System.DateTime.Now.AddDays(1);

        }

        private void regRed_Click(object sender, EventArgs e)
        {

        }


    }
}
