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

     private bool Registro_Cargado(int Socio, int Dep)

     {

         string QUERY = "SELECT  TRAMITE,ENFERMEDAD,CIRUGIA ,ID FROM HOTEL_DIAS_ALOJAMIENTO WHERE NRO_SOCIO=" + Socio.ToString() + " AND NRO_DEP= " + Dep.ToString() + " AND extract(year from F_ALTA)=" + System.DateTime.Now.Year.ToString();
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

     public void ProcesarDias(int Socio, int Dep, int Tipo, int Dias)

     {    //si no esta cargado el registro, cargar

   
                if (!Registro_Cargado(Socio,Dep))
                    
                {

                    dlog.HOTEL_DIAS_INSERT(Socio, Dep, Tramite, Enfermedad, Cirugia, System.DateTime.Now.Year);
                    Registro_Cargado(Socio, Dep);

                }

                 //Actualizar el Registro

                this.Actualizar(ID, Dias, Tipo);

     
     }
     public string ConsultarDias(int Socio, int Dep)
     {
         if (!Registro_Cargado(Socio, Dep))
         {

             dlog.HOTEL_DIAS_INSERT(Socio, Dep, Tramite, Enfermedad, Cirugia, System.DateTime.Now.Year);
             Registro_Cargado(Socio, Dep);

         }

         return "Dias de Tramte :" + Tramite_Disponibles.ToString() + " - Dias de Enfermedad : " + Enfermedad_Disponibles.ToString() + " - Dias de Cirugia :" + Cirugia_Disponibles;

     
     
     }
     public string ConsultarDiasAbreviado(int Socio, int Dep)
     {
         if (!Registro_Cargado(Socio, Dep))
         {

             dlog.HOTEL_DIAS_INSERT(Socio, Dep, Tramite, Enfermedad, Cirugia, System.DateTime.Now.Year);
             Registro_Cargado(Socio, Dep);

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
