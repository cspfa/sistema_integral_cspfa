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

namespace SOCIOS.deportes.Asistencia
{
    public partial class VerificacionAsistencia : Form
    {
     SOCIOS.bo dlog;
       SOCIOS.deportes.CamposService cs = new CamposService();
       string ROL = "";
       SOCIOS.deportes.Asistencia.AsistenciaService asist_service = new AsistenciaService();
       List<DateTime> Fechas = new List<DateTime>();


        public VerificacionAsistencia()
        {
           
            InitializeComponent();
            ROL = VGlobales.vp_role;
            
            cs.ComboRol(cbRol);

            this.ComboActividad();

            
     
        

        }

        //private void ComboActividad()
        //{
        //    string Query = "SELECT ID,DETALLE FROM SECTACT WHERE ROL='DEPORTES' AND DETALLE  NOT LIKE '%CUOTA%' and DETALLE NOT LIKE '%ATENCION AL PUBLICO%' AND DETALLE NOT LIKE '%TOALLAS%'  ORDER BY ID";
        //    bo dlog = new bo();
        //    cbActividad.DataSource = null;
        //    cbActividad.Items.Clear();
        //    cbActividad.DataSource = dlog.BO_EjecutoDataTable(Query);
        //    cbActividad.DisplayMember = "DETALLE";
        //    cbActividad.ValueMember = "ID";
        //    cbActividad.SelectedItem = 1;

      


        //}

        private void ComboActividad()

        {
            if (VGlobales.vp_role == "DEPORTES")
            {

                ROL = cbRol.Text.TrimEnd().TrimStart();
                cbRol.Visible = true;
                lbRol.Visible = true;


            }
            else
            {
                ROL = VGlobales.vp_role.TrimEnd().TrimStart();
                cbRol.Visible = false;
                lbRol.Visible = false;
            }

            cs.ComboActividad(ROL, cbActividad);
        }

        private void ArmoFecha()

        {

            Fechas.Clear();
            DateTime fecha1 = dpFechaDesde.Value;
            DateTime fecha2 = dpFEchaHasta.Value;

            int dias = (fecha2 - fecha1).Days;
          
            Fechas.Add(fecha2);
            DateTime Fecha = fecha2;
            while (dias != -1)
            {
                Fecha = Fecha.AddDays(-1);
                Fechas.Add(Fecha);
                dias = dias - 1;

              
            }
            
            

        }

        private void ReporteAsistencia_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }


        

        private void Reporte_Click(object sender, EventArgs e)
        {
            string Fecha;

            string Actividad;
            string ID;
            Fecha = "DESDE" + dpFechaDesde.Value.Day.ToString() + " - " + dpFechaDesde.Value.Month.ToString() + " - " + dpFechaDesde.Value.Year.ToString() + " HASTA " +
                    dpFEchaHasta.Value.Day.ToString() + " - " + dpFEchaHasta.Value.Month.ToString() + " - " + dpFEchaHasta.Value.Year.ToString();
            Actividad = cbActividad.Text.Trim();
            ID = cbActividad.SelectedValue.ToString();

            

            try
            {
                this.ArmoFecha();
                bo dlog = new bo();
                //Array que contendrá los parámetros
                ReportParameter[] parameters = new ReportParameter[2];

                //Establecemos el valor de los parámetros
                parameters[0] = new ReportParameter("Actividad", Actividad);
                parameters[1] = new ReportParameter("Fecha", Fecha);
                


                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Clear();
                var reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "DataSet2";
                reportDataSource1.Value = asist_service.Reporte_Verificacion_Asistencia(ID, ROL, dpFechaDesde.Value, dpFEchaHasta.Value);


              //  reportDataSource1.Value = asist_service.Verificar_Asistencia(ID, ROL,Fechas);       

                reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

                this.reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboActividad();
        }

        private void VerificacionAsistencia_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}