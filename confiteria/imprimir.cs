using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using iTextSharp.text.pdf;
using SOCIOS;

namespace Confiteria
{
    class imprimir
    {
        bo dlog = new bo();

        private DataSet COMANDA { get; set; }
        private DataSet SOLICITUD { get; set; }
        private DataSet ITEMS { get; set; }
        private string TIPO_COMANDA { get; set; }
        private string ORIGINAL_DUPLICADO { get; set; }

        public void imprimirComanda(DataSet I, DataSet C, string T)
        {
            COMANDA = C;
            ITEMS = I;
            TIPO_COMANDA = T;
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PaperSize psize = new PaperSize();
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_Print);
            DialogResult result = pd.ShowDialog();

            if (result == DialogResult.OK)
            {
                pdoc.Print();
            }
        }

        public void imprimirSolicitud(DataSet S)
        {
            SOLICITUD = S;
            PrintDialog pd = new PrintDialog();
            PrintDocument psol = new PrintDocument();
            PaperSize psize = new PaperSize();
            pd.Document = psol;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            psol.PrintPage += new PrintPageEventHandler(psol_Print);
            DialogResult result = pd.ShowDialog();

            if (result == DialogResult.OK)
            {
                ORIGINAL_DUPLICADO = "ORIGINAL";
                psol.Print();
                ORIGINAL_DUPLICADO = "DUPLICADO";
                psol.Print();
            }
        }

        public void imprimirSolicitudEspecial(DataSet S)
        {
            SOLICITUD = S;
            PrintDialog pd = new PrintDialog();
            PrintDocument psolesp = new PrintDocument();
            PaperSize psize = new PaperSize();
            pd.Document = psolesp;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            psolesp.PrintPage += new PrintPageEventHandler(psolesp_Print);
            DialogResult result = pd.ShowDialog();

            if (result == DialogResult.OK)
            {
                ORIGINAL_DUPLICADO = "ORIGINAL";
                psolesp.Print();
                ORIGINAL_DUPLICADO = "DUPLICADO";
                psolesp.Print();
            }
        }

