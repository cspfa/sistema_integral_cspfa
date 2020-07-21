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
    public partial class ReporteBonoPasaje : Form
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
        string Empresa;
        string Tipo;
        string Clase;
        int ID_ROL ;
        string ROL;
        string CODINT = "";
        SOCIOS.Turismo.TurismoUtils ut = new SOCIOS.Turismo.TurismoUtils();

        public ReporteBonoPasaje(CabeceraTitular pCAB,DateTime pfecha, int pBono,string pFormaPago,string pObs,decimal pTotal)
        {
            CAB = new CabeceraTitular();
            SOC = new DatoSocio();
            ID = pBono;
            FormaPago = pFormaPago;
            Obs = pObs;
            Total = pTotal;
            CAB = pCAB;
           
           
            Fecha = pfecha;
            dlog = new bo();
           
            InitializeComponent();
        }

        private void ReporteBonoOdontologico_Load(object sender, EventArgs e)
        {
            this.LoadDataReporte();
            
        }

        private void LoadDataReporte()

        {
            string FechaS;
            string Actividad;
         

            FechaS = Fecha.Day.ToString("00") + "-" + Fecha.Month.ToString("00") + "-" + Fecha.Year.ToString();
            DataTable personas = this.DatosPersonas(ID.ToString());
            DataTable pasajes = this.DatosPasaje(ID.ToString());
            Montos_Bono mb = new bono.Montos_Bono();
            mb = ut.Montos_Bono(ID);

            Datos_Personales_Bono dp = new Datos_Personales_Bono();
            dp = ut.Datos_Personales_Bono(ID);
            
            //determinar si el bono es Anulado o No

            BonoAnulado = this.Anulado(ID);
            this.DatosPasaje(ID);
            bo dlog = new bo();
            //Codigo Barra
            string Barra = "TU" + ID_ROL.ToString("0000000000");
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[30];
            //Establecemos el valor de los parámetros
                      
            parameters[0] = new ReportParameter("Fecha", FechaS);
            parameters[1] = new ReportParameter("Bono", ID_ROL.ToString("000000") + "-" + ROL.Substring(0,3));
            parameters[2] = new ReportParameter("Socio", CAB.NroSocioTitular);
            parameters[3] = new ReportParameter("Dni", CAB.Dni);
            parameters[4] = new ReportParameter("Afiliado", CAB.NroAfiliadoTitular);
            parameters[5] = new ReportParameter("Beneficio", CAB.NroBeneficioTitular);
            parameters[6] = new ReportParameter("NombreTit", CAB.NombreTitular);
            parameters[7] = new ReportParameter("Domicilio", CAB.Domicilio);
            parameters[8] = new ReportParameter("Localidad",CAB.Localidad);
            parameters[9] = new ReportParameter("Telefono", dp.Telefono);
            parameters[10] = new ReportParameter("Edad", "0");
            parameters[11] = new ReportParameter("FormaPago", FormaPago);
            parameters[12] = new ReportParameter("Obs", Obs);
            parameters[13] = new ReportParameter("Total", mb.TOTAL);
            parameters[14] = new ReportParameter("Anulado", BonoAnulado.ToString());
            parameters[15] = new ReportParameter("Autorizacion",mb.CONTRALOR);
            parameters[16] = new ReportParameter("Empresa", Empresa);
            parameters[17] = new ReportParameter("Tipo", Tipo);
            parameters[18] = new ReportParameter("Clase", Clase);
            parameters[19] = new ReportParameter("Barra", Barra);
            parameters[20] = new ReportParameter("Directivo", "");
            parameters[21] = new ReportParameter("Cargo", "");
            parameters[22] = new ReportParameter("EFECTIVO", mb.Efectivo);
            parameters[23] = new ReportParameter("DEBITO", mb.Debito);
            parameters[24] = new ReportParameter("CREDITO", mb.Credito);
            parameters[25] = new ReportParameter("PLANILLA", mb.Planilla);
            parameters[26] = new ReportParameter("TRANSFER", mb.Transfer);
            parameters[27] = new ReportParameter("Mail", dp.Mail);
            parameters[28] = new ReportParameter("CODINT","");
            parameters[29] = new ReportParameter("PLAN_CUENTA", "");
            this.reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetPasaje", pasajes));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetPersonaPasaje", personas));
           
            this.reportViewer.RefreshReport();
            reportViewer.Visible = true;
        
        }


        private DataTable DatosPersonas(string ID)
        {

            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
            string Query = @" select Nombre,Apellido,'ARG' Nacionalidad, 'Dni' TipoDni, Dni from bono_Personas
            where  ROL ='TURISMO' and BONO=" + ID;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt1;


        }


        private DataTable DatosPasaje(string ID)
        {

            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
            string Query = @"select B.Boleto  NroBoleto ,B.Cantidad Cantidad , extract(day from B.Salida)||'.'||extract(month from  B.Salida)||'.'||extract(year from  B.Salida)  FechaSalida, 
                            B.Origen Origen ,  B.IMPORTE_TOTAL Monto,LO.DES_SHORT OrigenText,B.Destino Destino,
                            LD.DES_SHORT DestinoText  
                            from bono_turismo_pasajes B , Localidad LO , Localidad LD
                            where B.ORIGEN = LO.LOCALIDADID AND B.DESTINO = LD.LOCALIDADID AND B.BONO=" + ID;
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



                    dt1.Columns.Add("NroBoleto", typeof(string));
                    dt1.Columns.Add("Cantidad", typeof(string));
                    dt1.Columns.Add("FechaSalida", typeof(string));
                    dt1.Columns.Add("Origen", typeof(string));
                    dt1.Columns.Add("Monto", typeof(string));
                    dt1.Columns.Add("OrigenText", typeof(string));
                    dt1.Columns.Add("Destino", typeof(string));
                    dt1.Columns.Add("DestinoText", typeof(string));

                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("NroBoleto")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Cantidad")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("FechaSalida")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Origen")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Monto")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("OrigenText")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Destino")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DestinoText")).Trim());
                                     


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
            string QUERY = "select ID  from  BONO_TURISMO WHERE coalesce(FE_BAJA,'1')='1' and  ID= "+ pBono.ToString();
            DataRow[] foundRows;
           
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

          
            if (foundRows.Length > 0)
            {
                return 0;
            }
            else
                return 1;
        
        
        
        }

        private void DatosPasaje (int ID)
        {
            string QUERY = " select B.Tipo_pasaje, B.Clase_Pasaje,T.Razon_Social,B.ID_ROL, B.ROL,B.CODINT from bono_turismo  B, Proveedores T where T.ID = B.OPERADOR and B.ID= " + ID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
               Tipo= foundRows[0][0].ToString().Trim();
               Clase = foundRows[0][1].ToString().Trim();
               Empresa = foundRows[0][2].ToString().Trim();
               ID_ROL = Int32.Parse(foundRows[0][3].ToString().Trim());
               ROL = foundRows[0][4].ToString();
               if (foundRows[0][5].ToString().Length>0)
                 CODINT = "CODINT:" +  foundRows[0][5].ToString();
            }
           
               


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
