using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Excel = Microsoft.Office.Interop.Excel;


namespace SOCIOS
{
    public partial class recibosEnBlanco : Form
    {
        BO.bo_Caja BO_CAJA = new BO.bo_Caja();
        bo dlog = new bo();
        genHTML gh = new genHTML();
        printhtml p = new printhtml();
        numeroRecibo nr = new numeroRecibo();
        maxid mi = new maxid();
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();

        string TABLA { get; set; }
        string COMPROBANTE { get; set; }

        public recibosEnBlanco()
        {
            InitializeComponent();
        }

        private void cargaInicial()
        {
            TABLA = "RECIBOS_CAJA";
            COMPROBANTE = "RECIBO";
            comboComprobantes();
            cbComprobantes.SelectedItem = "RECIBO";
            buscarPuntosDeVenta();
            tbDesde.Text = "";
            tbHasta.Text = "";
            btnConfirmarImpresion.Enabled = false;
        }

        private void comboComprobantes()
        {
            cbComprobantes.Items.Add("RECIBO");
            cbComprobantes.Items.Add("BONO");
        }

        private int cuentaDestino(string DESTINO)
        { 
            
            string QUERY = "SELECT CUENTA FROM RECIBOS_DESTINOS WHERE ID = " + DESTINO;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return int.Parse(foundRows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        private string accionPtoVta(string PTO_VTA)
        {
            string QUERY = "SELECT ACCION FROM PUNTOS_DE_VENTA WHERE PTO_VTA = '" + PTO_VTA + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            return foundRows[0][0].ToString();
        }

        private bool checkDesdeHasta(int DESDE, int HASTA, string TABLA)
        {
            bool RESULT = false;
            string QUERY = "SELECT NRO_COMP FROM " + TABLA + " WHERE NRO_COMP BETWEEN " + DESDE + " AND " + HASTA + " ORDER BY NRO_COMP ASC;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                RESULT = true;
            }

            return RESULT;
        }

        private void guardarComprobantes(string USUARIO_MOD)
        {
            if (TABLA == "NINGUNA")
            {
                MessageBox.Show("SELECCIONAR UN TIPO DE COMPROBANTE");
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    string USUARIO = cs.UserID = VGlobales.vp_username;
                    string PTO_VTA = lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text;
                    int DESDE = int.Parse(tbDesde.Text);
                    int HASTA = int.Parse(tbHasta.Text);
                    int DESTINO = int.Parse(lvPuntosDeVenta.SelectedItems[0].SubItems[4].Text);
                    int ID = int.Parse(mi.m("ID", TABLA)) + 1;
                    string ACCION = accionPtoVta(PTO_VTA);
                    
                    if (TABLA == "RECIBOS_CAJA")
                    {
                        BO_CAJA.recibosEnBlanco(DESDE, HASTA, USUARIO, DESTINO, PTO_VTA, ID, USUARIO_MOD);
                    }

                    if (TABLA == "BONOS_CAJA")
                    {
                        BO_CAJA.bonosEnBlanco(DESDE, HASTA, USUARIO, DESTINO, PTO_VTA, ID, USUARIO_MOD);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDIERON GUARDAR LOS COMPROBANTES\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Cursor = Cursors.Default;
            }
        }

        private void imprimir()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                string PTO_VTA = lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text;
                int DESDE = int.Parse(tbDesde.Text);
                int HASTA = int.Parse(tbHasta.Text);
                string ACCION = accionPtoVta(PTO_VTA);

                if (TABLA == "RECIBOS_CAJA")
                {
                    if (ACCION == "N")
                    {
                        gh.recibosEnBlanco(DESDE, HASTA, "RECIBO", PTO_VTA);
                        p.printHTML("recibo_en_blanco.html");
                    }
                }

                if (TABLA == "BONOS_CAJA")
                {
                    if (ACCION == "N")
                    {
                        gh.recibosEnBlanco(DESDE, HASTA, "BONO", PTO_VTA);
                        p.printHTML("recibo_en_blanco.html");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDIERON IMPRIMIR LOS COMPROBANTES\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }
             
        private void btnConfirmarImpresion_Click(object sender, EventArgs e)
        {
            if (lvPuntosDeVenta.SelectedItems.Count != 1)
            {
                MessageBox.Show("SELECCIONAR UN PUNTO DE VENTA", "ERROR!");
            }
            else
            {
                if (MessageBox.Show("SE VAN A IMPRIMIR " + tbCantidad.Text + " " + cbComprobantes.Text + "S PARA EL PUNTO DE VENTA " + lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text + "\n¿CONTINUAR?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    guardarComprobantes("BLANCO");
                    string PTO_VTA = lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text;
                    int DESDE = int.Parse(tbDesde.Text);
                    int HASTA = int.Parse(tbHasta.Text);
                    generarExcel(DESDE, HASTA, PTO_VTA, true);
                    buscarPuntosDeVenta();
                }
            }
        }

        private void calcular()
        {
            if (tbCantidad.Text != "" && lvPuntosDeVenta.SelectedItems.Count == 1)
            {
                int INDEX = 0;
                string PTO_VTA = "";
                int NRO_DESDE = 0;
                int NRO_HASTA = 0;
                int CANTIDAD = 0;

                if (cbComprobantes.SelectedItem == "RECIBO")
                {
                    INDEX = 2;
                }

                if (cbComprobantes.SelectedItem == "BONO")
                {
                    INDEX = 3;
                }

                PTO_VTA = lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text;
                NRO_DESDE = int.Parse(lvPuntosDeVenta.SelectedItems[0].SubItems[INDEX].Text) + 1;
                CANTIDAD = int.Parse(tbCantidad.Text);
                tbDesde.Text = NRO_DESDE.ToString();
                tbHasta.Text = (NRO_DESDE + CANTIDAD - 1).ToString();
                btnConfirmarImpresion.Enabled = true;
                //btnImprimirManual.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                tbHasta.Text = "";
                btnConfirmarImpresion.Enabled = false;
                //btnImprimirManual.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {
            if (TABLA == "NINGUNA")
            {
                MessageBox.Show("SELECCIONAR UN COMPROBANTE");
            }
            else
            {
                calcular();
            }
        }

        private void buscarPuntosDeVenta()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco = "SELECT PTO_VTA, DETALLE, NUM_RECIBO, NUM_BONO, DESTINO FROM PUNTOS_DE_VENTA ORDER BY PTO_VTA;";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarPuntosDeVenta(reader);
                    }

                    reader.Close();
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

            Cursor = Cursors.Default;
        }

        private void mostrarPuntosDeVenta(FbDataReader reader)
        {
            lvPuntosDeVenta.Items.Clear();
            lvPuntosDeVenta.Columns.Clear();
            lvPuntosDeVenta.BeginUpdate();

            if (lvPuntosDeVenta.Columns.Count == 0)
            {
                lvPuntosDeVenta.Columns.Add("PTO VTA");
                lvPuntosDeVenta.Columns.Add("LUGAR");
                lvPuntosDeVenta.Columns.Add("# RECIBO");
                lvPuntosDeVenta.Columns.Add("# BONO");
                lvPuntosDeVenta.Columns.Add("ID");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("PTO_VTA")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DETALLE")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_RECIBO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_BONO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DESTINO")).Trim());
                lvPuntosDeVenta.Items.Add(listItem);
            }

            while (reader.Read());
            lvPuntosDeVenta.EndUpdate();
            lvPuntosDeVenta.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvPuntosDeVenta.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnImprimirManual_Click(object sender, EventArgs e)
        {
            if (lvPuntosDeVenta.SelectedItems.Count != 1)
            {
                MessageBox.Show("POR FAVOR SELECCIONAR UN PUNTO DE VENTA");
            }
            else
            {
                string PTO_VTA = lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text;

                if (TABLA == "NINGUNA")
                {
                    MessageBox.Show("SELECCIONAR UN COMPROBANTE");
                }
                else if (tbDesde.Text == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO DESDE");
                }
                else if (tbHasta.Text == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO HASTA");
                }
                else
                {
                    if (TABLA == "RECIBOS_CAJA")
                    {
                        gh.recibosEnBlanco(int.Parse(tbDesde.Text), int.Parse(tbHasta.Text), "RECIBO", PTO_VTA);
                    }

                    if (TABLA == "BONOS_CAJA")
                    {
                        gh.recibosEnBlanco(int.Parse(tbDesde.Text), int.Parse(tbHasta.Text), "BONO", PTO_VTA);
                    }

                    try
                    {
                        p.printHTML("recibo_en_blanco.html");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
        }

        private void recibosEnBlanco_Load(object sender, EventArgs e)
        {
            cargaInicial();
        }

        private void reset(object sender, EventArgs e)
        {
            calcular();
        }

        public void excel(int DESDE, int HASTA, string path, string PTO_VTA)
        {
            string DESTINO = lvPuntosDeVenta.SelectedItems[0].SubItems[4].Text;
            int CUENTA = cuentaDestino(DESTINO);
            string data = null;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];
            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;
            xlWorkSheet.Cells[1, 1] = "RECIBO";
            xlWorkSheet.Cells[1, 2] = "CONCEPTO";
            xlWorkSheet.Cells[1, 3] = "IMPORTE";
            xlWorkSheet.Cells[1, 4] = "FECHA";
            xlWorkSheet.Cells[1, 5] = "NOMBRE Y APELLIDO TITULAR";
            xlWorkSheet.Cells[1, 6] = "NOMBRE Y APELLIDO";
            xlWorkSheet.Cells[1, 7] = "BARRA";
            xlWorkSheet.Cells[1, 8] = "DNI";
            xlWorkSheet.Cells[1, 9] = "OBSERVACIONES";
            xlWorkSheet.Cells[1, 10] = "CUENTA_HABER";
            xlWorkSheet.Columns[1].ColumnWidth = 10;
            xlWorkSheet.Columns[2].ColumnWidth = 40;
            xlWorkSheet.Columns[3].ColumnWidth = 10;
            xlWorkSheet.Columns[3].EntireColumn.NumberFormat = "1234,10";
            xlWorkSheet.Columns[4].ColumnWidth = 10;
            xlWorkSheet.Columns[4].EntireColumn.NumberFormat = "DD/MM/AAAA";
            xlWorkSheet.Columns[5].ColumnWidth = 40;
            xlWorkSheet.Columns[6].ColumnWidth = 40;
            xlWorkSheet.Columns[7].ColumnWidth = 10;
            xlWorkSheet.Columns[8].ColumnWidth = 10;
            xlWorkSheet.Columns[9].ColumnWidth = 40;
            xlWorkSheet.Columns[10].ColumnWidth = 15;
            int FILA = 2;

            for (int i = DESDE; i <= HASTA; i++)
            {
                xlWorkSheet.Cells[FILA, 1] = PTO_VTA + "-" + i;
                
                if (CUENTA > 0)
                    xlWorkSheet.Cells[FILA, 10] = CUENTA;
                
                FILA++;
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

        private void generarExcel(int DESDE, int HASTA, string PTO_VTA, bool IMPRIMIR)
        {
            if (cbExcel.Checked == true)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Archivo XLS|*.xls";
                saveFileDialog1.Title = "Guardar Listado";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    excel(DESDE, HASTA, saveFileDialog1.FileName, PTO_VTA);

                    if (IMPRIMIR == true)
                    {
                        imprimir();
                    }

                    Cursor = Cursors.Default;
                }
            }
            else
            {
                if (IMPRIMIR == true)
                {
                    imprimir();
                }
            }
         }

        private void lvPuntosDeVenta_MouseUp(object sender, MouseEventArgs e)
        {
            calcular();
        }

        private void cbComprobantes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbComprobantes.SelectedItem == "RECIBO")
            {
                TABLA = "RECIBOS_CAJA";
            }

            if (cbComprobantes.SelectedItem == "BONO")
            {
                TABLA = "BONOS_CAJA";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvPuntosDeVenta.SelectedItems.Count != 1)
            {
                MessageBox.Show("SELECCIONAR UN PUNTO DE VENTA", "ERROR!");
            }
            else
            {
                if (MessageBox.Show("SE VAN A RESERVAR " + tbCantidad.Text + " " + cbComprobantes.Text + "S PARA EL PUNTO DE VENTA " + lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text + "\n¿CONTINUAR?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    guardarComprobantes("RESERVADO");
                    string PTO_VTA = lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text;
                    int DESDE = int.Parse(tbDesde.Text);
                    int HASTA = int.Parse(tbHasta.Text);
                    generarExcel(DESDE, HASTA, PTO_VTA, false);
                    buscarPuntosDeVenta();
                    MessageBox.Show(cbComprobantes.Text + "S RESERVADOS CORRECTAMENTE", "LISTO!");
                }
            }
        }
    }
}
