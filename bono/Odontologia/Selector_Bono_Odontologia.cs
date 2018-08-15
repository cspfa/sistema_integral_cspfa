using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono.Odontologia
{
    public partial class Selector_Bono_Odontologia : Form
    {
        bo dlog = new bo();
        string NRO_SOC="";
        string NRO_DEP="";
        string NRO_SOC_TIT="";
        string NRO_DEP_TIT="";
        string BARRA = "";
        public Selector_Bono_Odontologia(string pNRO_SOC, string pNRO_DEP,string pBARRA, string pNRO_SOC_TIT,string pNRO_DEP_TIT)
        {
            InitializeComponent();

            NRO_SOC     = pNRO_SOC;
            NRO_DEP     = pNRO_DEP;
            NRO_SOC_TIT = pNRO_SOC_TIT;
            NRO_DEP_TIT = pNRO_DEP_TIT;
            BARRA       = pBARRA;

            this.ComboOdontologia();

        }



        public void ComboOdontologia()
        {
            cbOdontologia.DataSource = null;
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '" + VGlobales.vp_role + "' AND DETALLE LIKE '%ODONTO%'  ORDER BY DETALLE;";
            cbOdontologia.Items.Clear();
            cbOdontologia.DataSource = dlog.BO_EjecutoDataTable(query);
            cbOdontologia.DisplayMember = "DETALLE";
            cbOdontologia.ValueMember = "ID";
            cbOdontologia.SelectedIndex = -1;

        }


        public bool comboProfesional(string ESPECIALIDAD, ComboBox cbProfesionales)
        {
            try
            {
                cbProfesionales.DataSource = null;

                string query = "SELECT P.ID, P.NOMBRE FROM PROFESIONALES P, PROF_ESP PE WHERE PE.ESPECIALIDAD = " + ESPECIALIDAD + " AND PE.PROFESIONAL = P.ID AND P.BAJA IS NULL ORDER BY P.NOMBRE ASC;";

                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                {
                    cbProfesionales.Items.Clear();
                    cbProfesionales.SelectedItem = 0;
                    cbProfesionales.DataSource = dlog.BO_EjecutoDataTable(query);
                    cbProfesionales.DisplayMember = "NOMBRE";
                    cbProfesionales.ValueMember = "ID";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void cbOdontologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOdontologia.SelectedValue != null)
                comboProfesional(cbOdontologia.SelectedValue.ToString(),cbProfesionales);
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            bono.BonoOdontologico admBonoOdonto = new bono.BonoOdontologico(NRO_SOC, NRO_DEP, BARRA, NRO_SOC_TIT, NRO_DEP_TIT, Int32.Parse( cbOdontologia.SelectedValue.ToString()), 0, false, "TURNO");
            admBonoOdonto.idProfesional = Int32.Parse(cbProfesionales.SelectedValue.ToString());
            admBonoOdonto.nombreProfesional = cbProfesionales.Text;
            DialogResult dr = admBonoOdonto.ShowDialog();
        }
    }
}
