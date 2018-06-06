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
    public partial class ReporteBonoHotel : Form
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

        public ReporteBonoHotel(CabeceraTitular pCAB, DateTime pfecha, int pBono, string pFormaPago, string pObs, decimal pTotal)
        {
            InitializeComponent();
            CAB = new CabeceraTitular();
            SOC = new DatoSocio();
            ID = pBono;
            FormaPago = pFormaPago;
            Obs = pObs;
            Total = pTotal;
            CAB = pCAB;
            Fecha = pfecha;
           

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
            string Barra = "TU" + objVoucher.ID_ROL_BONO.ToString("0000000000");
            //DIAS DISPONIBLES

            Hotel_Dias_Utils dias = new Hotel_Dias_Utils();
            string infoDias="";
           
            if (objVoucher.BonoSocial)
                infoDias = dias.ConsultarDiasAbreviado(Int32.Parse(CAB.NroSocioTitular),Int32.Parse(CAB.NroDepTitular));
            
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[34];
            
            
            //Establecemos el valor de los parámetros

            parameters[0] = new ReportParameter("Fecha", FechaS);
            parameters[1] = new ReportParameter("Bono", objVoucher.ID_ROL_BONO.ToString("000000") + "-" + objVoucher.ROL.ToString() );
            parameters[2] = new ReportParameter("Socio", CAB.NroSocioTitular);
            parameters[3] = new ReportParameter("Dni", CAB.Dni);
            parameters[4] = new ReportParameter("Afiliado", CAB.NroAfiliadoTitular.TrimEnd());
            parameters[5] = new ReportParameter("Beneficio", CAB.NroBeneficioTitular.TrimEnd());
            parameters[6] = new ReportParameter("NombreTit", CAB.NombreTitular.TrimEnd());
            parameters[7] = new ReportParameter("Domicilio", CAB.Domicilio.TrimEnd());
            parameters[8] = new ReportParameter("Localidad", CAB.Localidad.TrimEnd());
            parameters[9] = new ReportParameter("Telefono", CAB.Telefonos.TrimEnd());
            parameters[10] = new ReportParameter("Edad", "0");
            parameters[11] = new ReportParameter("FormaPago", FormaPago.TrimEnd());
            parameters[12] = new ReportParameter("Obs", Obs);
            parameters[13] = new ReportParameter("Total", Total.ToString("0.##"));
            parameters[14] = new ReportParameter("Anulado", BonoAnulado.ToString());
            parameters[15] = new ReportParameter("Autorizacion", "");
            parameters[16] = new ReportParameter("Empresa", "CSPFA");
            parameters[17] = new ReportParameter("Barra", Barra);
            parameters[18] = new ReportParameter("Habitacion", objVoucher.Habitacion_Nombre.TrimEnd());
            parameters[19] = new ReportParameter("Desde", objVoucher.Desde);
            parameters[20] = new ReportParameter("Hasta", objVoucher.Hasta);
            parameters[21] = new ReportParameter("FechaPaquete", "");
            parameters[22] = new ReportParameter("Traslado", "");
            parameters[23] = new ReportParameter("Hotel", objVoucher.Hotel_Nombre.TrimEnd());
            parameters[24] = new ReportParameter("Regimen", objVoucher.Regimen_Nombre.TrimEnd());
            parameters[25] = new ReportParameter("ObsHotel", objVoucher.ObsHotel.TrimEnd());
            parameters[26] = new ReportParameter("Estadia", objVoucher.Estadia.Trim());
            parameters[27] = new ReportParameter("ContactoHotel", objVoucher.Telefono.TrimEnd());
            parameters[28] = new ReportParameter("Nro_Habitacion", objVoucher.Nro_Habitacion.TrimEnd());
            parameters[29] = new ReportParameter("Social", objVoucher.BonoSocial.ToString());
            parameters[30] = new ReportParameter("Motivo", objVoucher.Motivo.ToString());
            parameters[31] = new ReportParameter("DiasDisponibles",infoDias);
            parameters[32] = new ReportParameter("Directivo","");
            parameters[33] = new ReportParameter("Cargo", "");
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
               MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReporteBonoHotel_Load(object sender, EventArgs e)
        {
            this.LoadDataReporte();
        }

        private void Voucher_Click(object sender, EventArgs e)
        {
             
        
       
            ReporteBonoVoucher rb = new ReporteBonoVoucher(ID);
            rb.ShowDialog();
            rb.Focus();
          
        
        }

    }
}
