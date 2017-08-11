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
        public modificarCajaDiaria(string ID, string FECHA, string EFECTIVO, string OTROS, string SUBTOTAL, string EGRESOS, string SALDO, string TOTAL)
        {
            InitializeComponent();
            cargaInicial(ID, FECHA, EFECTIVO, OTROS, SUBTOTAL, EGRESOS, SALDO, TOTAL);
        }

        private void cargaInicial(string ID, string FECHA, string EFECTIVO, string OTROS, string SUBTOTAL, string EGRESOS, string SALDO, string TOTAL)
        {
            int INT_SUBTOTAL = int.Parse(EFECTIVO) + int.Parse(OTROS);
            gbCaja.Text = "MODIFICAR TOTALES DE CAJA DEL " + FECHA;
            
            tbEfectivo.Text = EFECTIVO;
            tbOtros.Text = OTROS;
            tbSubtotal.Text = SUBTOTAL;
            tbEgresos.Text = EGRESOS;
            tbSaldo.Text = SALDO;
            tbTotal.Text = TOTAL;
            
            lbEfectivo.Text = EFECTIVO;
            lbOtros.Text = OTROS;
            lbSubtotal.Text = INT_SUBTOTAL.ToString();
            lbEgresos.Text = EGRESOS;
            lbSaldos.Text = SALDO;
            lbTotal.Text = TOTAL;
        }
    }
}
