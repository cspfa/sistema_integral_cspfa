using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SOCIOS
{
    public partial class renuncias : Form
    {
        public renuncias()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            buscarRenuncias("EXCEL");
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            buscarRenuncias("PDF");
        }

        private void header(Document doc, int MES, int ANO, int MES_CESE, int ANO_CESE, iTextSharp.text.Font FONT, PdfWriter writer)
        {
            Paragraph header = new Paragraph("RESUMEN GENERAL DE RENUNCIAS MENSUALES", FONT);
            header.Alignment = Element.ALIGN_CENTER;
            header.SpacingAfter = 5;
            doc.Add(header);
            Paragraph sub = new Paragraph("MES/AÑO: " + MES + "/" + ANO + " - MES DE CESE: " + MES_CESE + "/" + ANO_CESE, FONT);
            sub.Alignment = Element.ALIGN_CENTER;
            sub.SpacingAfter = 5;
            doc.Add(sub);
        }

        public void pdf(DataSet ds, string path)
        {
            int A_ACTIVOS = 0;
            int A_ADHERENTES = 0;
            int A_VITALICIOS = 0;
            int A_INVITADOS = 0;
            int A_INTERFUERZAS = 0;

            int P_ACTIVOS = 0;
            int P_ACTIVOS_ESP = 0;
            int P_ADHERENTES = 0;
            int P_VITALICIOS = 0;
            int P_VITALICIOS_ESP = 0;
            int P_INVITADOS = 0;
            int P_INTERFUERZAS = 0;

            string ACRJP2 = "";
            string PCRJP1 = "";
            string PCRJP2 = "";
            string PCRJP3 = "";
            string CAT_SOC = "";
            string TABLA = "";

            int MES;
            int ANO;
            int MES_CESE;
            int ANO_CESE;

            #region TOTALES
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ACRJP2 = row[6].ToString().Trim();
                PCRJP1 = row[7].ToString().Trim();
                PCRJP2 = row[8].ToString().Trim();
                PCRJP3 = row[9].ToString().Trim();
                CAT_SOC = row[10].ToString().Trim();
                TABLA = row[11].ToString().Trim();

                if (ACRJP2 != "0" && PCRJP2 == "0") //ACTIVIDAD
                {
                    if (TABLA == "TITULAR" && CAT_SOC == "001")
                    {
                        A_ACTIVOS++;
                    }
                    
                    if (TABLA == "TITULAR" && CAT_SOC == "002")
                    {
                        A_VITALICIOS++;
                    }

                    if (TABLA == "ADHERENTE")
                    {
                        A_ADHERENTES++;
                    }

                    if (TABLA == "TITULAR" && CAT_SOC == "006")
                    {
                        A_INVITADOS++;
                    }

                    if (TABLA == "TITULAR" && CAT_SOC == "015")
                    {
                        A_INTERFUERZAS++;
                    }
                }
                
                if (PCRJP2 != "0") //PASIVIDAD
                {
                    if (TABLA == "TITULAR" && CAT_SOC == "001")
                    {
                        P_ACTIVOS++;
                    }

                    if (TABLA == "TITULAR" && CAT_SOC == "003")
                    {
                        P_ACTIVOS_ESP++;
                    }

                    if (TABLA == "TITULAR" && CAT_SOC == "002")
                    {
                        P_VITALICIOS++;
                    }

                    if (TABLA == "TITULAR" && CAT_SOC == "004")
                    {
                        P_VITALICIOS_ESP++;
                    }
                    
                    if (TABLA == "ADHERENTE")
                    {
                        P_ADHERENTES++;
                    }

                    if (TABLA == "TITULAR" && CAT_SOC == "006")
                    {
                        P_INVITADOS++;
                    }

                    if (TABLA == "TITULAR" && CAT_SOC == "015")
                    {
                        P_INTERFUERZAS++;
                    }
                }
            }
            #endregion

            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.AddTitle("RESUMEN GENERAL DE RENUNCIAS MENSUALES");
            doc.AddCreator("CSPFA");
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font _standardFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _standardFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

            iTextSharp.text.Font _mediumFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font _mediumFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

            BaseColor negro = new BaseColor(0, 0, 0);
            BaseColor gris = new BaseColor(230, 230, 230);
            BaseColor topo = new BaseColor(100, 100, 100);
            BaseColor blanco = new BaseColor(255, 255, 255);
            BaseColor colorFondo = new BaseColor(255, 255, 255);
            
            MES = int.Parse(dpDesde.Text.Substring(3, 2));
            ANO = int.Parse(dpDesde.Text.Substring(6, 4));

            if (MES != 12)
            {
                MES_CESE = MES + 1;
                ANO_CESE = ANO;
            }
            else
            {
                MES_CESE = 1;
                ANO_CESE = ANO + 1;
            }

            header(doc, MES, ANO, MES_CESE, ANO_CESE, _standardFontBold, writer);
            doc.Add(Chunk.NEWLINE);

            #region ACTIVIDAD CARATULA
            Paragraph tituloActividad = new Paragraph("ACTIVIDAD", _standardFontBold);
            tituloActividad.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloActividad);
            PdfPTable tablaActividad = new PdfPTable(2);
            tablaActividad.SpacingAfter = 10;
            tablaActividad.SpacingBefore = 10;
            tablaActividad.WidthPercentage = 50;
            PdfPCell celdaCategoriaA = new PdfPCell(new Phrase("CATEGORIA", _standardFontBold));
            celdaCategoriaA.FixedHeight = 25f;
            celdaCategoriaA.HorizontalAlignment = 1;
            celdaCategoriaA.BackgroundColor = gris;
            PdfPCell celdaRenunciasA = new PdfPCell(new Phrase("RENUNCIAS", _standardFontBold));
            celdaRenunciasA.HorizontalAlignment = 1;
            celdaRenunciasA.FixedHeight = 25f;
            celdaRenunciasA.BackgroundColor = gris;
            PdfPCell celdaActivoA = new PdfPCell(new Paragraph("ACTIVO", _standardFont));
            celdaActivoA.HorizontalAlignment = 1;
            celdaActivoA.FixedHeight = 25f;
            PdfPCell celdaAdherenteA = new PdfPCell(new Paragraph("ADHERENTE", _standardFont));
            celdaAdherenteA.HorizontalAlignment = 1;
            celdaAdherenteA.FixedHeight = 25f;
            PdfPCell celdaVitalicioA = new PdfPCell(new Paragraph("VITALICIO", _standardFont));
            celdaVitalicioA.HorizontalAlignment = 1;
            celdaVitalicioA.FixedHeight = 25f;
            PdfPCell celdaInvitadoA = new PdfPCell(new Paragraph("INVITADO", _standardFont));
            celdaInvitadoA.HorizontalAlignment = 1;
            celdaInvitadoA.FixedHeight = 25f;
            PdfPCell celdaInterfuerzasA = new PdfPCell(new Paragraph("INTERFUERZAS", _standardFont));
            celdaInterfuerzasA.HorizontalAlignment = 1;
            celdaInterfuerzasA.FixedHeight = 25f;
            PdfPCell celdaTotalA = new PdfPCell(new Paragraph("TOTAL", _standardFontBold));
            celdaTotalA.HorizontalAlignment = 1;
            celdaTotalA.FixedHeight = 25f;
            celdaTotalA.BackgroundColor = gris;
            PdfPCell celdaRActivoA = new PdfPCell(new Paragraph(A_ACTIVOS.ToString(), _standardFont));
            celdaRActivoA.HorizontalAlignment = 1;
            celdaRActivoA.FixedHeight = 25f;
            PdfPCell celdaRAdherenteA = new PdfPCell(new Paragraph(A_ADHERENTES.ToString(), _standardFont));
            celdaRAdherenteA.HorizontalAlignment = 1;
            celdaRAdherenteA.FixedHeight = 25f;
            PdfPCell celdaRVitalicioA = new PdfPCell(new Paragraph(A_VITALICIOS.ToString(), _standardFont));
            celdaRVitalicioA.HorizontalAlignment = 1;
            celdaRVitalicioA.FixedHeight = 25f;
            PdfPCell celdaRInvitadoA = new PdfPCell(new Paragraph(A_INVITADOS.ToString(), _standardFont));
            celdaRInvitadoA.HorizontalAlignment = 1;
            celdaRInvitadoA.FixedHeight = 25f;
            PdfPCell celdaRInterfuerzasA = new PdfPCell(new Paragraph(A_INTERFUERZAS.ToString(), _standardFont));
            celdaRInterfuerzasA.HorizontalAlignment = 1;
            celdaRInterfuerzasA.FixedHeight = 25f;
            PdfPCell celdaRTotalA = new PdfPCell(new Paragraph((A_ACTIVOS + A_ADHERENTES + A_VITALICIOS + A_INVITADOS + A_INTERFUERZAS).ToString(), _standardFontBold));
            celdaRTotalA.HorizontalAlignment = 1;
            celdaRTotalA.BackgroundColor = gris;
            tablaActividad.AddCell(celdaCategoriaA);
            tablaActividad.AddCell(celdaRenunciasA);
            tablaActividad.AddCell(celdaActivoA);
            tablaActividad.AddCell(celdaRActivoA);
            tablaActividad.AddCell(celdaAdherenteA);
            tablaActividad.AddCell(celdaRAdherenteA);
            tablaActividad.AddCell(celdaVitalicioA);
            tablaActividad.AddCell(celdaRVitalicioA);
            tablaActividad.AddCell(celdaInvitadoA);
            tablaActividad.AddCell(celdaRInvitadoA);
            tablaActividad.AddCell(celdaInterfuerzasA);
            tablaActividad.AddCell(celdaRInterfuerzasA); 
            tablaActividad.AddCell(celdaTotalA);
            tablaActividad.AddCell(celdaRTotalA);
            doc.Add(tablaActividad);
            doc.Add(Chunk.NEWLINE);
            #endregion

            #region PASIVIDAD CARATULA
            Paragraph tituloPasividad = new Paragraph("PASIVIDAD", _standardFontBold);
            tituloPasividad.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloPasividad);
            
            PdfPTable tablaPasividad = new PdfPTable(2);
            tablaPasividad.WidthPercentage = 50;
            tablaPasividad.SpacingAfter = 10;
            tablaPasividad.SpacingBefore = 10;
            tablaPasividad.HorizontalAlignment = 1;

            PdfPCell celdaCategoriaP = new PdfPCell(new Phrase("CATEGORIA", _standardFontBold));
            celdaCategoriaP.HorizontalAlignment = 1;
            celdaCategoriaP.FixedHeight = 25f;
            celdaCategoriaP.BackgroundColor = gris;
            
            PdfPCell celdaRenunciasP = new PdfPCell(new Phrase("RENUNCIAS", _standardFontBold));
            celdaRenunciasP.HorizontalAlignment = 1;
            celdaRenunciasP.FixedHeight = 25f;
            celdaRenunciasP.BackgroundColor = gris;
            
            PdfPCell celdaActivoP = new PdfPCell(new Paragraph("ACTIVO", _standardFont));
            celdaActivoP.HorizontalAlignment = 1;
            celdaActivoP.FixedHeight = 25f;
            
            PdfPCell celdaActivoPE = new PdfPCell(new Paragraph("ACTIVO ESP", _standardFont));
            celdaActivoPE.HorizontalAlignment = 1;
            celdaActivoPE.FixedHeight = 25f;
            
            PdfPCell celdaAdherenteP = new PdfPCell(new Paragraph("ADHERENTE", _standardFont));
            celdaAdherenteP.HorizontalAlignment = 1;
            celdaAdherenteP.FixedHeight = 25f;
            
            PdfPCell celdaVitalicioP = new PdfPCell(new Paragraph("VITALICIO", _standardFont));
            celdaVitalicioP.HorizontalAlignment = 1;
            celdaVitalicioP.FixedHeight = 25f;
            
            PdfPCell celdaVitalicioPE = new PdfPCell(new Paragraph("VITALICIO ESP", _standardFont));
            celdaVitalicioPE.HorizontalAlignment = 1;
            celdaVitalicioPE.FixedHeight = 25f;
            
            PdfPCell celdaInvitadoP = new PdfPCell(new Paragraph("INVITADO", _standardFont));
            celdaInvitadoP.HorizontalAlignment = 1;
            celdaInvitadoP.FixedHeight = 25f;

            PdfPCell celdaInterfuerzasP = new PdfPCell(new Paragraph("INTERFUERZAS", _standardFont));
            celdaInterfuerzasP.HorizontalAlignment = 1;
            celdaInterfuerzasP.FixedHeight = 25f;
            
            PdfPCell celdaTotalP = new PdfPCell(new Paragraph("TOTAL", _standardFontBold));
            celdaTotalP.HorizontalAlignment = 1;
            celdaTotalP.FixedHeight = 25f;
            celdaTotalP.BackgroundColor = gris;

            PdfPCell celdaRActivoP = new PdfPCell(new Paragraph(P_ACTIVOS.ToString(), _standardFont));
            celdaRActivoP.HorizontalAlignment = 1;
            celdaRActivoP.FixedHeight = 25f;

            PdfPCell celdaRActivoPE = new PdfPCell(new Paragraph(P_ACTIVOS_ESP.ToString(), _standardFont));
            celdaRActivoPE.HorizontalAlignment = 1;
            celdaRActivoPE.FixedHeight = 25f;

            PdfPCell celdaRAdherenteP = new PdfPCell(new Paragraph(P_ADHERENTES.ToString(), _standardFont));
            celdaRAdherenteP.HorizontalAlignment = 1;
            celdaRAdherenteP.FixedHeight = 25f;

            PdfPCell celdaRVitalicioP = new PdfPCell(new Paragraph(P_VITALICIOS.ToString(), _standardFont));
            celdaRVitalicioP.HorizontalAlignment = 1;
            celdaRVitalicioP.FixedHeight = 25f;

            PdfPCell celdaRVitalicioPE = new PdfPCell(new Paragraph(P_VITALICIOS_ESP.ToString(), _standardFont));
            celdaRVitalicioPE.HorizontalAlignment = 1;
            celdaRVitalicioPE.FixedHeight = 25f;

            PdfPCell celdaRInvitadoP = new PdfPCell(new Paragraph(P_INVITADOS.ToString(), _standardFont));
            celdaRInvitadoP.HorizontalAlignment = 1;
            celdaRInvitadoP.FixedHeight = 25f;

            PdfPCell celdaRInterfuerzasP = new PdfPCell(new Paragraph(P_INTERFUERZAS.ToString(), _standardFont));
            celdaRInterfuerzasP.HorizontalAlignment = 1;
            celdaRInterfuerzasP.FixedHeight = 25f;

            PdfPCell celdaRTotalP = new PdfPCell(new Paragraph((P_ACTIVOS + P_ADHERENTES + P_VITALICIOS + P_INVITADOS + P_ACTIVOS_ESP + P_VITALICIOS_ESP + P_INTERFUERZAS).ToString(), _standardFontBold));
            celdaRTotalP.HorizontalAlignment = 1;
            celdaRTotalP.BackgroundColor = gris;
            tablaPasividad.AddCell(celdaCategoriaP);
            tablaPasividad.AddCell(celdaRenunciasP);
            tablaPasividad.AddCell(celdaActivoP);
            tablaPasividad.AddCell(celdaRActivoP);
            tablaPasividad.AddCell(celdaActivoPE);
            tablaPasividad.AddCell(celdaRActivoPE);
            tablaPasividad.AddCell(celdaAdherenteP);
            tablaPasividad.AddCell(celdaRAdherenteP);
            tablaPasividad.AddCell(celdaVitalicioP);
            tablaPasividad.AddCell(celdaRVitalicioP);
            tablaPasividad.AddCell(celdaVitalicioPE);
            tablaPasividad.AddCell(celdaRVitalicioPE);
            tablaPasividad.AddCell(celdaInvitadoP);
            tablaPasividad.AddCell(celdaRInvitadoP);
            tablaPasividad.AddCell(celdaInterfuerzasP);
            tablaPasividad.AddCell(celdaRInterfuerzasP);
            tablaPasividad.AddCell(celdaTotalP);
            tablaPasividad.AddCell(celdaRTotalP);
            doc.Add(tablaPasividad);
            #endregion

            #region TOTAL GENERAL CARATULA
            PdfPTable tablaTotal = new PdfPTable(1);
            tablaTotal.WidthPercentage = 50;
            tablaTotal.SpacingBefore = 20;
            PdfPCell celdaTotal = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS", _standardFontBold));
            celdaTotal.HorizontalAlignment = 1;
            celdaTotal.FixedHeight = 25f;
            celdaTotal.BackgroundColor = gris;
            PdfPCell celdaTotalR = new PdfPCell(new Paragraph((P_ACTIVOS + P_ADHERENTES + P_VITALICIOS + P_INVITADOS + A_ACTIVOS + A_ADHERENTES + A_VITALICIOS + A_INVITADOS + A_INTERFUERZAS + P_ACTIVOS_ESP + P_VITALICIOS_ESP + P_INTERFUERZAS).ToString(), _standardFontBold));
            celdaTotalR.HorizontalAlignment = 1;
            celdaTotalR.FixedHeight = 25f;
            tablaTotal.AddCell(celdaTotal);
            tablaTotal.AddCell(celdaTotalR);
            doc.Add(tablaTotal);
            #endregion
            
            #region TABLA ACTIVO
            PdfPTable tablaActivo = new PdfPTable(6);
            tablaActivo.WidthPercentage = 100;
            tablaActivo.SpacingAfter = 10;
            tablaActivo.SpacingBefore = 10;
            tablaActivo.SetWidths(new float[] { 2f, 6f, 2f, 6f, 2f, 2f });
            PdfPCell celdaNsocio = new PdfPCell(new Phrase("NºSOCIO", _mediumFontBoldWhite));
            PdfPCell celdaNombre = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
            PdfPCell celdaFecha = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            PdfPCell celdaDestino = new PdfPCell(new Phrase("DESTINO", _mediumFontBoldWhite));
            PdfPCell celdaAfil = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
            PdfPCell celdaBenef = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
            celdaNsocio.BackgroundColor = topo;
            celdaNsocio.BorderColor = blanco;
            celdaNsocio.HorizontalAlignment = 1;
            celdaNsocio.FixedHeight = 16f;
            celdaNombre.BackgroundColor = topo;
            celdaNombre.BorderColor = blanco;
            celdaNombre.HorizontalAlignment = 1;
            celdaNombre.FixedHeight = 16f;
            celdaFecha.BackgroundColor = topo;
            celdaFecha.BorderColor = blanco;
            celdaFecha.HorizontalAlignment = 1;
            celdaFecha.FixedHeight = 16f;
            celdaDestino.BackgroundColor = topo;
            celdaDestino.BorderColor = blanco;
            celdaDestino.HorizontalAlignment = 1;
            celdaDestino.FixedHeight = 16f;
            celdaAfil.BackgroundColor = topo;
            celdaAfil.BorderColor = blanco;
            celdaAfil.HorizontalAlignment = 1;
            celdaAfil.FixedHeight = 16f;
            celdaBenef.BackgroundColor = topo;
            celdaBenef.BorderColor = blanco;
            celdaBenef.HorizontalAlignment = 1;
            celdaBenef.FixedHeight = 16f;
            tablaActivo.AddCell(celdaNsocio);
            tablaActivo.AddCell(celdaNombre);
            tablaActivo.AddCell(celdaFecha);
            tablaActivo.AddCell(celdaDestino);
            tablaActivo.AddCell(celdaAfil);
            tablaActivo.AddCell(celdaBenef);
            #endregion

            #region TABLA ACTIVO ESPECIAL
            PdfPTable tablaActivoEspecial = new PdfPTable(6);
            tablaActivoEspecial.WidthPercentage = 100;
            tablaActivoEspecial.SpacingAfter = 10;
            tablaActivoEspecial.SpacingBefore = 10;
            tablaActivoEspecial.SetWidths(new float[] { 2f, 6f, 2f, 6f, 2f, 2f });
            PdfPCell celdaNsocioEspecial = new PdfPCell(new Phrase("NºSOCIO", _mediumFontBoldWhite));
            PdfPCell celdaNombreEspecial = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
            PdfPCell celdaFechaEspecial = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            PdfPCell celdaDestinoEspecial = new PdfPCell(new Phrase("DESTINO", _mediumFontBoldWhite));
            PdfPCell celdaAfilEspecial = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
            PdfPCell celdaBenefEspecial = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
            celdaNsocioEspecial.BackgroundColor = topo;
            celdaNsocioEspecial.BorderColor = blanco;
            celdaNsocioEspecial.HorizontalAlignment = 1;
            celdaNsocioEspecial.FixedHeight = 16f;
            celdaNombreEspecial.BackgroundColor = topo;
            celdaNombreEspecial.BorderColor = blanco;
            celdaNombreEspecial.HorizontalAlignment = 1;
            celdaNombreEspecial.FixedHeight = 16f;
            celdaFechaEspecial.BackgroundColor = topo;
            celdaFechaEspecial.BorderColor = blanco;
            celdaFechaEspecial.HorizontalAlignment = 1;
            celdaFechaEspecial.FixedHeight = 16f;
            celdaDestinoEspecial.BackgroundColor = topo;
            celdaDestinoEspecial.BorderColor = blanco;
            celdaDestinoEspecial.HorizontalAlignment = 1;
            celdaDestinoEspecial.FixedHeight = 16f;
            celdaAfilEspecial.BackgroundColor = topo;
            celdaAfilEspecial.BorderColor = blanco;
            celdaAfilEspecial.HorizontalAlignment = 1;
            celdaAfilEspecial.FixedHeight = 16f;
            celdaBenefEspecial.BackgroundColor = topo;
            celdaBenefEspecial.BorderColor = blanco;
            celdaBenefEspecial.HorizontalAlignment = 1;
            celdaBenefEspecial.FixedHeight = 16f;
            tablaActivoEspecial.AddCell(celdaNsocioEspecial);
            tablaActivoEspecial.AddCell(celdaNombreEspecial);
            tablaActivoEspecial.AddCell(celdaFechaEspecial);
            tablaActivoEspecial.AddCell(celdaDestinoEspecial);
            tablaActivoEspecial.AddCell(celdaAfilEspecial);
            tablaActivoEspecial.AddCell(celdaBenefEspecial);
            #endregion

            #region TABLA ADHERENTE
            PdfPTable tablaAdherente = new PdfPTable(6);
            tablaAdherente.WidthPercentage = 100;
            tablaAdherente.SpacingAfter = 10;
            tablaAdherente.SpacingBefore = 10;
            tablaAdherente.SetWidths(new float[] { 2f, 6f, 2f, 6f, 2f, 2f });
            PdfPCell celdaNsocioADH = new PdfPCell(new Phrase("NºSOCIO", _mediumFontBoldWhite));
            PdfPCell celdaNombreADH = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
            PdfPCell celdaFechaADH = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            PdfPCell celdaDestinoADH = new PdfPCell(new Phrase("DESTINO", _mediumFontBoldWhite));
            PdfPCell celdaAfilADH = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
            PdfPCell celdaBenefADH = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
            celdaNsocioADH.BackgroundColor = topo;
            celdaNsocioADH.BorderColor = blanco;
            celdaNsocioADH.HorizontalAlignment = 1;
            celdaNsocioADH.FixedHeight = 16f;
            celdaNombreADH.BackgroundColor = topo;
            celdaNombreADH.BorderColor = blanco;
            celdaNombreADH.HorizontalAlignment = 1;
            celdaNombreADH.FixedHeight = 16f;
            celdaFechaADH.BackgroundColor = topo;
            celdaFechaADH.BorderColor = blanco;
            celdaFechaADH.HorizontalAlignment = 1;
            celdaFechaADH.FixedHeight = 16f;
            celdaDestinoADH.BackgroundColor = topo;
            celdaDestinoADH.BorderColor = blanco;
            celdaDestinoADH.HorizontalAlignment = 1;
            celdaDestinoADH.FixedHeight = 16f;
            celdaAfilADH.BackgroundColor = topo;
            celdaAfilADH.BorderColor = blanco;
            celdaAfilADH.HorizontalAlignment = 1;
            celdaAfilADH.FixedHeight = 16f;
            celdaBenefADH.BackgroundColor = topo;
            celdaBenefADH.BorderColor = blanco;
            celdaBenefADH.HorizontalAlignment = 1;
            celdaBenefADH.FixedHeight = 16f;
            tablaAdherente.AddCell(celdaNsocioADH);
            tablaAdherente.AddCell(celdaNombreADH);
            tablaAdherente.AddCell(celdaFechaADH);
            tablaAdherente.AddCell(celdaDestinoADH);
            tablaAdherente.AddCell(celdaAfilADH);
            tablaAdherente.AddCell(celdaBenefADH);
            #endregion

            #region TABLA VITALICIO
            PdfPTable tablaVitalicio = new PdfPTable(6);
            tablaVitalicio.WidthPercentage = 100;
            tablaVitalicio.SpacingAfter = 10;
            tablaVitalicio.SpacingBefore = 10;
            tablaVitalicio.SetWidths(new float[] { 2f, 6f, 2f, 6f, 2f, 2f });
            PdfPCell celdaNsocioVIT = new PdfPCell(new Phrase("NºSOCIO", _mediumFontBoldWhite));
            PdfPCell celdaNombreVIT = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
            PdfPCell celdaFechaVIT = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            PdfPCell celdaDestinoVIT = new PdfPCell(new Phrase("DESTINO", _mediumFontBoldWhite));
            PdfPCell celdaAfilVIT = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
            PdfPCell celdaBenefVIT = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
            celdaNsocioVIT.BackgroundColor = topo;
            celdaNsocioVIT.BorderColor = blanco;
            celdaNsocioVIT.HorizontalAlignment = 1;
            celdaNsocioVIT.FixedHeight = 16f;
            celdaNombreVIT.BackgroundColor = topo;
            celdaNombreVIT.BorderColor = blanco;
            celdaNombreVIT.HorizontalAlignment = 1;
            celdaNombreVIT.FixedHeight = 16f;
            celdaFechaVIT.BackgroundColor = topo;
            celdaFechaVIT.BorderColor = blanco;
            celdaFechaVIT.HorizontalAlignment = 1;
            celdaFechaVIT.FixedHeight = 16f;
            celdaDestinoVIT.BackgroundColor = topo;
            celdaDestinoVIT.BorderColor = blanco;
            celdaDestinoVIT.HorizontalAlignment = 1;
            celdaDestinoVIT.FixedHeight = 16f;
            celdaAfilVIT.BackgroundColor = topo;
            celdaAfilVIT.BorderColor = blanco;
            celdaAfilVIT.HorizontalAlignment = 1;
            celdaAfilVIT.FixedHeight = 16f;
            celdaBenefVIT.BackgroundColor = topo;
            celdaBenefVIT.BorderColor = blanco;
            celdaBenefVIT.HorizontalAlignment = 1;
            celdaBenefVIT.FixedHeight = 16f;
            tablaVitalicio.AddCell(celdaNsocioVIT);
            tablaVitalicio.AddCell(celdaNombreVIT);
            tablaVitalicio.AddCell(celdaFechaVIT);
            tablaVitalicio.AddCell(celdaDestinoVIT);
            tablaVitalicio.AddCell(celdaAfilVIT);
            tablaVitalicio.AddCell(celdaBenefVIT);
            #endregion

            #region TABLA VITALICIO ESPECIAL
            PdfPTable tablaVitalicioEspecial = new PdfPTable(6);
            tablaVitalicioEspecial.WidthPercentage = 100;
            tablaVitalicioEspecial.SpacingAfter = 10;
            tablaVitalicioEspecial.SpacingBefore = 10;
            tablaVitalicioEspecial.SetWidths(new float[] { 2f, 6f, 2f, 6f, 2f, 2f });
            PdfPCell celdaNsocioVIT_ESP = new PdfPCell(new Phrase("NºSOCIO", _mediumFontBoldWhite));
            PdfPCell celdaNombreVIT_ESP = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
            PdfPCell celdaFechaVIT_ESP = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            PdfPCell celdaDestinoVIT_ESP = new PdfPCell(new Phrase("DESTINO", _mediumFontBoldWhite));
            PdfPCell celdaAfilVIT_ESP = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
            PdfPCell celdaBenefVIT_ESP = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
            celdaNsocioVIT_ESP.BackgroundColor = topo;
            celdaNsocioVIT_ESP.BorderColor = blanco;
            celdaNsocioVIT_ESP.HorizontalAlignment = 1;
            celdaNsocioVIT_ESP.FixedHeight = 16f;
            celdaNombreVIT_ESP.BackgroundColor = topo;
            celdaNombreVIT_ESP.BorderColor = blanco;
            celdaNombreVIT_ESP.HorizontalAlignment = 1;
            celdaNombreVIT_ESP.FixedHeight = 16f;
            celdaFechaVIT_ESP.BackgroundColor = topo;
            celdaFechaVIT_ESP.BorderColor = blanco;
            celdaFechaVIT_ESP.HorizontalAlignment = 1;
            celdaFechaVIT_ESP.FixedHeight = 16f;
            celdaDestinoVIT_ESP.BackgroundColor = topo;
            celdaDestinoVIT_ESP.BorderColor = blanco;
            celdaDestinoVIT_ESP.HorizontalAlignment = 1;
            celdaDestinoVIT_ESP.FixedHeight = 16f;
            celdaAfilVIT_ESP.BackgroundColor = topo;
            celdaAfilVIT_ESP.BorderColor = blanco;
            celdaAfilVIT_ESP.HorizontalAlignment = 1;
            celdaAfilVIT_ESP.FixedHeight = 16f;
            celdaBenefVIT_ESP.BackgroundColor = topo;
            celdaBenefVIT_ESP.BorderColor = blanco;
            celdaBenefVIT_ESP.HorizontalAlignment = 1;
            celdaBenefVIT_ESP.FixedHeight = 16f;
            tablaVitalicioEspecial.AddCell(celdaNsocioVIT_ESP);
            tablaVitalicioEspecial.AddCell(celdaNombreVIT_ESP);
            tablaVitalicioEspecial.AddCell(celdaFechaVIT_ESP);
            tablaVitalicioEspecial.AddCell(celdaDestinoVIT_ESP);
            tablaVitalicioEspecial.AddCell(celdaAfilVIT_ESP);
            tablaVitalicioEspecial.AddCell(celdaBenefVIT_ESP);
            #endregion

            #region TABLA INVITADOS
            PdfPTable tablaInvitado = new PdfPTable(6);
            tablaInvitado.WidthPercentage = 100;
            tablaInvitado.SpacingAfter = 10;
            tablaInvitado.SpacingBefore = 10;
            tablaInvitado.SetWidths(new float[] { 2f, 6f, 2f, 6f, 2f, 2f });
            PdfPCell celdaNsocioINP = new PdfPCell(new Phrase("NºSOCIO", _mediumFontBoldWhite));
            PdfPCell celdaNombreINP = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
            PdfPCell celdaFechaINP = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            PdfPCell celdaDestinoINP = new PdfPCell(new Phrase("DESTINO", _mediumFontBoldWhite));
            PdfPCell celdaAfilINP = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
            PdfPCell celdaBenefINP = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
            celdaNsocioINP.BackgroundColor = topo;
            celdaNsocioINP.BorderColor = blanco;
            celdaNsocioINP.HorizontalAlignment = 1;
            celdaNsocioINP.FixedHeight = 16f;
            celdaNombreINP.BackgroundColor = topo;
            celdaNombreINP.BorderColor = blanco;
            celdaNombreINP.HorizontalAlignment = 1;
            celdaNombreINP.FixedHeight = 16f;
            celdaFechaINP.BackgroundColor = topo;
            celdaFechaINP.BorderColor = blanco;
            celdaFechaINP.HorizontalAlignment = 1;
            celdaFechaINP.FixedHeight = 16f;
            celdaDestinoINP.BackgroundColor = topo;
            celdaDestinoINP.BorderColor = blanco;
            celdaDestinoINP.HorizontalAlignment = 1;
            celdaDestinoINP.FixedHeight = 16f;
            celdaAfilINP.BackgroundColor = topo;
            celdaAfilINP.BorderColor = blanco;
            celdaAfilINP.HorizontalAlignment = 1;
            celdaAfilINP.FixedHeight = 16f;
            celdaBenefINP.BackgroundColor = topo;
            celdaBenefINP.BorderColor = blanco;
            celdaBenefINP.HorizontalAlignment = 1;
            celdaBenefINP.FixedHeight = 16f;
            tablaInvitado.AddCell(celdaNsocioINP);
            tablaInvitado.AddCell(celdaNombreINP);
            tablaInvitado.AddCell(celdaFechaINP);
            tablaInvitado.AddCell(celdaDestinoINP);
            tablaInvitado.AddCell(celdaAfilINP);
            tablaInvitado.AddCell(celdaBenefINP);
            #endregion

            #region TABLA INTERFUERZAS
            PdfPTable tablaInterfuerzas = new PdfPTable(6);
            tablaInterfuerzas.WidthPercentage = 100;
            tablaInterfuerzas.SpacingAfter = 10;
            tablaInterfuerzas.SpacingBefore = 10;
            tablaInterfuerzas.SetWidths(new float[] { 2f, 6f, 2f, 6f, 2f, 2f });
            PdfPCell celdaNsocioINT = new PdfPCell(new Phrase("NºSOCIO", _mediumFontBoldWhite));
            PdfPCell celdaNombreINT = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
            PdfPCell celdaFechaINT = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            PdfPCell celdaDestinoINT = new PdfPCell(new Phrase("DESTINO", _mediumFontBoldWhite));
            PdfPCell celdaAfilINT = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
            PdfPCell celdaBenefINT = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
            celdaNsocioINT.BackgroundColor = topo;
            celdaNsocioINT.BorderColor = blanco;
            celdaNsocioINT.HorizontalAlignment = 1;
            celdaNsocioINT.FixedHeight = 16f;
            celdaNombreINT.BackgroundColor = topo;
            celdaNombreINT.BorderColor = blanco;
            celdaNombreINT.HorizontalAlignment = 1;
            celdaNombreINT.FixedHeight = 16f;
            celdaFechaINT.BackgroundColor = topo;
            celdaFechaINT.BorderColor = blanco;
            celdaFechaINT.HorizontalAlignment = 1;
            celdaFechaINT.FixedHeight = 16f;
            celdaDestinoINT.BackgroundColor = topo;
            celdaDestinoINT.BorderColor = blanco;
            celdaDestinoINT.HorizontalAlignment = 1;
            celdaDestinoINT.FixedHeight = 16f;
            celdaAfilINT.BackgroundColor = topo;
            celdaAfilINT.BorderColor = blanco;
            celdaAfilINT.HorizontalAlignment = 1;
            celdaAfilINT.FixedHeight = 16f;
            celdaBenefINT.BackgroundColor = topo;
            celdaBenefINT.BorderColor = blanco;
            celdaBenefINT.HorizontalAlignment = 1;
            celdaBenefINT.FixedHeight = 16f;
            tablaInterfuerzas.AddCell(celdaNsocioINT);
            tablaInterfuerzas.AddCell(celdaNombreINT);
            tablaInterfuerzas.AddCell(celdaFechaINT);
            tablaInterfuerzas.AddCell(celdaDestinoINT);
            tablaInterfuerzas.AddCell(celdaAfilINT);
            tablaInterfuerzas.AddCell(celdaBenefINT);
            #endregion

            string NRO_SOC;
            string NOMBRE;
            DateTime FECHA;
            string DESTINO;
            string AFILIADO;
            string BENEFICIO;
            int TOTAL_ACTIVO = A_ACTIVOS + P_ACTIVOS;
            int TOTAL_ACTIVO_ESP = P_ACTIVOS_ESP;
            int TOTAL_ADHERENTE = A_ADHERENTES + P_ADHERENTES;
            int TOTAL_VITALICIO = A_VITALICIOS + P_VITALICIOS;
            int TOTAL_VITALICIO_ESP = P_VITALICIOS_ESP;
            int TOTAL_INVITADOS = A_INVITADOS + P_INVITADOS;
            int TOTAL_INTERFUERZAS = A_INTERFUERZAS + P_INTERFUERZAS;
            int TOTAL_MES = TOTAL_ACTIVO + TOTAL_ADHERENTE + TOTAL_VITALICIO + TOTAL_INVITADOS + TOTAL_ACTIVO_ESP + TOTAL_VITALICIO_ESP + TOTAL_INTERFUERZAS;
            int X = 0;
        
            #region ACTIVOS
            doc.NewPage();
            header(doc, MES, ANO, MES_CESE, ANO_CESE, _standardFontBold, writer);

            Paragraph tituloActivo = new Paragraph("CATEGORIA SOCIAL: ACTIVO", _standardFontBold);
            tituloActivo.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloActivo);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NRO_SOC = row[0].ToString() + "/" + row[1].ToString();
                NOMBRE = row[2].ToString().Trim() + ", " + row[3].ToString().Trim();

                if (NOMBRE.Length > 30)
                {
                    NOMBRE = NOMBRE.Substring(0, 30);
                }
                else
                {
                    NOMBRE = NOMBRE;
                }

                FECHA = DateTime.Parse(row[4].ToString());
                DESTINO = row[5].ToString().Trim();

                if (DESTINO.Length > 30)
                {
                    DESTINO = DESTINO.Substring(0, 30);
                }
                else
                {
                    DESTINO = DESTINO;
                }

                CAT_SOC = row[10].ToString();
                AFILIADO = row[6].ToString();
                BENEFICIO = row[7].ToString() + "/" + row[8].ToString() + "/" + row[9].ToString();
                TABLA = row[11].ToString().Trim();

                if (TABLA == "TITULAR" && CAT_SOC == "001")
                {
                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell valorNsocio = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    valorNsocio.HorizontalAlignment = 1;
                    valorNsocio.BorderWidth = 0;
                    valorNsocio.BackgroundColor = colorFondo;
                    valorNsocio.FixedHeight = 14f;
                    tablaActivo.AddCell(valorNsocio);

                    PdfPCell valorNombre = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    valorNombre.HorizontalAlignment = 0;
                    valorNombre.BorderWidth = 0;
                    valorNombre.BackgroundColor = colorFondo;
                    valorNombre.FixedHeight = 14f;
                    tablaActivo.AddCell(valorNombre);

                    PdfPCell valorFecha = new PdfPCell(new Phrase(FECHA.ToShortDateString(), _mediumFont));
                    valorFecha.HorizontalAlignment = 1;
                    valorFecha.BorderWidth = 0;
                    valorFecha.BackgroundColor = colorFondo;
                    valorFecha.FixedHeight = 14f;
                    tablaActivo.AddCell(valorFecha);

                    PdfPCell valorDestino = new PdfPCell(new Phrase(DESTINO, _mediumFont));
                    valorDestino.HorizontalAlignment = 0;
                    valorDestino.BorderWidth = 0;
                    valorDestino.BackgroundColor = colorFondo;
                    valorDestino.FixedHeight = 14f;
                    tablaActivo.AddCell(valorDestino);

                    PdfPCell valorAfiliado = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    valorAfiliado.HorizontalAlignment = 1;
                    valorAfiliado.BorderWidth = 0;
                    valorAfiliado.BackgroundColor = colorFondo;
                    valorAfiliado.FixedHeight = 14f;
                    tablaActivo.AddCell(valorAfiliado);

                    PdfPCell valorBeneficio = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    valorBeneficio.HorizontalAlignment = 1;
                    valorBeneficio.BorderWidth = 0;
                    valorBeneficio.BackgroundColor = colorFondo;
                    valorBeneficio.FixedHeight = 14f;
                    tablaActivo.AddCell(valorBeneficio);
                }
            }

            PdfPTable footActivo = new PdfPTable(1);
            footActivo.SpacingBefore = 5;
            footActivo.WidthPercentage = 100;
            
            PdfPCell cellTotalActivo = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS PARA LA CATEGORIA ACTIVO " + TOTAL_ACTIVO.ToString(), _standardFontBold));
            cellTotalActivo.BackgroundColor = gris;
            cellTotalActivo.BorderWidth = 0;
            cellTotalActivo.FixedHeight = 25f;
            cellTotalActivo.HorizontalAlignment = 1;

            PdfPCell cellTotalActivoA = new PdfPCell(new Phrase("ACTIVIDAD " + A_ACTIVOS.ToString() + " - PASIVIDAD " + P_ACTIVOS.ToString(), _standardFontBold));
            cellTotalActivoA.BackgroundColor = gris;
            cellTotalActivoA.BorderWidth = 0;
            cellTotalActivoA.FixedHeight = 25f;
            cellTotalActivoA.HorizontalAlignment = 1;

            footActivo.AddCell(cellTotalActivo);
            footActivo.AddCell(cellTotalActivoA);
            
            doc.Add(tablaActivo);
            doc.Add(footActivo);
            #endregion

            #region ACTIVOS ESPECIALES
            doc.NewPage();
            header(doc, MES, ANO, MES_CESE, ANO_CESE, _standardFontBold, writer);

            Paragraph tituloActivoEspecial = new Paragraph("CATEGORIA SOCIAL: ACTIVO ESPECIAL", _standardFontBold);
            tituloActivoEspecial.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloActivoEspecial);


            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NRO_SOC = row[0].ToString() + "/" + row[1].ToString();
                NOMBRE = row[2].ToString().Trim() + ", " + row[3].ToString().Trim();

                if (NOMBRE.Length > 30)
                {
                    NOMBRE = NOMBRE.Substring(0, 30);
                }
                else
                {
                    NOMBRE = NOMBRE;
                }

                FECHA = DateTime.Parse(row[4].ToString());
                DESTINO = row[5].ToString().Trim();

                if (DESTINO.Length > 30)
                {
                    DESTINO = DESTINO.Substring(0, 30);
                }
                else
                {
                    DESTINO = DESTINO;
                }

                CAT_SOC = row[10].ToString();
                AFILIADO = row[6].ToString();
                BENEFICIO = row[7].ToString() + "/" + row[8].ToString() + "/" + row[9].ToString();
                TABLA = row[11].ToString().Trim();

                if (TABLA == "TITULAR" && CAT_SOC == "003")
                {
                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell valorNsocio = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    valorNsocio.HorizontalAlignment = 1;
                    valorNsocio.BorderWidth = 0;
                    valorNsocio.BackgroundColor = colorFondo;
                    valorNsocio.FixedHeight = 14f;
                    tablaActivoEspecial.AddCell(valorNsocio);

                    PdfPCell valorNombre = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    valorNombre.HorizontalAlignment = 0;
                    valorNombre.BorderWidth = 0;
                    valorNombre.BackgroundColor = colorFondo;
                    valorNombre.FixedHeight = 14f;
                    tablaActivoEspecial.AddCell(valorNombre);

                    PdfPCell valorFecha = new PdfPCell(new Phrase(FECHA.ToShortDateString(), _mediumFont));
                    valorFecha.HorizontalAlignment = 1;
                    valorFecha.BorderWidth = 0;
                    valorFecha.BackgroundColor = colorFondo;
                    valorFecha.FixedHeight = 14f;
                    tablaActivoEspecial.AddCell(valorFecha);

                    PdfPCell valorDestino = new PdfPCell(new Phrase(DESTINO, _mediumFont));
                    valorDestino.HorizontalAlignment = 0;
                    valorDestino.BorderWidth = 0;
                    valorDestino.BackgroundColor = colorFondo;
                    valorDestino.FixedHeight = 14f;
                    tablaActivoEspecial.AddCell(valorDestino);

                    PdfPCell valorAfiliado = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    valorAfiliado.HorizontalAlignment = 1;
                    valorAfiliado.BorderWidth = 0;
                    valorAfiliado.BackgroundColor = colorFondo;
                    valorAfiliado.FixedHeight = 14f;
                    tablaActivoEspecial.AddCell(valorAfiliado);

                    PdfPCell valorBeneficio = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    valorBeneficio.HorizontalAlignment = 1;
                    valorBeneficio.BorderWidth = 0;
                    valorBeneficio.BackgroundColor = colorFondo;
                    valorBeneficio.FixedHeight = 14f;
                    tablaActivoEspecial.AddCell(valorBeneficio);
                }
            }

            PdfPTable footActivoEspecial = new PdfPTable(1);
            footActivoEspecial.SpacingBefore = 5;
            footActivoEspecial.WidthPercentage = 100;

            PdfPCell cellTotalActivoEspecial = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS PARA LA CATEGORIA ACTIVO ESPECIAL " + TOTAL_ACTIVO_ESP.ToString(), _standardFontBold));
            cellTotalActivoEspecial.BackgroundColor = gris;
            cellTotalActivoEspecial.BorderWidth = 0;
            cellTotalActivoEspecial.FixedHeight = 25f;
            cellTotalActivoEspecial.HorizontalAlignment = 1;

            footActivoEspecial.AddCell(cellTotalActivoEspecial);

            doc.Add(tablaActivoEspecial);
            doc.Add(footActivoEspecial);
            #endregion
            
            #region ADHERENTES
            doc.NewPage();
            header(doc, MES, ANO, MES_CESE, ANO_CESE, _standardFontBold, writer);

            Paragraph tituloAdherente = new Paragraph("CATEGORIA SOCIAL: ADHERENTE", _standardFontBold);
            tituloAdherente.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloAdherente);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NRO_SOC = row[0].ToString() + "/" + row[1].ToString();
                NOMBRE = row[2].ToString().Trim() + ", " + row[3].ToString().Trim();

                if (NOMBRE.Length > 30)
                {
                    NOMBRE = NOMBRE.Substring(0, 30);
                }
                else
                {
                    NOMBRE = NOMBRE;
                }

                FECHA = DateTime.Parse(row[4].ToString());
                DESTINO = row[5].ToString().Trim();

                if (DESTINO.Length > 30)
                {
                    DESTINO = DESTINO.Substring(0, 30);
                }
                else
                {
                    DESTINO = DESTINO;
                }

                CAT_SOC = row[10].ToString();
                AFILIADO = row[6].ToString();
                BENEFICIO = row[7].ToString() + "/" + row[8].ToString() + "/" + row[9].ToString();
                TABLA = row[11].ToString().Trim();

                if (TABLA == "ADHERENTE")
                {
                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell valorNsocioADH = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    valorNsocioADH.HorizontalAlignment = 1;
                    valorNsocioADH.BorderWidth = 0;
                    valorNsocioADH.BackgroundColor = colorFondo;
                    valorNsocioADH.FixedHeight = 14f;
                    tablaAdherente.AddCell(valorNsocioADH);

                    PdfPCell valorNombreADH = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    valorNombreADH.HorizontalAlignment = 0;
                    valorNombreADH.BorderWidth = 0;
                    valorNombreADH.BackgroundColor = colorFondo;
                    valorNombreADH.FixedHeight = 14f;
                    tablaAdherente.AddCell(valorNombreADH);

                    PdfPCell valorFechaADH = new PdfPCell(new Phrase(FECHA.ToShortDateString(), _mediumFont));
                    valorFechaADH.HorizontalAlignment = 1;
                    valorFechaADH.BorderWidth = 0;
                    valorFechaADH.BackgroundColor = colorFondo;
                    valorFechaADH.FixedHeight = 14f;
                    tablaAdherente.AddCell(valorFechaADH);

                    PdfPCell valorDestinoADH = new PdfPCell(new Phrase(DESTINO, _mediumFont));
                    valorDestinoADH.HorizontalAlignment = 0;
                    valorDestinoADH.BorderWidth = 0;
                    valorDestinoADH.BackgroundColor = colorFondo;
                    valorDestinoADH.FixedHeight = 14f;
                    tablaAdherente.AddCell(valorDestinoADH);

                    PdfPCell valorAfilADH = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    valorAfilADH.HorizontalAlignment = 1;
                    valorAfilADH.BorderWidth = 0;
                    valorAfilADH.BackgroundColor = colorFondo;
                    valorAfilADH.FixedHeight = 14f;
                    tablaAdherente.AddCell(valorAfilADH);

                    PdfPCell valorBenefADH = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    valorBenefADH.HorizontalAlignment = 1;
                    valorBenefADH.BorderWidth = 0;
                    valorBenefADH.BackgroundColor = colorFondo;
                    valorBenefADH.FixedHeight = 14f;
                    tablaAdherente.AddCell(valorBenefADH);
                }
            }

            PdfPTable footAdh = new PdfPTable(1);
            footAdh.SpacingBefore = 5;
            footAdh.WidthPercentage = 100;
            
            PdfPCell cellTotalAdh = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS PARA LA CATEGORIA ADHERENTE " + TOTAL_ADHERENTE.ToString(), _standardFontBold));
            cellTotalAdh.BackgroundColor = gris;
            cellTotalAdh.FixedHeight = 25f;
            cellTotalAdh.HorizontalAlignment = 1;
            cellTotalAdh.BorderWidth = 0;

            PdfPCell cellTotalAdhA = new PdfPCell(new Phrase("ACTIVIDAD " + A_ADHERENTES.ToString() + " - PASIVIDAD " + P_ADHERENTES.ToString(), _standardFontBold));
            cellTotalAdhA.BackgroundColor = gris;
            cellTotalAdhA.FixedHeight = 25f;
            cellTotalAdhA.HorizontalAlignment = 1;
            cellTotalAdhA.BorderWidth = 0;

            footAdh.AddCell(cellTotalAdh);
            footAdh.AddCell(cellTotalAdhA);
            
            doc.Add(tablaAdherente);
            doc.Add(footAdh);
