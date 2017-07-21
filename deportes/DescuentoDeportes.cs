using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS.descuentos;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace SOCIOS.deportes
{
    public partial class DescuentoDeportes : Form
    {
        SOCIOS.descuentos.DescuentoUtils du = new DescuentoUtils();
        SOCIOS.deportes.CamposService cs = new CamposService();
        public DescuentoDeportes()
        {
            InitializeComponent();
            cs.ComboRol(cbRol);
            dataGridDtoDepo.DataSource           = du.getDto_Deportes( (int)TIPO_ACTIVIDAD.TODOS,cbRol.Text.TrimEnd().TrimStart());
        }

        private void TXT_Click(object sender, EventArgs e)
        {
            GENERACION_TXT gt = new GENERACION_TXT();
           
            gt.ShowDialog();



               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ARCHIVOS_PROCESADOS ap = new ARCHIVOS_PROCESADOS();
            ap.ShowDialog();
        }

        private void XLS_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           
             saveFileDialog1.Filter = "*.xls | ";
              

            saveFileDialog1.Title = "Guardar Listado";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excel(du.getDto_Deportes((int)TIPO_ACTIVIDAD.TODOS,cbRol.Text.TrimEnd().TrimStart()), saveFileDialog1.FileName);
                DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n", "LISTO!");

            }


        }

        public void excel(List<DtoDeportes> lista, string path)
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
            
            xlWorkSheet.Cells[1, 1] = "ID_TITULAR";
            xlWorkSheet.Cells[1, 2] = "NRO_SOCIO";
            xlWorkSheet.Cells[1, 3] = "NRO_DEP";
            xlWorkSheet.Cells[1, 4] = "BARRA";
        
            xlWorkSheet.Cells[1, 5] = "NOMBRE_TITULAR";
            xlWorkSheet.Cells[1, 6] = "APELLIDO_TITULAR";
            xlWorkSheet.Cells[1, 7] = "AAR";
            xlWorkSheet.Cells[1, 8] = "ACRJP1";
            xlWorkSheet.Cells[1, 9] = "ACRJP2";
            xlWorkSheet.Cells[1,10 ] = "ACRJP3";
            xlWorkSheet.Cells[1, 11] = "PAR";
            xlWorkSheet.Cells[1, 12] = "PCRJP1";
            xlWorkSheet.Cells[1, 13] = "PCRJP2";
            xlWorkSheet.Cells[1, 14] = "PCRJP3";
            xlWorkSheet.Cells[1, 15] = "MONTO";
            xlWorkSheet.Cells[1, 16] = "DETALLE";
           
            xlWorkSheet.Cells[1, 17] = "DNI";
            xlWorkSheet.Cells[1, 18] = "NOMBRE_APELLIDO";
            xlWorkSheet.Cells[1, 19] = "ROL";


            int I = 2;
            foreach (DtoDeportes item in lista)

            {

                    xlWorkSheet.Cells[I, 1] = item.Nro_Socio;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 2] = item.Nro_Socio;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 3] = item.Nro_Dep;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 4] = item.Barra;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 5] = item.NOMBRE_TITULAR;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 6] = item.APELLIDO_TITULAR;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 7] = item.aar;
                    xlWorkSheet.Columns[1].AutoFit();

                    xlWorkSheet.Cells[I, 8] = item.acrjp1;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 9] = item.acrjp2;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 10] = item.acrjp3;
                    xlWorkSheet.Columns[1].AutoFit();

                    xlWorkSheet.Cells[I, 11] = item.par;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 12] = item.pcrjp1;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 13] = item.pcrjp2;
                    xlWorkSheet.Columns[1].AutoFit();
                    xlWorkSheet.Cells[I, 14] = item.pcrjp3;
                    xlWorkSheet.Columns[1].AutoFit();

                    xlWorkSheet.Cells[I, 15] = item.Monto;
                    xlWorkSheet.Columns[1].AutoFit();

                    xlWorkSheet.Cells[I, 16] = item.DETALLE;
                    xlWorkSheet.Columns[1].AutoFit();

                    xlWorkSheet.Cells[I, 17] = item.DNI;
                    xlWorkSheet.Columns[1].AutoFit();

                    xlWorkSheet.Cells[I, 18] = item.Nombre_Apellido;
                    xlWorkSheet.Columns[1].AutoFit();

                    xlWorkSheet.Cells[I, 19] = item.ROL;
                    xlWorkSheet.Columns[1].AutoFit();
                    I = I + 1;
            }

          
                   

                
            

            


          
            //xlWorkSheet.Columns[5].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[6].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[8].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[10].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[12].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[14].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[16].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[18].EntireColumn.NumberFormat = "000";
            xlWorkSheet.Columns[15].EntireColumn.NumberFormat = "#,###.00 ";
            //xlWorkSheet.Columns[11].EntireColumn.NumberFormat = "#,###.00 ";
            //xlWorkSheet.Columns[15].EntireColumn.NumberFormat = "#,###.00 ";
            //xlWorkSheet.Columns[17].EntireColumn.NumberFormat = "#,###.00 ";
            //xlWorkSheet.Columns[19].EntireColumn.NumberFormat = "#,###.00 ";
            //xlWorkSheet.Columns[21].EntireColumn.NumberFormat = "#,###.00 ";
            //xlWorkSheet.Columns[23].EntireColumn.NumberFormat = "#,###.00 ";
            //xlWorkSheet.Columns[25].EntireColumn.NumberFormat = "#,###.00 ";


            //xlWorkSheet.Columns[28].EntireColumn.NumberFormat = "DD/MM/AAAA";

            //xlWorkSheet.Columns[32].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[33].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[34].EntireColumn.NumberFormat = "000";
            //xlWorkSheet.Columns[35].EntireColumn.NumberFormat = "000";



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

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridDtoDepo.DataSource = du.getDto_Deportes((int)TIPO_ACTIVIDAD.TODOS, cbRol.Text.TrimEnd().TrimStart());
        }
    }
}
