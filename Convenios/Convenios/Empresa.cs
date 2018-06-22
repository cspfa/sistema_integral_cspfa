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
        bo bo = new bo();

        private int ID_EMPRESA { get; set; }

        public Empresa()
        {
            InitializeComponent();
            comboLocalidades();
        }

        private void comboLocalidades()
        {
            string query = "SELECT ID, LOCALIDAD FROM CONVENIOS_LOCALIDADES ORDER BY LOCALIDAD ASC;";
            cbLocalidad.DataSource = null;
            cbLocalidad.Items.Clear();
            cbLocalidad.DataSource = bo.BO_EjecutoDataTable(query);
            cbLocalidad.DisplayMember = "LOCALIDAD";
            cbLocalidad.ValueMember = "ID";
            cbLocalidad.SelectedItem = 0;
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
            comboLocalidades();
        }
    }
}
