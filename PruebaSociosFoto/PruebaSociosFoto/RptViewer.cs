using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;






namespace SOCIOS
{
    public partial class RptViewer : Form
    {

        private ReportDocument customerReport;

        public RptViewer()
        {
            InitializeComponent();
        }

        private void ConfigureCrystalReports()
        {
         
         

            customerReport = new ReportDocument();


            string reportPath = Directory.GetCurrentDirectory() + "\\Socios.rpt";


            reportPath = "C:\\CSPFA_SOCIOS\\Socios.rpt";


           // MessageBox.Show(reportPath);



            //string reportPath = Application.StartupPath + "\\" + "Socios.rpt";
            //string reportPath = "C:\\Descargas\\socios-010710\\socios\\PruebaSociosFoto\\PruebaSociosFoto\\Socios.rpt";
            customerReport.Load(reportPath);
            DataSet dataSet = DataSetConfiguration.TitFamAdh;
            dataSet = DataSetConfiguration.TitFamAdh;

            customerReport.SetDataSource(dataSet);
            crystalReportViewer1.ReportSource = customerReport;

            //if (File.Exists("C:\\TMP.TIF"))
            //    File.Delete("C:\\TMP.TIF");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureCrystalReports();
        }

        private void crystalReportViewer_Load(object sender, EventArgs e)
        {

        }

        // conversiones de BLOB a IMG y viceversa
        // De image a byte []:
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            //imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        // De byte [] a image:
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }





    }
}