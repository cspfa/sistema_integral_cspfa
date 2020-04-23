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
       Hotel_Dias_Utils hdu =  new Hotel_Dias_Utils();
       int nroSocio=0;
       int nroDep=0;
       int Tipo;
       int Dias;
       int ID_BONO;

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


       public List<Datos_Vouchers_Lista> getVouchers_Social(DateTime pDesde, DateTime pHasta)
       {


           string Desde = this.fechaUSA(pDesde.AddDays(-1));
           string Hasta = this.fechaUSA(pHasta.AddDays(1));



           List<Datos_Vouchers_Lista> DETALLE = new List<Datos_Vouchers_Lista>();

           string QUERY = @"select V.ID,BT.NRO_SOCIO,BT.NRO_DEP,BT.APELLIDO,BT.NOMBRE, BT.FE_BONO, BT.ID_ROL, BT.ROL, V.MOTIVO,V.NOCHES,BT.FE_BAJA
                                    from bono_turismo BT, voucher_Bono_hotel V 
                            where BT.ID=V.BONO  and V.F_ALTA>'" + Desde + "' and V.F_ALTA < '" + Hasta + "' and BT.TIPO='SOC'  order by BT.ID_ROL desc";

           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           if (foundRows.Length > 0)
           {
               int I = 0;
               while (I <= (foundRows.Length - 1))
               {




                   Datos_Vouchers_Lista item = new Datos_Vouchers_Lista();



                   item.ID = foundRows[I][0].ToString();
                   item.NRO_SOC = foundRows[I][1].ToString();
                   item.NRO_DEP = foundRows[I][2].ToString();
                   item.APELLIDO = foundRows[I][3].ToString();
                   item.NOMBRE = foundRows[I][4].ToString();

                   item.FECHA = DateTime.Parse(foundRows[I][5].ToString().Trim()).ToShortDateString();
                   item.BONO = Int32.Parse(foundRows[I][6].ToString());
                   item.ROL = foundRows[I][7].ToString().Trim();
                   item.MOTIVO = foundRows[I][8].ToString().Trim();
                   item.DIAS = Int32.Parse(foundRows[I][9].ToString().Trim());

                   if (foundRows[I][10].ToString().Trim().Length > 0)
                   {
                       item.ANULADO = DateTime.Parse(foundRows[I][10].ToString().Trim()).ToShortDateString();
                   }


                   I = I + 1;



                   DETALLE.Add(item);
               }
           }

           return DETALLE;

       }

       private string fechaUSA(DateTime fecha)
       {
           string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");

           return Fecha;


       }
       public void Baja_Voucher_Bono(int ID_VOUCHER)
       { 
         this.DATOS_VOUCHER(ID_VOUCHER);
         this.BAJA_VOUCHER(ID_VOUCHER);
         dlog.BajaTurismo(ID_BONO, VGlobales.vp_username, System.DateTime.Now);
         // se agregan dias a la cuenta con la cancelacion
           hdu.ProcesarDias(nroSocio, nroDep, Tipo,System.DateTime.Now.Year, Dias * (-1));

       }


       private void BAJA_VOUCHER (int ID)
       {
           int Total = 0;
           string SQL = "";

           SQL = "UPDATE  VOUCHER_BONO_HOTEL set F_BAJA=(select cast('Now' as date) from rdb$database) WHERE ID=" + ID.ToString();


          
           Datos_ini ini2 = new Datos_ini();
           FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
           cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
           cs.Database = ini2.Ubicacion;
           cs.UserID = VGlobales.vp_username;
           cs.Password = VGlobales.vp_password;
           cs.Role = VGlobales.vp_role;
           cs.Dialect = 3;
           string connectionString = cs.ToString();

           using (FbConnection connection = new FbConnection(connectionString))
           {

               connection.Open();
               FbTransaction transaction = connection.BeginTransaction();
               FbCommand cmd = new FbCommand(SQL, connection, transaction);
               cmd.CommandText = SQL;
               cmd.Connection = connection;
               cmd.CommandType = CommandType.Text;

               cmd.ExecuteNonQuery();
               transaction.Commit();
               connection.Dispose();

           }
       }

       private void DATOS_VOUCHER(int ID)
       {

           string QUERY = "SELECT  BT.ID,BT.NRO_SOCIO,BT.NRO_DEP,V.MOTIVO,V.DIAS from voucher_bono_hotel VT,Bono_turismo BT   where BT.ID= VT.BONO and VT.ID=" + ID;
           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           if (foundRows.Length > 0)
           {


               ID_BONO = Int32.Parse(foundRows[0][0].ToString().Trim());
               nroSocio= Int32.Parse(foundRows[0][1].ToString().Trim());
               nroDep = Int32.Parse(foundRows[0][2].ToString().Trim());
               if (foundRows[0][3].ToString().Trim().ToUpper().StartsWith("T"))
                   Tipo = (int) SOCIOS.Turismo.Hotel_Social_Enum.TRAMITE; 
               else if (foundRows[0][3].ToString().Trim().ToUpper().StartsWith("C"))
                    Tipo = (int)SOCIOS.Turismo.Hotel_Social_Enum.CIRUGIA;
               else
                   Tipo = (int)SOCIOS.Turismo.Hotel_Social_Enum.ENFERMEDAD;
               Dias = Int32.Parse(foundRows[0][3].ToString().Trim());
                   

           }
          



       }
    

    }
}
