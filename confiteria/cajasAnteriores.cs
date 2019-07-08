using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SOCIOS;

namespace Confiteria
{
    public partial class cajasAnteriores : Form
    {
        public cajasAnteriores()
        {
            InitializeComponent();
        }

        private void cajasDiarias()
        {
            dgCajasAnteriores.DataSource = null;
            conString conString = new conString();
            string connectionString = conString.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT * FROM CONFITERIA_CAJA_DIARIA_S WHERE ROL = '" + VGlobales.vp_role + "';";
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    dgCajasAnteriores.Rows.Clear();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string ID = row[0].ToString().Trim();
                        string FECHA = row[1].ToString().Trim().Substring(0, 10);
                        string USUARIO = row[2].ToString().Trim();
                        decimal EFECTIVO = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[3].ToString()))));
                        decimal TARJETAS = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[4].ToString()))));
                        decimal DESCUENTOS = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[5].ToString()))));
                        decimal ESPECIALES = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[6].ToString()))));
                        dgCajasAnteriores.Rows.Add(ID, FECHA, USUARIO, EFECTIVO, TARJETAS, DESCUENTOS, ESPECIALES);
                    }

                    dgCajasAnteriores.ClearSelection();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void cajasAnteriores_Load(object sender, EventArgs e)
        {
            cajasDiarias();
        }

        private void btnImprimirListado_Click(object sender, EventArgs e)
        {
            grillaPreComanda gp = new grillaPreComanda();
            int RENDIDA = int.Parse(dgCajasAnteriores[0, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
            gp.imprimirListado("SI", RENDIDA, "NO");
        }
    }
}
