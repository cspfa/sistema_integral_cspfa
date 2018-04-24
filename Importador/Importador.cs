using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using SOCIOS;

namespace Importador
{
    public partial class Importador : Form
    {
        List<SOCIOS.EntradaCampo> LISTA_EC = new List<SOCIOS.EntradaCampo>();
        SOCIOS.bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        EntradaCampoService entradaCampoService = new EntradaCampoService();

        //SOCIOS.conString 

        private string ROLE { get; set; }

        public Importador()
        {
            InitializeComponent();
            ROLE = "CPOCABA";
        }

        private void cbID_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gpRed_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Refrescar_EC_Click(object sender, EventArgs e)
        {
            
        }

        private void Refrescar_Entrada_Campo()
        {

        LISTA_EC=      entradaCampoService.InfoExportar(chkFiltro.Checked, cbID.Checked, tbDESDE.Text, tbHASTA.Text,ROLE);
        lbEntradaCampo.Text= LISTA_EC.Count.ToString();
        }

        private void Importar_EC_Click(object sender, EventArgs e)
        {

        }
    }
}
