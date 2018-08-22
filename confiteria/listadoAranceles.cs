using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Confiteria
{
    public partial class listadoAranceles : Form
    {
        public listadoAranceles()
        {
            InitializeComponent();
        }

        private void mostrarAranceles(DataSet ds)
        {
            dgListadoAranceles.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string DETALLE = row[0].ToString().Trim();
                string NOMBRE = row[1].ToString().Trim();
                string ARANCEL = row[2].ToString().Trim();
                dgListadoAranceles.Rows.Add(DETALLE, NOMBRE, ARANCEL);
            }
        }

        private void buscarAranceles()
        {
            try
            {
                SOCIOS.conString conString = new SOCIOS.conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string query = "SELECT * FROM CONFITERIA_ARANCELES;";
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mostrarAranceles(ds);
                        }
                        else
                        {
                            MessageBox.Show("NO SE ENCONTRARON RESULTADOS", "OUCH!");
                        }
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO OBTENER EL DATO\n " + error, "ERROR");
            }
        }

        private void listadoAranceles_Load(object sender, EventArgs e)
        {
            buscarAranceles();
        }

        static void OpenAdobeAcrobat(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ACRORD32.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        private void listadoPDF(string RUTA)
        {
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _standardFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

            BaseColor negro = new BaseColor(0, 0, 0);
            BaseColor gris = new BaseColor(230, 230, 230);
            BaseColor topo = new BaseColor(100, 100, 100);
            BaseColor blanco = new BaseColor(255, 255, 255);

            Document doc = new Document(PageSize.A4);
            //doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(RUTA, FileMode.Create));
            doc.AddTitle("LISTADO ARANCELES COMEDOR CSPFA");
            doc.AddCreator("CSPFA");
            doc.Open();

            Paragraph header = new Paragraph("LISTADO ARANCELES COMEDOR CSPFA", _standardFontBold);
            header.Alignment = Element.ALIGN_CENTER;
            header.SpacingAfter = 5;
            doc.Add(header);

            PdfPTable TABLA_ARANCELES = new PdfPTable(3);
            TABLA_ARANCELES.WidthPercentage = 100;
            TABLA_ARANCELES.SpacingAfter = 5;
            TABLA_ARANCELES.SpacingBefore = 5;
            TABLA_ARANCELES.SetWidths(new float[] { 1f, 1f, 1f });

            PdfPCell CELDA_TIPO = new PdfPCell(new Phrase("TIPO", _mediumFontBoldWhite));
            CELDA_TIPO.BackgroundColor = topo;
            CELDA_TIPO.BorderColor = blanco;
            CELDA_TIPO.HorizontalAlignment = 1;
            CELDA_TIPO.FixedHeight = 16f;
            TABLA_ARANCELES.AddCell(CELDA_TIPO);

            PdfPCell CELDA_NOMBRE = new PdfPCell(new Phrase("NOMBRE", _mediumFontBoldWhite));
            CELDA_NOMBRE.BackgroundColor = topo;
            CELDA_NOMBRE.BorderColor = blanco;
            CELDA_NOMBRE.HorizontalAlignment = 1;
            CELDA_NOMBRE.FixedHeight = 16f;
            TABLA_ARANCELES.AddCell(CELDA_NOMBRE);

            PdfPCell CELDA_ARANCEL = new PdfPCell(new Phrase("ARANCEL", _mediumFontBoldWhite));
            CELDA_ARANCEL.BackgroundColor = topo;
            CELDA_ARANCEL.BorderColor = blanco;
            CELDA_ARANCEL.HorizontalAlignment = 1;
            CELDA_ARANCEL.FixedHeight = 16f;
            TABLA_ARANCELES.AddCell(CELDA_ARANCEL);

            if (dgListadoAranceles.Rows.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                foreach (DataGridViewRow row in dgListadoAranceles.Rows)
                {
                    string TIPO = row.Cells[0].Value.ToString();
                    string NOMBRE = row.Cells[1].Value.ToString();
                    string ARANCEL = row.Cells[2].Value.ToString();

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

                    PdfPCell CELL_TIPO = new PdfPCell(new Phrase(TIPO, _mediumFont));
                    CELL_TIPO.HorizontalAlignment = 1;
                    CELL_TIPO.BorderWidth = 0;
                    CELL_TIPO.BackgroundColor = colorFondo;
                    CELL_TIPO.FixedHeight = 14f;
                    TABLA_ARANCELES.AddCell(CELL_TIPO);

                    PdfPCell CELL_NOMBRE = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    CELL_NOMBRE.HorizontalAlignment = 1;
                    CELL_NOMBRE.BorderWidth = 0;
                    CELL_NOMBRE.BackgroundColor = colorFondo;
                    CELL_NOMBRE.FixedHeight = 14f;
                    TABLA_ARANCELES.AddCell(CELL_NOMBRE);

                    PdfPCell CELL_ARANCEL = new PdfPCell(new Phrase(ARANCEL, _mediumFont));
                    CELL_ARANCEL.HorizontalAlignment = 1;
                    CELL_ARANCEL.BorderWidth = 0;
                    CELL_ARANCEL.BackgroundColor = colorFondo;
                    CELL_ARANCEL.FixedHeight = 14f;
                    TABLA_ARANCELES.AddCell(CELL_ARANCEL);
                }
            }

            doc.Add(TABLA_ARANCELES);
            doc.Close();
            writer.Close();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string RUTA = saveFileDialog1.FileName;
                listadoPDF(RUTA);

                DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OpenAdobeAcrobat(RUTA);
                }
            }
        }

        private void btnExportarXls_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.Filter = "Archivo XLS|*.xls";
                saveFileDialog1.Title = "Guardar Listado";
                string RUTA = saveFileDialog1.FileName;
                listadoExcel(RUTA);
                DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE", "LISTO!", MessageBoxButtons.YesNo);
            }
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

        private void listadoExcel(string RUTA)
        {
            if (dgListadoAranceles.Rows.Count > 0)
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet ARANCELES;
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add();
                ARANCELES = xlWorkBook.Worksheets[1];
                ARANCELES.Name = "ARANCELES";
                ARANCELES.Cells[1, 1] = "TIPO";
                ARANCELES.Cells[1, 2] = "NOMBRE";
                ARANCELES.Cells[1, 2] = "ARANCEL";
                int X = 2;

                foreach (DataGridViewRow row in dgListadoAranceles.Rows)
                {
                    string TIPO = row.Cells[0].Value.ToString();
                    string NOMBRE = row.Cells[1].Value.ToString();
                    string ARANCEL = row.Cells[2].Value.ToString();
                    ARANCELES.Cells[X, 1] = TIPO;
                    ARANCELES.Columns[1].AutoFit();
                    ARANCELES.Cells[X, 2] = NOMBRE;
                    ARANCELES.Columns[2].AutoFit();
                    ARANCELES.Cells[X, 3] = DETALLE;
                    ARANCELES.Columns[3].AutoFit();
                }

                xlWorkBook.SaveAs(RUTA, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(ARANCELES);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }  
        }
    }
}
