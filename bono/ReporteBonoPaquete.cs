﻿using System;
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
    public partial class ReporteBonoPaquete : Form
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
        SOCIOS.Turismo.TurismoUtils ut;



        public ReporteBonoPaquete()
        {
            InitializeComponent();
        }

        public ReporteBonoPaquete(CabeceraTitular pCAB, DateTime pfecha, int pBono, string pFormaPago, string pObs, decimal pTotal,int pSalida)

        {   CAB = new CabeceraTitular();
            SOC = new DatoSocio();
            ID = pBono;
            FormaPago = pFormaPago;
            Obs = pObs;
            Total = pTotal;
            CAB = pCAB;
            Fecha = pfecha;
            Salida = pSalida;
            
            dlog = new bo();
            ub =  new UtilsBono();
            ut = new SOCIOS.Turismo.TurismoUtils();
            
            InitializeComponent();

        }
        
        
        


        private void ReporteBonoPaquete_Load(object sender, EventArgs e)
        {

            this.LoadDataReporte();

        }

        private void LoadDataReporte()
        {
            string FechaS;
            string FechaPaquete;
            string Actividad;

            SOCIOS.Turismo.Salida  objSalida = ut.GetSalida(Salida);
            if (objSalida == null)
                throw new Exception("el paquete no tiene salida!");
            FechaS = Fecha.Day.ToString("00") + "-" + Fecha.Month.ToString("00") + "-" + Fecha.Year.ToString();
            FechaPaquete = objSalida.Fecha.Day.ToString("00") + objSalida.Fecha.Month.ToString("00") + "-" + objSalida.Fecha.Year.ToString();
            DataTable personas = ut.DatosPersonas(ID.ToString());

            
            //determinar si el bono es Anulado o No

            BonoAnulado = ub.Anulado(ID);
           
            bo dlog = new bo();
            //Codigo Barra
            string Barra = "TU" + ID.ToString("0000000000");
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[27];
            //Establecemos el valor de los parámetros

            parameters[0] = new ReportParameter("Fecha", FechaS);
            parameters[1] = new ReportParameter("Bono", ID.ToString("000000"));
            parameters[2] = new ReportParameter("Socio", CAB.NroSocioTitular);
            parameters[3] = new ReportParameter("Dni", CAB.Dni);
            parameters[4] = new ReportParameter("Afiliado", CAB.NroAfiliadoTitular);
            parameters[5] = new ReportParameter("Beneficio", CAB.NroBeneficioTitular);
            parameters[6] = new ReportParameter("NombreTit", CAB.NombreTitular);
            parameters[7] = new ReportParameter("Domicilio", CAB.Domicilio);
            parameters[8] = new ReportParameter("Localidad", CAB.Localidad);
            parameters[9] = new ReportParameter("Telefono", CAB.Telefonos);
            parameters[10] = new ReportParameter("Edad", "0");
            parameters[11] = new ReportParameter("FormaPago", FormaPago);
            parameters[12] = new ReportParameter("Obs", Obs);
            parameters[13] = new ReportParameter("Total", Total.ToString("0.##"));
            parameters[14] = new ReportParameter("Anulado", BonoAnulado.ToString());
            parameters[15] = new ReportParameter("Autorizacion", "");
            parameters[16] = new ReportParameter("Empresa",objSalida.Operador_Nombre);
            
           
            parameters[17] = new ReportParameter("Barra", Barra);
          
            parameters[18] = new ReportParameter("Paquete", objSalida.Nombre);
            parameters[19] = new ReportParameter("Desde", objSalida.Prov_Desde_Nombre);
            parameters[20] = new ReportParameter("Hasta", objSalida.Prov_Hasta_Nombre);
            parameters[21] = new ReportParameter("FechaPaquete",FechaPaquete );
            parameters[22] = new ReportParameter("Traslado", objSalida.Traslado_Nombre);
            parameters[23] = new ReportParameter("Hotel", objSalida.Hotel_Nombre);
            parameters[24] = new ReportParameter("Regimen", objSalida.Regimen_Nombre);
            parameters[25] = new ReportParameter("ObsPaquete", objSalida.Observaciones);
            parameters[26] = new ReportParameter("Estadia", objSalida.Estadia.TrimEnd());




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
            
            }
        }


       


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SOCIOS.ReportPrintDocument rp = new ReportPrintDocument(reportViewer.LocalReport);
            rp.Print();
        }
    }
}
