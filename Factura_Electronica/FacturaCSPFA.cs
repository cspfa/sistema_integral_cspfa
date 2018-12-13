using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Data;

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
       public List<Info_Afip_Comprobante> Consulta_Facturacion(int TipoComprobante, int PuntoVenta, DateTime Desde, DateTime Hasta)
       {
           
           List<Info_Afip_Comprobante> lista = new List<Info_Afip_Comprobante>();
           foreach (Check_Recibo item in this.Recibos(PuntoVenta, Desde, Hasta))
           {
               Afip.ComprobanteAfip comprobante = this.Consulta_Facturacion(TipoComprobante, PuntoVenta, item.Numero);
               if (comprobante.CAE.Length > 0)
               {
                   lista.Add(new Info_Afip_Comprobante(PuntoVenta,item.Numero,comprobante.FECHA,comprobante.TOTAL,comprobante.CUIT,comprobante.CAE,comprobante.FECHA_VENC));
               }

           }

           return lista.OrderBy(x=>x.Numero).ToList();


       }



       private List<Check_Recibo> Recibos (int Punto_Venta, DateTime pDesde, DateTime pHasta )
       {
           decimal Monto = 0;
           string Desde = this.fechaUSA(pDesde);
           string Hasta = this.fechaUSA(pHasta);
           List<Check_Recibo> Lista = new List<Check_Recibo>();

           string Query = "SELECT NUMERO_E  NUM from recibos_caja where char_length(CAE)>0 and PTO_VTA_E=" + Punto_Venta.ToString()+ " and Fecha_recibo  Between  '" + Desde + "' AND '" + Hasta + "'";;



           string connectionString;

           DataSet ds1 = new DataSet();

           Datos_ini ini3 = new Datos_ini();


           FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
           cs.DataSource = ini3.Servidor; //cs.Port = int.Parse(ini3.Puerto);
           cs.Database = ini3.Ubicacion;
           cs.UserID = VGlobales.vp_username;
           cs.Password = VGlobales.vp_password;
           cs.Role = VGlobales.vp_role;
           cs.Dialect = 3;
           connectionString = cs.ToString();

           using (FbConnection connection = new FbConnection(connectionString))
           {
               connection.Open();

               FbTransaction transaction = connection.BeginTransaction();

               DataTable dt1 = new DataTable("RESULTADOS");

               dt1.Columns.Add("NUM", typeof(string));


               ds1.Tables.Add(dt1);

               FbCommand cmd = new FbCommand(Query, connection, transaction);

               FbDataReader reader3 = cmd.ExecuteReader();

               while (reader3.Read())
               {

                   Check_Recibo check = new Check_Recibo();

                   
                  check.Numero      =  Int32.Parse(reader3.GetString(reader3.GetOrdinal("NUM")).Trim());
                  check.Pto_Venta = Punto_Venta;
                  Lista.Add(check);

                   







               }



           }

           return Lista;

       }

       private string fechaUSA(DateTime fecha)
       {
           string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");

           return Fecha;


       }



       //Tipo de Comprobante : 15 RECIBO c , 16 NOTA DE VENTA AL CONTADO
       //Tipo Documento      : 96 DNI      , 80 CUIT 
       public Recibo_Request Facturo_Recibo(int ID_REGISTRO_RECIBO, int PTO_VENTA, int Tipo_COMPROBANTE, int TipoDocumento, string Documento, decimal Monto, DateTime Fecha,int Modo_Facturacion)

       {          

           try
           {

               if (Modo_Facturacion == (int)SOCIOS.Factura_Electronica.Tipo_FACTURACION_ENUM.UNITARIA)
               {
                   // Facturacion Unitaria , factura como siempre
                   Afip.AfipFactResults result_request = this.Facturar(PTO_VENTA, Fecha, Tipo_COMPROBANTE, TipoDocumento, Documento, 2, Monto);


                   this.Marcar_Facturacion(ID_REGISTRO_RECIBO, PTO_VENTA, result_request.Numero, result_request.Cae, result_request.Vencimiento, true, Modo_Facturacion);

                   return Exito_Request(result_request);
               }
               else
               { // Facturacion Modal , Divide el monto en varias facturas sucesivas 
                   Recibo_Request result = new Recibo_Request();

                    return result;
               }


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

       

       
       
       public void Marcar_Facturacion(int ID_REGISTRO_RECIBO,int PTO_VENTA,int NUMERO, string CAE, string VENC_CAE,bool Recibo, int Modo_Facturacion)

       {
           if (Recibo)
           {
               if (Modo_Facturacion == (int)SOCIOS.Factura_Electronica.Tipo_FACTURACION_ENUM.UNITARIA)
               {
                   bo_Afip.Marca_Afip_Recibo(ID_REGISTRO_RECIBO, PTO_VENTA, NUMERO, CAE, VENC_CAE, Modo_Facturacion);
                   bo_Afip.Marca_Afip_Recibo_Factura_I(ID_REGISTRO_RECIBO, CAE, VENC_CAE, PTO_VENTA, NUMERO);
               }
               else
               { 
               
               
               }
           }
           else
               bo_Afip.Marca_Afip_Bono(ID_REGISTRO_RECIBO, PTO_VENTA, NUMERO, CAE, VENC_CAE);


       
       }

       public string Codigo_Barra(string TipoFactura,int Pto,string CAE,string VencimientoCAE)
       {
           
        return CUIT_ENTIDAD +TipoFactura + Utils.CompletarCeros(Pto.ToString(), false, 4) + Utils.CompletarCeros(CAE, false, 13) + VencimientoCAE + "9";
       }


    }
}
