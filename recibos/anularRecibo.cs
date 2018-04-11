using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace SOCIOS
{
    public partial class anularRecibo : Form
    {
        BO.bo_Caja BO_CAJA = new BO.bo_Caja();
        bo dlog = new bo();
        existe ex = new existe();

        public anularRecibo()
        {
            InitializeComponent();
            comboPtoVta();
        }

        private void comboPtoVta()
        {
            string ROL = VGlobales.vp_role;

            if (ROL == "INFORMES")
            {
                ROL = "CAJA";
            }

            string query = "SELECT PTO_VTA FROM PUNTOS_DE_VENTA WHERE ROL = '" + ROL + "' AND ACCION = 'N';";

            if (ROL == "CAJA")
            {
                query = "SELECT PTO_VTA FROM PUNTOS_DE_VENTA ORDER BY PTO_VTA;";
            }
            
            cbPtoVta.DataSource = null;
            cbPtoVta.Items.Clear();
            cbPtoVta.DataSource = dlog.BO_EjecutoDataTable(query);
            cbPtoVta.DisplayMember = "PTO_VTA";
            cbPtoVta.ValueMember = "PTO_VTA";
            cbPtoVta.SelectedItem = 0;
        }

        private void anular(int NRO, string COMPROBANTE, string TABLA, string FECHA, string PTO_VTA)
        {
            string ACCION = "";
            TextBox CAMPO = null;

            if (COMPROBANTE == "RECIBO")
                CAMPO = tbNroRecibo;

            if (COMPROBANTE == "BONO")
                CAMPO = tbNroBono;

            if (FECHA == null)
                ACCION = "RESTABLECIDO";
            else
                ACCION = "ANULADO";

            if (CAMPO.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO " + COMPROBANTE + " Nº", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ex.check(TABLA, "NRO_COMP", NRO.ToString()) == false)
            {
                MessageBox.Show("EL NUMERO DEL " + COMPROBANTE + " INGRESADO NO EXISTE", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (COMPROBANTE == "RECIBO")
                        BO_CAJA.anularRecibo(NRO, FECHA, PTO_VTA);

                    if (COMPROBANTE == "BONO")
                        BO_CAJA.anularBono(NRO, FECHA, PTO_VTA);

                    MessageBox.Show(COMPROBANTE + " " + ACCION + " CORRECTAMENTE", "LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ANULAR EL " + COMPROBANTE + "\n" + error, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int NRO = int.Parse(tbNroRecibo.Text.Trim());
            string COMPROBANTE = "RECIBO";
            string TABLA = "RECIBOS_CAJA";
            string FECHA = DateTime.Now.ToString();
            string PTO_VTA = cbPtoVta.SelectedValue.ToString();
            anular(NRO, COMPROBANTE, TABLA, FECHA, PTO_VTA);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int NRO = int.Parse(tbNroBono.Text.Trim());
            string COMPROBANTE = "BONO";
            string TABLA = "BONOS_CAJA";
            string FECHA = DateTime.Now.ToString();
            string PTO_VTA = cbPtoVta.SelectedValue.ToString();
            anular(NRO, COMPROBANTE, TABLA, FECHA, PTO_VTA);
        }

        private void btnUndoRecibo_Click(object sender, EventArgs e)
        {
            int NRO = int.Parse(tbNroRecibo.Text.Trim());
            string COMPROBANTE = "RECIBO";
            string TABLA = "RECIBOS_CAJA";
            string FECHA = null;
            string PTO_VTA = cbPtoVta.SelectedValue.ToString();
            anular(NRO, COMPROBANTE, TABLA, FECHA, PTO_VTA);
        }

        private void btnUndoBono_Click(object sender, EventArgs e)
        {
            int NRO = int.Parse(tbNroBono.Text.Trim());
            string COMPROBANTE = "BONO";
            string TABLA = "BONOS_CAJA";
            string FECHA = null;
            string PTO_VTA = cbPtoVta.SelectedValue.ToString();
            anular(NRO, COMPROBANTE, TABLA, FECHA, PTO_VTA); ;
        }
    }
}
