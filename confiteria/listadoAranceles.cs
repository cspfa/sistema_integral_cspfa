using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS.confiteria
{
    public partial class listadoAranceles : Form
    {
        public listadoAranceles()
        {
            InitializeComponent();
        }

        private void buscarAranceles()
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
                    string query = "SELECT * FROM CONFITERIA_ARANCELES;";
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
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("NO SE ENCONTRARON RESULTADOS");
                        }
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO OBTENER EL DATO\n " + error, "ERROR");
            }
        }

        private void listadoAranceles_Load(object sender, EventArgs e)
        {
            buscarAranceles();
        }
    }
}
