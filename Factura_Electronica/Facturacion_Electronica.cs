using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.Factura_Electronica
{
   public  class Facturacion_Electronica
    {

        string urlWsaa;
        string urlWsfe;
        string rutaCert;
        string rutaTicket;
        string rutaArchivos;
        Afip.FacturadorAfip facturador;
      

        List<AfipServices.wsfev1.FECAEDetRequest> Facturas;
        List<AfipServices.wsfev1.FECAEDetRequest> Notas;
        AfipFactResults Result;
        List<AfipFactErrores> Errors;
        #region Publicas
            public Facturacion_Electronica()
           {
               this.Obtener_Configuracion(); // obtengo del config las rutas 
               this.GenerarTicketAcceso();   // genero xml de acceso a AFIP
               this.Logueo();                // me logueo en la factura electronica
           
           }

            public Afip.AfipFactResults Facturar(FacturaHead fh)

            {

                Afip.AfipFactResults Result;
               
                           
               return facturador.FacturacionUnitaria_SinIVA((int)fh.Pto_Venta,fh.TipoFactura,fh.Concepto ,fh.Tipo_Documento , fh.Documento, (DateTime)fh.Fecha, (decimal)fh.Monto, "");
                    
                    



            
            }
        #endregion

        #region Privadas
                      private void Obtener_Configuracion()

       {
           rutaCert = "C:/CSPFA_SOCIOS/AFIP/cspfa.pfx";
           urlWsaa = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL";
           urlWsfe ="https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL";

           rutaTicket = "C:/CSPFA_SOCIOS/AFIP/ticketAcceso.xml";
           rutaArchivos ="C:/CSPFA_SOCIOS/AFIP/XML/";

       
       }

                      private void GenerarTicketAcceso()
       {




           Afip.LoginTicket lt = new Afip.LoginTicket();

           lt.CrearTicket("wsfe", urlWsaa, rutaCert, rutaTicket, false);



       }

                      private void Logueo()
       {

           facturador = new Afip.FacturadorAfip(urlWsfe, rutaTicket, rutaArchivos);


       }
       #endregion
    }
}
