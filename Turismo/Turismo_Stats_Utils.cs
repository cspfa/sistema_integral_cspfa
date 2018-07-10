using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data;


namespace SOCIOS.Turismo
{
    public class Hotel_Stats_Ocupacion
    {
        public string Hotel                 { get; set; }
        public string Habitacion            { get; set; }
        public string Capacidad             { get; set; }
        public string Vendido               { get; set; }
        public int    Tipo_Habitacion       { get; set; }
        public int    Hotel_ID              { get; set; }
    
    }

   public class Turismo_Stats_Utils
    {

      public List<Hotel_Stats_Ocupacion> getStats(DateTime Desde , DateTime Hasta )
       {

           bo dlog = new bo();
           List<Hotel_Stats_Ocupacion> lista = new List<Hotel_Stats_Ocupacion>();
           string SQL = @" select  H.ID,H.NOMBRE,HT.ID,HT.TIPO , HE.CANTIDAD  from HOTEL_STATS HE, HOTEL_HABITACION_TIPO HT,HOTEL H
                         where   HT.ID = HE.HABITACION_ID and H.ID= HE.HOTEL_ID ";


           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(SQL).Select();
           int I = 0;
           int Dias = 0;

           Dias = (Hasta - Desde).Days;
           if (Dias == 0)
               Dias = 1;

           if (foundRows.Length > 0)
           {
               while (I < foundRows.Length - 1)
               {
                   Hotel_Stats_Ocupacion hso = new Hotel_Stats_Ocupacion();
                   hso.Hotel                 = foundRows[I][1].ToString().Trim();
                   hso.Habitacion            = foundRows[I][3].ToString().Trim();
                   hso.Hotel_ID              = Int32.Parse(foundRows[I][0].ToString().Trim());
                   hso.Capacidad             =  (Int32.Parse(foundRows[I][4].ToString().Trim()) * Dias).ToString();
                   hso.Tipo_Habitacion = Int32.Parse(foundRows[I][2].ToString().Trim());

                   hso.Vendido = this.getCantidad(Desde, Hasta, hso.Tipo_Habitacion, hso.Hotel_ID).ToString();

                   lista.Add(hso);

                   I = I + 1;
               }
           }

           return lista;
           

           

       
        
       
       }
   
       private string fechaUSA(DateTime fecha)
      {
          string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");

          return Fecha;


      }

      public  int getCantidad(DateTime Desde, DateTime Hasta,int Tipo,int Hotel)
      {

          bo dlog = new bo();
          List<Hotel_Stats_Ocupacion> lista = new List<Hotel_Stats_Ocupacion>();
          string SQL = @"select sum(B.cantidad_Habitacion) from Bono_turismo B,Voucher_Bono_Hotel VBH, HOTEL H
                                where B.ID= VBH.BONO   and VBH.HOTEL = H.ID 
                                    and H.PROPIO=1 and B.TIPO_HABITACION=" + Tipo.ToString() +" and VBH.HOTEL=" + Hotel.ToString()
                        + " and B.FE_BONO Between '" + fechaUSA(Desde) +"' and '" + fechaUSA(Hasta)+"'";


          DataRow[] foundRows;

          foundRows = dlog.BO_EjecutoDataTable(SQL).Select();
   

          if (foundRows.Length > 0)
          {
              try
              {
                  return Int32.Parse(foundRows[0][0].ToString().Trim());
              }
              catch
              {
                  return 0;
              
              }
            
          }

          return 0;







      }


    }
}
