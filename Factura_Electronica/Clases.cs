using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.Factura_Electronica
{
    #region ClasesTipo
    public class AfipFactResults
    {

        public int Numero { get; set; }
        public string Cae { get; set; }
        public string Vencimiento { get; set; }
        public string Fecha { get; set; }
        public string Dni { get; set; }


    }

    public class Recibo_Request : Afip.AfipFactResults
    {
        public bool   Result       { get; set; }
        public Exception Excepcion    { get; set; }
    
    }

    public class InfoPreFactura : Recibo_Request
    {
        public int    ID               { get; set; }
        public int    TIPO_DOC         { get; set; }
        public string DOC              { get; set; }
        public int    TIPO_COMPROBANTE { get; set; }
        public int    CONCEPTO         { get; set; }
        public DateTime FECHA          { get; set; }
        
        public decimal  MONTO          { get; set; }
    }

    public class AfipFactErrores
    {
        public int Numero { get; set; }
        public string Error { get; set; }

    }
    public class FacturaHead
    {
        public DateTime Fecha           { get; set; }
        public int      Pto_Venta       { get; set; }
        public int      Numero          { get; set; }
        public int      TipoFactura     { get; set; }
        public decimal  Monto           { get; set; }
        public int      Tipo_Documento  { get; set; }
        public string   Documento       { get; set; }
        public int      Concepto        { get; set; }


        public FacturaHead(DateTime pFecha, int pPto_Venta, int pTipoFactura, decimal pMonto, int pTipo_Documento, string pDocumento,int pConcepto)
        {
            Fecha          = pFecha;
            Pto_Venta      = pPto_Venta;
           
            TipoFactura    = pTipoFactura;
            Monto          = pMonto;
            Tipo_Documento = pTipo_Documento;
            Documento      = pDocumento;
            Concepto       = pConcepto;
            // Validaciones , se saca la condicion queda todo en base a la extension del documento
            //if ( Tipo_Documento == (int)Factura_Electronica.Tipo_Doc_Enum.CONSUMIDOR_FINAL) 
          
            


                //if (Monto > 5000 && Documento.Length < 9)  // 20-05-2019 se agrega control por extension de documento, menos de 9 es dni
                //    throw new Exception("No se puede facturar a consumidor final mas de $5000");
                



        }

     

       


    }



    public class Datos_Factura
    {
        public string TIPO_DNI                  { get; set; }
        public int    TIPO_FACTURA              { get; set; }
        public string TIPO_FACTURA_DESCRIPCION  { get; set; }
        public string DNI                       { get; set; }
        public string NOMBRE                    { get; set; }
        public string DOMICILIO                 { get; set; }
        public string CONDICION_IVA_SOCIO       { get; set; }
        public string PTO_VENTA                 { get; set; }
        public string NUMERO                    { get; set; }
        public string CAE                       { get; set; }
        public string VENCIMIENTO               { get; set; }
        public decimal MONTO                    { get; set; }
        public string  BARRA                    { get; set; }

        public Datos_Factura(string pTipoDNI, string pDNI, string pNOMBRE, string pDOMICILIO, string pCondicionIVA,int pTipoFactura, string pPTo_Venta, string pNumero, string pCAE, string pCAEVENC, decimal pMONTO)
        {
            Factura_Electronica.FacturaCSPFA srvFactura = new FacturaCSPFA(Int32.Parse(pPTo_Venta));
            
            TIPO_DNI            = pTipoDNI;
            DNI                 = pDNI;
            NOMBRE              = pNOMBRE;
            DOMICILIO           = pDOMICILIO;
            CONDICION_IVA_SOCIO = pCondicionIVA;
            PTO_VENTA           = pPTo_Venta;
            NUMERO              = pNumero;
            CAE                 = pCAE;
            VENCIMIENTO         = pCAEVENC;
            MONTO               = pMONTO;
            TIPO_FACTURA        = pTipoFactura;
           
            if (TIPO_FACTURA ==  (int)Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C)
                 TIPO_FACTURA_DESCRIPCION = "RECIBO C";
            else
                TIPO_FACTURA_DESCRIPCION   = "NOTA CREDITO C";

            BARRA = srvFactura.Codigo_Barra(TIPO_FACTURA.ToString(),Int32.Parse( PTO_VENTA), CAE, VENCIMIENTO);
        }


    }

    public class Check_Recibo
    {
        public int Pto_Venta { get; set; }
        public int Numero    { get; set; }

    }

    public class Info_Afip_Comprobante
    {
        public int Pto_Venta      { get; set; }
        public int Numero         { get; set; }
        public string Fecha       { get; set; }
        public double Total      { get; set; }
        public string Documento   { get; set; }
        public string CAE         { get; set; }
        public string Vencimiento { get; set; }
        
        public Info_Afip_Comprobante(int pPtoVenta, int pNumero, string pFecha, double pTotal, string pDocumento, string pCAE, string pVencimiento)
        {
            Pto_Venta   = pPtoVenta;
            Numero      = pNumero;
            Fecha       = pFecha.Substring(6, 2) + "/" + pFecha.Substring(4, 2) + "/" + pFecha.Substring(0, 4);
            Total       = pTotal;
            Documento   = pDocumento;
            CAE         = pCAE;
            Vencimiento = pVencimiento.Substring(6, 2) + "/" + pVencimiento.Substring(4, 2) + "/" + pVencimiento.Substring(0, 4);

        
        }

    
    }

    public class Info_Pre_Facturado
    {
        public int Pto_Venta        { get; set; }
        public int Tipo_Comprobante { get; set; }
        public int Tipo_Documento    { get; set; }
        public string Documento     { get; set; }
        public DateTime Fecha       { get; set; }
        public Info_Pre_Facturado(int pPtoVta, int pTipoC, int pTipoDoc, string pDoc, DateTime pFecha)
        {
            Pto_Venta        = pPtoVta;
            Tipo_Comprobante = pTipoC;
            Tipo_Documento   = pTipoDoc;
            Documento        = pDoc;
            Fecha            = pFecha;

        
        }
    }

    
    #endregion
}
