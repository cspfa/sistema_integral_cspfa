using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.Factura_Electronica
{
   public class FacturaCSPFA
    {
       Facturacion_Electronica sf = new Facturacion_Electronica();
       SOCIOS.BO.BO_Afip bo_Afip = new BO.BO_Afip();

       public Afip.AfipFactResults Facturar(int PuntoVenta, DateTime Fecha, int TipoComprobante, int TipoDocumento, string Documento,int Concepto, Decimal Monto)
       {
           FacturaHead fh = new FacturaHead(Fecha, PuntoVenta, TipoComprobante, Monto, TipoDocumento, Documento, Concepto);

           return sf.Facturar(fh);
          
       
       }

       //Tipo de Comprobante : 15 RECIBO c , 16 NOTA DE VENTA AL CONTADO
       //Tipo Documento      : 96 DNI      , 80 CUIT
       public void Facturo_Recibo(int ID_REGISTRO_RECIBO, int PTO_VENTA, int Tipo_COMPROBANTE, int TipoDocumento, string Documento, decimal Monto,DateTime Fecha)

       {
        

           try
           {
               Afip.AfipFactResults result = this.Facturar(PTO_VENTA, Fecha, Tipo_COMPROBANTE, TipoDocumento, Documento, 2, Monto);
               this.Marcar_Facturacion(ID_REGISTRO_RECIBO, PTO_VENTA, result.Numero, result.Cae, result.Vencimiento);


           } catch(Exception EX)
               
           {
               
           }


       
       }

       

       
       
       public void Marcar_Facturacion(int ID_REGISTRO_RECIBO,int PTO_VENTA,int NUMERO, string CAE, string VENC_CAE)

       {
               bo_Afip.Marca_Afip(ID_REGISTRO_RECIBO,PTO_VENTA,NUMERO, CAE, VENC_CAE);
       
       
       }




    }
}
