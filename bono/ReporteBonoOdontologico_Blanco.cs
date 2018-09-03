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
    public partial class ReporteBonoOdontologico_Blanco : Form
    {   CabeceraTitular CAB;
        DatoSocio SOC;
        DateTime Fecha;
          bo dlog;
        decimal Total;
        string Obs;
        string FormaPago;
        int ID;
        int CODINT;

        
        public ReporteBonoOdontologico_Blanco(int ID_ROL,int COD_INT)
        {
     
            InitializeComponent();
            ID = ID_ROL;
            CODINT = COD_INT;
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
            
         

          
            DataTable ds = null;
            
            //Determinar si el bono es Anulado o No

        

            bo dlog = new bo();
            //Codigo de Barra
       
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[2];
            //Establecemos el valor de los parámetros
       

     
          
            parameters[0] = new ReportParameter("ID", ID.ToString());
            parameters[1] = new ReportParameter("CODINT", CODINT.ToString());
          

            this.reportViewer.LocalReport.SetParameters(parameters);
            //reportViewer.LocalReport.DataSources.Clear();

            //reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds));

           
            this.reportViewer.RefreshReport();
            reportViewer.Visible = true;
        
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
