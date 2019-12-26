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
       SOCIOS.Factura_Electronica.PreFacturado prefact = new PreFacturado();
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
                   decimal VALOR_AFIP = Valor_Facturado(Tipo_COMPROBANTE, PTO_VENTA, result_request.Numero);
                   
                   if (Tipo_COMPROBANTE == (int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.NOTA_VENTA_C)
                   {
                       this.Marcar_NC(ID_REGISTRO_RECIBO, result_request.Numero, result_request.Cae, result_request.Vencimiento,VALOR_AFIP);
                   }
                   else
                   {
                       this.Marcar_Factura(ID_REGISTRO_RECIBO, PTO_VENTA, result_request.Numero, result_request.Cae, result_request.Vencimiento, true, Modo_Facturacion, Monto, Tipo_COMPROBANTE, TipoDocumento, Documento, 2, Fecha,VALOR_AFIP);
                   }
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

       private decimal Valor_Facturado(int Tipo_Comprobante, int PtoVta, int Numero)
       {

           Afip.ComprobanteAfip comp = sf.Consulta(Tipo_Comprobante, PtoVta, Numero);
           if (comp != null)
           {
               return (decimal)comp.TOTAL;


           }
           else
               return 0;
       }

       private void Facturacion_Multiple(int ID_REGISTRO_RECIBO, int PTO_VENTA, int Tipo_COMPROBANTE, int TipoDocumento, string Documento, decimal Monto, DateTime Fecha)

       {
           List<InfoPreFactura>  pre_Facturas = new List<InfoPreFactura>();

           decimal CANTIDAD_FACTURAS = Decimal.Round( Monto / 4999);
           decimal CANTIDAD_FACTURAS_FLOOR = Math.Floor(CANTIDAD_FACTURAS);
           decimal IMPORTE_FACTURADO = CANTIDAD_FACTURAS_FLOOR * 4999;
           decimal IMPORTE_RESTANTE = Decimal.Round( Monto - IMPORTE_FACTURADO,2);
           
           // Primero se Graban todas las cantidades de facturas, luego. se barre el grabado y se factura 
           for (int i = 1; i <= CANTIDAD_FACTURAS_FLOOR; i++)
           {
               
               bo_Afip.Marca_Afip_Recibo_Factura_I(ID_REGISTRO_RECIBO,Fecha, "","", PTO_VENTA,0,IMPORTE_FACTURADO,TipoDocumento,Documento,2,Tipo_COMPROBANTE);

            
           }

           // resto de facturacion

           bo_Afip.Marca_Afip_Recibo_Factura_I(ID_REGISTRO_RECIBO,Fecha, "", "", PTO_VENTA, 0, IMPORTE_RESTANTE,TipoDocumento, Documento, 2, Tipo_COMPROBANTE);

           pre_Facturas = prefact.Facturar_Registros_Recibo(ID_REGISTRO_RECIBO, PTO_VENTA);

           foreach (InfoPreFactura item in pre_Facturas)
           {
               if (item.Cae.Length > 0)

               {

                   bo_Afip.Marca_Afip_Recibo_Factura_U(item.ID, item.Cae, item.Vencimiento, item.Punto_Venta, item.Numero);  
               
               }
           }

           

          



       
       
       }

       public bool Valido_Ya_Facturado(int ID_REGISTRO_RECIBO)
       {

           string QUERY = "SELECT CAE from Recibos_caja where ID= " + ID_REGISTRO_RECIBO.ToString();

           DataRow[] foundRows;
           foundRows = bo_Afip.BO_EjecutoDataTable(QUERY).Select();

           if (foundRows.Length > 0)
           {
               if (foundRows[0][0].ToString().Trim().Length > 0)
                   return true;
               

               return false;
           }
           else
               return false;

       }

       

       public Recibo_Request Exito_Request(Afip.AfipFactResults result)
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

       

       
       
       public void Marcar_Factura(int ID_REGISTRO_RECIBO,int PTO_VENTA,int NUMERO, string CAE, string VENC_CAE,bool Recibo, int Modo_Facturacion,decimal Monto,int Tipo_Comprobante,int tipo_Documento,string Documento,int Concepto,DateTime fecha,Decimal Monto_AFIP)

       {
           if (Recibo)
           {
               
                   
                   bo_Afip.Marca_Afip_Recibo(ID_REGISTRO_RECIBO, PTO_VENTA, NUMERO, CAE, VENC_CAE, Modo_Facturacion,Monto_AFIP);
                   this.Grabo_Fecha_Pto_Vta(PTO_VENTA.ToString("0000"), fecha); 
                  
                   //  bo_Afip.Marca_Afip_Recibo_Factura_I(ID_REGISTRO_RECIBO,fecha, CAE, VENC_CAE, PTO_VENTA, NUMERO,Monto,tipo_Documento,Documento,Concepto,Tipo_Comprobante);
               
           }
           else
               bo_Afip.Marca_Afip_Bono(ID_REGISTRO_RECIBO, PTO_VENTA, NUMERO, CAE, VENC_CAE);


       
       }
       public void Marcar_NC(int ID_REGISTRO_RECIBO, int NUMERO, string CAE, string VENC_CAE,decimal MONTO_AFIP)
       {

           bo_Afip.Marca_Afip_Nota_Credito(ID_REGISTRO_RECIBO, NUMERO, CAE, VENC_CAE,MONTO_AFIP);
           

       }
      
       public bool Validar_Recibo_NC(int ID_REGISTRO_RECIBO)
       {
           string QUERY = "SELECT ANULADO,CAE_NC,CAE from Recibos_caja where ID= " + ID_REGISTRO_RECIBO.ToString();
            
            DataRow[] foundRows;
            foundRows =  bo_Afip.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                if (foundRows[0][0].ToString().Trim().Length == 0)
                    throw new Exception("El Recibo no tiene Anulacion, no se puede efectuar la NC a afip");
                if (foundRows[0][1].ToString().Trim().Length > 0)
                    throw new Exception("El Recibo ya tiene NC!");
                if (foundRows[0][2].ToString().Trim().Length == 0)
                    throw new Exception("El Recibo no esta facturado en AFIP!");

                return false;
            }
            else
                return false;

                  

       
       }

       public void Generar_Recibo_Interno_NC(int ID_REGISTRO_RECIBO)
       {


             numeroRecibo nr = new numeroRecibo();
            maxid mid = new maxid();
           SOCIOS.BO.bo_Caja bo_caja = new BO.bo_Caja();

           string Query = "select Cuenta_Debe,CUENTA_HABER,SECTACT,ID_SOCIO,VALOR,FORMA_DE_PAGO,USUARIO,ID_PROFESIONAL,NOMBRE_SOCIO_TITULAR,TIPO_SOCIO_TITULAR,OBSERVACIONES,FECHA_RECIBO,BARRA,NOMBRE_SOCIO,DNI,TIPO_SOCIO_NO_TITULAR,NRO_COMP,PTO_VTA,REINTEGRO_DE,BANCO_DEPO,pto_vta_e,Numero_NC_E,CAE_NC,USR_FACT_NC  from recibos_caja where ID=" + ID_REGISTRO_RECIBO.ToString(); 


           string connectionString;

           DataRow[] foundRows;
           foundRows =  bo_caja.BO_EjecutoDataTable(Query).Select();

           if (foundRows.Length > 0)
           {
                int  numero_recibo = nr.obtenerNroComprobante("RECIBO", "0005");
                int  recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;
                int cuenta_debe= Int32.Parse( foundRows[0][1].ToString().Trim());
                int cuenta_haber= Int32.Parse( foundRows[0][2].ToString().Trim());
                int secact= Int32.Parse( foundRows[0][3].ToString().Trim());
                int id_socio= Int32.Parse( foundRows[0][4].ToString().Trim());
                decimal valor = Decimal.Parse( foundRows[0][5].ToString().Trim());
                string forma_de_pago =foundRows[0][6].ToString().Trim();
                string User          =foundRows[0][7].ToString().Trim();
                int profesional_id = Int32.Parse(foundRows[0][8].ToString().Trim());

                string Nombre_socio_titular          =foundRows[0][9].ToString().Trim();
                string Tipo_Socio_Titular          =foundRows[0][10].ToString().Trim();
                string Observaciones          =foundRows[0][11].ToString().Trim();
                string Fecha_Recibo          =foundRows[0][12].ToString().Trim();
                int Barra = Int32.Parse(foundRows[0][13].ToString().Trim());
                string Nombre_Socio        =foundRows[0][14].ToString().Trim();
                string dni         =foundRows[0][15].ToString().Trim();
                string Tipo_Socio_No_Titular          =foundRows[0][16].ToString().Trim();
                string Punto_Venta=foundRows[0][17].ToString().Trim();
                int Reintegro_de= Int32.Parse(foundRows[0][18].ToString().Trim());
                string  BANCO_DEPO=foundRows[0][19].ToString().Trim();
                int NUMERO_NC= Int32.Parse(foundRows[0][20].ToString().Trim());
                string CAE_NC =foundRows[0][21].ToString().Trim();
                string CAE_VENC_NC = foundRows[0][22].ToString().Trim();
                string USR_NC = foundRows[0][23].ToString().Trim();


                bo_caja.nuevoReciboCaja_NC(recibo_id, cuenta_debe, cuenta_haber, secact, id_socio, valor, forma_de_pago, User, profesional_id, Nombre_socio_titular, Tipo_Socio_Titular, Observaciones, Fecha_Recibo, Barra, Nombre_Socio, dni, Tipo_Socio_No_Titular, numero_recibo, Punto_Venta, Reintegro_de,BANCO_DEPO, NUMERO_NC, CAE_NC,CAE_VENC_NC,USR_NC);



              ;
           }
         


           }
       

     
       
       public string Codigo_Barra(string TipoFactura,int Pto,string CAE,string VencimientoCAE)
       {           
        return CUIT_ENTIDAD +TipoFactura + Utils.CompletarCeros(Pto.ToString(), false, 4) + Utils.CompletarCeros(CAE, false, 13) + VencimientoCAE + "9";
       }

       //public DateTime ProximaFechaFacturar(DateTime fecha, int PuntoVta)
       //{ 
       //}
       public void Grabo_Fecha_Pto_Vta(string PtoVta,DateTime Fecha)
       {
           try
           {
               SOCIOS.db db = new SOCIOS.db();
               string QUERY = "UPDATE PUNTOS_DE_VENTA SET FECHA_WS='" + String.Format("{0:mm/dd/yyyy}",Fecha) + "' where PTO_VTA ='" + PtoVta + "'";
               
               
               db.Ejecuto_Consulta(QUERY);
               
           }
           catch
           {
               
           }
       }

    } 
}
