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
    public partial class Convenios : Form
    {
        public Convenios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarEmpresa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Empresa empresa = new Empresa();
            empresa.ShowDialog();
        }
    }
}
