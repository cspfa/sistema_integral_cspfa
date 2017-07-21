using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono.Odontologia
{
    public partial class BonosXturno : Form
    {

        ServicioOdonto service = new ServicioOdonto();




        public BonosXturno(int Turno)
        {
            
            InitializeComponent();

            service.ComboBonos(cbBono, Turno);


            

            
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            int Bono = Int32.Parse(cbBono.SelectedValue.ToString());

            SOCIOS.bono.Odontologico odonto = new bono.Odontologico(Bono, true);

        }
    }
}
