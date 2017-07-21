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
    public partial class HabitacionHotel : Form
    {
        TurismoUtils tu = new TurismoUtils();
        bo dlog = new bo();
        string MODO = "";
        int ID = 0;

        public HabitacionHotel()
        {
            InitializeComponent();
            tu.UpdateComboHotelPropio(cbHotel);

        }

        private void HabitacionHotel_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void UpdateGrilla(int HOTEL)
        {

            dgvHabitacion.Visible = true;


            string Query = @"select H.ID ID, H.NOMBRE NOMBRE,T.TIPO TIPO, H.PLAZAS PLAZAS from Hotel_Habitacion H , Hotel_Habitacion_Tipo T
                             WHERE H.HABITACION_ID = T.ID AND H.HOTEL_ID =  " + HOTEL.ToString();

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
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("PLAZAS", typeof(string));
                  
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("PLAZAS")).Trim());
                    }

                    reader3.Close();


                    dgvHabitacion.DataSource = dt1;
                    dgvHabitacion.Columns[0].Visible = false;
                    dgvHabitacion.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHabitacion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHabitacion.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHabitacion.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void Filtrar_Click(object sender, EventArgs e)
        {
            this.UpdateGrilla(Int32.Parse(cbHotel.SelectedValue.ToString()));
            gpHabitacionTipo.Visible = false;



        }

        private void BlanquearCampos()

        {

            tu.UpdateComboHabitacionTipo(cbTipo);
            int Tipo = Int32.Parse(cbTipo.SelectedValue.ToString());
            tbPlaza.Text = tu.PLazasInicialesTipoHabitacion(Tipo).ToString();
            tbNombre.Text = "";
            
        
        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            MODO = "INS";
            gpHabitacionTipo.Visible = true;
            this.BlanquearCampos();
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Tipo = Int32.Parse(cbTipo.SelectedValue.ToString());
                tbPlaza.Text = tu.PLazasInicialesTipoHabitacion(Tipo).ToString();
            }
            catch (Exception ex)

            { 
            
            }
        }


        private void Validar()

        { 
        
         if (tbNombre.Text.Length==0)
             throw new Exception("Ingrese Nombre/Tipo");
         if (tbPlaza.Text.Length==0)
             throw new Exception("Ingrese PLaza");
         else if (Int32.Parse(tbPlaza.Text) ==0)
             throw new Exception("PLaza No puede ser 0");


        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {

            try
            {
                int Hotel = Int32.Parse(cbHotel.SelectedValue.ToString());
                int Tipo = Int32.Parse(cbTipo.SelectedValue.ToString());

                if (MODO == "INS")
                {

                    dlog.Hotel_Habitacion_Ins(Hotel, Tipo, Int32.Parse(tbPlaza.Text), tbNombre.Text);

                }
                else
                {
                    dlog.Hotel_Habitacion_Baja(ID);
                }


                UpdateGrilla(Hotel);
                gpHabitacionTipo.Visible = false;

                MessageBox.Show("Datos Guardados con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHabitacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }

        private void CancelarBank_Click(object sender, EventArgs e)
        {
            MODO = "UPD";
            int Hotel = Int32.Parse(cbHotel.SelectedValue.ToString());
            try
            {
                if (MessageBox.Show("Seguro de Borrar La Habitacion del Hotel?", "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dlog.Hotel_Habitacion_Baja(ID);
                    UpdateGrilla(Hotel);
                    MessageBox.Show("Datos Guardados con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)



            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

        }

        private void dgvHabitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgvHabitacion.SelectedRows[0].Cells[0].Value.ToString());
        }

    }
}
