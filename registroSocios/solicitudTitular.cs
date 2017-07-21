using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace SOCIOS
{
    public partial class solicitudTitular : Form
    {
        bo dlog = new bo();

        public solicitudTitular()
        {
            InitializeComponent();
            llenarComboOrigenAlta();
            llenarComboDestinos();
            rbActividad.Checked = true;
            rbAlfabetico.Checked = true;
            mtbPCRJP1.Visible = false;
            mtbPCRJP2.Visible = false;
            mtbPCRJP3.Visible = false;
            rbAlta.Checked = true;
        }

        public void llenarComboOrigenAlta()
        {
            string query = "SELECT CODIGO, SIGN FROM CODIGOS WHERE SUBSTRING(CODIGO FROM 1 FOR 3) = 'OA0' ORDER BY SIGN ASC;";
            cbOrigenAlta.Items.Clear();
            cbOrigenAlta.DataSource = dlog.BO_EjecutoDataTable(query);
            cbOrigenAlta.DisplayMember = "SIGN";
            cbOrigenAlta.ValueMember = "CODIGO";
        }

        public void llenarComboDestinos()
        {
            string query = "SELECT CODIGO, SIGN FROM CODIGOS WHERE SUBSTRING(CODIGO FROM 1 FOR 3) = 'DE0' ORDER BY SIGN ASC;";
            cbDestino.Items.Clear();
            cbDestino.DataSource = dlog.BO_EjecutoDataTable(query);
            cbDestino.DisplayMember = "SIGN";
            cbDestino.ValueMember = "CODIGO";
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
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

            int ORDEN;

            if (rbAlfabetico.Checked)
                ORDEN = 1;
            else
                ORDEN = 2;

            string IND = "";
            int AFI_BEN = 0;

            if (rbActividad.Checked)
            {
                AFI_BEN = 1;
                string AAR = mtbAAR.Text;
                string ACRJP2 = mtbACRJP2.Text;
                IND = AAR + "" + ACRJP2;
            }

            string PCRJP1;
            string PCRJP2;
            string PCRJP3;

            if (rbPasividad.Checked)
            {
                AFI_BEN = 2;
                PCRJP1 = mtbPCRJP1.Text;
                PCRJP2 = mtbPCRJP2.Text;
                PCRJP3 = mtbPCRJP3.Text;
                IND = PCRJP1 + "" + PCRJP2 + "" + PCRJP3;
            }

            int O = 0;
            int A = 0;

            if (cbO.Checked)
                O = 1;
            
            if (cbA.Checked)
                A = 1;

                   
            genHTML gh = new genHTML();
            gh.formularioSolicitud(dtpADTO.Text, ORIGEN_ALTA, PAR, ORDEN, IND, AFI_BEN, O, A);
        }

        private void rbPasividad_Click(object sender, EventArgs e)
        {
            laIndividual.Text = "Beneficio";
            mtbPCRJP1.Visible = true;
            mtbPCRJP2.Visible = true;
            mtbPCRJP3.Visible = true;
        }

        private void rbActividad_Click(object sender, EventArgs e)
        {
            laIndividual.Text = "Afiliado";
            mtbAAR.Visible = true;
            mtbACRJP2.Visible = true;
            mtbPCRJP1.Visible = false;
            mtbPCRJP2.Visible = false;
            mtbPCRJP3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rbAlfabetico.Checked = true;
            rbActividad.Checked = true;
            mtbAAR.Text = "";
            mtbACRJP2.Text = "";
            mtbPCRJP1.Text = "";
            mtbPCRJP2.Text = "";
            mtbPCRJP3.Text = "";
            cbOrigenAlta.SelectedIndex = 0;
            dtpADTO.ResetText();
            cbA.Checked = false;
            cbO.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string ORIGEN_ALTA;
            string DESTINO = "";
            string DESDE = "";
            string HASTA = "";

            if (cbRangoLP.Checked)
            {
                DESDE = tbDesde.Text.Trim();
                HASTA = tbHasta.Text.Trim();
            }

            int CSPFA = 0;

            if (cbOrigenAlta.SelectedValue != null)
                ORIGEN_ALTA = cbOrigenAlta.SelectedValue.ToString();
            else
                ORIGEN_ALTA = null;

            int PAR;

            if (rbActividad.Checked)
                PAR = 0;
            else
                PAR = 2;

            int ORDEN = 1;

            if (rbAlfabetico.Checked)
            {
                ORDEN = 1;
            }
            else if (rbAfiliado.Checked)
            {
                ORDEN = 2;
            }
            else if (rbLegajo.Checked)
            {
                ORDEN = 3;
            }

            string IND = "";
            int AFI_BEN = 0;

            if (rbActividad.Checked)
            {
                AFI_BEN = 1;
                string AAR = mtbAAR.Text;
                string ACRJP2 = mtbACRJP2.Text;
                IND = AAR + "" + ACRJP2;
            }

            string PCRJP1;
            string PCRJP2;
            string PCRJP3;

            if (rbPasividad.Checked)
            {
                AFI_BEN = 2;
                PCRJP1 = mtbPCRJP1.Text;
                PCRJP2 = mtbPCRJP2.Text;
                PCRJP3 = mtbPCRJP3.Text;
                IND = PCRJP1 + "" + PCRJP2 + "" + PCRJP3;
            }

            int O = 0;
            int A = 0;

            if (cbO.Checked)
                O = 1;

            if (cbA.Checked)
                A = 1;

            if (rbAlta.Checked)
                CSPFA = 1;

            if (rbBaja.Checked)
                CSPFA = 2;

            if (cbD.Checked)
                DESTINO = cbDestino.SelectedValue.ToString();

            genHTML gh = new genHTML();

            if (cbOrigenAlta.SelectedValue.ToString() == "OA0VOL")
            {
                gh.solicitudTripticoVolve(dtpADTO.Text, ORIGEN_ALTA, PAR, ORDEN, IND, AFI_BEN, O, A, CSPFA, DESTINO, DESDE, HASTA);
            }
            else
            {
                gh.solicitudTriptico(dtpADTO.Text, ORIGEN_ALTA, PAR, ORDEN, IND, AFI_BEN, O, A, CSPFA, DESTINO, DESDE, HASTA);
            }

            Cursor = Cursors.Default;
        }

        private void cbO_CheckedChanged(object sender, EventArgs e)
        {
            if (cbO.Checked)
                gbDestino.Enabled = true;
            else
                gbDestino.Enabled = false;
        }
    }
}
