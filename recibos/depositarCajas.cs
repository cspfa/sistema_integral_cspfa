using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
    public partial class depositarCajas : Form
    {
        bo dlog = new bo();

        public depositarCajas(string CAJAS)
        {
            InitializeComponent();
            CAJAS = CAJAS.Remove(CAJAS.Length - 2);
            buscarBancos();
            buscarCajas(CAJAS, dgCajasSeleccionadas);
        }

        private void buscarBancos()
        {
            conString cs = new conString();
            string connectionString = cs.get();

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                string query = "SELECT ID, NOMBRE FROM BANCOS";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(BANCOS);
                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }
        
        private void buscarCajas(string CAJAS, DataGridView GRILLA)
        {
            try
            {
                string query = "SELECT ID, FECHA, TOTAL FROM CAJA_DIARIA WHERE ID IN (" + CAJAS + ");";
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetString(reader.GetOrdinal("ID")));
                        string FECHA = reader.GetString(reader.GetOrdinal("FECHA")).Substring(0, 10);
                        string TOTAL = string.Format("{0:n}", reader.GetDecimal(reader.GetOrdinal("TOTAL")));
                        GRILLA.Rows.Add(ID, FECHA, TOTAL);
                    }

                    reader.Close();
                    GRILLA.Columns[0].Width = 50;
                    GRILLA.Columns[1].Width = 80;
                    GRILLA.Columns[2].Width = 90;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
