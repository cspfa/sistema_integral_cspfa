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
    public partial class Info_Habitacion : Form
    {
        int Habitacion;
        SOCIOS.Turismo.Hotel.DisponibilidadUtils du = new Hotel.DisponibilidadUtils();
        int Registro;
        int ID;

        public Info_Habitacion(int pHabitacion,string Hotel,string nHabitacion,DateTime Fecha)
        {
            InitializeComponent();
            
            Habitacion               = pHabitacion;
            lbNombreHabitacion.Text  = nHabitacion;
            lbNombreHotel.Text       = Hotel;
            dpFecha.Value            = Fecha;
            this.LoadData(Habitacion, Fecha);





        }

        private void LoadData(int Habitacion, DateTime fecha)


        {
            dataGridDispo.DataSource = du.Ocupacion(Habitacion, fecha);

            dataGridDispo.Columns[0].Visible = false;
            dataGridDispo.Columns[1].Visible = false;
            dataGridDispo.Columns[2].Visible = false;
            dataGridDispo.Columns[11].Visible = false;
        
        
        }

        private void dpFecha_ValueChanged(object sender, EventArgs e)
        {
            dataGridDispo.DataSource = du.Ocupacion(Habitacion, dpFecha.Value);
        }

        private void dataGridDispo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Registro = Int32.Parse(dataGridDispo.SelectedRows[0].Cells[11].Value.ToString());
            ID       = Int32.Parse(dataGridDispo.SelectedRows[0].Cells[0].Value.ToString());


        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Liberar las plazas de la Ocupacion? " ,"Confirmacion Borrar Registro ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    du.Liberar_Ocupacion(ID);
                    this.LoadData(Habitacion, dpFecha.Value);

                }
              
                 catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                
                

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SOCIOS.Turismo.Solicitudes.Personas_Solicitud pr = new SOCIOS.Turismo.Solicitudes.Personas_Solicitud(Registro,lbNombreHabitacion.Text,dpFecha.Value.ToShortDateString());
            pr.ShowDialog();
           
        }

        private void Info_Habitacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void Info_Habitacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
