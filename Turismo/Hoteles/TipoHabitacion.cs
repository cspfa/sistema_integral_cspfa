using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;

namespace SOCIOS.Turismo
{
    public partial class TipoHabitacion : Form
    {
       
        bo dlog = new bo();
        SOCIOS.Turismo.TurismoUtils utilsTurismo = new TurismoUtils();

        int Inicio;
        string Nombre;
        int ID;
        string Modo;

        public void BLanqueoCampos()

        {
            tbTipo.Text   = "";
            tbCamas.Text  = "";
        }
        public TipoHabitacion()
        {
            InitializeComponent();

            this.BindGrilla();

        }

        private void CancelarBank_Click(object sender, EventArgs e)
        {

        }

        private void dgvSalidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            Modo = "INS";
            this.BLanqueoCampos();
            this.gpDatos.Visible = true;

        }

        private void BindGrilla()

        {
            //this.Blanquear_Campos();
            gpDatos.Visible = false;

            string Query = @"select  ID , TIPO, CAMAS from  HOTEL_HABITACION_TIPO  ";

            string connectionString;

            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();

            try
            {
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
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("CAMAS", typeof(string));
                    
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("CAMAS")).Trim());
                    }

                    reader3.Close();



                    dgvTipoHabitacion.DataSource = dt1;

                    dgvTipoHabitacion.Columns[0].Visible = false;
                    dgvTipoHabitacion.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTipoHabitacion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTipoHabitacion.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        
        }

        private void CancelarBank_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvTipoHabitacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Modo == "INS")
                    dlog.Tipo_Habitacion_Ins(tbTipo.Text, Int32.Parse(tbCamas.Text));
                else
                    dlog.Tipo_Habitacion_Upd(ID, tbTipo.Text, Int32.Parse(tbCamas.Text));


                this.BindGrilla();
                MessageBox.Show("Datos Guardados con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dgvTipoHabitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgvTipoHabitacion.SelectedRows[0].Cells[0].Value.ToString());
            tbTipo.Text = dgvTipoHabitacion.SelectedRows[0].Cells[1].Value.ToString();
            tbCamas.Text = dgvTipoHabitacion.SelectedRows[0].Cells[2].Value.ToString();

            gpDatos.Visible = true;
            Modo = "UPD";
        }

        
    }
}
