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
    public partial class modificarCajaDiaria : Form
    {
        BO.bo_Caja BO_CAJA = new BO.bo_Caja();

        private int ID_CAJA { get; set; }

        public modificarCajaDiaria(string ID, string FECHA, string EFECTIVO, string OTROS, string SUBTOTAL, string EGRESOS, string SALDO, string TOTAL)
        {
            InitializeComponent();
            cargaInicial(ID, FECHA, EFECTIVO, OTROS, SUBTOTAL, EGRESOS, SALDO, TOTAL);
        }

        private decimal sumar(decimal VALOR1, decimal VALOR2)
        {
            decimal SUMA = 0;
            SUMA = VALOR1 + VALOR2;
            return SUMA;
        }

        private void cargaInicial(string ID, string FECHA, string EFECTIVO, string OTROS, string SUBTOTAL, string EGRESOS, string SALDO, string TOTAL)
        {
            decimal INT_SUBTOTAL = decimal.Parse(EFECTIVO) + decimal.Parse(OTROS);
            ID_CAJA = int.Parse(ID);
            gbCaja.Text = "MODIFICAR TOTALES DE CAJA DEL " + FECHA;
            
            tbEfectivo.Text = EFECTIVO;
            tbOtros.Text = OTROS;
            tbSubtotal.Text = string.Format("{0:n}", INT_SUBTOTAL);
            tbEgresos.Text = EGRESOS;
            tbSaldo.Text = SALDO;
            tbTotal.Text = TOTAL;
            
            lbEfectivo.Text = EFECTIVO;
            lbOtros.Text = OTROS;
            lbSubtotal.Text = string.Format("{0:n}", INT_SUBTOTAL);
            lbEgresos.Text = EGRESOS;
            lbSaldos.Text = SALDO;
            lbTotal.Text = TOTAL;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            decimal EFECTIVO = 0;
            decimal OTROS = 0;
            decimal SUBTOTAL = 0;
            decimal EGRESOS = 0;
            decimal SALDO = 0;
            decimal TOTAL = 0;

            EFECTIVO = decimal.Parse(tbEfectivo.Text);
            OTROS = decimal.Parse(tbOtros.Text);
            SUBTOTAL = decimal.Parse(tbSubtotal.Text);
            EGRESOS = decimal.Parse(tbEgresos.Text);
            SALDO = decimal.Parse(tbSaldo.Text);
            TOTAL = decimal.Parse(tbTotal.Text);

            try
            {
                BO_CAJA.modificarCajaDiaria(EFECTIVO, OTROS, SUBTOTAL, EGRESOS, SALDO, TOTAL, ID_CAJA);
                MessageBox.Show("CAJA DIARIA MODIFICADA CORRECTAMENTE", "LISTO!");
            }
            catch (Exception error)
            {
                MessageBox.Show("LA CAJA DIARIA NO PUDO SER MODIFICADA", "ERROR");
            }
        }

        /*private void calcular(TextBox SENDER, TextBox NOSENDER, Label ORIGINAL)
        {
            decimal VALOR1 = 0;
            decimal VALOR2 = 0;
            decimal SUBTOTAL = 0;
            string RESULTADO = string.Empty;
            decimal DIFERENCIA = 0;
            decimal TOTAL = 0;
            decimal VORIGINAL = 0;

            try
            {
                SENDER.BackColor = Color.White;
                VORIGINAL = decimal.Parse(SENDER.Text);
                VALOR1 = decimal.Parse(SENDER.Text);
                VALOR2 = decimal.Parse(NOSENDER.Text);
                SUBTOTAL = sumar(VALOR1, VALOR2);
                RESULTADO = string.Format("{0:n}", SUBTOTAL);
                tbSubtotal.Text = RESULTADO;
                tbSaldo.Text = RESULTADO;
                DIFERENCIA = VALOR1 - VORIGINAL;
                lbDiferencia.Text = DIFERENCIA.ToString();
                TOTAL = decimal.Parse(lbTotal.Text) + DIFERENCIA;
                tbTotal.Text = string.Format("{0:n}", TOTAL);
            }
            catch (Exception error)
            {
                SENDER.BackColor = Color.OrangeRed;
            }
        }*/    
    }
}
