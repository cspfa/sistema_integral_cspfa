using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;

namespace SOCIOS.Carnet
{

     public enum Tipo_Carnet
        { 
           TITULAR =1,
           INVITADO_PARTICIPAIVO =2,
           EMPLEADO =3,
           VITALCIO =4,
           CADETE   =5,
           FAMILIAR =6,
           SOCIO_INVITADO =7,
           ADHERENTE      =8,
            METROPOLITANA = 9
        
        }
    
    public class CarnetSocio
    {
        public iTextSharp.text.Image fondo;
        SOCIOS.Carnet.Utils uc = new Utils();
        public string rutaPdf;
        public System.Drawing.Image foto;




   

        public void GenerarCarnet(string Ingreso, string Socio, string Apellido, string Nombre, string Doc,string Afiliado_Beneficio,string CodigoBarra)
        {

            float height = fondo.Height;
            float width = fondo.Width;
            rutaPdf = rutaPdf + Apellido + "-" + Nombre + ".pdf";
            Document document = new Document(new iTextSharp.text.Rectangle(width, height));
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(rutaPdf, FileMode.Create));
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

            Font times25 = new Font(bfTimes, 30, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            BaseFont Arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
         

            iTextSharp.text.Image fotoItext = iTextSharp.text.Image.GetInstance(foto, System.Drawing.Imaging.ImageFormat.Jpeg);

            iTextSharp.text.Image Barra;
            document.Open();
            pdfWriter.Open();

            PdfContentByte pdfContentType = pdfWriter.DirectContent;
            fondo.SetAbsolutePosition(0, 0);
            fondo.Alignment = iTextSharp.text.Image.UNDERLYING;

            pdfContentType.SetFontAndSize(Arial, 45);

            document.Add(fondo);
            //FOTO
            fotoItext.SetAbsolutePosition(30, 250);
            // foto.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            // foto.ScaleToFit(300, 300);
            document.Add(fotoItext);

            pdfContentType.BeginText();


            // Fecha
            pdfContentType.SetTextMatrix(510,535);
            pdfContentType.ShowText(Ingreso);
            // Nro 
            pdfContentType.SetTextMatrix(800, 535);
            pdfContentType.ShowText(Socio);
      
           
            //Apellido
         
            pdfContentType.SetTextMatrix(400, 455);

            pdfContentType.ShowText(Apellido);
            //Nombre
          
      
            pdfContentType.SetTextMatrix(400, 355);

            pdfContentType.ShowText(Nombre);
            
            //DNI
            pdfContentType.SetTextMatrix(380, 255);
            pdfContentType.ShowText(SOCIOS.Carnet.Utils.CenterString(Doc));
            //TIPO
            pdfContentType.SetTextMatrix(870, 255);
            pdfContentType.ShowText("DNI");


            //Afiliado/Beneficio - todos menos empleado
          
                pdfContentType.SetTextMatrix(520, 165);
                pdfContentType.ShowText(Afiliado_Beneficio);
            


            // Codigo de barra

            Barra = iTextSharp.text.Image.GetInstance(SOCIOS.Utils.Barcode128(CodigoBarra), System.Drawing.Imaging.ImageFormat.Jpeg);
            Barra.ScaleToFit(930, 75);
            Barra.SetAbsolutePosition(230, 25);
            document.Add(Barra);


            pdfContentType.EndText();







            document.Close();

            System.Diagnostics.Process.Start(rutaPdf);


        }


    }


   public class CarnetTitular : CarnetSocio
    {
      
        public CarnetTitular(System.Drawing.Image pfoto)
        {
            fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//Carnet//titular.jpg");
            rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//CarnetTitular" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            foto = pfoto;

        }


       
    }

   public class CarnetMetropolitana : CarnetSocio
   {

       public CarnetMetropolitana(System.Drawing.Image pfoto)
       {
           fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//Carnet//metropolitana.jpg");
           rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//CarnetMetro" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
           foto = pfoto;

       }

       public void GenerarCarnet(string Ingreso, string Socio, string Apellido, string Nombre, string Doc, string Afiliado_Beneficio, string CodigoBarra)
       {

           float height = fondo.Height;
           float width = fondo.Width;
           rutaPdf = rutaPdf + Apellido + "-" + Nombre + ".pdf";
           Document document = new Document(new iTextSharp.text.Rectangle(width, height));
           PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(rutaPdf, FileMode.Create));
           BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

           Font times25 = new Font(bfTimes, 30, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

           BaseFont Arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);


