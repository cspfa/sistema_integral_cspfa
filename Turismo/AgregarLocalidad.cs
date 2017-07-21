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
    public partial class AgregarLocalidad : Form
    {
        bo dlog = new bo();
        SOCIOS.Turismo.TurismoUtils utilsTurismo = new TurismoUtils();
        int Provincia;
        int INICIO = 1;
        public AgregarLocalidad()
        {
            InitializeComponent();
        }

        public AgregarLocalidad(int pProvincia)
        {
            InitializeComponent();
            Provincia = pProvincia;
            utilsTurismo.UpdateComboProvincia(0, cbProvincia);
            cbProvincia.SelectedItem = Provincia;
            FiltrarGrilla(Provincia);
            INICIO = 0;
        
        }

        public void FiltrarGrilla(int Provincia)


        {

           string Query = @" SELECT DESCRIPCION NOMBRE, DES_SHORT ABREVIATURA FROM LOCALIDAD WHERE PROVINCIAID=  " + Provincia.ToString();

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

               
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("ABREVIATURA", typeof(string));
                   
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ABREVIATURA")).Trim());
                    }

                    reader3.Close();

                
                        dgvLocalidad.DataSource = dt1;
                        dgvLocalidad.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvLocalidad.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                      
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNombre.Text.Length == 0)
                    throw new Exception("DEBE INGRESAR NOMBRE");
                   
                if (tbAbrev.Text.Length == 0)
                {
                    throw new Exception("DEBE INGRESAR ABREVIATURA");
                  

                }

                if (tbAbrev.Text.Length > 10)
                {
                   throw new  Exception ("ABREVIATURA NO PUEDE SER MAYOR A 10 CARACTERES");

                }

                Provincia = Int32.Parse(cbProvincia.SelectedValue.ToString());



                dlog.Localidad_Ins(Provincia, tbNombre.Text, tbAbrev.Text);
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (INICIO == 0 && cbProvincia.SelectedItem != null)
                this.FiltrarGrilla(Int32.Parse(cbProvincia.SelectedValue.ToString()));
        }
    }
}
