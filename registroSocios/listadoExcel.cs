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

namespace SOCIOS
{
    public partial class listadoExcel : Form
    {
        bo dlog = new bo();

        public listadoExcel()
        {
            InitializeComponent();
            llenarComboOrigenAlta();
            rbAlfabetico.Checked = true;
            rbAlta.Checked = true;
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

        public void excel(DataSet ds, string path)
        {
            string data = null;
            Cursor = Cursors.WaitCursor;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];

            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;
            
            xlWorkSheet.Cells[1, 1] = "APELLIDOS";
            xlWorkSheet.Cells[1, 2] = "NOMBRES";
            xlWorkSheet.Cells[1, 3] = "DOCUMENTO";
            xlWorkSheet.Cells[1, 4] = "AAR";
            xlWorkSheet.Cells[1, 5] = "ACRJP2";
            xlWorkSheet.Cells[1, 6] = "NRO SOCIO";
            xlWorkSheet.Cells[1, 7] = "NRO DEP";
            xlWorkSheet.Cells[1, 8] = "LEGAJO";
            xlWorkSheet.Cells[1, 9] = "A DESCUENTO";
            xlWorkSheet.Cells[1, 10] = "DOMICILIO";
            xlWorkSheet.Cells[1, 11] = "NUMERO";
            xlWorkSheet.Cells[1, 12] = "LOCALIDAD";

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = ds.Tables[0].Rows.Count;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
       
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                    xlWorkSheet.Columns[9].EntireColumn.NumberFormat = "DD/AAAA";
                }

                progressBar1.PerformStep();
            }

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            Cursor = Cursors.Default;
        }

        public void llenarComboOrigenAlta()
        {
            string query = "SELECT CODIGO, SIGN FROM CODIGOS WHERE SUBSTRING(CODIGO FROM 1 FOR 3) = 'OA0';";
            cbOrigenAlta.Items.Clear();
            cbOrigenAlta.DataSource = dlog.BO_EjecutoDataTable(query);
            cbOrigenAlta.DisplayMember = "SIGN";
            cbOrigenAlta.ValueMember = "CODIGO";
        }

        static void OpenMicrosoftExcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        public string consulta()
        {
            string ORIGEN_ALTA;
            int PAR = 0;
            int ORDEN = 0;
            int AFI_BEN = 0;
            string PCRJP1;
            string PCRJP2;
            string PCRJP3;
            int O = 1;
            int A = 1;

            if (cbOrigenAlta.SelectedValue != null)
                ORIGEN_ALTA = cbOrigenAlta.SelectedValue.ToString();
            else
                ORIGEN_ALTA = null;

            string origen = ORIGEN_ALTA.Substring(3, 3);
            string mes = dtpADTO.Text.Substring(3, 2);
            string anio = dtpADTO.Text.Substring(6, 4);

            if (rbAlfabetico.Checked)
                ORDEN = 1;
            else if (rbAfiliado.Checked)
                ORDEN = 2;
            else if (rbLegajo.Checked)
                ORDEN = 3;

            string query = "SELECT APE_SOC, NOM_SOC, NUM_DOC, AAR, ACRJP2, NRO_SOC, NRO_DEP, LEG_PER, A_DTO, CALL_PAR, NRO_PAR, LOC_PAR FROM TITULAR WHERE A_DTO = '" + anio + "/" + mes + "/01' AND ORIGEN_ALTA = '" + origen + "'";

            if (rbAlta.Checked)
                query += " AND F_BAJCI IS NULL";
            else if (rbBaja.Checked)
                query += " AND F_BAJCI IS NOT NULL";

            if (ORDEN == 1)
                query += " ORDER BY APE_SOC, NOM_SOC;";
            else if (ORDEN == 2)
                query += " ORDER BY AAR, ACRJP2;";
            else if (ORDEN == 3)
                query += " ORDER BY LEG_PER;";

            return query;
        }

        
        private void btnVer_Click(object sender, EventArgs e)
        {
            string query = consulta();
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
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();
                    
                    bo dlog = new bo();
                    DataSet ds = dlog.BO_EjecutoDataSet(query);

                    try
                    {
                        if (reader.Read())
                        {
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                            saveFileDialog1.Filter = "Archivo XLS|*.xls";
                            saveFileDialog1.Title = "Guardar Listado";

                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                Cursor = Cursors.WaitCursor;

                                excel(ds, saveFileDialog1.FileName);
                                                                
                                Cursor = Cursors.Default;

                                DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    OpenMicrosoftExcel(saveFileDialog1.FileName);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }

                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
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
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e) //LIMPIAR
        {
            rbAlfabetico.Checked = true;
            cbOrigenAlta.SelectedIndex = 0;
            dtpADTO.ResetText();
        }
    }
}
