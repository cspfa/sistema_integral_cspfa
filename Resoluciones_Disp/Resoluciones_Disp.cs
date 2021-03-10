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


namespace Resoluciones_Disp
{
    public partial class Resoluciones_Disp : Form
    {
        bo bo = new bo();
        Utils util = new Utils();

        public Resoluciones_Disp()
        {
            InitializeComponent();
            comboTipos(cbTipo);
        }

        private void comboTipos(ComboBox COMBO)
        {
            string query = "SELECT ID, TIPO FROM RES_Y_DISP_TIPO ";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = bo.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "TIPO";
            COMBO.ValueMember = "ID";
            COMBO.SelectedItem = -1;
        }

        private void ResolucionesDisposiciones_Load(object sender, EventArgs e)
        {
            comboTipos(cbTipo);
            buscar();
        }

        private void buscar()
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
                    string QUERY = "SELECT * FROM RES_Y_DISP;";

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
                        else
                        {
                            MessageBox.Show("NO SE ENCONTRARON RESULTADOS", "OUCH!");
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
            dgResolucionesDisposiciones.Rows.Clear();

            string query = "SELECT ANIO, NUMERO, DESCRIPCION FROM RES_Y_DISP";
            DataTable dt = bo.BO_EjecutoDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                string ANIO = row[0].ToString();
                string NUMERO = row[1].ToString().Trim();
                string DESCRIPCION = row[2].ToString().Trim();

                dgResolucionesDisposiciones.Rows.Add(ANIO, NUMERO, DESCRIPCION);
            }

            dgResolucionesDisposiciones.ClearSelection();
            pintarResultados();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void pintarResultados()
        {
            if (dgResolucionesDisposiciones.Rows.Count > 0)
            {
                int X = 0;

                foreach (DataGridViewRow row in dgResolucionesDisposiciones.Rows)
                {
                    if ( (X % 2) == 0)
                    {
                        dgResolucionesDisposiciones.Rows[X].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        dgResolucionesDisposiciones.Rows[X].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        dgResolucionesDisposiciones.Rows[X].DefaultCellStyle.BackColor = Color.LightBlue;
                        dgResolucionesDisposiciones.Rows[X].DefaultCellStyle.ForeColor = Color.Black;
                    }

                    X++;
                }
            }
        }
    }
}
