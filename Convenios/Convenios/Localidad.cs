using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Convenios
{
    public partial class Localidad : Form
    {
        public Localidad()
        {
            InitializeComponent();
        }

        SOCIOS.existe e = new SOCIOS.existe();
        //e.check();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbLocalidad.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO LOCALIDAD", "ERROR");
            }
            else
            { 
                
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
