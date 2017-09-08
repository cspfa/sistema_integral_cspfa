using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Linq;

namespace SOCIOS.deportes.Asistencia
{

   public class ReporteAsistencia
    {
       public string ID                   { get; set; }
       public string DNI                  { get; set; }
       public string NOMBRE               { get; set; }
       public string APELLIDO             { get; set; }
       public string  FECHA             { get; set; }

       public string   PRESENTE           { get; set; }
       public DateTime VENCIMIENTO_APTO   { get; set; }
       public int Sectact                 { get; set; }
       public string ROL                  { get; set; }
    }

   public class AsistenciaService

   {
       SOCIOS.bo dlog = new bo();

       public  List<ReporteAsistencia> ReporteAsistencia(string ID,string ROL)
       {

           string connectionString;
           List<ReporteAsistencia> lista = new List<ReporteAsistencia>();
           DataTable dt1 = new DataTable("RESULTADOS");
           string Query = "select D.ID_ROL Id, D.NOMBRE Nombre,D.APELLIDO Apellido,D.FE_VENCIMIENTO Fecha,IIF(char_length(MD.DNI)>0,'SI','NO') Moroso, D.DNI DNI , D.Sectact SEC, D.ROL ROL " +
                        "from deportes_adm D left join MOROSOS_DEPORTES MD on MD.DNI = cast(D.dni as Integer) , socio_actividades A , sectact S " +
                        "where D.ID_ROL =A.ID_DEPORTE and D.ROL=A.ROL  and S.ID =A.SECTACT    and S.ID =" + ID + "  AND D.ROL='" + ROL + "' ORDER BY Apellido";
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



                   

                   FbCommand cmd = new FbCommand(Query, connection, transaction);

                   FbDataReader reader3 = cmd.ExecuteReader();

                   while (reader3.Read())
                   {

                       ReporteAsistencia item = new ReporteAsistencia();
                       item.ID       = reader3.GetString(reader3.GetOrdinal("Id")).Trim();
                       item.NOMBRE   = reader3.GetString(reader3.GetOrdinal("Nombre")).Trim();
                       item.APELLIDO =  reader3.GetString(reader3.GetOrdinal("Apellido")).Trim();
                       item.FECHA    = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("Fecha")).Trim()).ToShortDateString();
                      // item.MORA     = reader3.GetString(reader3.GetOrdinal("Moroso")).Trim();
                       item.DNI      =  reader3.GetString(reader3.GetOrdinal("DNI")).Trim();
                       item.Sectact = Int32.Parse(reader3.GetOrdinal("SEC").ToString());
                       item.ROL = reader3.GetString(reader3.GetOrdinal("ROL")).TrimEnd().TrimStart();

                       lista.Add(item);

                   }

                   reader3.Close();



                   transaction.Commit();

               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

