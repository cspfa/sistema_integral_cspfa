using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using SOCIOS.Turismo;

namespace SOCIOS.Turismo.Solicitudes
{
   public  class SolicitudUtils
   {
       bo dlog = new bo();
       public int GetMaxID(string NRO_SOCIO, string DEP,DateTime Desde, DateTime Hasta,string Tipo)
       {
           string QUERY = "SELECT coalesce (MAX(ID),0) FROM  SOLICITUD_INTERIOR WHERE  ";

           if (Tipo == "ADH")
           {
               QUERY = QUERY + " NRO_ADH=" + NRO_SOCIO + " AND NRO_DEP_ADH =" + DEP + " AND ";
           }
           else
           {
               QUERY = QUERY + " NRO_SOCIO=" + NRO_SOCIO + " AND NRO_DEP =" + DEP + " AND ";
           }

           QUERY = QUERY + @"Extract (Day from DESDE)=" + Desde.Day.ToString() +
                            " and Extract (Month from  DESDE) ="  + Desde.Month.ToString() + 
                            " and Extract (year from DESDE ) = " + Desde.Year.ToString() +
                             " and Extract (Day from HASTA)="  + Hasta.Day.ToString() +
                             " and Extract (Month from  HASTA) =  " + Hasta.Month.ToString() + 
                             " and Extract (year from HASTA ) =" + Hasta.Year.ToString();

        



           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
           if (foundRows.Length > 0)
           {
               return Int32.Parse(foundRows[0][0].ToString().Trim());
           }
           else
               return 0;


       }

       public List<SOCIOS.Turismo.Solicitud> getSolicitudes(int ID)

