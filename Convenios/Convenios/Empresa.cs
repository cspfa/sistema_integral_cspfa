using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using SOCIOS;

namespace Convenios
{
    public partial class Empresa : Form
    {
        bo bo = new bo();
        existe ex = new existe();

        private int ID_EMPRESA { get; set; }

        public Empresa()
        {
            InitializeComponent();
            comboLocalidades();
        }

        private void buscar(string RAZON_SOCIAL)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT C.ID, C.RAZON_SOCIAL, C.DOMICILIO, C.LOCALIDAD, L.LOCALIDAD FROM CONVENIOS_EMPRESAS C, CONVENIOS_LOCALIDADES L WHERE C.RAZON_SOCIAL LIKE '%" + RAZON_SOCIAL + "%' AND C.LOCALIDAD = L.ID ORDER BY C.RAZON_SOCIAL ASC;";
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mostrar(ds);
                        }
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Cursor = Cursors.Default;
        }

        private void mostrar(DataSet ds)
        {
            dgResultadosBuscador.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string ID = row[0].ToString().Trim();
                string RAZON_SOCIAL = row[1].ToString().Trim();
                string DOMICILIO = row[2].ToString().Trim();
                string ID_LOCALIDAD = row[3].ToString().Trim();
                string LOCALIDAD = row[4].ToString().Trim();
                dgResultadosBuscador.Rows.Add(ID, RAZON_SOCIAL, DOMICILIO, ID_LOCALIDAD, LOCALIDAD);
            }
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
            if (tbRazonSocialBuscador.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO LOCALIDAD", "ERROR");
            }
            else
            {
                buscar(tbRazonSocialBuscador.Text.Trim());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbRazonSocial.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO RAZÓN SOCIAL", "ERROR");
            }
            else if (tbDomicilio.Text == "")
            {
                MessageBox.Show("COMPLETAR EL DOMICILIO", "ERROR");
            }
            else 
            {
                try
                {
                    if (ID_EMPRESA > 0)
                    {
                        bo.modificarEmpresa(ID_EMPRESA, tbRazonSocial.Text.Trim(), tbDomicilio.Text.Trim(), int.Parse(cbLocalidad.SelectedValue.ToString()));
                        MessageBox.Show("SE MODIFICÓ LA EMPRESA CORRECTAMENTE", "LISTO");
                        buscar(tbRazonSocial.Text.Trim());
                    }
                    else
                    {
                        if (ex.check("CONVENIOS_EMPRESAS", "RAZON_SOCIAL", tbRazonSocial.Text.Trim()) == false)
                        {
                            bo.nuevaEmpresa(tbRazonSocial.Text.Trim(), tbDomicilio.Text.Trim(), int.Parse(cbLocalidad.SelectedValue.ToString()));
                            MessageBox.Show("SE GUARDO LA EMPRESA CORRECTAMENTE", "LISTO");
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR LA EMPRESA\n" + error, "ERROR");
                }
            }
        }

        private void btnAgregarEmpresa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Localidad localidad = new Localidad();
            localidad.ShowDialog();
            comboLocalidades();
        }

        private void dgResultadosBuscador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgResultadosBuscador.RowCount > 0)
            {
                if (dgResultadosBuscador.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow ROW in dgResultadosBuscador.SelectedRows)
                    {
                        tbRazonSocial.Text = ROW.Cells["RAZON_SOCIAL"].Value.ToString().Trim();
                        cbLocalidad.SelectedValue = ROW.Cells["ID_LOC"].Value.ToString().Trim();
                        tbDomicilio.Text = ROW.Cells["DOMICILIO"].Value.ToString().Trim();
                        ID_EMPRESA = int.Parse(ROW.Cells["ID_EMP"].Value.ToString().Trim());
                    }
                }
            }
        }
    }
}
