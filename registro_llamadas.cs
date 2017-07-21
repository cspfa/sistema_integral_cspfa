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
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;

namespace SOCIOS
{
    public partial class registro_llamadas : Form
    {
        bo dlog = new bo();

        public registro_llamadas()
        {
            InitializeComponent();
            cargarLLamadas();
        }

        public void cargarLLamadas()
        {
            string query = "SELECT * FROM CALL_LOG ORDER BY FECHA DESC;";

            if (tbInterno.Text != "" && tbDestino.Text == "")
            {
                query = "SELECT * FROM CALL_LOG WHERE INTERNO = " + tbInterno.Text + " ORDER BY FECHA DESC;";
            }
            else if (tbInterno.Text != "" && tbDestino.Text != "")
            {
                query = "SELECT * FROM CALL_LOG WHERE INTERNO = " + tbInterno.Text + " AND DESTINO = '" + tbDestino.Text + "' ORDER BY FECHA DESC;";
            }
            else if (tbInterno.Text == "" && tbDestino.Text != "")
            {
                query = "SELECT * FROM CALL_LOG WHERE DESTINO = '" + tbDestino.Text + "' ORDER BY FECHA DESC;";
            }

            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
                cs.Database = ini3.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("HORA", typeof(string));
                    dt1.Columns.Add("INTERNO", typeof(string));
                    dt1.Columns.Add("DESTINO", typeof(string));
                    dt1.Columns.Add("DURACION", typeof(string));
                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("FECHA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("HORA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("INTERNO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DESTINO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DURACION")).Trim());
                    }

                    reader3.Close();

                    dgLlamadas.DataSource = dt1;
                    dgLlamadas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgLlamadas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgLlamadas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgLlamadas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgLlamadas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cargarLLamadas();
        }
    }
}
