using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.Factura_Electronica
{
    public class PreFacturado
    {
      public   List<InfoPreFactura> Facturar_Registros_Recibo(int ID_RECIBO, int Pto_Vta)
        {
            List<InfoPreFactura> lista = new List<InfoPreFactura>();
            SOCIOS.BO.BO_Afip dlog = new SOCIOS.BO.BO_Afip();
            DataRow[] foundRows;
            bool Ya_Facturado = false;
           
            FacturaCSPFA sf = new FacturaCSPFA(Pto_Vta);
            string QUERY = "SELECT MONTO,ID,Tipo_Documento,Documento,Tipo_Comprobante,Concepto,Fecha,PTO_VTA_E,NUMERO_E,CAE,CAE_VENC,FECHA_FACTURACION FROM FACTURA_RECIBO_CAJA WHERE RECIBO_CAJA= " + ID_RECIBO.ToString();
            InfoPreFactura info = new InfoPreFactura();
           

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {
                int I = 0;
                for (int i = 0; i < foundRows.Length; i++)
                {
                 info = new InfoPreFactura();
                 decimal Importe = Decimal.Round( Decimal.Parse(foundRows[I][0].ToString().Trim()),2);
                 int ID          = Int32.Parse(foundRows[I][1].ToString().Trim());
                 int TipoDoc     = Int32.Parse(foundRows[I][2].ToString().Trim());
                 string DOC      =foundRows[I][3].ToString().Trim();
                 int Tipo_Comprobante = Int32.Parse(foundRows[I][4].ToString().Trim());
                 int Concepto = Int32.Parse(foundRows[I][5].ToString().Trim());
                 DateTime Fecha = DateTime.Parse(foundRows[I][6].ToString().Trim());

                 info.MONTO = Importe;
                 info.ID = ID;
                 info.TIPO_DOC = TipoDoc;
                 info.DOC = DOC;
                 info.TIPO_COMPROBANTE = Tipo_Comprobante;
                 info.CONCEPTO = Concepto;
                 info.FECHA = Fecha;


                 if (foundRows[I][9].ToString().Trim().Length > 0)
                 {
                     Ya_Facturado = true;
                     info.Punto_Venta = Int32.Parse(foundRows[I][7].ToString().Trim());
                     info.Numero      = Int32.Parse(foundRows[I][8].ToString().Trim());
                     info.Cae         =foundRows[I][9].ToString().Trim();
                     info.Vencimiento = foundRows[I][10].ToString().Trim();
                     info.FECHA       = DateTime.Parse(foundRows[I][10].ToString().Trim());
 
                    
                 }

                 Afip.AfipFactResults result = new   Afip.AfipFactResults();
                       Recibo_Request   recibo = new Recibo_Request();
                 try
                     {
                         if (!Ya_Facturado)
                         {

                    

                                   result = sf.Facturar(Pto_Vta, Fecha, Tipo_Comprobante, TipoDoc, DOC, Concepto, Importe);



                                   recibo = sf.Exito_Request(result);
                                // 24-12 , si lo acaba de facturar, datos de factura 
                                   info = item_PreFactura(recibo, ID);

                         }
                          
                      } catch (Exception e ) { 

                          recibo.Result = false;
                          recibo.Excepcion = e;
                          Ya_Facturado = false;
                          
                      }

                 lista.Add(info);


                    


               

                    
                   

                           


                 


                 


                }

            }

            return lista;


        }


        InfoPreFactura item_PreFactura(Recibo_Request item,int ID)
        {
            InfoPreFactura pf = new InfoPreFactura();
            pf.Cae            = item.Cae;
            pf.Excepcion      = item.Excepcion;
            pf.ID             = ID;
            pf.Numero         = item.Numero;
            pf.Punto_Venta = item.Punto_Venta;
            pf.Result = item.Result;
            pf.Secuencia = item.Secuencia;
            pf.Vencimiento = item.Vencimiento;
            return pf;
          
        
        }
    }

   
}
