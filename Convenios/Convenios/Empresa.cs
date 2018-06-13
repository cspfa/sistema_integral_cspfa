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
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarEmpresa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Localidad localidad = new Localidad();
            localidad.ShowDialog();
        }
    }
}
