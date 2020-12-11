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
using System.IO;

namespace SOCIOS.bono
{
    public class Montos_Bono
    {
        public string Efectivo { get; set; }
        public string Debito   { get; set; }
        public string Credito  { get; set; }
        public string Planilla { get; set; }
        public string Transfer { get; set; }
        public string CONTRALOR   { get; set; }
        public string TOTAL { get; set; }
    
    }

    public class Datos_Personales_Bono
    {
        public string Mail      { get; set; }
        public string Telefono  { get; set; }
        public Datos_Personales_Bono()
        {
            Mail     = "";
            Telefono = "";
        }
    }
    public partial class ReporteBonoOdontologico : Form
    {   CabeceraTitular CAB;
        DatoSocio SOC;
        DateTime Fecha;
          bo dlog;
        decimal Total;
        string Obs;
        string FormaPago;
        int ID;
        int ID_ROL;
        string Prof;
        int BonoAnulado;
        SOCIOS.bono.BonoUtils bonoUtils = new bono.BonoUtils();
        
        public ReporteBonoOdontologico(CabeceraTitular pCAB,DatoSocio pSOC,DateTime pfecha, int pBono,string pProf,string pFormaPago,string pObs,decimal pTotal,int pID_ROL)
        {
            CAB = new CabeceraTitular();
            SOC = new DatoSocio();
            ID = pBono;
            ID_ROL = pID_ROL;
            FormaPago = pFormaPago;
            Obs = pObs;
            Total = pTotal;
            CAB = pCAB;
            SOC = pSOC;
            Prof = pProf.TrimEnd().TrimStart();
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
            Montos_Bono mb = new bono.Montos_Bono();
         

            FechaS = Fecha.Day.ToString("00") + "-" + Fecha.Month.ToString("00") + "-" + Fecha.Year.ToString();
            DataTable ds = this.Datos(ID.ToString());
            

            //Determinar si el bono es Anulado o No

            BonoAnulado = this.Anulado(ID);

            // Traigo Montos
            mb = this.Montos_Bono(ID);
            string Leyenda = "";
            Leyenda = bonoUtils.LEYENDA_BONO_PROFESIONAL_DESDE_BONO(ID);
            bo dlog = new bo();
            //Codigo de Barra
            string Barra = "OD" + ID_ROL.ToString("0000000000");
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[28];
            //Establecemos el valor de los parámetros
            int nroContraLor = this.Contralor(ID);
            string Contralor = nroContraLor.ToString();

            if (nroContraLor != 0)
                Contralor = "Contralor DTO : "+  nroContraLor.ToString();
            parameters[0] = new ReportParameter("Fecha", FechaS);
            parameters[1] = new ReportParameter("Bono", ID_ROL.ToString("000000"));
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
            parameters[15] = new ReportParameter("Total", mb.TOTAL);
            parameters[16] = new ReportParameter("Anulado", BonoAnulado.ToString());
            parameters[17] = new ReportParameter("Barra", Barra);
            if (Contralor != "0")
                parameters[18] = new ReportParameter("Contralor","CONTRALOR:" + Contralor);
            else
                 parameters[18] = new ReportParameter("Contralor","");
            parameters[19] = new ReportParameter("Categoria",SOC.TIPO );
            parameters[20] = new ReportParameter("Directivo", "");
            parameters[21] = new ReportParameter("Cargo", "");

            parameters[22] = new ReportParameter("EFECTIVO", mb.Efectivo);
            parameters[23] = new ReportParameter("PLANILLA", mb.Planilla);
            parameters[24] = new ReportParameter("DEBITO", mb.Debito);
            parameters[25] = new ReportParameter("CREDITO", mb.Credito);
            parameters[26] = new ReportParameter("Leyenda", mb.Credito);
            parameters[27] = new ReportParameter("TRANSFER", mb.Transfer);

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
                return Int32.Parse(foundRows[0][0].ToString());
            }
            else
                return 0;
        
        }


        private Montos_Bono Montos_Bono (int pBono)
        {
            string QUERY = "select EFECTIVO,TARJETA_CREDITO,TARJETA_CREDITO_CUOTAS,TARJETA_DEBITO,PLANILLA,PLANILLA_CUOTAS,TRANSFER from  BONO_ODONTOLOGICO WHERE   ID= " + pBono.ToString();
            DataRow[] foundRows;
            Montos_Bono mb = new bono.Montos_Bono();
            decimal TOTAL = 0;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            
            if (foundRows.Length > 0)
            {
                mb.Efectivo = Decimal.Round(Decimal.Parse(foundRows[0][0].ToString()), 2).ToString();
                TOTAL = TOTAL + Decimal.Round(Decimal.Parse(foundRows[0][0].ToString()), 2);
                if (foundRows[0][2].ToString() != "0")
                {
                    mb.Credito = Decimal.Round(Decimal.Parse(foundRows[0][1].ToString()), 2).ToString() + " - " + foundRows[0][2].ToString() + " Cuotas";
                    TOTAL = TOTAL + Decimal.Round(Decimal.Parse(foundRows[0][1].ToString()), 2);
                }
                else
                    mb.Credito = "0";

                mb.Debito = Decimal.Round(Decimal.Parse(foundRows[0][3].ToString()), 2).ToString();
                TOTAL = TOTAL + Decimal.Round(Decimal.Parse(foundRows[0][3].ToString()), 2);
                if (foundRows[0][5].ToString() != "0")
                {
                    mb.Planilla = Decimal.Round(Decimal.Parse(foundRows[0][4].ToString()), 2).ToString() + " - " + foundRows[0][5].ToString() + " Cuotas";
                    TOTAL = TOTAL + Decimal.Round(Decimal.Parse(foundRows[0][4].ToString()), 2);
                }
                else
                    mb.Planilla = "0";

                if (foundRows[0][6].ToString().Length>0 )
                {
                    if (foundRows[0][6].ToString() != "0")
                    {
                        mb.Transfer = Decimal.Round(Decimal.Parse(foundRows[0][6].ToString()), 2).ToString();
                        TOTAL = TOTAL + Decimal.Round(Decimal.Parse(foundRows[0][6].ToString()), 2);
                    }
                }
              

                
            }

            mb.TOTAL = Decimal.Round(Total, 2).ToString();
            return mb;

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

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] Bytes = reportViewer.LocalReport.Render(format: "PDF", deviceInfo: "");

            using (FileStream stream = new FileStream("\\\\192.168.1.6\\factura_electronica\\1\\test.pdf", FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }  
        }


    }
}
