using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Turismo.Solicitudes
{
    public partial class Personas_Solicitud : Form
    {
        Solicitudes.SolicitudUtils su = new SolicitudUtils();
        public Personas_Solicitud(int REG,string Habitacion, string Fecha)
        {
            InitializeComponent();
            
            dgSolicitud.DataSource = su.Personas_Registro(REG);
            lbFecha.Text = Fecha;
            lbHabitacion.Text = Habitacion;

        }
    }
}
