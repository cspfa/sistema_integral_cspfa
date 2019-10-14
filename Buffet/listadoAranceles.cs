using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using SOCIOS;
using System.Data.OleDb;

namespace Buffet
{
    public partial class listadoAranceles : Form
    {
        bo dlog = new bo();
        Utils utils = new Utils();
        imprimir print = new imprimir();

        public listadoAranceles()
        {
            InitializeComponent();
            comboCategorias(VGlobales.vp_role);
        }

        public void comboCategorias(string ROL)
        {
            cbCategoria.DataSource = null;
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = 'MENU " + ROL + "' AND ESTADO = 1 ORDER BY DETALLE;";
            cbCategoria.Items.Clear();
            cbCategoria.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCategoria.DisplayMember = "DETALLE";
            cbCategoria.ValueMember = "ID";
            cbCategoria.SelectedIndex = 0;
        }

        private void mostrarAranceles(DataSet ds)
        {
            dgListadoAranceles.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string DETALLE = row[0].ToString().Trim();
                string NOMBRE = row[1].ToString().Trim();
                string ARANCEL = row[2].ToString().Trim();
                int STOCK = Convert.ToInt32(row[3]);
                int ID = Convert.ToInt32(row[4]);
                string BARCODE = row[5].ToString().Trim();
                dgListadoAranceles.Rows.Add(ID, DETALLE, NOMBRE, ARANCEL, STOCK, BARCODE);
            }
        }

