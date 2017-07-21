using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
    public partial class abmAsambleas : Form
    {
        public abmAsambleas()
        {
            InitializeComponent();
            buscarAsambleas();
            tbEleccion.Text = DateTime.Now.Year.ToString();
            tbCerrada.Text = "S";
            tbTipo.Text = "A";
        }

        private void limpiar()
        {
            tbEleccion.Text = "";
            tbTipo.Text = "";
            dpFecha.Text = DateTime.Today.ToShortDateString();
            tbCerrada.Text = "";
            dpFechaTope.Text = DateTime.Today.ToShortDateString();
        }

        private void mostrarAsambleas(DataSet ds)
        {
            dgAsambleas.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string ELECCION = row[0].ToString();
                string TIPO = row[1].ToString();
                string FECHA = string.Empty;

                if (row[2].ToString() != null)
                    FECHA = row[2].ToString().Substring(0, 10);
                else
                    FECHA = null;

                string CERRADO = row[3].ToString();

                string FECHA_TOPE = string.Empty;

                if (row[4].ToString() != null)
                    FECHA_TOPE = row[4].ToString().Substring(0, 10);
                else
                    FECHA_TOPE = null;

                string USUARIO = row[5].ToString().Trim();
                dgAsambleas.Rows.Add(ELECCION, TIPO, FECHA, CERRADO, FECHA_TOPE, USUARIO);
            }
            
            dgAsambleas.ClearSelection();
        }

        private void buscarAsambleas()
        {
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string query = "SELECT ELECCION, TIPO, FECHA, CERRADO, FECHA_TOPE, USUARIO FROM CONTROL_ASISTENCIA ORDER BY ELECCION DESC, TIPO DESC;";
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
                            mostrarAsambleas(ds);
                        }
                        else
                        {
                            MessageBox.Show("NO SE ENCONTRARON REGISTROS CON LA CONDICION INDICADA");
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
        }

        private void cargarDatos()
        {
            tbEleccion.Text = dgAsambleas.SelectedCells[0].Value.ToString();
            tbTipo.Text = dgAsambleas.SelectedCells[1].Value.ToString().Trim();
            dpFecha.Text = dgAsambleas.SelectedCells[2].Value.ToString();
            tbCerrada.Text = dgAsambleas.SelectedCells[3].Value.ToString().Trim();
            dpFechaTope.Text = dgAsambleas.SelectedCells[4].Value.ToString();
        }

        private void nuevaAsamblea()
        {
            int res;
            DateTime FE = Convert.ToDateTime(dpFecha.Text);
            DateTime FE_TOPE = Convert.ToDateTime(dpFechaTope.Text);
            string FECHA = FE.ToString("MM/dd/yyyy");
            string FECHA_TOPE = FE_TOPE.ToString("MM/dd/yyyy");
            string TIPO = tbTipo.Text.Trim();
            int ELECCION = Convert.ToInt32(tbEleccion.Text);
            string CERRADA = tbCerrada.Text.Trim();
            string USUARIO = VGlobales.vp_username;

            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection1 = new FbConnection(connectionString))
                {
                    connection1.Open();
                    FbTransaction transaction1 = connection1.BeginTransaction();
                    string fcmd;
                    fcmd = "INSERT INTO CONTROL_ASISTENCIA (ELECCION, TIPO, FECHA, USUARIO, CERRADO, FECHA_TOPE) ";
                    fcmd += "VALUES (" + ELECCION + ", '" + TIPO + "', '" + FECHA + "', '" + USUARIO + "', '" + CERRADA + "', '" + FECHA_TOPE + "');";
                    FbCommand cmd1 = new FbCommand(fcmd, connection1, transaction1);
                    cmd1.CommandText = fcmd;
                    cmd1.Connection = connection1;
                    cmd1.CommandType = CommandType.Text;
                    res = cmd1.ExecuteNonQuery();
                    MessageBox.Show("ASAMBLEA GENERADA", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    transaction1.Commit();
                    connection1.Close();
                    buscarAsambleas();
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                limpiar();
            }
        }

        private void modificaAsamblea()
        {
            int res;
            DateTime FE_MOD = Convert.ToDateTime(dpFecha.Text);
            DateTime FE_TOPE_MOD = Convert.ToDateTime(dpFechaTope.Text);
            string FECHA_MOD = FE_MOD.ToString("MM/dd/yyyy");
            string FECHA_TOPE_MOD = FE_TOPE_MOD.ToString("MM/dd/yyyy");
            string TIPO_MOD = tbTipo.Text.Trim();
            int ELECCION_MOD = Convert.ToInt32(tbEleccion.Text);
            string CERRADA_MOD = tbCerrada.Text.Trim();
            string USUARIO_MOD = VGlobales.vp_username;

            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection1 = new FbConnection(connectionString))
                {
                    connection1.Open();
                    FbTransaction transaction1 = connection1.BeginTransaction();
                    string fcmd;
                    fcmd = "UPDATE CONTROL_ASISTENCIA SET FECHA = '" + FECHA_MOD + "', FECHA_TOPE = '" + FECHA_TOPE_MOD + "', TIPO = '" + TIPO_MOD + "', CERRADO = '" + CERRADA_MOD + "', USUARIO = '" + USUARIO_MOD + "' WHERE ELECCION = " + ELECCION_MOD + ";";
                    FbCommand cmd1 = new FbCommand(fcmd, connection1, transaction1);
                    cmd1.CommandText = fcmd;
                    cmd1.Connection = connection1;
                    cmd1.CommandType = CommandType.Text;
                    res = cmd1.ExecuteNonQuery();
                    MessageBox.Show("ASAMBLEA MODIFICADA", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    transaction1.Commit();
                    connection1.Close();
                    buscarAsambleas();
                    btnModificaAsamblea.Enabled = false;
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                btnModificaAsamblea.Enabled = false;
                limpiar();
            }
        }

        private void dgAsambleas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatos();
            btnModificaAsamblea.Enabled = true;
        }

        private void btnModificaAsamblea_Click(object sender, EventArgs e)
        {
            modificaAsamblea();
        }

        private void btnNuevaAsamblea_Click(object sender, EventArgs e)
        {
            nuevaAsamblea();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
