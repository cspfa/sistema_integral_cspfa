using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SOCIOS.Tecnica
{
    public partial class ReporteTickets : Form
    {
        public ReporteTickets(List<TicketReporte> lista,string INFO)
        {
          

            InitializeComponent();

            //reportViewer.LocalReport.Refresh();
            //reportViewer.RefreshReport();
            // reportViewer.LocalReport.ReportEmbeddedResource = @"ReporteEntradaCampo.rdlc";
            //  Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[1];






            //Establecemos el valor de los parámetros

            parameters[0] = new ReportParameter("INFO", INFO);
           

            try
            {

                this.reportViewer.LocalReport.SetParameters(parameters);

                reportViewer.LocalReport.DataSources.Clear();

                reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", lista));
              
                this.reportViewer.RefreshReport();
                reportViewer.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReporteTickets_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}
