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
            // Validaciones 
            if (Tipo_Documento == (int)Factura_Electronica.Tipo_Doc_Enum.CONSUMIDOR_FINAL)
            {
                if (Monto > 5000)
                    throw new Exception("No se puede facturar a consumidor final mas de $5000");
                Documento = "0";
            
            }



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
            Factura_Electronica.FacturaCSPFA srvFactura = new FacturaCSPFA();
            
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


    #endregion
}