        public void psolesp_Print(object sender, PrintPageEventArgs e)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.X = 20;
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 12);
            Font courier_med = new Font("FontA1x1", 9);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;

            foreach (DataRow row in SOLICITUD.Tables[0].Rows)
            {
                string ID = row[0].ToString().Trim();
                string FECHA = row[1].ToString().Substring(0, 9).Trim();
                string NOM_SOC = row[2].ToString().Trim();
                string IMPORTE = string.Format("{0:n}", Convert.ToDecimal(row[3].ToString())).Trim();
                string DESTINO = row[4].ToString().Trim();
                string LEG_PER = row[5].ToString().Trim();
                string AFILIADO = row[6].ToString().Trim();
                string BENEFICIO = row[7].ToString().Trim();
                string A_DTO = row[8].ToString().Substring(0, 10).Trim();
                string BORRADOR = row[12].ToString().Trim();
                string CONSUME = row[13].ToString().Trim();
                string IMPORTE_DESCONTADO = row[14].ToString().Trim();

                graphics.DrawString("SOLICITUD DE DESCUENTO", courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("NUMERO " + ID + " - " + ORIGINAL_DUPLICADO, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(FECHA, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("BORRADOR " + BORRADOR, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("-----------------------------------------------------------------------------", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("VALOR CONSUMICION $ " + IMPORTE, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("A DESCONTAR $ " + IMPORTE_DESCONTADO, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("-----------------------------------------------------------------------------", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("APELLIDO Y NOMBRE", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(NOM_SOC, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                if (CONSUME != "")
                {
                    graphics.DrawString("CONSUME", courier_med, black, startX, startY + Offset);
                    Offset = Offset + 20;

                    graphics.DrawString(CONSUME, courier_med, black, startX, startY + Offset);
                    Offset = Offset + 20;

                    graphics.DrawString("-----------------------------------------------------------------------------", courier_med, black, startX, startY + Offset);
                }
                
                Offset = Offset + 80;

                graphics.DrawString("____________________________________________________________________________", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("FIRMA", courier_med, black, startX, startY + Offset);
                Offset = Offset + 40;

                graphics.DrawString(".", courier_med, black, startX, startY + Offset);
            }
        }

        public void psol_Print(object sender, PrintPageEventArgs e)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.X = 20;
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 12);
            Font courier_med = new Font("FontA1x1", 9);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;

            foreach (DataRow row in SOLICITUD.Tables[0].Rows)
            {
                string ID = row[0].ToString();
                string FECHA = row[1].ToString().Substring(0, 9);
                string NOM_SOC = row[2].ToString();
                string IMPORTE = string.Format("{0:n}", Convert.ToDecimal(row[3].ToString()));
                string DESTINO = row[4].ToString();
                string LEG_PER = row[5].ToString();
                string AFILIADO = row[6].ToString();
                string BENEFICIO = row[7].ToString();
                string A_DTO = row[8].ToString().Substring(0, 10);
                string BORRADOR = row[12].ToString();
                string CONSUME = row[13].ToString();

                graphics.DrawString("SOLICITUD DE DESCUENTO", courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("NUMERO " + ID + " - " + ORIGINAL_DUPLICADO, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(FECHA, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("BORRADOR " + BORRADOR, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("-----------------------------------------------------------------------------", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("VALOR CONSUMICION $ " + IMPORTE, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("-----------------------------------------------------------------------------", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("APELLIDO Y NOMBRE", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(NOM_SOC, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("CONSUME", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(CONSUME, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("DESTINO:", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(DESTINO, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("LP: " + LEG_PER, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("AFILIADO: " + AFILIADO + " - BENEFICIO: " + BENEFICIO, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("FECHA A DTO: " + A_DTO, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("-----------------------------------------------------------------------------", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("AUTORIZO AL CSPFA A DESCONTAR EL VALOR DE", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("ESTA SOLICITUD DE MIS HABERES", courier_med, black, startX, startY + Offset);
                Offset = Offset + 80;

                graphics.DrawString("____________________________________________________________________________", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString("FIRMA", courier_med, black, startX, startY + Offset);
                Offset = Offset + 40;

                graphics.DrawString(".", courier_med, black, startX, startY + Offset);
            }
        }

        public void pdoc_Print(object sender, PrintPageEventArgs e)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.X = 40;
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 9);
            Font courier_med = new Font("FontA1x1", 9);
            Font courier_sma = new Font("FontA1x1", 8);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;
            string TOTAL = "";
            string A_PAGAR = "";
            string DESC = "";
            graphics.DrawString("CONFITERÍA CSPFA", courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;

            foreach (DataRow row in COMANDA.Tables[0].Rows)
            {
                code39.Code = "CO" + row[0].ToString().Trim();
                Bitmap bm = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White));
                graphics.DrawString(row[1].ToString(), courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("COMANDA " + row[0].ToString(), courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("BORRADOR " + row[16].ToString(), courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("MESA " + row[2].ToString(), courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;

                if (TIPO_COMANDA == "SOCIO")
                {
                    graphics.DrawString("SOCIO " + row[5].ToString() + " " + row[6].ToString() + " " + row[7].ToString(), courier_big, black, startX, startY + Offset);
                    Offset = Offset + 20;

                    if (row[18].ToString() != "")
                    {
                        TOTAL = "TOTAL $ " + row[4].ToString();
                        A_PAGAR = "A PAGAR $ " + row[18].ToString();
                        DESC = "DESC % " + row[17].ToString();
                    }
                    else
                    {
                        TOTAL = "TOTAL $ " + row[4].ToString();
                    }

                    graphics.DrawString(row[14].ToString(), courier_big, black, startX, startY + Offset);
                    Offset = Offset + 20;
                }
            }
            
            foreach (DataRow row in ITEMS.Tables[0].Rows)
            {
                string CANTIDAD = row[1].ToString();
                string ITEM = row[5].ToString();
                string ITEM_FINAL = "";
                string SUBTOTAL = "";
                string VALOR = row[3].ToString();
                int LARGO = ITEM.Length;
                string OBSERVACION = row[9].ToString();

                if (LARGO >= 40)
                {
                    ITEM = ITEM.Substring(0, 40);
                }

                if (TIPO_COMANDA == "SOCIO")
                {
                    SUBTOTAL = "$ " + row[4].ToString();
                    ITEM_FINAL = CANTIDAD + " - $ " + VALOR + " - " + ITEM;
                }
                else
                {
                    ITEM_FINAL = CANTIDAD + " " + ITEM;
                }

                graphics.DrawString(ITEM_FINAL, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                if (TIPO_COMANDA == "COCINA")
                {
                    if (OBSERVACION.Length > 1)
                    {
                        graphics.DrawString(OBSERVACION, courier_sma, black, startX, startY + Offset);
                        Offset = Offset + 20;
                    }
                }
            }
            
            if (TIPO_COMANDA == "SOCIO")
            {
                graphics.DrawString(TOTAL, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(A_PAGAR, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(DESC, courier_big, black, startX, startY + Offset);
                Offset = Offset + 40;

                Bitmap bm2 = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White));
                graphics.DrawImage(bm2, startX, startY + Offset);
                Offset = Offset + 40;
            }

            graphics.DrawString("...", courier_med, black, startX, startY + Offset);
            Offset = Offset + 20;
        }
    }
}
