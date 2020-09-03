using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SOCIOS.Turismo
{
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
            IniciarFiltros();
        }

        private void IniciarFiltros()
        {
            dpDesde.Text = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1).ToShortDateString();
            dpHasta.Text = new DateTime(System.DateTime.Now.AddMonths(1).Year, System.DateTime.Now.AddMonths(1).Month, 1).ToShortDateString();
            //cbFiltro.Items.Insert(0, "PASAJES");
            //cbFiltro.Items.Insert(1, "SALIDAS");
            //cbFiltro.Items.Insert(2, "HOTELES");
            //cbFiltro.SelectedValue = 0;
            //cbFiltro.Refresh();

        }

        //private void btnFiltro_Click(object sender, EventArgs e)
        //{
        //    this.RefrescarGrilla();
        //}


        //private void RefrescarGrilla()
        //{

        //    int Tipo = cbFiltro.SelectedIndex;
        //    if (Tipo == 0)
        //    {
        //        dgvStats.DataSource = (new TurismoStats()).Stats_Memoria_Pasajes(dpDesde.Value, dpHasta.Value);
        //    } else if (Tipo ==2)
        //      dgvStats.DataSource = (new TurismoStats()).Stats_Memoria_Hoteles(Tipo, dpDesde.Value, dpHasta.Value);


        //}

        public void XLS_STATS(DateTime desde, DateTime hasta)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
         

            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            Excel.Worksheet HOTEL;
            HOTEL = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
           

            HOTEL = xlWorkBook.Worksheets[1];
            HOTEL.Name = "HOTELES";
            Excel.Worksheet PASAJE;
            PASAJE = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
            PASAJE.Name = "PASAJES";
            PASAJE = xlWorkBook.Worksheets[2];

            HOTEL.Cells[1, 1] = "NRO";
            HOTEL.Cells[1, 2] = "FECHA";
             HOTEL.Cells[1, 3] = "NOMBRE";
             HOTEL.Cells[1, 4] = "DESTINO";
             HOTEL.Cells[1, 5] = "PAX";
             HOTEL.Cells[1, 6] = "NOCHES";
             HOTEL.Cells[1, 7] = "PLAZAS";
             HOTEL.Cells[1, 8] = "CONTADO";
             HOTEL.Cells[1, 9] = "CUOTAS";
             HOTEL.Cells[1, 10] = "VALOR CUOTA";
             HOTEL.Cells[1, 11] = "TOTAL";
             HOTEL.Cells[1, 12] = "OBS";
             HOTEL.Cells[1, 13] = "OBS_PAGO";
            int I = 2;

            foreach (Memoria_Hotel m in (new TurismoStats()).Stats_Memoria_Hoteles(2, desde, hasta))
            {
                 HOTEL.Cells[I, 1] = m.Nro_Solicitud;
                 HOTEL.Cells[I, 2] = m.Fecha;
                 HOTEL.Cells[I, 3] = m.Nombre_Apellido;
                 HOTEL.Cells[I, 4] = m.Destino;
                 HOTEL.Cells[I, 5] = m.Pax;
                 HOTEL.Cells[I, 6] = m.Noches;
                 HOTEL.Cells[I, 7] = m.Plazas;
                 HOTEL.Cells[I, 8] = m.Contado;
                 HOTEL.Cells[I, 9] = m.Cuotas;
                 HOTEL.Cells[I, 10] = m.Valor_Cuota;
                 HOTEL.Cells[I, 11] = m.Total;
                 HOTEL.Cells[I, 12] = m.Obs;
                 HOTEL.Cells[I, 13] = m.Obs_Pago;
                I = I + 1;
            }
            I = 2;

            PASAJE.Cells[1, 1] = "NRO";
            PASAJE.Cells[1, 2] = "FECHA";
            PASAJE.Cells[1, 3] = "NOMBRE";
            PASAJE.Cells[1, 4] = "DESTINO";
            PASAJE.Cells[1, 5] = "PAX";
            PASAJE.Cells[1, 6] = "NOCHES";
            PASAJE.Cells[1, 7] = "PLAZAS";
            PASAJE.Cells[1, 8] = "CONTADO";
            PASAJE.Cells[1, 9] = "CUOTAS";
            PASAJE.Cells[1, 10] = "VALOR CUOTA";
            PASAJE.Cells[1, 11] = "TOTAL";
            PASAJE.Cells[1, 12] = "OBS";
            PASAJE.Cells[1, 13] = "OBS_PAGO";


            foreach (Memoria m in (new TurismoStats()).Stats_Memoria_Pasajes(desde, hasta))
            {
                PASAJE.Cells[I, 1] = m.Nro_Solicitud;
                PASAJE.Cells[I, 2] = m.Fecha; 
                PASAJE.Cells[I, 3] = m.Nombre_Apellido;
                PASAJE.Cells[I, 4] = m.Destino;
                PASAJE.Cells[I, 5] = m.Pax;
               
                PASAJE.Cells[I, 6] = m.Contado;
                PASAJE.Cells[I, 7] = m.Cuotas;
                PASAJE.Cells[I, 8] = m.Valor_Cuota;
                PASAJE.Cells[I, 9] = m.Total;
                PASAJE.Cells[I, 10] = m.Obs;
                PASAJE.Cells[I, 11] = m.Obs_Pago;
                I = I + 1;
            }


            string ARCHIVO = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo XLS|*.xls";
            saveFileDialog1.Title = "Guardar Listado";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ARCHIVO = saveFileDialog1.FileName;
            }

            xlWorkBook.SaveAs(ARCHIVO, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
          
            releaseObject(HOTEL);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            MessageBox.Show("EXCEL GENERADO CORRECTAMENTE", "LISTO!");
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

        private void XLS_Click(object sender, EventArgs e)
        {
            XLS_STATS(dpDesde.Value, dpHasta.Value);
        }
    }
}
