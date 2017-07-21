using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS.Tecnica
{
    public partial class Seguimientos : Form
    {
        int TICKET;
        int ID;
        string TEXTO;
        DateTime FECHA;
        public Seguimientos(int pTICKET)
        {
            InitializeComponent();
            TICKET = pTICKET;

            lbIncidente.Text = "TICKET NRO : " + TICKET.ToString();
            this.BindData();

        }

        private void BindData()
        {
            string query = @"select ID,COMEN,FECHA,F_A ALTA, USR_A USUARIO from SEGUIMIENTOS_ASISTENCIA_TECNICA  where ASISTENCIA_TECNICA =  " + TICKET.ToString();








            //MessageBox.Show(query);

            string connectionString;

            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();


            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini3.Servidor; //cs.Port = int.Parse(ini3.Puerto);
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

                dt1.Columns.Add("ID", typeof(string));
                dt1.Columns.Add("COMEN", typeof(string));
                dt1.Columns.Add("NOMBRE", typeof(string));
                dt1.Columns.Add("FECHA", typeof(string));
                dt1.Columns.Add("ALTA", typeof(string));
                dt1.Columns.Add("USUARIO", typeof(string));

                ds1.Tables.Add(dt1);

                FbCommand cmd = new FbCommand(query, connection, transaction);

                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {
                    dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                 reader3.GetString(reader3.GetOrdinal("COMEN")).Trim(),
                                 reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                 reader3.GetString(reader3.GetOrdinal("FECHA")).Trim(),
                                 reader3.GetString(reader3.GetOrdinal("ALTA")).Trim(),
                                 reader3.GetString(reader3.GetOrdinal("USUARIO")).Trim());
                }

                reader3.Close();

                dataGridView1.DataSource = dt1;
                
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                transaction.Commit();



            }
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            ABM_Seguimiento abm = new ABM_Seguimiento(TICKET);
            DialogResult res = abm.ShowDialog();

            if (res == DialogResult.OK)
            {
                MessageBox.Show("Seguimientos Actualizados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BindData();


            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            ID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            TEXTO = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            FECHA = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ABM_Seguimiento abm = new ABM_Seguimiento(TEXTO, FECHA);

            abm.ShowDialog();
        }
    }
}
