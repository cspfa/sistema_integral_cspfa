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
        string PROFESIONAL_NOMBRE;

        
        public ReporteBonoOdontologico_Blanco(int ID_ROL,int COD_INT,string PROFESIONAL)
        {
     
            InitializeComponent();
            ID          = ID_ROL;
            CODINT      = COD_INT;
            PROFESIONAL_NOMBRE = PROFESIONAL;

        }

        private void ReporteBonoOdontologico_Load(object sender, EventArgs e)
        {
            string texto;
            try
            {
                cbOrden.Text = "ORIGINAL";
                this.LoadDataReporte("ORIGINAL");
            } catch (Exception ex)
            {
                texto = ex.Message;
            }

        }

        private void LoadDataReporte(string ORDEN)

        {
            
         

          
            DataTable ds = null;
            
            //Determinar si el bono es Anulado o No

        

            bo dlog = new bo();
            //Codigo de Barra
       
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[4];
            //Establecemos el valor de los parámetros
       

     
          
            parameters[0] = new ReportParameter("ID", ID.ToString());
            parameters[1] = new ReportParameter("CODINT", CODINT.ToString());
            parameters[2] = new ReportParameter("ORDEN", ORDEN);

            parameters[3] = new ReportParameter("PROFESIONAL",PROFESIONAL_NOMBRE);

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

        private void Refrescar_Click(object sender, EventArgs e)
        {
            this.LoadDataReporte(cbOrden.Text.ToString());
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {

        }

        public void Imprimir_Todo_Directo()
        {
            SOCIOS.ReportPrintDocument rp;
            //ORIGINAL
            this.LoadDataReporte("ORIGINAL");
            rp = new ReportPrintDocument(reportViewer.LocalReport);
            rp.Print();
            //DUPLICADO
            this.LoadDataReporte("DUPLICADO");
            rp = new ReportPrintDocument(reportViewer.LocalReport);
            rp.Print();
            //TRIPLICADO
            this.LoadDataReporte("TRIPLICADO");
            rp = new ReportPrintDocument(reportViewer.LocalReport);
            rp.Print();
        }

        private void imprimir_Todo_Click(object sender, EventArgs e)
        {
            this.Imprimir_Todo_Directo();
        }


    }
}
