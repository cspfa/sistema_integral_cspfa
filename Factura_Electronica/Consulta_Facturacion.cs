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
    public partial class Consulta_Facturacion : Form
    {
        FacturaCSPFA sf;
        BO.BO_Afip dlog = new BO.BO_Afip();

        public Consulta_Facturacion()
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


        private void Consulta_Click(object sender, EventArgs e)
        {

            int Punto = Int32.Parse(ComboPtoVenta.SelectedValue.ToString());

            sf = new FacturaCSPFA(Punto);
            DGV_FACTURAS.DataSource= sf.Consulta_Facturacion((int)Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C,Punto,dpDesde.Value,dpHasta.Value);


        }

        private void btnConsultaUnitaria_Click(object sender, EventArgs e)
        {
            Consulta_Factura cf = new Consulta_Factura();
            cf.ShowDialog();
        }

      
    }
}
