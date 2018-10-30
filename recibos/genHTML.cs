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

namespace SOCIOS
{
    class genHTML
    {
        bo dlog = new bo();
        public Font PrinterFont { get; set; }
        public string TextToPrint { get; set; }
        private string COD_DTO { get; set; }
        private string TITULO { get; set; }
        private string CRJP { get; set; }
        private string TIPO_RB { get; set; }
        private string[] DATOS_BR { get; set; }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private Bitmap createBarCode(string data)
        {
            Bitmap barCode = new Bitmap(1, 1);
            Font threeOfNine = new Font("Free 3 of 9", 34, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Graphics graphics = Graphics.FromImage(barCode);
            SizeF dataSize = graphics.MeasureString(data, threeOfNine);
            barCode = new Bitmap(barCode, dataSize.ToSize());
            graphics = Graphics.FromImage(barCode);
            graphics.Clear(Color.White);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            graphics.DrawString(data, threeOfNine, new SolidBrush(Color.Black), 0, 0);
            graphics.Flush();
            threeOfNine.Dispose();
            graphics.Dispose();
            return barCode;
        }

        private Bitmap createBarCode39(string data)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.Code = data;
            Bitmap bm = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White));
            return bm;
        }

        #region FORMULARIO SOLICITUD
        public void formularioSolicitud(string ADTO, string ORIGEN_ALTA, int PAR, int ORDEN, string IND, int AFI_BEN, int O, int A)
        {
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("dd-MM-yyyy");
            string origen = ORIGEN_ALTA.Substring(3, 3);
            string mes = ADTO.Substring(3, 2);
            string anio = ADTO.Substring(6, 4);

            string query = "SELECT APE_SOC, NOM_SOC, NUM_DOC, AAR, ACRJP2, NRO_SOC, LEG_PER FROM TITULAR WHERE 1=1";

            if (A == 1)
                query += " AND A_DTO = '" + anio + "/" + mes + "/01'";

            if (O == 1)
                query += " AND ORIGEN_ALTA = '" + origen + "'";

            if (AFI_BEN == 1 && IND != "")
                query += " AND AAR = " + IND.Substring(0, 1) + " AND ACRJP2 = " + IND.Substring(1, 6) + "";

            if (AFI_BEN == 2 && IND != "")
                query += " AND PCRJP1 = " + IND.Substring(0, 2) + " AND PCRJP2 = " + IND.Substring(2, 6) + " AND PCRJP3 = " + IND.Substring(8, 1) + "";

            query += " AND PAR = " + PAR + "";

            query += " AND F_BAJCI IS NULL";

            if (ORDEN == 1)
                query += " ORDER BY APE_SOC, NOM_SOC;";
            else
                query += " ORDER BY AAR, ACRJP2;";

            int CODIGO = 0;

            if (AFI_BEN == 1)
                CODIGO = 633;

            if (AFI_BEN == 2)
                CODIGO = 640;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            //MessageBox.Show(query);
            //Clipboard.SetDataObject(query);

            if (foundRows.Length > 0)
            {
                string html = "<html><meta charset='UTF-8'><body style='font-family:arial;'>";

                int x = 1;

                for (int i = 0; i <= foundRows.Length - 1; i++)
                {
                    html += "<table width='900' border='0' cellspacing='4'>";

                    html += "<tr><td colspan='3' align='center'>Circulo de Suboficiales de la Policia Federal Argentina <div>Asociaci&oacute;n Civil Fundada el 7 de Marzo de 1957 con Personer&iacute;a Jur&iacute;dica Otorgada el 26 de Mayo de 1958 <br/> CUIT: 30-51658821-3 </div> </td></tr>";

                    html += "<tr><td colspan='3'><div align='center' style='font-size:26px;font-weight:bold;'>AUTORIZACI&Oacute;N</div></td></tr>";

                    html += "<tr><td><div style='font-size:18px;font-weight:bold;text-decoration:underline;'>ALTA DESCUENTO</div></td><td>&nbsp;</td><td>FECHA: <strong>" + fecha_actual + "</strong></td></tr>";

                    html += "<tr><td>APELLIDO: <strong>" + foundRows[i][0] + "</strong></td><td>&nbsp;</td><td>NOMBRES: <strong>" + foundRows[i][1] + "</strong></td></tr>";

                    html += "<tr><td>DNI: <strong>" + foundRows[i][2] + "</strong></td><td>&nbsp;</td><td>AFILIADO. C.R.J Y P.F.A: <strong>" + foundRows[i][3] + "/" + foundRows[i][4] + "</strong></td></tr>";

                    html += "<tr><td>LP: <strong>" + foundRows[i][6] + "</strong></td><td>&nbsp;</td><td>NRO SOCIO: <strong>" + foundRows[i][5] + "</strong></td></tr>";

                    html += "<tr><td colspan='3' style='border:1px solid #333;padding:6px;'>Autorizo en este acto al CSPFA a efectuar el descuento mensual de la Cuota Societaria de mis Haberes seg&uacute;n detalle, firmando al pie de la presente en conformidad.-</td></tr>";

                    html += "<tr><td align='center' style='border:1px solid #CCC;'>CONCEPTO</td><td align='center' style='border:1px solid #CCC;'>COD.DTO.</td><td align='center' style='border:1px solid #CCC;'>HABERES</td></tr>";

                    html += "<tr><td align='center' style='border:1px solid #CCC;font-weight:bold;'>ALTA</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'>" + CODIGO + "</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'><strong>" + mes + "/" + anio + "</strong></td></tr>";

                    html += "<tr><td height='120'></td><td>&nbsp;</td><td></td></tr>";

                    html += "<tr><td valign='bottom' align='center' style='border-top:1px dashed #333;'>FIRMA DEL SOCIO TITULAR</td><td>&nbsp;</td><td valign='bottom' align='center' style='border-top:1px dashed #333;'>ACLARACI&Oacute;N</td></tr>";

                    html += "</table>";

                    html += "<br/><br/>";

                    html += "<div style='width:900px;height:1px;border-top:1px dashed #000;'></div>";

                    html += "<br/><br/>";

                    if (x != 3)
                    {
                        x++;
                    }
                    else
                    {
                        html += "<br style='page-break-after: always;' />";
                        x = 1;
                    }
                }

                html += "</body></html>";

                string fileName = "temp.html";
                StreamWriter writer = File.CreateText(fileName);
                writer.WriteLine(html);
                writer.Close();

                preHTML ph = new preHTML(html);
                ph.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron datos");
            }
        }
        #endregion

        #region CUOTAS TARJETAS
        public void cuotasTarjetas(string CUOTAS, string TARJETA, string IMPORTE, string IMPORTE_FINANCIADO, string VALOR_CUOTA, string VOUCHER)
        {
            string html = "<html><meta charset='UTF-8'><body>";
            html += "<table border='0' width='685' height='100' cellspacing='0' cellpadding='6' style='font-family:courier;border:1px solid #333;'>";
            html += "<tr style='font-size:16px;' align='center'>";
            html += "<td>TARJETA</td> <td>CUOTAS</td> <td>IMPORTE</td> <td>IMPORTE FINANCIADO</td> <td>VALOR CUOTA</td> <td>VOUCHER</td>";
            html += "</tr>";
            html += "<tr style='font-size:20px;' align='center'>";
            html += "<td>" + TARJETA + "</td> <td>" + CUOTAS + "</td> <td>" + IMPORTE + "</td> <td>" + IMPORTE_FINANCIADO + "</td> <td>" + VALOR_CUOTA + "</td> <td>" + VOUCHER + "</td>";
            html += "</tr>";
            html += "</table>";
            html += "</body></html>";
            string fileName = "tarjetas_cuotas.html";
            StreamWriter writer = File.CreateText(fileName);
            writer.WriteLine(html);
            writer.Close();
        }
        #endregion

        public void reciboTicket(string NRO_RECIBO, string NOMBRE_SOCIO, string FORMAPAGO, string SECTACT, string VALOR, int ID_PROFESIONAL, string SOCIO_TITULAR, string TIPO_SOCIO_TITULAR, 
            string OBSERVACIONES, string NRO_SOC, string NRO_DEP, string DOBLE_DUPLICADO, string DNI, string DEBE, string HABER, 
            string COMPROBANTE, string PTO_VTA, string FECHA, string REINTEGRO)
        {
            nombreProf np = new nombreProf();
            string PROFESIONAL = np.nombre(ID_PROFESIONAL);
            numerosAletras nal = new numerosAletras();
            VALOR = VALOR.Replace("$", "");
            VALOR = VALOR.Replace(".", ",");
            VALOR = VALOR.Replace("-", "");
            string VALOR_LETRAS = nal.convertir(VALOR);
            fechaAletras fal = new fechaAletras();
            string FECHA_LETRAS = fal.convertir(FECHA);
            int CANTIDAD = 2;
            string BR = COMPROBANTE;
            string[] DATOS = { NRO_RECIBO, FECHA_LETRAS, NOMBRE_SOCIO, FORMAPAGO, SECTACT, VALOR, VALOR_LETRAS, FECHA, PROFESIONAL, SOCIO_TITULAR, TIPO_SOCIO_TITULAR, OBSERVACIONES, NRO_SOC,
                               NRO_DEP, DOBLE_DUPLICADO, DNI, CANTIDAD.ToString(), BR, PTO_VTA, REINTEGRO };
            DATOS_BR = DATOS;
            print();
        }

        public void print()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PaperSize psize = new PaperSize();
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_Print);
            DialogResult result = pd.ShowDialog();

            if (result == DialogResult.OK)
            {
                int CANTIDAD = int.Parse(DATOS_BR[16]);

                for (int i = 1; i <= CANTIDAD; i++)
                {
                    switch (i)
                    {
                        case 1:
                            TIPO_RB = "ORIGINAL";
                            break;

                        case 2:
                            TIPO_RB = "DUPLICADO";
                            break;

                        case 3:
                            TIPO_RB = "TRIPLICADO";
                            break;
                    }

                    pdoc.Print();
                }
            }
        }

        public void pdoc_Print(object sender, PrintPageEventArgs e)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            string LEYENDA = "";
            string RECIBO_BONO = DATOS_BR[17];
            string TITULO = "";
            string NRO_RECIBO = DATOS_BR[0];
            string PTO_VTA = DATOS_BR[18];
            string VALOR = DATOS_BR[5];
            string VALOR_LETRAS = DATOS_BR[6];
            string REINTEGRO = DATOS_BR[19];
            string RR = "Recibí de ";

            if (RECIBO_BONO == "B")
            {
                code39.Code = "BO" + DATOS_BR[0];
                LEYENDA = "Cobrado por cuenta de:";
                TITULO = "BONO";
            }
            
            if (RECIBO_BONO == "R")
            {
                code39.Code = "RE" + DATOS_BR[0];
                LEYENDA = "Concepto: ";
                TITULO = "RECIBO PROVISORIO";
            }

            if (REINTEGRO == "SI")
            {
                RR = "Reintegré a ";
                TITULO = "REINTEGRO";
            }

            Bitmap bm = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White));
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 7);
            Font courier_xl = new Font("FontA1x1", 9);
            Font courier_med = new Font("FontA1x1", 6);
            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush red = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;
            int sep = 12;
            int sep2 = 14;

            graphics.DrawString("Círculo de Suboficiales de la PFA", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("Asociación Civil fundada el 7/3/1957", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("Personería Jurídica otorgada el 26/5/1958", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("CUIT: 30-51658821-3", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("Imp Ganancias Exento Art 20 Inc F Ley 20628(Lo 1997)", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("IVA Exento Art 7 Inc H Apar 6 Ley 20631(to 1997)", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("Imp Ing Brutos Exento Art 34 Inc 15 Cod Fiscal (to 2005) CABA", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("Exceptuando de emitir comprobantes", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("Anexo 1 de la R.G. 1415 apartado K", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString("----------------------------------------------------------------------------------------------------------------", courier_med, black, startX, startY + Offset);
            Offset = Offset + sep;
            graphics.DrawString(TITULO + " Nº " + PTO_VTA + "-" + NRO_RECIBO, courier_xl, black, startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Buenos Aires, " + DATOS_BR[1], courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawString(RR + "" + DATOS_BR[2], courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawString(DATOS_BR[10] + " - " + DATOS_BR[12] + " - " + DATOS_BR[13], courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawString("Pesos $ " + VALOR + ".-" , courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawString(VALOR_LETRAS, courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawString(LEYENDA, courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawString(DATOS_BR[4] + " - " + DATOS_BR[8], courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawString("Observaciones", courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawString(DATOS_BR[11], courier_big, black, startX, startY + Offset);
            Offset = Offset + sep2;
            graphics.DrawImage(bm, startX, startY + Offset);
        }

        #region FICHA TITULAR
        public void fichaTitular(int NUM_SOC, int NUM_DEP)
        {
            string folder = Directory.GetCurrentDirectory() + "\\TMP_IMG";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(folder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
            }

            // T I T U L A R E S

            conString conString = new conString();
            string connectionString = conString.get();

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                string QUERY = "SELECT * FROM FICHA_SOCIO(" + NUM_SOC + ", " + NUM_DEP + ");";
                FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                FbDataReader mt = cmd.ExecuteReader();

                string html = "<html><meta charset='UTF-8'><body style='font-family:courier;'>";

                if (mt.Read())
                {
                    Byte[] byteBLOBData1 = new Byte[0];
                    byteBLOBData1 = (Byte[])mt.GetValue(mt.GetOrdinal("FOTO"));
                    MemoryStream stmBLOBData1 = new MemoryStream(byteBLOBData1);
                    Image FOTO = byteArrayToImage(byteBLOBData1);
                    FOTO.Save(Directory.GetCurrentDirectory() + "\\TMP_IMG\\FOTO_TEMP.JPG");
                    string CATEGORIA = mt.GetString(mt.GetOrdinal("CATEGORIA"));
                    string NRO_SOC = mt.GetString(mt.GetOrdinal("NRO_SOC")).ToString();
                    string NRO_DEP = mt.GetString(mt.GetOrdinal("NRO_DEP")).ToString();
                    string PAR = mt.GetString(mt.GetOrdinal("PAR")).ToString();
                    string PCRJP1 = mt.GetString(mt.GetOrdinal("PCRJP1")).ToString();
                    string PCRJP2 = mt.GetString(mt.GetOrdinal("PCRJP2")).ToString();
                    string PCRJP3 = mt.GetString(mt.GetOrdinal("PCRJP3")).ToString();
                    string AAR = mt.GetString(mt.GetOrdinal("AAR")).ToString();
                    string ACRJP1 = mt.GetString(mt.GetOrdinal("ACRJP1")).ToString();
                    string ACRJP2 = mt.GetString(mt.GetOrdinal("ACRJP2")).ToString();
                    string ACRJP3 = mt.GetString(mt.GetOrdinal("ACRJP3")).ToString();
                    string APE_SOC = mt.GetString(mt.GetOrdinal("APE_SOC")).ToString();
                    string NOM_SOC = mt.GetString(mt.GetOrdinal("NOM_SOC")).ToString();
                    string F_NACIM = mt.GetString(mt.GetOrdinal("F_NACIM")).ToString();
                    string NUM_DOC = mt.GetString(mt.GetOrdinal("NUM_DOC")).ToString();
                    string NUM_CED = mt.GetString(mt.GetOrdinal("NUM_CED")).ToString();
                    string SEXO = mt.GetString(mt.GetOrdinal("SEXO"));
                    string CALL_PAR = mt.GetString(mt.GetOrdinal("CALL_PAR"));
                    string NRO_PAR = mt.GetString(mt.GetOrdinal("NRO_PAR")).ToString();
                    string PIS_PAR = mt.GetString(mt.GetOrdinal("PIS_PAR")).ToString();
                    string DPT_PAR = mt.GetString(mt.GetOrdinal("DPT_PAR")).ToString();
                    string LOC_PAR = mt.GetString(mt.GetOrdinal("LOC_PAR"));
                    string PROVINCIA = mt.GetString(mt.GetOrdinal("PROVINCIA"));
                    string CP_PART = mt.GetString(mt.GetOrdinal("CP_PART")).ToString();
                    string CAR_TE1 = mt.GetString(mt.GetOrdinal("CAR_TE1"));
                    string NUM_TE1 = mt.GetString(mt.GetOrdinal("NUM_TE1"));
                    string CAR_TE2 = mt.GetString(mt.GetOrdinal("CAR_TE2"));
                    string NUM_TE2 = mt.GetString(mt.GetOrdinal("NUM_TE2"));
                    string LEG_PER = mt.GetString(mt.GetOrdinal("LEG_PER")).ToString();
                    string DESTINO = mt.GetString(mt.GetOrdinal("DESTINO"));
                    string F_ALTPO = mt.GetString(mt.GetOrdinal("F_ALTPO"));
                    string CAM_JER = mt.GetString(mt.GetOrdinal("CAM_JER"));
                    string F_BAJPO = mt.GetString(mt.GetOrdinal("F_BAJPO"));
                    string ORD_DIA = mt.GetString(mt.GetOrdinal("ORD_DIA"));
                    string ORD_FEC = mt.GetString(mt.GetOrdinal("ORD_FEC"));
                    string ORD_DIA2 = mt.GetString(mt.GetOrdinal("ORD_DIA2"));
                    string ORD_FEC2 = mt.GetString(mt.GetOrdinal("ORD_FEC2"));
                    string ORD_DIA3 = mt.GetString(mt.GetOrdinal("ORD_DIA3"));
                    string ORD_FEC3 = mt.GetString(mt.GetOrdinal("ORD_FEC3"));
                    string F_ALTCI = mt.GetString(mt.GetOrdinal("F_ALTCI"));
                    string F_CACAT = mt.GetString(mt.GetOrdinal("F_CACAT"));
                    string F_ALTVI = mt.GetString(mt.GetOrdinal("F_ALTVI"));
                    string COD_DTO = mt.GetString(mt.GetOrdinal("COD_DTO"));
                    string NCOD_DTO = mt.GetString(mt.GetOrdinal("NCOD_DTO"));
                    string F_CESDE = mt.GetString(mt.GetOrdinal("F_CESDE"));
                    string A_DTO = mt.GetString(mt.GetOrdinal("A_DTO"));
                    string SUSCRIP = mt.GetString(mt.GetOrdinal("SUSCRIP"));
                    string F_CARN = mt.GetString(mt.GetOrdinal("F_CARN"));
                    string TIPO_CARNET = mt.GetString(mt.GetOrdinal("TIPO_CARNET"));
                    string F_BAJCI = mt.GetString(mt.GetOrdinal("F_BAJCI"));
                    string JERARQUIA = mt.GetString(mt.GetOrdinal("JERARQUIA"));
                    string M_BAJPO = mt.GetString(mt.GetOrdinal("M_BAJPO"));
                    string ID_EMPLEADO = "NO POSEE";

                    if (mt.GetString(mt.GetOrdinal("ID_EMPLEADO")) != "")
                        ID_EMPLEADO = mt.GetString(mt.GetOrdinal("ID_EMPLEADO"));

                    html += "<table width='100%' style='margin-top:10px;font-size:14px;' border='0' cellspacing='0' cellpadding='4'>";
                    html += "<tr style='background:#F9F9F9;'> <td align='left'><strong>DATOS DEL <br/> TITULAR</strong></td> <td align='center'>CATEGORÍA:<BR/> <strong>" + CATEGORIA + "</strong></td> <td align='center'>NRO SOCIO:<BR/> <strong>" + NRO_SOC + "/" + NRO_DEP + "</strong></td> <td align='center'>NRO BENEFICIO:<BR/><strong>" + PCRJP1 + "/" + PCRJP2 + "/" + PCRJP3 + "</strong></td> <td align='center'>NRO AFILIADO:<BR/><strong>" + AAR + "/" + ACRJP2 + "</strong> </td> <td align='center'>ID EMPLEADO:<BR/><strong>" + ID_EMPLEADO + "</strong> </td> <td align='right'><img src=' " + Directory.GetCurrentDirectory() + "\\TMP_IMG\\FOTO_TEMP.JPG' height='80' width='80' style='background-color:#ececec;' /></td> </tr>";
                    html += "</table>";
                    html += "<table width='100%' style='font-size:12px;' border='0' cellspacing='0' cellpadding='4'>";
                    html += "<tr style='background:#FFF;'> <td align='left' colspan='5'> <strong>PERSONALES</strong> </td> </tr>";
                    html += "<tr style='background:#F9F9F9;'> <td colspan='2'>APELLIDO: <strong>" + APE_SOC + "</strong> </td> <td colspan='3'>NOMBRE: <strong>" + NOM_SOC + "</strong> </td> </tr>";
                    html += "<tr> <td>F.NAC: <strong>"; if (F_NACIM != "") { html += F_NACIM.Substring(0, 10); } html += "</strong> </td> <td>DNI: <strong>" + NUM_DOC + "</strong></td> <td colspan='2'>CI: <strong>" + NUM_CED + "</strong> </td> <td>SEXO: <strong>" + SEXO + "</strong></td> </tr>";
                    html += "<tr style='background:#F9F9F9'> <td colspan='2'>DOMICILIO: <strong>" + CALL_PAR + "</strong></td> <td width='138'>NRO: <strong>" + NRO_PAR + "</strong></td> <td width='104'>PISO: <strong>" + PIS_PAR + "</strong></td> <td>DEPTO: <strong>" + DPT_PAR + "</strong></td> </tr>";
                    html += "<tr> <td colspan='2'>LOCALIDAD: <strong>" + LOC_PAR + "</strong></td> <td colspan='3'>CP: <strong>" + CP_PART + " - " + PROVINCIA + "</strong></td> </tr>";
                    html += "<tr style='background:#F9F9F9;'> <td colspan='5'>TELEFONOS: <strong>" + CAR_TE1 + " - " + NUM_TE1 + "</strong> <strong>" + CAR_TE2 + "</strong><strong>" + NUM_TE2 + "</strong></td> </tr>";
                    
                    html += "<tr style='background:#FFF;'> <td align='left' colspan='5'><strong>POLICIALES</strong></td> </tr>";
                    html += "<tr style='background:#F9F9F9;'> <td colspan='2'>LEGAJO PERSONAL: <strong>" + LEG_PER + " </strong></td> <td colspan='3'>DESTINO: <strong>" + DESTINO + "</strong></td> </tr>";
                    html += "<tr><td colspan='2'>ALTA POLICIAL: <strong>"; if (F_ALTPO != "") { html += F_ALTPO.Substring(0, 10); } html += "</strong></td> <td colspan='3'>JERARQUIA: " + JERARQUIA + " - CAMBIO JERARQUIA: <strong>"; if (CAM_JER != "") { html += CAM_JER.Substring(0, 10); } html += "</strong></td> </tr>";
                    html += "<tr style='background:#F9F9F9;'> <td colspan='2'>BAJA POLICIAL: <strong>"; if (F_BAJPO != "") { html += F_BAJPO.Substring(0, 10); } html += " - " + M_BAJPO + "</strong> </td> <td colspan='2'>OD: <strong>" + ORD_DIA + "</strong> </td> <td>FOD: <strong>"; if (ORD_FEC != "") { html += ORD_FEC.Substring(0, 10); } html += "</strong></td> </tr>";
                    
                    html += "<tr style='background:#FFF ;'> <td align='left' colspan='5'><strong>CIRCULO</strong></td> </tr>";
                    html += "<tr style='background:#F9F9F9'> <td>ALTA: <strong>"; if (F_ALTCI != "") { html += F_ALTCI.Substring(0, 10); } html += "</strong></td> <td>CAMBIO CAT: <strong>"; if (F_CACAT != "") { html += F_CACAT.Substring(0, 10); } html += "</strong> </td> <td width='138'>F VIT: <strong>"; if (F_ALTVI != "") { html += F_ALTVI.Substring(0, 10); } html += "</strong></td> <td width='104'>COD DTO: <strong>" + COD_DTO + "</strong></td> <td>NCOD DTO: <strong>" + NCOD_DTO + "</strong></td> </tr>";
                    html += "<tr><td>F CESE: ";

                    if (F_CESDE != "") { html += "<strong>" + F_CESDE.Substring(0, 10) + "</strong></td>"; }

                    html += "<td>A DTO: ";

                    if (A_DTO != "") { html += "<strong>" + A_DTO.Substring(0, 10) + "</strong></td>"; }

                    html += "<td colspan='3'>SUSCRIPTOR: " + SUSCRIP + "</strong></td> </tr>";

                    html += "<tr style='background:#F9F9F9'> ";
                    html += "<td>F CARNET: <strong>";

                    if (F_CARN != "") { html += "<strong>" + F_CARN.Substring(0, 10) + "</strong></td>"; }

                    html += "<td colspan='2'>TIPO CARNET: <strong>" + TIPO_CARNET + "</strong></td>";
                    html += "<td colspan='2'>BAJA CIRCULO: ";

                    if (F_BAJCI != "") { html += "<strong>" + F_BAJCI.Substring(0, 10) + "</strong></td> </tr>"; }

                    html += "</table>";
                }


                #region FAMILIARES

                string QUERY_FAM = "SELECT * FROM FICHA_FAMILIAR(" + NUM_SOC + ", " + NUM_DEP + ");";
                FbCommand cmd_fam = new FbCommand(QUERY_FAM, connection, transaction);
                FbDataReader mt_fam = cmd_fam.ExecuteReader();
                int f = 0;

                if (mt_fam.Read())
                {
                    html += "<table width='100%' style='margin-top:20px;font-size:12px;' border='0' cellspacing='0' cellpadding='4'>";
                    html += "<tr style='background:#F9F9F9;'><td colspan='6'><strong>DATOS DE LOS FAMILIARES</strong></td></tr>";
                    html += "<tr style='background:#FFFFFF;'><td><strong>BARRA</strong></td><td><strong>APELLIDO</strong></td><td><strong>NOMBRE</strong></td><td><strong>NACIMIENTO</strong></td><td><strong>CARNET</strong></td><td><strong>DNI</strong></td></tr>";
                    
                    do 
                    {
                        string BARRA = mt_fam.GetInt32(mt_fam.GetOrdinal("BARRA")).ToString();
                        string APE_FAM = mt_fam.GetString(mt_fam.GetOrdinal("APE_FAM"));
                        string NOM_FAM = mt_fam.GetString(mt_fam.GetOrdinal("NOM_FAM"));
                        string F_NACFAM = mt_fam.GetString(mt_fam.GetOrdinal("F_NACFAM"));
                        string TIP_CARN = mt_fam.GetString(mt_fam.GetOrdinal("TIP_CARN"));
                        string NUM_DOCF = mt_fam.GetInt32(mt_fam.GetOrdinal("NUM_DOCF")).ToString();
                        string STYLE = "#F9F9F9";

                        if (F_NACFAM != "")
                        {
                            F_NACFAM = F_NACFAM.Substring(0, 10);
                        }
                        else
                        {
                            F_NACFAM = "NO DISPONIBLE";
                        }

                        if (f == 0)
                        {
                            STYLE = "#F9F9F9";
                            f++;
                        }
                        else
                        {
                            STYLE = "#FFFFFF";
                            f = 0;
                        }
                        
                        html += "<tr style='background:" + STYLE + ";'><td>" + BARRA + "</td><td>" + APE_FAM + "</td><td>" + NOM_FAM + "</td><td>" + F_NACFAM + "</td><td>" + TIP_CARN + "</td><td>" + NUM_DOCF + "</td></tr>";
                    }

                    while (mt_fam.Read());
                    
                    html += "</table>";
                }
                #endregion

                #region ADHERENTES
                // A D H E R E N T E S
                string QUERY_ADH = "SELECT * FROM FICHA_ADHERENTE(" + NUM_SOC + ", " + NUM_DEP + ");";
                FbCommand cmd_adh = new FbCommand(QUERY_ADH, connection, transaction);
                FbDataReader mt_adh = cmd_adh.ExecuteReader();
                int a = 0;
                string STYLE_ADH = "#F9F9F9";

                if (mt_adh.Read())
                {

                    html += "<table width='100%' style='margin-top:20px;font-size:12px;' border='0' cellspacing='0' cellpadding='4'>";
                    html += "<tr style='background:#F9F9F9;'><td colspan='9'><strong>DATOS DE LOS ADHERENTES</strong></td></tr>";
                    html += "<tr style='background:#FFFFFF;'><td><strong>N ADH</strong></td><td><strong>N DEP</strong></td><td><strong>BARRA</strong></td><td><strong>APELLIDO</strong></td><td><strong>NOMBRE</strong></td><td><strong>CDTO</strong></td><td><strong>NACIMIENTO</strong></td><td><strong>ALTA</strong></td><td><strong>BAJA</strong></td></tr>";

                    do
                    {
                        string NRO_ADH = mt_adh.GetInt32(mt_adh.GetOrdinal("NRO_ADH")).ToString();
                        string NRO_DEPADH = mt_adh.GetInt32(mt_adh.GetOrdinal("NRO_DEPADH")).ToString();
                        string BARRA = mt_adh.GetInt32(mt_adh.GetOrdinal("BARRA")).ToString();
                        string APELLIDO = mt_adh.GetString(mt_adh.GetOrdinal("APE_ADH"));
                        string NOMBRE = mt_adh.GetString(mt_adh.GetOrdinal("NOM_ADH"));
                        string COD_DTO = mt_adh.GetString(mt_adh.GetOrdinal("COD_DTO"));
                        string ALTA = mt_adh.GetString(mt_adh.GetOrdinal("FE_ALTA"));
                        string BAJA = mt_adh.GetString(mt_adh.GetOrdinal("FE_BAJA"));
                        string NACIMIENTO = mt_adh.GetString(mt_adh.GetOrdinal("F_NACIMADH"));

                        if (NACIMIENTO != "")
                        {
                            NACIMIENTO = NACIMIENTO.Substring(0, 10);
                        }
                        else
                        {
                            NACIMIENTO = "NO DISPONIBLE";
                        }

                        if (BAJA != "")
                        {
                            BAJA = BAJA.Substring(0,10);
                        }
                        else
                        {
                            BAJA = "NO DISPONIBLE";
                        }

                        if (ALTA != "")
                        {
                            ALTA = ALTA.Substring(0, 10);
                        }
                        else
                        {
                            ALTA = "NO DISPONIBLE";
                        }

                        if (a == 0)
                        {
                            STYLE_ADH = "#F9F9F9";
                            a++;
                        }
                        else
                        {
                            STYLE_ADH = "#FFFFFF";
                            a = 0;
                        }

                        html += "<tr style='background:" + STYLE_ADH + ";'><td>" + NRO_ADH + "</td><td>" + NRO_DEPADH + "</td><td>" + BARRA + "</td><td>" + APELLIDO + "</td><td>" + NOMBRE + "</td><td>" + COD_DTO + "</td><td>" + NACIMIENTO + "</td><td>" + ALTA + "</td><td>" + BAJA + "</td></tr>";
                    }

                    while (mt_adh.Read());
                    html += "</table>";
                }
                
                #endregion

                html += "</body></html>";
                string fileName = "temp.html"; StreamWriter writer = File.CreateText(fileName); writer.WriteLine(html); writer.Close();
                printhtml p = new printhtml();
                preHTML ph = new preHTML(html);
                ph.ShowDialog();
            }
        }

#endregion

        #region AUTH INDIVIDUAL ADH
        public void authIndividualAdherente(int ID_TITULAR, int ID_ADHERENTE)
        {
            DateTime Hoy = DateTime.Today;

            string fecha_actual = Hoy.ToString("dd-MM-yyyy");

            string query = "SELECT T.APE_SOC, T.NOM_SOC, T.NUM_DOC, T.AAR, T.ACRJP2, T.NRO_SOC, T.LEG_PER, T.NCOD_DTO, T.A_DTO, T.PAR, A.APE_ADH, A.NOM_ADH, A.NRO_ADH, A.NUM_DOCADH, T.PCRJP2, T.PCRJP1 FROM TITULAR T, ADHERENT A WHERE T.ID_TITULAR = " + ID_TITULAR + " AND A.ID_ADHERENTE = " + ID_ADHERENTE;

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                string html = "<html><meta charset='UTF-8'><body style='font-family:courier;'>";

                int x = 1;

                for (int i = 0; i <= foundRows.Length - 1; i++)
                {
                    if (foundRows[i][9].ToString() == "2")
                    {
                        COD_DTO = "643";
                        TITULO = "BENEFICIO";
                        CRJP = foundRows[i][15].ToString() + "/" + foundRows[i][14].ToString();
                    }
                    else if (foundRows[i][9].ToString() == "0" && foundRows[i][3].ToString() == "1")
                    {
                        COD_DTO = "641";
                        TITULO = "AFILIADO";
                        CRJP = foundRows[i][3].ToString() + "/" + foundRows[i][4].ToString();
                    }

                    html += "<table width='750' style='margin-top:710px;' border='0' cellspacing='2'>";

                    html += "<tr><td colspan='3' style='font-size:12px;' align='center'>C&iacute;rculo de Suboficiales de la Polic&iacute;a Federal Argentina <div>Asociaci&oacute;n Civil Fundada el 7 de Marzo de 1957 con Personer&iacute;a Jur&iacute;dica Otorgada el 26 de Mayo de 1958 <br/> CUIT: 30-51658821-3 </div> </td></tr>";

                    html += "<tr><td colspan='3'><div align='center' style='font-size:12px;font-weight:bold;'>AUTORIZACI&Oacute;N ALTA DE DESCUENTO</div></td></tr>";


                    html += "<tr style='font-size:12px;'><td>TITULAR: <strong>" + foundRows[i][0].ToString().Trim() + ", " + foundRows[i][1].ToString().Trim() + "</strong></td><td>&nbsp;</td><td>FECHA: <strong>" + fecha_actual + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>DNI: <strong>" + foundRows[i][2] + "</strong></td><td>&nbsp;</td><td>" + TITULO + ": <strong>" + CRJP + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>LP: <strong>" + foundRows[i][6] + "</strong></td><td>&nbsp;</td><td>NRO SOCIO: <strong>" + foundRows[i][5] + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>ADHERENTE: <strong>" + foundRows[i][10].ToString().Trim() + ", " + foundRows[i][11].ToString().Trim() + "</strong></td><td>&nbsp;</td><td>NRO SOCIO: <strong>" + foundRows[i][12] + "</strong> - DNI: <strong>" + foundRows[i][13] + "</strong></td></tr>";


                    html += "<tr style='font-size:12px;'><td colspan='3' style='border:1px solid #333;padding:6px;'>Autorizo en este acto al CSPFA a efectuar el descuento mensual de la Cuota Societaria de mis Haberes seg&uacute;n detalle, firmando al pie de la presente en conformidad.-</td></tr>";

                    html += "<tr style='font-size:12px;'><td align='center' style='border:1px solid #CCC;'>CONCEPTO</td><td align='center' style='border:1px solid #CCC;'>COD.DTO.</td><td align='center' style='border:1px solid #CCC;'>HABERES</td></tr>";

                    html += "<tr style='font-size:12px;'><td align='center' style='border:1px solid #CCC;font-weight:bold;'>ALTA</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'>" + COD_DTO + "</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'><strong>" + foundRows[i][8].ToString().Substring(3, 7) + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td height='60'></td><td>&nbsp;</td><td></td></tr>";

                    html += "<tr style='font-size:12px;'><td valign='bottom' align='center' style='border-top:1px dashed #333;'>FIRMA DEL SOCIO TITULAR</td><td>&nbsp;</td><td valign='bottom' align='center' style='border-top:1px dashed #333;'>ACLARACI&Oacute;N</td></tr>";

                    html += "</table>";

                    html += "<br style='page-break-after: always;' />";

                }

                html += "</body></html>";

                string fileName = "temp.html"; StreamWriter writer = File.CreateText(fileName); writer.WriteLine(html); writer.Close();

                printhtml p = new printhtml();

                try
                {
                    p.printHTML("temp.html");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos");
            }
        }
        #endregion

        #region AUTH INDIVIDUAL TIT
        public void authIndividualTitular(int ID_TITULAR)
        {
            DateTime Hoy = DateTime.Today;

            string fecha_actual = Hoy.ToString("dd-MM-yyyy");

            string query = "SELECT T.APE_SOC, T.NOM_SOC, T.NUM_DOC, T.AAR, T.ACRJP2, T.NRO_SOC, T.LEG_PER, T.NCOD_DTO, T.A_DTO, T.PAR, T.PCRJP2, T.PCRJP1 FROM TITULAR T WHERE T.ID_TITULAR = " + ID_TITULAR;

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                string html = "<html><meta charset='UTF-8'><body style='font-family:courier;'>";

                int x = 1;

                for (int i = 0; i <= foundRows.Length - 1; i++)
                {
                    if (foundRows[i][9].ToString() == "2")
                    {
                        COD_DTO = "643";
                        TITULO = "BENEFICIO";
                        CRJP = foundRows[i][11].ToString() + "/" + foundRows[i][10].ToString();
                    }
                    else if (foundRows[i][9].ToString() == "0" && foundRows[i][3].ToString() == "1")
                    {
                        COD_DTO = "641";
                        TITULO = "AFILIADO";
                        CRJP = foundRows[i][3].ToString() + "/" + foundRows[i][4].ToString();
                    }

                    html += "<table width='750' style='margin-top:710px;' border='0' cellspacing='2'>";

                    html += "<tr><td colspan='3' style='font-size:12px;' align='center'>C&iacute;rculo de Suboficiales de la Polic&iacute;a Federal Argentina <div>Asociaci&oacute;n Civil Fundada el 7 de Marzo de 1957 con Personer&iacute;a Jur&iacute;dica Otorgada el 26 de Mayo de 1958 <br/> CUIT: 30-51658821-3 </div> </td></tr>";

                    html += "<tr><td colspan='3'><div align='center' style='font-size:12px;font-weight:bold;'>AUTORIZACI&Oacute;N ALTA DE DESCUENTO</div></td></tr>";


                    html += "<tr style='font-size:12px;'><td>TITULAR: <strong>" + foundRows[i][0].ToString().Trim() + ", " + foundRows[i][1].ToString().Trim() + "</strong></td><td>&nbsp;</td><td>FECHA: <strong>" + fecha_actual + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>DNI: <strong>" + foundRows[i][2] + "</strong></td><td>&nbsp;</td><td>" + TITULO + ": <strong>" + CRJP + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>LP: <strong>" + foundRows[i][6] + "</strong></td><td>&nbsp;</td><td>NRO SOCIO: <strong>" + foundRows[i][5] + "</strong></td></tr>";


                    html += "<tr style='font-size:12px;'><td colspan='3' style='border:1px solid #333;padding:6px;'>Autorizo en este acto al CSPFA a efectuar el descuento mensual de la Cuota Societaria de mis Haberes seg&uacute;n detalle, firmando al pie de la presente en conformidad.-</td></tr>";

                    html += "<tr style='font-size:12px;'><td align='center' style='border:1px solid #CCC;'>CONCEPTO</td><td align='center' style='border:1px solid #CCC;'>COD.DTO.</td><td align='center' style='border:1px solid #CCC;'>HABERES</td></tr>";

                    html += "<tr style='font-size:12px;'><td align='center' style='border:1px solid #CCC;font-weight:bold;'>ALTA</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'>" + COD_DTO + "</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'><strong>"; if (foundRows[i][8].ToString() !="") { html += foundRows[i][8].ToString().Substring(3, 7); } html +="</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td height='70'></td><td>&nbsp;</td><td></td></tr>";

                    html += "<tr style='font-size:12px;'><td valign='bottom' align='center' style='border-top:1px dashed #333;'>FIRMA DEL SOCIO TITULAR</td><td>&nbsp;</td><td valign='bottom' align='center' style='border-top:1px dashed #333;'>ACLARACI&Oacute;N</td></tr>";

                    html += "</table>";

                    html += "<br style='page-break-after: always;' />";

                }

                html += "</body></html>";

                string fileName = "temp.html";
                StreamWriter writer = File.CreateText(fileName);
                writer.WriteLine(html);
                writer.Close();

                printhtml p = new printhtml();

                try
                {
                    p.printHTML("temp.html");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }

                //preHTML ph = new preHTML(html);
                //ph.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron datos");
            }
        }
        #endregion

        #region SOLICITUD VOLVE
        public void solicitudTripticoVolve(string ADTO, string ORIGEN_ALTA, int PAR, int ORDEN, string IND, int AFI_BEN, int O, int A, int CSPFA, string DESTINO, string DESDE, string HASTA)
        {
            //VOLVE A SER PARTE

            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("dd-MM-yyyy");
            string anio_actual = Hoy.ToString("yyyy");
            string origen = ORIGEN_ALTA.Substring(3, 3);
            string mes = ADTO.Substring(3, 2);
            string anio = ADTO.Substring(6, 4);

            string query = "SELECT APE_SOC, NOM_SOC, NUM_DOC, AAR, ACRJP2, NRO_SOC, LEG_PER FROM TITULAR_TEMP WHERE 1=1";

            if (A == 1)
                query += " AND A_DTO = '" + anio + "/" + mes + "/01'";

            if (O == 1)
                query += " AND ORIGEN_ALTA = '" + origen + "'";

            if (AFI_BEN == 1 && IND != "")
                query += " AND AAR = " + IND.Substring(0, 1) + " AND ACRJP2 = " + IND.Substring(1, 6) + "";

            if (AFI_BEN == 2 && IND != "")
                query += " AND PCRJP1 = " + IND.Substring(0, 2) + " AND PCRJP2 = " + IND.Substring(2, 6) + " AND PCRJP3 = " + IND.Substring(8, 1) + "";

            query += " AND PAR = " + PAR + "";

            if (CSPFA == 1)
                query += " AND F_BAJCI IS NULL";
            else
                query += " AND F_BAJCI IS NOT NULL";

            if (DESTINO != "")
                query += " AND DESTINO = '" + DESTINO.Substring(3, 3) + "'";

            if (DESDE != "" && HASTA != "")
                query += " AND LEG_PER >= '" + DESDE + "' AND LEG_PER <= '" + HASTA + "'";

            if (ORDEN == 1)
                query += " ORDER BY APE_SOC, NOM_SOC;";
            else if (ORDEN == 2)
                query += " ORDER BY AAR, ACRJP2;";
            else if (ORDEN == 3)
                query += " ORDER BY LEG_PER;";

            int CODIGO = 0;

            if (AFI_BEN == 1)
                CODIGO = 633;

            if (AFI_BEN == 2)
                CODIGO = 640;

            //MessageBox.Show(query);

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                string html = "<html><meta charset='UTF-8'><body style='font-family:courier;'>";

                int x = 1;

                for (int i = 0; i <= foundRows.Length - 1; i++)
                {
                    html += "<table width='750' style='margin-top:700px;' border='0' cellspacing='2'>";

                    html += "<tr><td colspan='3' style='font-size:12px;' align='center'>C&iacute;rculo de Suboficiales de la Polic&iacute;a Federal Argentina <div>Asociaci&oacute;n Civil Fundada el 7 de Marzo de 1957 con Personer&iacute;a Jur&iacute;dica Otorgada el 26 de Mayo de 1958 <br/> CUIT: 30-51658821-3 </div> </td></tr>";

                    html += "<tr><td colspan='3'><div align='center' style='font-size:12px;font-weight:bold;'>AUTORIZACI&Oacute;N ALTA DESCUENTO</div></td></tr>";

                    html += "<tr><td><div style='font-size:12px;font-weight:bold;'>ALTA DESCUENTO</div></td><td>&nbsp;</td><td style='font-size:12px;'>FECHA: <strong>" + fecha_actual + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>APELLIDO: <strong>" + foundRows[i][0] + "</strong></td><td>&nbsp;</td><td>NOMBRES: <strong>" + foundRows[i][1] + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>DNI: <strong>" + foundRows[i][2] + "</strong></td><td>&nbsp;</td><td>AFILIADO. C.R.J Y P.F.A: <strong>" + foundRows[i][3] + "/" + foundRows[i][4] + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>LP: <strong>" + foundRows[i][6] + "</strong></td><td>&nbsp;</td><td style='font-size:12px;'></td></tr>";

                    html += "<tr style='font-size:12px;'><td colspan='3' style='border:1px solid #333;padding:6px;'>Autorizo en este acto al CSPFA a efectuar el descuento mensual de la Cuota Societaria de mis Haberes seg&uacute;n lo testado en el detalle, firmando al pie de la presente en conformidad.- <strong>INTERVINO: LUIS OROZCO</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td align='center' style='border:1px solid #CCC;'>CONCEPTO</td><td align='center' style='border:1px solid #CCC;'>COD.DTO.</td><td align='center' style='border:1px solid #CCC;'>HABERES</td></tr>";

                    html += "<tr style='font-size:12px;'><td align='center' style='border:1px solid #CCC;font-weight:bold;'>ALTA</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'>" + CODIGO + "</td><td align='center' style='border:1px solid #CCC;'>30 DIAS S/C MES&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A&Ntilde;O " + anio_actual + "</td></tr>";

                    html += "<tr style='font-size:12px;'><td height='70'></td><td>&nbsp;</td><td></td></tr>";

                    html += "<tr style='font-size:12px;'><td valign='bottom' align='center' style='border-top:1px dashed #333;'>FIRMA DEL SOCIO TITULAR</td><td>&nbsp;</td><td valign='bottom' align='center' style='border-top:1px dashed #333;'>ACLARACI&Oacute;N</td></tr>";

                    html += "</table>";

                    html += "<br style='page-break-after: always;' />";

                }

                html += "</body></html>";

                string fileName = "temp.html";
                StreamWriter writer = File.CreateText(fileName);
                writer.WriteLine(html);
                writer.Close();
                preHTML ph = new preHTML(html);
                ph.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron datos");
            }
        }
        #endregion

        #region SOLICITUD TRIPTICO
        public void solicitudTriptico(string ADTO, string ORIGEN_ALTA, int PAR, int ORDEN, string IND, int AFI_BEN, int O, int A, int CSPFA, string DESTINO, string DESDE, string HASTA)
        {
            //SOLO PARA LA ESCUELA
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("dd-MM-yyyy");
            string origen = ORIGEN_ALTA.Substring(3, 3);
            string mes = ADTO.Substring(3, 2);
            string anio = ADTO.Substring(6, 4);

            string query = "SELECT APE_SOC, NOM_SOC, NUM_DOC, AAR, ACRJP2, NRO_SOC, LEG_PER FROM TITULAR WHERE 1=1";

            if (A == 1)
                query += " AND A_DTO = '" + anio + "/" + mes + "/01'";

            if (O == 1)
                query += " AND ORIGEN_ALTA = '" + origen + "'";

            if (AFI_BEN == 1 && IND != "")
                query += " AND AAR = " + IND.Substring(0, 1) + " AND ACRJP2 = " + IND.Substring(1, 6) + "";

            if (AFI_BEN == 2 && IND != "")
                query += " AND PCRJP1 = " + IND.Substring(0, 2) + " AND PCRJP2 = " + IND.Substring(2, 6) + " AND PCRJP3 = " + IND.Substring(8, 1) + "";

            query += " AND PAR = " + PAR + "";

            if (CSPFA == 1)
                query += " AND F_BAJCI IS NULL";
            else
                query += " AND F_BAJCI IS NOT NULL";

            if (DESTINO != "")
                query += " AND DESTINO = '" + DESTINO.Substring(3,3) + "'";

            if (DESDE != "" && HASTA != "")
                query += " AND LEG_PER >= '" + DESDE + "' AND LEG_PER <= '" + HASTA + "'";

            if (ORDEN == 1)
                query += " ORDER BY APE_SOC, NOM_SOC;";
            else if (ORDEN == 2)
                query += " ORDER BY AAR, ACRJP2;";
            else if (ORDEN == 3)
                query += " ORDER BY LEG_PER;";

            int CODIGO = 0;

            if (AFI_BEN == 1)
                CODIGO = 633;

            if (AFI_BEN == 2)
                CODIGO = 640;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                string html = "<html><meta charset='UTF-8'><body style='font-family:courier;'>";

                int x = 1;

                for (int i = 0; i <= foundRows.Length - 1; i++)
                {
                    html += "<table width='750' style='margin-top:700px;' border='0' cellspacing='2'>";

                    html += "<tr><td colspan='3' style='font-size:12px;' align='center'>C&iacute;rculo de Suboficiales de la Polic&iacute;a Federal Argentina <div>Asociaci&oacute;n Civil Fundada el 7 de Marzo de 1957 con Personer&iacute;a Jur&iacute;dica Otorgada el 26 de Mayo de 1958 <br/> CUIT: 30-51658821-3 </div> </td></tr>";

                    html += "<tr><td colspan='3'><div align='center' style='font-size:12px;font-weight:bold;'>AUTORIZACI&Oacute;N ALTA DESCUENTO</div></td></tr>";

                    html += "<tr><td><div style='font-size:12px;font-weight:bold;'>ALTA DESCUENTO</div></td><td>&nbsp;</td><td style='font-size:12px;'>FECHA: <strong>" + fecha_actual + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>APELLIDO: <strong>" + foundRows[i][0] + "</strong></td><td>&nbsp;</td><td>NOMBRES: <strong>" + foundRows[i][1] + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td>DNI: <strong>" + foundRows[i][2] + "</strong></td><td>&nbsp;</td><td>AFILIADO. C.R.J Y P.F.A: <strong>" + foundRows[i][3] + "/" + foundRows[i][4] + "</strong></td></tr>";

                    html += "<tr><td><div style='float:left;font-size:18px;background-color:#000;color:#fff;font-weight:bold;padding:2px 4px;'>LP: " + foundRows[i][6] + "</div></td><td>&nbsp;</td><td style='font-size:12px;'>NRO SOCIO: <strong>" + foundRows[i][5] + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td colspan='3' style='border:1px solid #333;padding:6px;'>Autorizo en este acto al CSPFA a efectuar el descuento mensual de la Cuota Societaria de mis Haberes seg&uacute;n detalle, firmando al pie de la presente en conformidad.-</td></tr>";

                    html += "<tr style='font-size:12px;'><td align='center' style='border:1px solid #CCC;'>CONCEPTO</td><td align='center' style='border:1px solid #CCC;'>COD.DTO.</td><td align='center' style='border:1px solid #CCC;'>HABERES</td></tr>";

                    html += "<tr style='font-size:12px;'><td align='center' style='border:1px solid #CCC;font-weight:bold;'>ALTA</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'>" + CODIGO + "</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'><strong>" + mes + "/" + anio + "</strong></td></tr>";

                    html += "<tr style='font-size:12px;'><td height='70'></td><td>&nbsp;</td><td></td></tr>";

                    html += "<tr style='font-size:12px;'><td valign='bottom' align='center' style='border-top:1px dashed #333;'>FIRMA DEL SOCIO TITULAR</td><td>&nbsp;</td><td valign='bottom' align='center' style='border-top:1px dashed #333;'>ACLARACI&Oacute;N</td></tr>";

                    html += "</table>";

                    html += "<br style='page-break-after: always;' />";

                }

                html += "</body></html>";

                string fileName = "temp.html";
                StreamWriter writer = File.CreateText(fileName);
                writer.WriteLine(html);
                writer.Close();
                preHTML ph = new preHTML(html);
                ph.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron datos");
            }
        }
        #endregion

        //HTML RECIBO / BONO
        public void gHTML(string NRO_RECIBO, string NOMBRE_SOCIO, string FORMAPAGO, string SECTACT, string VALOR, int ID_PROFESIONAL, string SOCIO_TITULAR, string TIPO_SOCIO_TITULAR, string OBSERVACIONES, 
                          string NRO_SOC, string NRO_DEP, string DOBLE_DUPLICADO, string DNI, string DEBE, string HABER, string PTO_VTA, string RECIBO_BONO)
        {
            Bitmap barCode = null;
            nombreProf np = new nombreProf();
            numerosAletras nal = new numerosAletras();
            DateTime Hoy = DateTime.Today;
            fechaAletras fal = new fechaAletras();

            if (RECIBO_BONO == "R")
            {
                TITULO = "RECIBO";
                barCode = createBarCode39("RE" + PTO_VTA + "" + NRO_RECIBO);
            }

            if (RECIBO_BONO == "B")
            {
                TITULO = "BONO";
                barCode = createBarCode39("BO" + PTO_VTA + "" + NRO_RECIBO);
            }

            barCode.Save(@"C:\CSPFA_SOCIOS\BARCODE_TEMP.JPG", System.Drawing.Imaging.ImageFormat.Jpeg);
            string profesional = np.nombre(ID_PROFESIONAL);
            string VALOR_SIN_PESO = VALOR.Replace("$", "");
            string VALOR_SIN_PUNTO = VALOR_SIN_PESO.Replace(".", ",");
            string VALOR_LETRAS = nal.convertir(VALOR_SIN_PUNTO);
            string fecha_actual = Hoy.ToString("dd-MM-yyyy");
            string FECHA = fal.convertir(fecha_actual);
            int CANTIDAD_RECIBOS = 3;

            if (DOBLE_DUPLICADO == "SI")
            {
                CANTIDAD_RECIBOS = 4;
            }
           
            string html = "<html><meta charset='UTF-8'><body>";

            for (int i = 1; i <= CANTIDAD_RECIBOS; i++)
            {
                html += "<table border='0' width='685' height='290' cellspacing='0' cellpadding='6' style='font-family:courier;border:1px solid #333;'>";
                html += "<tr><td align='left' style='font-size:12px;'>CIRCULO DE SUBOFICIALES DE LA PFA<td><div style='padding-right:100px;text-align:right;'><img src='C:\\CSPFA_SOCIOS\\BARCODE_TEMP.JPG' /></div></td></tr>";
                html += "<tr><td colspan='2' align='left'><div style='font-size:9px;'>Asociaci&oacute;n Civil Fundada el 7 de Marzo de 1957 con Personer&iacute;a Jur&iacute;dica Otorgada el 26 de Mayo de 1958 <br/> CUIT: 30-51658821-3</div></td></tr>";

                switch (i)
                {
                    case 1:
                        html += "<tr><td width='310' style='font-size:16px;'>" + TITULO + " ORIGINAL N&deg; <strong>" + NRO_RECIBO + "</strong></td><td width='476' align='left'>Buenos Aires, " + FECHA + "</td></tr>";
                        break;

                    case 2:
                        html += "<tr><td width='310' style='font-size:16px;'>" + TITULO + " DUPLICADO N&deg; <strong>" + NRO_RECIBO + "</strong></td><td width='476' align='left'>Buenos Aires, " + FECHA + "</td></tr>";
                        break;

                    case 3:
                        html += "<tr><td width='310' style='font-size:16px;'>" + TITULO + " TRIPLICADO N&deg; <strong>" + NRO_RECIBO + "</strong></td><td width='476' align='left'>Buenos Aires, " + FECHA + "</td></tr>";
                        break;

                    case 4:
                        html += "<tr><td width='310' style='font-size:16px;'>RECIBO DUPLICADO N&deg; <strong>" + NRO_RECIBO + "</strong></td><td width='476' align='left'>Buenos Aires, " + FECHA + "</td></tr>";
                        break;
                }

                html += "<tr><td colspan='2' style='font-size:12px;'>Socio Titular: " + SOCIO_TITULAR + " - " + TIPO_SOCIO_TITULAR + " - " + NRO_SOC + " - " + NRO_DEP + "</td></tr>";
                html += "<tr><td colspan='2' style='font-size:12px;'>Recib&iacute; del Sr./a: " + NOMBRE_SOCIO + "</td></tr>";
                html += "<tr><td colspan='2' style='font-size:12px;'>Pesos: " + VALOR + " (" + VALOR_LETRAS + ")</td></tr>";
                html += "<tr><td colspan='2' style='font-size:12px;'>en concepto de: " + SECTACT + " - " + profesional + " - D: " + DEBE + " - H: " + HABER + "</td></tr>";
                html += "<tr><td colspan='2' style='font-size:12px;'>Obs: " + OBSERVACIONES + "</td></tr>";
                html += "<tr><td colspan='2' style='font-size:9px;'>Imp.Ganancias:Exento Art.20 Inc.F | Ley 20628(Lo.1997) | IVA:Exento Art.7 Inc. h apartado 6 | Ley 20631 (t.o.1997)<br/>Imp.Ingresos Brutos: Exento Art.34 inc.15 | Cod. Fiscal: (t.o. 2005) CABA | Exceptuando de emitir comprobantes | Anexo 1 de la R.G. 1415 apartado K</td></tr>";
                html += "</table>";
                html += "<br style='line-height:40px;'/>";
            }

            html += "<br style='page-break-after: always;' /></body></html>";

            string fileName = "recibo_temp.html";
            StreamWriter writer = File.CreateText(fileName);
            writer.WriteLine(html);
            writer.Close();
        }

        #region RECIBOS EN BLANCO
        public void recibosEnBlanco(int DESDE, int HASTA, string TITULO, string PTO_VTA)
        {
            string html = "";

            for (int X = DESDE; X <= HASTA; X++)
            {
                html += "<html><meta charset='UTF-8'><body>";

                for (int i = 1; i <= 3; i++)
                {
                    html += "<table border='0' width='685' height='290' cellspacing='0' cellpadding='6' style='font-family:courier;border:1px solid #333;'>";

                    html += "<tr><td colspan='2' align='center'>Circulo de Suboficiales de la Policia Federal Argentina <div style='font-size:9px;'>Asociaci&oacute;n Civil Fundada el 7 de Marzo de 1957 con Personer&iacute;a Jur&iacute;dica Otorgada el 26 de Mayo de 1958 <br/> CUIT: 30-51658821-3 </div> </td></tr>";

                    switch (i)
                    {
                        case 1:
                            html += "<tr><td width='310' style='font-size:16px;'>" + TITULO + " ORIGINAL N&deg; <strong>" + PTO_VTA + "-" + X + "</strong> </td><td width='380' align='left'>Buenos Aires, </td></tr>";
                            break;

                        case 2:
                            html += "<tr><td width='310' style='font-size:16px;'>" + TITULO + " DUPLICADO N&deg; <strong>" + PTO_VTA + "-" + X + "</strong> </td><td width='380' align='left'>Buenos Aires, </td></tr>";
                            break;

                        case 3:
                            html += "<tr><td width='310' style='font-size:16px;'>" + TITULO + " TRIPLICADO N&deg; <strong>" + PTO_VTA + "-" + X + "</strong> </td><td width='380' align='left'>Buenos Aires,  </td></tr>";
                            break;
                    }

                    html += "<tr><td colspan='2' style='font-size:12px;'>Socio Titular:  </td></tr>";
                    html += "<tr><td colspan='2' style='font-size:12px;'>Recib&iacute; del Sr./a:  </td></tr>";
                    html += "<tr><td colspan='2' style='font-size:12px;'>Pesos: </td></tr>";
                    html += "<tr><td colspan='2' style='font-size:12px;'>en concepto de: </td></tr>";
                    html += "<tr><td colspan='2' style='font-size:12px;'>Obs:  </td></tr>";
                    html += "<tr><td colspan='2' style='font-size:9px;'>Imp.Ganancias:Exento Art.20 Inc.F | Ley 20628(Lo.1997) | IVA:Exento Art.7 Inc. h apartado 6 | Ley 20631 (t.o.1997)<br/>Imp.Ingresos Brutos: Exento Art.34 inc.15 | Cod. Fiscal: (t.o. 2005) CABA | Exceptuando de emitir comprobantes | Anexo 1 de la R.G. 1415 apartado K</td></tr>";
                    html += "</table>";
                    html += "<br style='line-height:40px;'/>";
                }

                html += "<br style='page-break-after: always;' /></body></html>";
            }

            string fileName = "recibo_en_blanco.html";
            StreamWriter writer = File.CreateText(fileName);
            writer.WriteLine(html);
            writer.Close();
        }
        #endregion

        #region LISTADO TURNOS
        public void listadoTurnos(string PROFESIONAL, string FECHA_FINAL, string ESPECIALIDAD, string FECHA, int ESTADO)
        {
            try 
            {
                bo dlog = new bo();

                int PROF = int.Parse(PROFESIONAL);

                //OBTENGO NOMBRE PROFESIONAL

                string query_prof = "SELECT NOMBRE FROM PROFESIONALES WHERE ID = " + PROFESIONAL;

                DataRow[] nombreProfesional;

                nombreProfesional = dlog.BO_EjecutoDataTable(query_prof).Select();

                //OBTENGO NOMBRE ESPECIALIDAD

                string query_esp = "SELECT DETALLE FROM SECTACT WHERE ID = " + ESPECIALIDAD;

                DataRow[] nombreEspecialidad;

                nombreEspecialidad = dlog.BO_EjecutoDataTable(query_esp).Select();

                //OBTENGO LOS TURNOS
            
                string query = "SELECT TM.NRO_SOC, TM.NRO_DEP, TM.TIPO_SOC, TM.BARRA, TM.NRO_DOC, TM.NOMBRE, SUBSTRING(AP.DESDE FROM 1 FOR 5), SUBSTRING(AP.HASTA FROM 1 FOR 5), TM.EMAIL, TM.TELEFONO, TM.OBRA_SOCIAL, TM.PRIMERA_VEZ, TM.OBSERVACIONES, TM.USUARIO";
    
                query += " FROM TURNOS_MEDICOS TM, AGENDA_PROFESIONALES AP";
    
                query += " WHERE TM.PROFESIONAL = " + PROF;

                query += " AND AP.FECHA = '" + FECHA_FINAL + "'";
    
                query += " AND TM.DIAYHORA = AP.ID";

                if (ESTADO == 1)
                {
                    query += " AND AP.BAJA IS NULL";
                }
                else
                {
                    query += " AND AP.BAJA IS NOT NULL";
                }

                query += " AND TM.BAJA IS NULL";
                
                query += " ORDER BY AP.DESDE ASC;";

                DataRow[] listadoTurnos;

                listadoTurnos = dlog.BO_EjecutoDataTable(query).Select();

                string html = "";

                html += "<html><meta charset='UTF-8'><body>";

                html += "<table border='0' cellspacing='0' cellpadding='6' style='font-family:courier;font-size:12px;width:100%;'>";

                html += "<tr><td colspan='10' style='font-size:20px;'><strong>" + FECHA + " - " + nombreEspecialidad[0][0] + " - " + nombreProfesional[0][0] + "</strong></td></tr>";

                if (ESTADO == 1)
                {
                    html += "<tr><td colspan='10'>LISTADO DE TURNOS ACTIVOS</td></tr>";
                }
                else
                {
                    html += "<tr><td colspan='10'>LISTADO DE TURNOS CANCELADOS</td></tr>";
                }

                html += "<tr style='font-weight:bold;'><td>SOC</td><td>DEP</td><td>TIPO</td><td>/</td><td>DNI</td><td>APELLIDO Y NOMBRE</td><td>DESDE</td><td>HASTA</td></td><td>EMAIL</td></td><td>TEL</td></td><td>OS</td><td>1&deg; VEZ</td><td>OBSERVACIONES</td><td>USUARIO</td></tr>";
                
                if (listadoTurnos.Length > 0)
                {
                    int x = 1;

                    for (int i = 0; i <= listadoTurnos.Length - 1; i++)
                    {
                        if (x == 1)
                        {
                            html += "<tr style='background-color:#ececec;'>";
                            x++;
                        }
                        else
                        {
                            html += "<tr>";
                            x--;
                        }

                        html += "<td>" + listadoTurnos[i][0].ToString().Trim() + "</td>";
                        html += "<td>" + listadoTurnos[i][1].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][2].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][3].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][4].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][5].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][6].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][7].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][8].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][9].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][10].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][11].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][12].ToString() + "</td>";
                        html += "<td>" + listadoTurnos[i][13].ToString() + "</td>";
                        html += "</tr>";
                    }
                }
                        
                html += "</table>";

                html += "</body></html>";

                string fileName = "listado_turnos.html";
                
                StreamWriter writer = File.CreateText(fileName);
                
                writer.WriteLine(html);
                
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}

