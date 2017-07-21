using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Tecnica
{
    public partial class ABM_Seguimiento : Form
    {
        int TICKET;
        bo_Tecnica dlog = new bo_Tecnica();
        public ABM_Seguimiento(int pTicket)
        {
            InitializeComponent();
            Grabar.Visible = true;
            TICKET = pTicket;

        }

        public ABM_Seguimiento(string Texto,DateTime Fecha)
        {
            InitializeComponent();
            tbSeguimiento.Text = Texto;
            dpFecha.Value = Fecha;
            Grabar.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            dlog.Asistencia_Tecnica_Nuevo_Seguimiento(TICKET, tbSeguimiento.Text, dpFecha.Value); 
        }
    }
}
