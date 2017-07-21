using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SOCIOS.entradaCampo.Reporte
{
    public partial class ReporteIngresos : Form
    {
        public ReporteIngresos(DateTime Desde, DateTime Hasta, List<SOCIOS.EntradaCampo> Datos,string User)
        {
            InitializeComponent();

            //reportViewer.LocalReport.Refresh();
            //reportViewer.RefreshReport();
            // reportViewer.LocalReport.ReportEmbeddedResource = @"ReporteEntradaCampo.rdlc";
            //  Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[4];






            //Establecemos el valor de los parámetros

            parameters[0] = new ReportParameter("FechaDesde", Desde.ToShortDateString());
            parameters[1] = new ReportParameter("FechaHasta", Hasta.ToShortDateString());
            parameters[2] = new ReportParameter("CAMPO", VGlobales.vp_role);
            parameters[3] = new ReportParameter("USER", User);


            try
            {

                this.reportViewer.LocalReport.SetParameters(parameters);
                reportViewer.LocalReport.DataSources.Clear();

                reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetReporte", Datos.OrderBy(x=>x.ID_INTERNO).ToList()));
                reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetReintegros", Datos.Where(x => x.MONTO_TOTAL < 0).OrderBy(x => x.ID_INTERNO).ToList()));
                this.reportViewer.RefreshReport();
                reportViewer.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReporteIngresos_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}
