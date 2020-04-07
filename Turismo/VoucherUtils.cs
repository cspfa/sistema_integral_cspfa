using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.Turismo
{
   public class VoucherUtils
   {
       bo_Turismo dlog = new bo_Turismo();
       public void GenerarVoucher(int Bono,int Hotel, DateTime Desde, DateTime Hasta,int Regimen,int Habitacion,string NumeroHabitacion,string TipoBono,string Motivo, string Late,string IN,int Codint)

       {
        
           try
           {
               dlog.Voucher_HOTEL_Insert(Bono, Desde, Hasta, Hotel, this.Diferencia_Dias(Desde, Hasta), this.Cantidadpersonas(Bono), Regimen, Habitacion, NumeroHabitacion, TipoBono, Motivo,Late,IN,Codint);
           }
           catch (Exception ex)

           { 
           throw new Exception (ex.Message);
           }
       
       }

       private int Diferencia_Dias(DateTime Desde, DateTime Hasta)

       {
           int DiffDays = (int)(Hasta - Desde).TotalDays;
           if (DiffDays == 0)
               DiffDays = 1;
           return DiffDays;

       }

       private int Cantidadpersonas(int Bono)

       {
           string QUERY = "SELECT * FROM BONO_PERSONAS WHERE ROL='TURISMO' AND BONO=" + Bono.ToString();
           
           return dlog.BO_EjecutoDataTable(QUERY).Select().Length;
       
       }


       public voucherHotel getVoucherHotel(int Bono)

       {
           string Query = @"select H.ID, H.NOMBRE,L.DESCRIPCION,H.TELEFONO,H.DOMICILIO,H.CHECKIN,H.CHECKOUT,V.REGIMEN,TR.NOMBRE, V.TIPO_HABITACION,HT.TIPO,V.PASAJEROS,V.NOCHES,V.DESDE,V.HASTA,H.OBSERVACIONES,V.NRO_HABITACION NRO_HAB,V.TIPO TIPO ,V.MOTIVO MOTIVO, B.ID_ROL ,B.ROL,B.NRO_BONO_FILIAL,V.LATE_CHK,V.LATE_IN
                           from VOUCHER_BONO_HOTEL V, HOTEL H ,LOCALIDAD L ,TURISMO_REGIMEN   TR  ,HOTEL_HABITACION_TIPO HT, BONO_TURISMO B       
                           WHERE H.ID =  V.HOTEL AND H.LOCALIDADID =L.LOCALIDADID AND TR.ID = V.REGIMEN AND HT.ID = V.TIPO_HABITACION and B.ID=V.BONO     AND V.BONO = " + Bono.ToString();

           voucherHotel voucher = new voucherHotel();
           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(Query).Select();

           if (foundRows.Length > 0)
           {
               voucher.Hotel                = Int32.Parse(foundRows[0][0].ToString());
               voucher.Hotel_Nombre         = foundRows[0][1].ToString();
               voucher.Lugar                = foundRows[0][2].ToString();
               voucher.Telefono             = foundRows[0][3].ToString();
               voucher.Direccion            = foundRows[0][4].ToString();
               voucher.CheckIn              = foundRows[0][5].ToString();
               voucher.CheckOut             = foundRows[0][6].ToString();
               voucher.Regimen              = Int32.Parse(foundRows[0][7].ToString());
               voucher.Regimen_Nombre       = foundRows[0][8].ToString();
               voucher.Habitacion           = Int32.Parse(foundRows[0][9].ToString());
               voucher.Habitacion_Nombre    = foundRows[0][10].ToString();
               voucher.Pasajeros            = Int32.Parse(foundRows[0][11].ToString());
              
               

               voucher.Desde                = DateTime.Parse(foundRows[0][13].ToString()).ToShortDateString();
               voucher.Hasta                = DateTime.Parse(foundRows[0][14].ToString()).ToShortDateString();
               voucher.ObsHotel             = foundRows[0][15].ToString();
               voucher.Nro_Habitacion       = foundRows[0][16].ToString();
        
               voucher.Nro_Habitacion.Split();


               if (foundRows[0][17].ToString().Trim() == "SOC")
                   voucher.BonoSocial = true;
               else
                   voucher.BonoSocial = false;

               voucher.Motivo = foundRows[0][18].ToString();
               voucher.ID_ROL_BONO = Int32.Parse(foundRows[0][19].ToString());
               if (foundRows[0][20].ToString().Length > 0)
                   voucher.ROL = foundRows[0][20].ToString().Substring(0, 3);
               else
                   voucher.ROL = "";

               if (foundRows[0][21].ToString().Length > 0)
                   voucher.BONO_FILIAL = foundRows[0][21].ToString();
               else
                   voucher.BONO_FILIAL = "";
               //if (foundRows[0][22].ToString().Length > 0)
               //{
               //    voucher.CheckOut = foundRows[0][22].ToString();
               //}
               //if (foundRows[0][23].ToString().Length > 0)
               //{
               //    voucher.CheckIn = foundRows[0][23].ToString();
               //}


           }
          
           DateTime fecha1 = DateTime.Parse(voucher.Desde);
           DateTime fecha2 = DateTime.Parse(voucher.Hasta);
             
           int Dias       =  (fecha2 - fecha1).Days;

             if (Dias == 0)
                 Dias = 1;

             if (Dias > 1)
                 voucher.Estadia = (Dias + 1) + " Dias ," + Dias.ToString() + "Noches";
             else
                 voucher.Estadia = " 2 Dias, 1 Noche";

             voucher.OBS = foundRows[0][19].ToString();

           return voucher;

       
       }


       public int GetMaxID(int BONO)
       {
           string QUERY = "SELECT coalesce (MAX(ID),0) FROM voucher_bono_Hotel WHERE BONO=" + BONO.ToString();
           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           if (foundRows.Length > 0)
           {
               return Int32.Parse(foundRows[0][0].ToString().Trim());
           }
           else
               return 0;


       }


       public int GetMax_ID_ROL(string ROL, int CODINT)
       {
           string QUERY = "SELECT coalesce (MAX(ID_ROL),0) FROM voucher_bono_Hotel WHERE ROL='" + ROL + "' and CODINT=" + CODINT.ToString();
           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           if (foundRows.Length > 0)
           {
               return Int32.Parse(foundRows[0][0].ToString().Trim());
           }
           else
               return 0;


       }
      
    

    }
}
