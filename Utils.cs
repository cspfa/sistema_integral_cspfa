using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using iTextSharp.text.pdf;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace SOCIOS
{
   public static class Utils
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width; int sourceHeight = imgToResize.Height; float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)size.Width / (float)sourceWidth); nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW) nPercent = nPercentH;
            else nPercent = nPercentW; int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic; g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }

        public static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        public static Image cropImage(Image img, RectangleF cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        public static Image crop(Image b, Rectangle r)
        {
            Bitmap nb = new Bitmap(b);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(b,r);


            return (Image)nb;

        }

       public static Image ImagenCarnet (Image foto)
        {
            Image fotoP = foto;
            string texto;
           //try
           //{

           //    if (fotoP.Width > fotoP.Height)
           //    {   //margen izquierdo
           //        //fotoP = Utils.cropImage(foto, new Rectangle(20, 0, fotoP.Width, fotoP.Height));
           //        //margen derecho
           //       // fotoP = Utils.cropImage(fotoP, new Rectangle(0, 0, fotoP.Width-10, fotoP.Height));
           //       fotoP = Zoom(fotoP);
           //    }
           //}
           //catch (Exception ex)

           //{
           //    texto = ex.Message;
           //}
          //tamanio carnet
            Image fotoTratada  =  resizeImage(fotoP,new Size(340,340));
            return fotoTratada;
       
       
         }

       public static Image Zoom(Image image)


       {

           int width = image.Width;
           int height = image.Height;
          

           RectangleF sourceRect = new RectangleF(0, 0, .85f * width,height);
           return cropImage(image, sourceRect);
       
       
       }
       public static Image Barcode(string Codigo)
       {
           Barcode39 code39 = new Barcode39();
   
           code39.CodeType = iTextSharp.text.pdf.Barcode.CODE128_RAW;
           code39.CodeType = iTextSharp.text.pdf.Barcode.CODE128_RAW;
           code39.ChecksumText = true;
           code39.GenerateChecksum = true;
           code39.Code = Codigo; 
           Bitmap bm = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White)); 
           return (Image) bm;
       }

       public static Image Barcode128(string Codigo)
       {
           Barcode39 code128 = new Barcode39();
          // code128.CodeType = iTextSharp.text.pdf.Barcode.;
           code128.CodeType = Barcode39.CODE128;
           code128.ChecksumText = true;
           code128.GenerateChecksum = true;
           code128.X = 7;
     
           code128.Code = Codigo;
           Bitmap bm = new Bitmap(code128.CreateDrawingImage(Color.Black, Color.White));
           return (Image)bm;
       }





    }

   public static class Config
   {   
       public static string getValor(string pRol,string pValor,int pNumero)
       {
           try
           {
               bo dlog = new bo();

               string VALOR = "";

               if (pNumero == 0)
                   VALOR = " VALOR ";

               if (pNumero == 1)
                   VALOR = "VALOR1 ";
               if (pNumero == 2)
                   VALOR = " VALOR2 ";
               if (pNumero == 3)
                   VALOR = " VALOR3 ";

               string Query = "SELECT " + VALOR + " as  VALOR FROM CONFIG WHERE PARAM ='" + pValor + "'";
               if (pRol.Length ==0)
                  if (pRol != "SISTEMAS" )
                     Query = Query + " AND ROL = '" + pRol + "'";
               
               if (dlog.BO_EjecutoDataTable(Query).Rows[0]["VALOR"].ToString().Trim().Length > 0)
                   return dlog.BO_EjecutoDataTable(Query).Rows[0]["VALOR"].ToString().Trim();
               else
                   throw new Exception("No se encuentra el valor para ese rol");
           } 
           catch (Exception ex)
           {
               return "0";
               //throw new Exception(ex.Message);
           }
       }
   }


   public class Encrypt

   { 
   
   
   
   }

   public class Mailer
   {
       private string Remitente, Usr, Pass, Server;
       
       public Mailer()
       {
           Usr       = Config.getValor("SISTEMAS", "MAIL", 0);
           Pass      = Config.getValor("SISTEMAS", "MAIL", 1);
           Server    = Config.getValor("SISTEMAS", "MAIL", 2);
       }

       public void EnvioMail(string mailAEnviar,string Asunto,string Mensaje)
       {
           try
           {
               MailMessage mail = new MailMessage();
               
               if (mailAEnviar.Contains(";"))
               {
                   string[] direcciones = mailAEnviar.Split(';');

                   foreach (string dir in direcciones)
                   {
                       mail.To.Add(new System.Net.Mail.MailAddress(dir));
                   }
               }
               else
                 mail.To.Add(mailAEnviar);
               
               MailAddress emisor = new MailAddress(Usr);
               mail.From = emisor;
               mail.IsBodyHtml = true;
               mail.Body = Mensaje;
               mail.Subject = Asunto;
               SmtpClient smtpclient = new SmtpClient(Server, 25);
               NetworkCredential credencial = new NetworkCredential(Usr, Pass);
               smtpclient.Credentials = credencial;
               smtpclient.EnableSsl = true;
               smtpclient.Send(mail);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }
   }

   //Clases para Impresion de RDLC Directa 
   public class ReportPrintDocument : PrintDocument
   {
       private PageSettings m_pageSettings;
       private int m_currentPage;
       private List<Stream> m_pages = new List<Stream>();

       public ReportPrintDocument(ServerReport serverReport)
           : this((Report)serverReport)
       {
           RenderAllServerReportPages(serverReport);
       }

       public ReportPrintDocument(LocalReport localReport)
           : this((Report)localReport)
       {
           RenderAllLocalReportPages(localReport);
       }

       public ReportPrintDocument(Report report)
       {
           // Set the page settings to the default defined in the report
           ReportPageSettings reportPageSettings = report.GetDefaultPageSettings();

           // The page settings object will use the default printer unless
           // PageSettings.PrinterSettings is changed.  This assumes there
           // is a default printer.
           m_pageSettings = new PageSettings();
           m_pageSettings.PaperSize = reportPageSettings.PaperSize;
           m_pageSettings.Margins = reportPageSettings.Margins;
       }

       protected override void Dispose(bool disposing)
       {
           base.Dispose(disposing);

           if (disposing)
           {
               foreach (Stream s in m_pages)
               {
                   s.Dispose();
               }

               m_pages.Clear();
           }
       }

       protected override void OnBeginPrint(PrintEventArgs e)
       {
           base.OnBeginPrint(e);

           m_currentPage = 0;
       }

       protected override void OnPrintPage(PrintPageEventArgs e)
       {
           base.OnPrintPage(e);

           Stream pageToPrint = m_pages[m_currentPage];
           pageToPrint.Position = 0;

           // Load each page into a Metafile to draw it.
           using (Metafile pageMetaFile = new Metafile(pageToPrint))
           {
               Rectangle adjustedRect = new Rectangle(
                       e.PageBounds.Left - (int)e.PageSettings.HardMarginX,
                       e.PageBounds.Top - (int)e.PageSettings.HardMarginY,
                       e.PageBounds.Width,
                       e.PageBounds.Height);

               // Draw a white background for the report
               e.Graphics.FillRectangle(Brushes.White, adjustedRect);

               // Draw the report content
               e.Graphics.DrawImage(pageMetaFile, adjustedRect);

               // Prepare for next page.  Make sure we haven't hit the end.
               m_currentPage++;
               e.HasMorePages = m_currentPage < m_pages.Count;
           }
       }

       protected override void OnQueryPageSettings(QueryPageSettingsEventArgs e)
       {
           e.PageSettings = (PageSettings)m_pageSettings.Clone();
       }

       private void RenderAllServerReportPages(ServerReport serverReport)
       {
           string deviceInfo = CreateEMFDeviceInfo();

           // Generating Image renderer pages one at a time can be expensive.  In order
           // to generate page 2, the server would need to recalculate page 1 and throw it
           // away.  Using PersistStreams causes the server to generate all the pages in
           // the background but return as soon as page 1 is complete.
           NameValueCollection firstPageParameters = new NameValueCollection();
           firstPageParameters.Add("rs:PersistStreams", "True");

           // GetNextStream returns the next page in the sequence from the background process
           // started by PersistStreams.
           NameValueCollection nonFirstPageParameters = new NameValueCollection();
           nonFirstPageParameters.Add("rs:GetNextStream", "True");

           string mimeType;
           string fileExtension;
           Stream pageStream = serverReport.Render("IMAGE", deviceInfo, firstPageParameters, out mimeType, out fileExtension);

           // The server returns an empty stream when moving beyond the last page.
           while (pageStream.Length > 0)
           {
               m_pages.Add(pageStream);

               pageStream = serverReport.Render("IMAGE", deviceInfo, nonFirstPageParameters, out mimeType, out fileExtension);
           }
       }

       private void RenderAllLocalReportPages(LocalReport localReport)
       {
           string deviceInfo = CreateEMFDeviceInfo();

           Warning[] warnings;
           localReport.Render("IMAGE", deviceInfo, LocalReportCreateStreamCallback, out warnings);
       }

       private Stream LocalReportCreateStreamCallback(
           string name,
           string extension,
           Encoding encoding,
           string mimeType,
           bool willSeek)
       {
           MemoryStream stream = new MemoryStream();
           m_pages.Add(stream);

           return stream;
       }

       private string CreateEMFDeviceInfo()
       {
           PaperSize paperSize = m_pageSettings.PaperSize;
           Margins margins = m_pageSettings.Margins;

           // The device info string defines the page range to print as well as the size of the page.
           // A start and end page of 0 means generate all pages.
           return string.Format(
               CultureInfo.InvariantCulture,
               "<DeviceInfo><OutputFormat>emf</OutputFormat><StartPage>0</StartPage><EndPage>0</EndPage><MarginTop>{0}</MarginTop><MarginLeft>{1}</MarginLeft><MarginRight>{2}</MarginRight><MarginBottom>{3}</MarginBottom><PageHeight>{4}</PageHeight><PageWidth>{5}</PageWidth></DeviceInfo>",
               ToInches(margins.Top),
               ToInches(margins.Left),
               ToInches(margins.Right),
               ToInches(margins.Bottom),
               ToInches(paperSize.Height),
               ToInches(paperSize.Width));
       }

       private static string ToInches(int hundrethsOfInch)
       {
           double inches = hundrethsOfInch / 100.0;
           return inches.ToString(CultureInfo.InvariantCulture) + "in";
       }

      
           
       
   }

   public static class FECHAS

   {
       public static string fechaUSA(DateTime fecha)
       {
           string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");

           return Fecha;


       }
   
   }
}