#endregion

            #region VITALICIOS
            doc.NewPage();
            header(doc, MES, ANO, MES_CESE, ANO_CESE, _standardFontBold, writer);

            Paragraph tituloVitalicio = new Paragraph("CATEGORIA SOCIAL: VITALICIOS", _standardFontBold);
            tituloVitalicio.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloVitalicio);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NRO_SOC = row[0].ToString() + "/" + row[1].ToString();
                NOMBRE = row[2].ToString().Trim() + ", " + row[3].ToString().Trim();

                if (NOMBRE.Length > 30)
                {
                    NOMBRE = NOMBRE.Substring(0, 30);
                }
                else
                {
                    NOMBRE = NOMBRE;
                }

                FECHA = DateTime.Parse(row[4].ToString());
                DESTINO = row[5].ToString().Trim();

                if (DESTINO.Length > 30)
                {
                    DESTINO = DESTINO.Substring(0, 30);
                }
                else
                {
                    DESTINO = DESTINO;
                }

                CAT_SOC = row[10].ToString();
                AFILIADO = row[6].ToString();
                BENEFICIO = row[7].ToString() + "/" + row[8].ToString() + "/" + row[9].ToString();
                TABLA = row[11].ToString().Trim();

                if (TABLA == "TITULAR" && CAT_SOC == "002")
                {
                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell valorNsocioVIT = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    valorNsocioVIT.HorizontalAlignment = 1;
                    valorNsocioVIT.BorderWidth = 0;
                    valorNsocioVIT.BackgroundColor = colorFondo;
                    valorNsocioVIT.FixedHeight = 14f;
                    tablaVitalicio.AddCell(valorNsocioVIT);

                    PdfPCell valorNombreVIT = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    valorNombreVIT.HorizontalAlignment = 0;
                    valorNombreVIT.BorderWidth = 0;
                    valorNombreVIT.BackgroundColor = colorFondo;
                    valorNombreVIT.FixedHeight = 14f;
                    tablaVitalicio.AddCell(valorNombreVIT);

                    PdfPCell valorFechaVIT = new PdfPCell(new Phrase(FECHA.ToShortDateString(), _mediumFont));
                    valorFechaVIT.HorizontalAlignment = 1;
                    valorFechaVIT.BorderWidth = 0;
                    valorFechaVIT.BackgroundColor = colorFondo;
                    valorFechaVIT.FixedHeight = 14f;
                    tablaVitalicio.AddCell(valorFechaVIT);

                    PdfPCell valorDestinoVIT = new PdfPCell(new Phrase(DESTINO, _mediumFont));
                    valorDestinoVIT.HorizontalAlignment = 0;
                    valorDestinoVIT.BorderWidth = 0;
                    valorDestinoVIT.BackgroundColor = colorFondo;
                    valorDestinoVIT.FixedHeight = 14f;
                    tablaVitalicio.AddCell(valorDestinoVIT);

                    PdfPCell valorAfilVIT = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    valorAfilVIT.HorizontalAlignment = 1;
                    valorAfilVIT.BorderWidth = 0;
                    valorAfilVIT.BackgroundColor = colorFondo;
                    valorAfilVIT.FixedHeight = 14f;
                    tablaVitalicio.AddCell(valorAfilVIT);

                    PdfPCell valorBenefVIT = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    valorBenefVIT.HorizontalAlignment = 1;
                    valorBenefVIT.BorderWidth = 0;
                    valorBenefVIT.BackgroundColor = colorFondo;
                    valorBenefVIT.FixedHeight = 14f;
                    tablaVitalicio.AddCell(valorBenefVIT);
                }
            }

            PdfPTable footVit = new PdfPTable(1);
            footVit.SpacingBefore = 5;
            footVit.WidthPercentage = 100;
            
            PdfPCell cellTotalVit = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS PARA LA CATEGORIA VITALICIO " + TOTAL_VITALICIO, _standardFontBold));
            cellTotalVit.BackgroundColor = gris;
            cellTotalVit.BorderWidth = 0;
            cellTotalVit.FixedHeight = 25f;
            cellTotalVit.HorizontalAlignment = 1;

            PdfPCell cellTotalVitA = new PdfPCell(new Phrase("ACTIVIDAD " + A_VITALICIOS + " - PASIVIDAD " + P_VITALICIOS, _standardFontBold));
            cellTotalVitA.BackgroundColor = gris;
            cellTotalVitA.BorderWidth = 0;
            cellTotalVitA.FixedHeight = 25f;
            cellTotalVitA.HorizontalAlignment = 1;

            footVit.AddCell(cellTotalVit);
            footVit.AddCell(cellTotalVitA);
            
            doc.Add(tablaVitalicio);
            doc.Add(footVit);
            #endregion

            #region VITALICIOS ESPECIALES
            doc.NewPage();
            header(doc, MES, ANO, MES_CESE, ANO_CESE, _standardFontBold, writer);

            Paragraph tituloVitalicioEspecial = new Paragraph("CATEGORIA SOCIAL: VITALICIOS ESPECIALES", _standardFontBold);
            tituloVitalicioEspecial.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloVitalicioEspecial);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NRO_SOC = row[0].ToString() + "/" + row[1].ToString();
                NOMBRE = row[2].ToString().Trim() + ", " + row[3].ToString().Trim();

                if (NOMBRE.Length > 30)
                {
                    NOMBRE = NOMBRE.Substring(0, 30);
                }
                else
                {
                    NOMBRE = NOMBRE;
                }

                FECHA = DateTime.Parse(row[4].ToString());
                DESTINO = row[5].ToString().Trim();

                if (DESTINO.Length > 30)
                {
                    DESTINO = DESTINO.Substring(0, 30);
                }
                else
                {
                    DESTINO = DESTINO;
                }

                CAT_SOC = row[10].ToString();
                AFILIADO = row[6].ToString();
                BENEFICIO = row[7].ToString() + "/" + row[8].ToString() + "/" + row[9].ToString();
                TABLA = row[11].ToString().Trim();

                if (TABLA == "TITULAR" && CAT_SOC == "004")
                {
                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell valorNsocioVIT = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    valorNsocioVIT.HorizontalAlignment = 1;
                    valorNsocioVIT.BorderWidth = 0;
                    valorNsocioVIT.BackgroundColor = colorFondo;
                    valorNsocioVIT.FixedHeight = 14f;
                    tablaVitalicioEspecial.AddCell(valorNsocioVIT);

                    PdfPCell valorNombreVIT = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    valorNombreVIT.HorizontalAlignment = 0;
                    valorNombreVIT.BorderWidth = 0;
                    valorNombreVIT.BackgroundColor = colorFondo;
                    valorNombreVIT.FixedHeight = 14f;
                    tablaVitalicioEspecial.AddCell(valorNombreVIT);

                    PdfPCell valorFechaVIT = new PdfPCell(new Phrase(FECHA.ToShortDateString(), _mediumFont));
                    valorFechaVIT.HorizontalAlignment = 1;
                    valorFechaVIT.BorderWidth = 0;
                    valorFechaVIT.BackgroundColor = colorFondo;
                    valorFechaVIT.FixedHeight = 14f;
                    tablaVitalicioEspecial.AddCell(valorFechaVIT);

                    PdfPCell valorDestinoVIT = new PdfPCell(new Phrase(DESTINO, _mediumFont));
                    valorDestinoVIT.HorizontalAlignment = 0;
                    valorDestinoVIT.BorderWidth = 0;
                    valorDestinoVIT.BackgroundColor = colorFondo;
                    valorDestinoVIT.FixedHeight = 14f;
                    tablaVitalicioEspecial.AddCell(valorDestinoVIT);

                    PdfPCell valorAfilVIT = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    valorAfilVIT.HorizontalAlignment = 1;
                    valorAfilVIT.BorderWidth = 0;
                    valorAfilVIT.BackgroundColor = colorFondo;
                    valorAfilVIT.FixedHeight = 14f;
                    tablaVitalicioEspecial.AddCell(valorAfilVIT);

                    PdfPCell valorBenefVIT = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    valorBenefVIT.HorizontalAlignment = 1;
                    valorBenefVIT.BorderWidth = 0;
                    valorBenefVIT.BackgroundColor = colorFondo;
                    valorBenefVIT.FixedHeight = 14f;
                    tablaVitalicioEspecial.AddCell(valorBenefVIT);
                }
            }

            PdfPTable footVitEsp = new PdfPTable(1);
            footVitEsp.SpacingBefore = 5;
            footVitEsp.WidthPercentage = 100;

            PdfPCell cellTotalVitEsp = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS PARA LA CATEGORIA VITALICIO ESPECIAL " + TOTAL_VITALICIO_ESP, _standardFontBold));
            cellTotalVitEsp.BackgroundColor = gris;
            cellTotalVitEsp.BorderWidth = 0;
            cellTotalVitEsp.FixedHeight = 25f;
            cellTotalVitEsp.HorizontalAlignment = 1;

            footVitEsp.AddCell(cellTotalVitEsp);

            doc.Add(tablaVitalicioEspecial);
            doc.Add(footVitEsp);
            #endregion

            #region INVITADOS PARTICIPATIVOS
            doc.NewPage();
            header(doc, MES, ANO, MES_CESE, ANO_CESE, _standardFontBold, writer);
            Paragraph tituloInvitados = new Paragraph("CATEGORIA SOCIAL: INVITADOS", _standardFontBold);
            tituloInvitados.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloInvitados);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NRO_SOC = row[0].ToString() + "/" + row[1].ToString();
                NOMBRE = row[2].ToString().Trim() + ", " + row[3].ToString().Trim();

                if (NOMBRE.Length > 30)
                {
                    NOMBRE = NOMBRE.Substring(0, 30);
                }
                else
                {
                    NOMBRE = NOMBRE;
                }

                FECHA = DateTime.Parse(row[4].ToString());
                DESTINO = row[5].ToString().Trim();

                if (DESTINO.Length > 30)
                {
                    DESTINO = DESTINO.Substring(0, 30);
                }
                else
                {
                    DESTINO = DESTINO;
                }

                CAT_SOC = row[10].ToString();
                AFILIADO = row[6].ToString();
                BENEFICIO = row[7].ToString() + "/" + row[8].ToString() + "/" + row[9].ToString();
                TABLA = row[11].ToString().Trim();

                if (TABLA == "TITULAR" && CAT_SOC == "006")
                {
                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell valorNsocioINP = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    valorNsocioINP.HorizontalAlignment = 1;
                    valorNsocioINP.BorderWidth = 0;
                    valorNsocioINP.BackgroundColor = colorFondo;
                    valorNsocioINP.FixedHeight = 14f;
                    tablaInvitado.AddCell(valorNsocioINP);

                    PdfPCell valorNombreINP = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    valorNombreINP.HorizontalAlignment = 0;
                    valorNombreINP.BorderWidth = 0;
                    valorNombreINP.BackgroundColor = colorFondo;
                    valorNombreINP.FixedHeight = 14f;
                    tablaInvitado.AddCell(valorNombreINP);

                    PdfPCell valorFechaINP = new PdfPCell(new Phrase(FECHA.ToShortDateString(), _mediumFont));
                    valorFechaINP.HorizontalAlignment = 1;
                    valorFechaINP.BorderWidth = 0;
                    valorFechaINP.BackgroundColor = colorFondo;
                    valorFechaINP.FixedHeight = 14f;
                    tablaInvitado.AddCell(valorFechaINP);

                    PdfPCell valorDestinoINP = new PdfPCell(new Phrase(DESTINO, _mediumFont));
                    valorDestinoINP.HorizontalAlignment = 0;
                    valorDestinoINP.BorderWidth = 0;
                    valorDestinoINP.BackgroundColor = colorFondo;
                    valorDestinoINP.FixedHeight = 14f;
                    tablaInvitado.AddCell(valorDestinoINP);

                    PdfPCell valorAfiliadoINP = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    valorAfiliadoINP.HorizontalAlignment = 1;
                    valorAfiliadoINP.BorderWidth = 0;
                    valorAfiliadoINP.BackgroundColor = colorFondo;
                    valorAfiliadoINP.FixedHeight = 14f;
                    tablaInvitado.AddCell(valorAfiliadoINP);

                    PdfPCell valorBeneficioINP = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    valorBeneficioINP.HorizontalAlignment = 1;
                    valorBeneficioINP.BorderWidth = 0;
                    valorBeneficioINP.BackgroundColor = colorFondo;
                    valorBeneficioINP.FixedHeight = 14f;
                    tablaInvitado.AddCell(valorBeneficioINP);
                }
            }
            
            PdfPTable footInvitado = new PdfPTable(1);
            footInvitado.SpacingBefore = 5;
            footInvitado.WidthPercentage = 100;

            PdfPCell cellTotalInvitado = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS PARA LA CATEGORIA SOCIO INVITADO " + TOTAL_INVITADOS.ToString(), _standardFontBold));
            cellTotalInvitado.BackgroundColor = gris;
            cellTotalInvitado.BorderWidth = 0;
            cellTotalInvitado.FixedHeight = 25f;
            cellTotalInvitado.HorizontalAlignment = 1;

            PdfPCell cellTotalInvitadoA = new PdfPCell(new Phrase("ACTIVIDAD " + A_INVITADOS.ToString() + " - PASIVIDAD " + P_INVITADOS.ToString(), _standardFontBold));
            cellTotalInvitadoA.BackgroundColor = gris;
            cellTotalInvitadoA.BorderWidth = 0;
            cellTotalInvitadoA.FixedHeight = 25f;
            cellTotalInvitadoA.HorizontalAlignment = 1;

            footInvitado.AddCell(cellTotalInvitado);
            footInvitado.AddCell(cellTotalInvitadoA);
            doc.Add(tablaInvitado);
            doc.Add(footInvitado);
            #endregion

            #region ADH INTERFUERZAS
            doc.NewPage();
            header(doc, MES, ANO, MES_CESE, ANO_CESE, _standardFontBold, writer);
            Paragraph tituloInterfuerzas = new Paragraph("CATEGORIA SOCIAL: ADH INTERFUERZAS", _standardFontBold);
            tituloInterfuerzas.Alignment = Element.ALIGN_CENTER;
            doc.Add(tituloInterfuerzas);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NRO_SOC = row[0].ToString() + "/" + row[1].ToString();
                NOMBRE = row[2].ToString().Trim() + ", " + row[3].ToString().Trim();

                if (NOMBRE.Length > 30)
                {
                    NOMBRE = NOMBRE.Substring(0, 30);
                }
                else
                {
                    NOMBRE = NOMBRE;
                }

                FECHA = DateTime.Parse(row[4].ToString());
                DESTINO = row[5].ToString().Trim();

                if (DESTINO.Length > 30)
                {
                    DESTINO = DESTINO.Substring(0, 30);
                }
                else
                {
                    DESTINO = DESTINO;
                }

                CAT_SOC = row[10].ToString();
                AFILIADO = row[6].ToString();
                BENEFICIO = row[7].ToString() + "/" + row[8].ToString() + "/" + row[9].ToString();
                TABLA = row[11].ToString().Trim();

                if (TABLA == "TITULAR" && CAT_SOC == "015")
                {
                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell valorNsocioINT = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    valorNsocioINT.HorizontalAlignment = 1;
                    valorNsocioINT.BorderWidth = 0;
                    valorNsocioINT.BackgroundColor = colorFondo;
                    valorNsocioINT.FixedHeight = 14f;
                    tablaInterfuerzas.AddCell(valorNsocioINT);

                    PdfPCell valorNombreINT = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    valorNombreINT.HorizontalAlignment = 0;
                    valorNombreINT.BorderWidth = 0;
                    valorNombreINT.BackgroundColor = colorFondo;
                    valorNombreINT.FixedHeight = 14f;
                    tablaInterfuerzas.AddCell(valorNombreINT);

                    PdfPCell valorFechaINT = new PdfPCell(new Phrase(FECHA.ToShortDateString(), _mediumFont));
                    valorFechaINT.HorizontalAlignment = 1;
                    valorFechaINT.BorderWidth = 0;
                    valorFechaINT.BackgroundColor = colorFondo;
                    valorFechaINT.FixedHeight = 14f;
                    tablaInterfuerzas.AddCell(valorFechaINT);

                    PdfPCell valorDestinoINT = new PdfPCell(new Phrase(DESTINO, _mediumFont));
                    valorDestinoINT.HorizontalAlignment = 0;
                    valorDestinoINT.BorderWidth = 0;
                    valorDestinoINT.BackgroundColor = colorFondo;
                    valorDestinoINT.FixedHeight = 14f;
                    tablaInterfuerzas.AddCell(valorDestinoINT);

                    PdfPCell valorAfiliadoINT = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    valorAfiliadoINT.HorizontalAlignment = 1;
                    valorAfiliadoINT.BorderWidth = 0;
                    valorAfiliadoINT.BackgroundColor = colorFondo;
                    valorAfiliadoINT.FixedHeight = 14f;
                    tablaInterfuerzas.AddCell(valorAfiliadoINT);

                    PdfPCell valorBeneficioINT = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    valorBeneficioINT.HorizontalAlignment = 1;
                    valorBeneficioINT.BorderWidth = 0;
                    valorBeneficioINT.BackgroundColor = colorFondo;
                    valorBeneficioINT.FixedHeight = 14f;
                    tablaInterfuerzas.AddCell(valorBeneficioINT);
                }
            }

            PdfPTable footInterfuerzas = new PdfPTable(1);
            footInterfuerzas.SpacingBefore = 5;
            footInterfuerzas.WidthPercentage = 100;

            PdfPCell cellTotalInterfuerzas = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS PARA LA CATEGORIA ADH INTERFUERZAS " + TOTAL_INTERFUERZAS.ToString(), _standardFontBold));
            cellTotalInterfuerzas.BackgroundColor = gris;
            cellTotalInterfuerzas.BorderWidth = 0;
            cellTotalInterfuerzas.FixedHeight = 25f;
            cellTotalInterfuerzas.HorizontalAlignment = 1;

            PdfPCell cellTotalInterfuerzasA = new PdfPCell(new Phrase("ACTIVIDAD " + A_INTERFUERZAS.ToString() + " - PASIVIDAD " + P_INTERFUERZAS.ToString(), _standardFontBold));
            cellTotalInterfuerzasA.BackgroundColor = gris;
            cellTotalInterfuerzasA.BorderWidth = 0;
            cellTotalInterfuerzasA.FixedHeight = 25f;
            cellTotalInterfuerzasA.HorizontalAlignment = 1;

            footInterfuerzas.AddCell(cellTotalInterfuerzas);
            footInterfuerzas.AddCell(cellTotalInterfuerzasA);
            doc.Add(tablaInterfuerzas);
            doc.Add(footInterfuerzas);
            #endregion
            
            #region FOOT TOTAL DEL MES
            PdfPTable footTotalMes = new PdfPTable(1);
            footTotalMes.SpacingBefore = 15;
            footTotalMes.WidthPercentage = 100;
            PdfPCell cellTotalMes = new PdfPCell(new Phrase("TOTAL DE RENUNCIAS PARA EL MES " + TOTAL_MES.ToString(), _standardFontBold));
            cellTotalMes.BackgroundColor = gris;
            cellTotalMes.BorderWidth = 0;
            cellTotalMes.FixedHeight = 25f;
            cellTotalMes.HorizontalAlignment = 1;
            footTotalMes.AddCell(cellTotalMes);
            doc.Add(footTotalMes);
            #endregion

            doc.Close();
            writer.Close();
        }

        public void excel(DataSet ds, string path)
        {
            string data = null;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];
            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;
            xlWorkSheet.Cells[1, 1] = "NRO_SOC";
            xlWorkSheet.Cells[1, 2] = "NRO_DEP";
            xlWorkSheet.Cells[1, 3] = "APE_SOC";
            xlWorkSheet.Cells[1, 4] = "NOM_SOC";
            xlWorkSheet.Cells[1, 5] = "F_BAJCI";
            xlWorkSheet.Cells[1, 6] = "DESTINO";
            xlWorkSheet.Cells[1, 7] = "ACRJP2";
            xlWorkSheet.Cells[1, 8] = "PCRJP1";
            xlWorkSheet.Cells[1, 9] = "PCRJP2";
            xlWorkSheet.Cells[1, 10] = "PCRJP3";
            xlWorkSheet.Cells[1, 11] = "CAT_SOC";
            xlWorkSheet.Cells[1, 12] = "TABLA";

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                    xlWorkSheet.Columns[5].EntireColumn.NumberFormat = "DD/MM/AAAA";
                    xlWorkSheet.Columns[11].EntireColumn.NumberFormat = "000";
                }
            }

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        static void OpenMicrosoftExcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        static void OpenAdobeAcrobat(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ACRORD32.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        public void buscarRenuncias(string DOC)
        {
            Cursor = Cursors.WaitCursor;
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    
                    string dia_desde = dpDesde.Text.Substring(0, 2);
                    string mes_desde = dpDesde.Text.Substring(3, 2);
                    string ano_desde = dpDesde.Text.Substring(6, 4);
                    string fecha_desde = mes_desde + "/" + dia_desde + "/" + ano_desde;

                    string dia_hasta = dpHasta.Text.Substring(0, 2);
                    string mes_hasta = dpHasta.Text.Substring(3, 2);
                    string ano_hasta = dpHasta.Text.Substring(6, 4);
                    string fecha_hasta = mes_hasta + "/" + dia_hasta + "/" + ano_hasta;

                    DataSet ds = new DataSet();
                    string query = "SELECT * FROM P_RENUNCIAS_CSPFA ('" + fecha_desde + "', '" + fecha_hasta + "')";
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);
                    
                    try
                    {
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (DOC == "EXCEL")
                                {
                                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                                    saveFileDialog1.Filter = "Archivo XLS|*.xls";
                                    saveFileDialog1.Title = "Guardar Listado";

                                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                    {
                                        excel(ds, saveFileDialog1.FileName);
                                        DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                                        if (result == DialogResult.Yes)
                                        {
                                            OpenMicrosoftExcel(saveFileDialog1.FileName);
                                        }
                                    }
                                }

                                if (DOC == "PDF")
                                {
                                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                                    saveFileDialog1.Filter = "Archivo PDF|*.pdf";
                                    saveFileDialog1.Title = "Guardar Listado";

                                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                    {
                                        pdf(ds, saveFileDialog1.FileName);
                                        DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                                        if (result == DialogResult.Yes)
                                        {
                                            OpenAdobeAcrobat(saveFileDialog1.FileName);
                                        }
                                    }
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }

                        Cursor = Cursors.Default;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
