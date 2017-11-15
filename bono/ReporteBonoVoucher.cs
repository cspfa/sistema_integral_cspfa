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
    public partial class ReporteBonoVoucher : Form
    {


        CabeceraTitular CAB;
        DatoSocio SOC;
        DateTime Fecha;
        bo dlog;
        decimal Total;
        string Obs;
        string FormaPago;
        int ID;
        string Prof;
        int BonoAnulado;

        string Tipo;
        string Clase;
        int Salida;
        UtilsBono ub;
        SOCIOS.Turismo.TurismoUtils ut=new TurismoUtils();

        SOCIOS.Turismo.VoucherUtils vu = new VoucherUtils();

        public ReporteBonoVoucher( int pBono)
        {
            InitializeComponent();
            CAB = new CabeceraTitular();
            SOC = new DatoSocio();
            ID = pBono;
          
           

            dlog = new bo();
            ub = new UtilsBono();
            ut = new SOCIOS.Turismo.TurismoUtils();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SOCIOS.ReportPrintDocument rp = new ReportPrintDocument(reportViewer.LocalReport);
            rp.Print();
        }

        private void LoadDataReporte()
        {
            string FechaS;
            string FechaPaquete;
            string Actividad;



            SOCIOS.Turismo.voucherHotel objVoucher = vu.getVoucherHotel(ID);
            

            FechaS = Fecha.Day.ToString("00") + "-" + Fecha.Month.ToString("00") + "-" + Fecha.Year.ToString();
            
            DataTable personas =ut.DatosPersonas(ID.ToString());


            //determinar si el bono es Anulado o No

            BonoAnulado = ub.Anulado(ID);

            bo dlog = new bo();
            //Codigo Barra
            string Barra = "TU" + ID.ToString("0000000000");
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[18];
            //Establecemos el valor de los parámetros
            
         
          

           
            parameters[0] = new ReportParameter("Bono", objVoucher.ID_ROL_BONO.ToString("000000") + "-" + objVoucher.ROL.Substring(0,3));
            parameters[1] = new ReportParameter("Localidad", objVoucher.Lugar);
            parameters[2] = new ReportParameter("Barra", Barra);
             parameters[3] = new ReportParameter("Habitacion", objVoucher.Habitacion_Nombre);

             parameters[4] = new ReportParameter("Desde", objVoucher.Desde);
             parameters[5] = new ReportParameter("Hasta", objVoucher.Hasta);
             parameters[6] = new ReportParameter("Hotel", objVoucher.Hotel_Nombre);
             parameters[7] = new ReportParameter("Regimen", objVoucher.Regimen_Nombre);
             parameters[8] = new ReportParameter("ObsHotel", objVoucher.ObsHotel);

            parameters[9] = new ReportParameter("ContactoHotel", objVoucher.Telefono);
            parameters[10] = new ReportParameter("DireccionHotel", objVoucher.Direccion);

            parameters[11] = new ReportParameter("CheckIn",objVoucher.CheckIn);
            parameters[12] = new ReportParameter("CheckOut", objVoucher.CheckOut);
            parameters[13] = new ReportParameter("Noches", objVoucher.Estadia.Trim() );
            parameters[14] = new ReportParameter("Pasajeros", objVoucher.Pasajeros.ToString());
            parameters[15] = new ReportParameter("ID",ID.ToString());
            parameters[16] = new ReportParameter("OBS", objVoucher.OBS);
            parameters[17] = new ReportParameter("NroHabitacion", objVoucher.Nro_Habitacion);

            try
            {

                this.reportViewer.LocalReport.SetParameters(parameters);
                reportViewer.LocalReport.DataSources.Clear();

                reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetPersonaPasaje", personas));

                this.reportViewer.RefreshReport();
                reportViewer.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void ReporteBonoHotel_Load(object sender, EventArgs e)
        {
            this.LoadDataReporte();
        }

    }
}
