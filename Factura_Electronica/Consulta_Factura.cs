using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Factura_Electronica
{
    public partial class Consulta_Factura : Form
    {
        FacturaCSPFA serviceFactura;
        Afip.ComprobanteAfip comp;
        BO.BO_Afip dlog = new BO.BO_Afip();
        public Consulta_Factura()
        {
            InitializeComponent();
            this.Cargo_COMBO();
        }


        private void Cargo_COMBO()
        {

            string query = "select PTO_VTA ID from puntos_de_Venta  order  by PTO_VTA ";


            ComboPtoVenta.DataSource = null;
            ComboPtoVenta.Items.Clear();
            ComboPtoVenta.DataSource = dlog.BO_EjecutoDataTable(query);
            ComboPtoVenta.DisplayMember = "ID";
            ComboPtoVenta.ValueMember = "ID";
            ComboPtoVenta.SelectedItem = 1;
        }
        private void CONSULTA_Click(object sender, EventArgs e)
        {
             int Punto = Int32.Parse(ComboPtoVenta.SelectedValue.ToString());
             int Numero = Int32.Parse(tbNumeroConsulta.Text);
            lbEstado.Text ="";
            lbCAE.Text ="";
            lbDocumento.Text ="";
            lbFecha.Text ="";
            lbNumero.Text ="";
            lbPuntoVenta.Text ="";
            lbVencimiento.Text ="";
          
            serviceFactura = new FacturaCSPFA(Punto);
            comp =    serviceFactura.Consulta_Facturacion((int)Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C,Punto,Numero );
                if (comp.CAE.Length > 0)
                {
                    lbEstado.Text       = "Comprobante Encontrado en AFIP";
                    lbPuntoVenta.Text   = Punto.ToString();
                    lbNumero.Text       = Numero.ToString();
                    lbCAE.Text          = comp.CAE;
                    lbDocumento.Text    = comp.CUIT;
                    lbFecha.Text        = comp.FECHA;
                    lbVencimiento.Text  = comp.FECHA_VENC;
                    lbMonto.Text        = comp.TOTAL.ToString();

                }
                else
                {
                    lbEstado.Text = "Comprobante NO Existe en AFIP";
                    
        
                }

        }
    }
}
