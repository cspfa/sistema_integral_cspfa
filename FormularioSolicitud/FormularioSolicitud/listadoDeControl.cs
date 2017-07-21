using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SOCIOS
{
    public partial class listadoDeControl : Form
    {
        BO_Datos dlog = new BO_Datos();

        public listadoDeControl()
        {
            InitializeComponent();
            llenarComboOrigenAlta();
        }

        public void llenarComboOrigenAlta()
        {
            string query = "SELECT CODIGO, SIGN FROM CODIGOS WHERE SUBSTRING(CODIGO FROM 1 FOR 3) = 'OA0';";
            cbOrigenAlta.Items.Clear();
            cbOrigenAlta.DataSource = dlog.BO_EjecutoDataTable(query);
            cbOrigenAlta.DisplayMember = "SIGN";
            cbOrigenAlta.ValueMember = "CODIGO";
            cbOrigenAlta.SelectedItem = null;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            string ADTO = dtpADTO.Text;
            string ORIGEN_ALTA;

            if (cbOrigenAlta.SelectedValue != null)
                ORIGEN_ALTA = cbOrigenAlta.SelectedValue.ToString();
            else
                ORIGEN_ALTA = null;
            
            int PAR;

            if (rbActividad.Checked)
                PAR = 0;
            else
                PAR = 2;

            listadoDeControlPrint lcp = new listadoDeControlPrint(PAR, ADTO, ORIGEN_ALTA);
            lcp.ShowDialog();
            this.Close();
        }
    }
}