           iTextSharp.text.Image fotoItext = iTextSharp.text.Image.GetInstance(foto, System.Drawing.Imaging.ImageFormat.Jpeg);

           iTextSharp.text.Image Barra;
           document.Open();
           pdfWriter.Open();

           PdfContentByte pdfContentType = pdfWriter.DirectContent;
           fondo.SetAbsolutePosition(0, 0);
           fondo.Alignment = iTextSharp.text.Image.UNDERLYING;

           pdfContentType.SetFontAndSize(Arial, 45);

           document.Add(fondo);
           

           //FOTO
           fotoItext.SetAbsolutePosition(10, 295);
                      
           // foto.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
           // foto.ScaleToFit(300, 300);
           document.Add(fotoItext);

           pdfContentType.BeginText();


           // Fecha
           pdfContentType.SetTextMatrix(505, 580);
           pdfContentType.ShowText(Ingreso);
           // Nro 
           pdfContentType.SetTextMatrix(800, 580);
           pdfContentType.ShowText(Socio);


           //Apellido

           pdfContentType.SetTextMatrix(400, 505);

           pdfContentType.ShowText(Apellido);
           //Nombre


           pdfContentType.SetTextMatrix(400, 410);

           pdfContentType.ShowText(Nombre);

           //DNI
           pdfContentType.SetTextMatrix(360, 300);
           pdfContentType.ShowText(SOCIOS.Carnet.Utils.CenterString(Doc));
           //TIPO
           pdfContentType.SetTextMatrix(870, 300);
           pdfContentType.ShowText("DNI");


           //Afiliado/Beneficio - todos menos empleado

           pdfContentType.SetTextMatrix(520, 165);
           pdfContentType.ShowText(Afiliado_Beneficio);



           // Codigo de barra

           Barra = iTextSharp.text.Image.GetInstance(SOCIOS.Utils.Barcode128(CodigoBarra), System.Drawing.Imaging.ImageFormat.Jpeg);
           Barra.ScaleToFit(930, 75);
           Barra.SetAbsolutePosition(230, 25);
           document.Add(Barra);


           pdfContentType.EndText();







           document.Close();

