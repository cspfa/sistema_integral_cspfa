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
    public partial class Localidad : Form
    {
        public Localidad()
        {
            InitializeComponent();
        }

        bo bo = new bo();

        private void buscar(string LOCALIDAD)
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
                    string QUERY = "SELECT ID, LOCALIDAD FROM CONVENIOS_LOCALIDADES WHERE LOCALIDAD LIKE '%" + LOCALIDAD + "%' ORDER BY LOCALIDAD ASC;";
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
                string LOCALIDAD = row[1].ToString().Trim();               
                dgResultadosBuscador.Rows.Add(ID, LOCALIDAD);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbLocalidadlBuscador.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO LOCALIDAD", "ERROR");
            }
            else
            {
                buscar(tbLocalidad.Text.Trim());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbLocalidad.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO LOCALIDAD", "ERROR");
            }
            else
            {
                try
                {
                    bo.nuevaLocalidad(tbLocalidad.Text.Trim());
                    MessageBox.Show("LOCALIDAD CREADA CORRECTAMENTE", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO CREAR LA NUEVA LOCALIDAD\n" + error, "ERROR!");
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tbLocalidad.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO LOCALIDAD", "ERROR");
            }
            else
            {
                try
                {
                    MessageBox.Show("LOCALIDAD MODIFICADA CORRECTAMENTE", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO NODIFICAR LA LOCALIDAD\n" + error, "ERROR!");
                }
            }
        }
    }
}