           return lista;


       }



       public List<ReporteAsistencia> ReporteAsistencia_Remoto(DateTime Desde,DateTime Hasta,string ROL)
       {

           string connectionString;
           List<ReporteAsistencia> lista = new List<ReporteAsistencia>();
           DataTable dt1 = new DataTable("RESULTADOS");
               string Query = @"select A.ID ID, A.NOMBRE NOMBRE, A.APELLIDO APELLIDO,A.FECHA FECHA,A.DNI , A.P PRESENTE, A.ROL ROL, A.SECTACT SECT from SOCIO_ACTIVIDADES_ASISTENCIA A
                                      WHERE A.FECHA between '" + fechaUSA( Desde) + "' AND '" +  fechaUSA( Hasta) + "' AND A.ROL='"  +ROL +"'  order by DNI"  ;

          DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable_Remota(Query,ROL).Select();
            try
            {
                // foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY,RolRemoto).Select();
                if (foundRows.Length > 0)
                {
                    int I = 0;
                    for (int i = 0; i < foundRows.Length; i++)
                    {

                        
                        ReporteAsistencia item = new ReporteAsistencia();
                        item.ID = foundRows[i][0].ToString();
                        item.NOMBRE = foundRows[i][1].ToString();
                        item.APELLIDO = foundRows[i][2].ToString();
                        item.FECHA = DateTime.Parse(foundRows[i][3].ToString()).ToShortDateString();
                        // item.MORA     = reader3.GetString(reader3.GetOrdinal("Moroso")).Trim();
                        item.DNI = foundRows[i][4].ToString();
                        item.PRESENTE = foundRows[i][5].ToString();

                        item.ROL = foundRows[i][6].ToString().TrimEnd().TrimStart();
                        item.Sectact = Int32.Parse(foundRows[i][7].ToString());

                        lista.Add(item);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

           return lista;


       }





       
       private string fechaUSA(DateTime fecha)
       {
           string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");

           return Fecha;


       }


       public List<ReporteAsistencia> Reporte_Verificacion_Asistencia(string SECT_ACT, string ROL,DateTime pDesde,DateTime pHasta)
       {

           string connectionString;

           List<ReporteAsistencia> lista = new List<ReporteAsistencia>();
           string Desde = this.fechaUSA(pDesde);
           string Hasta = this.fechaUSA(pHasta);
           SOCIOS.deportes.DeportesService ds = new DeportesService();

           DataTable dt1 = new DataTable("RESULTADOS");
           string Query = @"select A.ID ID, A.NOMBRE NOMBRE, A.APELLIDO APELLIDO,A.FECHA FECHA,A.DNI , A.P PRESENTE, A.ROL ROL, A.SECTACT SECT from SOCIO_ACTIVIDADES_ASISTENCIA A
                                      WHERE A.FECHA between '" + Desde + "' AND '" + Hasta + "' AND A.ROL='"  +ROL +"' and A.SECTACT= " + SECT_ACT.ToString() +  " order by DNI"  ;
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





                   FbCommand cmd = new FbCommand(Query, connection, transaction);

                   FbDataReader reader3 = cmd.ExecuteReader();

                   while (reader3.Read())
                   {

                       ReporteAsistencia  item = new ReporteAsistencia();
                       item.ID = reader3.GetString(reader3.GetOrdinal("ID")).Trim();
                       item.NOMBRE = reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim();
                       item.APELLIDO = reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim();
                       item.FECHA = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA")).Trim()).ToShortDateString();
                    
                       item.DNI =  reader3.GetString(reader3.GetOrdinal("DNI")).Trim();
                       try
                       {
                           item.VENCIMIENTO_APTO = ds.Fecha_Vencimiento_Apto(item.DNI, ROL).Value;
                       }
                       catch (Exception ex)
                       { 
                       }

                       if (reader3.GetString(reader3.GetOrdinal("PRESENTE")).Trim() != "0")
                           item.PRESENTE = "X";
                       item.ROL = reader3.GetString(reader3.GetOrdinal("ROL")).TrimEnd().TrimStart();
                       item.Sectact = Int32.Parse(reader3.GetString(reader3.GetOrdinal("SECT")));

                       
                       lista.Add(item);

                   }

                   reader3.Close();



                   transaction.Commit();

               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

           return lista;


       }

     

       //public List<ReporteAsistencia> Verificar_Asistencia(string ID, string ROL, List<DateTime> Fechas)

       //{
       //    List<ReporteAsistencia> lista = new List<ReporteAsistencia>();
               


       //       foreach( ReporteAsistencia repo in  this.ReporteAsistencia(ID, ROL))

       //       {
       //            foreach(DateTime F in Fechas)
       //            {
       //                repo.ASISTENCIA = F;
       //                lista.Add(repo);
                     
       //            }
              
       //       }

           




       //    foreach (ReporteAsistencia r in lista.OrderBy(x=>x.APELLIDO ).ThenBy(d=>d.FECHA).ToList())

       //    { 
       //       if (this.ExisteAsistencia(ID,r.ASISTENCIA,r.DNI))

       //       {
       //          r.PRESENTE ="X";
       //       }
           
       //    }


       //    return lista;
       
       //}



       public bool ExisteAsistencia(string ID, DateTime Fecha, string DNI)
       {
           List<SOCIOS.Titular> lista = new List<Titular>();

           string QUERY = @" select ID from SOCIO_ACTIVIDADES_ASISTENCIA 
                             where  extract(DAY from fecha)=" + Fecha.Day.ToString() + "and extract(month from Fecha)=" + Fecha.Month.ToString() + " and extract(Year from fecha)= " + Fecha.Year.ToString() + " " +
                             "and SECTACT= " + ID + " and DNI= " + DNI.ToString() + " AND P=1"; 

           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


           if (foundRows.Length > 0)
           {
               return true;
           }
           else
               return false;
       }


   
   }
}
