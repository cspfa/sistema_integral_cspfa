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
using System.Data.SqlClient;

namespace SOCIOS.AbmTabla
{
  public  interface TableInterface
  {
      
      void Borrar(int ID);
       void Insertar(string Descripcion);
       DataTable    getData();

    }

  public class Regimen : TableInterface
  {
      bo dlog = new bo();
     public void Insertar(string Descripcion)
      {
          try
          {
              dlog.Regimen_Ins(Descripcion);
          }
          catch (Exception ex)

          {
              throw new Exception(ex.Message);
          
          }
       
   
     }

     public void Borrar(int ID)

     {
         try
         {
             dlog.Regimen_Baja(ID);
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message);

         }
     
     }

     public DataTable getData()
     {
         string connectionString;
         DataTable dt1 = new DataTable("RESULTADOS");

         string Query = "select  ID,NOMBRE from Turismo_Regimen where coalesce(F_BAJA,'1')='1'";

         DataSet ds1 = new DataSet();

         Datos_ini ini3 = new Datos_ini();

         try
         {
             FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
             cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
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


                 dt1.Columns.Add("ID", typeof(string));
                 dt1.Columns.Add("NOMBRE", typeof(string));
               


                 ds1.Tables.Add(dt1);

                 FbCommand cmd = new FbCommand(Query, connection, transaction);

                 FbDataReader reader3 = cmd.ExecuteReader();

                 while (reader3.Read())
                 {
                     dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                  reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim());
                                  

                 }

                 reader3.Close();



                 transaction.Commit();

             }
         }
         catch (Exception ex)
         {
             throw new Exception( ex.ToString());
         }

         return dt1;
     
     
     }
  }

  public class Traslado : TableInterface
  {
      bo log = new bo();
      public void Insertar(string Descripcion)
      {
          try
          {
              log.Traslado_Ins(Descripcion);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.Message);

          }


      }

      public void Borrar(int ID)
      {
          try
          {
              log.Traslado_Baja(ID);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.Message);

          }

      }
      public DataTable getData()
      {
          string connectionString;
          DataTable dt1 = new DataTable("RESULTADOS");

          string Query = "select  ID,NOMBRE from Turismo_Traslado where coalesce(F_BAJA,'1')='1'";

          DataSet ds1 = new DataSet();

          Datos_ini ini3 = new Datos_ini();

          try
          {
              FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
              cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
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


                  dt1.Columns.Add("ID", typeof(string));
                  dt1.Columns.Add("NOMBRE", typeof(string));



                  ds1.Tables.Add(dt1);

                  FbCommand cmd = new FbCommand(Query, connection, transaction);

                  FbDataReader reader3 = cmd.ExecuteReader();

                  while (reader3.Read())
                  {
                      dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                   reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim());


                  }

                  reader3.Close();



                  transaction.Commit();

              }
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }

          return dt1;


      }

  }
  public class TipoSalida : TableInterface
  {
      bo log = new bo();
      public void Insertar(string Descripcion)
      {
          try
          {
              log.Tipo_Salida_Ins(Descripcion);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.Message);

          }


      }

      public void Borrar(int ID)
      {
          try
          {
              log.Tipo_Salida_Baja(ID);
          }
          catch (Exception ex)
          {
              throw new Exception(ex.Message);

          }

      }
      public DataTable getData()
      {
          string connectionString;
          DataTable dt1 = new DataTable("RESULTADOS");

          string Query = "select  ID,NOMBRE from TURISMO_TIPO where coalesce(F_BAJA,'1')='1'";

          DataSet ds1 = new DataSet();

          Datos_ini ini3 = new Datos_ini();

          try
          {
              FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
              cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
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


                  dt1.Columns.Add("ID", typeof(string));
                  dt1.Columns.Add("NOMBRE", typeof(string));



                  ds1.Tables.Add(dt1);

                  FbCommand cmd = new FbCommand(Query, connection, transaction);

                  FbDataReader reader3 = cmd.ExecuteReader();

                  while (reader3.Read())
                  {
                      dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                   reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim());


                  }

                  reader3.Close();



                  transaction.Commit();

              }
          }
          catch (Exception ex)
          {
              throw new Exception(ex.ToString());
          }

          return dt1;


      }

  }



}
