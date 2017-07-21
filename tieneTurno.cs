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
    public partial class tieneTurno : Form
    {
        public tieneTurno(string NRO_SOC, string NRO_DEP, string BARRA, string TIPO_SOC)
        {
            InitializeComponent();

            string FECHA = DateTime.Today.ToShortDateString();

            string DAY = FECHA.Substring(0, 2);

            string MONTH = FECHA.Substring(3, 2);

            string YEAR = FECHA.Substring(6, 4);

            string FECHA_FINAL = MONTH + "/" + DAY + "/" + YEAR;

            string query = "SELECT * FROM P_TIENE_TURNO (" + NRO_SOC + ", '" + FECHA_FINAL + "', " + NRO_DEP + ", 0);";

            if (TIPO_SOC == "FAM")
            {
                query = "SELECT * FROM P_TIENE_TURNO (" + NRO_SOC + ", '" + FECHA_FINAL + "', " + NRO_DEP + ", " + BARRA + ");";
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

                    dt1.Columns.Add("ESPECIALIDAD", typeof(string));
                    dt1.Columns.Add("PROFESIONAL", typeof(string));
                    dt1.Columns.Add("DESDE", typeof(string));
                    dt1.Columns.Add("HASTA", typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ESPECIALIDAD")).Trim(),
                                        reader3.GetString(reader3.GetOrdinal("PROFESIONAL")).Trim(),
                                        reader3.GetString(reader3.GetOrdinal("DESDE")).Trim().Substring(0, 5),
                                        reader3.GetString(reader3.GetOrdinal("HASTA")).Trim().Substring(0, 5));
                    }

                    reader3.Close();

                    dgvTurnos.DataSource = dt1;
                    dgvTurnos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTurnos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTurnos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTurnos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    transaction.Commit();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error);
            }
        }

        private void btnDarIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dgvTurnos.CurrentCell.Value.ToString());
        }
    }
}
