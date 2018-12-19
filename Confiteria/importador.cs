using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS;

namespace Confiteria
{
    public partial class importador : Form
    {
        string ROL { get; set; }

        public importador(string P_ROL)
        {
            InitializeComponent();
            ROL = P_ROL;
            cajasDiarias();
            comandas();
        }

        private void cajasDiarias()
        {
            conString conString = new conString();
            string connectionString = conString.getRemota(ROL);

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT * FROM CONFITERIA_CAJA_DIARIA_S WHERE EXPORTADA = 0 AND ROL = '" + ROL + "';";
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

        private void comandas()
        {
            conString conString = new conString();
            string connectionString = conString.getRemota(ROL);

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT NRO_COMANDA, FECHA, IMPORTE, NOMBRE_SOCIO, NRO_SOC, NRO_DEP, ID FROM CONFITERIA_COMANDAS WHERE EXPORTADA = 0 AND ROL = '" + ROL + "';";
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    dgComandas.Rows.Clear();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string NRO_COMANDA = row[0].ToString().Trim();
                        decimal IMPORTE = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[2].ToString()))));
                        string FECHA = row[1].ToString().Trim().Substring(0, 10);
                        string NOMBRE = row[3].ToString().Trim();
                        string NRO_SOC = row[4].ToString().Trim();
                        string NRO_DEP = row[5].ToString().Trim();
                        string ID = row[6].ToString().Trim();
                        dgComandas.Rows.Add(NRO_COMANDA, IMPORTE, FECHA, NOMBRE, NRO_SOC, NRO_DEP, ID);
                    }

                    dgComandas.ClearSelection();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void importar()
        {

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

        }
    }
}
