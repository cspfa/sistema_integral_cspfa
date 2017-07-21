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

namespace SOCIOS.bono
{
    public partial class ReporteBonoOdontologico : Form
    {   CabeceraTitular CAB;
        DatoSocio SOC;
        DateTime Fecha;
          bo dlog;
        decimal Total;
        string Obs;
        string FormaPago;
        int ID;
        string Prof;
        int BonoAnulado;
        
        public ReporteBonoOdontologico(CabeceraTitular pCAB,DatoSocio pSOC,DateTime pfecha, int pBono,string pProf,string pFormaPago,string pObs,decimal pTotal)
        {
            CAB = new CabeceraTitular();
            SOC = new DatoSocio();
            ID = pBono;
            FormaPago = pFormaPago;
            Obs = pObs;
            Total = pTotal;
            CAB = pCAB;
            SOC = pSOC;
            Prof = pProf;
            Fecha = pfecha;
            dlog = new bo();
           
            InitializeComponent();
        }

        private void ReporteBonoOdontologico_Load(object sender, EventArgs e)
        {
            string texto;
            try
            {
                this.LoadDataReporte();
            } catch (Exception ex)
            {
                texto = ex.Message;
            }

        }

        private void LoadDataReporte()

        {
            string FechaS;
            string Actividad;
         

            FechaS = Fecha.Day.ToString("00") + "-" + Fecha.Month.ToString("00") + "-" + Fecha.Year.ToString();
            DataTable ds = this.Datos(ID.ToString());
            
            //Determinar si el bono es Anulado o No

            BonoAnulado = this.Anulado(ID);

            bo dlog = new bo();
            //Codigo de Barra
            string Barra = "OD" + ID.ToString("0000000000");
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[19];
            //Establecemos el valor de los parámetros
            int nroContraLor = this.Contralor(ID);
            string Contralor = "";

            if (nroContraLor != 0)
                Contralor = "Contralor DTO : "+  nroContraLor.ToString();
            parameters[0] = new ReportParameter("Fecha", FechaS);
            parameters[1] = new ReportParameter("Bono", ID.ToString("000000"));
            parameters[2] = new ReportParameter("Socio", CAB.NroSocioTitular);
            parameters[3] = new ReportParameter("Dni", CAB.Dni);
            parameters[4] = new ReportParameter("Afiliado", CAB.NroAfiliadoTitular);
            parameters[5] = new ReportParameter("Beneficio", CAB.NroBeneficioTitular);
            parameters[6] = new ReportParameter("NombreTit", CAB.NombreTitular);
            parameters[7] = new ReportParameter("Domicilio", CAB.Domicilio);
            parameters[8] = new ReportParameter("Localidad",CAB.Localidad);
            parameters[9] = new ReportParameter("Telefono", CAB.Telefonos);
            parameters[10] = new ReportParameter("NombrePac",SOC.APELLIDO + "," + SOC.NOMBRE );
           
            parameters[11] = new ReportParameter("Edad", SOC.EDAD);

            parameters[12] = new ReportParameter("FormaPago", FormaPago);
            parameters[13] = new ReportParameter("Obs", Obs);
            parameters[14] = new ReportParameter("Prof",Prof );
            parameters[15] = new ReportParameter("Total", Total.ToString("0.##"));
            parameters[16] = new ReportParameter("Anulado", BonoAnulado.ToString());
            parameters[17] = new ReportParameter("Barra", Barra);
            parameters[18] = new ReportParameter("Contralor",Contralor);
            this.reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds));

           
            this.reportViewer.RefreshReport();
            reportViewer.Visible = true;
        
        }


        private DataTable Datos(string ID)
        {

            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
            string Query = @" SELECT B.MONTO Monto,T.DETALLE Descripcion  
  from bono_detalle B,SectAct T where B.SECTACT = T.ID   and B.BONO =" + ID;
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



                    dt1.Columns.Add("Monto", typeof(string));
                    dt1.Columns.Add("Descripcion", typeof(string));
                


                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("Monto")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Descripcion")).Trim());

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

        private int Anulado(int pBono)
        {
            string QUERY = "select ID  from  BONO_ODONTOLOGICO WHERE coalesce(FE_BAJA,'1')='1' and  ID= "+ pBono.ToString();
            DataRow[] foundRows;
           
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

          
            if (foundRows.Length > 0)
            {
                return 0;
            }
            else
                return 1;
        
        
        
        }

        private int Contralor(int pBono)

        {
            string QUERY = "select CONTRALOR from  BONO_ODONTOLOGICO WHERE coalesce(FE_BAJA,'1')='1' and  ID= " + pBono.ToString();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {
                return 0;
            }
            else
                return 1;
        
        }

        private void Print_Click(object sender, EventArgs e)
        {
            SOCIOS.ReportPrintDocument rp = new ReportPrintDocument(reportViewer.LocalReport);
            rp.Print();
        }

        public void ImprimirDirecto()

        {
            SOCIOS.ReportPrintDocument rp = new ReportPrintDocument(reportViewer.LocalReport);
            rp.Print();
        }


    }
}
