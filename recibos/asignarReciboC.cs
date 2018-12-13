using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class asignarReciboC : Form
    {
        bo dlog = new bo();
        BO.bo_Caja BO_CAJA = new BO.bo_Caja();
        private int ID_RECIBO { get; set; }

        public asignarReciboC(string ID, string ROLE)
        {
            InitializeComponent();
            comboPtosDeVta(ROLE);
            ID_RECIBO = int.Parse(ID);
        }

        private void comboPtosDeVta(string ROLE)
        {
            string query = "SELECT PTO_VTA FROM PUNTOS_DE_VENTA WHERE ROL = '" + ROLE + "' AND ACCION != 'O';";
            cbPtosDeVta.DataSource = null;
            cbPtosDeVta.Items.Clear();
            cbPtosDeVta.DataSource = dlog.BO_EjecutoDataTable(query);
            cbPtosDeVta.DisplayMember = "PTO_VTA";
            cbPtosDeVta.ValueMember = "PTO_VTA";
            cbPtosDeVta.SelectedItem = 0;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            string PTO_VTA = cbPtosDeVta.SelectedValue.ToString();
            string NRO_RECIBO = tbNroReciboC.Text.Trim();
            numeroRecibo nr = new numeroRecibo();
            bool EXISTE = nr.existeReciboC(PTO_VTA, NRO_RECIBO);

            if (EXISTE == false)
            {
                BO_CAJA.asignarReciboC(ID_RECIBO, PTO_VTA);
            }
            else
            {
                MessageBox.Show("EL RECIBO C NRO " + NRO_RECIBO + " DEL PUNTO DE VENTA " + PTO_VTA + " YA SE ENCUENTRA ASIGNADO");
            }
        }
    }
}
