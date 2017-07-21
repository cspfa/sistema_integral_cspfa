using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using System.IO;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using System.IO;

namespace SOCIOS.Carnet
{
    public class Utils
    {
        bo dlog = new bo();
        public static Image resizeImage(Image imgToResize, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode =
            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }
        public  static string CenterString(string par)
        {
            string stringToCenter = par;
            int totalLength = 30;

            string centeredString =
                 stringToCenter.PadLeft(((totalLength - stringToCenter.Length) / 2)
                                        + stringToCenter.Length)
                               .PadRight(totalLength);
            return centeredString;


        }
        public static  byte[] CodigoBarra(string Codigo)
        {
            Barcode128 code128 = new Barcode128();
            code128.CodeType = Barcode.CODE128;
            code128.ChecksumText = true;
            code128.GenerateChecksum = true;
            code128.Code = Codigo;
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            System.Drawing.Image i = (System.Drawing.Image)bm;
            return imageToByteArray(i);


        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }


        public static string InicializarDirectorioCarnet(string DIR)
        {
            try
            {
              
                if (!(Directory.Exists("C://CSPFA_SOCIOS//TMP_CARNET//")))
                {
                    Directory.CreateDirectory("C://CSPFA_SOCIOS//TMP_CARNET//");

                }
                else
                {


                    foreach (string fichero in Directory.GetFiles("C://CSPFA_SOCIOS//TMP_CARNET//", "*.pdf"))
                    {
                        File.Delete(fichero);
                    }

                }

            }
            catch
            {
            }


            return DIR;



        }



        public Image Imagen_Nativa (int Nro, int Dep,string Tabla)

        {   int id_titular = (Nro * 1000) + Dep;


            string Query = "";
              
           
          if (Tabla.Contains("ADH"))
            {
                Query = "SELECT FOTO FROM ADHERENT_IMAGEN WHERE ID_TITULAR = " + id_titular.ToString();
            }
            else
            {
                Query = "SELECT FOTO FROM FAMILIAR_IMAGEN WHERE ID_TITULAR = " + id_titular.ToString();
            }



         
              DataRow[] foundRows;
              foundRows = dlog.BO_EjecutoDataTable(Query).Select();
              
            if (foundRows.Length > 0)
              {
                  Byte[] byteBLOBData1 = new Byte[0];
                  byteBLOBData1 = (Byte[])foundRows[0][0];
                  MemoryStream stmBLOBData1 = new MemoryStream(byteBLOBData1);
                  return System.Drawing.Image.FromStream(stmBLOBData1);
              }else
                  return SOCIOS.Properties.Resources.fotonodisponible;
          




        }
    }
}
