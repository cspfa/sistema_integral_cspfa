using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.Factura_Electronica
{
   public class FacturaCSPFA
    {
       Facturacion_Electronica sf ;
       SOCIOS.BO.BO_Afip bo_Afip = new BO.BO_Afip();
       string CUIT_ENTIDAD = "30516588213";
       public FacturaCSPFA(int PuntoVenta)

       {
           sf = new Facturacion_Electronica(PuntoVenta);


       
       
       }
       public Afip.AfipFactResults Facturar(int PuntoVenta, DateTime Fecha, int TipoComprobante, int TipoDocumento, string Documento,int Concepto, Decimal Monto)
       {

           FacturaHead fh = new FacturaHead(Fecha, PuntoVenta, TipoComprobante, Monto, TipoDocumento, Documento, Concepto);



           return sf.Facturar(fh);
          
       
       }


       public Afip.ComprobanteAfip Consulta_Facturacion(int TipoComprobante ,int PuntoVenta,int Numero)
           {

               return sf.Consulta(TipoComprobante, PuntoVenta, Numero);

           }


       //Tipo de Comprobante : 15 RECIBO c , 16 NOTA DE VENTA AL CONTADO
       //Tipo Documento      : 96 DNI      , 80 CUIT 
       public Recibo_Request Facturo_Recibo(int ID_REGISTRO_RECIBO, int PTO_VENTA, int Tipo_COMPROBANTE, int TipoDocumento, string Documento, decimal Monto, DateTime Fecha)

       {
           

           try
           {
               
               Afip.AfipFactResults result_request = this.Facturar(PTO_VENTA, Fecha, Tipo_COMPROBANTE, TipoDocumento, Documento, 2, Monto);
               this.Marcar_Facturacion(ID_REGISTRO_RECIBO, PTO_VENTA, result_request.Numero, result_request.Cae, result_request.Vencimiento,true);
               return Exito_Request(result_request);


           } catch(Exception EX)
           {
               Recibo_Request result = new Recibo_Request();   
               result.Result = false;
               result.Excepcion = EX;
               return result;
               
           }


       
       }

       private Recibo_Request Exito_Request(Afip.AfipFactResults result)
       {
           Recibo_Request item = new Recibo_Request();
           item.Cae = result.Cae;
           item.Punto_Venta = result.Punto_Venta;
           item.Numero = result.Numero;
           item.Secuencia = result.Secuencia;
           item.Vencimiento = result.Vencimiento;
           item.Excepcion=null;
           item.Result = true;
           return item;

       
       }

       

       
       
       public void Marcar_Facturacion(int ID_REGISTRO_RECIBO,int PTO_VENTA,int NUMERO, string CAE, string VENC_CAE,bool Recibo)

       {
          if (Recibo)
             bo_Afip.Marca_Afip_Recibo(ID_REGISTRO_RECIBO,PTO_VENTA,NUMERO, CAE, VENC_CAE);
          else
              bo_Afip.Marca_Afip_Bono(ID_REGISTRO_RECIBO, PTO_VENTA, NUMERO, CAE, VENC_CAE);
       
       }

       public string Codigo_Barra(string TipoFactura,int Pto,string CAE,string VencimientoCAE)
       {
           
        return CUIT_ENTIDAD +TipoFactura + Utils.CompletarCeros(Pto.ToString(), false, 4) + Utils.CompletarCeros(CAE, false, 13) + VencimientoCAE + "9";
       }


    }
}