        private void buscarAranceles(string CATEGORIA, string BARCODE = null)
        {
            try
            {
                SOCIOS.conString conString = new SOCIOS.conString();
                string connectionString = conString.get();
                string ROLE = "MENU " + VGlobales.vp_role;

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string query = "SELECT S.DETALLE, P.NOMBRE, A.ARANCEL, COALESCE(P.STOCK, 0), P.ID, P.BARCODE FROM ARANCELES A, SECTACT S, PROFESIONALES P WHERE A.PROFESIONAL = P.ID ";
                    query += "AND A.SECTACT = S.ID AND S.ROL = '" + ROLE + "' AND A.FE_BAJA IS NULL AND A.CATSOC = '001' ORDER BY S.DETALLE ASC, P.NOMBRE ASC;";

                    if (CATEGORIA !="X")
                    {
                        query = "SELECT S.DETALLE, P.NOMBRE, A.ARANCEL, COALESCE(P.STOCK, 0), P.ID, P.BARCODE FROM ARANCELES A, SECTACT S, PROFESIONALES P WHERE A.PROFESIONAL = P.ID ";
                        query += "AND A.SECTACT = S.ID AND S.ROL = '" + ROLE + "' AND S.DETALLE = '" + CATEGORIA + "' AND A.FE_BAJA IS NULL AND A.CATSOC = '001' ORDER BY S.DETALLE ASC, P.NOMBRE ASC;";
                    }

                    if (BARCODE != null)
                    {
                        query = "SELECT S.DETALLE, P.NOMBRE, A.ARANCEL, COALESCE(P.STOCK, 0), P.ID, P.BARCODE FROM ARANCELES A, SECTACT S, PROFESIONALES P WHERE A.PROFESIONAL = P.ID ";
                        query += "AND A.SECTACT = S.ID AND S.ROL = '" + ROLE + "' AND P.BARCODE = '" + BARCODE + "' AND A.FE_BAJA IS NULL AND A.CATSOC = '001' ORDER BY S.DETALLE ASC, P.NOMBRE ASC;";
                    }

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
            buscarAranceles("X");
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
            doc.AddTitle("LISTADO ARANCELES COMEDOR " + VGlobales.vp_role);
            doc.AddCreator("CSPFA");
            doc.Open();

            Paragraph header = new Paragraph("LISTADO ARANCELES COMEDOR " + VGlobales.vp_role, _standardFontBold);
            header.Alignment = Element.ALIGN_CENTER;
            header.SpacingAfter = 5;
            doc.Add(header);

            PdfPTable TABLA_ARANCELES = new PdfPTable(5);
            TABLA_ARANCELES.WidthPercentage = 100;
            TABLA_ARANCELES.SpacingAfter = 5;
            TABLA_ARANCELES.SpacingBefore = 5;
            TABLA_ARANCELES.SetWidths(new float[] { 1f, 1f, 2f, 1f, 1f });

            PdfPCell CELDA_ID = new PdfPCell(new Phrase("ID", _mediumFontBoldWhite));
            CELDA_ID.BackgroundColor = topo;
            CELDA_ID.BorderColor = blanco;
            CELDA_ID.HorizontalAlignment = 1;
            CELDA_ID.FixedHeight = 16f;
            TABLA_ARANCELES.AddCell(CELDA_ID);
            
            PdfPCell CELDA_TIPO = new PdfPCell(new Phrase("CATEGORIA", _mediumFontBoldWhite));
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

            PdfPCell CELDA_STOCK = new PdfPCell(new Phrase("STOCK", _mediumFontBoldWhite));
            CELDA_STOCK.BackgroundColor = topo;
            CELDA_STOCK.BorderColor = blanco;
            CELDA_STOCK.HorizontalAlignment = 1;
            CELDA_STOCK.FixedHeight = 16f;
            TABLA_ARANCELES.AddCell(CELDA_STOCK);

            if (dgListadoAranceles.Rows.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                foreach (DataGridViewRow row in dgListadoAranceles.Rows)
                {
                    string ID = row.Cells[0].Value.ToString();
                    string TIPO = row.Cells[1].Value.ToString();
                    string NOMBRE = row.Cells[2].Value.ToString();
                    string ARANCEL = row.Cells[3].Value.ToString();
                    string STOCK = row.Cells[4].Value.ToString();

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

                    PdfPCell CELL_ID = new PdfPCell(new Phrase(ID, _mediumFont));
                    CELL_ID.HorizontalAlignment = 1;
                    CELL_ID.BorderWidth = 0;
                    CELL_ID.BackgroundColor = colorFondo;
                    CELL_ID.FixedHeight = 14f;
                    TABLA_ARANCELES.AddCell(CELL_ID);

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

                    PdfPCell CELL_STOCK = new PdfPCell(new Phrase(STOCK, _mediumFont));
                    CELL_STOCK.HorizontalAlignment = 1;
                    CELL_STOCK.BorderWidth = 0;
                    CELL_STOCK.BackgroundColor = colorFondo;
                    CELL_STOCK.FixedHeight = 14f;
                    TABLA_ARANCELES.AddCell(CELL_STOCK);
                }
            }

            doc.Add(TABLA_ARANCELES);
            doc.Close();
            writer.Close();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo PDF|*.pdf";
            saveFileDialog1.Title = "Guardar Listado";

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
            Cursor = Cursors.WaitCursor;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo XLS|*.xls";
            saveFileDialog1.Title = "Guardar Listado";
            string RUTA = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                RUTA = saveFileDialog1.FileName;
            }

            listadoExcel(RUTA);
            MessageBox.Show("LISTADO GENERADO CORRECTAMENTE", "LISTO!");

            Cursor = Cursors.Default;
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
                ARANCELES.Cells[1, 1] = "ID";
                ARANCELES.Cells[1, 2] = "CATEGORIA";
                ARANCELES.Cells[1, 3] = "NOMBRE";
                ARANCELES.Cells[1, 4] = "PRECIO";
                ARANCELES.Cells[1, 5] = "STOCK";
                string ID = "";
                string CATEGORIA = "";
                string NOMBRE = "";
                string PRECIO = "";
                string STOCK = "";
                int X = 2;

                foreach (DataGridViewRow row in dgListadoAranceles.Rows)
                {
                    ID = row.Cells[0].Value.ToString();
                    CATEGORIA = row.Cells[1].Value.ToString();
                    NOMBRE = row.Cells[2].Value.ToString();
                    PRECIO = row.Cells[3].Value.ToString();
                    STOCK = row.Cells[4].Value.ToString();

                    ARANCELES.Cells[X, 1] = ID;
                    ARANCELES.Columns[1].AutoFit();
                    ARANCELES.Cells[X, 2] = CATEGORIA;
                    ARANCELES.Columns[2].AutoFit();
                    ARANCELES.Cells[X, 3] = NOMBRE;
                    ARANCELES.Columns[3].AutoFit();
                    ARANCELES.Cells[X, 4] = PRECIO;
                    ARANCELES.Columns[4].AutoFit();
                    ARANCELES.Cells[X, 5] = STOCK;
                    ARANCELES.Columns[5].AutoFit();
                    X++;
                }

                xlWorkBook.SaveAs(RUTA, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(ARANCELES);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbStock.Text != "")
            {
                if (dgListadoAranceles.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow row in dgListadoAranceles.SelectedRows)
                    {
                        int STOCK_TOTAL = 0;
                        int STOCK_ACTUAL = Convert.ToInt32(row.Cells[4].Value);
                        int ID = Convert.ToInt32(row.Cells[0].Value);
                        int STOCK = Convert.ToInt32(tbStock.Text);
                        STOCK_TOTAL = STOCK_ACTUAL + STOCK;
                        bool SET_ITEM_STOCK = utils.setItemStock(ID, STOCK_TOTAL);

                        if (SET_ITEM_STOCK == true)
                            MessageBox.Show("STOCK ACTUALIZADO");
                        else
                            MessageBox.Show("NO SE PUDO ACTUALIZAR EL STOCK");

                        string CATEGORIA = cbCategoria.Text.Trim();
                        buscarAranceles(CATEGORIA);
                    }
                }
            }
            else
            {
                MessageBox.Show("INGRESAR UN NUMERO DE STOCK");
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string CATEGORIA = cbCategoria.Text.Trim();
            buscarAranceles(CATEGORIA);
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            buscarAranceles("X");
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string ARCHIVO = ofd.FileName;

            if (ARCHIVO != "*.xls")
            {
                if (MessageBox.Show("¿CONFIRMA IMPORTAR LOS DATOS DEL ARCHIVO " + ARCHIVO + " ?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ARCHIVO + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                    con.Open();
                    DataSet dset = new DataSet();
                    OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [ARANCELES$] WHERE ID IS NOT NULL;", con);
                    dadp.TableMappings.Add("ID", "CATEGORIA");
                    dadp.Fill(dset);
                    DataTable table = dset.Tables[0];

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        try
                        {
                            int ID = Convert.ToInt32(table.Rows[i][0]);
                            decimal PRECIO = Convert.ToDecimal(table.Rows[i][3]);
                            int STOCK = Convert.ToInt32(table.Rows[i][4]);
                            utils.setArancel(PRECIO, ID);
                            utils.setStock(STOCK, ID);
                        }
                        catch (Exception) { }
                    }

                    MessageBox.Show("ARANCELES Y STOCK IMPORTADOS CORRECTAMENTE");
                    string CATEGORIA = cbCategoria.Text.Trim();
                    buscarAranceles(CATEGORIA);
                    Cursor = Cursors.Default;
                }
            }
        }

