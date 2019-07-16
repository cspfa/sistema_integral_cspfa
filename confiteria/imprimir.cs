using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using iTextSharp.text.pdf;
using SOCIOS;

namespace Confiteria
{
    class imprimir
    {
        bo dlog = new bo();
        Utils utils = new Utils();

        private DataSet COMANDA { get; set; }
        private DataSet SOLICITUD { get; set; }
        private DataSet ITEMS { get; set; }
        private string TIPO_COMANDA { get; set; }
        private string ORIGINAL_DUPLICADO { get; set; }
        private string BARCODE { get; set; }
        private string NOMBRE { get; set; }

        public void printBarCodeConfiteria(string N, string BC)
        {
            NOMBRE = N;
            BARCODE = BC;
            string IMPRESORA = String.Empty;
            string IMPRESORA_INI = utils.getIniPrinter();

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (strPrinter == IMPRESORA_INI)
                    IMPRESORA = IMPRESORA_INI;
            }

            PrintDocument pbar = new PrintDocument();
            PaperSize psize = new PaperSize();
            pbar.PrintPage += new PrintPageEventHandler(pbar_Print);
            pbar.PrinterSettings.PrinterName = IMPRESORA;
            pbar.Print();
        }

        public void imprimirComanda(DataSet I, DataSet C, string T)
        {
            COMANDA = C;
            ITEMS = I;
            TIPO_COMANDA = T;
            string IMPRESORA = String.Empty;
            string IMPRESORA_INI = utils.getIniPrinter();

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if(strPrinter == IMPRESORA_INI)
                    IMPRESORA = IMPRESORA_INI;
            }

            PrintDocument pdoc = new PrintDocument();
            PaperSize psize = new PaperSize();
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_Print);
            pdoc.PrinterSettings.PrinterName = IMPRESORA;
            pdoc.Print();
        }

        public void imprimirSolicitud(DataSet S)
        {
            SOLICITUD = S;
            string IMPRESORA = String.Empty;
            string IMPRESORA_INI = utils.getIniPrinter();

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (strPrinter == IMPRESORA_INI)
                    IMPRESORA = IMPRESORA_INI;
            }

            PrintDocument psol = new PrintDocument();
            PaperSize psize = new PaperSize();
            psol.PrintPage += new PrintPageEventHandler(psol_Print);
            psol.PrinterSettings.PrinterName = IMPRESORA;
            ORIGINAL_DUPLICADO = "ORIGINAL";
            psol.Print();
            ORIGINAL_DUPLICADO = "DUPLICADO";
            psol.Print();
        }

        public void imprimirSolicitudEspecial(DataSet S)
        {
            SOLICITUD = S;
            string IMPRESORA = String.Empty;
            string IMPRESORA_INI = utils.getIniPrinter();

            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (strPrinter == IMPRESORA_INI)
                    IMPRESORA = IMPRESORA_INI;
            }

            PrintDocument psolesp = new PrintDocument();
            PaperSize psize = new PaperSize();
            psolesp.PrintPage += new PrintPageEventHandler(psolesp_Print);
            psolesp.PrinterSettings.PrinterName = IMPRESORA;
            ORIGINAL_DUPLICADO = "ORIGINAL";
            psolesp.Print();
            ORIGINAL_DUPLICADO = "DUPLICADO";
            psolesp.Print();
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
            
            if(VGlobales.vp_role != "CONFITERIA")
                graphics.DrawString("CONFITERÍA " + VGlobales.vp_role, courier_big, black, startX, startY + Offset);
            else
                graphics.DrawString("CONFITERÍA CSPFA", courier_big, black, startX, startY + Offset);

            Offset = Offset + 20;

            foreach (DataRow row in COMANDA.Tables[0].Rows)
            {
                code39.Code = "CO" + row[19].ToString().Trim();
                Bitmap bm = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White));

                graphics.DrawString("HORA DEL PEDIDO ", courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(row[1].ToString(), courier_big, black, startX, startY + Offset);

                if (VGlobales.vp_role == "CPOCABA")
                {
                    Offset = Offset + 20;
                    graphics.DrawString("HORA DE ENTREGA ", courier_big, black, startX, startY + Offset);
                    Offset = Offset + 20;
                    graphics.DrawString(row[20].ToString(), courier_big, black, startX, startY + Offset);
                }
                
                Offset = Offset + 20;
                graphics.DrawString("COMANDA " + row[19].ToString(), courier_big, black, startX, startY + Offset);
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

        public void pbar_Print(object sender, PrintPageEventArgs e)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.X = 20;
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 9);
            Font courier_med = new Font("FontA1x1", 9);
            Font courier_sma = new Font("FontA1x1", 7);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 10;
            int startY = 0;
            int Offset = 0;
            code39.Code = BARCODE;
            Bitmap bm = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White));

            Offset = Offset + 10;
            graphics.DrawString(NOMBRE, courier_sma, black, startX, startY + Offset);
            Offset = Offset + 15;
            graphics.DrawImage(bm, startX, startY + Offset);
            Offset = Offset + 30;
            graphics.DrawString(BARCODE, courier_sma, black, startX, startY + Offset);
        }
    }
}
