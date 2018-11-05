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
    public partial class Testing_Facturacion : Form
    {
        int TipoComprobante = 0;
        int TipoDocumento = 0;
        FacturaCSPFA serviceFactura = new FacturaCSPFA();
        Afip.AfipFactResults result = new Afip.AfipFactResults();
        public Testing_Facturacion()
        {
            InitializeComponent();
            this.Inicializo();

        }

        private void Inicializo()

        {
            cbTipoComprobante.Items.Insert(0, "RECIBOS C");
            cbTipoComprobante.Items.Insert(1, "NOTAS DE VENTA AL CONTADO C");
            
            cbTipoComprobante.SelectedIndex = 0;
            cbTipoComprobante.Refresh();

            cbTipoComprobanteConsulta.Items.Insert(0, "RECIBOS C");
            cbTipoComprobanteConsulta.Items.Insert(1, "NOTAS DE VENTA AL CONTADO C");

            cbTipoComprobanteConsulta.SelectedIndex = 0;
            cbTipoComprobanteConsulta.Refresh();

            cbTipoDocumento.Items.Insert(0, "DNI");
            cbTipoDocumento.Items.Insert(1, "CUIT");
            cbTipoDocumento.Items.Insert(2, "CON. FINAL.");
            cbTipoDocumento.SelectedIndex = 0;
            cbTipoDocumento.Refresh();
        
        }

        private void ObtenerDatos()
        {
            if (cbTipoComprobante.Text.Contains("RECIBOS C"))
            {
                TipoComprobante = (int)Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C;
            }
            else
                TipoComprobante = (int)Factura_Electronica.Tipo_Comprobante_Enum.NOTA_VENTA_C; 
            if ((cbTipoDocumento.Text.Contains("DNI")))
                TipoDocumento =(int)Factura_Electronica.Tipo_Doc_Enum.DNI;
            else if ((cbTipoDocumento.Text.Contains("CUIT")))
                TipoDocumento = (int)Factura_Electronica.Tipo_Doc_Enum.CUIT;
            else
                TipoDocumento = (int)Factura_Electronica.Tipo_Doc_Enum.CONSUMIDOR_FINAL; //Consumidor Final

              

        }

        private void Facturar_Click(object sender, EventArgs e)
        {
            this.ObtenerDatos();


            try
            {

                result = serviceFactura.Facturar(Int32.Parse(tbPuntoVenta.Text),dtFecha.Value,TipoComprobante,TipoDocumento,tbDni.Text,2,decimal.Parse(tbMonto.Text));
                lbCAE.Text = result.Cae;
                lbVencimiento.Text = result.Vencimiento;
                lbNumero.Text = result.Numero.ToString();
                lbPuntoVenta.Text = tbPuntoVenta.Text;
                
            }
            catch (Exception ex)

            {
                lbResult.Text = "ERROR" +ex.Message;
            
            
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           FacturaCSPFA serviceFactura = new FacturaCSPFA();
           int Punto_Venta = 1;
           string Documento =  "34068061";
           int ID_RECIBO = 99226;
           decimal Monto = Decimal.Parse(tbMonto.Text);


           serviceFactura.Facturo_Recibo(ID_RECIBO, Punto_Venta, (int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C, (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.DNI,Documento,Monto, System.DateTime.Now);

               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {   string DIR =@"c:\CSPFA_SOCIOS\";
                Impresor_Factura imp_factura = new Impresor_Factura(DIR);
                //imp_factura.Genero_PDF((int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C, 1, 250, System.DateTime.Now, "20340680619", "Consumidor Final", "Sebastian Auladell", "Roosevelt 3443 1431 CABA", 1600, "68399680115324", "20-11-2018","ORIGINAL","CONTADO");
                MessageBox.Show("Factura impresa en " + DIR);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RESULTADO_CONSULTA_Click(object sender, EventArgs e)
        {

        }

        private void CONSULTA_Click(object sender, EventArgs e)
        {
            int PuntoVenta = 0;
            int Numero     = 0;
            int TipoComprobante = 0;

            PuntoVenta = Int32.Parse(tbPtoVentaConsulta.Text);
            Numero = Int32.Parse(tbNumeroConsulta.Text);
           
            
            if (cbTipoComprobanteConsulta.Text.Contains("RECIBOS C"))
            {
                TipoComprobante = (int)Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C;
            }
            else
                TipoComprobante = (int)Factura_Electronica.Tipo_Comprobante_Enum.NOTA_VENTA_C;

          RESULTADO_CONSULTA.Text= serviceFactura.Consulta_Facturacion(TipoComprobante, PuntoVenta, Numero);
        }
    }
}
