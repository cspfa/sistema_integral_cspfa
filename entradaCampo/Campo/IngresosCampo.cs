using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using FirebirdSql.Data.FirebirdClient;
using System.Diagnostics;


namespace SOCIOS.Entrada_Campo
{    
    public partial class IngresosCampo : Form
    {
        EntradaCampoService es = new EntradaCampoService();
        List<SOCIOS.EntradaCampo> registros = new List<SOCIOS.EntradaCampo>();

        public IngresosCampo()
        {
            InitializeComponent();

            DataBind(true,false);

        }

        private void DataBind(bool SinProcesar,bool porID)
        {

            int ID_DESDE = 0;
            int ID_HASTA = 0;

            if (tbDESDE.Text.Length > 0)
                ID_DESDE = Int32.Parse(tbDESDE.Text);
            
            if (tbHASTA.Text.Length > 0)
                ID_HASTA = Int32.Parse(tbHASTA.Text);

            registros = new List<SOCIOS.EntradaCampo>();
            registros  = es.getIngresos(SinProcesar,false,ID_DESDE,ID_HASTA,false,"").Where(x=>x.ROL ==VGlobales.vp_role).ToList();
          
            if (ID_DESDE > 0 && porID)
            {
                if (ID_HASTA > 0)
                    registros = registros.Where(x => x.ID >= ID_DESDE).Where(x => x.ID <= ID_HASTA).ToList();
                else
                    registros = registros.Where(x => x.ID >= ID_DESDE).ToList();
            }

            dgvIngresos.DataSource = registros;
        }

        private void chkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            

            //this.DataBind(chkFiltro.Checked,cbID.Checked);
        }

