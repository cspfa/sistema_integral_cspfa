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
    public partial class Stats_Hoteles : Form
    {
        Turismo_Stats_Utils ts = new Turismo_Stats_Utils();
        
        public Stats_Hoteles()
        {
            InitializeComponent();
        }

        private void Filtrar_Click(object sender, EventArgs e)
        {
            GrillaDatos.DataSource = ts.getStats(Desde.Value, Hasta.Value);


        }
    }
}
