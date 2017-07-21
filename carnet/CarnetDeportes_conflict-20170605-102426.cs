using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;




namespace SOCIOS.deportes
{
    class serviceCarnet
    {

        public void GenerarCarnet(string Ingreso,string Nombre,String Apellido, string Doc,int ID,string Categoria_social ,int NRO_SOC,int NRO_DEP,int BARRA,string Cod_Dto,Image foto,string CodigoBarra,int Numerador,string CUOTA,string ROL)

        {


        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//Carnet//deportes.jpg");
        float height = image.Height;
        float width = image.Width;
        string rutaPdf="C://CSPFA_SOCIOS//Carnet-"+ Apellido+"-" + Nombre +"-"+ ID.ToString()+"-" + Numerador.ToString() + ".pdf";
        Document document = new Document( new iTextSharp.text.Rectangle(width,height));
        PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(rutaPdf, FileMode.Create));
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
    
        Font times25 = new Font(bfTimes, 30, Font.BOLD,iTextSharp.text.BaseColor.BLACK);

        BaseFont Arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

             

        iTextSharp.text.Image Barra;
        document.Open();
        pdfWriter.Open();
        
        PdfContentByte pdfContentType = pdfWriter.DirectContent;
        image.SetAbsolutePosition(0, 0);
        image.Alignment=iTextSharp.text.Image.UNDERLYING;

        pdfContentType.SetFontAndSize(Arial, 30);
        document.Add(image);
        //FOTO
        foto.SetAbsolutePosition(15, 95);
       // foto.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
       // foto.ScaleToFit(300, 300);
        document.Add(foto);
        
       pdfContentType.BeginText();


        // Fecha
       //pdfContentType.SetTextMatrix(520,550);
       //pdfContentType.ShowText(Ingreso);
       // Nro 
       pdfContentType.SetTextMatrix(730, 550);
       string nro = NRO_SOC.ToString("0000") + "/" + BARRA.ToString("00");
       pdfContentType.ShowText(nro );
       //Apellido
       pdfContentType.SetTextMatrix(465,485);
       pdfContentType.ShowText(this.CenterString(Apellido));
       //Nombre
       pdfContentType.SetTextMatrix(465, 430);
       pdfContentType.ShowText(this.CenterString(Nombre));
       //DNI
       pdfContentType.SetTextMatrix(465, 320);
       pdfContentType.ShowText(this.CenterString(Doc));
       
       //TIPO
    
       pdfContentType.SetTextMatrix(550, 230);
       pdfContentType.ShowText(this.CenterString(ROL));
       
      
       // SOCIOS.deportes.admActividades actividades = new deportes.admActividades(ID,Categoria_social, NRO_SOC, NRO_DEP, BARRA, Cod_Dto);
      // string Actividad= actividades.UltimaActividad();
      // pdfContentType.SetTextMatrix(350, 170);
      // pdfContentType.ShowText(Actividad);
       
       // Codigo de barra
      string Letra="";
            if (BARRA ==0)
            { Letra ="T";
            }else
                Letra = "F";

       CodigoBarra = Letra + NRO_SOC.ToString().PadLeft(6, '0') + NRO_DEP.ToString().PadLeft(3,'0') + BARRA.ToString("00")  ;
       Barra = iTextSharp.text.Image.GetInstance(SOCIOS.Utils.Barcode(CodigoBarra), System.Drawing.Imaging.ImageFormat.Jpeg);
       Barra.ScaleToFit(930, 80);
       Barra.SetAbsolutePosition(280, 15);
       document.Add(Barra);
      
        
       pdfContentType.EndText();
      






        document.Close();

        System.Diagnostics.Process.Start(rutaPdf);

        
        
        }


       

        private string CenterString(string par)


        {
            string stringToCenter = par;
            int totalLength = 30;

            string centeredString =
                 stringToCenter.PadLeft(((totalLength - stringToCenter.Length) / 2)
                                        + stringToCenter.Length)
                               .PadRight(totalLength);
            return centeredString;

        
        }
        private byte[] CodigoBarra(string Codigo)

        {
            Barcode128 code128 = new Barcode128();
            code128.CodeType = Barcode.CODE128;
            code128.ChecksumText = true;
            code128.GenerateChecksum = true;
            code128.Code = Codigo;
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            System.Drawing.Image i = (System.Drawing.Image)bm;
            return  this.imageToByteArray(i);
        
        
        }
        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        public string GenerarCarnet()
      {

          iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("carnet.png");
          float height = image.Height;
          float width = image.Width;

         // Document document = new Document(new Rectangle(width, height));
         // PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("Carnet.pdf",FileMode.Create));

          //document.Open();
          //pdfWriter.Open();

          //PdfContentByte pdfContentType = pdfWriter.DirectContent;

          //int y = 170;
          //int x = 150;
          
         
          //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
          
          //pdfContentType.BeginText();

          //try
          //{
          //    pdfContentType.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Nombre", x, y, 0);
          //}
          //catch (Exception ex)

          //{ 
          
          
          //}

          //pdfContentType.EndText();

          //document.Close();  

        return "";
      }

    private void LlenarDato(int x, int y, PdfContentByte pdfContentByte, Document document)

    { 
    
    
    }

    }
}
