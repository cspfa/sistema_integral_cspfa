using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace SOCIOS
{
    public partial class PFA_CABA : Form
    {
        DataTable TABLE { get; set; }
        DataRow[] ID_TITULARES { get; set; }
        bo DLOG = new bo();
        BO.bo_RegSoc REG_SOC = new BO.bo_RegSoc();
        nroSocio ns = new nroSocio();
        existe existe = new existe();

        public PFA_CABA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ARCHIVO = "";
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.FileName = "*.xls";
            OFD.ShowDialog();
            ARCHIVO = OFD.FileName;
            lbArchivoSeleccionado.Text = ARCHIVO;
            btnProcesar.Enabled = true;
        }

        private int sonSocios(DataSet DSET)
        {
            int SOCIOS = 0;
            string DNI = "";
            string QUERY = "SELECT COUNT(ID_TITULAR) FROM TITULAR WHERE NUM_DOC IN (";

            foreach (DataRow ROW in DSET.Tables[0].Rows)
            {
                DNI = ROW[0].ToString();
                QUERY += DNI + ",";
            }

            QUERY = QUERY.TrimEnd(',');
            QUERY = QUERY + ") AND NRO_DEP = 994;";
            DataRow[] foundRows;
            foundRows = DLOG.BO_EjecutoDataTable(QUERY).Select();
            SOCIOS = int.Parse(foundRows[0][0].ToString());
            return SOCIOS;
        }

        private DataRow[] getSocios(DataSet DSET)
        {
            DataRow[] ROWS;
            string DNI = "";
            string QUERY = "SELECT ID_TITULAR FROM TITULAR WHERE NUM_DOC IN (";

            foreach (DataRow ROW in DSET.Tables[0].Rows)
            {
                DNI = ROW[0].ToString();
                QUERY += DNI + ",";
            }

            QUERY = QUERY.TrimEnd(',');
            QUERY = QUERY + ") AND NRO_DEP = 994;";
            ROWS = DLOG.BO_EjecutoDataTable(QUERY).Select();
            return ROWS;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                string ARCHIVO = lbArchivoSeleccionado.Text;
                int REGISTROS = 0;
                int SOCIOS = 0;
                OleDbConnection CON = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ARCHIVO + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                CON.Open();
                DataSet DSET = new DataSet();
                OleDbDataAdapter DADP = new OleDbDataAdapter("SELECT * FROM [DNI$] WHERE DNI IS NOT NULL;", CON);
                DADP.TableMappings.Add("DNI", "NOMBRE");
                DADP.Fill(DSET);
                TABLE = DSET.Tables[0];
                REGISTROS = TABLE.Rows.Count;
                SOCIOS = sonSocios(DSET);
                ID_TITULARES = getSocios(DSET);
                lbResultados.Text = "REGISTROS ENCONTRADOS: " + REGISTROS.ToString() + " - SON SOCIOS: " + SOCIOS;
                btnActualizar.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL LEER EL ARCHIVO EXCEL\nPOSIBLES ERRORES:\nCABECERA DE COLUMNA DEBE SER DNI\nNOMBRE DE HOJA DEBE SER DNI\n" + error, "ERROR");
                Cursor = Cursors.Default;
            }

            Cursor = Cursors.Default;
        }

        private int getIdTitular(int NUM_DOC)
        { 
            int ID_TITULAR = 0;
            string QUERY = "SELECT MAX(ID_TITULAR) FROM TITULAR WHERE NUM_DOC = " + NUM_DOC + ";";
            DataRow[] foundRows;
            foundRows = DLOG.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                ID_TITULAR = int.Parse(foundRows[0][0].ToString());
            }

            return ID_TITULAR;
        }

        private string getNombreTitular(int ID_TITULAR)
        {
            string NOMBRE = "";
            string QUERY = "SELECT TRIM(NOM_SOC), TRIM(APE_SOC) FROM TITULAR WHERE ID_TITULAR = " + ID_TITULAR + ";";
            DataRow[] foundRows;
            foundRows = DLOG.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                NOMBRE = foundRows[0][1].ToString() + ", " + foundRows[0][0].ToString();
            }

            return NOMBRE;
        }

        private string nuevoCodDto(int ID_TITULAR)
        {
            string N_COD_DTO = "";
            string CAT_SOC = "";
            string QUERY = "SELECT CAT_SOC FROM TITULAR WHERE ID_TITULAR = " + ID_TITULAR + ";";
            DataRow[] foundRows;
            foundRows = DLOG.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                CAT_SOC = foundRows[0][0].ToString();
            }

            if (CAT_SOC == "001") N_COD_DTO = "871";
            if (CAT_SOC == "002") N_COD_DTO = "187";

            return N_COD_DTO;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SE DISPONE A CONVERTIR LOS TITULARES SELECCIONADOS A ADHERENTES INTERFUERZAS\n¿CONTINUAR?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                progressBar.Visible = true;
                progressBar.Minimum = 0;
                progressBar.Maximum = TABLE.Rows.Count;
                progressBar.Value = 1;
                progressBar.Step = 1;
                int ID_TITULAR = 0;
                int N_NRO_SOC = 0;
                int N_ID_TITULAR = 0;
                string N_COD_DTO = "";
                string NOMBRE = "";
                string UPDATE = "";
                string ESTADO = "TRASPASADO";
                lvResultado.Items.Clear();
                lvResultado.Columns.Clear();
                lvResultado.BeginUpdate();

                if (lvResultado.Columns.Count == 0)
                {
                    lvResultado.Columns.Add("ID _TITULAR");
                    lvResultado.Columns.Add("APELLIDO Y NOMBRE");
                    lvResultado.Columns.Add("# ID NUEVO");
                    lvResultado.Columns.Add("# SOCIO NUEVO");
                    lvResultado.Columns.Add("# DTO NUEVO");
                    lvResultado.Columns.Add("ESTADO");
                }

                foreach (DataRow ROW in ID_TITULARES)
                {
                    try
                    {
                        ID_TITULAR = int.Parse(ROW[0].ToString());
                        NOMBRE = getNombreTitular(ID_TITULAR);
                        N_NRO_SOC = ns.numero(11);
                        N_ID_TITULAR = (N_NRO_SOC * 1000) + 20;
                        N_COD_DTO = nuevoCodDto(ID_TITULAR);
                        REG_SOC.PFA_CABA(ID_TITULAR, N_ID_TITULAR, N_NRO_SOC, int.Parse(N_COD_DTO));
                        ListViewItem LI = new ListViewItem(ID_TITULAR.ToString());
                        LI.SubItems.Add(NOMBRE);
                        LI.SubItems.Add(N_ID_TITULAR.ToString());
                        LI.SubItems.Add(N_NRO_SOC.ToString());
                        LI.SubItems.Add(N_COD_DTO.ToString());
                        LI.SubItems.Add(ESTADO);
                        lvResultado.Items.Add(LI);
                        progressBar.PerformStep();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("OCURRIO UN ERROR EN EL REGISTRO CON ID " + ID_TITULAR + "\n" + error);
                    }
                }

                lvResultado.EndUpdate();
                lvResultado.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvResultado.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                button2.Enabled = true;
                string PATH = @"\\192.168.1.6\prosecretaria\zz_migraciones\PFA-A-CABA-" + DateTime.Now + ".xls";
                buscarSocios(PATH);
                Cursor = Cursors.Default;
            }
        }

        public void buscarSocios(string PATH)
        {
            Cursor = Cursors.WaitCursor;
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT NRO_SOC, NRO_DEP, APE_SOC, NOM_SOC, COD_DTO, ACRJP2, NRO_SOC_ANT FROM TITULAR WHERE ID_TITULAR_ANT IN (";

                    foreach (ListViewItem item in lvResultado.Items)
                    {
                        QUERY += item.SubItems[0].Text + ",";
                    }

                    QUERY = QUERY.TrimEnd(',');
                    QUERY = QUERY + ");";

                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
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
                                if (PATH == "X")
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
                                else
                                {
                                    excel(ds, PATH);
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

        private void button2_Click(object sender, EventArgs e)
        {
            buscarSocios("X");
        }

        static void OpenMicrosoftExcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        public void excel(DataSet DS, string PATH)
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
            xlWorkSheet.Cells[1, 1] = "NRO SOC";
            xlWorkSheet.Cells[1, 2] = "NRO DEP";
            xlWorkSheet.Cells[1, 3] = "APELLIDO";
            xlWorkSheet.Cells[1, 4] = "NOMBRES";
            xlWorkSheet.Cells[1, 5] = "COD DTO";
            xlWorkSheet.Cells[1, 6] = "ACRJP2";
            xlWorkSheet.Cells[1, 7] = "NRO SOC ANT";

            for (int i = 0; i <= DS.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= DS.Tables[0].Columns.Count - 1; j++)
                {
                    data = DS.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                }
            }

            xlWorkBook.SaveAs(PATH, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
    }
}
