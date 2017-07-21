using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS.bono
{
    public partial class PersonasBono : Form
    {
       public  DataGridViewSelectedRowCollection Seleccion;

        public PersonasBono(string NRO_SOC, string NRO_DEP, List<DatoSocio> Seleccion)
        {
            InitializeComponent();
            this.InicioGrilla(NRO_SOC, NRO_DEP, Seleccion);
        }

        private void InicioGrilla(string NRO_SOC, string NRO_DEP,List<DatoSocio> Seleccion)
        {
            string query = "SELECT * FROM P_OBTENER_FAMADH(" + NRO_SOC + "," + NRO_DEP + ")";
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

                    dt1.Columns.Add("ID_TITULAR", typeof(string));
                    dt1.Columns.Add("NRO_SOC", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("NUM_DOC", typeof(string));
                    dt1.Columns.Add("ACRJP2", typeof(string));
                    dt1.Columns.Add("SOCIO", typeof(string));
                    dt1.Columns.Add("EDAD", typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID_TITULAR")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BARRA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NUM_DOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ACRJP2")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("SOCIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("EDAD")).Trim() );
                    }

                    reader3.Close();
                    dgvGrupo.DataSource = dt1;

                    dgvGrupo.Columns[0].Visible = false;
                    dgvGrupo.Columns[8].Visible = false;

                    transaction.Commit();


                    //matcheo Seleccion 
                    dgvGrupo.ClearSelection();
                    dgvGrupo.MultiSelect = true;
                   
                    foreach (DataGridViewRow row in dgvGrupo.Rows)
                    {

                        string Barra = row.Cells["BARRA"].Value.ToString();
                        string NRO = row.Cells["NRO_SOC"].Value.ToString();
                        string DEP = row.Cells["NRO_DEP"].Value.ToString();

                        foreach(DatoSocio  val in Seleccion )
                        {
                            if ((val.BARRA == Barra  && val.NRO_SOCIO == NRO && val.NRO_DEP ==DEP) ) 
                                row.Selected= true;
                         
                        }
                    }
             
                  


                   

                    dgvGrupo.DataSource = dt1;  


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {

            try
            {
                bool Control_Ed = false;
                foreach (DataGridViewRow dr in dgvGrupo.SelectedRows)

                { 


                  if (dr.Cells[10].Value != null)
                     
                    
                      Control_Ed =this.Control_Edad(dr.Cells[6].Value.ToString(),Int32.Parse(dr.Cells[3].Value.ToString()));
                      
                    if ( dr.Cells[10].Value.ToString().Length == 0  && Control_Ed ==true )  
                      {
                          throw new Exception("Falta Cargar Edad en Personas Seleccionadas");
                      
                      }
                
                }
                
                Seleccion = dgvGrupo.SelectedRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private bool Control_Edad(string Tipo, int Barra)

        {

            if (Tipo.Contains("FAM") && Barra > 3)
                return true;

            if (Tipo.Contains("ADH") && Barra > 2)
                return true;
            if (Tipo.Contains("NO SOCIO") && Barra > 2)
                return true;
            if (Tipo.Contains("EMP") && Barra > 2)
                return true;

            return false;
        
        }

        private void dgvGrupo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvGrupo.Rows[e.RowIndex];// get you required index
                // check the cell value under your specific column and then you can toggle your colors
                if (row.Cells[10].Value.ToString().Length == 0)
                    row.DefaultCellStyle.BackColor = Color.Yellow;
            }
            catch (Exception ex)
            {


            }
        }

       
    }
}
