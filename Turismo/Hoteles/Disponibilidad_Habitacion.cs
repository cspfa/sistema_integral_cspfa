using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Turismo.Hoteles
{
    public partial class Disponibilidad_Habitacion : Form
    {
        bo dlog = new bo();
        Hotel.HotelUtils           hu     = new Hotel.HotelUtils();
        Solicitudes.SolicitudUtils su     = new Solicitudes.SolicitudUtils();
        DateTime Fecha;
        int PLazas;
        public Habitacion hab;

        public Disponibilidad_Habitacion(DateTime pFecha, int pPLazas)
        {
            InitializeComponent();
            UpdateComboHotel();
            Fecha        = pFecha;
            PLazas       = pPLazas;
            
            lbFecha.Text = pFecha.ToShortDateString();
            lbPlaza.Text = pPLazas.ToString();
        }

        public void UpdateComboHotel()
        {
            string query = "SELECT ID, NOMBRE  FROM  HOTEL WHERE PROPIO=1 ";
            

            cbHotel.DataSource = null;

            cbHotel.Items.Clear();

            cbHotel.DataSource = dlog.BO_EjecutoDataTable(query);

            cbHotel.DisplayMember = "NOMBRE";

            cbHotel.ValueMember = "ID";

            cbHotel.SelectedItem = 1;

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            dgvHabitaciones.DataSource = hu.HabitacionesDisponibles(Int32.Parse(cbHotel.SelectedValue.ToString()), Fecha, PLazas);
           
            dgvHabitaciones.Columns[0].Visible = false;
            dgvHabitaciones.Columns[1].Visible = false;
            dgvHabitaciones.Columns[3].Visible = false;
            dgvHabitaciones.Columns[5].Visible = false;
            
        }

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            Confirmacion.Visible = true;


             

          
        }

        private void dgvHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Confirmacion_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvHabitaciones.SelectedRows[0];

            
            hab = new Habitacion(Int32.Parse(dr.Cells[0].Value.ToString()),
                                  Int32.Parse(dr.Cells[1].Value.ToString()),
                                  dr.Cells[2].Value.ToString(),
                                  Int32.Parse(dr.Cells[3].Value.ToString()),
                                  dr.Cells[4].Value.ToString(),
                                  Int32.Parse(dr.Cells[5].Value.ToString()),
                                  dr.Cells[6].Value.ToString(),
                                  Int32.Parse(dr.Cells[7].Value.ToString()),
                                  PLazas,
                                  DateTime.Parse(dr.Cells[9].Value.ToString()),
                                  cbBloqueo.Checked);


        }
    }
}
