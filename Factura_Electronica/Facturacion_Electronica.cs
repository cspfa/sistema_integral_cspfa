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
        bool Modo_Facturacion_Produccion = false;
        string Punto_VENTA;
              
     
        

        List<AfipServices.wsfev1.FECAEDetRequest> Facturas;
        List<AfipServices.wsfev1.FECAEDetRequest> Notas;
        AfipFactResults Result;
        List<AfipFactErrores> Errors;
        #region Publicas
            public Facturacion_Electronica(int pPuntoVenta)
           {
               
                this.Obtener_Configuracion(pPuntoVenta); // obtengo del config las rutas 
               this.GenerarTicketAcceso();   // genero xml de acceso a AFIP
               this.Logueo();                // me logueo en la factura electronica
           
           }

            public Afip.AfipFactResults Facturar(FacturaHead fh)

            {

                Afip.AfipFactResults Result = new Afip.AfipFactResults();
               


                return facturador.FacturacionUnitaria_SinIVA((int)fh.Pto_Venta, fh.TipoFactura, fh.Concepto, fh.Tipo_Documento, fh.Documento, (DateTime)fh.Fecha, (decimal)fh.Monto, rutaArchivos);
                    
                    



            
            }

            public Afip.ComprobanteAfip Consulta(int TipoComprobante, int PtoVenta, int Numero)
            {

                return   facturador.Consulta(TipoComprobante, PtoVenta, Numero);
            }
        #endregion

        #region Privadas
       private void Obtener_Configuracion(int Punto_Venta)

       {

           if (VGlobales.MODO_FACTURACION.Contains("PROD"))
               Modo_Facturacion_Produccion =true;
           else
               Modo_Facturacion_Produccion=false;


           if (Modo_Facturacion_Produccion)
           {
               rutaCert = "C:/CSPFA_SOCIOS/AFIP/cspfa_Produccion.pfx";
               urlWsaa = "https://wsaa.afip.gov.ar/ws/services/LoginCms?WSDL";
               urlWsfe = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL";
               rutaArchivos = "\\\\192.168.1.6\\factura_electronica\\" + Punto_Venta.ToString().PadLeft(4,'0') + "\\XML";

            }
           else
           {
               rutaCert = "C:/CSPFA_SOCIOS/AFIP/cspfa_Test.pfx";
               urlWsaa = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL";
               urlWsfe = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL";
               rutaArchivos = "\\\\192.168.1.6\\factura_electronica\\TEST\\" + Punto_Venta.ToString().PadLeft(4, '0') + "\\XML";

            }

           rutaTicket = "C:/CSPFA_SOCIOS/AFIP/ticketAcceso.xml";
           

       
       }

                      private void GenerarTicketAcceso()
       {




           Afip.LoginTicket lt = new Afip.LoginTicket();

           lt.CrearTicket("wsfe", urlWsaa, rutaCert, rutaTicket, false);
           double horas = lt.horas;


       }

                      private void Logueo()
       {

           facturador = new Afip.FacturadorAfip(urlWsfe, rutaTicket, rutaArchivos);


       }
       #endregion
    }
}
