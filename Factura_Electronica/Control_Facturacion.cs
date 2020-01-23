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
    public partial class Control_Facturacion : Form
    {
        FacturaCSPFA serviceFactura;
        Afip.ComprobanteAfip comp;
        BO.BO_Afip dlog = new BO.BO_Afip();
        List<InfoFacturaTotal> recibos = new List<InfoFacturaTotal>();
        List<InfoFacturaTotal> Lista_Internos = new List<InfoFacturaTotal>();

        public Control_Facturacion()
        {
            InitializeComponent();
            this.Cargo_COMBO();
        }

        private void Control_Facturacion_Load(object sender, EventArgs e)
        {

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

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            recibos = new List<InfoFacturaTotal>();
            Lista_Internos = new List<InfoFacturaTotal>();
            dgvRecibos.DataSource = null;
            this.Proceso_Consulta();
        }

        private void Proceso_Consulta()
        {
            int ptoVta = Int32.Parse(ComboPtoVenta.SelectedValue.ToString());
            int Desde = Int32.Parse(tbDesde.Text);
            int Hasta = Int32.Parse(tbHasta.Text);
           
            this.Obtener_Afip(ptoVta, Desde, Hasta);



        
        }

        private void Obtener_Afip (int Pto_Vta,int Desde,int Hasta)
        {
            List<ReporteFacturaTotal> lista_final = new List<ReporteFacturaTotal>();

            this.Obtener_Internos(Pto_Vta, Desde, Hasta);
            serviceFactura = new FacturaCSPFA(4);
           while(Desde<=Hasta)
           {
             InfoFacturaTotal item = new InfoFacturaTotal();
             

                comp =    serviceFactura.Consulta_Facturacion((int)Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C,Pto_Vta,Desde );
                if (comp.CAE.Length > 0)
                {
                    
                    item.NUMERO = Desde.ToString();
                   
                    item.PUNTO_VENTA     = Pto_Vta;
                    item.CAE             = comp.CAE;
                    item.CUIT            =  comp.CUIT;
                    item.FECHA_VENC     = comp.FECHA_VENC;
                    item.TOTAL           = Double.Parse(comp.TOTAL.ToString());
                    var x = Lista_Internos.Where(b=>(b.NUMERO==Desde.ToString() && b.PUNTO_VENTA==Pto_Vta)).FirstOrDefault();
                  
                    if (x!=null)
                    {
                      item.CAE_INTERNO = x.CAE_INTERNO;
                      item.VALOR_INTERNO = x.VALOR_INTERNO;
                      item.VENC_INTERNO =x.VENC_INTERNO;
                      item.DNI_INTERNO =x.DNI_INTERNO;
                     
                    }
                  
                    recibos.Add(item);

                }
               

          
            Desde = Desde+1;
           }

           foreach (InfoFacturaTotal item in recibos)
           {
               ReporteFacturaTotal rft = new ReporteFacturaTotal();
               rft.CAE_AFIP = item.CAE;
               rft.MONTO_AFIP = item.TOTAL.ToString();
               rft.VENC_AFIP = item.FECHA_VENC;

               rft.CAE_INT = item.CAE_INTERNO;
               rft.MONTO_INT = item.VALOR_INTERNO.ToString();
               rft.VENC_INT = item.VENC_INTERNO;

               rft.NUMERO = item.NUMERO;
               rft.RECEPTOR = item.CUIT;
               if (rft.MONTO_AFIP != rft.MONTO_INT)
                   rft.ALERT = true;

               lista_final.Add(rft);

           
           }

            dgvRecibos.DataSource= lista_final;
            
        
        
        }

        private void Obtener_Internos(int Pto_Vta,int Desde,int Hasta)
            
             {
                 Lista_Internos = new List<InfoFacturaTotal>();
           InfoFacturaTotal item = new InfoFacturaTotal();

           string QUERY = @"select VALOR,DNI,CAE,CAE_VENC,pto_vta_e,numero_e from recibos_caja where (USR_FACT is not null) and pto_vta_e="+Pto_Vta.ToString()+"  and NUMERO_E>="+Desde.ToString()+" and numero_e<=  "+ Hasta.ToString();

            



            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

                   if (foundRows.Length > 0)
                   {
                              
                       for(int I=0;I<foundRows.Length;I++)
                          {

                             item = new InfoFacturaTotal();
                             if (foundRows[I][0].ToString().Length > 0)
                                 item.VALOR_INTERNO = Decimal.Round(Decimal.Parse(foundRows[I][0].ToString().Trim()), 2);
                             else
                                 item.VALOR_INTERNO = 0;
                             if (foundRows[I][1].ToString().Length > 0)
                                 item.DNI_INTERNO = foundRows[I][1].ToString().Trim();
                             else
                                 item.DNI_INTERNO = "";
                             item.CAE_INTERNO = foundRows[I][2].ToString().Trim();
                             item.VENC_INTERNO = foundRows[I][3].ToString().Trim();
                             item.PUNTO_VENTA = Int32.Parse( foundRows[I][4].ToString().Trim());
                             item.NUMERO = foundRows[I][5].ToString().Trim();
                             Lista_Internos.Add(item);
                           }

                   }
             }





        
     }


    }

