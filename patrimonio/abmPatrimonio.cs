using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class abmPatrimonio : Form
    {
        bo_Patrimonio dlog = new bo_Patrimonio();

        public abmPatrimonio()
        {
            InitializeComponent();
            buscarPatrimonio();
            comboTipos();
            comboDivPatrimonio();
        }

        private void comboTipos()
        {
            string query = "SELECT ID, TRIM(DETALLE) AS DETALLE FROM PATRIMONIO_TIPO ORDER BY DETALLE ASC;";
            cbTipo.DataSource = null;
            cbTipo.Items.Clear();
            cbTipo.DataSource = dlog.BO_EjecutoDataTable(query);
            cbTipo.DisplayMember = "DETALLE";
            cbTipo.ValueMember = "ID";
            cbTipo.SelectedItem = 0;
        }

        private void comboDivPatrimonio()
        {
            string query = "SELECT ID, TRIM(DETALLE) AS DETALLE FROM PATRIMONIO_DIV ORDER BY DETALLE ASC;";
            cbDivPatrimonio.DataSource = null;
            cbDivPatrimonio.Items.Clear();
            cbDivPatrimonio.DataSource = dlog.BO_EjecutoDataTable(query);
            cbDivPatrimonio.DisplayMember = "DETALLE";
            cbDivPatrimonio.ValueMember = "ID";
            cbDivPatrimonio.SelectedItem = 0;
        }

        private void btnNuevoPatrimonio_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "")
            {
                MessageBox.Show("EL CAMPO NOMBRE ES NECESARIO", "ERROR");
            }
            else
            {
                try
                {
                    int TIPO = int.Parse(cbTipo.SelectedValue.ToString());
                    int DIV_PATR = int.Parse(cbDivPatrimonio.SelectedValue.ToString());
                    int NUMERO = int.Parse(tbNumero.Text);
                    string NOMBRE = tbNombre.Text.Trim();
                    string DOMICILIO = tbDomicilio.Text.Trim();
                    string LATITUD = tbLatitud.Text.Trim();
                    string LONGITUD = tbLongitud.Text.Trim();
                    dlog.altaPatrimonio(TIPO, DIV_PATR, NUMERO, NOMBRE, DOMICILIO, LATITUD, LONGITUD);
                    MessageBox.Show("SE AGREGO EL PATRIMONIO CORRECTAMENTE", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("EL PATRIMONIO NO PUDO SER AGREGADO\n" + error, "ERROR");
                }
            }
        }

        private void buscarPatrimonio()
        {
            conString conString = new conString();
            string connectionString = conString.get();

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                DataSet ds = new DataSet();
                string query = "SELECT P.ID, T.DETALLE, V.DETALLE, P.NUMERO, P.NOMBRE, P.DOMICILIO, P.LATITUD, P.LONGITUD FROM PATRIMONIO P, PATRIMONIO_TIPO T, PATRIMONIO_DIV V WHERE P.DIV_PATR = V.ID AND P.TIPO = T.ID ORDER BY P.NOMBRE ASC;";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);
                
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mostrarPatrimonio(ds);
                    }
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private void mostrarPatrimonio(DataSet DATOS)
        {
            try
            {
                dgPatrimonio.Rows.Clear();

                foreach (DataRow row in DATOS.Tables[0].Rows)
                {
                    string ID = row[0].ToString().Trim();
                    string TIPO = row[1].ToString().Trim();
                    string DIV_PATR = row[2].ToString().Trim();
                    string NUMERO = row[3].ToString().Trim();
                    string NOMBRE = row[4].ToString().Trim();
                    string DOMICILIO = row[5].ToString().Trim();
                    string LATITUD = row[6].ToString().Trim();
                    string LONGITUD = row[7].ToString().Trim();
                    dgPatrimonio.Rows.Add(ID, TIPO, DIV_PATR, NUMERO, NOMBRE, DOMICILIO, LATITUD, LONGITUD);
                }

                dgPatrimonio.ClearSelection();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void dgPatrimonio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dgPatrimonio[6, dgPatrimonio.CurrentCell.RowIndex].Value.ToString());
        }
    }
}
