using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.entradaCampo.CSPFA
{
    public partial class ConfiguracionAforo : Form
    {
        public ConfiguracionAforo()
        {
            InitializeComponent();

            tbPileta.Text   = Config.getValor(VGlobales.vp_role, "CAMPO_PILETA_TOPE", 0);
            tbDia.Text      = Config.getValor(VGlobales.vp_role, "CAMPO_PILETA_TOPE", 1);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbPileta.Text.Length>0)
                   Config.setValor("CPO", "CAMPO_PILETA_TOPE", 0,tbPileta.Text);
                if (tbDia.Text.Length>0)
                   Config.setValor("CPO", "CAMPO_PILETA_TOPE", 1,tbDia.Text);

                MessageBox.Show("limites de Aforo Cambiados!");

            }
            catch (Exception ex)
            { 
            
            }
        }

        private void ConfiguracionAforo_Load(object sender, EventArgs e)
        {

        }
    }
}
