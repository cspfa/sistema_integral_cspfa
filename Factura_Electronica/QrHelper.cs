using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

using System.IO;

using System.Drawing;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace SOCIOS.Factura_Electronica
{
    public class Data_QR
    {
        public int    ver      { get; set; }
        public string fecha    { get; set; }
        public string cuit     { get; set; }
        public int    ptoVta   { get; set; }
        public int    tipoCmp  { get; set; }
        public int     nroCmp  { get; set; }
        public decimal importe { get; set; }
        public string moneda    { get; set; }
        public int ctz          { get; set; }
        public int tipoDocRec    { get; set; }
        public string    nroDocRec { get; set; }
        public string    tipoCodAu  { get; set; }
        public string codAut { get; set; }

        public Data_QR(DateTime Fecha,int Punto_Venta,int Tipo_Comprobante,int Numero,decimal Monto,int TipoDoc,string Doc,string CAE)
        {
            ver = 1;
            fecha = Fecha.Year.ToString() + "-" + Fecha.Month.ToString("00") + "-" + Fecha.Day.ToString();
            cuit = "30516588213";
            ptoVta = Punto_Venta;
            tipoCmp = Tipo_Comprobante;
            nroCmp = Numero;
            importe = Monto;
            moneda = "PES";
            ctz = 1;
            tipoDocRec = TipoDoc;
            nroDocRec = Doc;
            tipoCodAu = "E";
            codAut = CAE;

        }
    }


    public class QrHelper
    {

        public  System.Drawing.Image QR_TS(DateTime Fecha, int Punto_Venta, int Tipo_Comprobante, int Numero, decimal Monto, int TipoDoc, string Doc, string CAE)
        {

            var data = new Data_QR(Fecha, Punto_Venta, Tipo_Comprobante, Numero, Monto, TipoDoc, Doc, CAE);
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            string url = "https://www.afip.gob.ar/fe/qr/?p=" + base64;
            iTextSharp.text.pdf.BarcodeQRCode qrcode = new iTextSharp.text.pdf.BarcodeQRCode(url, 50, 50, null);

            iTextSharp.text.Image img1 = qrcode.GetImage();

            Document doc = new Document(PageSize.A4);
            string pdf2 = "qr";
            PdfWriter.GetInstance(doc, new FileStream(pdf2 + ".pdf", FileMode.Create));
            doc.Open();
           
            doc.Add(img1);
            doc.Close();


           return  ExtractImages(pdf2 + ".pdf").First();



            
            

            

        }

        private static List<System.Drawing.Image> ExtractImages(String PDFSourcePath)
        {
            List<System.Drawing.Image> ImgList = new List<System.Drawing.Image>();

            iTextSharp.text.pdf.RandomAccessFileOrArray RAFObj = null;
            iTextSharp.text.pdf.PdfReader PDFReaderObj = null;
            iTextSharp.text.pdf.PdfObject PDFObj = null;
            iTextSharp.text.pdf.PdfStream PDFStremObj = null;

            try
            {
                RAFObj = new iTextSharp.text.pdf.RandomAccessFileOrArray(PDFSourcePath);
                PDFReaderObj = new iTextSharp.text.pdf.PdfReader(RAFObj, null);

                for (int i = 0; i <= PDFReaderObj.XrefSize - 1; i++)
                {
                    PDFObj = PDFReaderObj.GetPdfObject(i);

                    if ((PDFObj != null) && PDFObj.IsStream())
                    {
                        PDFStremObj = (iTextSharp.text.pdf.PdfStream)PDFObj;
                        iTextSharp.text.pdf.PdfObject subtype = PDFStremObj.Get(iTextSharp.text.pdf.PdfName.SUBTYPE);

                        if ((subtype != null) && subtype.ToString() == iTextSharp.text.pdf.PdfName.IMAGE.ToString())
                        {
                            try
                            {

                                iTextSharp.text.pdf.parser.PdfImageObject PdfImageObj =
                         new iTextSharp.text.pdf.parser.PdfImageObject((iTextSharp.text.pdf.PRStream)PDFStremObj);

                                System.Drawing.Image ImgPDF = PdfImageObj.GetDrawingImage();


                                ImgList.Add(ImgPDF);

                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
                PDFReaderObj.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ImgList;
        }

       
        
  
        
    }
}
