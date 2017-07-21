using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Firebird;

namespace SOCIOS
{
    public partial class tarjetas : Form
    {
        bo dlog = new bo();

        public  int CUOTAS = 0;
        public string IMPORTE_TOTAL = "";
        public string IMPORTE_CUOTA = "";

   

        public tarjetas()
        {
            InitializeComponent();
            comboTarjetas();
        }

        public tarjetas(decimal Importe)
        {
            InitializeComponent();
            comboTarjetas();
            txtImporte.Text = string.Format("{0:n}", Importe); 
        }
        private void comboTarjetas()
        {
            cbTarjetas.DataSource = null;
            string query = "SELECT ID, NOMBRE FROM TARJETAS ORDER BY ID;";
            cbTarjetas.Items.Clear();
            cbTarjetas.SelectedItem = 0;
            cbTarjetas.DataSource = dlog.BO_EjecutoDataTable(query);
            cbTarjetas.DisplayMember = "NOMBRE";
            cbTarjetas.ValueMember = "ID";
        }

        private string obtenerCoeficiente(int TARJETA, int CUOTAS)
        {
            string QUERY = "SELECT COEFICIENTE FROM TARJETAS_COEFICIENTES WHERE TARJETA = " + TARJETA + " AND CUOTAS = " + CUOTAS;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return foundRows[0][0].ToString().Trim();
            }
            else
            {
                return "0";
            }
        }

        private decimal calcularTotal(int TARJETA, decimal IMPORTE, int CUOTAS)
        {
            if (CUOTAS == 1)
            {
                return IMPORTE;
            }
            else
            {
                string COEFICIENTE = obtenerCoeficiente(TARJETA, CUOTAS);
                decimal TOTAL = Convert.ToDecimal(IMPORTE * int.Parse(COEFICIENTE)/10000);
                return TOTAL;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCuotas.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA CANTIDAD DE CUOTAS");
            }
            else if (Convert.ToInt16(txtCuotas.Text.Trim()) > 12)
            {
                MessageBox.Show("LA CANTIDAD DE CUOTAS NO PUEDE SER MAYOR QUE 12");
            }
            else if (txtImporte.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR EL IMPORTE A CALCULAR");
            }
            else
            {
                int TARJETA = Convert.ToInt16(cbTarjetas.SelectedValue.ToString());
                decimal IMPORTE = Convert.ToDecimal(txtImporte.Text.Trim());
                 CUOTAS = Convert.ToInt16(txtCuotas.Text.Trim());
                decimal TOTAL = calcularTotal(TARJETA, IMPORTE, CUOTAS);
                decimal VALOR_CUOTA = TOTAL / CUOTAS;

                IMPORTE_TOTAL = string.Format("{0:n}", TOTAL);
                IMPORTE_CUOTA = string.Format("{0:n}", VALOR_CUOTA);

                lbTotal.Text = IMPORTE_TOTAL.ToString();
                lbCuota.Text = IMPORTE_CUOTA.ToString();
                btCerrar.Visible = true;
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string CUOTAS = txtCuotas.Text.Trim();
                string TARJETA = cbTarjetas.Text;
                string IMPORTE = txtImporte.Text;
                IMPORTE = string.Format("{0:n}", IMPORTE);
                string VOUCHER = txtVoucher.Text;
                string IMPORTE_FINANCIADO = lbTotal.Text;
                string VALOR_CUOTA = lbCuota.Text;
                genHTML gen = new genHTML();
                gen.cuotasTarjetas(CUOTAS, TARJETA, IMPORTE, IMPORTE_FINANCIADO, VALOR_CUOTA, VOUCHER);
                printhtml p = new printhtml();
                p.printHTML("tarjetas_cuotas.html");
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL INTENTAR IMPRIMIR\n" + error);
            }
        }
    }
}