           System.Diagnostics.Process.Start(rutaPdf);


       }



   }


   public class CarnetFamiliar : CarnetSocio
   { 
       public CarnetFamiliar(System.Drawing.Image pfoto)
        { 
           fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//Carnet//familiar.jpg");
           rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//CarnetTitular" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
           foto = pfoto;

        }
   
   }

   public class CarnetEmpleado : CarnetSocio
   {

       public CarnetEmpleado(System.Drawing.Image pfoto)
       {
           fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//Carnet//empleado.jpg");
           rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//CarnetEmpleado" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
           foto = pfoto;

       }



       public void GenerarCarnet(string Ingreso, string Socio, string Apellido, string Nombre, string Doc, string Legajo, string CodigoBarra)
       {

           float height = fondo.Height;
           float width = fondo.Width;
           rutaPdf = rutaPdf + Apellido + "-" + Nombre + ".pdf";
           Document document = new Document(new iTextSharp.text.Rectangle(width, height));
           PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(rutaPdf, FileMode.Create));
           BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

           Font times25 = new Font(bfTimes, 30, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
         
           BaseFont Arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

           iTextSharp.text.Image fotoItext = iTextSharp.text.Image.GetInstance(foto, System.Drawing.Imaging.ImageFormat.Jpeg);

           iTextSharp.text.Image Barra;
           document.Open();
           pdfWriter.Open();

           PdfContentByte pdfContentType = pdfWriter.DirectContent;
           fondo.SetAbsolutePosition(0, 0);
           fondo.Alignment = iTextSharp.text.Image.UNDERLYING;

           pdfContentType.SetFontAndSize(Arial, 45);
           document.Add(fondo);
           //FOTO
           fotoItext.SetAbsolutePosition(30, 300);
           // foto.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
           // foto.ScaleToFit(300, 300);
           document.Add(fotoItext);

           pdfContentType.BeginText();


           // Fecha
           pdfContentType.SetTextMatrix(510, 560);
           pdfContentType.ShowText(Ingreso);
           // Nro 
           pdfContentType.SetTextMatrix(780, 560);
           pdfContentType.ShowText(Socio);


        

           //Apellido
          
               pdfContentType.SetTextMatrix(400, 480);
        

           pdfContentType.ShowText(Apellido);
           //Nombre
           pdfContentType.SetTextMatrix(400, 400);

           pdfContentType.ShowText(Nombre);

           //DNI
           pdfContentType.SetTextMatrix(400, 310);
           pdfContentType.ShowText(SOCIOS.Carnet.Utils.CenterString(Doc));
           //TIPO
           pdfContentType.SetTextMatrix(835, 310);
           pdfContentType.ShowText("DNI");


           //Afiliado/Beneficio - todos menos empleado



           // LEgajo -Solo Empleados
          
               pdfContentType.SetTextMatrix(600, 165);
               pdfContentType.ShowText(Legajo);
           

           // Codigo de barra

           Barra = iTextSharp.text.Image.GetInstance(SOCIOS.Utils.Barcode128(CodigoBarra), System.Drawing.Imaging.ImageFormat.Jpeg);
           Barra.ScaleToFit(930, 75);
           Barra.SetAbsolutePosition(230, 25);
           document.Add(Barra);


           pdfContentType.EndText();







           document.Close();

           System.Diagnostics.Process.Start(rutaPdf);


       }



   }

   public class CarnetVitalicio : CarnetSocio
   {

       public CarnetVitalicio(System.Drawing.Image pfoto)
       {
           fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//Carnet//vitalicio.jpg");
           rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//CarnetVitalicio" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
           foto = pfoto;

       }



   }

   public class CarnetInvitado : CarnetSocio
   {

       public CarnetInvitado(System.Drawing.Image pfoto)
       {
           fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//CARNET//invitado.jpg");
           rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//CarnetTitular" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
          
           foto = pfoto;

       }

       public void GenerarCarnet(string Ingreso, string Socio, string Apellido, string Nombre, string Doc, string Afiliado_Beneficio, string CodigoBarra, string OBS)
       {

           float height = fondo.Height;
           float width = fondo.Width;
           rutaPdf = rutaPdf + Apellido + "-" + Nombre + ".pdf";
           Document document = new Document(new iTextSharp.text.Rectangle(width, height));
           PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(rutaPdf, FileMode.Create));
           BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
           int topeX;

           Font times25 = new Font(bfTimes, 30, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

           BaseFont Arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

           iTextSharp.text.Image fotoItext = iTextSharp.text.Image.GetInstance(foto, System.Drawing.Imaging.ImageFormat.Jpeg);

           iTextSharp.text.Image Barra;
           document.Open();
           pdfWriter.Open();

           PdfContentByte pdfContentType = pdfWriter.DirectContent;
           fondo.SetAbsolutePosition(0, 0);
           fondo.Alignment = iTextSharp.text.Image.UNDERLYING;

           pdfContentType.SetFontAndSize(Arial, 45);
           document.Add(fondo);
           //FOTO
           fotoItext.SetAbsolutePosition(30, 350);
           // foto.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
           // foto.ScaleToFit(300, 300);
           document.Add(fotoItext);

           pdfContentType.BeginText();


           // Fecha
           pdfContentType.SetTextMatrix(520, 570);
           pdfContentType.ShowText(Ingreso);
           // Nro 
           pdfContentType.SetTextMatrix(800, 570);
           pdfContentType.ShowText(Socio);




           //Apellido

           pdfContentType.SetTextMatrix(400, 495);


           pdfContentType.ShowText(Apellido);
           //Nombre
           
           pdfContentType.SetTextMatrix(400, 400);


           pdfContentType.ShowText(Nombre);

           //DNI
           pdfContentType.SetTextMatrix(405, 295);
           pdfContentType.ShowText(SOCIOS.Carnet.Utils.CenterString(Doc));
           //TIPO
           pdfContentType.SetTextMatrix(860, 295);
           pdfContentType.ShowText("DNI");


           //Afiliado/Beneficio - todos menos empleado

           pdfContentType.SetTextMatrix(415, 170);
           pdfContentType.ShowText(Afiliado_Beneficio);
           // OBS
           pdfContentType.SetTextMatrix(415, 125);
           pdfContentType.ShowText(OBS);


           // Codigo de barra

           Barra = iTextSharp.text.Image.GetInstance(SOCIOS.Utils.Barcode128(CodigoBarra), System.Drawing.Imaging.ImageFormat.Jpeg);
           
           Barra.ScaleToFit(930, 75);
           Barra.SetAbsolutePosition(230, 25);
           document.Add(Barra);


           pdfContentType.EndText();







           document.Close();

           System.Diagnostics.Process.Start(rutaPdf);


       }



   }


   public class CarnetSocioInvitado : CarnetSocio
   {

       public CarnetSocioInvitado(System.Drawing.Image pfoto)
       {
           fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//CARNET//socio_invitado.jpg");
           rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//Carnet_Socio_Invitado" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

           foto = pfoto;

       }



       public void GenerarCarnet(string Ingreso, string Socio, string Apellido, string Nombre, string Doc, string Afiliado_Beneficio, string CodigoBarra)
       {

           float height = fondo.Height;
           float width = fondo.Width;
           rutaPdf = rutaPdf + Apellido + "-" + Nombre + ".pdf";
           Document document = new Document(new iTextSharp.text.Rectangle(width, height));
           PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(rutaPdf, FileMode.Create));
           BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
      

           Font times25 = new Font(bfTimes, 30, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

           BaseFont Arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

           iTextSharp.text.Image fotoItext = iTextSharp.text.Image.GetInstance(foto, System.Drawing.Imaging.ImageFormat.Jpeg);

           iTextSharp.text.Image Barra;
           document.Open();
           pdfWriter.Open();

           PdfContentByte pdfContentType = pdfWriter.DirectContent;
           fondo.SetAbsolutePosition(0, 0);
           fondo.Alignment = iTextSharp.text.Image.UNDERLYING;

           pdfContentType.SetFontAndSize(Arial, 45);
           document.Add(fondo);
           //FOTO
           fotoItext.SetAbsolutePosition(30, 280);
           // foto.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
           // foto.ScaleToFit(300, 300);
           document.Add(fotoItext);

           pdfContentType.BeginText();


           // Fecha
           pdfContentType.SetTextMatrix(520, 570);
           pdfContentType.ShowText(Ingreso);
           // Nro 
           pdfContentType.SetTextMatrix(800, 570);
           pdfContentType.ShowText(Socio);


          


           //Apellido

           pdfContentType.SetTextMatrix(400, 495);


           pdfContentType.ShowText(Apellido);
           //Nombre

           pdfContentType.SetTextMatrix(400, 400);


           pdfContentType.ShowText(Nombre);

           //DNI
           pdfContentType.SetTextMatrix(405, 295);
           pdfContentType.ShowText(SOCIOS.Carnet.Utils.CenterString(Doc));
           //TIPO
           pdfContentType.SetTextMatrix(860, 295);
           pdfContentType.ShowText("DNI");


           //Afiliado/Beneficio - todos menos empleado

           pdfContentType.SetTextMatrix(415, 170);
           pdfContentType.ShowText(Afiliado_Beneficio);
        


           // Codigo de barra

           Barra = iTextSharp.text.Image.GetInstance(SOCIOS.Utils.Barcode128(CodigoBarra), System.Drawing.Imaging.ImageFormat.Jpeg);
          
           Barra.ScaleToFit(930, 75);
           Barra.SetAbsolutePosition(230, 25);
           document.Add(Barra);


           pdfContentType.EndText();







           document.Close();

           System.Diagnostics.Process.Start(rutaPdf);


       }




   }


   public class CarnetAdherente : CarnetSocio
   {

       public CarnetAdherente(System.Drawing.Image pfoto)
       {
           fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//CARNET//adherente.jpg");
           rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//CarnetAdherente" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();

           foto = pfoto;

       }





   }

   public class CarnetCadete : CarnetSocio
   {

       public CarnetCadete(System.Drawing.Image pfoto)
       {
           fondo = iTextSharp.text.Image.GetInstance("C://CSPFA_SOCIOS//Carnet//Cadete.jpg");
           rutaPdf = "C://CSPFA_SOCIOS//TMP_CARNET//CarnetCadete" + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
           foto = pfoto;

       }

       public void GenerarCarnet(string Ingreso, string Socio, string Apellido, string Nombre, string Doc, string Afiliado_Beneficio, string CodigoBarra,string Vencimiento)
       {

           float height = fondo.Height;
           float width = fondo.Width;
           rutaPdf = rutaPdf + Apellido + "-" + Nombre + ".pdf";
           Document document = new Document(new iTextSharp.text.Rectangle(width, height));
           PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(rutaPdf, FileMode.Create));
           BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
         

           Font times25 = new Font(bfTimes, 30, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

           BaseFont Arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

           iTextSharp.text.Image fotoItext = iTextSharp.text.Image.GetInstance(foto, System.Drawing.Imaging.ImageFormat.Jpeg);

           iTextSharp.text.Image Barra;
           document.Open();
           pdfWriter.Open();

           PdfContentByte pdfContentType = pdfWriter.DirectContent;
           fondo.SetAbsolutePosition(0, 0);
           fondo.Alignment = iTextSharp.text.Image.UNDERLYING;

           pdfContentType.SetFontAndSize(Arial, 45);
           document.Add(fondo);
           //FOTO
           fotoItext.SetAbsolutePosition(30, 250);
           // foto.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
           // foto.ScaleToFit(300, 300);
           document.Add(fotoItext);

           pdfContentType.BeginText();


           // Fecha
           pdfContentType.SetTextMatrix(520, 550);
           pdfContentType.ShowText(Ingreso);
           // Nro 
           pdfContentType.SetTextMatrix(800, 550);
           pdfContentType.ShowText(Socio);

              


           //Apellido
         
               pdfContentType.SetTextMatrix(400, 475);
         

           pdfContentType.ShowText(Apellido);
           //Nombre
              pdfContentType.SetTextMatrix(400, 375);
         

           pdfContentType.ShowText(Nombre);

           //DNI
           pdfContentType.SetTextMatrix(440, 275);
           pdfContentType.ShowText(SOCIOS.Carnet.Utils.CenterString(Doc));
           //TIPO
           pdfContentType.SetTextMatrix(870, 275);
           pdfContentType.ShowText("DNI");


           //Afiliado/Beneficio - todos menos empleado

           pdfContentType.SetTextMatrix(570, 185);
           pdfContentType.ShowText(Afiliado_Beneficio);
           // Vencimiento
           pdfContentType.SetTextMatrix(570, 140);
           pdfContentType.ShowText(Vencimiento);


           // Codigo de barra

           Barra = iTextSharp.text.Image.GetInstance(SOCIOS.Utils.Barcode128(CodigoBarra), System.Drawing.Imaging.ImageFormat.Jpeg);
          
           Barra.ScaleToFit(930, 75);
           Barra.SetAbsolutePosition(230, 25);
           document.Add(Barra);


           pdfContentType.EndText();







           document.Close();

           System.Diagnostics.Process.Start(rutaPdf);


       }



   }



   public class GeneradorCarnet
   {
       CarnetTitular   titular;
       CarnetVitalicio vitalicio;
       CarnetEmpleado  empleado;
       CarnetInvitado  invitado;
       CarnetCadete    cadete;
       CarnetFamiliar familiar;
       CarnetAdherente adherente;
       CarnetSocioInvitado socioInvitado;
       CarnetMetropolitana carnetMetropolitana;

       public GeneradorCarnet(int pModo,System.Drawing.Image pfoto)
       {
           if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.TITULAR)
               titular = new CarnetTitular(pfoto);
           else if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.INVITADO_PARTICIPAIVO)
               invitado = new CarnetInvitado(pfoto);
           else if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.EMPLEADO)
               empleado = new CarnetEmpleado(pfoto);
           else if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.VITALCIO)
               vitalicio = new CarnetVitalicio(pfoto);
           else if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.CADETE)
               cadete = new CarnetCadete(pfoto);
           else if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.FAMILIAR)
               familiar = new CarnetFamiliar(pfoto);
           else if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.SOCIO_INVITADO)
               socioInvitado = new CarnetSocioInvitado(pfoto);
           else if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.ADHERENTE)
               adherente = new CarnetAdherente(pfoto);
           else if (pModo == (int)SOCIOS.Carnet.Tipo_Carnet.METROPOLITANA)
               carnetMetropolitana = new CarnetMetropolitana(pfoto);


       
       }

       public bool GenerarCarnet(string Ingreso, string Socio, string Apellido, string Nombre, string Doc, string Afiliado_Beneficio, string CodigoBarra,string Legajo,string Vencimiento,string OBS)
       {

           try
           {

               bool Metro = false;
               if (VGlobales.vp_Depuracion == "17" || VGlobales.vp_Depuracion == "017")
                   Metro = true;


               if (Metro)
               {
                   carnetMetropolitana.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra);
               }
               else
               {

                   if (titular != null)
                       titular.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra);
                   else if (invitado != null)
                       invitado.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra, OBS);
                   else if (empleado != null)
                       empleado.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Legajo, CodigoBarra);
                   else if (vitalicio != null)
                       vitalicio.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra);
                   else if (cadete != null)
                       cadete.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra, Vencimiento);
                   else if (familiar != null)
                       familiar.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra);
                   else if (adherente != null)
                       adherente.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra);
                   else if (socioInvitado != null)
                       socioInvitado.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra);
                   else
                       carnetMetropolitana.GenerarCarnet(Ingreso, Socio, Apellido, Nombre, Doc, Afiliado_Beneficio, CodigoBarra);
               }
               return true;

           }
           catch (Exception ex)
           {
               return false;
           }
       
       }



   
   }
}
