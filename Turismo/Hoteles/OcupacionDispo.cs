using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS.Turismo.Hotel;
using Microsoft.Reporting.WinForms;

namespace SOCIOS.Turismo.Hoteles
{
    public partial class OcupacionDispo : Form
    {
        bo dlog = new bo();
        SOCIOS.Turismo.Hotel.DisponibilidadUtils dispo = new DisponibilidadUtils();
        HotelUtils hotelUtils                          = new HotelUtils();
        int Hotel;

        public OcupacionDispo()
        {
            InitializeComponent();
          
        
           // Set the Format type and the CustomFormat string.
             dpFecha.Format = DateTimePickerFormat.Custom;
             dpFecha .CustomFormat = "MM - yyyy";
             this.CargaCombosHotel();
          


        }

        public void CargaCombosHotel()
        {
            string query = "SELECT ID, NOMBRE  FROM  HOTEL WHERE PROPIO=1 ";


            cbHotel.DataSource = null;

            cbHotel.Items.Clear();

            cbHotel.DataSource = dlog.BO_EjecutoDataTable(query);

            cbHotel.DisplayMember = "NOMBRE";

            cbHotel.ValueMember = "ID";

            cbHotel.SelectedItem = 1;

        }

        private void OcupacionDispo_Load(object sender, EventArgs e)
        {

           


           
        
        }

        private void  Load_Reporte(int pHotel, int Mes, int Anio)
        {
            
               
      
            //Datos de la Habitacion!
            hotelUtils.ComboHabitacion(cbHabitacion, pHotel);
            dpFechaHotel.Value = dpFecha.Value;
            lbNombreHotel.Text = cbHotel.Text;
            gpHotelHabitacion.Visible = true;
            Hotel = pHotel;

            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[2];
           
          

            //Establecemos el valor de los parámetros

            parameters[0] = new ReportParameter("Hotel", cbHotel.Text.TrimEnd().TrimStart());
            parameters[1] = new ReportParameter("Mes", dpFecha.Value.Month.ToString() + "/" + dpFecha.Value.Year.ToString().TrimEnd().TrimStart());
            this.reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dispo.ListaDisponibilidad(Hotel, Mes, Anio)));

            this.reportViewer1.RefreshReport();

            reportViewer1.Visible = true;
        
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            this.Load_Repo();
        }

        private  void Load_Repo()


        {int Hotel = Int32.Parse(cbHotel.SelectedValue.ToString());
            gpHotelHabitacion.Visible = false;

            if (this.dispo.MesConReservas(Hotel, dpFecha.Value.Month, dpFecha.Value.Year))
            {
                this.Load_Reporte(Hotel, dpFecha.Value.Month, dpFecha.Value.Year);
            }
            else
            {
                reportViewer1.Visible = false;
                MessageBox.Show("El Hotel y la Fecha  Seleccionada No Presenta Datos Cargados ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            SOCIOS.Turismo.Hoteles.Info_Habitacion info = new Info_Habitacion(Int32.Parse(cbHabitacion.SelectedValue.ToString()),cbHotel.Text,cbHabitacion.Text ,dpFechaHotel.Value);
            DialogResult dr = info.ShowDialog();

            if (dr == DialogResult.Yes)

            { this.Load_Repo();
            
            }
        }


       
    }
}
