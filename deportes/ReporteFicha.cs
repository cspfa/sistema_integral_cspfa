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
namespace SOCIOS.deportes
{
    public partial class ReporteFicha : Form
    {
        int ID_ROL;
        string ROL;
  
        string NOMBRE;
        string DNI;
        string NRO_SOCIO;
        string TELEFONO;
        string CELULAR;
        string CP;


        string NOMBRE_TIT;
        string DNI_TIT;
        string AF_TIT;
        string TEL_TIT;

 
        string DIRECCION;
        string EMAIL;
        string OBS;
        string NRO_SOCIO_TIT;
        string VINCULO_TIT;
        List<SOCIOS.deportes.Registro_Responsables> respon= new List<Registro_Responsables>();



        public ReporteFicha(string pNOMBRE,string pDNI,string pNRO_SOCIO,string pTELEFONO,string pCelular,string pEmail,string pCP,string pDireccion,string pOBS, List<SOCIOS.deportes.Registro_Responsables> prespon,int pID_ROL,string pROL,string pDNI_TIT,string pNOMBRE_TIT,string pTEL_TIT,string pAF_TIT,string pNRO_SOCIO_TIT,string pVinculo_TIT)
        {
            InitializeComponent();
       
            NOMBRE   = pNOMBRE;
            DNI      = pDNI;
            NRO_SOCIO = pNRO_SOCIO;
            TELEFONO = pTELEFONO;
            CELULAR = pCelular;
            CP = pCP;
            DIRECCION = pDireccion;
            EMAIL = pEmail;
            respon = prespon;
            ID_ROL = pID_ROL;
            ROL = pROL;
            
            DNI_TIT = pDNI_TIT;
            AF_TIT = pAF_TIT;
            TEL_TIT = pTEL_TIT;
            NRO_SOCIO_TIT = pNRO_SOCIO_TIT;
            VINCULO_TIT = pVinculo_TIT;



        }


        private DataTable Datos_Responsable(List<SOCIOS.deportes.Registro_Responsables> respon)
        {

           
            DataTable dt1 = new DataTable("RESULTADOS");
            DataSet ds1 = new DataSet();
            try
            {
               



                    dt1.Columns.Add("DNI", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("VINCULO", typeof(string));
                    dt1.Columns.Add("TELEFONO", typeof(string));
                    dt1.Columns.Add("EMAIL", typeof(string));


                    ds1.Tables.Add(dt1);

                
                      foreach (SOCIOS.deportes.Registro_Responsables item in respon)
                        {
                            dt1.Rows.Add(item.DNI,item.NOMBRE,item.APELLIDO,item.VINCULO,item.TELEFONO,item.EMAIL);
                      
                      
                      }


                      
                       

                    

                 

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt1;


        }

        private void ReporteFicha_Load(object sender, EventArgs e)
        {
           this.reportViewer.RefreshReport();
          
           try
           {
               this.LoadDataReporte();
           }
           catch (Exception ex)
           {
               
           }


        }

        private void LoadDataReporte()

         {
       

             bo dlog = new bo();
             
             ReportParameter[] parameters = new ReportParameter[16];
             //Establecemos el valor de los parámetros
           
             parameters[0] = new ReportParameter("NOMBRE", NOMBRE);
      
             parameters[1] = new ReportParameter("FECHA", System.DateTime.Now.ToShortDateString());
             parameters[2] = new ReportParameter("DNI", DNI);
             parameters[3] = new ReportParameter("SOCIO",NRO_SOCIO);
             parameters[4] = new ReportParameter("CP", CP);
             parameters[5] = new ReportParameter("TELEFONO",TELEFONO );
             parameters[6] = new ReportParameter("CELULAR",CELULAR);
             parameters[7] = new ReportParameter("EMAIL",EMAIL);
             parameters[8] = new ReportParameter("DIRECCION",DIRECCION);
             parameters[9] = new ReportParameter("OBS",OBS);

           

             parameters[10] = new ReportParameter("NOMBRE_R", NOMBRE_TIT);
             parameters[11] = new ReportParameter("VINCULO_R",VINCULO_TIT);
             parameters[12] = new ReportParameter("TELEFONO_R",TEL_TIT);
             parameters[13] = new ReportParameter("DNI_R", DNI_TIT);
             parameters[14] = new ReportParameter("AF_BENEF_R", AF_TIT);
             parameters[15] = new ReportParameter("SOCIO_R",NRO_SOCIO_TIT);
             
             this.reportViewer.LocalReport.SetParameters(parameters);
             
             reportViewer.LocalReport.DataSources.Clear();
             reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetResponsables", this.Datos_Responsable(respon)));
             reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetActividades", this.Datos_Actividad(ID_ROL,ROL)));

             this.reportViewer.RefreshReport();
             reportViewer.Visible = true;
        
        
        
        }

        private DataTable Datos_Actividad(int ID_ROL,string ROL)
        {

            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
            string Query = "SELECT SOCIO_ACTIVIDADES.ID ID, SECTACT.DETALLE ACTIVIDAD , PROFESIONALES.NOMBRE PROFESIONAL ,SOCIO_ACTIVIDADES.ARANCEL ARANCEL, SOCIO_ACTIVIDADES.F_ALTA FECHA,SOCIO_ACTIVIDADES.ESTADO ESTADO, COALESCE(SOCIO_ACTIVIDADES.F_BAJA,'') BAJA,SOCIO_ACTIVIDADES.PROFESIONAL PROFESIONAL_ID ,SOCIO_ACTIVIDADES.SECTACT SECTACT" +
                                 "  FROM   SOCIO_ACTIVIDADES ,PROFESIONALES,SECTACT    WHERE    " +
                                 "  SOCIO_ACTIVIDADES.PROFESIONAL=PROFESIONALES.ID " +
                                 " AND      SOCIO_ACTIVIDADES.SECTACT    =   SECTACT.ID  " +
                                " AND  SOCIO_ACTIVIDADES.ID_DEPORTE=  " + ID_ROL.ToString() + "  AND SOCIO_ACTIVIDADES.ROL='" + ROL.TrimEnd() + "'"
                                + " AND (SOCIO_ACTIVIDADES.F_UPDATE IS NULL OR (SOCIO_ACTIVIDADES.F_UPDATE IS NOT NULL AND SOCIO_ACTIVIDADES.ESTADO=1))   ORDER BY    ACTIVIDAD ;";

            Datos_ini ini3 = new Datos_ini();
            DataSet ds1 = new DataSet();

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



                    dt1.Columns.Add("Detalle", typeof(string));
                



                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ACTIVIDAD")).Trim());

                    }

                    reader3.Close();



                    transaction.Commit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt1;


        }
    }
}
