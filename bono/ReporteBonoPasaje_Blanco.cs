using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
using SOCIOS.Turismo;

namespace SOCIOS.bono
{
    public partial class ReporteBonoPasaje_Blanco : Form
    {   int ID_ROL;
         int ID;
        DateTime Fecha;
              UtilsBono ub;
           CabeceraTitular CAB;
           string ROL;
           SOCIOS.Turismo.TurismoUtils ut = new TurismoUtils();

        public ReporteBonoPasaje_Blanco(int pID_ROL,int pID,DateTime pFecha,   CabeceraTitular pCAB ,string pROL)
        {
            ID_ROL = pID_ROL;
            Fecha = pFecha;
            CAB = pCAB;
            ROL = pROL;

            InitializeComponent();
        }

        private void ReporteBonoBlanco_Load(object sender, EventArgs e)
        {
            this.LoadDataReporte();
            this.reportViewer1.RefreshReport();
        }

        private void LoadDataReporte()
        {
            string FechaS;
            string FechaPaquete;
            string Actividad;

      


            FechaS = Fecha.Day.ToString("00") + "-" + Fecha.Month.ToString("00") + "-" + Fecha.Year.ToString();
        
    
            bo dlog = new bo();
            //Codigo Barra
            string Barra = "TU" + ID.ToString("0000000000");
            //DIAS DISPONIBLES

            Hotel_Dias_Utils dias = new Hotel_Dias_Utils();
            string infoDias = "";

         

            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[12];


            //Establecemos el valor de los parámetros

            parameters[0] = new ReportParameter("Fecha", FechaS);
            parameters[1] = new ReportParameter("Bono", ID_ROL.ToString("000000") + "-" + ROL.ToString());
            parameters[2] = new ReportParameter("Socio", CAB.NroSocioTitular);
            parameters[3] = new ReportParameter("Dni", CAB.Dni);
            parameters[4] = new ReportParameter("Afiliado", CAB.NroAfiliadoTitular.TrimEnd());
            parameters[5] = new ReportParameter("Beneficio", CAB.NroBeneficioTitular.TrimEnd());
            parameters[6] = new ReportParameter("NombreTit", CAB.NombreTitular.TrimEnd());
            parameters[7] = new ReportParameter("Domicilio", CAB.Domicilio.TrimEnd());
            parameters[8] = new ReportParameter("Localidad", CAB.Localidad.TrimEnd());
            parameters[9] = new ReportParameter("Telefono", CAB.Telefonos.TrimEnd());
            parameters[10] = new ReportParameter("Edad", "0");
            
            parameters[11] = new ReportParameter("Barra", Barra);
          

            try
            {

                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Clear();
                DataTable personas = ut.DatosPersonas(ID.ToString());
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetPersonaPasaje",personas ));
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetPasaje", personas));
                this.reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