        private void XLS_Click(object sender, EventArgs e)
        {

            string Mensaje ="Se genera el Archivo y se Marcan los registros como procesados ";
            if (!chkFiltro.Checked)
                Mensaje = "Esta enviando toda la historia de ingresos, no solo las novedades, esta de acuerdo?";


            int ID_DESDE = 0;
            int ID_HASTA = 0;

            if (tbDESDE.Text.Length > 0)
                ID_DESDE = Int32.Parse(tbDESDE.Text);

            if (tbHASTA.Text.Length > 0)
                ID_HASTA = Int32.Parse(tbHASTA.Text);

            if (cbID.Checked)
            {
                if (ID_DESDE > 0)
                    Mensaje = Mensaje + " Envia a partir del Id Interno : " + ID_DESDE.ToString();
              
                if (ID_HASTA > 0)
                    Mensaje = Mensaje + " y Hasta el Id Interno : " + ID_HASTA.ToString();


            
            }
            if (MessageBox.Show(Mensaje, "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    
                  

                    DataSet ds = new DataSet();

                    string query = "SELECT * FROM  ENTRADA_CAMPO WHERE 1=1   ";

                    if (chkFiltro.Checked)
                        query = query + " AND EXPORTADO=0 AND ROL = '" + VGlobales.vp_role + "'";
                    
                    
                    if (ID_DESDE > 0 && cbID.Checked)
                    {
                        if (ID_HASTA > 0)
                            query = query + "  AND ID_ROL >= " + ID_DESDE.ToString() + " AND ID_ROL <= " + ID_HASTA.ToString(); 
                        else
                            query = query + "  AND ID_ROL >= " + ID_DESDE.ToString(); 
                    }

                    query = query + " order by ID_ROL";

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
                               
                                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                                    if (chkFiltro.Checked)
                                       saveFileDialog1.Filter = "Archivo CSPFA|*.cspfa";
                                    else
                                        saveFileDialog1.Filter = "Archivo CSPFA|*.cspfall";

                                    saveFileDialog1.Title = "Guardar Listado";

                                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                    {
                                        excel(ds, saveFileDialog1.FileName);
                                        DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n", "LISTO!");

                                       
                                    }
                                

                               
                                
                            }
                            else
                            {
                                MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }

                        Cursor = Cursors.Default;

                        es.Procesar_Registros(registros);
                        es.Impresion_Totales(registros,"");


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

        //private void Impresion_totales(List<SOCIOS.EntradaCampo> lista)

        //{ 
        //   int Socio                    = lista.Sum(x=>x.SOCIO) ;
        //   int Socio_Pileta             = lista.Sum(x=>x.SOCIO_PILETA);
        //   int Socio_Estacionamiento    = lista.Sum(x=>x.SOCIO_ESTACIONAMIENTO);
        //   int Invitado                 = lista.Sum(x=>x.INVITADO);
        //   int Invitado_Pileta          = lista.Sum(x=>x.INVITADO_PILETA);
        //   int Invitado_Estacionamiento = lista.Sum(x=>x.INVITADO_ESTACIONAMIENTO);
        //   int Inter                   = lista.Sum(x=>x.INTERCIRCULO);
        //   int Inter_Pileta            =lista.Sum(x=>x.INTERCIRCULO_PILETA);
        //   int Inter_Estacionamiento   = lista.Sum(x=>x.INTERCIRCULO_ESTACIONAMIENTO);
        //   int Menor                   = lista.Sum(x=>x.MENOR);
        //   int Disca                    =lista.Sum(x=>x.DISCAPACITADO);
        //   int Disca_Acom              = lista.Sum(x=>x.DISCAPACITADO_ACOM);

        //    es.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Inter, Inter_Pileta, Inter_Estacionamiento, Menor, Disca, Disca_Acom, 0, "TOTALES", System.DateTime.Now.ToString(), false);

            
            
        
        //}

        static void OpenMicrosoftExcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
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
            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "DNI";
            xlWorkSheet.Cells[1, 3] = "NOMBRE";
            xlWorkSheet.Cells[1, 4] = "APELLIDO";
            xlWorkSheet.Cells[1, 5] = "NRO_SOC";
            xlWorkSheet.Cells[1, 6] = "NRO_DEP";
            xlWorkSheet.Cells[1, 7] = "TIPO";
            xlWorkSheet.Cells[1, 8] = "INVITADO";
            xlWorkSheet.Cells[1, 9] = "MONTO_INVITADO";

            xlWorkSheet.Cells[1, 10] = "INVITADO_PILETA";
            xlWorkSheet.Cells[1, 11] = "MONTO_INVITADO_PIL";
          
            xlWorkSheet.Cells[1, 12] = "INVITADO_EST";
            xlWorkSheet.Cells[1, 13] = "MONTO_INVITADO_EST";


            xlWorkSheet.Cells[1, 14] = "SOCIO";
            xlWorkSheet.Cells[1, 15] = "MONTO_SOCIO";
            xlWorkSheet.Cells[1, 16] = "SOCIO_PILETA";
            xlWorkSheet.Cells[1, 17] = "MONTO_SOCIO_PIL";

            xlWorkSheet.Cells[1, 18] = "SOCIO_EST";
            xlWorkSheet.Cells[1, 19] = "MONTO_SOCIO_EST";

            xlWorkSheet.Cells[1, 20] = "INTER";
            xlWorkSheet.Cells[1, 21] = "MONTO_INTER";

            xlWorkSheet.Cells[1, 22] = "INTER_PILETA";
            xlWorkSheet.Cells[1, 23] = "MONTO_INTER_PILETA";

            xlWorkSheet.Cells[1, 24] = "INTER_EST";
            xlWorkSheet.Cells[1, 25] = "MONTO_INTER_EST";

            xlWorkSheet.Cells[1, 26] = "CANTIDAD_TOTAL";
            xlWorkSheet.Cells[1, 27] = "MONTO_TOTAL";
            xlWorkSheet.Cells[1, 28] = "FECHA";
            xlWorkSheet.Cells[1, 29] = "ROL";
            xlWorkSheet.Cells[1, 30] = "USUARIO";
            xlWorkSheet.Cells[1, 31] = "EXPORTADO";
            xlWorkSheet.Cells[1, 32] = "ID_ROL";
            xlWorkSheet.Cells[1, 33] = "FECHA_ANUL";
            xlWorkSheet.Cells[1, 34] = "USUARIO_IMPORTACION";
            xlWorkSheet.Cells[1, 35] = "FECHA_IMPORTACION";
            xlWorkSheet.Cells[1, 36] = "ROL_IMPORTACION";
            xlWorkSheet.Cells[1, 37] = "USUARIO_ANUL";
            
            xlWorkSheet.Cells[1, 38] = "MENOR";
            xlWorkSheet.Cells[1, 39] = "DISCA";
            xlWorkSheet.Cells[1, 40] = "VITALICIO_ORO";
            xlWorkSheet.Cells[1, 41] = "";
            xlWorkSheet.Cells[1, 42] = "LEGAJO";
            xlWorkSheet.Cells[1, 43] = "OBS REUNION";
            xlWorkSheet.Cells[1, 44] = "EVENTO";
            xlWorkSheet.Cells[1, 45] = "MONTO EVENTO";


            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                   
                }
            }

            xlWorkSheet.Columns[18].EntireColumn.NumberFormat = "DD/MM/AAAA";
          
            
            xlWorkSheet.Columns[1].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[5].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[6].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[8].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[10].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[12].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[14].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[16].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[18].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[9].EntireColumn.NumberFormat = "#,###.00 ";
            xlWorkSheet.Columns[11].EntireColumn.NumberFormat = "#,###.00 ";
            xlWorkSheet.Columns[15].EntireColumn.NumberFormat = "#,###.00 ";
            xlWorkSheet.Columns[17].EntireColumn.NumberFormat = "#,###.00 ";
            xlWorkSheet.Columns[19].EntireColumn.NumberFormat = "#,###.00 ";
            xlWorkSheet.Columns[21].EntireColumn.NumberFormat = "#,###.00 ";
            xlWorkSheet.Columns[23].EntireColumn.NumberFormat = "#,###.00 ";
            xlWorkSheet.Columns[25].EntireColumn.NumberFormat = "#,###.00 ";

       
            xlWorkSheet.Columns[28].EntireColumn.NumberFormat = "DD/MM/AAAA";

            xlWorkSheet.Columns[32].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[33].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[34].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[35].EntireColumn.NumberFormat = "000";



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

        private void IngresosCampo_Load(object sender, EventArgs e)
        {

        }

        private void cbID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbID.Checked)
                pnlID.Visible = true;
            else
                pnlID.Visible = false;

           // this.DataBind(chkFiltro.Checked, cbID.Checked);
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            this.DataBind(chkFiltro.Checked, cbID.Checked);
        }

        private void pnlID_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