       {
           List<SOCIOS.Turismo.Solicitud> lista = new List<SOCIOS.Turismo.Solicitud>();






           string Query = @"select  S.ID ID, S.NRO_SOCIO NRO_SOCIO,
                                   S.NRO_DEP NRO_DEP  ,
                                   S.BARRA BARRA  , 
                                   S.DNI DNI      ,
                                   S.NOMBRE NOMBRE,
                                   S.APELLIDO APELLIDO,
                                   S.TIPO TIPO       ,
                                   S.NRO_ADH NRO_ADH,
                                   S.NRO_DEP_ADH DEP_ADH ,   
                                   S.DESDE  DESDE,
                                   S.HASTA HASTA,
                                   S.PLAZAS PLAZAS,
                                  
                                   H.TIPO  HABITACION , 
                                   S.PROCESADA PROCESADA,
                                   H.ID   HABITACION_ID,
                                   S.F_B    from SOLICITUD_INTERIOR  S ,HOTEL_HABITACION_TIPO H where H.ID =S.TIPO_HABITACION
                                    and  coalesce (S.F_B,'')=''";

           if (ID != 0)
           {

               Query = Query + " and S.ID=" + ID.ToString(); 
           
           }
           string connectionString;

           DataSet ds1 = new DataSet();

           Datos_ini ini3 = new Datos_ini();

           try
           {
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

                   dt1.Columns.Add("ID", typeof(string));
                   dt1.Columns.Add("NRO_SOCIO", typeof(string));
                   dt1.Columns.Add("NRO_DEP", typeof(string));
                   dt1.Columns.Add("BARRA", typeof(string));
                   dt1.Columns.Add("DNI", typeof(string));
                   dt1.Columns.Add("NOMBRE", typeof(string));
                   dt1.Columns.Add("APELLIDO", typeof(string));
                   dt1.Columns.Add("TIPO", typeof(string));
                   dt1.Columns.Add("NRO_ADH", typeof(string));
                   dt1.Columns.Add("DEP_ADH", typeof(string));
                   dt1.Columns.Add("DESDE", typeof(string));
                   dt1.Columns.Add("HASTA", typeof(string));
                   dt1.Columns.Add("PLAZAS", typeof(string));
                   dt1.Columns.Add("HABITACION", typeof(string));
                   dt1.Columns.Add("PROCESADA", typeof(string));
                   dt1.Columns.Add("HABITACION_ID", typeof(string));
                   ds1.Tables.Add(dt1);

                   FbCommand cmd = new FbCommand(Query, connection, transaction);

                   FbDataReader reader3 = cmd.ExecuteReader();

                   while (reader3.Read())
                   {
                       SOCIOS.Turismo.Solicitud item = new Turismo.Solicitud();
                       item.ID                           =Int32.Parse(reader3.GetString(reader3.GetOrdinal("ID")).Trim());
                       item.Nro_Socio                    = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_SOCIO")).Trim());
                       item.Nro_Dep                      = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim());
                       item.Barra                        = Int32.Parse(reader3.GetString(reader3.GetOrdinal("BARRA")).Trim());
                       item.DNI                          = reader3.GetString(reader3.GetOrdinal("DNI")).Trim();
                       item.Nombre                       = reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim();
                       item.Apellido                     = reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim();
                       item.Tipo                         = reader3.GetString(reader3.GetOrdinal("TIPO")).Trim();
                       item.Nro_Adh                      = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_ADH")).Trim());
                       item.Nro_Dep_Adh                  = Int32.Parse(reader3.GetString(reader3.GetOrdinal("DEP_ADH")).Trim());
                       item.Desde                        = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("DESDE")).Trim());
                       item.Hasta                        = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("HASTA")).Trim());
                    
                       item.Habitacion                   = reader3.GetString(reader3.GetOrdinal("HABITACION")).Trim();
                       item.Procesada                    = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PROCESADA")).Trim());
                       item.Plazas                       = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PLAZAS")).Trim());
                       item.Habitacion_ID                = Int32.Parse(reader3.GetString(reader3.GetOrdinal("HABITACION_ID")).Trim());
                       lista.Add(item);
                   }

                   reader3.Close();

                  

                   transaction.Commit();
               }


               if  (lista.Count >0)
                    return lista;
               else
                   return null;



           }
           catch (Exception ex)
           {
               
           }
           return lista;
       
       
       }


       public DataTable DatosPersonas(string ID)
       {

           string connectionString;
           DataTable dt1 = new DataTable("RESULTADOS");
           string Query = @" select Nombre,Apellido,'ARG' Nacionalidad, 'Dni' TipoDni, Dni from bono_Personas
            where  ROL ='INTERIOR' and BONO=" + ID;
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



                   dt1.Columns.Add("Nombre", typeof(string));
                   dt1.Columns.Add("Apellido", typeof(string));
                   dt1.Columns.Add("Nacionalidad", typeof(string));
                   dt1.Columns.Add("TipoDni", typeof(string));
                   dt1.Columns.Add("Dni", typeof(string));


                   ds1.Tables.Add(dt1);

                   FbCommand cmd = new FbCommand(Query, connection, transaction);

                   FbDataReader reader3 = cmd.ExecuteReader();

                   while (reader3.Read())
                   {
                       dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("Nombre")).Trim(),
                                    reader3.GetString(reader3.GetOrdinal("Apellido")).Trim(),
                                    reader3.GetString(reader3.GetOrdinal("Nacionalidad")).Trim(),
                                    reader3.GetString(reader3.GetOrdinal("TipoDni")).Trim(),
                                    reader3.GetString(reader3.GetOrdinal("Dni")).Trim());


                   }

                   reader3.Close();



                   transaction.Commit();

               }
           
          

           return dt1;


       }

       public int GetRegistroMaxID(int NRO_SOCIO,int NRO_DEP, int BARRA)
       {
           string QUERY = "SELECT coalesce (MAX(ID),0) FROM REgistro_Alojamiento WHERE NRO_SOC = " + NRO_SOCIO.ToString() + " AND NRO_DEP =" + NRO_DEP.ToString() + " AND BARRA = " + BARRA.ToString();
           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           if (foundRows.Length > 0)
           {
               return Int32.Parse(foundRows[0][0].ToString().Trim());
           }
           else
               return 0;


       }



       public List<Personas_Registro_Solicitud> Personas_Registro(int Registro)

       {
           List<Personas_Registro_Solicitud> lista = new List<Personas_Registro_Solicitud>();
           string SQL = "Select DNI, NOMBRE, APELLIDO from REGISTRO_ALOJAMIENTO_PERSONA where REGISTRO_ALOJAMIENTO_ID= " + Registro.ToString();
           DataRow[] foundRows;
            
            foundRows = dlog.BO_EjecutoDataTable(SQL).Select();

            if (foundRows.Length > 0)
            {

                foreach (DataRow dr in foundRows)
                {
                     lista.Add( new Personas_Registro_Solicitud(dr[0].ToString(), dr[1].ToString(), dr[2].ToString()));

                }
            }

            return lista;

       
       }



    }
}