        private void tbBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }*/
        }

        private void tbBarCode_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());
        }

        private void btnAsignarBarras_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow ROW in dgListadoAranceles.SelectedRows)
            {
                if (ROW.Cells[0].Value.ToString() != "")
                {
                    bool SET_BARCODE = utils.setBarcode(Convert.ToInt32(ROW.Cells[0].Value), tbBarCode.Text.Trim());

                    if (SET_BARCODE == true)
                    {
                        MessageBox.Show("CÓDIGO DE BARRAS ACTUALIZADO");
                    }
                    else
                    {
                        MessageBox.Show("OCURRIO UN ERROR");
                    }
                }
            }
        }

        private void tbBarCodeSearch_Leave(object sender, EventArgs e)
        {
            buscarAranceles("X", tbBarCodeSearch.Text.Trim());
        }

        private void tbBarCodeSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnImprimirBarcode_Click(object sender, EventArgs e)
        {
            if (dgListadoAranceles.SelectedRows.Count > 0)
            {
                string BARCODE = String.Empty;
                string NOMBRE = String.Empty;

                foreach (DataGridViewRow ROW in dgListadoAranceles.SelectedRows)
                {
                    int ITEM = Convert.ToInt32(ROW.Cells[0].Value);
                    BARCODE = utils.getItemBarCode(ITEM);
                    NOMBRE = utils.getItemName(ITEM);

                    if (BARCODE == "")
                    {
                        string START_BARCODE = "1000001";
                        string END_BARCODE = Convert.ToString(ITEM).PadLeft(6, '0');
                        BARCODE = START_BARCODE + "" + END_BARCODE;
                    }
                }

                print.printBarCodeConfiteria(NOMBRE, BARCODE);
            }
        }
    }
}
