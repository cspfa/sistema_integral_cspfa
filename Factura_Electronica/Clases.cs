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

        }



       


    }


    #endregion
}
