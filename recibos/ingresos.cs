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
    public partial class ingresos : Form
    {
        bo dlog = new bo(); 

        public ingresos()
        {
            InitializeComponent();
            cargaInicial();
        }

        private void cargaInicial()
        {
            dpDesde.Text = DateTime.Today.ToShortDateString();
            dpHasta.Text = DateTime.Today.ToShortDateString();
            comboRoles();
            string ROLE = cbRoles.SelectedValue.ToString().Trim();
            comboDestinos(ROLE);
            comboAnulado();
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
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];
            
            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;

            xlWorkSheet.Cells[1, 1] = "#";
            xlWorkSheet.Cells[1, 2] = "TIPO";
            xlWorkSheet.Cells[1, 3] = "FECHA RECIBO";
            xlWorkSheet.Cells[1, 4] = "FECHA CAJA";
            xlWorkSheet.Cells[1, 5] = "FECHA ALTA";
            xlWorkSheet.Cells[1, 6] = "FECHA ANULADO";
            xlWorkSheet.Cells[1, 7] = "CUENTA DEBE";
            xlWorkSheet.Cells[1, 8] = "CUENTA HABER";
            xlWorkSheet.Cells[1, 9] = "VALOR";
            xlWorkSheet.Cells[1, 10] = "PAGO";
            xlWorkSheet.Cells[1, 11] = "OBSERVACIONES";
            xlWorkSheet.Cells[1, 12] = "SOCIO TITULAR";
            xlWorkSheet.Cells[1, 13] = "TIPO TITULAR";
            xlWorkSheet.Cells[1, 14] = "SOCIO";
            xlWorkSheet.Cells[1, 15] = "TIPO";
            xlWorkSheet.Cells[1, 16] = "BARRA";
            xlWorkSheet.Cells[1, 17] = "SERVICIO";
            xlWorkSheet.Cells[1, 18] = "PROFESIONAL";
            xlWorkSheet.Cells[1, 19] = "ROL";
            xlWorkSheet.Cells[1, 20] = "DNI";
            
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                    xlWorkSheet.Columns[3].EntireColumn.NumberFormat = "DD/MM/AAAA";
                }
            }

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        public void comboDestinos(string ROL)
        {
            string QUERY = "";
            QUERY = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '" + ROL + "' AND ESTADO = 1 ORDER BY DETALLE ASC;";

            if (ROL.Trim() == "PROSECRETARIA")
            {
                QUERY = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '" + ROL + "' AND ESTADO = 1 AND ID=160 ORDER BY DETALLE ASC;";
            }
            
            cbDest.DataSource = null;
            cbDest.Items.Clear();
            cbDest.SelectedItem = 0;
            cbDest.DataSource = dlog.BO_EjecutoDataTable(QUERY);
            cbDest.DisplayMember = "DETALLE";
            cbDest.ValueMember = "ID";
        }

        public void comboRoles()
        {
            string query;

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "CAJA" || VGlobales.vp_role == "CONTADURIA")
            {
                query = "SELECT DISTINCT ROL FROM SECTACT ORDER BY ROL;";
            }
            else if (VGlobales.vp_role == "SERVICIOS MEDICOS")
            {
                query = "SELECT DISTINCT ROL FROM SECTACT WHERE ROL = 'SERVICIOS MEDICOS' OR ROL = 'RECETAS' ORDER BY ROL;";
            }
            else if (VGlobales.vp_role == "CPOCABA")
            {
                query = "SELECT DISTINCT ROL FROM SECTACT WHERE ROL = 'CPOCABA' OR ROL = 'PROSECRETARIA' ORDER BY ROL;";
            }
            else
            {
                query = "SELECT DISTINCT ROL FROM SECTACT WHERE ROL = '" + VGlobales.vp_role + "' ORDER BY ROL;";
            }

            cbRoles.DataSource = null;
            cbRoles.Items.Clear();
            cbRoles.SelectedItem = 0;
            cbRoles.DataSource = dlog.BO_EjecutoDataTable(query);
            cbRoles.DisplayMember = "ROL";
            cbRoles.ValueMember = "ROL";
        }

        public void comboAnulado()
        {
            cbAnulado.Items.Clear();
            cbAnulado.Items.Add("NO");
            cbAnulado.Items.Add("SI");
            cbAnulado.SelectedIndex = 0;
        }

        static void OpenMicrosoftExcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        private void mostrarRecibos(FbDataReader reader3)
        {
            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable("RESULTADOS");
            ds1.Tables.Add(dt1);
            dt1.Columns.Add("#", typeof(int));
            dt1.Columns.Add("TIPO", typeof(string));
            dt1.Columns.Add("FECHA RECIBO", typeof(string));
            dt1.Columns.Add("FECHA CAJA", typeof(string));
            dt1.Columns.Add("FECHA ALTA", typeof(string));
            dt1.Columns.Add("FECHA ANULADO", typeof(string));
            dt1.Columns.Add("CUENTA DEBE", typeof(string));
            dt1.Columns.Add("CUENTA HABER", typeof(string));
            dt1.Columns.Add("VALOR", typeof(decimal));
            dt1.Columns.Add("PAGO", typeof(string));
            dt1.Columns.Add("OBSERVACIONES", typeof(string));
            dt1.Columns.Add("NOMBRE TITULAR", typeof(string));
            dt1.Columns.Add("TIPO TITULAR", typeof(string));
            dt1.Columns.Add("NOMBRE SOCIO", typeof(string));
            dt1.Columns.Add("TIPO SOCIO", typeof(string));
            dt1.Columns.Add("/", typeof(string));
            dt1.Columns.Add("DETALLE", typeof(string));
            dt1.Columns.Add("PROFESIONAL", typeof(string));
            dt1.Columns.Add("ROLE", typeof(string));
            dt1.Columns.Add("DNI", typeof(string));

            string VALOR = string.Empty;
            decimal IMPORTE;

            while (reader3.Read())
            {
                string ID = reader3.GetString(reader3.GetOrdinal("NRO_COMP"));
                string BR = reader3.GetString(reader3.GetOrdinal("BR")).Trim();
                string FECHA_RECIBO = reader3.GetString(reader3.GetOrdinal("FECHA_RECIBO")).Substring(0, 10);
                string FECHA_CAJA = reader3.GetString(reader3.GetOrdinal("FECHA_CAJA"));
                string FECHA_ALTA = reader3.GetString(reader3.GetOrdinal("FECHA_ALTA"));
                string FECHA_ANULADO = reader3.GetString(reader3.GetOrdinal("FECHA_ANULADO"));
                string CUENTA_DEBE = reader3.GetString(reader3.GetOrdinal("CUENTA_DEBE")).Trim();
                string CUENTA_HABER = reader3.GetString(reader3.GetOrdinal("CUENTA_HABER")).Trim();
                IMPORTE = reader3.GetDecimal(reader3.GetOrdinal("VALOR"));
                VALOR = string.Format("{0:n}", IMPORTE).Trim();
                string PAGO = reader3.GetString(reader3.GetOrdinal("PAGO")).Trim();
                string OBSERVACIONES = reader3.GetString(reader3.GetOrdinal("OBSERVACIONES")).Trim();
                string NOMBRE_SOCIO_TITULAR = reader3.GetString(reader3.GetOrdinal("NOMBRE_SOCIO_TITULAR")).Trim();
                string TIPO_SOCIO_TITULAR = reader3.GetString(reader3.GetOrdinal("TIPO_SOCIO_TITULAR")).Trim();
                string NOMBRE_SOCIO = reader3.GetString(reader3.GetOrdinal("NOMBRE_SOCIO")).Trim();
                string TIPO_SOCIO = reader3.GetString(reader3.GetOrdinal("TIPO_SOCIO")).Trim();
                string BARRA = reader3.GetString(reader3.GetOrdinal("BARRA"));
                string DETAIL = reader3.GetString(reader3.GetOrdinal("DETALLE")).Trim();
                string PROFESIONAL = reader3.GetString(reader3.GetOrdinal("PROFESIONAL")).Trim();
                string ROLL = reader3.GetString(reader3.GetOrdinal("ROLL")).Trim();
                string DNI = reader3.GetString(reader3.GetOrdinal("DNI"));

                dt1.Rows.Add(ID, BR, FECHA_RECIBO, FECHA_CAJA, FECHA_ALTA, FECHA_ANULADO, CUENTA_DEBE, CUENTA_HABER, VALOR, PAGO, OBSERVACIONES, NOMBRE_SOCIO_TITULAR, TIPO_SOCIO_TITULAR,
                    NOMBRE_SOCIO, TIPO_SOCIO, BARRA, DETAIL, PROFESIONAL, ROLL, DNI);
            }

            dgIngresos.DataSource = dt1;
            reader3.Close();
        }

        private void buscarRecibos(string DESDE, string HASTA, string ROL, string COMANDO, string ANULADO, string DETALLE)
        {
            try
            {
                string connectionString;
                Datos_ini ini3 = new Datos_ini();
                string query = "SELECT * FROM INGRESOS ('" + DESDE + "', '" + HASTA + "', '" + ROL + "', '" + ANULADO + "', '" + DETALLE + "');";
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
                cs.Database = ini3.Ubicacion;
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
                    FbDataReader reader3 = cmd.ExecuteReader();

                    if (reader3.Read())
                    {
                        if (COMANDO == "VER")
                        {
                            mostrarRecibos(reader3);
                        }

                        if (COMANDO == "EXCEL")
                        {
                            bo dlog = new bo();
                            DataSet ds = dlog.BO_EjecutoDataSet(query);
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
                    }
                    else
                    {
                        MessageBox.Show("NO SE ENCONTRARON REGISTROS CON LA CONDICION INGRESADA", "ERROR!");
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string DIAD = dpDesde.Text.Substring(0, 2);
            string MESD = dpDesde.Text.Substring(3, 2);
            string ANOD = dpDesde.Text.Substring(6, 4);
            string FECHA_DESDE = MESD + "/" + DIAD + "/" + ANOD;

            string DIAH = dpHasta.Text.Substring(0, 2);
            string MESH = dpHasta.Text.Substring(3, 2);
            string ANOH = dpHasta.Text.Substring(6, 4);
            string FECHA_HASTA = MESH + "/" + DIAH + "/" + ANOH;

            string ANULADO = cbAnulado.SelectedItem.ToString();
            string DETALLE = cbDest.SelectedValue.ToString().Trim();
            string ROL = cbRoles.SelectedValue.ToString().Trim();

            if (cbListarTodos.CheckState.ToString() == "Checked")
            {
                DETALLE = "TODOS";
            }

            buscarRecibos(FECHA_DESDE, FECHA_HASTA, ROL, "VER", ANULADO, DETALLE);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string DIAD = dpDesde.Text.Substring(0, 2);
            string MESD = dpDesde.Text.Substring(3, 2);
            string ANOD = dpDesde.Text.Substring(6, 4);
            string FECHA_DESDE = MESD + "/" + DIAD + "/" + ANOD;

            string DIAH = dpHasta.Text.Substring(0, 2);
            string MESH = dpHasta.Text.Substring(3, 2);
            string ANOH = dpHasta.Text.Substring(6, 4);
            string FECHA_HASTA = MESH + "/" + DIAH + "/" + ANOH;

            string ANULADO = cbAnulado.SelectedItem.ToString();
            string DETALLE = cbDest.SelectedValue.ToString();
            string ROL = cbRoles.SelectedValue.ToString().Trim();

            if (cbListarTodos.CheckState.ToString() == "Checked")
            {
                DETALLE = "TODOS";
            }

            buscarRecibos(FECHA_DESDE, FECHA_HASTA, ROL, "EXCEL", ANULADO, DETALLE);
        }

        private void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDestinos(cbRoles.SelectedValue.ToString());
        }

        private void cbListarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbListarTodos.CheckState.ToString() == "Checked")
            {
                cbDest.Enabled = false;
            }

            if (cbListarTodos.CheckState.ToString() == "Unchecked")
            {
                cbDest.Enabled = true;
            }
        }
    }
}
