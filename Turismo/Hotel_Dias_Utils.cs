using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.Turismo
{

    public enum Hotel_Social_Enum
    {
        TRAMITE    = 1,
        ENFERMEDAD = 2,
        CIRUGIA    = 3 
       
    }



    public class Datos_Vouchers
    {
        public string  FECHA { get; set; }
        public int     BONO  { get; set; }
        public string  ROL   { get; set; }
        public string  MOTIVO { get; set; }
        public int     DIAS { get; set; }

    
    }

    public class Datos_Dias
    {
        public int TRAMITE                  { get; set; }
        public int ENFERMEDAD               { get; set; }
        public int CIRUGIA                  { get; set; }
        public List<Datos_Vouchers> DETALLE { get; set; }
        bo_Turismo dlog = new bo_Turismo();
     
        public Datos_Dias(int NroSocio, int NroDep)
        {
            DETALLE = new List<Datos_Vouchers>();
            this.Cargar_Lista(NroSocio, NroDep);

            TRAMITE    = DETALLE.Where(x => x.MOTIVO.ToLower().StartsWith("t")).Count();
            ENFERMEDAD = DETALLE.Where(x => x.MOTIVO.ToLower().StartsWith("e")).Count();
            CIRUGIA    = DETALLE.Where(x => x.MOTIVO.ToLower().StartsWith("c")).Count();


        }

        private void  Cargar_Lista(int NroSocio, int NroDep)
        {

            string QUERY = @"select BT.FE_BONO, BT.ID_ROL, BT.ROL, V.MOTIVO,V.NOCHES
                                    from bono_turismo BT, voucher_Bono_hotel V 
                            where BT.ID=V.BONO  and BT.NRO_SOCIO="+ NroSocio.ToString() +" and BT.NRO_DEP=" + NroDep.ToString() +"  order by BT.ID_ROL desc";                      

            



            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                int I = 0;
                while (I <= (foundRows.Length - 1))
                {
                  



                    Datos_Vouchers item = new Datos_Vouchers();

                    item.FECHA = foundRows[I][0].ToString().Trim();
                    item.BONO = Int32.Parse(foundRows[I][1].ToString());
                    item.ROL = foundRows[I][2].ToString().Trim();
                    item.MOTIVO = foundRows[I][3].ToString().Trim();
                    item.DIAS = Int32.Parse(foundRows[I][4].ToString().Trim());

                    I = I + 1;



                    DETALLE.Add(item);
                }
            }

        
        }



    }

   public class Hotel_Dias_Utils
    {
       int Tramite    =0;
       int Enfermedad =0;
       int Cirugia    =0;

       int Tramite_Disponibles    = 0;
       int Enfermedad_Disponibles = 0;
       int Cirugia_Disponibles    = 0;

       int ID=0;
       bo_Turismo dlog = new bo_Turismo();
     public  Hotel_Dias_Utils()

       {

           string QUERY = "SELECT TRAMITE,ENFERMEDAD,CIRUGIA FROM HOTEL_DIAS_ALOJAMIENTO WHERE NRO_SOCIO=0 AND NRO_DEP=0 ";
           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           if (foundRows.Length > 0)
           {
               Tramite    = Int32.Parse(foundRows[0][0].ToString().Trim());
               Enfermedad = Int32.Parse(foundRows[0][1].ToString().Trim());
               Cirugia    = Int32.Parse(foundRows[0][2].ToString().Trim());

           }
        
       }

     private bool Registro_Cargado(int Socio, int Dep,int Anio)

     {

         string QUERY = "SELECT  TRAMITE,ENFERMEDAD,CIRUGIA ,ID FROM HOTEL_DIAS_ALOJAMIENTO WHERE NRO_SOCIO=" + Socio.ToString() + " AND NRO_DEP= " + Dep.ToString() + " AND  ANIO=" + Anio.ToString() ;
         DataRow[] foundRows;
         foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

         if (foundRows.Length > 0)
         {
             Tramite_Disponibles    = Int32.Parse(foundRows[0][0].ToString().Trim());
             Enfermedad_Disponibles = Int32.Parse(foundRows[0][1].ToString().Trim());
             Cirugia_Disponibles    = Int32.Parse(foundRows[0][2].ToString().Trim());
             ID                     = Int32.Parse(foundRows[0][3].ToString().Trim());
             return true;
         }
         else
             return false;
        
     
     
     }

     public void ProcesarDias(int Socio, int Dep, int Tipo,int Anio, int Dias)

     {    //si no esta cargado el registro, cargar

   
                if (!Registro_Cargado(Socio,Dep,Anio))
                    
                {

                    dlog.HOTEL_DIAS_INSERT(Socio, Dep, Tramite, Enfermedad, Cirugia, Anio);
                    Registro_Cargado(Socio, Dep,Anio);

                }

                 //Actualizar el Registro

                this.Actualizar(ID, Dias, Tipo);

     
     }
     public string ConsultarDias(int Socio, int Dep,int Anio)
     {
         if (!Registro_Cargado(Socio, Dep,Anio))
         {

             dlog.HOTEL_DIAS_INSERT(Socio, Dep, Tramite, Enfermedad, Cirugia, Anio);
             Registro_Cargado(Socio, Dep,Anio);

         }

         return "Dias de Tramte :" + Tramite_Disponibles.ToString() + " - Dias de Enfermedad : " + Enfermedad_Disponibles.ToString() + " - Dias de Cirugia :" + Cirugia_Disponibles;

     
     
     }
     public string ConsultarDiasAbreviado(int Socio, int Dep,int Anio)
     {
         if (!Registro_Cargado(Socio, Dep,Anio))
         {

             dlog.HOTEL_DIAS_INSERT(Socio, Dep, Tramite, Enfermedad, Cirugia, Anio);
             Registro_Cargado(Socio, Dep,Anio);

         }

         return "TRT:" + Tramite_Disponibles.ToString() + "ENF:" + Enfermedad_Disponibles.ToString() + " CIRG:" + Cirugia_Disponibles.ToString();



     }


     private void Actualizar(int ID, int Dias, int Tipo)
     {
         int Total = 0;
         string SQL = "";


         if (Tipo == (int)Hotel_Social_Enum.TRAMITE)
         {

             Total = Tramite_Disponibles - Dias;
             if (Total < 0)
                 throw new Exception("No alcanzan los dias requeridos para alojamiento, poose solamente :" + Tramite_Disponibles);

             else
             {
                 SQL = "UPDATE HOTEL_DIAS_ALOJAMIENTO SET TRAMITE =" + Total.ToString() + " WHERE ID = " + ID;


             }
         }
         else if (Tipo == (int)Hotel_Social_Enum.ENFERMEDAD)
         {
             Total = Enfermedad_Disponibles - Dias;
             if (Total < 0)
                 throw new Exception("No alcanzan los dias requeridos para alojamiento, poose solamente :" + Enfermedad_Disponibles);

             else
             {
                 SQL = "UPDATE HOTEL_DIAS_ALOJAMIENTO SET ENFERMEDAD =" + Total.ToString() + " WHERE ID = " + ID;


             }


         }
         else

         {
             Total = Cirugia_Disponibles - Dias;
             if (Total < 0)
                 throw new Exception("No alcanzan los dias requeridos para alojamiento, poose solamente :" + Cirugia_Disponibles);

             else
             {
                 SQL = "UPDATE HOTEL_DIAS_ALOJAMIENTO SET CIRUGIA =" + Total.ToString() + " WHERE ID = " + ID;


             }



         
         
         }
         Datos_ini ini2 = new Datos_ini();
         FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
         cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
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
      


       
    }
}
